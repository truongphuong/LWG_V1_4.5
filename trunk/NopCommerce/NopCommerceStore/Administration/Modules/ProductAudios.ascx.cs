using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LWG.Business;
using LWG.Core.Models;
using NopSolutions.NopCommerce.BusinessLogic.Products;
using NopSolutions.NopCommerce.Common.Utils;
using NopSolutions.NopCommerce.BusinessLogic.Media;


namespace NopSolutions.NopCommerce.Web.Administration.Modules
{
    public partial class ProductAudios : BaseNopAdministrationUserControl
    {
        private void BindData()
        {
            
            Product product = ProductManager.GetProductById(ProductId);   
            if (product != null)
            {
                pnlData.Visible = true;
                pnlMessage.Visible = false;

                CatalogBiz catalogBiz = new CatalogBiz();
                lwg_Catalog catalog = catalogBiz.GetByID(this.ProductId);
                if (catalog != null)
                {
                    if (catalog.lwg_Audio.Count > 0)
                    {
                        gvAudios.Visible = true;
                        gvAudios.DataSource = catalog.lwg_Audio;
                        gvAudios.DataBind();                        
                    }
                    else
                        gvAudios.Visible = false;
                    if (!string.IsNullOrEmpty(catalog.SoundIcon))
                    {
                        int temp = 0;
                        if (int.TryParse(catalog.SoundIcon, out temp) && temp > 0)
                        {
                            Picture Picture = PictureManager.GetPictureById(temp);
                            string pictureUrl = PictureManager.GetPictureUrl(Picture, 100);
                            imgSoundIcon.Visible = true;
                            imgSoundIcon.ImageUrl = pictureUrl;
                        }
                    }
                }
            }
            else
            {
                pnlData.Visible = false;
                pnlMessage.Visible = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.BindData();
            }
        }

        private string SaveSoundFile(FileUpload fileupload, ref string strErr)
        {
            strErr = string.Empty;
            if (fileupload.HasFile)
            {
                try
                {
                    string temp = LWGUtils.SaveSoundFile(fileupload, LWGUtils.GetSoundPath(), ref strErr);
                    if (string.IsNullOrEmpty(strErr))
                    {
                        return temp;
                    }
                }
                catch (Exception ex)
                {
                    //TODO: uploadfile error
                    return string.Empty;
                }
            }
            else
            {
                strErr = LWGUtils.NO_FILE;
            }
            return string.Empty;
        }
        protected void btnUploadProductAudio_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = ProductManager.GetProductById(this.ProductId);
                if (product != null)
                {
                    CatalogBiz catalogBiz = new CatalogBiz();
                    lwg_Catalog catalog = catalogBiz.GetByID(product.ProductId);
                    if (catalog == null)
                    {
                        catalog = new lwg_Catalog();
                        catalog.CatalogId = product.ProductId;
                        catalog.CatalogNumber = string.Empty;
                        catalog.Subtitle = string.Empty;
                        catalog.TextLang = string.Empty;
                        catalog.PTSprodcode = string.Empty;
                        catalog.KaldbNumber = string.Empty;
                        catalog.SoundIcon = string.Empty;
                        catalog.PDF = string.Empty;
                        catalog.pages = string.Empty;
                        catalogBiz.SaveCatalog(catalog);
                    }
                    List<lwg_Audio> audioList = new List<lwg_Audio>();
                    lwg_Audio audio;
                    string error = string.Empty;
                    string path = SaveSoundFile(fuProductAudio1, ref error);
                    if (string.IsNullOrEmpty(error))
                    {
                        audio = new lwg_Audio();
                        audio.CatalogId = this.ProductId;
                        audio.DisplayOrder = txtProductAudioDisplayOrder1.Value;
                        audio.SoundFile = path;

                        audioList.Add(audio);
                    }
                    else
                    {
                        if (error == LWG.Business.LWGUtils.INVALID_FILE_EXTENSION)
                        {
                            throw new Exception("Invalid file extension."); 
                        }
                        else
                            if (error == LWG.Business.LWGUtils.INVALID_FILE_SIZE)
                            {
                                throw new Exception("Invalid file size");
                            }
                    }
                    path = SaveSoundFile(fuProductAudio2, ref error);
                    if (string.IsNullOrEmpty(error))
                    {
                        audio = new lwg_Audio();
                        audio.CatalogId = this.ProductId;
                        audio.DisplayOrder = txtProductAudioDisplayOrder2.Value;
                        audio.SoundFile = path;

                        audioList.Add(audio);
                    }
                    else
                    {
                        if (error == LWG.Business.LWGUtils.INVALID_FILE_EXTENSION)
                        {
                            throw new Exception("Invalid file extension."); 
                        }
                        else
                            if (error == LWG.Business.LWGUtils.INVALID_FILE_SIZE)
                            {
                                throw new Exception("Invalid file size");
                            }
                    }
                    path = SaveSoundFile(fuProductAudio3, ref error);
                    if (string.IsNullOrEmpty(error))
                    {
                        audio = new lwg_Audio();
                        audio.CatalogId = this.ProductId;
                        audio.DisplayOrder = txtProductAudioDisplayOrder3.Value;
                        audio.SoundFile = path;

                        audioList.Add(audio);
                    }
                    else
                    {
                        if (error == LWG.Business.LWGUtils.INVALID_FILE_EXTENSION)
                        {
                            throw new Exception("Invalid file extension."); 
                        }
                        else
                            if (error == LWG.Business.LWGUtils.INVALID_FILE_SIZE)
                            {
                                throw new Exception("Invalid file size");
                            }
                    }
                    // add videos
                    if (audioList.Count > 0)
                    {
                        AudioBiz audioBiz = new AudioBiz();
                        audioBiz.AddCatalogAudio(audioList);

                        BindData();
                    }
                                        
                }
            }
            catch (Exception exc)
            {
                ProcessException(exc);
            }
        }

        protected void gvAudios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateProductAudio")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvAudios.Rows[index];
                NumericTextBox txtProductVideoDisplayOrder = row.FindControl("txtProductAudioDisplayOrder") as NumericTextBox;
                HiddenField hfProductAudioId = row.FindControl("hdAudioId") as HiddenField;

                int displayOrder = txtProductVideoDisplayOrder.Value;
                int productAudioId = int.Parse(hfProductAudioId.Value);
                AudioBiz audioBiz = new AudioBiz();
                lwg_Audio audio = audioBiz.GetAudioById(productAudioId);
                if (audio != null)
                {
                    audio.DisplayOrder = displayOrder;
                    audioBiz.UpdateCatalogAudio(audio);
                }

                BindData();
            }
        }

        protected void gvAudios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnUpdate = e.Row.FindControl("btnUpdate") as Button;
                if (btnUpdate != null)
                    btnUpdate.CommandArgument = e.Row.RowIndex.ToString();
            }
        }

        protected void gvAudios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productAudioId = (int)gvAudios.DataKeys[e.RowIndex]["AudioId"];
            AudioBiz audioBiz = new AudioBiz();
            lwg_Audio audio = audioBiz.GetAudioById(productAudioId);
            if (audio != null)
            {
                audioBiz.DeleteCatalogAudio(productAudioId);
                LWGUtils.ClearOldFile(string.Format("{0}{1}", LWGUtils.GetSoundPath(), audio.SoundFile));
                BindData();
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            BindJQuery();

            this.btnMoreUploads.Attributes["onclick"] = "showUploadAudioPanels(); return false;";
        }

        public int ProductId
        {
            get
            {
                return CommonHelper.QueryStringInt("ProductId");
            }
        }
        private string SavePictureIcon(FileUpload fileupload)
        {
            Picture pic = null;
            lwg_Catalog lwg = new CatalogBiz().GetByID(ProductId);
            if (lwg != null)
            {
                if (!string.IsNullOrEmpty(lwg.SoundIcon))
                {
                    pic = PictureManager.GetPictureById(int.Parse(lwg.SoundIcon));
                }
            }
            HttpPostedFile PictureFile = fileupload.PostedFile;
            if ((PictureFile != null) && (!String.IsNullOrEmpty(PictureFile.FileName)))
            {
                byte[] pictureBinary = PictureManager.GetPictureBits(PictureFile.InputStream, PictureFile.ContentLength);
                if (pic != null)
                {
                    pic = PictureManager.UpdatePicture(pic.PictureId, pictureBinary, PictureFile.ContentType, true);
                }
                else
                {
                    pic = PictureManager.InsertPicture(pictureBinary, PictureFile.ContentType, true);
                }
            }
            int PictureId = 0;
            if (pic != null)
            {
                PictureId = pic.PictureId;
                //\                
                string pictureUrl = PictureManager.GetPictureUrl(pic, 100);
                imgSoundIcon.Visible = true;
                imgSoundIcon.ImageUrl = pictureUrl;
            }
            return PictureId.ToString();
        }

        protected void updateSoundIcon_Click(object sender, EventArgs e)
        {
            Product product = ProductManager.GetProductById(this.ProductId);
            if (product != null)
            {
                CatalogBiz catalogBiz = new CatalogBiz();
                lwg_Catalog catalog = catalogBiz.GetByID(ProductId);
                if (catalog == null)
                {
                    catalog = new lwg_Catalog();
                    catalog.CatalogId = product.ProductId;
                    catalog.CatalogNumber = string.Empty;
                    catalog.Subtitle = string.Empty;
                    catalog.TextLang = string.Empty;
                    catalog.PTSprodcode = string.Empty;
                    catalog.KaldbNumber = string.Empty;
                    catalog.SoundIcon = string.Empty;
                    catalog.PDF = string.Empty;
                    catalog.pages = string.Empty;
                    catalogBiz.SaveCatalog(catalog);
                }
                string strSoundIcon = SavePictureIcon(uploadSoundIcon);
                catalog.SoundIcon = strSoundIcon.Equals("0") == true ? catalog.SoundIcon : strSoundIcon; // txtSoundIcon.Text;// "soundIcon"; //TODO: change uploadfile control
                catalog.SoundIcon = catalog.SoundIcon == null ? string.Empty : catalog.SoundIcon;

                catalogBiz.SaveCatalog(catalog);
            }
        }
    }
}