using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Affiliate
    {
        public int AffiliateID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FaxNumber { get; set; }
        public string Company { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string ZipPostalCode { get; set; }
        public int CountryId { get; set; }
        public byte Active { get; set; }
        public bool Deleted { get; set; }
    }
}
