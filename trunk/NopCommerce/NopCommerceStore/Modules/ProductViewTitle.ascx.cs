using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NopSolutions.NopCommerce.BusinessLogic.Products;
using LWG.Core.Models;
using NopSolutions.NopCommerce.BusinessLogic;
using NopSolutions.NopCommerce.BusinessLogic.Directory;
using NopSolutions.NopCommerce.BusinessLogic.Tax;
using NopSolutions.NopCommerce.BusinessLogic.Configuration.Settings;
using NopSolutions.NopCommerce.Common;
using NopSolutions.NopCommerce.BusinessLogic.SEO;
using NopSolutions.NopCommerce.BusinessLogic.Categories;


namespace NopSolutions.NopCommerce.Web.Modules
{
    public partial class ProductViewTitle : BaseNopUserControl
    {
        Nop_Product product = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public Nop_Product Product
        {
            get
            {
                return product;
            }
            set
            {
                product = value;
            }
        }
        public override void DataBind()
        {
            base.DataBind();
            this.BindData();
        }
        private void BindData()
        {
            if (product != null)
            {
                string productURL = SEOHelper.GetProductUrl(product.ProductId);

                // product name
                hpProductName.Text = product.Name;
                hpProductName.NavigateUrl = productURL;

                // view more
                hlViewMore.NavigateUrl = productURL;

                #region product price
                var productVariantCollection = ProductManager.GetProductVariantsByProductId(product.ProductId);
                if (productVariantCollection.Count > 0)
                {
                    if (!(productVariantCollection.Count>1))
                    {
                        var productVariant = productVariantCollection[0];

                        if (!SettingManager.GetSettingValueBoolean("Common.HidePricesForNonRegistered") ||
                            (NopContext.Current.User != null &&
                            !NopContext.Current.User.IsGuest))
                        {
                            if (productVariant.CustomerEntersPrice)
                            {
                                lblPrice.Visible = false;
                            }
                            else
                            {
                                decimal oldPriceBase = TaxManager.GetPrice(productVariant, productVariant.OldPrice);
                                decimal finalPriceWithoutDiscountBase = TaxManager.GetPrice(productVariant, PriceHelper.GetFinalPrice(productVariant, false));

                                decimal oldPrice = CurrencyManager.ConvertCurrency(oldPriceBase, CurrencyManager.PrimaryStoreCurrency, NopContext.Current.WorkingCurrency);
                                decimal finalPriceWithoutDiscount = CurrencyManager.ConvertCurrency(finalPriceWithoutDiscountBase, CurrencyManager.PrimaryStoreCurrency, NopContext.Current.WorkingCurrency);

                                if (finalPriceWithoutDiscountBase != oldPriceBase && oldPriceBase != decimal.Zero)
                                {
                                    lblPrice.Text = PriceHelper.FormatPrice(finalPriceWithoutDiscount, false, false);
                                }
                                else
                                {
                                    lblPrice.Text = PriceHelper.FormatPrice(finalPriceWithoutDiscount,false,false);
                                }
                            }
                        }
                        else
                        {
                            lblPrice.Visible = false;
                        }
                    }
                    else
                    {
                        var productVariant = GetVariant(productVariantCollection);
                        if (productVariant != null)
                        {
                            if (!SettingManager.GetSettingValueBoolean("Common.HidePricesForNonRegistered") ||
                                (NopContext.Current.User != null &&
                                !NopContext.Current.User.IsGuest))
                            {
                                if (productVariant.CustomerEntersPrice)
                                {
                                    lblPrice.Visible = false;
                                }
                                else
                                {
                                    decimal fromPriceBase = TaxManager.GetPrice(productVariant, PriceHelper.GetFinalPrice(productVariant, false));
                                    decimal fromPrice = CurrencyManager.ConvertCurrency(fromPriceBase, CurrencyManager.PrimaryStoreCurrency, NopContext.Current.WorkingCurrency);

                                    lblPrice.Text = String.Format(GetLocaleResourceString("Products.PriceRangeFromText"), PriceHelper.FormatPrice(fromPrice, false, false));
                                }
                            }
                            else
                            {
                                lblPrice.Visible = false;
                            }
                        }

                    }
                }
                else
                {                    
                    lblPrice.Visible = false;
                }
                #endregion

                // category 
                var productCategories = CategoryManager.GetProductCategoriesByProductId(product.ProductId);
                if (productCategories.Count > 0)
                {
                    var breadCrumb = CategoryManager.GetBreadCrumb(productCategories[0].CategoryId);
                    if (breadCrumb.Count > 0)
                    {
                        rptrCategoryBreadcrumb.DataSource = breadCrumb;
                        rptrCategoryBreadcrumb.DataBind();
                    }
                }

                lblCategory.Text = "";// ProductManager.GetProductReviewByProductId(Product.ProductId);
                // catalog number 
                LWG.Business.CatalogBiz catalogBiz = new LWG.Business.CatalogBiz();
                lwg_Catalog catalog = catalogBiz.GetByID(product.ProductId);
                hlCatalogNo.Text = Server.HtmlEncode("# - " + catalog.CatalogNumber);
                hlCatalogNo.NavigateUrl = productURL;
            }
        }
        private ProductVariant GetVariant(ProductVariantCollection productVariants)
        {
            productVariants.Sort(new GenericComparer<ProductVariant>
                ("Price", GenericComparer<ProductVariant>.SortOrder.Ascending));
            if (productVariants.Count > 0)
                return productVariants[0];
            else
                return null;
        }
    }
}