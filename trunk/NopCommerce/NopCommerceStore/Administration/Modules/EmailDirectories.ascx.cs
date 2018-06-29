using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using NopSolutions.NopCommerce.BusinessLogic;
using NopSolutions.NopCommerce.BusinessLogic.Configuration.Settings;
using NopSolutions.NopCommerce.BusinessLogic.ExportImport;
using NopSolutions.NopCommerce.BusinessLogic.Localization;
using NopSolutions.NopCommerce.BusinessLogic.Manufacturers;
using NopSolutions.NopCommerce.BusinessLogic.Products;
using NopSolutions.NopCommerce.BusinessLogic.Utils;
using NopSolutions.NopCommerce.Common.Utils;
using NopSolutions.NopCommerce.BusinessLogic.Media;
using LWG.Business;
using LWG.Core.Models;



namespace NopSolutions.NopCommerce.Web.Administration.Modules
{
    public partial class EmailDirectories : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            EmailDirectoryBiz emailbiz = new EmailDirectoryBiz();
            gvEmails.DataSource = emailbiz.GetEmailByName(txtFirstName.Text, txtLastName.Text);
            gvEmails.DataBind();
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            BindGrid();   
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            EmailDirectoryBiz emailbiz = new EmailDirectoryBiz();
              foreach (GridViewRow row in gvEmails.Rows)
              {
                    var cbEmail = row.FindControl("cbEmail") as CheckBox;
                    var hfid = row.FindControl("hfid") as HiddenField;

                    bool isChecked = cbEmail.Checked;
                    int emailid = int.Parse(hfid.Value);
                    if (isChecked)
                    {
                        emailbiz.DeleteEmail(emailid);
                    }
                }

                BindGrid();

    
        }

        protected void gvEmails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvEmails.PageIndex = e.NewPageIndex;
            BindGrid();
        }


    }
}