using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Address
    {
        public int AddressId { get; set; }
        public int CustomerID { get; set; }
        public bool IsBillingAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FaxNumber { get; set; }
        public string Company { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int StateProvinceID { get; set; }
        public string ZipPostalCode { get; set; }
        public int CountryID { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public virtual Nop_Customer Nop_Customer { get; set; }
    }
}
