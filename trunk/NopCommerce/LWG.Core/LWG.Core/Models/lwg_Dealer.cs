using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_Dealer
    {
        public string DealerID { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string WebAddress { get; set; }
        public string Contact { get; set; }
        public string NewIssue { get; set; }
        public string AddressSearch { get; set; }
    }
}
