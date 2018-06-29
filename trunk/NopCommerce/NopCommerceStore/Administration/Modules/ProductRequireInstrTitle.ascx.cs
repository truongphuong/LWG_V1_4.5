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
    public partial class ProductRequireInstrTitleControl : BaseNopAdministrationUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindingInstrTitle();
                pnListInstrTitle.Visible = true;
                pnEditInstrTitle.Visible = false;
            } 
        }               

        #region InstrTitle

        protected void rptListrInstrTitle_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                lwg_InstrTitle lwg = (lwg_InstrTitle)e.Item.DataItem;
                Literal ltrTitleType = (Literal)e.Item.FindControl("ltrTitleType");
                ltrTitleType.Text = lwg.lwg_TitleType.Name;
            }
        }

        protected void btnAddInstrTitle_Click(object sender, EventArgs e)
        {
            lblNoteAddeditInstrTitle.Visible = false;
            txtInstrTitleName.Text = string.Empty;
            btnAddEditInstrTitle.Text = "Add";
            lblTitleInstrTitle.Text = "Add InstrTitle";
            pnListInstrTitle.Visible = false;
            pnEditInstrTitle.Visible = true;
            HiddenField1.Value = string.Empty;
        }

        //protected void lnkbtnTitleTypeManage_Click(object sender, EventArgs e)
        //{
        //    BindingTitleType();
        //    pnListTitleType.Visible = true;
        //    pnEditTitleType.Visible = false;
        //    divInstrTitle.Attributes.Add("style", "display: none;");
        //    divTitleType.Attributes.Add("style", "display: block;");
        //}

        protected void rptListrInstrTitle_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            CatalogTitleTypeBiz pBiz = new CatalogTitleTypeBiz();
            lwg_InstrTitle p = pBiz.GetInstrTitleByID(int.Parse(e.CommandArgument.ToString()));
            if (e.CommandName.Equals("EDIT"))
            {
                if (p != null)
                {
                    btnAddEditInstrTitle.Text = "Update";
                    lblTitleInstrTitle.Text = "Update InstrTitle";
                    HiddenField1.Value = e.CommandArgument.ToString();
                    pnEditInstrTitle.Visible = true;
                    pnListInstrTitle.Visible = false;
                    txtInstrTitleName.Text = p.Name;
                    if (drpTitleType.Items.Count > 0)
                    {
                        drpTitleType.SelectedValue = p.TitleTypeId.ToString();
                    }
                }
            }
            else if (e.CommandName.Equals("DELETE"))
            {
                if (p != null)
                {
                    if (pBiz.DeleteInstrTitle(p))
                    {
                        BindingInstrTitle();
                    }
                }
            }
        }

        protected void btnAddEditInstrTitle_Click(object sender, EventArgs e)
        {
            CatalogTitleTypeBiz pBiz = new CatalogTitleTypeBiz();
            lwg_InstrTitle p;
            if (string.IsNullOrEmpty(HiddenField1.Value))
            {
                p = new lwg_InstrTitle();
                lblNoteAddeditInstrTitle.Text = "Insert error, please try again";
            }
            else
            {
                p = pBiz.GetInstrTitleByID(int.Parse(HiddenField1.Value));
                lblNoteAddeditInstrTitle.Text = "Update error, please try again";
            }
            if (p != null)
            {
                p.Name = txtInstrTitleName.Text;
                if (drpTitleType.Items.Count > 0)
                {
                    p.TitleTypeId = int.Parse(drpTitleType.SelectedValue);
                }
                if (pBiz.SaveInstrTitle(p))
                {
                    BindingInstrTitle();
                    txtInstrTitleName.Text = string.Empty;
                    pnEditInstrTitle.Visible = false;
                    pnListInstrTitle.Visible = true;
                    return;
                }
            }
            lblNoteAddeditInstrTitle.Visible = true;
        }

        protected void btnCancelAddEditInstrTitle_Click(object sender, EventArgs e)
        {
            pnListInstrTitle.Visible = true;
            pnEditInstrTitle.Visible = false;
            BindingInstrTitle();
        }
        private void BindingInstrTitle()
        {
            CatalogTitleTypeBiz cBiz = new CatalogTitleTypeBiz();
            rptListrInstrTitle.DataSource = cBiz.GetListInstrTitle();
            rptListrInstrTitle.DataBind();
            drpTitleType.DataSource = cBiz.GetListTitleType();
            drpTitleType.DataBind();
        }
        #endregion
    }
}