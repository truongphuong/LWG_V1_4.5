using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LWG.Business;
using LWG.Core.Models;
using NopSolutions.NopCommerce.BusinessLogic.Categories;
using System.Text;
using NopSolutions.NopCommerce.BusinessLogic.Products;
using NopSolutions.NopCommerce.BusinessLogic.SEO;
using NopSolutions.NopCommerce.DataAccess.Products;

using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Caching;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using NopSolutions.NopCommerce.BusinessLogic;
using NopSolutions.NopCommerce.BusinessLogic.Localization;
using NopSolutions.NopCommerce.BusinessLogic.Payment;
using NopSolutions.NopCommerce.Common.Utils;


namespace NopSolutions.NopCommerce.Web
{
    public partial class advance_search : BaseNopPage
    {
        private int PageIndex
        {
            get
            {
                if (ViewState["_pageIndex"] == null)
                    return 0;
                return Convert.ToInt32(ViewState["_pageIndex"].ToString());
            }
            set
            {
                ViewState["_pageIndex"] = value;
            }
        }

        private string Query
        {
            get
            {
                if (ViewState["_query"] == null)
                    return string.Empty;
                return ViewState["_query"].ToString();
            }
            set
            {
                ViewState["_query"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string title = GetLocaleResourceString("PageTitle.advance_search");
                SEOHelper.RenderTitle(this, title, true);
                this.BindData();
                this.pnResult.Visible = false;
                this.pnSearchForm.Visible = true;
            }
        }

        private void BindData()
        {
            this.BindCategories();
            //this.BindCategory(); // old
            this.BindPeriod();
            this.BindGenre();
            this.BindSeries();
            this.BindPublisher();

            //this.BindInstrCategory(this.drpKeyboardTitles, TitleType.KEYBOARD);
            //this.BindInstrCategory(this.drpStringTitles, TitleType.STRING);
            //this.BindInstrCategory(this.drpWoodwindTitles, TitleType.WOODWIND);
            //this.BindInstrCategory(this.drpBrassTitles, TitleType.BRASS);
            //this.BindInstrCategory(this.drpPercussionTitles, TitleType.PERCUSSION);
            //this.BindInstrCategory(this.drpChamberTitles, TitleType.CHAMBER);
            //this.BindInstrCategory(this.drpLargeTitles, TitleType.LARGE);
            //this.BindInstrCategory(this.drpBandWindTitles, TitleType.BANDWIND);
            //this.BindInstrCategory(this.drpVocalChoralTitles, TitleType.VOCAL_CHORAL);
        }

        private void BindPublisher()
        {
            PublisherBiz pService = new PublisherBiz();
            List<lwg_Publisher> listPublisher = pService.GetListPublisher();
            if (listPublisher != null)
            {
                this.drpPublisher.DataSource = listPublisher;
                this.drpPublisher.DataTextField = "Name";
                this.drpPublisher.DataValueField = "PublisherId";
                this.drpPublisher.DataBind();
                this.drpPublisher.Items.Insert(0, new ListItem("-All Publishers -", "0"));
            }
        }

        private void BindSeries()
        {
            SeriesBiz sService = new SeriesBiz();
            List<lwg_Series> listSeries = sService.GetListSeries();
            if (listSeries != null)
            {
                this.drpSeries.DataSource = listSeries;
                this.drpSeries.DataTextField = "Name";
                this.drpSeries.DataValueField = "SeriesId";
                this.drpSeries.DataBind();
                this.drpSeries.Items.Insert(0, new ListItem("-All Series -", "0"));
            }
        }

        private void BindGenre()
        {
            GenerBiz gService = new GenerBiz();
            List<lwg_Genre> listGenre = gService.GetListGenre();
            if (listGenre != null)
            {
                this.drpGenre.DataSource = listGenre;
                this.drpGenre.DataTextField = "Name";
                this.drpGenre.DataValueField = "GerneId";
                this.drpGenre.DataBind();
                this.drpGenre.Items.Insert(0, new ListItem("-All Genres -", "0"));
            }
        }

        private void BindPeriod()
        {
            PeriodBiz pService = new PeriodBiz();
            List<lwg_Period> listPeriod = pService.GetListPeriod();
            if (listPeriod != null)
            {
                this.drpPeriodStyle.DataSource = listPeriod;
                this.drpPeriodStyle.DataTextField = "Name";
                this.drpPeriodStyle.DataValueField = "PeriodId";
                this.drpPeriodStyle.DataBind();
                this.drpPeriodStyle.Items.Insert(0, new ListItem("-All Period/Style-", "0"));
            }
        }

        #region add advance search the same search page
        protected void BindCategories()
        {
            drpCategory.Items.Clear();
            drpCategory.Items.Add(new ListItem(GetLocaleResourceString("Search.AllCategories"), "0"));
            BindCategories(0, "--");
        }

        public void BindCategories(int forParentEntityId, string prefix)
        {
            var categories = CategoryManager.GetAllCategories(forParentEntityId);

            foreach (var category in categories)
            {
                ListItem item = new ListItem(prefix + category.Name, category.CategoryId.ToString());
                this.drpCategory.Items.Add(item);
                if (CategoryManager.GetAllCategories(category.CategoryId).Count > 0)
                    BindCategories(category.CategoryId, prefix + "--");
            }

            if (drpCategory.Items.Count > 1)
            {
                this.drpCategory.DataBind();
            }
            else
            {
                drpCategory.Visible = false;
            }
        }
        #endregion
        //private void BindCategory()
        //{
        //    CategoryBiz cService = new CategoryBiz();
        //    List<Nop_Category> listCat = cService.GetAllParentCategory();
        //    if (listCat != null)
        //    {
        //        this.drpCategory.DataSource = listCat;
        //        this.drpCategory.DataTextField = "Name";
        //        this.drpCategory.DataValueField = "CategoryID";
        //        this.drpCategory.DataBind();
        //        this.drpCategory.Items.Insert(0, new ListItem("-All Categories-", "0"));
        //    }
        //}

        private void BindInstrCategory(DropDownList drp, TitleType type)
        {
            InstrTitleBiz iService = new InstrTitleBiz();
            List<lwg_InstrTitle> listTitle = iService.GetTitleByType(type);
            if (listTitle != null)
            {
                drp.DataSource = listTitle;
                drp.DataTextField = "Name";
                drp.DataValueField = "Id";
                drp.DataBind();
                drp.Items.Insert(0, new ListItem("-(Select)-", "0"));
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            StringBuilder selectClause = new StringBuilder();
            StringBuilder whereClause = new StringBuilder();

            //selectClause.AppendLine("SELECT c.* FROM lwg_Catalog c");
            selectClause.AppendLine("SELECT p.* FROM Nop_Product p INNER JOIN lwg_Catalog c ON p.ProductId = c.CatalogID");




            if (!string.IsNullOrEmpty(this.txtSku.Text))
            {
                selectClause.AppendLine("INNER JOIN Nop_ProductVariant pv ON p.ProductId = pv.ProductId");
                whereClause.AppendFormat("AND pv.SKU='{0}'", this.txtSku.Text.Trim().Replace("'", "''")).AppendLine();
            }
            if (!string.IsNullOrEmpty(this.txtComposer.Text))
            {
                selectClause.AppendLine("INNER JOIN lwg_PersonInRole cc ON c.CatalogID = cc.CatalogID");
                selectClause.AppendLine("INNER JOIN lwg_Person p1 ON cc.PersonID = p1.PersonID");

                whereClause.AppendFormat("AND (p1.FirstName LIKE '%{0}%'", this.txtComposer.Text.Trim().Replace("'", "''")).AppendLine();
                whereClause.AppendFormat("OR p1.LastName LIKE '%{0}%')", this.txtComposer.Text.Trim().Replace("'", "''")).AppendLine();
                whereClause.AppendFormat("AND cc.RoleId = {0}", LWGUtils.COMPOSER_ROLE_ID).AppendLine();
            }

            if (!string.IsNullOrEmpty(this.txtArranger.Text))
            {
                selectClause.AppendLine("INNER JOIN lwg_PersonInRole cp ON c.CatalogID = cp.CatalogID");
                selectClause.AppendLine("INNER JOIN lwg_Person p2 ON cp.PersonId = p2.PersonId");

                whereClause.AppendFormat("AND (p2.FirstName LIKE '%{0}%'", this.txtArranger.Text.Trim().Replace("'", "''")).AppendLine();
                whereClause.AppendFormat("OR p2.LastName LIKE '%{0}%')", this.txtArranger.Text.Trim().Replace("'", "''")).AppendLine();
            }

            if (!string.IsNullOrEmpty(this.txtTitle.Text))
            {
                if (!selectClause.ToString().Contains("Nop_ProductVariant"))
                    selectClause.AppendLine("LEFT OUTER JOIN Nop_ProductVariant pv ON p.ProductID = pv.ProductID");
                whereClause.AppendFormat("AND (c.TitleList LIKE '%{0}%'", this.txtTitle.Text.Trim().Replace("'", "''")).AppendLine();
                whereClause.AppendFormat("OR c.TableofContents LIKE '%{0}%'", this.txtTitle.Text.Trim().Replace("'", "''")).AppendLine();
                whereClause.AppendFormat("OR pv.ManufacturerPartNumber LIKE '%{0}%')", this.txtTitle.Text.Trim().Replace("'", "''")).AppendLine();
            }

            if (!string.IsNullOrEmpty(this.txtDuration.Text))
            {
                int duration;
                if (int.TryParse(this.txtDuration.Text, out duration))
                {
                    whereClause.Append("AND c.Duration ");
                    switch (this.drpDuration.SelectedValue)
                    {
                        case "-3":
                            whereClause.AppendFormat("<> '{0}'", duration).AppendLine();
                            break;
                        case "-2":
                            whereClause.AppendFormat("< '{0}'", duration).AppendLine();
                            break;
                        case "-1":
                            whereClause.AppendFormat("<= '{0}'", duration).AppendLine();
                            break;
                        case "0":
                            whereClause.AppendFormat("= '{0}'", duration).AppendLine();
                            break;
                        case "1":
                            whereClause.AppendFormat(">= '{0}'", duration).AppendLine();
                            break;
                        case "2":
                            whereClause.AppendFormat("> '{0}'", duration).AppendLine();
                            break;
                        default:
                            whereClause.AppendFormat("= '{0}'", duration).AppendLine();
                            break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(this.txtYear.Text))
            {
                whereClause.AppendFormat("AND c.Year like '%{0}%'", txtYear.Text.Trim().Replace("'", "''"));
            }

            if (!string.IsNullOrEmpty(this.txtGrade.Text))
            {
                int grade;
                if (int.TryParse(this.txtGrade.Text, out grade))
                {
                    whereClause.AppendFormat("AND c.Grade = '{0}'", grade).AppendLine();
                }
            }

            if (!string.IsNullOrEmpty(this.txtInstrumentation.Text))
            {
                if (!selectClause.ToString().Contains("Nop_ProductVariant"))
                    selectClause.AppendLine("LEFT OUTER JOIN Nop_ProductVariant pv ON p.ProductID = pv.ProductID");
                selectClause.AppendLine("LEFT OUTER JOIN Nop_ProductVariantLocalized pvl ON pv.ProductVariantID = pvl.ProductVariantID");
                selectClause.AppendLine("LEFT OUTER JOIN Nop_ProductLocalized pl  ON p.ProductID = pl.ProductID");
                string keyword = this.txtInstrumentation.Text.Trim().Replace("'", "''");
                whereClause.AppendFormat("AND (p.name like '%{0}%' ", keyword).AppendLine();
                whereClause.AppendFormat(" OR pv.ManufacturerPartNumber LIKE '%{0}%' ", keyword).AppendLine();
                whereClause.AppendFormat(" OR pv.name like '%{0}%' ", keyword).AppendLine();
                whereClause.AppendFormat(" OR pv.sku like '%{0}%' ", keyword).AppendLine();
                whereClause.AppendFormat(" OR c.tableofcontents like '%{0}%' ", keyword).AppendLine();
                whereClause.AppendFormat(" or pl.name like '%{0}%' ", keyword).AppendLine();
                whereClause.AppendFormat(" or pvl.name like '%{0}%' )", keyword).AppendLine();
            }

            int value;

            #region remove unused fields
            //value = int.Parse(this.drpKeyboardTitles.SelectedValue);
            //string instrTitleId = string.Empty;
            //if (value > 0)
            //{
            //    instrTitleId = instrTitleId + string.Format("{0},", value);
            //}

            //value = int.Parse(this.drpStringTitles.SelectedValue);
            //if (value > 0)
            //{
            //    instrTitleId = instrTitleId + string.Format("{0},", value);
            //}

            //value = int.Parse(this.drpWoodwindTitles.SelectedValue);
            //if (value > 0)
            //{
            //    instrTitleId = instrTitleId + string.Format("{0},", value);
            //}

            //value = int.Parse(this.drpBrassTitles.SelectedValue);
            //if (value > 0)
            //{
            //    instrTitleId = instrTitleId + string.Format("{0},", value);
            //}

            //value = int.Parse(this.drpPercussionTitles.SelectedValue);
            //if (value > 0)
            //{
            //    instrTitleId = instrTitleId + string.Format("{0},", value);
            //}

            //value = int.Parse(this.drpChamberTitles.SelectedValue);
            //if (value > 0)
            //{
            //    instrTitleId = instrTitleId + string.Format("{0},", value);
            //}

            //value = int.Parse(this.drpLargeTitles.SelectedValue);
            //if (value > 0)
            //{
            //    instrTitleId = instrTitleId + string.Format("{0},", value);
            //}

            //value = int.Parse(this.drpBandWindTitles.SelectedValue);
            //if (value > 0)
            //{
            //    instrTitleId = instrTitleId + string.Format("{0},", value);
            //}

            //value = int.Parse(this.drpVocalChoralTitles.SelectedValue);
            //if (value > 0)
            //{
            //    instrTitleId = instrTitleId + string.Format("{0},", value);
            //}

            //if (instrTitleId.Length > 0)
            //{
            //    instrTitleId = instrTitleId.Substring(0, instrTitleId.Length - 1);

            //    selectClause.AppendLine("INNER JOIN lwg_CatalogTitle ct ON c.CatalogId = ct.CatalogId");

            //    whereClause.AppendFormat("AND ct.InstrTitleId IN ({0})", instrTitleId).AppendLine();
            //}
            #endregion
            value = int.Parse(this.drpCategory.SelectedValue);
            if (value > 0)
            {
                selectClause.AppendLine("INNER JOIN Nop_Product np ON np.ProductId = c.CatalogId");
                selectClause.AppendLine("INNER JOIN Nop_Product_Category_Mapping npc ON np.ProductId = npc.ProductId");

                whereClause.AppendFormat("AND npc.CategoryId = {0}", value).AppendLine();
            }

            value = int.Parse(this.drpPeriodStyle.SelectedValue);
            if (value > 0)
            {
                selectClause.AppendLine("INNER JOIN lwg_PeriodMapping lpm ON lpm.CatalogID = p.ProductId");
                whereClause.AppendFormat("AND lpm.PeriodId = {0}", value).AppendLine();
            }

            value = int.Parse(this.drpSeries.SelectedValue);
            if (value > 0)
            {
                selectClause.AppendLine("INNER JOIN lwg_SeriesMapping lsm ON lsm.CatalogID = p.ProductId");
                whereClause.AppendFormat("AND lsm.SeriesId = {0}", value).AppendLine();
            }

            value = int.Parse(this.drpGenre.SelectedValue);
            {
                if (value > 0)
                {
                    selectClause.AppendLine("INNER JOIN lwg_CatalogGenre cg ON c.CatalogId = cg.CatalogId");
                    whereClause.AppendFormat("AND cg.GerneId = {0}", value).AppendLine();
                }
            }

            value = int.Parse(this.drpPublisher.SelectedValue);
            {
                if (value > 0)
                {
                    selectClause.AppendLine("INNER JOIN lwg_CatalogPublisher cpb ON c.CatalogId = cpb.CatalogId");
                    whereClause.AppendFormat("AND cpb.PublisherID = {0}", value).AppendLine();
                }
            }

            string select = selectClause.ToString();
            string where = whereClause.ToString();

            if (where.StartsWith("AND"))
            {
                where = where.Remove(0, 3);
            }

            string query = string.Empty;

            if (string.IsNullOrEmpty(where))
            {
                query = select;
            }
            else
            {
                query = string.Format("{0} WHERE {1}", select, where);
            }

            this.ltrQuery.Text = query;
            this.Query = query;

            this.BindProduct();
        }

        private void BindProduct()
        {
            LudwigContext context = new LudwigContext();
            var result = context.SqlQuery<Nop_Product>(this.Query);
            List<Nop_Product> lstProduct = result.ToList();
            List<Nop_Product> productForBind = new List<Nop_Product>();

            if (lstProduct.Count() > 0)
            {
                int totalRecords = lstProduct.Count;
                this.pagerProducts.Visible = this.pagerProducts.PageSize < totalRecords;
                for (int i = this.PageIndex; i < totalRecords; i++)
                {
                    productForBind.Add(lstProduct[i]);
                }
                this.lvResult.DataSource = productForBind;
                this.lvResult.DataBind();
                this.pnResult.Visible = true;
                this.pnSearchForm.Visible = false;
                this.ltrError.Visible = false;
            }
            else
            {
                this.pnResult.Visible = true;
                this.pnSearchForm.Visible = false;
                this.ltrError.Visible = true;
            }
        }

        protected void btnClearForm_Click(object sender, EventArgs e)
        {
            this.txtArranger.Text = string.Empty;
            this.txtComposer.Text = string.Empty;
            this.txtDuration.Text = string.Empty;
            this.txtGrade.Text = string.Empty;
            this.txtInstrumentation.Text = string.Empty;
            this.txtTitle.Text = string.Empty;
            this.txtYear.Text = string.Empty;
            this.BindData();

            this.ltrQuery.Text = string.Empty;
        }

        protected void lvProducts_OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            this.pagerProducts.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindProduct();
        }
    }
}
