using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LWG.Business;
using NopSolutions.NopCommerce.BusinessLogic.SEO;
using LWG.Core.Models;

namespace NopSolutions.NopCommerce.Web.Modules
{
    public partial class RecentProduct : BaseNopUserControl
    {
        public int Number
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack) 
            {
                this.BindData();
            }
        }

        private void BindData()
        {
            CatalogBiz cService = new CatalogBiz();
            List<lwg_Catalog> lstCatalog = cService.GetRecentCatalog(this.Number);
            if (lstCatalog.Count > 0) 
            {
                this.dlRecentProduct.DataSource = lstCatalog;
                this.dlRecentProduct.DataBind();
            }
        }

        protected void dlRecentProduct_Bound(object sender, DataListItemEventArgs e) 
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
            {
                
                lwg_Catalog obj = (lwg_Catalog)e.Item.DataItem;
                string catalogURL = SEOHelper.GetCatalogUrl(obj);

                Label lbl = (Label)e.Item.FindControl("lblNumber");
                lbl.Text = (e.Item.ItemIndex + 1).ToString();

                HyperLink hpl = (HyperLink)e.Item.FindControl("hplName");
                hpl.Text = obj.TitleDisplay;
                hpl.NavigateUrl = catalogURL;
            }
        }
    }
}