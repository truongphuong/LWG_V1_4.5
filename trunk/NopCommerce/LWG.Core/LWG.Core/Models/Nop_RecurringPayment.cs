using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_RecurringPayment
    {
        public Nop_RecurringPayment()
        {
            this.Nop_RecurringPaymentHistory = new List<Nop_RecurringPaymentHistory>();
        }

        public int RecurringPaymentID { get; set; }
        public int InitialOrderID { get; set; }
        public int CycleLength { get; set; }
        public int CyclePeriod { get; set; }
        public int TotalCycles { get; set; }
        public System.DateTime StartDate { get; set; }
        public bool IsActive { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public virtual ICollection<Nop_RecurringPaymentHistory> Nop_RecurringPaymentHistory { get; set; }
    }
}
