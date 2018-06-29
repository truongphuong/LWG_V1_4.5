using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using NopSolutions.NopCommerce.BusinessLogic;
using NopSolutions.NopCommerce.BusinessLogic.SEO;
using NopSolutions.NopCommerce.Common.Utils;

namespace NopSolutions.NopCommerce.Web
{
    public partial class Offices : BaseNopPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string title = GetLocaleResourceString("PageTitle.Offices");
            SEOHelper.RenderTitle(this, title, true);
        }

        protected void lbMain_Click(object sender, EventArgs e)
        {
            Panel0.Visible = false;
            Panel1.Visible = true;
            Panel2.Visible = false;
        }

        protected void lbDevelopment_Click(object sender, EventArgs e)
        {
            Panel0.Visible = false;
            Panel1.Visible = false;
            Panel2.Visible = true;
        }

        protected void lbRecords_Click(object sender, EventArgs e)
        {
            
        }
    }
}
