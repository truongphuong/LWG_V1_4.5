using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_PaymentStatus
    {
        public Nop_PaymentStatus()
        {
            this.Nop_Order = new List<Nop_Order>();
        }

        public int PaymentStatusID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Nop_Order> Nop_Order { get; set; }
    }
}
