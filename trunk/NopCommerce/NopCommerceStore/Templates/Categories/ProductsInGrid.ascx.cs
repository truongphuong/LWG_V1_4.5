//------------------------------------------------------------------------------
// The contents of this file are subject to the nopCommerce Public License Version 1.0 ("License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at  http://www.nopCommerce.com/License.aspx. 
// 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. 
// See the License for the specific language governing rights and limitations under the License.
// 
// The Original Code is nopCommerce.
// The Initial Developer of the Original Code is NopSolutions.
// All Rights Reserved.
// 
// Contributor(s): _______. 
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using NopSolutions.NopCommerce.BusinessLogic;
using NopSolutions.NopCommerce.BusinessLogic.Categories;
using NopSolutions.NopCommerce.BusinessLogic.Configuration.Settings;
using NopSolutions.NopCommerce.BusinessLogic.Directory;
using NopSolutions.NopCommerce.BusinessLogic.Localization;
using NopSolutions.NopCommerce.BusinessLogic.Media;
using NopSolutions.NopCommerce.BusinessLogic.Products;
using NopSolutions.NopCommerce.BusinessLogic.SEO;
using NopSolutions.NopCommerce.Common.Utils;
using NopSolutions.NopCommerce.BusinessLogic.Caching;

namespace NopSolutions.NopCommerce.Web.Templates.Categories
{
    public partial class ProductsInGrid : BaseNopUserControl
    {
        private const string CATEGORIES_BY_ID_KEY = "Nop.category.id-{0}-{1}";

        Category category = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                InitView();         
                FillDropDowns();
                BindData();
            }
        }
        
        #region add other view
        protected void InitView()
        {
            //if (category.ParentCategory == null)
            //{
            //    ibtnGalleryView.Visible = false;
            //    ibtnListView.Visible = false;
            //}
            //else
            //{
            //    ibtnGalleryView.Visible = true;
            //    ibtnListView.Visible = true;
            //}
            if (category.TemplateId == 3)
            {
                ibtnGalleryView.Enabled = false;
                ibtnListView.Enabled = true;
                ibtnListView.CssClass = "linktab";

            }
            else
                if (category.TemplateId == 5)
                {
                    ibtnListView.Enabled = false;
                    ibtnGalleryView.Enabled = true;
                    ibtnGalleryView.CssClass = "linktab";
                }
            
        }
        protected void SetCategoryById(int templateId)
        {
            int languageId = 0;
            if (NopContext.Current != null)
                languageId = NopContext.Current.WorkingLanguage.LanguageId;
            string key = string.Format(CATEGORIES_BY_ID_KEY, category.CategoryId, languageId);
            category.TemplateId = templateId;
            object obj2 = NopCache.Get(key);
            if (CategoryManager.CategoriesCacheEnabled)
            {
                if (obj2 != null)
                    NopCache.Remove(key);
                NopCache.Max(key, category);
            }            
        }
        #endregion

        protected void FillDropDowns()
        {
            if (SettingManager.GetSettingValueBoolean("Common.AllowProductSorting"))
            {
                ddlSorting.Items.Clear();

                var ddlSortPositionItem = new ListItem(GetLocaleResourceString("ProductSorting.Position"), ((int)ProductSortingEnum.Position).ToString());
                ddlSorting.Items.Add(ddlSortPositionItem);

                var ddlSortNameItem = new ListItem(GetLocaleResourceString("ProductSorting.Name"), ((int)ProductSortingEnum.Name).ToString());
                ddlSorting.Items.Add(ddlSortNameItem);

                var ddlSortPriceItem = new ListItem(GetLocaleResourceString("ProductSorting.Price"), ((int)ProductSortingEnum.Price).ToString());
                ddlSorting.Items.Add(ddlSortPriceItem);

                var ddlSortGradeItem = new ListItem(GetLocaleResourceString("ProductSorting.Grade"), ((int)ProductSortingEnum.Grade).ToString());
                ddlSorting.Items.Add(ddlSortGradeItem);

            }
            else
            {
                pnlSorting.Visible = false;
            }
        }

        protected void BindData()
        {
            var category = CategoryManager.GetCategoryById(this.CategoryId);

            //breadcrumb
            rptrCategoryBreadcrumb.DataSource = CategoryManager.GetBreadCrumb(this.CategoryId);
            rptrCategoryBreadcrumb.DataBind();

            lDescription.Text = category.Description;

            //subcategories
            var subCategoryCollection = CategoryManager.GetAllCategories(category.CategoryId);
            if (subCategoryCollection.Count > 0)
            {
                dlSubCategories.DataSource = subCategoryCollection;
                dlSubCategories.DataBind();
            }
            else
                dlSubCategories.Visible = false;

            //featured products
            var featuredProducts = category.FeaturedProducts;
            if (featuredProducts.Count > 0)
            {
                dlFeaturedProducts.DataSource = featuredProducts;
                dlFeaturedProducts.DataBind();
            }
            else
            {
                pnlFeaturedProducts.Visible = false;
            }

            //price ranges
            this.ctrlPriceRangeFilter.PriceRanges = category.PriceRanges;

            //page size
            int totalRecords = 0;
            int pageSize = 12;
            //\Tungnho comment here
            //if (category.PageSize > 0)
            //{
            //    pageSize = category.PageSize;
            //}

            //price ranges
            decimal? minPrice = null;
            decimal? maxPrice = null;
            decimal? minPriceConverted = null;
            decimal? maxPriceConverted = null;
            if (ctrlPriceRangeFilter.SelectedPriceRange != null)
            {
                minPrice = ctrlPriceRangeFilter.SelectedPriceRange.From;
                if (minPrice.HasValue)
                {
                    minPriceConverted = CurrencyManager.ConvertCurrency(minPrice.Value, NopContext.Current.WorkingCurrency, CurrencyManager.PrimaryStoreCurrency);
                }

                maxPrice = ctrlPriceRangeFilter.SelectedPriceRange.To;
                if (maxPrice.HasValue)
                {
                    maxPriceConverted = CurrencyManager.ConvertCurrency(maxPrice.Value, NopContext.Current.WorkingCurrency, CurrencyManager.PrimaryStoreCurrency);
                }
            }

            //specification filter
            var psoFilterOption = ctrlProductSpecificationFilter.GetAlreadyFilteredSpecOptionIds();

            //sorting
            ProductSortingEnum orderBy = ProductSortingEnum.Position;
            if (SettingManager.GetSettingValueBoolean("Common.AllowProductSorting"))
            {
                CommonHelper.SelectListItem(this.ddlSorting, CommonHelper.QueryStringInt("orderby"));            
                orderBy = (ProductSortingEnum)Enum.ToObject(typeof(ProductSortingEnum), int.Parse(ddlSorting.SelectedItem.Value));
            }

            var productCollection = ProductManager.GetAllProducts(this.CategoryId,
                0, 0, false, minPriceConverted, maxPriceConverted,
                string.Empty, false, pageSize, this.CurrentPageIndex, 
                psoFilterOption, orderBy, out totalRecords);

            if (productCollection.Count > 0)
            {
                this.productsPager.PageSize = pageSize;
                this.productsPager.TotalRecords = totalRecords;
                this.productsPager.PageIndex = this.CurrentPageIndex;

                this.dlProducts.DataSource = productCollection;
                this.dlProducts.DataBind();
            }
            else
            {
                this.dlProducts.Visible = false;
                this.pnlSorting.Visible = false;
            }
        }

        protected void ddlSorting_SelectedIndexChanged(object sender, EventArgs e)
        {
            string url = CommonHelper.GetThisPageUrl(true);
            url = CommonHelper.ModifyQueryString(url, "orderby=" + ddlSorting.SelectedItem.Value, null);
            Response.Redirect(url);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            
            category = CategoryManager.GetCategoryById(this.CategoryId);

            ctrlPriceRangeFilter.ExcludedQueryStringParams = productsPager.QueryStringProperty;

            ctrlProductSpecificationFilter.ExcludedQueryStringParams = productsPager.QueryStringProperty;
            ctrlProductSpecificationFilter.CategoryId = this.CategoryId;

            ctrlProductSpecificationFilter.ReservedQueryStringParams = "CategoryId,";
            ctrlProductSpecificationFilter.ReservedQueryStringParams += "orderby,";
            ctrlProductSpecificationFilter.ReservedQueryStringParams += ctrlPriceRangeFilter.QueryStringProperty;
            ctrlProductSpecificationFilter.ReservedQueryStringParams += ",";
            ctrlProductSpecificationFilter.ReservedQueryStringParams += productsPager.QueryStringProperty;
        }

        protected override void OnPreRender(EventArgs e)
        {
            this.pnlFilters.Visible = ctrlPriceRangeFilter.Visible || ctrlProductSpecificationFilter.Visible;
            base.OnPreRender(e);
        }

        protected void dlSubCategories_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var category = e.Item.DataItem as Category;
                string categoryURL = SEOHelper.GetCategoryUrl(category.CategoryId);

                var hlImageLink = e.Item.FindControl("hlImageLink") as HyperLink;
                if (hlImageLink != null)
                {
                    hlImageLink.ImageUrl = PictureManager.GetPictureUrl(category.PictureId, SettingManager.GetSettingValueInteger("Media.Category.ThumbnailImageSize", 125), true);
                    hlImageLink.NavigateUrl = categoryURL;
                    hlImageLink.ToolTip = String.Format(GetLocaleResourceString("Media.Category.ImageLinkTitleFormat"), category.Name);
                    hlImageLink.Text = String.Format(GetLocaleResourceString("Media.Category.ImageAlternateTextFormat"), category.Name);
                }

                var hlCategory = e.Item.FindControl("hlCategory") as HyperLink;
                if (hlCategory != null)
                {
                    hlCategory.NavigateUrl = categoryURL;
                    hlCategory.ToolTip = String.Format(GetLocaleResourceString("Media.Category.ImageLinkTitleFormat"), category.Name);
                    hlCategory.Text = Server.HtmlEncode(category.Name);
                }
            }
        }

        public int CurrentPageIndex
        {
            get
            {
                int _pageIndex = CommonHelper.QueryStringInt(productsPager.QueryStringProperty);
                _pageIndex--;
                if (_pageIndex < 0)
                    _pageIndex = 0;
                return _pageIndex;
            }
        }

        public int CategoryId
        {
            get
            {
                return CommonHelper.QueryStringInt("CategoryId");
            }
        }

                

        protected void ibtnGalleryView_Click(object sender, EventArgs e)
        {
            SetCategoryById(3);
            string url = CommonHelper.GetThisPageUrl(true);
            Response.Redirect(url);
        }

        protected void ibtnListView_Click(object sender, EventArgs e)
        {
            SetCategoryById(5);
            string url = CommonHelper.GetThisPageUrl(true);
            Response.Redirect(url);
        }
    }
}