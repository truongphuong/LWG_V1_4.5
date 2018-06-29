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
using NopSolutions.NopCommerce.BusinessLogic.Products;
using System.Collections.Generic;
using NopSolutions.NopCommerce.BusinessLogic.Configuration.Settings;
using NopSolutions.NopCommerce.Common;
using NopSolutions.NopCommerce.BusinessLogic.Localization;
using NopSolutions.NopCommerce.BusinessLogic.Audit;

namespace NopSolutions.NopCommerce.Web
{
    public partial class SearchResult : BaseNopPage
    {
        private string SearchTerms
        {
            get
            {
                return CommonHelper.QueryString("searchterms");
            }
        }

        private int CategoryId
        {
            get
            {
                return CommonHelper.QueryStringInt("categoryId");
            }
        }

        private int ManufacturerId
        {
            get
            {
                return CommonHelper.QueryStringInt("manufacturerId");
            }
        }

        private decimal? MinPriceConverted
        {
            get
            {
                return CommonHelper.QueryStringDecimal("minPriceConverted");
            }
        }

        private decimal? MaxPriceConverted
        {
            get
            {
                return CommonHelper.QueryStringDecimal("maxPriceConverted");
            }
        }

        private bool SearchInProductDescriptions
        {
            get
            {
                return CommonHelper.QueryStringBool("searchInProductDescriptions");
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadSEO();
            this.BindData();
        }

        protected void BindData()
        {
            try
            {
                string keywords = this.SearchTerms;

                if (!String.IsNullOrEmpty(keywords))
                {
                    int categoryId = this.CategoryId;
                    int manufacturerId = this.ManufacturerId;
                    decimal? minPriceConverted = this.MinPriceConverted;
                    decimal? maxPriceConverted = this.MaxPriceConverted;
                    bool searchInProductDescriptions = this.SearchInProductDescriptions;
                    
                    int totalRecords = 0;
                    var products = ProductManager.GetAllProducts(categoryId,
                        manufacturerId, 0, null,
                        minPriceConverted, maxPriceConverted,
                        keywords, searchInProductDescriptions,
                        100, 0, new List<int>(), out totalRecords);
                    
                    lvProducts.DataSource = products;
                    lvProducts.DataBind();
                    lvProducts.Visible = products.Count > 0;
                    pagerProducts.Visible = products.Count > pagerProducts.PageSize;
                    lblNoResults.Visible = !lvProducts.Visible;
                }
                else
                {
                    pagerProducts.Visible = false;
                    lvProducts.Visible = false;
                }
            }
            catch (Exception exc)
            {
                lvProducts.Visible = false;
                pagerProducts.Visible = false;
            }
        }

        protected void lvProducts_OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            this.pagerProducts.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            BindData();
        }

        private void LoadSEO()
        {
            string title = GetLocaleResourceString("PageTitle.Search");
            SEOHelper.RenderTitle(this, title, true);
        }

        public override PageSslProtectionEnum SslProtected
        {
            get
            {
                return PageSslProtectionEnum.No;
            }
        }
    }


}
