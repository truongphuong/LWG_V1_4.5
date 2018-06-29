using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_OrderStatus
    {
        public Nop_OrderStatus()
        {
            this.Nop_Order = new List<Nop_Order>();
        }

        public int OrderStatusID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Nop_Order> Nop_Order { get; set; }
    }
}
