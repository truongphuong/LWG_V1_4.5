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
using NopSolutions.NopCommerce.Common.Utils;
using NopSolutions.NopCommerce.Web.Administration.Modules;
using NopSolutions.NopCommerce.Web.Templates.Shipping;
using NopSolutions.NopCommerce.BusinessLogic.Directory;
using LWG.Business;
using LWG.Core.Models;
using Shipping.Methods.DHL;
using System.Text;

namespace NopSolutions.NopCommerce.Web.Administration.Shipping.DHLConfigure
{
    public partial class ConfigureShipping : BaseNopAdministrationUserControl, IConfigureShippingRateComputationMethodModule
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillServices();
                BindData();                
            }
        }
        private void FillServices()
        {
            chkListDHLIntlServices.DataSource = DHLComputationMethod.DHLIntlServices;
            chkListDHLIntlServices.DataTextField = "ServiceName";
            chkListDHLIntlServices.DataValueField = "ServiceID";
            chkListDHLIntlServices.DataBind();

            chkListDHLDomesticServices.DataSource = DHLComputationMethod.DHLDomesticServices;
            chkListDHLDomesticServices.DataTextField = "ServiceName";
            chkListDHLDomesticServices.DataValueField = "ServiceID";
            chkListDHLDomesticServices.DataBind();
        }
        private void BindData()
        {
            txtURL.Text = SettingManager.GetSettingValue("ShippingRateComputationMethod.DHL.URL");
            txtUsername.Text = SettingManager.GetSettingValue("ShippingRateComputationMethod.DHL.SiteID");
            txtPassword.Text = SettingManager.GetSettingValue("ShippingRateComputationMethod.DHL.Password");
            txtAdditionalHandlingCharge.Value = SettingManager.GetSettingValueDecimalNative("ShippingRateComputationMethod.DHL.AdditionalHandlingCharge");
            txtShippingCountry.Text = SettingManager.GetSettingValue("ShippingRateComputationMethod.DHL.ShippingCountry");
            txtShippingCity.Text = SettingManager.GetSettingValue("ShippingRateComputationMethod.DHL.ShippingCity");
            txtShippingDivision.Text = SettingManager.GetSettingValue("ShippingRateComputationMethod.DHL.ShippingDivision");
            txtShippedFromZipPostalCode.Text = SettingManager.GetSettingValue("ShippingRateComputationMethod.DHL.DefaultShippedFromZipPostalCode");

            // bingding carrier service offered
            string domesticServices = SettingManager.GetSettingValue("ShippingRateComputationMethod.DHL.DomesticServices");
            foreach (ListItem item in chkListDHLDomesticServices.Items)
            {
                if (domesticServices.Contains(item.Value))
                    item.Selected = true;
            }

            // bingding carrier service offered
            string iternationalServices = SettingManager.GetSettingValue("ShippingRateComputationMethod.DHL.InternationalServices");
            foreach (ListItem item in chkListDHLIntlServices.Items)
            {
                if (iternationalServices.Contains(item.Value))
                    item.Selected = true;
            }

            BindConvertionGrid();
        }

        public void Save()
        {
            SettingManager.SetParam("ShippingRateComputationMethod.DHL.URL", txtURL.Text.Trim());
            SettingManager.SetParam("ShippingRateComputationMethod.DHL.SiteID", txtUsername.Text.Trim());
            SettingManager.SetParam("ShippingRateComputationMethod.DHL.Password", txtPassword.Text.Trim());
            SettingManager.SetParamNative("ShippingRateComputationMethod.DHL.AdditionalHandlingCharge", txtAdditionalHandlingCharge.Value);
            SettingManager.SetParam("ShippingRateComputationMethod.DHL.DefaultShippedFromZipPostalCode", txtShippedFromZipPostalCode.Text.Trim());
            SettingManager.SetParam("ShippingRateComputationMethod.DHL.ShippingCountry", txtShippingCountry.Text.Trim());
            SettingManager.SetParam("ShippingRateComputationMethod.DHL.ShippingCity", txtShippingCity.Text.Trim());
            SettingManager.SetParam("ShippingRateComputationMethod.DHL.ShippingDivision", txtShippingDivision.Text.Trim());

            SettingManager.SetParam("ShippingRateComputationMethod.DHL.DomesticServices", GetDomesticServices());
            SettingManager.SetParam("ShippingRateComputationMethod.DHL.InternationalServices", GetIntlServices());
        }

        string GetDomesticServices()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ListItem item in chkListDHLDomesticServices.Items)
            {
                if (item.Selected)
                    sb.AppendFormat("{0}:", item.Value);
            }
            return sb.ToString();
        }

        string GetIntlServices()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ListItem item in chkListDHLIntlServices.Items)
            {
                if (item.Selected)
                    sb.AppendFormat("{0}:", item.Value);
            }
            return sb.ToString();
        }

        private void BindConvertionGrid()
        {
            ShippingConvertionBiz biz = new ShippingConvertionBiz();
            gvConvertion.DataSource = biz.GetAllConvertionByType(ShippingConvertionType.DHL);
            gvConvertion.DataBind();
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
            convertionBiz.AddConvertion(priceFrom, priceTo, chargeWeight, ShippingConvertionType.DHL);
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
                if (biz.UpdateConvertion(id, priceFrom, priceTo, chargeWeight, ShippingConvertionType.DHL))
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
