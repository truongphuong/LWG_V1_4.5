using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_BannedIpNetwork
    {
        public int BannedIpNetworkID { get; set; }
        public string StartAddress { get; set; }
        public string EndAddress { get; set; }
        public string Comment { get; set; }
        public string IpException { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
    }
}
