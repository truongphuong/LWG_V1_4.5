using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Campaign
    {
        public int CampaignID { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public System.DateTime CreatedOn { get; set; }
    }
}
