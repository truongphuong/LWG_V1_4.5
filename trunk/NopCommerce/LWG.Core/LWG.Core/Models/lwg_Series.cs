using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_Series
    {
        public lwg_Series()
        {
            this.lwg_SeriesMapping = new List<lwg_SeriesMapping>();
        }

        public int SeriesId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<lwg_SeriesMapping> lwg_SeriesMapping { get; set; }
    }
}
