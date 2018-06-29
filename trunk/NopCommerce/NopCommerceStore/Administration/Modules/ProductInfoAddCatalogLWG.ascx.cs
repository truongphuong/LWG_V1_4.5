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
    public partial class ProductInfoAddCatalogLWGControl : BaseNopAdministrationUserControl
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
                InitDropdownList();
                BindingCatalog();

            }
            lblNote.Visible = false;
        }
        private void InitDropdownList()
        {
            InstrumentalBiz iBiz = new InstrumentalBiz();

            PublisherBiz plBiz = new PublisherBiz();

            drpInstrumental.Items.Clear();
            drpInstrumental.DataSource = iBiz.GetListInstrumental();
            drpInstrumental.DataBind();
            drpInstrumental.Items.Add(new ListItem("Please choose ...", "-1"));
            drpInstrumental.SelectedValue = "-1";

            drpCatalogPublisher.Items.Clear();
            drpCatalogPublisher.DataSource = plBiz.GetListPublisher();
            drpCatalogPublisher.DataBind();
            drpCatalogPublisher.Items.Add(new ListItem("Please choose ...", "-1"));
            drpCatalogPublisher.SelectedValue = "-1";

        }

        private void BindingCatalog()
        {
            if (ProductId == 0)
            {
                pnlMessage.Visible = true;
                updatepnCatalog.Visible = false;
                return;
            }
            else
            {
                Product product = ProductManager.GetProductById(this.ProductId);
                if (product != null)
                {
                    ltBlurb.Text = product.FullDescription;

                    //load product variants 
                    ProductVariantCollection productVariants = product.ProductVariants;
                    gvProductVariants.DataSource = productVariants;
                    gvProductVariants.DataBind();
                    if (productVariants.Count > 1)
                        lblFScprodcode.Text = productVariants[1].SKU.ToString();// FSCprodcode1 mapped from SKU of second variant 
                    
                    CatalogBiz cBiz = new CatalogBiz();
                    lwg_Catalog c = cBiz.GetByID(ProductId);
                    if (c != null)
                    {
                        FillData(c);
                        btnAdd.Text = "Update";
                    }
                    else
                    {
                        ClearData();
                        btnAdd.Text = "Add";
                    }

                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SaveCatalogLWG();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void ClearData()
        {
            lblNote.Visible = false;
            // insert data            
            txtCatalogNumber.Text = string.Empty;
            txtDuration.Text = string.Empty; // "Duration1";
            lblFScprodcode.Text = string.Empty;// "FSCprodcode1";
            txtGrade.Text = string.Empty;
            txtKaldbNumber.Text = string.Empty; ;// "Kalddbnumber1";
            txtPages.Text = string.Empty;
            txtSubTitle.Text = string.Empty;
            txtTextLang.Text = string.Empty;
            txtCatalogInstrSearch.Text = string.Empty;
            txtCatalogNameSearch.Text = string.Empty;
            txtInstrDetail.Text = string.Empty;
            chkVocAccomp.Checked = true;
            // replace YearTo,YearFrom by Year
            txtYear.Text = string.Empty;
        }

        private void FillData(lwg_Catalog p)
        {
            if (p != null)
            {
                // insert data
                txtCatalogNumber.Text = p.CatalogNumber;
                txtDuration.Text = p.Duration; // "Duration1";

                txtGrade.Text = p.Grade == null ? string.Empty : p.Grade;
                if (drpInstrumental.Items.Count > 0)
                {
                    drpInstrumental.SelectedValue = p.InstrumentalId == null ? "-1" : p.InstrumentalId.ToString();
                }
                txtKaldbNumber.Text = p.KaldbNumber;// "Kalddbnumber1";
                txtPages.Text = p.pages;



                txtSubTitle.Text = p.Subtitle == null ? string.Empty : p.Subtitle;
                txtTextLang.Text = p.TextLang == null ? string.Empty : p.TextLang;


                // replace YearTo, YearFrom by Year
                txtYear.Text = p.Year;
                if (!string.IsNullOrEmpty(p.PDF))
                {
                    ltrPDFFile.Text = p.PDF;
                    btnDeletePDFFile.Visible = true;
                }
                else
                {
                    ltrPDFFile.Text = string.Empty;
                    btnDeletePDFFile.Visible = false;
                }

                CatalogBiz cBiz = new CatalogBiz();
                txtCatalogInstrSearch.Text = cBiz.GetInstrSearchByCatalogID(p.CatalogId);
                txtCatalogNameSearch.Text = cBiz.GetNameSearchByCatalogID(p.CatalogId);

                int iPublisherID = cBiz.GetPublisherIDByCatalogID(p.CatalogId);
                if (iPublisherID > 0)
                {
                    drpCatalogPublisher.SelectedValue = iPublisherID.ToString();
                }

                txtInstrDetail.Text = p.InstrDetail == null ? string.Empty : p.InstrDetail;
                chkVocAccomp.Checked = p.VocAccomp == null ? false : p.VocAccomp.Value;

                txtTableofContents.Content = p.TableofContents;
                txtCopyrightYear.Text = p.CopyrightYear;
            }

        }
        public string GetProductVariantName(ProductVariant productVariant)
        {
            string variantName = string.Empty;
            if (!String.IsNullOrEmpty(productVariant.Name))
                variantName = productVariant.Name;
            else
                variantName = GetLocaleResourceString("Admin.Product.ProductVariants.Unnamed");

            return variantName;
        }
        public void SaveCatalogLWG()
        {
            Page.Validate("AddEdit");
            if (Page.IsValid)
            {

                CatalogBiz pBiz = new CatalogBiz();
                Product product = ProductManager.GetProductById(ProductId);
                lwg_Catalog p = pBiz.GetByID(ProductId);
                if (p == null)
                {
                    p = new lwg_Catalog();
                    p.CatalogId = ProductId;
                    lblNote.Text = "Insert error, please try again";
                }
                else
                {
                    lblNote.Text = "Update error, please try again";
                }
                if (p != null)
                {
                    // insert data

                    p.CatalogNumber = txtCatalogNumber.Text;
                    p.Duration = txtDuration.Text.TrimStart().TrimEnd(); // "Duration1";

                    if (!string.IsNullOrEmpty(txtGrade.Text))
                    {
                        p.Grade = txtGrade.Text;
                    }
                    if (drpInstrumental.Items.Count > 0 && !drpInstrumental.SelectedValue.Equals("-1"))
                    {
                        p.InstrumentalId = int.Parse(drpInstrumental.SelectedValue);
                    }
                    p.KaldbNumber = txtKaldbNumber.Text;// "Kalddbnumber1";
                    p.pages = txtPages.Text;
                    string tempPDF = string.Empty;
                    string strPDF = SavePDFFile(uploadPDF, ref tempPDF);
                    if (string.IsNullOrEmpty(tempPDF))
                    {
                        LWGUtils.ClearOldFile(string.Format("{0}{1}", LWGUtils.GetPDFPath(), p.PDF));
                        p.PDF = strPDF;   //TODO: change to uploadfile control
                    }
                    p.PDF = p.PDF == null ? string.Empty : p.PDF;

                    p.Subtitle = txtSubTitle.Text;
                    p.TextLang = txtTextLang.Text;

                    // replace YearTo, YearFrom by Year
                    p.Year = txtYear.Text.Trim();
                    p.CopyrightYear = txtCopyrightYear.Text.Trim();
                    p.InstrDetail = txtInstrDetail.Text.TrimStart().TrimEnd();
                    p.VocAccomp = chkVocAccomp.Checked;

                    p.TableofContents = txtTableofContents.Content;
                    if (string.IsNullOrEmpty(p.SoundIcon))
                        p.SoundIcon = string.Empty;
                    //Save Catalog
                    if (pBiz.SaveCatalog(p))
                    {
                        // save publisher, genre,...                        
                        pBiz.SaveCatalogPublisher(p.CatalogId, int.Parse(drpCatalogPublisher.SelectedValue));
                        if (!string.IsNullOrEmpty(txtCatalogInstrSearch.Text))
                        {
                            lwg_CatalogInstrumentSearch lwg = new lwg_CatalogInstrumentSearch();
                            lwg.CatalogId = p.CatalogId;
                            lwg.IntrText = txtCatalogInstrSearch.Text;
                            pBiz.SaveCatalogInstrumentalSearch(lwg);
                        }
                        if (!string.IsNullOrEmpty(txtCatalogNameSearch.Text))
                        {
                            lwg_CatalogNameSearch lwg = new lwg_CatalogNameSearch();
                            lwg.CatalogId = p.CatalogId;
                            lwg.Name = txtCatalogNameSearch.Text;
                            pBiz.SaveCatalogNameSearch(lwg);
                        }

                        lblNote.Text = "Save success!";
                        //ClearData();
                    }
                }
                lblNote.Visible = true;
            }
        }

        private string SaveSoundFile(FileUpload fileupload, ref string strErr)
        {
            strErr = string.Empty;
            if (fileupload.HasFile)
            {
                try
                {
                    string temp = LWGUtils.SaveSoundFile(fileupload, LWGUtils.GetSoundPath(), ref strErr);
                    if (string.IsNullOrEmpty(strErr))
                    {
                        return temp;
                    }
                }
                catch (Exception ex)
                {
                    //TODO: uploadfile error
                    return string.Empty;
                }
            }
            else
            {
                strErr = LWGUtils.NO_FILE;
            }
            return string.Empty;
        }

        private string SavePDFFile(FileUpload fileupload, ref string strErr)
        {
            strErr = string.Empty;
            if (fileupload.HasFile)
            {
                try
                {
                    string temp = LWGUtils.SavePDFFile(fileupload, LWGUtils.GetPDFPath(), ref strErr);
                    if (string.IsNullOrEmpty(strErr))
                    {
                        return temp;
                    }
                }
                catch (Exception ex)
                {
                    //TODO: uploadfile error
                    return string.Empty;
                }
            }
            else
            {
                strErr = LWGUtils.NO_FILE;
            }
            return string.Empty;
        }

        protected void btnDeletePDFFile_Click(object sender, EventArgs e)
        {
            CatalogBiz catalogBiz = new CatalogBiz();
            lwg_Catalog catalog = catalogBiz.GetByID(this.ProductId);
            if (catalog != null)
            {
                if (!string.IsNullOrEmpty(catalog.PDF))
                {
                    LWGUtils.ClearOldFile(string.Format("{0}{1}", LWGUtils.GetPDFPath(), catalog.PDF));
                    catalog.PDF = string.Empty;
                    catalogBiz.SaveCatalog(catalog);
                    BindingCatalog();
                }
            }
        }
    }
}