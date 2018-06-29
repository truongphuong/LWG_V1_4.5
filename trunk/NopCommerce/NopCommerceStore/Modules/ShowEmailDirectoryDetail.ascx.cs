using System;
using NopSolutions.NopCommerce.BusinessLogic.Media;
using LWG.Business;
using LWG.Core.Models;

namespace NopSolutions.NopCommerce.Web.Modules
{
    public partial class ShowEmailDirectoryDetail : System.Web.UI.UserControl
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
            int emailid = 0;
            Nop_EmailDirectory email = null;
            if (Request.QueryString["emailid"] != null && int.TryParse(Request.QueryString["emailid"], out emailid))
            {
                email = emailbiz.GetEmailByID(emailid);
            }
            if (email != null)
            {
                lblDescrption.Text= email.Description;
                lblEmailAddress.Text = email.EmailAddress;
                lblname1.Text = email.FirstName;
                lblName.Text = email.FirstName + " " + email.LastName;
                lblName2.Text = email.FirstName + " " + email.LastName;
                //txtJobTitle.Text = email.JobTitle; 
                //txtPhoneNumber.Text = email.PhoneNumber;
                this.lblJobTitle.Text = email.JobTitle;
                this.lblPhone.Text = email.PhoneNumber;

                Picture Picture = PictureManager.GetPictureById(email.PictureID.Value);
                this.iEmail.Visible = Picture != null;
                string pictureUrl = PictureManager.GetPictureUrl(Picture, 100);
                this.iEmail.ImageUrl = pictureUrl;
            }
        }
    }
}