//------------------------------------------------------------------------------
// The contents of this file are subject to the nopCommerce Public License Version 1.0 ("License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at  http://www.nopCommerce.com/License.aspx. 
// 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. 
// See the License for the specific language governing rights and limitations under the License.
// 
// The Original Code is nopCommerce.
// The Initial Developer of the Original Code is NopSolutions.
// All Rights Reserved.
// 
// Contributor(s): _______. 
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using NopSolutions.NopCommerce.BusinessLogic.CustomerManagement;
using NopSolutions.NopCommerce.Web;
 
namespace NopSolutions.NopCommerce.Web.Administration.Modules
{
    public partial class SelectCustomerRolesControl : BaseNopAdministrationUserControl
    {
        protected List<int> selectedCustomerRoleIds = new List<int>();

        public void BindData()
        {
            CustomerRoleCollection customerRoles = CustomerManager.GetAllCustomerRoles();
            divDealer.Attributes.CssStyle.Add("display", "none");
            foreach (CustomerRole customerRole in customerRoles)
            {
                ListItem item = new ListItem(customerRole.Name, customerRole.CustomerRoleId.ToString());
                if (this.selectedCustomerRoleIds.Contains(customerRole.CustomerRoleId))
                {
                    item.Selected = true;
                    if (customerRole.CustomerRoleId == 5)
                    {
                        divDealer.Attributes.CssStyle.Remove("display");
                        divDealer.Attributes.CssStyle.Add("display", "block");
                    }
                }
                if (customerRole.CustomerRoleId == 5)
                    item.Attributes.Add("class", "dealerClick");
                this.cblCustomerRoles.Items.Add(item);
            }
            this.cblCustomerRoles.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string CssClass
        {
            get
            {
                return cblCustomerRoles.CssClass;
            }
            set
            {
                cblCustomerRoles.CssClass = value;
            }
        }

        public List<int> SelectedCustomerRoleIds
        {
            get
            {
                List<int> result = new List<int>();
                foreach (ListItem item in this.cblCustomerRoles.Items)
                    if (item.Selected)
                        result.Add(int.Parse(item.Value));
                return result;
            }
            set
            {
                this.selectedCustomerRoleIds = value;
            }
        }

        public string DealerID
        {
            get
            {
                return txtDealerID.Text.Trim();
            }
            set
            {
                txtDealerID.Text = value;
            }
        }

        protected void lbtnDealerDetail_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("dealerdetails.aspx?dealerid={0}",txtDealerID.Text.Trim()));
        }
    }
}