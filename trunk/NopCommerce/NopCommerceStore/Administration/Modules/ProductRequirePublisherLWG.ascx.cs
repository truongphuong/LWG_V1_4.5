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
    public partial class ProductRequirePublisherLWGControl : BaseNopAdministrationUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindingPublisher();
            } 
        }

        protected void rptPublisher_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            PublisherBiz pBiz = new PublisherBiz();
            lwg_Publisher p = pBiz.GetByID(int.Parse(e.CommandArgument.ToString()));
            if (e.CommandName.Equals("EDIT"))
            {
                if (p != null)
                {
                    btnAdd.Text = "Update";
                    txtTitle.Text = "Update Publisher";
                    hdfID.Value = e.CommandArgument.ToString();
                    pnEditPublisher.Visible = true;
                    pnListPublisher.Visible = false;
                    txtName.Text = p.Name;
                }
            }
            else if (e.CommandName.Equals("DELETE"))
            {
                if (p != null)
                {
                    if (pBiz.DeletePublisher(p))
                    {
                        BindingPublisher();
                    }
                }
            } 
        }

        private void BindingPublisher()
        {
            PublisherBiz pBiz = new PublisherBiz();
            rptPublisher.DataSource = pBiz.GetListPublisher();
            rptPublisher.DataBind();
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            lblNote.Visible = false;
            txtName.Text = string.Empty;
            btnAdd.Text = "Add";
            txtTitle.Text = "Add Publiser";
            pnEditPublisher.Visible = true;
            pnListPublisher.Visible = false;
            hdfID.Value = string.Empty;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            PublisherBiz pBiz = new PublisherBiz();
            lwg_Publisher p;
            if (string.IsNullOrEmpty(hdfID.Value))
            {
                p = new lwg_Publisher();
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
                if (pBiz.SavePublisher(p))
                {
                    BindingPublisher();
                    txtName.Text = string.Empty;
                    pnEditPublisher.Visible = false;
                    pnListPublisher.Visible = true;
                    return;
                }
            }
            lblNote.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            pnEditPublisher.Visible = false;
            pnListPublisher.Visible = true;
        }
    }
}