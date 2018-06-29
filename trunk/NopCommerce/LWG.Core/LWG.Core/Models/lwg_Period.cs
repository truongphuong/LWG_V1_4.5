using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_Period
    {
        public lwg_Period()
        {
            this.lwg_PeriodMapping = new List<lwg_PeriodMapping>();
        }

        public int PeriodId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<lwg_PeriodMapping> lwg_PeriodMapping { get; set; }
    }
}
