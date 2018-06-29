using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_LowStockActivity
    {
        public Nop_LowStockActivity()
        {
            this.Nop_ProductVariant = new List<Nop_ProductVariant>();
        }

        public int LowStockActivityID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Nop_ProductVariant> Nop_ProductVariant { get; set; }
    }
}
