//------------------------------------------------------------------------------
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
// Contributor(s): _______. 
//------------------------------------------------------------------------------

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using NopSolutions.NopCommerce.BusinessLogic.Configuration.Settings;
using NopSolutions.NopCommerce.BusinessLogic.Directory;
using NopSolutions.NopCommerce.Common.Utils;
using NopSolutions.NopCommerce.Shipping.Methods.UPS;
using NopSolutions.NopCommerce.Web.Administration.Modules;
using NopSolutions.NopCommerce.Web.Templates.Shipping;
using System.Text;
using LWG.Business;
using LWG.Core.Models;

namespace NopSolutions.NopCommerce.Web.Administration.Shipping.UPSConfigure
{
    public partial class ConfigureShipping : BaseNopAdministrationUserControl, IConfigureShippingRateComputationMethodModule
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillDropDowns();
                FillServices();
                BindData();
            }
        }

        private void FillDropDowns()
        {
            this.ddlUPSCustomerClassification.Items.Clear();
            string[] customerClassifications = Enum.GetNames(typeof(UPSCustomerClassification));
            foreach (string cc in customerClassifications)
            {
                ListItem ddlItem1 = new ListItem(CommonHelper.ConvertEnum(cc), cc);
                this.ddlUPSCustomerClassification.Items.Add(ddlItem1);
            }

            this.ddlUPSPickupType.Items.Clear();
            string[] pickupTypies = Enum.GetNames(typeof(UPSPickupType));
            foreach (string pt in pickupTypies)
            {
                ListItem ddlItem1 = new ListItem(CommonHelper.ConvertEnum(pt), pt);
                this.ddlUPSPickupType.Items.Add(ddlItem1);
            }

            this.ddlUPSPackagingType.Items.Clear();
            string[] packagingTypies = Enum.GetNames(typeof(UPSPackagingType));
            foreach (string pt in packagingTypies)
            {
                ListItem ddlItem1 = new ListItem(CommonHelper.ConvertEnum(pt), pt);
                this.ddlUPSPackagingType.Items.Add(ddlItem1);
            }

            this.ddlShippedFromCountry.Items.Clear();
            CountryCollection countries = CountryManager.GetAllCountries();
            foreach (Country country in countries)
            {
                ListItem ddlItem1 = new ListItem(country.Name, country.CountryId.ToString());
                this.ddlShippedFromCountry.Items.Add(ddlItem1);
            }
        }

        private void FillServices()
        {
            chkListUPSServices.DataSource = UPSComputationMethod.UPSServices;
            chkListUPSServices.DataTextField = "ServiceName";
            chkListUPSServices.DataValueField = "ServiceID";
            chkListUPSServices.DataBind();
        }

        private void BindConvertionGrid()
        {
            ShippingConvertionBiz biz = new ShippingConvertionBiz();
            gvConvertion.DataSource = biz.GetAllConvertionByType(ShippingConvertionType.UPS);
            gvConvertion.DataBind();
        }
        private void BindData()
        {
            txtURL.Text = SettingManager.GetSettingValue("ShippingRateComputationMethod.UPS.URL");
            txtAccessKey.Text = SettingManager.GetSettingValue("ShippingRateComputationMethod.UPS.AccessKey");
            txtUsername.Text = SettingManager.GetSettingValue("ShippingRateComputationMethod.UPS.Username");
            txtPassword.Text = SettingManager.GetSettingValue("ShippingRateComputationMethod.UPS.Password");
            txtAdditionalHandlingCharge.Value = SettingManager.GetSettingValueDecimalNative("ShippingRateComputationMethod.UPS.AdditionalHandlingCharge");

            int defaultShippedFromCountryId = SettingManager.GetSettingValueInteger("ShippingRateComputationMethod.UPS.DefaultShippedFromCountryId");
            CommonHelper.SelectListItem(ddlShippedFromCountry, defaultShippedFromCountryId);
            txtShippedFromZipPostalCode.Text = SettingManager.GetSettingValue("ShippingRateComputationMethod.UPS.DefaultShippedFromZipPostalCode");


            string customerClassificationStr = SettingManager.GetSettingValue("ShippingRateComputationMethod.UPS.CustomerClassification");
            if (!String.IsNullOrEmpty(customerClassificationStr))
            {
                UPSCustomerClassification customerClassification = (UPSCustomerClassification)Enum.Parse(typeof(UPSCustomerClassification), customerClassificationStr);
                CommonHelper.SelectListItem(ddlUPSCustomerClassification, customerClassification.ToString());
            }

            string pickupTypeStr = SettingManager.GetSettingValue("ShippingRateComputationMethod.UPS.PickupType");
            if (!String.IsNullOrEmpty(pickupTypeStr))
            {
                UPSPickupType pickupType = (UPSPickupType)Enum.Parse(typeof(UPSPickupType), pickupTypeStr);
                CommonHelper.SelectListItem(ddlUPSPickupType, pickupType.ToString());
            }

            string packagingTypeStr = SettingManager.GetSettingValue("ShippingRateComputationMethod.UPS.PackagingType");
            if (!String.IsNullOrEmpty(packagingTypeStr))
            {
                UPSPackagingType packagingType = (UPSPackagingType)Enum.Parse(typeof(UPSPackagingType), packagingTypeStr);
                CommonHelper.SelectListItem(ddlUPSPackagingType, packagingType.ToString());
            }

            // bingding carrier service offered
            string carrierServiceOffered = SettingManager.GetSettingValue("ShippingRateComputationMethod.USP.CarrierServicesOffered");
            foreach (ListItem item in chkListUPSServices.Items)
            {
                if (carrierServiceOffered.Contains(item.Value))
                    item.Selected = true;
            }

            BindConvertionGrid();
        }

        public void Save()
        {
            UPSCustomerClassification customerClassification = (UPSCustomerClassification)Enum.Parse(typeof(UPSCustomerClassification), ddlUPSCustomerClassification.SelectedItem.Value);
            UPSPickupType pickupType = (UPSPickupType)Enum.Parse(typeof(UPSPickupType), ddlUPSPickupType.SelectedItem.Value);
            UPSPackagingType packagingType = (UPSPackagingType)Enum.Parse(typeof(UPSPackagingType), ddlUPSPackagingType.SelectedItem.Value);

            SettingManager.SetParam("ShippingRateComputationMethod.UPS.URL", txtURL.Text);
            SettingManager.SetParam("ShippingRateComputationMethod.UPS.AccessKey", txtAccessKey.Text);
            SettingManager.SetParam("ShippingRateComputationMethod.UPS.Username", txtUsername.Text);
            SettingManager.SetParam("ShippingRateComputationMethod.UPS.Password", txtPassword.Text);
            SettingManager.SetParamNative("ShippingRateComputationMethod.UPS.AdditionalHandlingCharge", txtAdditionalHandlingCharge.Value);
            int defaultShippedFromCountryId = int.Parse(this.ddlShippedFromCountry.SelectedItem.Value);
            SettingManager.SetParam("ShippingRateComputationMethod.UPS.DefaultShippedFromCountryId", defaultShippedFromCountryId.ToString());
            SettingManager.SetParam("ShippingRateComputationMethod.UPS.DefaultShippedFromZipPostalCode", txtShippedFromZipPostalCode.Text);

            SettingManager.SetParam("ShippingRateComputationMethod.UPS.CustomerClassification", customerClassification.ToString());
            SettingManager.SetParam("ShippingRateComputationMethod.UPS.PickupType", pickupType.ToString());
            SettingManager.SetParam("ShippingRateComputationMethod.UPS.PackagingType", packagingType.ToString());
            SettingManager.SetParam("ShippingRateComputationMethod.USP.CarrierServicesOffered", GetCarrierServiceOffered());
        }

        string GetCarrierServiceOffered()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ListItem item in chkListUPSServices.Items)
            {
                if (item.Selected)
                    sb.AppendFormat("{0}:", item.Value);
            }
            return sb.ToString();
        }

        protected void btnAddConvertion_Click(object sender, EventArgs e)
        {
            ShippingConvertionBiz convertionBiz = new ShippingConvertionBiz();
            int priceFrom, priceTo, chargeWeight;
            if (!string.IsNullOrEmpty(txtPriceFrom.Text))
            {
                if (!Int32.TryParse(txtPriceFrom.Text, out priceFrom))
                {
                    return;
                }
            }
            else
            {
                priceFrom = 0;
            }

            if (!string.IsNullOrEmpty(txtPriceTo.Text))
            {
                if (!Int32.TryParse(txtPriceTo.Text, out priceTo))
                {
                    return;
                }
            }
            else
            {
                priceTo = Int32.MaxValue;
            }

            if (!Int32.TryParse(txtChargeWeight.Text, out chargeWeight))
            {
                return;
            }
            convertionBiz.AddConvertion(priceFrom, priceTo, chargeWeight, ShippingConvertionType.UPS);
            ResetConvertionAdd();
            BindConvertionGrid();
        }
        void ResetConvertionAdd()
        {
            txtPriceFrom.Text = string.Empty;
            txtPriceTo.Text = string.Empty;
            txtChargeWeight.Text = string.Empty;
        }
        protected void gvConvertion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateConvertion")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvConvertion.Rows[index];

                HiddenField hdID = row.FindControl("hdID") as HiddenField;
                TextBox txtFrom = row.FindControl("txtFrom") as TextBox;
                TextBox txtTo = row.FindControl("txtTo") as TextBox;
                TextBox txtChargeWeight = row.FindControl("txtChargeWeight") as TextBox;

                int id, priceFrom, priceTo, chargeWeight;
                if (!Int32.TryParse(hdID.Value, out id))
                    return;
                if (!Int32.TryParse(txtFrom.Text, out priceFrom))
                    return;
                if (!Int32.TryParse(txtTo.Text, out priceTo))
                    return;
                if (!Int32.TryParse(txtChargeWeight.Text, out chargeWeight))
                    return;

                ShippingConvertionBiz biz = new ShippingConvertionBiz();
                if (biz.UpdateConvertion(id, priceFrom, priceTo, chargeWeight, ShippingConvertionType.UPS))
                    BindConvertionGrid();

            }
        }

        protected void gvConvertion_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)gvConvertion.DataKeys[e.RowIndex]["ID"];
            ShippingConvertionBiz biz = new ShippingConvertionBiz();
            biz.DeleteConvertion(id);
            BindConvertionGrid();
        }

        protected void gvConvertion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnUpdate = e.Row.FindControl("btnUpdate") as Button;
                lwg_ShippingConvertionConfig config = e.Row.DataItem as lwg_ShippingConvertionConfig;
                if (btnUpdate != null)
                    btnUpdate.CommandArgument = e.Row.RowIndex.ToString();
            }
        }
    }
}
