using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LumenWorks.Framework.IO.Csv;
using System.IO;
using LWG.Business;
using NopSolutions.NopCommerce.BusinessLogic.Directory;
using LWG.Core.Models;

namespace NopSolutions.NopCommerce.Web.Administration.Modules
{
    public partial class DealerAdd : BaseNopUserControl
    {
        DealerBiz dealerBiz;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                lblAddNewError.Text = string.Empty;
                LoadStateDropDown();
            }
        }

        void LoadStateDropDown()
        {
            var stateProvinceCollection = StateProvinceManager.GetStateProvincesByCountryId(1);
            foreach (var stateProvince in stateProvinceCollection)
            {
                var ddlStateProviceItem2 = new ListItem(stateProvince.Name, stateProvince.Abbreviation);
                this.ddlUSState.Items.Add(ddlStateProviceItem2);
            }
            this.ddlUSState.Items.Add(new ListItem("Other (Non US)", "00"));
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (dealerBiz == null)
                    dealerBiz = new DealerBiz();

                if(dealerBiz.IsDealerExist(txtCustomerID.Text.Trim()))
                {
                    lblAddNewError.Text = GetLocaleResourceString("Dealer.DealerIDExistMessage");
                    return ;
                }

                lwg_Dealer newDealer = new lwg_Dealer();
                newDealer.DealerID = txtCustomerID.Text.Trim();
                newDealer.AddressLine1 = txtAddress1.Text.Trim();
                newDealer.AddressLine2 = txtAddress2.Text.Trim();
                newDealer.City = txtCity.Text.Trim();
                newDealer.Contact = txtContact.Text.Trim();
                newDealer.Fax = txtFax.Text.Trim();
                newDealer.Name = txtName.Text.Trim();
                newDealer.NewIssue = txtNewIssue.Text.Trim();
                newDealer.Phone = txtPhone.Text.Trim();
                if (ddlUSState.SelectedValue == "00")
                    newDealer.State = txtState.Text.Trim();
                else
                {
                    newDealer.State = ddlUSState.SelectedValue;
                }
                newDealer.WebAddress = txtWebAddress.Text.Trim();
                newDealer.Zip = txtZip.Text.Trim();
                newDealer.AddressSearch = string.Format("{0} {1} {2} {3} {4}", txtAddress1.Text.Trim(), txtAddress2.Text.Trim(), txtCity.Text.Trim(), txtState.Text.Trim(), txtZip.Text.Trim());

                if (dealerBiz.AddDealer(newDealer))
                {
                    Response.Redirect("dealer.aspx");
                    //pnlAddNew.Visible = false;
                    //pnlAddNewMessage.Visible = true;
                }
                else
                {
                    pnlAddNew.Visible = true;
                    pnlAddNewMessage.Visible = false;
                    lblAddNewError.Text = GetLocaleResourceString("Dealer.AddFailMessage");
                }
            }
        }

        protected void ddlUSState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUSState.SelectedValue != "00")
            {
                txtState.Visible = false;
            }
            else
            {
                txtState.Visible = true;
            }
        }

    }
}