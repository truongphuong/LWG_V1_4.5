using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LWG.Core.Models;
using LWG.Business;


namespace NopSolutions.NopCommerce.Web.Administration
{
    public partial class LicenseManagement : BaseNopAdministrationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindData();
                this.BindDrpType();
            } 
        }

        protected void grvLicense_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("DLT"))
            {
                LicenseBiz lBiz = new LicenseBiz();
                if (lBiz.DeleteLiscense(int.Parse(e.CommandArgument.ToString())))
                {
                    this.BindData();
                }
            }
        } 
         

        private void BindDrpType()
        {
            this.drpType.Items.Clear();
            
            Array values = Enum.GetValues(typeof(LicenseType));
            foreach (int val in values)
            {
                ListItem item = new ListItem();
                item.Value = val.ToString();
                item.Text = Enum.GetName(typeof(LicenseType), val);

                this.drpType.Items.Add(item);
            }

            this.drpType.Items.Insert(0, new ListItem("All", "0"));
        }

        private void BindData()
        {
            LicenseBiz lService = new LicenseBiz();
            List<lwg_LicenseForm> listLicense = lService.GetAllLicense();
            if (listLicense != null)
            {
                this.grvLicense.DataSource = listLicense.OrderByDescending(l => l.CreatedDate).ToList();
                this.grvLicense.DataBind();
            }
        }

        protected void grvLicense_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                lwg_LicenseForm license = (lwg_LicenseForm)e.Row.DataItem;
                Literal ltrType = (Literal)e.Row.FindControl("ltrType");

                if (license != null && ltrType != null)
                {
                    ltrType.Text = LicenseBiz.GetLicenseType(license.LicenseType);
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime from, to;

            if (!DateTime.TryParse(this.txtFrom.Text, out from))
            {
                from = DateTime.MinValue;
            }

            if (!DateTime.TryParse(this.txtTo.Text, out to))
            {
                to = DateTime.MaxValue;
            }

            int type = int.Parse(this.drpType.SelectedValue);

            LicenseBiz lService = new LicenseBiz();
            List<lwg_LicenseForm> listLicense = lService.Search(from, to, type);
            if (listLicense != null)
            {
                this.grvLicense.DataSource = listLicense.OrderByDescending(l => l.CreatedDate).ToList();
                this.grvLicense.DataBind();
            }
        }
    }
}
