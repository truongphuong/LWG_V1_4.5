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
using NopSolutions.NopCommerce.Common.Utils;

namespace NopSolutions.NopCommerce.Web.Administration.Modules
{
    public partial class CatalogComposerControl : BaseNopAdministrationUserControl
    {
        public int ProductId
        {
            get
            {
                return CommonHelper.QueryStringInt("ProductId");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ProductId == 0)
            {
                pnlContent.Visible = false;
                pnlMessage.Visible = true;
            }
            else
            {
                pnlContent.Visible = true;
                pnlMessage.Visible = false;
            }
            if (!IsPostBack)
            {
                InitData();
                ltrMessageNote.Visible = false;
            }
        }
        private void InitData()
        {
            RoleBiz rBiz = new RoleBiz();
            PersonBiz pBiz = new PersonBiz();
            ddlPeople.Items.Clear();
            //ddlPeople.DataSource = pBiz.GetListPerson(txtFirstName.Text.TrimStart().TrimEnd(), txtLastName.Text.TrimStart().TrimEnd());
            //ddlPeople.DataBind();
            ddlRole.DataSource = rBiz.GetListRole();
            ddlRole.DataBind();
            BindingCatalogRole();
        }

        private void BindingCatalogRole()
        {
            PersonBiz pBiz = new PersonBiz();
            gvComposers.DataSource = pBiz.GetListPersonInRoleByCatalogID(ProductId);
            gvComposers.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ddlPeople.Items.Clear();
            PersonBiz pBiz = new PersonBiz();
            ddlPeople.DataSource = pBiz.GetListPerson(txtFirstName.Text.TrimStart().TrimEnd(), txtLastName.Text.TrimStart().TrimEnd());
            ddlPeople.DataBind();
        }

        protected void btnAddPeopleRoleCatalog_Click(object sender, EventArgs e)
        {
            PersonBiz pBiz = new PersonBiz();
            lwg_PersonInRole lg = new lwg_PersonInRole();
            CatalogBiz cBiz = new CatalogBiz();
            if (cBiz.GetByID(ProductId) != null)
            {
                if (ddlPeople.Items.Count > 0)
                {
                    lg.CatalogId = ProductId;
                    lg.PersonId = int.Parse(ddlPeople.SelectedValue);
                    lg.RoleId = int.Parse(ddlRole.SelectedValue);
                    if (pBiz.SavePersonInRole(lg))
                    {
                        BindingCatalogRole();
                    }
                }
                ltrMessageNote.Visible = false;
            }
            else
            {
                ltrMessageNote.Visible = true;
            }
        }

        protected void gvComposers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("REMOVE"))
            {
                PersonBiz pBiz = new PersonBiz();
                int id = int.Parse(e.CommandArgument.ToString());
                if (pBiz.DeletePersonInRole(id))
                {
                    BindingCatalogRole();
                }
            }
        }

        protected void gvComposers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem == null)
            {
                return;
            }
            lwg_PersonInRole lg = (lwg_PersonInRole)e.Row.DataItem;
            if (lg != null)
            {
                Literal ltrNamePeople = (Literal)e.Row.FindControl("ltrNamePeople");
                ltrNamePeople.Text = lg.lwg_Person.NameDisplay;
                Literal ltrNameRole = (Literal)e.Row.FindControl("ltrNameRole");
                ltrNameRole.Text = lg.lwg_Role.Name;

                LinkButton lnkbtnRemove = (LinkButton)e.Row.FindControl("lnkbtnRemove");
                lnkbtnRemove.CommandArgument = lg.Id.ToString();
            }
        }



    }
}