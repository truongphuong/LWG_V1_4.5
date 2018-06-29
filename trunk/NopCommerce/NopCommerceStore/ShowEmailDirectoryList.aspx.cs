using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using NopSolutions.NopCommerce.BusinessLogic;
using NopSolutions.NopCommerce.BusinessLogic.Localization;
using NopSolutions.NopCommerce.BusinessLogic.Payment;
using NopSolutions.NopCommerce.BusinessLogic.SEO;
using NopSolutions.NopCommerce.Common.Utils;
using LWG.Business;
using LWG.Core.Models;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Caching;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;

namespace NopSolutions.NopCommerce.Web
{
    public partial class ShowEmailDirectoryList : BaseNopPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string title = GetLocaleResourceString("PageTitle.ShowEmailDirectoryList");
                SEOHelper.RenderTitle(this, title, true);
            }
        }
    }
}
