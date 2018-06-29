using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_LicenseForm
    {
        public int LicenseID { get; set; }
        public int LicenseType { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
