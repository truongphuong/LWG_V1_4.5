using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NopSolutions.NopCommerce.BusinessLogic.Shipping;
using NopSolutions.NopCommerce.BusinessLogic.Configuration.Settings;
using NopSolutions.NopCommerce.BusinessLogic.Measures;
using NopSolutions.NopCommerce.Common;
using NopSolutions.NopCommerce.BusinessLogic.Directory;
using System.Net;
using System.IO;
using System.Xml;
using System.Globalization;
using LWG.Business;
using NopSolutions.NopCommerce.BusinessLogic.Products;
using NopSolutions.NopCommerce.BusinessLogic.Orders;

namespace Shipping.Methods.DHL
{
    public class DHLComputationMethod : IShippingRateComputationMethod
    {
        #region private
        private const string MEASUREWEIGHTSYSTEMKEYWORD = "lb";
        private const string MEASUREDIMENSIONSYSTEMKEYWORD = "inches";
        private string ProductCodeToken = "$ProductCode$";
        #endregion
        #region Utilities
        string CreateRequest(string siteid, string password, string cityFrom, string divisionFrom, ShipmentPackage shipmentPackage)
        {
            var usedMeasureWeight = MeasureManager.GetMeasureWeightBySystemKeyword(MEASUREWEIGHTSYSTEMKEYWORD);
            if (usedMeasureWeight == null)
                throw new NopException(string.Format("UPS shipping service. Could not load \"{0}\" measure weight", MEASUREWEIGHTSYSTEMKEYWORD));

            var usedMeasureDimension = MeasureManager.GetMeasureDimensionBySystemKeyword(MEASUREDIMENSIONSYSTEMKEYWORD);
            if (usedMeasureDimension == null)
                throw new NopException(string.Format("UPS shipping service. Could not load \"{0}\" measure dimension", MEASUREDIMENSIONSYSTEMKEYWORD));

            int length = Convert.ToInt32(Math.Ceiling(MeasureManager.ConvertDimension(shipmentPackage.GetTotalLength(), MeasureManager.BaseDimensionIn, usedMeasureDimension)));
            int height = Convert.ToInt32(Math.Ceiling(MeasureManager.ConvertDimension(shipmentPackage.GetTotalHeight(), MeasureManager.BaseDimensionIn, usedMeasureDimension)));
            int width = Convert.ToInt32(Math.Ceiling(MeasureManager.ConvertDimension(shipmentPackage.GetTotalWidth(), MeasureManager.BaseDimensionIn, usedMeasureDimension)));
            int weight;
            decimal totalPrice = decimal.Zero;
            foreach (ShoppingCartItem item in shipmentPackage.Items)
            {
                totalPrice += PriceHelper.GetSubTotal(item, true);
            }
            ShippingConvertionBiz convertionBiz = new ShippingConvertionBiz();
            weight = convertionBiz.GetWeightFromTotalPrice(totalPrice, ShippingConvertionType.DHL);

            if (length < 1)
                length = 1;
            if (height < 1)
                height = 1;
            if (width < 1)
                width = 1;
            if (weight < 1)
                weight = 1;

            StringBuilder sb = new StringBuilder();
            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.Append("<req:ShipmentBookRatingRequest xmlns:req=\"http://www.dhl.com\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.dhl.com ship-book-rate-req.xsd\">");

            // header
            sb.Append("<Request>");
            sb.Append("<ServiceHeader>");
            sb.Append(string.Format("<MessageTime>{0}</MessageTime>", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz")));
            sb.Append(string.Format("<MessageReference>{0}</MessageReference>", Guid.NewGuid().ToString().Replace("-", "")));
            sb.Append(string.Format("<SiteID>{0}</SiteID>", siteid));
            sb.Append(string.Format("<Password>{0}</Password>", password));
            sb.Append("</ServiceHeader>");
            sb.Append("</Request>");

            //Shipper
            sb.Append("<Shipper>");
            sb.Append(string.Format("<City>{0}</City>", cityFrom));
            sb.Append(string.Format("<Division>{0}</Division>", divisionFrom));
            sb.Append(string.Format("<PostalCode>{0}</PostalCode>", shipmentPackage.ZipPostalCodeFrom));
            sb.Append(string.Format("<CountryCode>{0}</CountryCode>", shipmentPackage.CountryFrom.TwoLetterIsoCode));
            sb.Append("</Shipper>");

            //Consignee
            sb.Append("<Consignee>");
            sb.Append(string.Format("<City>{0}</City>", shipmentPackage.ShippingAddress.City));
            sb.Append(string.Format("<Division>{0}</Division>", shipmentPackage.ShippingAddress.StateProvince != null ? shipmentPackage.ShippingAddress.StateProvince.Name : string.Empty));
            sb.Append(string.Format("<PostalCode>{0}</PostalCode>", shipmentPackage.ShippingAddress.ZipPostalCode));
            sb.Append(string.Format("<CountryCode>{0}</CountryCode>", shipmentPackage.ShippingAddress.Country.TwoLetterIsoCode));
            sb.Append("</Consignee>");

            //Shipment Details
            sb.Append("<ShipmentDetails>");
            sb.Append("<NumberOfPieces>1</NumberOfPieces>");
            sb.Append("<Pieces>");
            sb.Append("<Piece>");
            sb.Append("<PieceID>1</PieceID>");
            sb.Append("<PackageType>OD</PackageType>");
            sb.Append(string.Format("<Weight>{0}</Weight>", weight));
            sb.Append("<DimWeight>1</DimWeight>");
            sb.Append(string.Format("<Width>{0}</Width>", width));
            sb.Append(string.Format("<Height>{0}</Height>", height));
            sb.Append(string.Format("<Depth>{0}</Depth>", length));
            sb.Append("</Piece>");
            sb.Append("</Pieces>");
            sb.Append("<WeightUnit>L</WeightUnit>");
            sb.Append("<DimensionUnit>I</DimensionUnit>");
            sb.Append(string.Format("<Weight>{0}</Weight>", weight));
            sb.Append(string.Format("<ProductCode>{0}</ProductCode>", ProductCodeToken));
            sb.Append("</ShipmentDetails>");


            sb.Append("</req:ShipmentBookRatingRequest>");
            return sb.ToString();
        }
        private string DoRequest(string URL, string RequestString)
        {
            byte[] bytes = new ASCIIEncoding().GetBytes(RequestString);
            var request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST";
            request.ContentType = "text/xml";
            request.ContentLength = bytes.Length;
            var requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            var response = request.GetResponse();
            string responseXML = string.Empty;
            using (var reader = new StreamReader(response.GetResponseStream()))
                responseXML = reader.ReadToEnd();

            return responseXML;
        }

        private ShippingOption ParseResponse(string response, ref string error)
        {
            ShippingOption shippingOption = null;

            using (var sr = new StringReader(response))
            using (var tr = new XmlTextReader(sr))
                while (tr.Read())
                {
                    if ((tr.Name == "Status") && (tr.NodeType == XmlNodeType.Element))
                    {
                        string errorText = "";
                        while (tr.Read())
                        {
                            if ((tr.Name == "ActionStatus") && (tr.NodeType == XmlNodeType.Element))
                            {
                                if (tr.ReadString().ToLower() == "error")
                                {
                                    while (tr.Read())
                                    {
                                        if ((tr.Name == "ConditionData" && tr.NodeType == XmlNodeType.Element))
                                        {
                                            errorText += tr.ReadString() + ", ";
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                        error = "DHL Error returned: " + errorText;
                    }
                    else
                        if ((tr.Name == "Rated") && (tr.NodeType == XmlNodeType.Element))
                        {
                            if (tr.ReadString().ToUpper() == "Y")
                            {
                                string monetaryValue = "";
                                while (tr.Read())
                                {
                                    if ((tr.Name == "ShippingCharge") && (tr.NodeType == XmlNodeType.Element))
                                    {
                                        monetaryValue = tr.ReadString();
                                        break;
                                    }
                                    if (((tr.Name == "PackageCharge") && (tr.NodeType == XmlNodeType.EndElement)) || ((tr.Name == "RatedPackage") && (tr.NodeType == XmlNodeType.Element)))
                                    {
                                        monetaryValue = tr.ReadString();
                                        break;
                                    }
                                }


                                shippingOption = new ShippingOption();
                                shippingOption.Rate = Convert.ToDecimal(monetaryValue, new CultureInfo("en-US"));
                                shippingOption.Name = "";
                                break;
                            }
                        }
                }

            return shippingOption;
        }
        #endregion
        public ShippingOptionCollection GetShippingOptions(ShipmentPackage shipmentPackage, ref string error)
        {
            var shippingOptions = new ShippingOptionCollection();

            if (shipmentPackage == null)
                throw new ArgumentNullException("shipmentPackage");
            if (shipmentPackage.Items == null)
                throw new NopException("No shipment items");
            if (shipmentPackage.ShippingAddress == null)
            {
                error = "Shipping address is not set";
                return shippingOptions;
            }

            string url = SettingManager.GetSettingValue("ShippingRateComputationMethod.DHL.URL");
            string siteid = SettingManager.GetSettingValue("ShippingRateComputationMethod.DHL.SiteID");
            string password = SettingManager.GetSettingValue("ShippingRateComputationMethod.DHL.Password");
            string countryFrom = SettingManager.GetSettingValue("ShippingRateComputationMethod.DHL.ShippingCountry");
            string cityFrom = SettingManager.GetSettingValue("ShippingRateComputationMethod.DHL.ShippingCity");
            string divisionFrom = SettingManager.GetSettingValue("ShippingRateComputationMethod.DHL.ShippingDivision");
            string postalCodeFrom = SettingManager.GetSettingValue("ShippingRateComputationMethod.DHL.DefaultShippedFromZipPostalCode");
            decimal additionalHandlingCharge = SettingManager.GetSettingValueDecimalNative("ShippingRateComputationMethod.DHL.AdditionalHandlingCharge");

            shipmentPackage.CountryFrom = CountryManager.GetCountryByTwoLetterIsoCode(SettingManager.GetSettingValue("ShippingRateComputationMethod.DHL.ShippingCountry"));
            shipmentPackage.ZipPostalCodeFrom = postalCodeFrom;

            string requestStringWithTokens = CreateRequest(siteid, password, cityFrom, divisionFrom, shipmentPackage);
            bool isDomestic = IsDomestic(shipmentPackage);

            string carrierServices = string.Empty;
            if (isDomestic)
            {
                carrierServices = SettingManager.GetSettingValue("ShippingRateComputationMethod.DHL.DomesticServices");

                foreach (DHLService service in domesticSeviceList)
                {
                    if (carrierServices.Contains(service.ServiceID))
                    {
                        string requestString = requestStringWithTokens.Replace(ProductCodeToken, service.ServiceID);
                        string responseXML = DoRequest(url, requestString);
                        var shippingOption = ParseResponse(responseXML, ref error);
                        if (shippingOption != null)
                        {
                            shippingOption.Name = string.Format("DHL {0}", GetServiceName(service.ServiceID, true));
                            shippingOption.Rate += additionalHandlingCharge;
                            shippingOptions.Add(shippingOption);
                        }
                    }
                }
            }
            else
            {
                carrierServices = SettingManager.GetSettingValue("ShippingRateComputationMethod.DHL.InternationalServices");
                foreach (DHLService service in intlServiceList)
                {
                    if (carrierServices.Contains(service.ServiceID))
                    {
                        string requestString = requestStringWithTokens.Replace(ProductCodeToken, service.ServiceID);
                        string responseXML = DoRequest(url, requestString);
                        var shippingOption = ParseResponse(responseXML, ref error);
                        if (shippingOption != null)
                        {
                            shippingOption.Name = string.Format("DHL {0}", GetServiceName(service.ServiceID, false));
                            shippingOption.Rate += additionalHandlingCharge;
                            shippingOptions.Add(shippingOption);
                        }
                    }
                }
            }
            return shippingOptions;
        }

        string GetServiceName(string serviceID, bool isDomestic)
        {
            string serviceName = string.Empty;
            if (isDomestic)
            {
                serviceName = domesticSeviceList.Find(s => s.ServiceID == serviceID).ServiceName;
            }
            else
            {
                serviceName = intlServiceList.Find(s => s.ServiceID == serviceID).ServiceName;
            }
            return serviceName;
        }
        bool IsDomestic(ShipmentPackage shipmentPackage)
        {
            bool result = true;
            if (shipmentPackage != null &&
                shipmentPackage.ShippingAddress != null &&
                shipmentPackage.ShippingAddress.Country != null && shipmentPackage.CountryFrom != null)
            {
                result = shipmentPackage.ShippingAddress.Country.ThreeLetterIsoCode == "USA" && shipmentPackage.CountryFrom.ThreeLetterIsoCode == "USA";
            }
            return result;
        }

        public decimal? GetFixedRate(ShipmentPackage shipmentPackage)
        {
            return null;
        }

        public ShippingRateComputationMethodTypeEnum ShippingRateComputationMethodType
        {
            get
            {
                return ShippingRateComputationMethodTypeEnum.Realtime;
            }
        }

        #region static
        static List<DHLService> intlServiceList;
        static List<DHLService> domesticSeviceList;
        static DHLComputationMethod()
        {
            intlServiceList = new List<DHLService>();
            intlServiceList.Add(new DHLService("D", "Express Worldwide (document)"));
            intlServiceList.Add(new DHLService("E", "Express 9:00 (non-document)"));
            intlServiceList.Add(new DHLService("K", "Express 9:00 (document)"));
            intlServiceList.Add(new DHLService("L", "Express 10:30 (document)"));
            intlServiceList.Add(new DHLService("M", "Express 10:30 (non-document)"));
            intlServiceList.Add(new DHLService("P", "Express Worldwide (non-document)"));
            intlServiceList.Add(new DHLService("T", "Express 12:00 (document)"));
            intlServiceList.Add(new DHLService("X", "Express Envelope (document)"));
            intlServiceList.Add(new DHLService("Y", "Express 12:00 (non-document)"));

            domesticSeviceList = new List<DHLService>();
            domesticSeviceList.Add(new DHLService("N", "Domestic Express (document)"));
        }
        public static List<DHLService> DHLIntlServices
        {
            get
            {
                return intlServiceList;
            }
        }

        public static List<DHLService> DHLDomesticServices
        {
            get
            {
                return domesticSeviceList;
            }
        }
        #endregion
    }

    public struct DHLService
    {
        string _serviceId;
        string _serviceName;
        public DHLService(string _id, string _name)
        {
            _serviceId = _id;
            _serviceName = _name;
        }
        public string ServiceID
        {
            get
            {
                return _serviceId;
            }
        }
        public string ServiceName
        {
            get
            {
                return _serviceName;
            }
        }
    }
}
