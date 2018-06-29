using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_RewardPointsHistory
    {
        public int RewardPointsHistoryID { get; set; }
        public int CustomerID { get; set; }
        public int OrderID { get; set; }
        public int Points { get; set; }
        public int PointsBalance { get; set; }
        public decimal UsedAmount { get; set; }
        public decimal UsedAmountInCustomerCurrency { get; set; }
        public string CustomerCurrencyCode { get; set; }
        public string Message { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public virtual Nop_Customer Nop_Customer { get; set; }
    }
}
