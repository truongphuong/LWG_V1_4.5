using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_ReprintSource
    {
        public lwg_ReprintSource()
        {
            this.lwg_ReprintSourceMapping = new List<lwg_ReprintSourceMapping>();
        }

        public int ReprintSourceId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<lwg_ReprintSourceMapping> lwg_ReprintSourceMapping { get; set; }
    }
}
