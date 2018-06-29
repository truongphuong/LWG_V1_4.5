using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NopSolutions.NopCommerce.BusinessLogic;
using NopSolutions.NopCommerce.BusinessLogic.Localization;
using NopSolutions.NopCommerce.BusinessLogic.Payment;
using NopSolutions.NopCommerce.BusinessLogic.SEO;
using NopSolutions.NopCommerce.BusinessLogic.Media;
using NopSolutions.NopCommerce.Common.Utils;
using LWG.Business;
using LWG.Core.Models;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Text; 
using System.Web.Caching;
using System.Web.Security;
using NopSolutions.NopCommerce.BusinessLogic.Configuration.Settings;

namespace NopSolutions.NopCommerce.Web
{
    public partial class ComposerDetailsPage : BaseNopPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string title = GetLocaleResourceString("PageTitle.ComposerDetailsPage");
            SEOHelper.RenderTitle(this, title, true);
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ComposerID"]))
                {
                    string PId = Request.QueryString["ComposerID"].ToString();

                    long PersonId = 0;

                    if (long.TryParse(PId, out PersonId))
                    {
                        try
                        {
                            PersonBiz pb = new PersonBiz();
                            lwg_Person person = pb.GetByID(PersonId);

                            if (person != null)
                            {
                                this.litName.Text = person.NameDisplay;
                                this.lblName.Text = person.NameDisplay;

                                this.Literal1.Text = "About " + person.NameDisplay;

                                if (!String.IsNullOrEmpty(person.Biography))
                                    this.Literal2.Text = Custring(person.Biography);

                                if (person.PictureID.HasValue)
                                {
                                    if (person.PictureID.Value > 0)
                                    {
                                        Picture Picture = PictureManager.GetPictureById(person.PictureID.Value);
                                        string pictureUrl = PictureManager.GetPictureUrl(Picture, 150);
                                        this.iPicture.Visible = true;
                                        this.iPicture.ImageUrl = pictureUrl;
                                    }
                                }
                                else
                                {
                                    iPicture.ImageUrl = PictureManager.GetDefaultPictureUrl(SettingManager.GetSettingValueInteger("Media.Product.DetailImageSize", 150));
                                }
                            }
                            else
                            {
                                Response.Write("This composer doesn't exist.");
                            }

                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex.Message);
                        }
                        return;
                    }
                }

                // Invalid Person ID. Go to Composers page or 404 page.
                Response.Redirect("~/MeetComposers.aspx");

            }
        }

        public string Custring(object s)
        {
            HtmlGenericControl h = new HtmlGenericControl();
            h.InnerHtml = Server.HtmlDecode(s.ToString());
            return h.InnerText;
        }


        public override PageSslProtectionEnum SslProtected
        {
            get
            {
                return PageSslProtectionEnum.No;
            }
        }
    }
}
