using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using NopSolutions.NopCommerce.BusinessLogic.Media;
using NopSolutions.NopCommerce.Common.Utils;
using LWG.Business;
using LWG.Core.Models;

namespace NopSolutions.NopCommerce.Web.Administration.Modules
{
    public partial class ComposerInfoControl : BaseNopAdministrationUserControl
    {
        private void BindData()
        {
            PersonBiz pBiz = new PersonBiz();
            lwg_Person person = pBiz.GetByID(this.ComposerId);

            if (person != null)
            {
                txtDOB.Text = person.DOB;
                txtDOD.Text = person.DOD;
                txtFirstName.Text = (String)person.FirstName;
                txtLastName.Text = (String)person.LastName;
                txtNameDisplay.Text = (String)person.NameDisplay;
                txtNameList.Text = (String)person.NameList;
                txtNameSort.Text = (String)person.NameSort;
                txtBiography.Content = Server.HtmlDecode(person.Biography);

                if (person.PictureID.HasValue)
                {
                    if (person.PictureID.Value > 0)
                    {
                        Picture Picture = PictureManager.GetPictureById(person.PictureID.Value);
                        this.btnRemoveImage.Visible = Picture != null;
                        string pictureUrl = PictureManager.GetPictureUrl(Picture, 100);
                        this.iPicture.Visible = true;
                        this.iPicture.ImageUrl = pictureUrl;
                    }
                }

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.BindData();
            }
        }

        public string SaveInfo()
        {
            PersonBiz pBiz = new PersonBiz();

            lwg_Person person = pBiz.GetByID(this.ComposerId);

            Picture pic = null;

            if (person == null)
            {
                person = new lwg_Person();
            }
            else
            {
                if (person.PictureID.HasValue)
                {
                    if (person.PictureID.Value > 0)
                        pic = PictureManager.GetPictureById(person.PictureID.Value);
                }
            }

            HttpPostedFile PictureFile = fuPicture.PostedFile;
            if ((PictureFile != null) && (!String.IsNullOrEmpty(PictureFile.FileName)))
            {
                byte[] pictureBinary = PictureManager.GetPictureBits(PictureFile.InputStream, PictureFile.ContentLength);
                if (pic != null)
                    pic = PictureManager.UpdatePicture(pic.PictureId, pictureBinary, PictureFile.ContentType, true);
                else
                    pic = PictureManager.InsertPicture(pictureBinary, PictureFile.ContentType, true);
            }
            int PictureId = 0;
            if (pic != null)
                PictureId = pic.PictureId;

            person.Biography = Server.HtmlEncode(txtBiography.Content);

            if (txtDOB.Text.Trim() != person.DOB)
            {
                person.DOB = txtDOB.Text.Trim();
            }

            if (txtDOD.Text.Trim() != person.DOD)
            {
                person.DOD = txtDOD.Text.Trim();
            }
            string lastName = txtLastName.Text.Trim();
            person.FirstLetter = lastName.Length > 0 ? lastName.Substring(0, 1).ToUpper() : string.Empty;
            person.FirstName = txtFirstName.Text.Trim();
            person.LastName = lastName;
            person.NameDisplay = txtNameDisplay.Text.Trim();
            person.NameList = txtNameList.Text.Trim();
            person.NameSort = txtNameSort.Text.Trim();
            person.PictureID = PictureId;

            pBiz.SavePerson(person);

            return person.PersonId.ToString();
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                PersonBiz pBiz = new PersonBiz();
                pBiz.DeletePerson(this.ComposerId);

                Response.Redirect("Composers.aspx");
            }
            catch (Exception exc)
            {
                ProcessException(exc);
            }
        }


        protected void btnRemoveImage_Click(object sender, EventArgs e)
        {
            lwg_Person person = null;
            PersonBiz pbiz = new PersonBiz();

            person = pbiz.GetByID(this.ComposerId);
            if (person != null)
            {
                PictureManager.DeletePicture(person.PictureID.Value);
                person.PictureID = 0;
                pbiz.SavePerson(person);
                btnRemoveImage.Visible = false;
                BindData();
            }


        }

        public long ComposerId
        {
            get
            {
                return long.Parse(CommonHelper.QueryStringInt("ComposerID").ToString());
            }
        }

    }
}