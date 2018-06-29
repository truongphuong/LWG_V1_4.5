using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using NopSolutions.NopCommerce.BusinessLogic;
using NopSolutions.NopCommerce.BusinessLogic.ExportImport;
using NopSolutions.NopCommerce.BusinessLogic.Localization;
using NopSolutions.NopCommerce.BusinessLogic.Products;
using NopSolutions.NopCommerce.BusinessLogic.Security;
using NopSolutions.NopCommerce.Common.Utils;
using System.Xml.Linq;

namespace NopSolutions.NopCommerce.Web.Administration
{
    public partial class ProductRequireFiles : BaseNopAdministrationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack && Request.QueryString["TabID"] != null)
            {
                ProductRequireTabs.ActiveTabIndex = int.Parse(Request.QueryString["TabID"].ToString());
            }
        }
    }
}
