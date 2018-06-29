using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_BannedIpAddress
    {
        public int BannedIpAddressID { get; set; }
        public string Address { get; set; }
        public string Comment { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
    }
}
