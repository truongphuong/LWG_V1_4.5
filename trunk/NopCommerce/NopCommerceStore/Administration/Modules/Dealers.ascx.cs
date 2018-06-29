using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LWG.Business;
using NopSolutions.NopCommerce.BusinessLogic.Audit;
using NopSolutions.NopCommerce.BusinessLogic.Configuration.Settings;

namespace NopSolutions.NopCommerce.Web.Administration.Modules
{
    public partial class Dealers : BaseNopAdministrationUserControl
    {
        DealerBiz dealerBiz; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            string name = txtSearchName.Text.Trim();
            string address = txtSearchAddress.Text.Trim();
            string id = txtSearchID.Text.Trim();
            dealerBiz = new DealerBiz();
            gvDealer.DataSource = dealerBiz.GetAllDealersBySearch(id,name,address);
            gvDealer.DataBind();
        }

        protected void gvDealer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDealer.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    BindGrid();
                    txtSearchName.Focus();
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                dealerBiz = new DealerBiz();
                foreach (GridViewRow row in gvDealer.Rows)
                {
                    var cbDealer = row.FindControl("cbDealer") as CheckBox;
                    var hfDealerId = row.FindControl("hfDealerId") as HiddenField;

                    bool isChecked = cbDealer.Checked;
                    if (isChecked)
                    {
                        dealerBiz.DeleteDealer(hfDealerId.Value);
                    }
                }

                BindGrid();
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            Response.Redirect("dealerimport.aspx");
        }
    }
}