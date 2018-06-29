using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using NopSolutions.NopCommerce.BusinessLogic;
using NopSolutions.NopCommerce.BusinessLogic.Configuration.Settings;
using NopSolutions.NopCommerce.BusinessLogic.ExportImport;
using NopSolutions.NopCommerce.BusinessLogic.Localization;
using NopSolutions.NopCommerce.BusinessLogic.Manufacturers;
using NopSolutions.NopCommerce.BusinessLogic.Products;
using NopSolutions.NopCommerce.BusinessLogic.Utils;
using NopSolutions.NopCommerce.Common.Utils;
using NopSolutions.NopCommerce.BusinessLogic.Media;
using LWG.Business;
using LWG.Core.Models;

namespace NopSolutions.NopCommerce.Web.Administration.Modules
{
    public partial class EmailDirectoryDetail : System.Web.UI.UserControl
    {
        EmailDirectoryBiz emailbiz = new EmailDirectoryBiz();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        private void BindData()
        {
            int emailid =0 ;
            Nop_EmailDirectory email = null;
            if (Request.QueryString["emailid"] != null&&int.TryParse(Request.QueryString["emailid"],out emailid))
            {
                email = emailbiz.GetEmailByID(emailid);
            }
            if (email != null)
            {
                txtDescription.Content = email.Description;
                txtEmailAddress.Text = email.EmailAddress;
                txtFirstName.Text = email.FirstName;
                txtJobTitle.Text = email.JobTitle;
                txtLastName.Text = email.LastName;
                txtPhoneNumber.Text = email.PhoneNumber;

                Picture Picture = PictureManager.GetPictureById(email.PictureID.Value);
                this.btnRemoveImage.Visible = Picture != null;
                string pictureUrl = PictureManager.GetPictureUrl(Picture, 100);
                this.iPicture.Visible = true;
                this.iPicture.ImageUrl = pictureUrl;

            }
        }
        private bool save()
        {
            int emailid = 0;
            Nop_EmailDirectory email = null;
            if (Request.QueryString["emailid"] != null && int.TryParse(Request.QueryString["emailid"], out emailid))
            {
                email = emailbiz.GetEmailByID(emailid);
            }

            if (email != null)
            {
                Picture pic = PictureManager.GetPictureById(email.PictureID.Value);
                HttpPostedFile PictureFile = fuPicture.PostedFile;
                if ((PictureFile != null) && (!String.IsNullOrEmpty(PictureFile.FileName)))
                {
                    byte[] categoryPictureBinary = PictureManager.GetPictureBits(PictureFile.InputStream, PictureFile.ContentLength);
                    if (pic != null)
                        pic = PictureManager.UpdatePicture(pic.PictureId, categoryPictureBinary, PictureFile.ContentType, true);
                    else
                        pic = PictureManager.InsertPicture(categoryPictureBinary, PictureFile.ContentType, true);
                }
                int PictureId = 0;
                if (pic != null)
                    PictureId = pic.PictureId;

                email.Description = this.txtDescription.Content;
                email.EmailAddress = txtEmailAddress.Text;
                email.FirstName = txtFirstName.Text;
                email.LastName = txtLastName.Text;
                email.PhoneNumber = txtPhoneNumber.Text;
                email.PictureID = PictureId;
                email.JobTitle = txtJobTitle.Text;
                bool b = emailbiz.SaveEmail(email);
                BindData();
                return b;
            }
            else
            {
                Picture pic = null;
                HttpPostedFile PictureFile = fuPicture.PostedFile;
                if ((PictureFile != null) && (!String.IsNullOrEmpty(PictureFile.FileName)))
                {
                    byte[] PictureBinary = PictureManager.GetPictureBits(PictureFile.InputStream, PictureFile.ContentLength);
                    pic = PictureManager.InsertPicture(PictureBinary, PictureFile.ContentType, true);
                }
                int PictureId = 0;
                if (pic != null)
                    PictureId = pic.PictureId;
                Nop_EmailDirectory newemail = new Nop_EmailDirectory();

                newemail.Description = this.txtDescription.Content;
                newemail.EmailAddress = txtEmailAddress.Text;
                newemail.FirstName = txtFirstName.Text;
                newemail.LastName = txtLastName.Text;
                newemail.PhoneNumber = txtPhoneNumber.Text;
                newemail.PictureID = PictureId;
                newemail.JobTitle = txtJobTitle.Text;
                bool b = emailbiz.SaveEmail(newemail);

                Response.Redirect("EmailDirectory.aspx");
                return b;
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            save();
            
        }

        protected void btnRemoveImage_Click(object sender, EventArgs e)
        {
            Nop_EmailDirectory email = null;
            int emailid = 0;
            if (Request.QueryString["emailid"] != null && int.TryParse(Request.QueryString["emailid"], out emailid))
            {
                email = emailbiz.GetEmailByID(emailid);
            }
            if (email != null)
            {
                PictureManager.DeletePicture(email.PictureID.Value);
                email.PictureID = 0;
                emailbiz.SaveEmail(email);
                BindData();
            }
        }
    }
}