using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ActivityLogType
    {
        public Nop_ActivityLogType()
        {
            this.Nop_ActivityLog = new List<Nop_ActivityLog>();
        }

        public int ActivityLogTypeID { get; set; }
        public string SystemKeyword { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public virtual ICollection<Nop_ActivityLog> Nop_ActivityLog { get; set; }
    }
}
