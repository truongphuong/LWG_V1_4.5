using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_GiftCardUsageHistory
    {
        public int GiftCardUsageHistoryID { get; set; }
        public int GiftCardID { get; set; }
        public int CustomerID { get; set; }
        public int OrderID { get; set; }
        public decimal UsedValue { get; set; }
        public decimal UsedValueInCustomerCurrency { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public virtual Nop_Customer Nop_Customer { get; set; }
        public virtual Nop_GiftCard Nop_GiftCard { get; set; }
    }
}
