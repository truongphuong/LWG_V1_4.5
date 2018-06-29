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
    public partial class RoleManageControl : BaseNopAdministrationUserControl
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
            RoleBiz pbiz = new RoleBiz();

            gvProductRole.DataSource = pbiz.GetListRole();
            gvProductRole.DataBind();
        }

        protected void gvProductRole_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProductRole.PageIndex = e.NewPageIndex;
            BindGrid();
        }
    }
}