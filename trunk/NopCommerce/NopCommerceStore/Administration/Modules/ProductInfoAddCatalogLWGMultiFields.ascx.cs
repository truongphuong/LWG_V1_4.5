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

using System.Linq;
using System.Xml.Linq;
using LWG.Business;
using LWG.Core.Models;

namespace NopSolutions.NopCommerce.Web.Administration.Modules
{
    public partial class ProductInfoAddCatalogLWGMultiFieldsControl : BaseNopAdministrationUserControl
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
            if (!IsPostBack)
            {
                if (ProductId > 0)
                {
                    InitDropdownList();
                    pnUpdatepn1.Visible = true;
                    pnlMessage.Visible = false;
                    BindingGenre();
                    //BindingCatalogInstrTitle();
                    BindingPeriod();
                    BindingReprintSource();
                    BindingSeries();
                }
                else
                {
                    pnUpdatepn1.Visible = false;
                    pnlMessage.Visible = true;
                } 
            }
        }
        
        #region Genre area
        protected void gvGenre_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("REMOVE"))
            {
                GenerBiz gBiz = new GenerBiz();
                int id = int.Parse(e.CommandArgument.ToString());
                if (gBiz.DeleteCatalogGenre(id,ProductId))
                {
                    BindingGenre();
                }
            } 
        }

        protected void gvGenre_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem == null)
            {
                return;
            }
            lwg_CatalogGenre lg = (lwg_CatalogGenre)e.Row.DataItem;
            if (lg != null)
            {
                Literal ltrProductDisplay = (Literal)e.Row.FindControl("ltrProductDisplay");
                ltrProductDisplay.Text = lg.lwg_Catalog.TitleDisplay;

                Literal ltrGenreName = (Literal)e.Row.FindControl("ltrGenreName");
                ltrGenreName.Text = lg.lwg_Genre.Name;

                LinkButton lnkbtnRemove = (LinkButton)e.Row.FindControl("lnkbtnRemove");
                lnkbtnRemove.CommandArgument = lg.GerneId.ToString();
            }
        }

        protected void btnAddGenre_Click(object sender, EventArgs e)
        {
            CatalogBiz pBiz = new CatalogBiz();
            if (drpCatalogGenre.Items.Count > 0)
            {
                if (pBiz.SaveCatalogGenre(ProductId, int.Parse(drpCatalogGenre.SelectedValue)))
                {
                    BindingGenre();
                }
            }
        }

        private void BindingGenre()
        {
            //TODO: binding Genre 
            GenerBiz gBiz = new GenerBiz();
            gvGenre.DataSource = gBiz.GetListCatalogGenre(ProductId);
            gvGenre.DataBind();
        }

        #endregion

        #region InstrTitleTye

        //protected void gvCatalogInstrTitle_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.DataItem == null)
        //    {
        //        return;
        //    }
        //    lwg_CatalogTitle lg = (lwg_CatalogTitle)e.Row.DataItem;
        //    if (lg != null)
        //    {
        //        Literal ltrProductName = (Literal)e.Row.FindControl("ltrProductName");
        //        ltrProductName.Text = lg.lwg_Catalog.TitleDisplay;

        //        Literal ltrInstrTitleName = (Literal)e.Row.FindControl("ltrInstrTitleName");
        //        ltrInstrTitleName.Text = lg.lwg_InstrTitle.Name;

        //        Literal ltrTitleTypeName = (Literal)e.Row.FindControl("ltrTitleTypeName");
        //        ltrTitleTypeName.Text = lg.lwg_InstrTitle.lwg_TitleType.Name;
                
        //        LinkButton lnkbtnRemove = (LinkButton)e.Row.FindControl("lnkbtnRemove");
        //        lnkbtnRemove.CommandArgument = lg.InstrTitleId.ToString();
        //    }
        //}

        //protected void gvCatalogInstrTitle_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName.Equals("REMOVE"))
        //    {
        //        CatalogBiz cBiz = new CatalogBiz();
        //        int id = int.Parse(e.CommandArgument.ToString());
        //        if (cBiz.DeleteCatalogTitle(id,ProductId))
        //        {
        //            BindingCatalogInstrTitle();
        //        }
        //    }
        //}

        //protected void btnAddInstrTitle_Click(object sender, EventArgs e)
        //{
        //    CatalogBiz pBiz = new CatalogBiz();
        //    if (drpInstrTitle.Items.Count > 0)
        //    {
        //        if (pBiz.SaveCatalogTitle(ProductId, int.Parse(drpInstrTitle.SelectedValue)))
        //        {
        //            BindingCatalogInstrTitle();
        //        }
        //    }
        //}

        //protected void drpTitleType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    CatalogTitleTypeBiz cttBiz = new CatalogTitleTypeBiz();
        //    if (drpTitleType.Items.Count > 0)
        //    {
        //        drpInstrTitle.DataSource = cttBiz.GetListInstrTitle(int.Parse(drpTitleType.SelectedValue));
        //        drpInstrTitle.DataBind();
        //    }
        //}

        //private void BindingCatalogInstrTitle()
        //{
        //    CatalogTitleTypeBiz ctBiz = new CatalogTitleTypeBiz();
        //    gvCatalogInstrTitle.DataSource = ctBiz.GetListCatalogTitleByCatalogID(ProductId);
        //    gvCatalogInstrTitle.DataBind();
        //}
        #endregion
        
        private void InitDropdownList()
        {
            CatalogTitleTypeBiz cttBiz = new CatalogTitleTypeBiz();
            GenerBiz gBiz = new GenerBiz();
            PeriodBiz pBiz = new PeriodBiz();
            ReprintSourceBiz rBiz = new ReprintSourceBiz();
            SeriesBiz sBiz = new SeriesBiz();

            drpCatalogGenre.DataSource = gBiz.GetListGenre();
            drpCatalogGenre.DataBind();

            //drpTitleType.DataSource = cttBiz.GetListTitleType();
            //drpTitleType.DataBind();

            //if (drpTitleType.Items.Count > 0)
            //{
            //    drpInstrTitle.DataSource = cttBiz.GetListInstrTitle(int.Parse(drpTitleType.SelectedValue));
            //    drpInstrTitle.DataBind();
            //}
                        
            drpPeriod.DataSource = pBiz.GetListPeriod();
            drpPeriod.DataBind();            
                        
            drpReprintSource.DataSource = rBiz.GetListReprintSource();
            drpReprintSource.DataBind();
            grdReprintsource.DataSource = null;
            grdReprintsource.DataBind();
                        
            drpSeries.DataSource = sBiz.GetListSeries();
            drpSeries.DataBind();
            grdSeries.DataSource = null;
            grdSeries.DataBind();
        }

        #region Series
        protected void btnSeries_Click(object sender, EventArgs e)
        {
            SeriesBiz sBiz = new SeriesBiz();
            lwg_SeriesMapping lwg = new lwg_SeriesMapping();
            lwg.CatalogID = ProductId;
            lwg.SeriesID = int.Parse(drpSeries.SelectedValue);
            if (sBiz.SaveSeriesMapping(lwg))
            {
                BindingSeries();    
            }
            //TODO: save fail
        }

        protected void grdSeries_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("REMOVE"))
            {
                SeriesBiz sBiz = new SeriesBiz();
                int id = int.Parse(e.CommandArgument.ToString());
                if (sBiz.DeleteSeriesMappingByID(id, ProductId))
                {
                    BindingSeries();
                }
            } 
        }

        protected void grdSeries_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem == null)
            {
                return;
            }
            lwg_SeriesMapping lg = (lwg_SeriesMapping)e.Row.DataItem;
            if (lg != null)
            {
                Literal ltrProductDisplay = (Literal)e.Row.FindControl("ltrProductDisplay");
                ltrProductDisplay.Text = lg.lwg_Catalog.TitleDisplay;

                Literal ltrSeriesName = (Literal)e.Row.FindControl("ltrSeriesName");
                ltrSeriesName.Text = lg.lwg_Series.Name;

                LinkButton lnkbtnRemove = (LinkButton)e.Row.FindControl("lnkbtnRemove");
                lnkbtnRemove.CommandArgument = lg.SeriesID.ToString();
            }
        }

        private void BindingSeries()
        {
            SeriesBiz sBiz = new SeriesBiz();
            grdSeries.DataSource = sBiz.GetListSeriesMappingByCatalogID(ProductId);
            grdSeries.DataBind();
        }
        #endregion

        #region ReprintSource
        protected void btnReprintsource_Click(object sender, EventArgs e)
        {
            ReprintSourceBiz rBiz = new ReprintSourceBiz();
            lwg_ReprintSourceMapping lwg = new lwg_ReprintSourceMapping();
            lwg.CatalogID = ProductId;
            lwg.ReprintSourceID = int.Parse(drpReprintSource.SelectedValue);
            if (rBiz.SaveReprintSourceMapping(lwg))
            {
                BindingReprintSource();
            }
            //TODO: save fail
        }

        protected void grdReprintsource_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("REMOVE"))
            {
                ReprintSourceBiz rBiz = new ReprintSourceBiz();
                int id = int.Parse(e.CommandArgument.ToString());
                if (rBiz.DeleteReprintSourceMappingByID(id, ProductId))
                {
                    BindingReprintSource();
                }
            } 
        }

        protected void grdReprintsource_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem == null)
            {
                return;
            }
            lwg_ReprintSourceMapping lg = (lwg_ReprintSourceMapping)e.Row.DataItem;
            if (lg != null)
            {
                Literal ltrProductDisplay = (Literal)e.Row.FindControl("ltrProductDisplay");
                ltrProductDisplay.Text = lg.lwg_Catalog.TitleDisplay;

                Literal ltrReprintsource = (Literal)e.Row.FindControl("ltrReprintsource");
                ltrReprintsource.Text = lg.lwg_ReprintSource.Name;

                LinkButton lnkbtnRemove = (LinkButton)e.Row.FindControl("lnkbtnRemove");
                lnkbtnRemove.CommandArgument = lg.ReprintSourceID.ToString();
            }
        }

        private void BindingReprintSource()
        {
            ReprintSourceBiz rBiz = new ReprintSourceBiz();
            grdReprintsource.DataSource = rBiz.GetListReprintSourceMappingByCatalogID(ProductId);
            grdReprintsource.DataBind();
        }
        #endregion

        #region Period
        protected void btnPeriodAdd_Click(object sender, EventArgs e)
        {
            PeriodBiz pBiz = new PeriodBiz();
            lwg_PeriodMapping lwg = new lwg_PeriodMapping();
            lwg.CatalogID = ProductId;
            lwg.PeriodID = int.Parse(drpPeriod.SelectedValue);
            if (pBiz.SavePeriodMappingByID(lwg))
            {
                BindingPeriod();
            }
            //TODO: save fail
        }

        protected void grdPeriod_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("REMOVE"))
            {
                PeriodBiz pBiz = new PeriodBiz();
                int id = int.Parse(e.CommandArgument.ToString());
                if (pBiz.DeletePeriodMappingBuyID(id, ProductId))
                {
                    BindingPeriod();
                }
            } 
        }

        protected void grdPeriod_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem == null)
            {
                return;
            }
            lwg_PeriodMapping lg = (lwg_PeriodMapping)e.Row.DataItem;
            if (lg != null)
            {
                Literal ltrProductDisplay = (Literal)e.Row.FindControl("ltrProductDisplay");
                ltrProductDisplay.Text = lg.lwg_Catalog.TitleDisplay;

                Literal ltrPeriodName = (Literal)e.Row.FindControl("ltrPeriodName");
                ltrPeriodName.Text = lg.lwg_Period.Name;

                LinkButton lnkbtnRemove = (LinkButton)e.Row.FindControl("lnkbtnRemove");
                lnkbtnRemove.CommandArgument = lg.PeriodID.ToString();
            }
        }

        private void BindingPeriod()
        {
            PeriodBiz pBiz = new PeriodBiz();
            grdPeriod.DataSource = pBiz.GetListPeriodMappingByCatalogID(ProductId);
            grdPeriod.DataBind();            
        }
        #endregion      
        
    }
}