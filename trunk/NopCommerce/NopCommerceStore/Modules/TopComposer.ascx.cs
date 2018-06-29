using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using LWG.Core.Models;
using LWG.Business;
using System.Collections.Generic;

namespace NopSolutions.NopCommerce.Web.Modules
{
    public partial class TopComposerControl : BaseNopUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void dtlTopComposer_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                lwg_Person obj = (lwg_Person)e.Item.DataItem;
                if (obj != null)
                {
                    Label lblNumber = (Label)e.Item.FindControl("lblNumber");
                    lblNumber.Text = (e.Item.ItemIndex + 1).ToString();

                    HyperLink lblName = (HyperLink)e.Item.FindControl("lblName");
                    lblName.Text = obj.NameDisplay;
                    lblName.NavigateUrl = string.Format("~/ComposerDetails.aspx?ComposerID={0}",obj.PersonId);

                    PersonBiz pBiz = new PersonBiz();
                    Label lblProductNumber = (Label)e.Item.FindControl("lblProductNumber");
                    lblProductNumber.Text = pBiz.CountTotalProductWithComposerRole(obj.PersonId).ToString();
                }
            } 
        }

        private void BindData()
        {
            PersonBiz pBiz = new PersonBiz();
            List<lwg_Person> lst = pBiz.GetTopComposer(20);
            dtlTopComposer.DataSource = lst;
            dtlTopComposer.DataBind();
        }                 
    }
}