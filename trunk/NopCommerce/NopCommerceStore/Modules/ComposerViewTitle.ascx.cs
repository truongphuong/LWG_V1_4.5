using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LWG.Business;
using NopSolutions.NopCommerce.BusinessLogic.Products;



namespace NopSolutions.NopCommerce.Web.Modules
{
    public partial class ComposerViewTitle : BaseNopUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindData();
            }
        }
        protected void BindData()
        {
            string PId = Request.QueryString["ComposerID"].ToString();
            PersonBiz personBiz = new PersonBiz();
            Int32 personID;
            if (Int32.TryParse(PId, out personID))
            {
                var productCollection = personBiz.GetAllProductWithComposerId(personID);
                dlViewTitle.DataSource = productCollection;
                dlViewTitle.DataBind();
            }
            else 
                Response.Redirect("~/MeetComposers.aspx");
        }
                
    }
}