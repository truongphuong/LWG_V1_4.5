﻿using System;
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
    public partial class ProductRequirePeriodControl : BaseNopAdministrationUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindingPeriod();
            }
        }

        private void BindingPeriod()
        {
            PeriodBiz pBiz = new PeriodBiz();
            rptPeriod.DataSource = pBiz.GetListPeriod();
            rptPeriod.DataBind();
        }

        protected void rptPeriod_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            PeriodBiz pBiz = new PeriodBiz();
            lwg_Period p = pBiz.GetByID(int.Parse(e.CommandArgument.ToString()));
            if (e.CommandName.Equals("EDIT"))
            {
                if (p != null)
                {
                    btnAdd.Text = "Update";
                    txtTitle.Text = "Update Period";
                    hdfID.Value = e.CommandArgument.ToString();
                    pnEditPeriod.Visible = true;
                    pnListPeriods.Visible = false;
                    txtName.Text = p.Name;
                }
            }
            else if (e.CommandName.Equals("DELETE"))
            {
                if (p != null)
                {
                    if (pBiz.DeletePeriod(p))
                    {
                        BindingPeriod();
                    }
                }
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            lblNote.Visible = false;
            txtName.Text = string.Empty;
            btnAdd.Text = "Add";
            txtTitle.Text = "Add Period";
            pnEditPeriod.Visible = true;
            pnListPeriods.Visible = false;
            hdfID.Value = string.Empty;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            PeriodBiz pBiz = new PeriodBiz();
            lwg_Period p;
            if (string.IsNullOrEmpty(hdfID.Value))
            {
                p = new lwg_Period();
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
                if (pBiz.SavePeriod(p))
                {
                    rptPeriod.DataSource = pBiz.GetListPeriod();
                    rptPeriod.DataBind();
                    txtName.Text = string.Empty;
                    pnEditPeriod.Visible = false;
                    pnListPeriods.Visible = true;
                    return;
                }
            }
            lblNote.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            pnEditPeriod.Visible = false;
            pnListPeriods.Visible = true;
        }
    }
}