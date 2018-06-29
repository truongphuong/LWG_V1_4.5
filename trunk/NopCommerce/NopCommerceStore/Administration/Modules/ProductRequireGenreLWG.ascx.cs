using System;
using System.Collections;
using System.Collections.Generic;
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
using NopSolutions.NopCommerce.BusinessLogic.Categories;
using NopSolutions.NopCommerce.BusinessLogic.Manufacturers;
using NopSolutions.NopCommerce.BusinessLogic.Media;
using NopSolutions.NopCommerce.BusinessLogic.Products;
using NopSolutions.NopCommerce.BusinessLogic.Promo.Discounts;
using NopSolutions.NopCommerce.BusinessLogic.Tax;
using NopSolutions.NopCommerce.BusinessLogic.Templates;
using NopSolutions.NopCommerce.Common.Utils;
using NopSolutions.NopCommerce.BusinessLogic.Warehouses;
using NopSolutions.NopCommerce.Web.Administration.Modules;
using System.Xml.Linq;
using System.Linq;
using LWG.Business;
using LWG.Core.Models;

namespace NopSolutions.NopCommerce.Web.Administration.Modules
{
    public partial class ProductRequireGenreLWGControl : BaseNopAdministrationUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindingGenre();
            } 
        }

        protected void rptGenre_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            GenerBiz pBiz = new GenerBiz();
            lwg_Genre p = pBiz.GetByID(int.Parse(e.CommandArgument.ToString()));
            if (e.CommandName.Equals("EDIT"))
            {
                if (p != null)
                {
                    btnAdd.Text = "Update";
                    txtTitle.Text = "Update Genre";
                    hdfID.Value = e.CommandArgument.ToString();
                    pnEditGenre.Visible = true;
                    pnListGenre.Visible = false;
                    txtName.Text = p.Name;
                }
            }
            else if (e.CommandName.Equals("DELETE"))
            {
                if (p != null)
                {
                    if (pBiz.DeleteGenre(p))
                    {
                        BindingGenre();
                    }
                }
            }  
        }
        private void BindingGenre()
        {
            GenerBiz pBiz = new GenerBiz();
            rptGenre.DataSource = pBiz.GetListGenre();
            rptGenre.DataBind();
        }               

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            lblNote.Visible = false;
            txtName.Text = string.Empty;
            btnAdd.Text = "Add";
            txtTitle.Text = "Add Genre";
            pnEditGenre.Visible = true;
            pnListGenre.Visible = false;
            hdfID.Value = string.Empty;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            GenerBiz pBiz = new GenerBiz();
            lwg_Genre p;
            if (string.IsNullOrEmpty(hdfID.Value))
            {
                p = new lwg_Genre();
                lblNote.Text = "Insert error, please try again";
            }
            else
            {
                p = pBiz.GetByID(int.Parse(hdfID.Value));
                lblNote.Text = "Update error, please try again";
            }
            if (p != null)
            {
                p.Name = txtName.Text;
                if (pBiz.SaveGenre(p))
                {
                    BindingGenre();
                    txtName.Text = string.Empty;
                    pnEditGenre.Visible = false;
                    pnListGenre.Visible = true;
                    return;
                }
            }
            lblNote.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            pnEditGenre.Visible = false;
            pnListGenre.Visible = true;
        }
    }
}