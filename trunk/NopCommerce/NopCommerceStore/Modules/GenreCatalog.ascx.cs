using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using LWG.Core.Models;
using LWG.Business;


namespace NopSolutions.NopCommerce.Web.Modules
{
    public partial class GenreCatalog : BaseNopUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack) 
            {
                this.BindData();
            }
        }

        private void BindData()
        {
            GenerBiz genreService = new GenerBiz();
            List<lwg_Genre> listGenre = genreService.GetListGenre();

            this.dlGenre.DataSource = listGenre;
            this.dlGenre.DataBind();
        }

        protected void dlGenre_Bound(object sender, DataListItemEventArgs e) 
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item) 
            {
                lwg_Genre obj = (lwg_Genre)e.Item.DataItem;
                Label lbl = (Label)e.Item.FindControl("lblNumber");
                lbl.Text = (e.Item.ItemIndex + 1).ToString();

                lbl = (Label)e.Item.FindControl("lblName");
                lbl.Text = obj.Name;

                CatalogBiz cService = new CatalogBiz();
                lbl = (Label)e.Item.FindControl("lblProductNumber");
                lbl.Text = cService.GetTotalCatalogOfGenre(obj.GerneId).ToString();

            }
        }
    }
}