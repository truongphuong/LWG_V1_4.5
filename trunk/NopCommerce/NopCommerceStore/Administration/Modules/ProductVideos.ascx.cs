using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using NopSolutions.NopCommerce.BusinessLogic.Categories;
using NopSolutions.NopCommerce.BusinessLogic.Manufacturers;
using NopSolutions.NopCommerce.BusinessLogic.Media;
using NopSolutions.NopCommerce.BusinessLogic.Products;
using NopSolutions.NopCommerce.BusinessLogic.Products.Specs;
using NopSolutions.NopCommerce.BusinessLogic.Templates;
using NopSolutions.NopCommerce.Common.Utils;
using NopSolutions.NopCommerce.Web.Administration.Modules;
using LWG.Core.Models;
using LWG.Business;
namespace NopSolutions.NopCommerce.Web.Administration.Modules
{
    public partial class ProductVideos : BaseNopAdministrationUserControl
    {
        private void BindData()
        {
            Product product = ProductManager.GetProductById(ProductId);   
            if (product != null)
            {
                CatalogBiz catalogBiz = new CatalogBiz();
                lwg_Catalog catalog = catalogBiz.GetByID(this.ProductId);

                pnlData.Visible = true;
                pnlMessage.Visible = false;
                
                if(catalog !=null)
                {
                    if (catalog.lwg_Video.Count > 0)
                    {
                        gvVideos.Visible = true;
                        gvVideos.DataSource = catalog.lwg_Video;
                        gvVideos.DataBind();
                    }
                    else
                        gvVideos.Visible = false;
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

        private string SaveVideoFile(FileUpload fileupload, ref string strErr)
        {
            strErr = string.Empty;
            if (fileupload.HasFile)
            {
                try
                {
                    string temp = LWGUtils.SaveVideoFile(fileupload, LWGUtils.GetVideoPath(), ref strErr);
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
        protected void btnUploadProductVideo_Click(object sender, EventArgs e)
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
                    List<lwg_Video> videoList = new List<lwg_Video>();
                    lwg_Video video;
                    string error = string.Empty;
                    string path = SaveVideoFile(fuProductVideo1, ref error);
                    if (string.IsNullOrEmpty(error))
                    {
                        video = new lwg_Video();
                        video.CatalogId = this.ProductId;
                        video.DisplayOrder = txtProductVideoDisplayOrder1.Value;
                        video.QTFile = path;

                        videoList.Add(video);
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
                    path = SaveVideoFile(fuProductVideo2, ref error);
                    if (string.IsNullOrEmpty(error))
                    {
                        video = new lwg_Video();
                        video.CatalogId = this.ProductId;
                        video.DisplayOrder = txtProductVideoDisplayOrder2.Value;
                        video.QTFile = path;

                        videoList.Add(video);
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
                    path = SaveVideoFile(fuProductVideo3, ref error);
                    if (string.IsNullOrEmpty(error))
                    {
                        video = new lwg_Video();
                        video.CatalogId = this.ProductId;
                        video.DisplayOrder = txtProductVideoDisplayOrder3.Value;
                        video.QTFile = path;

                        videoList.Add(video);
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
                    if (videoList.Count > 0)
                    {
                        VideoBiz videoBiz = new VideoBiz();
                        videoBiz.AddCatalogVideo(videoList);

                        BindData();
                    }
                }
            }
            catch (Exception exc)
            {
                ProcessException(exc);
            }
        }

        protected void gvVideos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateProductVideo")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvVideos.Rows[index];
                NumericTextBox txtProductVideoDisplayOrder = row.FindControl("txtProductVideoDisplayOrder") as NumericTextBox;
                HiddenField hfProductVideoId = row.FindControl("hdVideoId") as HiddenField;

                int displayOrder = txtProductVideoDisplayOrder.Value;
                int productVideoId = int.Parse(hfProductVideoId.Value);
                VideoBiz videoBiz = new VideoBiz();
                lwg_Video video = videoBiz.GetVideoById(productVideoId);
                if (video != null)
                {
                    video.DisplayOrder = displayOrder;
                    videoBiz.UpdateCatalogVideo(video);
                }

                BindData();
            }
        }

        protected void gvVideos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnUpdate = e.Row.FindControl("btnUpdate") as Button;
                if (btnUpdate != null)
                    btnUpdate.CommandArgument = e.Row.RowIndex.ToString();
            }
        }

        protected void gvVideos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productVideoId = (int)gvVideos.DataKeys[e.RowIndex]["VideoId"];
            VideoBiz videoBiz = new VideoBiz();
            lwg_Video video = videoBiz.GetVideoById(productVideoId);
            if(video!=null)
            {
                videoBiz.DeleteCatalogVideo(productVideoId);
                LWGUtils.ClearOldFile(string.Format("{0}{1}", LWGUtils.GetVideoPath(), video.QTFile));
                BindData();
            }            
        }

        protected override void OnPreRender(EventArgs e)
        {
            BindJQuery();

            this.btnMoreUploads.Attributes["onclick"] = "showUploadVideoPanels(); return false;";
        }

        public int ProductId
        {
            get
            {
                return CommonHelper.QueryStringInt("ProductId");
            }
        }
    }
}