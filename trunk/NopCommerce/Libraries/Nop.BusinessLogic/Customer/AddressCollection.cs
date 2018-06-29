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
using System.Collections.Generic;
using System.Text;


namespace NopSolutions.NopCommerce.BusinessLogic.CustomerManagement
{
    /// <summary>
    /// Represents an address collection
    /// </summary>
    public partial class AddressCollection : BaseEntityCollection<Address>
    {
        /// <summary>
        /// Finds an address
        /// </summary>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="phoneNumber">Phone number</param>
        /// <param name="email">Email</param>
        /// <param name="faxNumber">Fax number</param>
        /// <param name="company">Company</param>
        /// <param name="address1">Address 1</param>
        /// <param name="address2">Address 2</param>
        /// <param name="city">City</param>
        /// <param name="stateProvinceId">State/province identifier</param>
        /// <param name="zipPostalCode">Zip postal code</param>
        /// <param name="countryId">Country identifier</param>
        /// <returns>Address</returns>
        public Address FindAddress(string firstName, string lastName, string phoneNumber, 
            string email, string faxNumber, string company,string address1, 
            string address2, string city, int stateProvinceId,
            string zipPostalCode, int countryId)
        {
            return this.Find((a) => a.FirstName == firstName &&
                a.LastName == lastName && 
                a.PhoneNumber == phoneNumber &&
                a.Email == email && 
                a.FaxNumber == faxNumber &&
                a.Company == company && 
                a.Address1 == address1 && 
                a.Address2 == address2 &&
                a.City == city && 
                a.StateProvinceId == stateProvinceId && 
                a.ZipPostalCode == zipPostalCode &&
                a.CountryId == countryId);
        }
    }
}