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
    public partial class ProductRequireInstrumentalLWGControl : BaseNopAdministrationUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindingInstrumental();
            } 
        }

        private void BindingInstrumental()
        {
            InstrumentalBiz pBiz = new InstrumentalBiz();
            rptInstrumental.DataSource = pBiz.GetListInstrumental();
            rptInstrumental.DataBind();
        }

        protected void rptInstrumental_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            InstrumentalBiz pBiz = new InstrumentalBiz();
            lwg_Instrumental p = pBiz.GetByID(int.Parse(e.CommandArgument.ToString()));
            if (e.CommandName.Equals("EDIT"))
            {
                if (p != null)
                {
                    btnAdd.Text = "Update";
                    txtTitle.Text = "Update Instrumental";
                    hdfID.Value = e.CommandArgument.ToString();
                    pnEditInstrumental.Visible = true;
                    pnListInstrumental.Visible = false;
                    txtShortName.Text = p.ShortName;
                    txtLongName.Text = p.LongName;
                }
            }
            else if (e.CommandName.Equals("DELETE"))
            {
                if (p != null)
                {
                    if (pBiz.DeleteInstrumental(p))
                    {
                        BindingInstrumental();
                    }
                }
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            lblNote.Visible = false;
            txtShortName.Text = string.Empty;
            txtLongName.Text = string.Empty;
            btnAdd.Text = "Add";
            txtTitle.Text = "Add Instrumental";
            pnEditInstrumental.Visible = true;
            pnListInstrumental.Visible = false;
            hdfID.Value = string.Empty;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            InstrumentalBiz pBiz = new InstrumentalBiz();
            lwg_Instrumental p;
            if (string.IsNullOrEmpty(hdfID.Value))
            {
                p = new lwg_Instrumental();
                lblNote.Text = "Insert error, please try again";
            }
            else
            {
                p = pBiz.GetByID(int.Parse(hdfID.Value));
                lblNote.Text = "Update error, please try again";
            }
            if (p != null)
            {
                p.ShortName = txtShortName.Text;
                p.LongName = txtLongName.Text;
                if (pBiz.SaveInstrumental(p))
                {
                    rptInstrumental.DataSource = pBiz.GetListInstrumental();
                    rptInstrumental.DataBind();
                    txtLongName.Text = string.Empty;
                    txtShortName.Text = string.Empty;
                    pnEditInstrumental.Visible = false;
                    pnListInstrumental.Visible = true;
                    return;
                }
            }
            lblNote.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtLongName.Text = string.Empty;
            txtShortName.Text = string.Empty;
            pnEditInstrumental.Visible = false;
            pnListInstrumental.Visible = true;
        }
    }
}