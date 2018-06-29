using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LWG.Core.Models;
using LWG.Business;

namespace NopSolutions.NopCommerce.Web.Modules
{
    public partial class License_Form : System.Web.UI.UserControl
    {
        public LicenseType Type { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.pnForm.Visible = true;
                this.pnMessage.Visible = false;
            }

            this.lnkBack.NavigateUrl = Request.Url.AbsoluteUri;
        }

        protected void imbSubmit_Click(object sender, ImageClickEventArgs e)
        {
            LicenseBiz lService = new LicenseBiz();
            lwg_LicenseForm license = new lwg_LicenseForm();

            license.Name = this.txtName.Text;
            license.Email = this.txtEmail.Text;
            license.Phone = this.txtPhone.Text;
            license.Address = this.txtAddress.Text;
            license.City = this.txtCity.Text;
            license.State = this.jumpMenu.Value;
            license.Zipcode = this.txtZipcode.Text;
            license.LicenseType = (int)this.Type;

            if (lService.InsertLicense(license) == true)
            {
                this.ltrMessage.Text = "Your license is submitted successfully.";
            }
            else
            {
                this.ltrMessage.Text = "Your license is not submitted successfully. Please try again.";
            }
            this.pnForm.Visible = false;
            this.pnMessage.Visible = true;
        }
    }
}