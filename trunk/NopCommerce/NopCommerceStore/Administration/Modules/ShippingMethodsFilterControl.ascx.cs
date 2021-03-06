﻿using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using NopSolutions.NopCommerce.BusinessLogic.Directory;
using NopSolutions.NopCommerce.BusinessLogic.Shipping;

namespace NopSolutions.NopCommerce.Web.Administration.Modules
{
    public partial class ShippingMethodsFilterControl : BaseNopAdministrationUserControl
    {
        public class NopGridViewCustomTemplate : ITemplate
        {
            #region Fields
            private DataControlRowType _templateType;
            private string _columnName;
            private string _dataType;
            private int _shippingMethodId;
            #endregion

            #region Ctor
            public NopGridViewCustomTemplate(DataControlRowType type, 
                string columnName, string DataType) : this(type, columnName, DataType, 0)
            {
            }

            public NopGridViewCustomTemplate(DataControlRowType type, 
                string columnName, string dataType, int shippingMethodId)
            {
                _templateType = type;
                _columnName = columnName;
                _dataType = dataType;
                _shippingMethodId = shippingMethodId;
            }
            #endregion

            #region Utilities
            private void ctrl_DataBinding(Object sender, EventArgs e)
            {
                WebControl ctrl = sender as WebControl;
                GridViewRow row = ctrl.NamingContainer as GridViewRow;

                switch(_dataType)
                {
                    case "String":
                        object RawValue = DataBinder.Eval(row.DataItem, _columnName);
                        (ctrl as Label).Text = RawValue.ToString();
                        break;

                    case "Checkbox":
                        ShippingMethodCountryMappingHelperClass map1 = row.DataItem as ShippingMethodCountryMappingHelperClass;
                        (ctrl as CheckBox).Checked = map1.Restrict[_shippingMethodId];
                        break;
                }
            }

            private void hfCountryId_DataBinding(Object sender, EventArgs e)
            {
                HiddenField hf = sender as HiddenField;
                GridViewRow row = hf.NamingContainer as GridViewRow;

                ShippingMethodCountryMappingHelperClass map1 = row.DataItem as ShippingMethodCountryMappingHelperClass;
                hf.Value = map1.CountryId.ToString();
            }
            #endregion

            #region Methods
            public void InstantiateIn(Control container)
            {
                switch(_templateType)
                {
                    case DataControlRowType.Header:
                        Literal lc = new Literal();
                        lc.Text = "<b>" + _columnName + "</b>";
                        container.Controls.Add(lc);
                        break;

                    case DataControlRowType.DataRow:
                        WebControl ctrl = null;
                        switch(_dataType)
                        {
                            case "String":
                                ctrl = new Label();
                                break;

                            case "Checkbox":
                                ctrl = new CheckBox();
                                ctrl.ID = String.Format("cbRestrict_{0}", _shippingMethodId);
                                HiddenField hfCountryId = new HiddenField();
                                hfCountryId.ID = String.Format("hfCountryId_{0}", _shippingMethodId);
                                hfCountryId.DataBinding += new EventHandler(hfCountryId_DataBinding);
                                container.Controls.Add(hfCountryId);
                                break;

                            default:
                                throw new Exception("Not supported column type");
                                break;
                        }
                        ctrl.DataBinding += new EventHandler(this.ctrl_DataBinding);
                        container.Controls.Add(ctrl);
                        break;
                }
            }
            #endregion
        }

        protected class ShippingMethodCountryMappingHelperClass
        {
            public int CountryId 
            { 
                get;
                set; 
            }

            public string CountryName 
            { 
                get; 
                set; 
            }

            public Dictionary<int, bool> Restrict 
            { 
                get; 
                set; 
            }
        }

        protected void BuildColumnsDynamically()
        {
            gvShippingMethodCountryMap.Columns.Clear();

            TemplateField tfAction = new TemplateField();
            tfAction.ItemTemplate = new NopGridViewCustomTemplate(DataControlRowType.DataRow, "CountryName", "String");
            tfAction.HeaderTemplate = new NopGridViewCustomTemplate(DataControlRowType.Header, GetLocaleResourceString("Admin.ShippingMethodsFilterControl.Grid.CountryName"), "String");
            gvShippingMethodCountryMap.Columns.Add(tfAction);

            ShippingMethodCollection shippingMethodCollection = ShippingMethodManager.GetAllShippingMethods();
            foreach(ShippingMethod shippingMethod in shippingMethodCollection)
            {
                TemplateField tf = new TemplateField();
                tf.ItemTemplate = new NopGridViewCustomTemplate(DataControlRowType.DataRow, "Restrict", "Checkbox", shippingMethod.ShippingMethodId);
                tf.HeaderTemplate = new NopGridViewCustomTemplate(DataControlRowType.Header, shippingMethod.Name, "String");
                gvShippingMethodCountryMap.Columns.Add(tf);
            }
        }

        protected void BindGrid()
        {
            CountryCollection countryCollection = CountryManager.GetAllCountries();
            ShippingMethodCollection shippingMethodCollection = ShippingMethodManager.GetAllShippingMethods();

            if(countryCollection.Count == 0)
            {
                lblMessage.Text = GetLocaleResourceString("Admin.ShippingMethodsFilterControl.NoCountryDefined");
            }
            if(shippingMethodCollection.Count == 0)
            {
                lblMessage.Text = GetLocaleResourceString("Admin.ShippingMethodsFilterControl.NoShippingMethodDefined");
            }

            List<ShippingMethodCountryMappingHelperClass> dt = new List<ShippingMethodCountryMappingHelperClass>();
            foreach(Country country in countryCollection)
            {
                ShippingMethodCountryMappingHelperClass map1 = new ShippingMethodCountryMappingHelperClass();
                map1.CountryId = country.CountryId;
                map1.CountryName = country.Name;
                map1.Restrict = new Dictionary<int, bool>();

                foreach(ShippingMethod shippingMethod in shippingMethodCollection)
                {
                    map1.Restrict.Add(shippingMethod.ShippingMethodId, ShippingMethodManager.DoesShippingMethodCountryMappingExist(shippingMethod.ShippingMethodId, country.CountryId));
                }

                dt.Add(map1);
            }

            gvShippingMethodCountryMap.DataSource = dt;
            gvShippingMethodCountryMap.DataBind();
        }

        protected override void OnInit(EventArgs e)
        {
            BuildColumnsDynamically();
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        public void SaveInfo()
        {
            if(Page.IsValid)
            {
                try
                {
                    ShippingMethodCollection shippingMethodCollection = ShippingMethodManager.GetAllShippingMethods();
                    foreach(GridViewRow row in gvShippingMethodCountryMap.Rows)
                    {
                        foreach(ShippingMethod shippingMethod in shippingMethodCollection)
                        {
                            CheckBox cbRestrict = row.FindControl(String.Format("cbRestrict_{0}", shippingMethod.ShippingMethodId)) as CheckBox;
                            HiddenField hfCountryId = row.FindControl(String.Format("hfCountryId_{0}", shippingMethod.ShippingMethodId)) as HiddenField;

                            int countryId = Int32.Parse(hfCountryId.Value);

                            if(cbRestrict.Checked)
                            {
                                ShippingMethodManager.CreateShippingMethodCountryMapping(shippingMethod.ShippingMethodId, countryId);
                            }
                            else
                            {
                                ShippingMethodManager.DeleteShippingMethodCountryMapping(shippingMethod.ShippingMethodId, countryId);
                            }
                        }
                    }

                    Response.Redirect("ShippingMethods.aspx");
                }
                catch(Exception exc)
                {
                    ProcessException(exc);
                }
            }
        }
    }
}