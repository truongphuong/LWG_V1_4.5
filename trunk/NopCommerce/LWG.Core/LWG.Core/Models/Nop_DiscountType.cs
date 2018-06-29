using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_DiscountType
    {
        public Nop_DiscountType()
        {
            this.Nop_Discount = new List<Nop_Discount>();
        }

        public int DiscountTypeID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Nop_Discount> Nop_Discount { get; set; }
    }
}
