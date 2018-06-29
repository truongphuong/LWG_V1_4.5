using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_DiscountUsageHistory
    {
        public int DiscountUsageHistoryID { get; set; }
        public int DiscountID { get; set; }
        public int CustomerID { get; set; }
        public int OrderID { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public virtual Nop_Customer Nop_Customer { get; set; }
        public virtual Nop_Discount Nop_Discount { get; set; }
        public virtual Nop_Order Nop_Order { get; set; }
    }
}
