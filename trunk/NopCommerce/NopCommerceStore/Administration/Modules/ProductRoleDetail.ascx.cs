using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using NopSolutions.NopCommerce.Common.Utils;
using LWG.Core.Models;
using LWG.Business;

namespace NopSolutions.NopCommerce.Web.Administration.Modules
{
    public partial class ProductRoleDetailControl : BaseNopAdministrationUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (RoleId > 0)
                {
                    RoleBiz rBiz = new RoleBiz();
                    lwg_Role lg = rBiz.GetByID(RoleId);
                    txtName.Text = lg.Name;
                }
            }
            if (RoleId > 0)
            {
                DeleteButton.Visible = true;
            }
            else
            {
                DeleteButton.Visible = false;
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    int roleID = SaveInfo();
                    Response.Redirect("ProductRole.aspx");
                }
                catch (Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                RoleBiz pBiz = new RoleBiz();
                pBiz.DeleteRole(RoleId);

                Response.Redirect("ProductRole.aspx", false);
            }
            catch (Exception exc)
            {
                ProcessException(exc);
            }
        }

        public int RoleId
        {
            get
            {
                return int.Parse(CommonHelper.QueryStringInt("ProductRoleId").ToString());
            }
        }

        private int SaveInfo()
        {
            RoleBiz rBiz = new RoleBiz();
            lwg_Role lg;
            if (RoleId > 0)
            {
                lg = rBiz.GetByID(RoleId);
            }
            else
            {
                lg = new lwg_Role();
            }
            lg.Name = txtName.Text;
            rBiz.SaveRole(lg);
            return lg.RoleId;
        }
    }
}