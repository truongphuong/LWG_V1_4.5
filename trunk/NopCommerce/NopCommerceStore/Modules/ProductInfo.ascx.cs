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
using NopSolutions.NopCommerce.BusinessLogic.Media;
using NopSolutions.NopCommerce.BusinessLogic.Products;
using NopSolutions.NopCommerce.Common.Utils;
using NopSolutions.NopCommerce.BusinessLogic.Configuration.Settings;
using LWG.Business;
using LWG.Core.Models;
using NopSolutions.NopCommerce.BusinessLogic.Categories;
using System.Collections.Generic;
using System.Linq;


namespace NopSolutions.NopCommerce.Web.Modules
{
    public partial class ProductInfoControl : BaseNopUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindData();
        }

        protected void BindData()
        {             
            var product = ProductManager.GetProductById(this.ProductId);
            if (product != null)
            {
                ctrlProductRating.Visible = product.AllowCustomerRatings;
                //Get product extend information
                CatalogBiz cService = new CatalogBiz();
                lwg_Catalog catalog = cService.GetByID(product.ProductId);

                lProductName.Text = Server.HtmlEncode(product.Name);
                lProductName1.Text = Server.HtmlEncode(product.Name);
                lShortDescription.Text = product.ShortDescription;
                lFullDescription.Text = product.FullDescription;
                lTableofContents.Text = catalog.TableofContents;
                ltrSubtitle.Text = catalog.Subtitle;

                var productPictures = product.ProductPictures;
                if (productPictures.Count > 1)
                {
                    defaultImage.ImageUrl = PictureManager.GetPictureUrl(productPictures[0].PictureId, SettingManager.GetSettingValueInteger("Media.Product.DetailImageSize", 300));
                    defaultImage.ToolTip = String.Format(GetLocaleResourceString("Media.Product.ImageAlternateTextFormat"), product.Name);
                    defaultImage.AlternateText = String.Format(GetLocaleResourceString("Media.Product.ImageAlternateTextFormat"), product.Name);
                    lvProductPictures.DataSource = productPictures;
                    lvProductPictures.DataBind();
                }
                else if (productPictures.Count == 1)
                {
                    defaultImage.ImageUrl = PictureManager.GetPictureUrl(productPictures[0].PictureId, SettingManager.GetSettingValueInteger("Media.Product.DetailImageSize", 300));
                    defaultImage.ToolTip = String.Format(GetLocaleResourceString("Media.Product.ImageAlternateTextFormat"), product.Name);
                    defaultImage.AlternateText = String.Format(GetLocaleResourceString("Media.Product.ImageAlternateTextFormat"), product.Name);
                    lvProductPictures.Visible = false;
                }
                else
                {
                    defaultImage.ImageUrl = PictureManager.GetDefaultPictureUrl(SettingManager.GetSettingValueInteger("Media.Product.DetailImageSize", 300));
                    defaultImage.ToolTip = String.Format(GetLocaleResourceString("Media.Product.ImageAlternateTextFormat"), product.Name);
                    defaultImage.AlternateText = String.Format(GetLocaleResourceString("Media.Product.ImageAlternateTextFormat"), product.Name);
                    lvProductPictures.Visible = false;
                }

                

                if (catalog != null)
                {
                    lProductName.Text = catalog.CatalogNumber + " - " + lProductName.Text;
                    //lProductName1.Text = catalog.TitleDisplay;
                    string strCompare = "http://";

                    AudioBiz audioBiz = new AudioBiz();
                    //lwg_Audio audio = audioBiz.GetSoundFile(catalog.CatalogId);
                    //if (audio != null)
                    //{
                    //    if (audio.SoundFile.TrimStart().StartsWith(strCompare))
                    //    {
                    //        hplListenToTheSample.NavigateUrl = audio.SoundFile;
                    //    }
                    //    else
                    //    {
                    //        hplListenToTheSample.NavigateUrl = string.Format("{0}{1}", LWGUtils.GetSoundPath(), audio.SoundFile);
                    //    }
                        
                    //}
                    List<lwg_Audio> audioList = audioBiz.GetAllSoundFiles(catalog.CatalogId);
                    if (audioList.Count > 0)
                    {
                        dlListenMusics.DataSource = audioList;
                        dlListenMusics.DataBind();
                        divListenToTheSample.Attributes.Add("style", "display:block;");
                    }
                    
                    if (!string.IsNullOrEmpty(catalog.PDF))
                    {
                        hplPreviewMusic.NavigateUrl = string.Format("{0}{1}", LWGUtils.GetPDFPath(), catalog.PDF);
                        divPreviewMusic.Attributes.Add("style", "display:block;");  
                    }
                    

                    if (catalog.lwg_PersonInRole != null && catalog.lwg_PersonInRole.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (lwg_PersonInRole catComposer in catalog.lwg_PersonInRole.OrderBy(p => p.RoleId))
                        {
                            if(catComposer.RoleId == LWGUtils.COMPOSER_ROLE_ID)
                                sb.Insert(0,string.Format("{0} ({1}), ",catComposer.lwg_Person.NameDisplay,catComposer.lwg_Role.Name));
                            else
                            sb.Append(catComposer.lwg_Person.NameDisplay).Append(" (" + catComposer.lwg_Role.Name).Append("), ");                            
                        }

                        string composer = sb.ToString();
                        if (composer.Length > 0)
                        {
                            try
                            {
                                composer = composer.Substring(0, composer.Length - 2);
                            }
                            catch
                            {
                                ;
                            }
                        }
                        ltrComposer.Text = "by " + composer;
                    }
                    else
                    {
                        ltrComposer.Text = string.Empty;
                    }

                    if (product.ProductVariants.Count > 0)
                    {
                        this.ltrPrice.Text = string.Format("{0:c}", product.ProductVariants[0].Price);
                        productVariantRepeater.DataSource = product.ProductVariants.OrderBy(pv => pv.Price);
                        productVariantRepeater.DataBind();
                    }
                    else
                    {
                        this.ltrPrice.Text = string.Format("{0:c}", "0");
                    }

                    this.ltrDuration.Text = catalog.Duration;
                    if (catalog.lwg_Instrumental != null)
                    {
                        this.ltrInstrumention.Text = catalog.lwg_Instrumental.LongName;
                    }

                    this.ltrYear.Text = catalog.Year;                    
                    this.ltrPeriod.Text = string.Empty;
                    
                    List<lwg_PeriodMapping> lstPeriod = new PeriodBiz().GetListPeriodMappingByCatalogID(ProductId);
                    if (lstPeriod != null && lstPeriod.Count > 0)
                    {
                        foreach (lwg_PeriodMapping lwg in lstPeriod)
                        {
                            this.ltrPeriod.Text += lwg.lwg_Period.Name + ", ";    
                        }
                        this.ltrPeriod.Text = this.ltrPeriod.Text.Substring(0, this.ltrPeriod.Text.Length - 2);                        
                    }

                    if (catalog.lwg_CatalogGenre != null && catalog.lwg_CatalogGenre.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (lwg_CatalogGenre catalogGenre in catalog.lwg_CatalogGenre)
                        {
                            sb.Append(catalogGenre.lwg_Genre.Name).Append(", ");
                        }

                        string genre = sb.ToString();
                        if (genre.Length > 0)
                        {
                            try
                            {
                                genre = genre.Substring(0, genre.Length - 2);
                            }
                            catch
                            {
                                ;
                            }
                        }

                        this.ltrGenre.Text = genre;
                        this.lblGenre.Visible = (genre != ""); // hide when blank field
                    }

                    this.ltrOrigPrint.Text = string.Empty;
                    List<lwg_ReprintSourceMapping> lstReprintSourceMapping = new ReprintSourceBiz().GetListReprintSourceMappingByCatalogID(ProductId);
                    if (lstReprintSourceMapping != null && lstReprintSourceMapping.Count > 0)
                    {
                        foreach (lwg_ReprintSourceMapping lwg in lstReprintSourceMapping)
                        {
                            this.ltrOrigPrint.Text += lwg.lwg_ReprintSource.Name + ", ";
                        }
                        this.ltrOrigPrint.Text = this.ltrOrigPrint.Text.Substring(0, this.ltrOrigPrint.Text.Length - 2);
                    }


                    if (product.ProductCategories != null && product.ProductCategories.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (ProductCategory productCat in product.ProductCategories)
                        {
                            sb.Append(productCat.Category.Name).Append(", ");
                        }

                        string category = sb.ToString();
                        if (category.Length > 0)
                        {
                            try
                            {
                                category = category.Substring(0, category.Length - 3);
                            }
                            catch
                            {
                                ;
                            }
                        }
                        this.ltrCategory.Text = category;
                    }

                    this.ltrSeries.Text = string.Empty;
                    List<lwg_SeriesMapping> lstSeriesMapping = new SeriesBiz().GetListSeriesMappingByCatalogID(ProductId);
                    if (lstSeriesMapping != null && lstSeriesMapping.Count > 0)
                    {
                        foreach (lwg_SeriesMapping lwg in lstSeriesMapping)
                        {
                            this.ltrSeries.Text += lwg.lwg_Series.Name + ", ";
                        }
                        this.ltrSeries.Text = this.ltrSeries.Text.Substring(0, this.ltrSeries.Text.Length - 2);
                    }

                    this.ltrText.Text = catalog.TextLang;
                    this.lGrade.Text = catalog.Grade;
                    this.ltrCopyrightYear.Text = catalog.CopyrightYear;
                    InitLabels(); // hide if blank field
                    
                    // add Grade Product Info

                }
                else
                {

                }
            }
            else
                this.Visible = false;
        }

        void InitLabels()
        {
            this.lblCategory.Visible = (this.ltrCategory.Text != "");
            this.lblGenre.Visible = (this.ltrGenre.Text != "");
            this.lblOrig.Visible = (this.ltrOrigPrint.Text != "");
            this.lblPeriod.Visible = (this.ltrPeriod.Text != "");
            this.lblSeries.Visible = (this.ltrSeries.Text != "");
            this.lblTextLang.Visible = (this.ltrText.Text != "");
            this.lblYear.Visible = (this.ltrYear.Text != "");
            this.lblGrade.Visible = (this.lGrade.Text != "");
            this.lblDuration.Visible = (this.ltrDuration.Text != "");
            this.lblInstrument.Visible = (this.ltrInstrumention.Text !="");
            this.lblCopyrightYear.Visible = this.ltrCopyrightYear.Text != "";
        }
        protected override void OnPreRender(EventArgs e)
        {
            //BindJQuery();

            string slimBox = CommonHelper.GetStoreLocation() + "Scripts/slimbox2.js";
            Page.ClientScript.RegisterClientScriptInclude(slimBox, slimBox);

            base.OnPreRender(e);
        }

        public int ProductId
        {
            get
            {
                return CommonHelper.QueryStringInt("ProductId");
            }
        }

        protected void dlListenMusics_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            lwg_Audio audio = e.Item.DataItem as lwg_Audio;
            HyperLink hpListenSampleMusic = e.Item.FindControl("hpListenSampleMusic") as HyperLink;
            HyperLink hpIconListenSampleMusic = e.Item.FindControl("hpIconListenSampleMusic") as HyperLink;
            if (audio != null && hpListenSampleMusic != null && hpIconListenSampleMusic != null)
            {
                string strCompare = "http://";
                if (audio.SoundFile.TrimStart().StartsWith(strCompare))
                {
                    hpListenSampleMusic.NavigateUrl = audio.SoundFile;
                    hpIconListenSampleMusic.NavigateUrl = audio.SoundFile;
                }
                else
                {
                    hpListenSampleMusic.NavigateUrl = string.Format("{0}{1}", LWGUtils.GetSoundPath(), audio.SoundFile);
                    hpIconListenSampleMusic.NavigateUrl = string.Format("{0}{1}", LWGUtils.GetSoundPath(), audio.SoundFile);
                }
                hpListenSampleMusic.Text = "Listen to the sample " + (e.Item.ItemIndex + 1).ToString();
            }
        }
    }
}