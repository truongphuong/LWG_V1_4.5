using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LWG.Business;
using NopSolutions.NopCommerce.Common.Utils;

namespace NopSolutions.NopCommerce.Web.Administration.Modules
{
    public partial class ComposersControl : BaseNopAdministrationUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }


        void BindGrid()
        {
            PersonBiz pbiz = new PersonBiz();
            
            gvComposers.DataSource = pbiz.GetAllPersons(txtNameDisplay.Text.Trim(), ddlFirstLetter.SelectedValue.ToString());
            gvComposers.DataBind();
        }

        protected void gvComposers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvComposers.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.gvComposers.PageIndex = 0;
            BindGrid();
        }
        protected void ddlFirstLetter_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }
}
}