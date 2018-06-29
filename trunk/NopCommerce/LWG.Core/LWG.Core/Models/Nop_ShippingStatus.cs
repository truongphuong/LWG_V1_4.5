using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ShippingStatus
    {
        public Nop_ShippingStatus()
        {
            this.Nop_Order = new List<Nop_Order>();
        }

        public int ShippingStatusID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Nop_Order> Nop_Order { get; set; }
    }
}
