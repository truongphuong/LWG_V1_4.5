using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ActivityLog
    {
        public int ActivityLogID { get; set; }
        public int ActivityLogTypeID { get; set; }
        public int CustomerID { get; set; }
        public string Comment { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public virtual Nop_ActivityLogType Nop_ActivityLogType { get; set; }
        public virtual Nop_Customer Nop_Customer { get; set; }
    }
}
