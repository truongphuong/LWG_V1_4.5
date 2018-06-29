﻿//------------------------------------------------------------------------------
// The contents of this file are subject to the nopCommerce Public License Version 1.0 ("License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at  http://www.nopCommerce.com/License.aspx. 
// 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. 
// See the License for the specific language governing rights and limitations under the License.
// 
// The Original Code is nopCommerce.
// The Initial Developer of the Original Code is NopSolutions.
// All Rights Reserved.
// 
// Contributor(s): 
//------------------------------------------------------------------------------

using System;
using System.IO;
using System.Net;
using System.Text;
using NopSolutions.NopCommerce.BusinessLogic.Configuration.Settings;
using NopSolutions.NopCommerce.BusinessLogic.Directory;
using NopSolutions.NopCommerce.BusinessLogic.Measures;
using NopSolutions.NopCommerce.BusinessLogic.Shipping;
using NopSolutions.NopCommerce.Common;
using System.Collections.Specialized;

namespace NopSolutions.NopCommerce.Shipping.Methods.AustraliaPost
{
    /// <summary>
    /// Australia post computation method
    /// </summary>
    public class AustraliaPostComputationMethod : IShippingRateComputationMethod
    {
        #region Constants

        private const int MAX_LENGTH = 1050; // 105 cm
        private const int MAX_WEIGHT = 20000; // 20 Kg

        #endregion

        #region Utilities

        private static int GetWeight(ShipmentPackage ShipmentPackage)
        {
            int value = Convert.ToInt32(Math.Ceiling(MeasureManager.ConvertWeight(ShippingManager.GetShoppingCartTotalWeigth(ShipmentPackage.Items, ShipmentPackage.Customer), MeasureManager.BaseWeightIn, AustraliaPostSettings.MeasureWeight)));
            return (value < 1 ? 1 : value);
        }

        private static int GetLength(ShipmentPackage ShipmentPackage)
        {
            int value = Convert.ToInt32(Math.Ceiling(MeasureManager.ConvertDimension(ShipmentPackage.GetTotalLength(), MeasureManager.BaseDimensionIn, AustraliaPostSettings.MeasureDimension)));
            return (value < 1 ? 1 : value);
        }

        private static int GetWidth(ShipmentPackage ShipmentPackage)
        {
            int value = Convert.ToInt32(Math.Ceiling(MeasureManager.ConvertDimension(ShipmentPackage.GetTotalWidth(), MeasureManager.BaseDimensionIn, AustraliaPostSettings.MeasureDimension)));
            return (value < 1 ? 1 : value);
        }

        private static int GetHeight(ShipmentPackage ShipmentPackage)
        {
            int value = Convert.ToInt32(Math.Ceiling(MeasureManager.ConvertDimension(ShipmentPackage.GetTotalHeight(), MeasureManager.BaseDimensionIn, AustraliaPostSettings.MeasureDimension)));
            return (value < 1 ? 1 : value);
        }

        private static ShippingOption RequestShippingOption(string ZipPostalCodeFrom, string ZipPostalCodeTo, string CountryCode, string ServiceType, int weight, int length, int width, int height)
        {
            ShippingOption shippingOption = new ShippingOption();
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Pickup_Postcode={0}&", ZipPostalCodeFrom);
            sb.AppendFormat("Destination_Postcode={0}&", ZipPostalCodeTo);
            sb.AppendFormat("Country={0}&", CountryCode);
            sb.AppendFormat("Service_Type={0}&", ServiceType);
            sb.AppendFormat("Weight={0}&", weight);
            sb.AppendFormat("Length={0}&", length);
            sb.AppendFormat("Width={0}&", width);
            sb.AppendFormat("Height={0}&", height);
            sb.Append("Quantity=1");

            HttpWebRequest request = WebRequest.Create(AustraliaPostSettings.GatewayUrl) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            byte[] reqContent = Encoding.ASCII.GetBytes(sb.ToString());
            request.ContentLength = reqContent.Length;
            using (Stream newStream = request.GetRequestStream())
            {
                newStream.Write(reqContent, 0, reqContent.Length);
            }

            WebResponse response = request.GetResponse();
            string rspContent;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                rspContent = reader.ReadToEnd();
            }

            string[] tmp = rspContent.Split(new char[] { '\n' }, 3);
            if (tmp.Length != 3)
            {
                throw new NopException("Response is not valid.");
            }

            NameValueCollection rspParams = new NameValueCollection();
            foreach (string s in tmp)
            {
                string[] tmp2 = s.Split(new char[] { '=' });
                if (tmp2.Length != 2)
                {
                    throw new NopException("Response is not valid.");
                }
                rspParams.Add(tmp2[0].Trim(), tmp2[1].Trim());
            }


            string err_msg = rspParams["err_msg"];
            if (!err_msg.ToUpperInvariant().StartsWith("OK"))
            {
                throw new NopException(err_msg);
            }

            shippingOption.Name = ServiceType;
            shippingOption.Description = String.Format("{0} Days", rspParams["days"]);
            shippingOption.Rate = Decimal.Parse(rspParams["charge"]);

            return shippingOption;
        }
        #endregion

        #region Methods
        /// <summary>
        ///  Gets available shipping options
        /// </summary>
        /// <param name="shipmentPackage">Shipment package</param>
        /// <param name="error">Error</param>
        /// <returns>Shipping options</returns>
        public ShippingOptionCollection GetShippingOptions(ShipmentPackage shipmentPackage, ref string error)
        {
            ShippingOptionCollection shippingOptions = new ShippingOptionCollection();

            if (shipmentPackage == null)
            {
                throw new ArgumentNullException("shipmentPackage");
            }
            if (shipmentPackage.Items == null)
            {
                throw new NopException("No shipment items");
            }
            if (shipmentPackage.ShippingAddress == null)
            {
                error = "Shipping address is not set";
                return shippingOptions;
            }

            shipmentPackage.ZipPostalCodeFrom = AustraliaPostSettings.ShippedFromZipPostalCode;
            string ZipPostalCodeFrom = shipmentPackage.ZipPostalCodeFrom;
            string ZipPostalCodeTo = shipmentPackage.ShippingAddress.ZipPostalCode;
            int weight = GetWeight(shipmentPackage);
            int length = GetLength(shipmentPackage);
            int width = GetWidth(shipmentPackage);
            int height = GetHeight(shipmentPackage);
            Country country = shipmentPackage.ShippingAddress.Country;

            if(length > MAX_LENGTH)
            {
                error = "Length exceed.";
                return shippingOptions;
            }
            if(weight > MAX_WEIGHT)
            {
                error = "Weight exceed.";
                return shippingOptions;
            }

            try
            {
                switch(country.ThreeLetterIsoCode)
                {
                    case "AUS":
                        shippingOptions.Add(RequestShippingOption(ZipPostalCodeFrom, ZipPostalCodeTo, country.TwoLetterIsoCode, "Standard", weight, length, width, height));
                        shippingOptions.Add(RequestShippingOption(ZipPostalCodeFrom, ZipPostalCodeTo, country.TwoLetterIsoCode, "Express", weight, length, width, height));
                        shippingOptions.Add(RequestShippingOption(ZipPostalCodeFrom, ZipPostalCodeTo, country.TwoLetterIsoCode, "EXP_PLT", weight, length, width, height));
                        break;
                    default:
                        shippingOptions.Add(RequestShippingOption(ZipPostalCodeFrom, ZipPostalCodeTo, country.TwoLetterIsoCode, "Air", weight, length, width, height));
                        shippingOptions.Add(RequestShippingOption(ZipPostalCodeFrom, ZipPostalCodeTo, country.TwoLetterIsoCode, "Sea", weight, length, width, height));
                        shippingOptions.Add(RequestShippingOption(ZipPostalCodeFrom, ZipPostalCodeTo, country.TwoLetterIsoCode, "ECI_D", weight, length, width, height));
                        shippingOptions.Add(RequestShippingOption(ZipPostalCodeFrom, ZipPostalCodeTo, country.TwoLetterIsoCode, "ECI_M", weight, length, width, height));
                        shippingOptions.Add(RequestShippingOption(ZipPostalCodeFrom, ZipPostalCodeTo, country.TwoLetterIsoCode, "EPI", weight, length, width, height));
                        break;
                }

                foreach(ShippingOption shippingOption in shippingOptions)
                {
                    shippingOption.Rate += AustraliaPostSettings.AdditionalHandlingCharge;
                }
            }
            catch(Exception ex)
            {
                error = ex.Message;
            }
            return shippingOptions;
        }

        /// <summary>
        /// Gets fixed shipping rate (if shipping rate computation method allows it and the rate can be calculated before checkout).
        /// </summary>
        /// <param name="shipmentPackage">Shipment package</param>
        /// <returns>Fixed shipping rate; or null if shipping rate could not be calculated before checkout</returns>
        public decimal? GetFixedRate(ShipmentPackage shipmentPackage)
        {
            return null;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets a shipping rate computation method type
        /// </summary>
        /// <returns>A shipping rate computation method type</returns>
        public ShippingRateComputationMethodTypeEnum ShippingRateComputationMethodType
        {
            get
            {
                return ShippingRateComputationMethodTypeEnum.Realtime;
            }
        }

        #endregion
    }
}

