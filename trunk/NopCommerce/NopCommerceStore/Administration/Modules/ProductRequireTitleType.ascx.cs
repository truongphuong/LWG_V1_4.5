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
    public partial class ProductRequireTitleTypeControl : BaseNopAdministrationUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindingTitleType();
            }
        }       

        #region TitleType
        protected void rptTitleType_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            CatalogTitleTypeBiz pBiz = new CatalogTitleTypeBiz();
            lwg_TitleType p = pBiz.GetTitleTypeByID(int.Parse(e.CommandArgument.ToString()));
            if (e.CommandName.Equals("EDIT"))
            {
                if (p != null)
                {
                    btnAdd.Text = "Update";
                    txtTitle.Text = "Update TitleType";
                    hdfID.Value = e.CommandArgument.ToString();
                    pnEditTitleType.Visible = true;
                    pnListTitleType.Visible = false;
                    txtName.Text = p.Name;
                }
            }
            else if (e.CommandName.Equals("DELETE"))
            {
                if (p != null)
                {
                    if (pBiz.DeleteTitleType(p))
                    {
                        BindingTitleType();
                    }
                }
            }
        }

        private void BindingTitleType()
        {
            CatalogTitleTypeBiz pBiz = new CatalogTitleTypeBiz();
            rptTitleType.DataSource = pBiz.GetListTitleType();
            rptTitleType.DataBind();
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            lblNote.Visible = false;
            txtName.Text = string.Empty;
            btnAdd.Text = "Add";
            txtTitle.Text = "Add TitleType";
            pnEditTitleType.Visible = true;
            pnListTitleType.Visible = false;
            hdfID.Value = string.Empty;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            CatalogTitleTypeBiz pBiz = new CatalogTitleTypeBiz();
            lwg_TitleType p;
            if (string.IsNullOrEmpty(hdfID.Value))
            {
                p = new lwg_TitleType();
                lblNote.Text = "Insert error, please try again";
            }
            else
            {
                p = pBiz.GetTitleTypeByID(int.Parse(hdfID.Value));
                lblNote.Text = "Update error, please try again";
            }
            if (p != null)
            {
                p.Name = txtName.Text;
                if (pBiz.SaveTitleType(p))
                {
                    BindingTitleType();
                    txtName.Text = string.Empty;
                    pnEditTitleType.Visible = false;
                    pnListTitleType.Visible = true;
                    return;
                }
            }
            lblNote.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            pnEditTitleType.Visible = false;
            pnListTitleType.Visible = true;
        }

        //protected void lnkbtnInstrTitle_Click(object sender, EventArgs e)
        //{
        //    BindingInstrTitle();
        //    pnListInstrTitle.Visible = true;
        //    pnEditInstrTitle.Visible = false;
        //    divInstrTitle.Attributes.Add("style", "display: block;");
        //    divTitleType.Attributes.Add("style", "display: none;");
        //}
        #endregion
    }
}