using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LWG.Business;
using LWG.Core.Models;
using NopSolutions.NopCommerce.BusinessLogic.Directory;

namespace NopSolutions.NopCommerce.Web.Administration.Modules
{
    public partial class DealerDetails : BaseNopUserControl
    {
        DealerBiz dealerBiz;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStateDropDown();
                LoadDetail();

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
        private void LoadDetail()
        {
            lblError.Text = string.Empty;
            lblSuccess.Text = string.Empty;
            if (Session["DealerUpdateSuccess"] != null)
            {
                lblSuccess.Text = Session["DealerUpdateSuccess"].ToString();
                Session.Remove("DealerUpdateSuccess");
            }
            dealerBiz = new DealerBiz();
            lwg_Dealer dealer = dealerBiz.GetDealerByDealerID(DealerID);
            if (dealer != null)
            {
                txtDealerID.Text = dealer.DealerID;
                txtAddress1.Text = dealer.AddressLine1;
                txtAddress2.Text = dealer.AddressLine2;
                txtCity.Text = dealer.City;
                txtContact.Text = dealer.Contact;
                txtFax.Text = dealer.Fax;
                txtPhone.Text = dealer.Phone;
                if (ddlUSState.Items.FindByValue(dealer.State) != null)
                {
                    ddlUSState.Items.FindByValue(dealer.State).Selected = true;
                    txtState.Text = string.Empty;
                    txtState.Visible = false;
                }
                else
                {
                    ddlUSState.Items.FindByValue("00").Selected=true;
                    txtState.Text = dealer.State;
                }
                
                txtWebAddress.Text = dealer.WebAddress;
                txtZip.Text = dealer.Zip;
                txtNewIssue.Text = dealer.NewIssue;
                txtName.Text = dealer.Name;
            }
            else
                Response.Redirect("Dealer.aspx");
        }

        public string DealerID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["dealerid"]))
                    return Request.QueryString["dealerid"];
                return string.Empty;
            }
        }
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if(dealerBiz==null)
                    dealerBiz = new DealerBiz();
                lwg_Dealer dealer = dealerBiz.GetDealerByDealerID(DealerID);
                lblError.Text = string.Empty;
                lblSuccess.Text = string.Empty;
                bool updateNewID = false;
                
                if(txtDealerID.Text.Trim()!=DealerID && dealerBiz.IsDealerExist(txtDealerID.Text.Trim()))
                {
                    lblError.Text = GetLocaleResourceString("Dealer.DealerIDExistMessage");
                    return;
                }
                else
                    if(txtDealerID.Text.Trim()!=DealerID && !dealerBiz.IsDealerExist(txtDealerID.Text.Trim())) // new id
                    {
                        updateNewID = true;
                    }
                if (dealer != null)
                {                    
                    dealer.AddressLine1 = txtAddress1.Text.Trim();
                    dealer.AddressLine2 = txtAddress2.Text.Trim();
                    dealer.City = txtCity.Text.Trim();
                    dealer.Contact = txtContact.Text.Trim();
                    dealer.Fax = txtFax.Text.Trim();
                    dealer.Name = txtName.Text.Trim();
                    dealer.NewIssue = txtNewIssue.Text.Trim();
                    dealer.Phone = txtPhone.Text.Trim();
                    if (ddlUSState.SelectedValue == "00")
                        dealer.State = txtState.Text.Trim();
                    else
                    {
                        dealer.State = ddlUSState.SelectedValue;
                    }
                    dealer.WebAddress = txtWebAddress.Text.Trim();
                    dealer.Zip = txtZip.Text.Trim();
                    dealer.AddressSearch = string.Format("{0} {1} {2} {3} {4}", txtAddress1.Text.Trim(), txtAddress2.Text.Trim(), txtCity.Text.Trim(), txtState.Text.Trim(), txtZip.Text.Trim());

                    bool updateSuccess;
                    if (updateNewID)
                    {
                        updateSuccess = dealerBiz.UpdateDealer(dealer,txtDealerID.Text.Trim());
                    }
                    else
                    {
                        updateSuccess = dealerBiz.UpdateDealer(dealer, string.Empty);
                    }

                    if (updateSuccess)
                    {
                        if (updateNewID)
                        {
                            Session["DealerUpdateSuccess"] = GetLocaleResourceString("Dealer.UpdateSuccessMessage");
                            Response.Redirect(string.Format("dealerdetails.aspx?dealerid={0}",txtDealerID.Text.Trim()));
                        }
                        else
                        {
                            lblSuccess.Text = GetLocaleResourceString("Dealer.UpdateSuccessMessage");
                        }
                        
                    }
                    else
                    {
                        lblError.Text = GetLocaleResourceString("Dealer.UpdateFailMessage");
                    }
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (dealerBiz == null)
                dealerBiz = new DealerBiz();
            if (dealerBiz.DeleteDealer(DealerID))
            {
                Response.Redirect("dealer.aspx");
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