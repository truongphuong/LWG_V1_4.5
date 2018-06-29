using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using NopSolutions.NopCommerce.BusinessLogic;
using NopSolutions.NopCommerce.BusinessLogic.Categories;
using NopSolutions.NopCommerce.BusinessLogic.Media;
using NopSolutions.NopCommerce.BusinessLogic.Products;
using NopSolutions.NopCommerce.BusinessLogic.SEO;
using NopSolutions.NopCommerce.Common.Utils;
using NopSolutions.NopCommerce.BusinessLogic.Configuration.Settings;
using System.Xml.Linq;
using System.Linq;
using NopSolutions.NopCommerce.BusinessLogic.Tax;
using NopSolutions.NopCommerce.BusinessLogic.Directory;
using LWG.Core.Models;

namespace NopSolutions.NopCommerce.Web.Modules
{
    public partial class ProductFeatureCataloglwgControl : BaseNopUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int NumberItem = 4;
                int totalRecords = 0;
                var vKeyboards = ProductManager.GetAllProducts(int.Parse(ConfigurationManager.AppSettings["CatagoryKeyboards"].ToString()), 0, 0, true, NumberItem, 0, out totalRecords);
                if (vKeyboards.Count > 0)
                {
                    dlKeyboards.RepeatColumns = NumberItem;
                    dlKeyboards.DataSource = vKeyboards;
                    dlKeyboards.DataBind();
                }
                var vFullOrchestra = ProductManager.GetAllProducts(int.Parse(ConfigurationManager.AppSettings["CatagoryFullOrchestra"].ToString()), 0, 0, true, NumberItem, 0, out totalRecords);
                if (vFullOrchestra.Count > 0)
                {
                    dlFullOrchestra.RepeatColumns = NumberItem;
                    dlFullOrchestra.DataSource = vFullOrchestra;
                    dlFullOrchestra.DataBind();
                }
                var vWoodwinds = ProductManager.GetAllProducts(int.Parse(ConfigurationManager.AppSettings["CatagoryWoodwinds"].ToString()), 0, 0, true, NumberItem, 0, out totalRecords);
                if (vWoodwinds.Count > 0)
                {
                    dlWoodwinds.RepeatColumns = NumberItem;
                    dlWoodwinds.DataSource = vWoodwinds;
                    dlWoodwinds.DataBind();
                }
                var vVoice = ProductManager.GetAllProducts(int.Parse(ConfigurationManager.AppSettings["CatagoryVoice"].ToString()), 0, 0, true, NumberItem, 0, out totalRecords);
                if (vVoice.Count > 0)
                {
                    dlVoice.RepeatColumns = NumberItem;
                    dlVoice.DataSource = vVoice;
                    dlVoice.DataBind();
                }
                var vStringOrchestra = ProductManager.GetAllProducts(int.Parse(ConfigurationManager.AppSettings["CategoryStringOrchestra"].ToString()), 0, 0, true, NumberItem, 0, out totalRecords);
                if (vStringOrchestra.Count > 0)
                {
                    dlStringOrchestra.RepeatColumns = NumberItem;
                    dlStringOrchestra.DataSource = vStringOrchestra;
                    dlStringOrchestra.DataBind();
                }
                var vString = ProductManager.GetAllProducts(int.Parse(ConfigurationManager.AppSettings["CatagoryString"].ToString()), 0, 0, true, NumberItem, 0, out totalRecords);
                if (vString.Count > 0)
                {
                    dlString.RepeatColumns = NumberItem;
                    dlString.DataSource = vString;
                    dlString.DataBind();
                }
                var vPercussion = ProductManager.GetAllProducts(int.Parse(ConfigurationManager.AppSettings["CatagoryPercussion"].ToString()), 0, 0, true, NumberItem, 0, out totalRecords);
                if (vPercussion.Count > 0)
                {
                    dlPercussion.RepeatColumns = NumberItem;
                    dlPercussion.DataSource = vPercussion;
                    dlPercussion.DataBind();
                }
                var vBrass = ProductManager.GetAllProducts(int.Parse(ConfigurationManager.AppSettings["CatagoryBrass"].ToString()), 0, 0, true, NumberItem, 0, out totalRecords);
                if (vBrass.Count > 0)
                {
                    dlBrass.RepeatColumns = NumberItem;
                    dlBrass.DataSource = vBrass;
                    dlBrass.DataBind();
                }
                var vBrand = ProductManager.GetAllProducts(int.Parse(ConfigurationManager.AppSettings["CatagoryBand"].ToString()), 0, 0, true, NumberItem, 0, out totalRecords);
                if (vBrand.Count > 0)
                {
                    dlBrand.RepeatColumns = NumberItem;
                    dlBrand.DataSource = vBrand;
                    dlBrand.DataBind();
                }
            }
        }
        protected void dlFullOrchestra_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var product = e.Item.DataItem as Product;
                if (product != null)
                {
                    string productURL = SEOHelper.GetProductUrl(product);

                    var hlImageLink = e.Item.FindControl("hlImageLink") as HyperLink;
                    if (hlImageLink != null)
                    {
                        ProductPicture productPicture = product.DefaultProductPicture;
                        if (productPicture != null)
                            hlImageLink.ImageUrl = PictureManager.GetPictureUrl(productPicture.Picture, SettingManager.GetSettingValueInteger("Media.Product.ThumbnailImageSize", 125), true);
                        else
                            hlImageLink.ImageUrl = PictureManager.GetDefaultPictureUrl(SettingManager.GetSettingValueInteger("Media.Product.ThumbnailImageSize", 125));

                        hlImageLink.NavigateUrl = productURL;
                        hlImageLink.ToolTip = String.Format(GetLocaleResourceString("Media.Product.ImageLinkTitleFormat"), product.Name);
                        hlImageLink.Text = String.Format(GetLocaleResourceString("Media.Product.ImageAlternateTextFormat"), product.Name);
                    }
                    // add catalog number
                    AddCatalogNo(product.ProductId, productURL, e);
                    //
                    var hlProduct = e.Item.FindControl("hlProduct") as HyperLink;
                    if (hlProduct != null)
                    {
                        hlProduct.NavigateUrl = productURL;
                        hlProduct.Text = Server.HtmlEncode(product.Name);
                    }
                    //\
                    Literal lblPrice = (Literal)e.Item.FindControl("lblPrice");
                    if (lblPrice != null)
                    {
                        var productVariantCollection = product.ProductVariants;
                        if (productVariantCollection.Count > 0)
                        {
                            if (!product.HasMultipleVariants)
                            {
                                var productVariant = productVariantCollection[0];

                                if (!SettingManager.GetSettingValueBoolean("Common.HidePricesForNonRegistered") ||
                                    (NopContext.Current.User != null &&
                                    !NopContext.Current.User.IsGuest))
                                {
                                    if (productVariant.CustomerEntersPrice)
                                    {
                                        //lblOldPrice.Visible = false;
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
                                            //lblOldPrice.Text = PriceHelper.FormatPrice(oldPrice);
                                            lblPrice.Text = PriceHelper.FormatPrice(finalPriceWithoutDiscount);
                                        }
                                        else
                                        {
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Text = PriceHelper.FormatPrice(finalPriceWithoutDiscount);
                                        }
                                    }
                                }
                                else
                                {
                                    //lblOldPrice.Visible = false;
                                    lblPrice.Visible = false;
                                    //btnAddToCart.Visible = false;
                                }
                            }
                            else
                            {
                                var productVariant = product.MinimalPriceProductVariant;
                                if (productVariant != null)
                                {
                                    if (!SettingManager.GetSettingValueBoolean("Common.HidePricesForNonRegistered") ||
                                        (NopContext.Current.User != null &&
                                        !NopContext.Current.User.IsGuest))
                                    {
                                        if (productVariant.CustomerEntersPrice)
                                        {
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Visible = false;
                                        }
                                        else
                                        {
                                            decimal fromPriceBase = TaxManager.GetPrice(productVariant, PriceHelper.GetFinalPrice(productVariant, false));
                                            decimal fromPrice = CurrencyManager.ConvertCurrency(fromPriceBase, CurrencyManager.PrimaryStoreCurrency, NopContext.Current.WorkingCurrency);
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Text = String.Format(GetLocaleResourceString("Products.PriceRangeFromText"), PriceHelper.FormatPrice(fromPrice));
                                        }
                                    }
                                    else
                                    {
                                        //lblOldPrice.Visible = false;
                                        lblPrice.Visible = false;
                                        //btnAddToCart.Visible = false;
                                    }
                                }

                                //btnAddToCart.Visible = false;
                            }
                        }
                        else
                        {
                            //lblOldPrice.Visible = false;
                            lblPrice.Visible = false;
                            //btnAddToCart.Visible = false;
                        }
                    }
                    HyperLink hplImageBuyNow = (HyperLink)e.Item.FindControl("hplImageBuyNow");
                    if (hplImageBuyNow != null)
                    {
                        hplImageBuyNow.NavigateUrl = productURL;
                    }
                }
            }
        }

        protected void dlBrand_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var product = e.Item.DataItem as Product;
                if (product != null)
                {
                    string productURL = SEOHelper.GetProductUrl(product);

                    var hlImageLink = e.Item.FindControl("hlImageLink") as HyperLink;
                    if (hlImageLink != null)
                    {
                        ProductPicture productPicture = product.DefaultProductPicture;
                        if (productPicture != null)
                            hlImageLink.ImageUrl = PictureManager.GetPictureUrl(productPicture.Picture, SettingManager.GetSettingValueInteger("Media.Product.ThumbnailImageSize", 125), true);
                        else
                            hlImageLink.ImageUrl = PictureManager.GetDefaultPictureUrl(SettingManager.GetSettingValueInteger("Media.Product.ThumbnailImageSize", 125));

                        hlImageLink.NavigateUrl = productURL;
                        hlImageLink.ToolTip = String.Format(GetLocaleResourceString("Media.Product.ImageLinkTitleFormat"), product.Name);
                        hlImageLink.Text = String.Format(GetLocaleResourceString("Media.Product.ImageAlternateTextFormat"), product.Name);
                    }
                    // add catalog number
                    AddCatalogNo(product.ProductId, productURL, e);
                    //
                    var hlProduct = e.Item.FindControl("hlProduct") as HyperLink;
                    if (hlProduct != null)
                    {
                        hlProduct.NavigateUrl = productURL;
                        hlProduct.Text = Server.HtmlEncode(product.Name);
                    }
                    //\
                    Literal lblPrice = (Literal)e.Item.FindControl("lblPrice");
                    if (lblPrice != null)
                    {
                        var productVariantCollection = product.ProductVariants;
                        if (productVariantCollection.Count > 0)
                        {
                            if (!product.HasMultipleVariants)
                            {
                                var productVariant = productVariantCollection[0];

                                if (!SettingManager.GetSettingValueBoolean("Common.HidePricesForNonRegistered") ||
                                    (NopContext.Current.User != null &&
                                    !NopContext.Current.User.IsGuest))
                                {
                                    if (productVariant.CustomerEntersPrice)
                                    {
                                        //lblOldPrice.Visible = false;
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
                                            //lblOldPrice.Text = PriceHelper.FormatPrice(oldPrice);
                                            lblPrice.Text = PriceHelper.FormatPrice(finalPriceWithoutDiscount);
                                        }
                                        else
                                        {
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Text = PriceHelper.FormatPrice(finalPriceWithoutDiscount);
                                        }
                                    }
                                }
                                else
                                {
                                    //lblOldPrice.Visible = false;
                                    lblPrice.Visible = false;
                                    //btnAddToCart.Visible = false;
                                }
                            }
                            else
                            {
                                var productVariant = product.MinimalPriceProductVariant;
                                if (productVariant != null)
                                {
                                    if (!SettingManager.GetSettingValueBoolean("Common.HidePricesForNonRegistered") ||
                                        (NopContext.Current.User != null &&
                                        !NopContext.Current.User.IsGuest))
                                    {
                                        if (productVariant.CustomerEntersPrice)
                                        {
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Visible = false;
                                        }
                                        else
                                        {
                                            decimal fromPriceBase = TaxManager.GetPrice(productVariant, PriceHelper.GetFinalPrice(productVariant, false));
                                            decimal fromPrice = CurrencyManager.ConvertCurrency(fromPriceBase, CurrencyManager.PrimaryStoreCurrency, NopContext.Current.WorkingCurrency);
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Text = String.Format(GetLocaleResourceString("Products.PriceRangeFromText"), PriceHelper.FormatPrice(fromPrice));
                                        }
                                    }
                                    else
                                    {
                                        //lblOldPrice.Visible = false;
                                        lblPrice.Visible = false;
                                        //btnAddToCart.Visible = false;
                                    }
                                }

                                //btnAddToCart.Visible = false;
                            }
                        }
                        else
                        {
                            //lblOldPrice.Visible = false;
                            lblPrice.Visible = false;
                            //btnAddToCart.Visible = false;
                        }
                    }
                    HyperLink hplImageBuyNow = (HyperLink)e.Item.FindControl("hplImageBuyNow");
                    if (hplImageBuyNow != null)
                    {
                        hplImageBuyNow.NavigateUrl = productURL;
                    }
                }
            }
        }

        protected void dlKeyboards_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var product = e.Item.DataItem as Product;
                if (product != null)
                {
                    string productURL = SEOHelper.GetProductUrl(product);

                    var hlImageLink = e.Item.FindControl("hlImageLink") as HyperLink;
                    if (hlImageLink != null)
                    {
                        ProductPicture productPicture = product.DefaultProductPicture;
                        if (productPicture != null)
                            hlImageLink.ImageUrl = PictureManager.GetPictureUrl(productPicture.Picture, SettingManager.GetSettingValueInteger("Media.Product.ThumbnailImageSize", 125), true);
                        else
                            hlImageLink.ImageUrl = PictureManager.GetDefaultPictureUrl(SettingManager.GetSettingValueInteger("Media.Product.ThumbnailImageSize", 125));

                        hlImageLink.NavigateUrl = productURL;
                        hlImageLink.ToolTip = String.Format(GetLocaleResourceString("Media.Product.ImageLinkTitleFormat"), product.Name);
                        hlImageLink.Text = String.Format(GetLocaleResourceString("Media.Product.ImageAlternateTextFormat"), product.Name);
                    }
                    // add catalog number
                    AddCatalogNo(product.ProductId, productURL, e);
                    //
                    var hlProduct = e.Item.FindControl("hlProduct") as HyperLink;
                    if (hlProduct != null)
                    {
                        hlProduct.NavigateUrl = productURL;
                        hlProduct.Text = Server.HtmlEncode(product.Name);
                    }
                    //\
                    Literal lblPrice = (Literal)e.Item.FindControl("lblPrice");
                    if (lblPrice != null)
                    {
                        var productVariantCollection = product.ProductVariants;
                        if (productVariantCollection.Count > 0)
                        {
                            if (!product.HasMultipleVariants)
                            {
                                var productVariant = productVariantCollection[0];

                                if (!SettingManager.GetSettingValueBoolean("Common.HidePricesForNonRegistered") ||
                                    (NopContext.Current.User != null &&
                                    !NopContext.Current.User.IsGuest))
                                {
                                    if (productVariant.CustomerEntersPrice)
                                    {
                                        //lblOldPrice.Visible = false;
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
                                            //lblOldPrice.Text = PriceHelper.FormatPrice(oldPrice);
                                            lblPrice.Text = PriceHelper.FormatPrice(finalPriceWithoutDiscount);
                                        }
                                        else
                                        {
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Text = PriceHelper.FormatPrice(finalPriceWithoutDiscount);
                                        }
                                    }
                                }
                                else
                                {
                                    //lblOldPrice.Visible = false;
                                    lblPrice.Visible = false;
                                    //btnAddToCart.Visible = false;
                                }
                            }
                            else
                            {
                                var productVariant = product.MinimalPriceProductVariant;
                                if (productVariant != null)
                                {
                                    if (!SettingManager.GetSettingValueBoolean("Common.HidePricesForNonRegistered") ||
                                        (NopContext.Current.User != null &&
                                        !NopContext.Current.User.IsGuest))
                                    {
                                        if (productVariant.CustomerEntersPrice)
                                        {
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Visible = false;
                                        }
                                        else
                                        {
                                            decimal fromPriceBase = TaxManager.GetPrice(productVariant, PriceHelper.GetFinalPrice(productVariant, false));
                                            decimal fromPrice = CurrencyManager.ConvertCurrency(fromPriceBase, CurrencyManager.PrimaryStoreCurrency, NopContext.Current.WorkingCurrency);
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Text = String.Format(GetLocaleResourceString("Products.PriceRangeFromText"), PriceHelper.FormatPrice(fromPrice));
                                        }
                                    }
                                    else
                                    {
                                        //lblOldPrice.Visible = false;
                                        lblPrice.Visible = false;
                                        //btnAddToCart.Visible = false;
                                    }
                                }

                                //btnAddToCart.Visible = false;
                            }
                        }
                        else
                        {
                            //lblOldPrice.Visible = false;
                            lblPrice.Visible = false;
                            //btnAddToCart.Visible = false;
                        }
                    }
                    HyperLink hplImageBuyNow = (HyperLink)e.Item.FindControl("hplImageBuyNow");
                    if (hplImageBuyNow != null)
                    {
                        hplImageBuyNow.NavigateUrl = productURL;
                    }
                }
            }
        }

        protected void dlWoodwinds_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var product = e.Item.DataItem as Product;
                if (product != null)
                {
                    string productURL = SEOHelper.GetProductUrl(product);

                    var hlImageLink = e.Item.FindControl("hlImageLink") as HyperLink;
                    if (hlImageLink != null)
                    {
                        ProductPicture productPicture = product.DefaultProductPicture;
                        if (productPicture != null)
                            hlImageLink.ImageUrl = PictureManager.GetPictureUrl(productPicture.Picture, SettingManager.GetSettingValueInteger("Media.Product.ThumbnailImageSize", 125), true);
                        else
                            hlImageLink.ImageUrl = PictureManager.GetDefaultPictureUrl(SettingManager.GetSettingValueInteger("Media.Product.ThumbnailImageSize", 125));

                        hlImageLink.NavigateUrl = productURL;
                        hlImageLink.ToolTip = String.Format(GetLocaleResourceString("Media.Product.ImageLinkTitleFormat"), product.Name);
                        hlImageLink.Text = String.Format(GetLocaleResourceString("Media.Product.ImageAlternateTextFormat"), product.Name);
                    }
                    // add catalog number
                    AddCatalogNo(product.ProductId, productURL, e);
                    //
                    var hlProduct = e.Item.FindControl("hlProduct") as HyperLink;
                    if (hlProduct != null)
                    {
                        hlProduct.NavigateUrl = productURL;
                        hlProduct.Text = Server.HtmlEncode(product.Name);
                    }
                    //\
                    Literal lblPrice = (Literal)e.Item.FindControl("lblPrice");
                    if (lblPrice != null)
                    {
                        var productVariantCollection = product.ProductVariants;
                        if (productVariantCollection.Count > 0)
                        {
                            if (!product.HasMultipleVariants)
                            {
                                var productVariant = productVariantCollection[0];

                                if (!SettingManager.GetSettingValueBoolean("Common.HidePricesForNonRegistered") ||
                                    (NopContext.Current.User != null &&
                                    !NopContext.Current.User.IsGuest))
                                {
                                    if (productVariant.CustomerEntersPrice)
                                    {
                                        //lblOldPrice.Visible = false;
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
                                            //lblOldPrice.Text = PriceHelper.FormatPrice(oldPrice);
                                            lblPrice.Text = PriceHelper.FormatPrice(finalPriceWithoutDiscount);
                                        }
                                        else
                                        {
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Text = PriceHelper.FormatPrice(finalPriceWithoutDiscount);
                                        }
                                    }
                                }
                                else
                                {
                                    //lblOldPrice.Visible = false;
                                    lblPrice.Visible = false;
                                    //btnAddToCart.Visible = false;
                                }
                            }
                            else
                            {
                                var productVariant = product.MinimalPriceProductVariant;
                                if (productVariant != null)
                                {
                                    if (!SettingManager.GetSettingValueBoolean("Common.HidePricesForNonRegistered") ||
                                        (NopContext.Current.User != null &&
                                        !NopContext.Current.User.IsGuest))
                                    {
                                        if (productVariant.CustomerEntersPrice)
                                        {
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Visible = false;
                                        }
                                        else
                                        {
                                            decimal fromPriceBase = TaxManager.GetPrice(productVariant, PriceHelper.GetFinalPrice(productVariant, false));
                                            decimal fromPrice = CurrencyManager.ConvertCurrency(fromPriceBase, CurrencyManager.PrimaryStoreCurrency, NopContext.Current.WorkingCurrency);
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Text = String.Format(GetLocaleResourceString("Products.PriceRangeFromText"), PriceHelper.FormatPrice(fromPrice));
                                        }
                                    }
                                    else
                                    {
                                        //lblOldPrice.Visible = false;
                                        lblPrice.Visible = false;
                                        //btnAddToCart.Visible = false;
                                    }
                                }

                                //btnAddToCart.Visible = false;
                            }
                        }
                        else
                        {
                            //lblOldPrice.Visible = false;
                            lblPrice.Visible = false;
                            //btnAddToCart.Visible = false;
                        }
                    }
                    HyperLink hplImageBuyNow = (HyperLink)e.Item.FindControl("hplImageBuyNow");
                    if (hplImageBuyNow != null)
                    {
                        hplImageBuyNow.NavigateUrl = productURL;
                    }
                }
            }
        }

        protected void dlVoice_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var product = e.Item.DataItem as Product;
                if (product != null)
                {
                    string productURL = SEOHelper.GetProductUrl(product);

                    var hlImageLink = e.Item.FindControl("hlImageLink") as HyperLink;
                    if (hlImageLink != null)
                    {
                        ProductPicture productPicture = product.DefaultProductPicture;
                        if (productPicture != null)
                            hlImageLink.ImageUrl = PictureManager.GetPictureUrl(productPicture.Picture, SettingManager.GetSettingValueInteger("Media.Product.ThumbnailImageSize", 125), true);
                        else
                            hlImageLink.ImageUrl = PictureManager.GetDefaultPictureUrl(SettingManager.GetSettingValueInteger("Media.Product.ThumbnailImageSize", 125));

                        hlImageLink.NavigateUrl = productURL;
                        hlImageLink.ToolTip = String.Format(GetLocaleResourceString("Media.Product.ImageLinkTitleFormat"), product.Name);
                        hlImageLink.Text = String.Format(GetLocaleResourceString("Media.Product.ImageAlternateTextFormat"), product.Name);
                    }
                    // add catalog number
                    AddCatalogNo(product.ProductId, productURL, e);
                    //
                    var hlProduct = e.Item.FindControl("hlProduct") as HyperLink;
                    if (hlProduct != null)
                    {
                        hlProduct.NavigateUrl = productURL;
                        hlProduct.Text = Server.HtmlEncode(product.Name);
                    }
                    //\
                    Literal lblPrice = (Literal)e.Item.FindControl("lblPrice");
                    if (lblPrice != null)
                    {
                        var productVariantCollection = product.ProductVariants;
                        if (productVariantCollection.Count > 0)
                        {
                            if (!product.HasMultipleVariants)
                            {
                                var productVariant = productVariantCollection[0];

                                if (!SettingManager.GetSettingValueBoolean("Common.HidePricesForNonRegistered") ||
                                    (NopContext.Current.User != null &&
                                    !NopContext.Current.User.IsGuest))
                                {
                                    if (productVariant.CustomerEntersPrice)
                                    {
                                        //lblOldPrice.Visible = false;
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
                                            //lblOldPrice.Text = PriceHelper.FormatPrice(oldPrice);
                                            lblPrice.Text = PriceHelper.FormatPrice(finalPriceWithoutDiscount);
                                        }
                                        else
                                        {
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Text = PriceHelper.FormatPrice(finalPriceWithoutDiscount);
                                        }
                                    }
                                }
                                else
                                {
                                    //lblOldPrice.Visible = false;
                                    lblPrice.Visible = false;
                                    //btnAddToCart.Visible = false;
                                }
                            }
                            else
                            {
                                var productVariant = product.MinimalPriceProductVariant;
                                if (productVariant != null)
                                {
                                    if (!SettingManager.GetSettingValueBoolean("Common.HidePricesForNonRegistered") ||
                                        (NopContext.Current.User != null &&
                                        !NopContext.Current.User.IsGuest))
                                    {
                                        if (productVariant.CustomerEntersPrice)
                                        {
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Visible = false;
                                        }
                                        else
                                        {
                                            decimal fromPriceBase = TaxManager.GetPrice(productVariant, PriceHelper.GetFinalPrice(productVariant, false));
                                            decimal fromPrice = CurrencyManager.ConvertCurrency(fromPriceBase, CurrencyManager.PrimaryStoreCurrency, NopContext.Current.WorkingCurrency);
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Text = String.Format(GetLocaleResourceString("Products.PriceRangeFromText"), PriceHelper.FormatPrice(fromPrice));
                                        }
                                    }
                                    else
                                    {
                                        //lblOldPrice.Visible = false;
                                        lblPrice.Visible = false;
                                        //btnAddToCart.Visible = false;
                                    }
                                }

                                //btnAddToCart.Visible = false;
                            }
                        }
                        else
                        {
                            //lblOldPrice.Visible = false;
                            lblPrice.Visible = false;
                            //btnAddToCart.Visible = false;
                        }
                    }
                    HyperLink hplImageBuyNow = (HyperLink)e.Item.FindControl("hplImageBuyNow");
                    if (hplImageBuyNow != null)
                    {
                        hplImageBuyNow.NavigateUrl = productURL;
                    }
                }
            }
        }

        protected void dlStringOrchestra_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var product = e.Item.DataItem as Product;
                if (product != null)
                {
                    string productURL = SEOHelper.GetProductUrl(product);

                    var hlImageLink = e.Item.FindControl("hlImageLink") as HyperLink;
                    if (hlImageLink != null)
                    {
                        ProductPicture productPicture = product.DefaultProductPicture;
                        if (productPicture != null)
                            hlImageLink.ImageUrl = PictureManager.GetPictureUrl(productPicture.Picture, SettingManager.GetSettingValueInteger("Media.Product.ThumbnailImageSize", 125), true);
                        else
                            hlImageLink.ImageUrl = PictureManager.GetDefaultPictureUrl(SettingManager.GetSettingValueInteger("Media.Product.ThumbnailImageSize", 125));

                        hlImageLink.NavigateUrl = productURL;
                        hlImageLink.ToolTip = String.Format(GetLocaleResourceString("Media.Product.ImageLinkTitleFormat"), product.Name);
                        hlImageLink.Text = String.Format(GetLocaleResourceString("Media.Product.ImageAlternateTextFormat"), product.Name);
                    }
                    // add catalog number
                    AddCatalogNo(product.ProductId, productURL, e);
                    //
                    var hlProduct = e.Item.FindControl("hlProduct") as HyperLink;
                    if (hlProduct != null)
                    {
                        hlProduct.NavigateUrl = productURL;
                        hlProduct.Text = Server.HtmlEncode(product.Name);
                    }
                    //\
                    Literal lblPrice = (Literal)e.Item.FindControl("lblPrice");
                    if (lblPrice != null)
                    {
                        var productVariantCollection = product.ProductVariants;
                        if (productVariantCollection.Count > 0)
                        {
                            if (!product.HasMultipleVariants)
                            {
                                var productVariant = productVariantCollection[0];

                                if (!SettingManager.GetSettingValueBoolean("Common.HidePricesForNonRegistered") ||
                                    (NopContext.Current.User != null &&
                                    !NopContext.Current.User.IsGuest))
                                {
                                    if (productVariant.CustomerEntersPrice)
                                    {
                                        //lblOldPrice.Visible = false;
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
                                            //lblOldPrice.Text = PriceHelper.FormatPrice(oldPrice);
                                            lblPrice.Text = PriceHelper.FormatPrice(finalPriceWithoutDiscount);
                                        }
                                        else
                                        {
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Text = PriceHelper.FormatPrice(finalPriceWithoutDiscount);
                                        }
                                    }
                                }
                                else
                                {
                                    //lblOldPrice.Visible = false;
                                    lblPrice.Visible = false;
                                    //btnAddToCart.Visible = false;
                                }
                            }
                            else
                            {
                                var productVariant = product.MinimalPriceProductVariant;
                                if (productVariant != null)
                                {
                                    if (!SettingManager.GetSettingValueBoolean("Common.HidePricesForNonRegistered") ||
                                        (NopContext.Current.User != null &&
                                        !NopContext.Current.User.IsGuest))
                                    {
                                        if (productVariant.CustomerEntersPrice)
                                        {
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Visible = false;
                                        }
                                        else
                                        {
                                            decimal fromPriceBase = TaxManager.GetPrice(productVariant, PriceHelper.GetFinalPrice(productVariant, false));
                                            decimal fromPrice = CurrencyManager.ConvertCurrency(fromPriceBase, CurrencyManager.PrimaryStoreCurrency, NopContext.Current.WorkingCurrency);
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Text = String.Format(GetLocaleResourceString("Products.PriceRangeFromText"), PriceHelper.FormatPrice(fromPrice));
                                        }
                                    }
                                    else
                                    {
                                        //lblOldPrice.Visible = false;
                                        lblPrice.Visible = false;
                                        //btnAddToCart.Visible = false;
                                    }
                                }

                                //btnAddToCart.Visible = false;
                            }
                        }
                        else
                        {
                            //lblOldPrice.Visible = false;
                            lblPrice.Visible = false;
                            //btnAddToCart.Visible = false;
                        }
                    }
                    HyperLink hplImageBuyNow = (HyperLink)e.Item.FindControl("hplImageBuyNow");
                    if (hplImageBuyNow != null)
                    {
                        hplImageBuyNow.NavigateUrl = productURL;
                    }
                }
            }
        }

        protected void dlString_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var product = e.Item.DataItem as Product;
                if (product != null)
                {
                    string productURL = SEOHelper.GetProductUrl(product);

                    var hlImageLink = e.Item.FindControl("hlImageLink") as HyperLink;
                    if (hlImageLink != null)
                    {
                        ProductPicture productPicture = product.DefaultProductPicture;
                        if (productPicture != null)
                            hlImageLink.ImageUrl = PictureManager.GetPictureUrl(productPicture.Picture, SettingManager.GetSettingValueInteger("Media.Product.ThumbnailImageSize", 125), true);
                        else
                            hlImageLink.ImageUrl = PictureManager.GetDefaultPictureUrl(SettingManager.GetSettingValueInteger("Media.Product.ThumbnailImageSize", 125));

                        hlImageLink.NavigateUrl = productURL;
                        hlImageLink.ToolTip = String.Format(GetLocaleResourceString("Media.Product.ImageLinkTitleFormat"), product.Name);
                        hlImageLink.Text = String.Format(GetLocaleResourceString("Media.Product.ImageAlternateTextFormat"), product.Name);
                    }
                    // add catalog number
                    AddCatalogNo(product.ProductId, productURL, e);
                    //
                    var hlProduct = e.Item.FindControl("hlProduct") as HyperLink;
                    if (hlProduct != null)
                    {
                        hlProduct.NavigateUrl = productURL;
                        hlProduct.Text = Server.HtmlEncode(product.Name);
                    }
                    //\
                    Literal lblPrice = (Literal)e.Item.FindControl("lblPrice");
                    if (lblPrice != null)
                    {
                        var productVariantCollection = product.ProductVariants;
                        if (productVariantCollection.Count > 0)
                        {
                            if (!product.HasMultipleVariants)
                            {
                                var productVariant = productVariantCollection[0];

                                if (!SettingManager.GetSettingValueBoolean("Common.HidePricesForNonRegistered") ||
                                    (NopContext.Current.User != null &&
                                    !NopContext.Current.User.IsGuest))
                                {
                                    if (productVariant.CustomerEntersPrice)
                                    {
                                        //lblOldPrice.Visible = false;
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
                                            //lblOldPrice.Text = PriceHelper.FormatPrice(oldPrice);
                                            lblPrice.Text = PriceHelper.FormatPrice(finalPriceWithoutDiscount);
                                        }
                                        else
                                        {
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Text = PriceHelper.FormatPrice(finalPriceWithoutDiscount);
                                        }
                                    }
                                }
                                else
                                {
                                    //lblOldPrice.Visible = false;
                                    lblPrice.Visible = false;
                                    //btnAddToCart.Visible = false;
                                }
                            }
                            else
                            {
                                var productVariant = product.MinimalPriceProductVariant;
                                if (productVariant != null)
                                {
                                    if (!SettingManager.GetSettingValueBoolean("Common.HidePricesForNonRegistered") ||
                                        (NopContext.Current.User != null &&
                                        !NopContext.Current.User.IsGuest))
                                    {
                                        if (productVariant.CustomerEntersPrice)
                                        {
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Visible = false;
                                        }
                                        else
                                        {
                                            decimal fromPriceBase = TaxManager.GetPrice(productVariant, PriceHelper.GetFinalPrice(productVariant, false));
                                            decimal fromPrice = CurrencyManager.ConvertCurrency(fromPriceBase, CurrencyManager.PrimaryStoreCurrency, NopContext.Current.WorkingCurrency);
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Text = String.Format(GetLocaleResourceString("Products.PriceRangeFromText"), PriceHelper.FormatPrice(fromPrice));
                                        }
                                    }
                                    else
                                    {
                                        //lblOldPrice.Visible = false;
                                        lblPrice.Visible = false;
                                        //btnAddToCart.Visible = false;
                                    }
                                }

                                //btnAddToCart.Visible = false;
                            }
                        }
                        else
                        {
                            //lblOldPrice.Visible = false;
                            lblPrice.Visible = false;
                            //btnAddToCart.Visible = false;
                        }
                    }
                    HyperLink hplImageBuyNow = (HyperLink)e.Item.FindControl("hplImageBuyNow");
                    if (hplImageBuyNow != null)
                    {
                        hplImageBuyNow.NavigateUrl = productURL;
                    }
                }
            }
        }

        protected void dlPercussion_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var product = e.Item.DataItem as Product;
                if (product != null)
                {
                    string productURL = SEOHelper.GetProductUrl(product);

                    var hlImageLink = e.Item.FindControl("hlImageLink") as HyperLink;
                    if (hlImageLink != null)
                    {
                        ProductPicture productPicture = product.DefaultProductPicture;
                        if (productPicture != null)
                            hlImageLink.ImageUrl = PictureManager.GetPictureUrl(productPicture.Picture, SettingManager.GetSettingValueInteger("Media.Product.ThumbnailImageSize", 125), true);
                        else
                            hlImageLink.ImageUrl = PictureManager.GetDefaultPictureUrl(SettingManager.GetSettingValueInteger("Media.Product.ThumbnailImageSize", 125));

                        hlImageLink.NavigateUrl = productURL;
                        hlImageLink.ToolTip = String.Format(GetLocaleResourceString("Media.Product.ImageLinkTitleFormat"), product.Name);
                        hlImageLink.Text = String.Format(GetLocaleResourceString("Media.Product.ImageAlternateTextFormat"), product.Name);
                    }
                    // add catalog number
                    AddCatalogNo(product.ProductId, productURL, e);
                    //
                    var hlProduct = e.Item.FindControl("hlProduct") as HyperLink;
                    if (hlProduct != null)
                    {
                        hlProduct.NavigateUrl = productURL;
                        hlProduct.Text = Server.HtmlEncode(product.Name);
                    }
                    //\
                    Literal lblPrice = (Literal)e.Item.FindControl("lblPrice");
                    if (lblPrice != null)
                    {
                        var productVariantCollection = product.ProductVariants;
                        if (productVariantCollection.Count > 0)
                        {
                            if (!product.HasMultipleVariants)
                            {
                                var productVariant = productVariantCollection[0];

                                if (!SettingManager.GetSettingValueBoolean("Common.HidePricesForNonRegistered") ||
                                    (NopContext.Current.User != null &&
                                    !NopContext.Current.User.IsGuest))
                                {
                                    if (productVariant.CustomerEntersPrice)
                                    {
                                        //lblOldPrice.Visible = false;
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
                                            //lblOldPrice.Text = PriceHelper.FormatPrice(oldPrice);
                                            lblPrice.Text = PriceHelper.FormatPrice(finalPriceWithoutDiscount);
                                        }
                                        else
                                        {
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Text = PriceHelper.FormatPrice(finalPriceWithoutDiscount);
                                        }
                                    }
                                }
                                else
                                {
                                    //lblOldPrice.Visible = false;
                                    lblPrice.Visible = false;
                                    //btnAddToCart.Visible = false;
                                }
                            }
                            else
                            {
                                var productVariant = product.MinimalPriceProductVariant;
                                if (productVariant != null)
                                {
                                    if (!SettingManager.GetSettingValueBoolean("Common.HidePricesForNonRegistered") ||
                                        (NopContext.Current.User != null &&
                                        !NopContext.Current.User.IsGuest))
                                    {
                                        if (productVariant.CustomerEntersPrice)
                                        {
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Visible = false;
                                        }
                                        else
                                        {
                                            decimal fromPriceBase = TaxManager.GetPrice(productVariant, PriceHelper.GetFinalPrice(productVariant, false));
                                            decimal fromPrice = CurrencyManager.ConvertCurrency(fromPriceBase, CurrencyManager.PrimaryStoreCurrency, NopContext.Current.WorkingCurrency);
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Text = String.Format(GetLocaleResourceString("Products.PriceRangeFromText"), PriceHelper.FormatPrice(fromPrice));
                                        }
                                    }
                                    else
                                    {
                                        //lblOldPrice.Visible = false;
                                        lblPrice.Visible = false;
                                        //btnAddToCart.Visible = false;
                                    }
                                }

                                //btnAddToCart.Visible = false;
                            }
                        }
                        else
                        {
                            //lblOldPrice.Visible = false;
                            lblPrice.Visible = false;
                            //btnAddToCart.Visible = false;
                        }
                    }
                    HyperLink hplImageBuyNow = (HyperLink)e.Item.FindControl("hplImageBuyNow");
                    if (hplImageBuyNow != null)
                    {
                        hplImageBuyNow.NavigateUrl = productURL;
                    }
                }
            }
        }

        protected void dlBrass_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var product = e.Item.DataItem as Product;
                if (product != null)
                {
                    string productURL = SEOHelper.GetProductUrl(product);

                    var hlImageLink = e.Item.FindControl("hlImageLink") as HyperLink;
                    if (hlImageLink != null)
                    {
                        ProductPicture productPicture = product.DefaultProductPicture;
                        if (productPicture != null)
                            hlImageLink.ImageUrl = PictureManager.GetPictureUrl(productPicture.Picture, SettingManager.GetSettingValueInteger("Media.Product.ThumbnailImageSize", 125), true);
                        else
                            hlImageLink.ImageUrl = PictureManager.GetDefaultPictureUrl(SettingManager.GetSettingValueInteger("Media.Product.ThumbnailImageSize", 125));

                        hlImageLink.NavigateUrl = productURL;
                        hlImageLink.ToolTip = String.Format(GetLocaleResourceString("Media.Product.ImageLinkTitleFormat"), product.Name);
                        hlImageLink.Text = String.Format(GetLocaleResourceString("Media.Product.ImageAlternateTextFormat"), product.Name);
                    }
                    // add catalog number
                    AddCatalogNo(product.ProductId, productURL, e);
                    //
                    var hlProduct = e.Item.FindControl("hlProduct") as HyperLink;
                    if (hlProduct != null)
                    {
                        hlProduct.NavigateUrl = productURL;
                        hlProduct.Text = Server.HtmlEncode(product.Name);
                    }
                    //\
                    Literal lblPrice = (Literal)e.Item.FindControl("lblPrice");
                    if (lblPrice != null)
                    {
                        var productVariantCollection = product.ProductVariants;
                        if (productVariantCollection.Count > 0)
                        {
                            if (!product.HasMultipleVariants)
                            {
                                var productVariant = productVariantCollection[0];

                                if (!SettingManager.GetSettingValueBoolean("Common.HidePricesForNonRegistered") ||
                                    (NopContext.Current.User != null &&
                                    !NopContext.Current.User.IsGuest))
                                {
                                    if (productVariant.CustomerEntersPrice)
                                    {
                                        //lblOldPrice.Visible = false;
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
                                            //lblOldPrice.Text = PriceHelper.FormatPrice(oldPrice);
                                            lblPrice.Text = PriceHelper.FormatPrice(finalPriceWithoutDiscount);
                                        }
                                        else
                                        {
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Text = PriceHelper.FormatPrice(finalPriceWithoutDiscount);
                                        }
                                    }
                                }
                                else
                                {
                                    //lblOldPrice.Visible = false;
                                    lblPrice.Visible = false;
                                    //btnAddToCart.Visible = false;
                                }
                            }
                            else
                            {
                                var productVariant = product.MinimalPriceProductVariant;
                                if (productVariant != null)
                                {
                                    if (!SettingManager.GetSettingValueBoolean("Common.HidePricesForNonRegistered") ||
                                        (NopContext.Current.User != null &&
                                        !NopContext.Current.User.IsGuest))
                                    {
                                        if (productVariant.CustomerEntersPrice)
                                        {
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Visible = false;
                                        }
                                        else
                                        {
                                            decimal fromPriceBase = TaxManager.GetPrice(productVariant, PriceHelper.GetFinalPrice(productVariant, false));
                                            decimal fromPrice = CurrencyManager.ConvertCurrency(fromPriceBase, CurrencyManager.PrimaryStoreCurrency, NopContext.Current.WorkingCurrency);
                                            //lblOldPrice.Visible = false;
                                            lblPrice.Text = String.Format(GetLocaleResourceString("Products.PriceRangeFromText"), PriceHelper.FormatPrice(fromPrice));
                                        }
                                    }
                                    else
                                    {
                                        //lblOldPrice.Visible = false;
                                        lblPrice.Visible = false;
                                        //btnAddToCart.Visible = false;
                                    }
                                }

                                //btnAddToCart.Visible = false;
                            }
                        }
                        else
                        {
                            //lblOldPrice.Visible = false;
                            lblPrice.Visible = false;
                            //btnAddToCart.Visible = false;
                        }
                    }
                    HyperLink hplImageBuyNow = (HyperLink)e.Item.FindControl("hplImageBuyNow");
                    if (hplImageBuyNow != null)
                    {
                        hplImageBuyNow.NavigateUrl = productURL;
                    }
                }
            }
        }

        protected void AddCatalogNo(int productId, string productURL, DataListItemEventArgs e)
        {
            // add catalog number
            LWG.Business.CatalogBiz catalogBiz = new LWG.Business.CatalogBiz();
            lwg_Catalog catalog = catalogBiz.GetByID(productId);

            var hlCatalogNo = e.Item.FindControl("hlCatalogNo") as HyperLink;
            if (hlCatalogNo != null)
            {
                hlCatalogNo.NavigateUrl = productURL;
                hlCatalogNo.Text = Server.HtmlEncode(catalog.CatalogNumber);
            }
        }
                    //
    }
}