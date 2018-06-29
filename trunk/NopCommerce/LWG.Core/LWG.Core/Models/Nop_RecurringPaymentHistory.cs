using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_RecurringPaymentHistory
    {
        public int RecurringPaymentHistoryID { get; set; }
        public int RecurringPaymentID { get; set; }
        public int OrderID { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public virtual Nop_RecurringPayment Nop_RecurringPayment { get; set; }
    }
}
