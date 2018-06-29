using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_CustomerRole_ProductPrice
    {
        public int CustomerRoleProductPriceID { get; set; }
        public int CustomerRoleID { get; set; }
        public int ProductVariantID { get; set; }
        public decimal Price { get; set; }
        public virtual Nop_CustomerRole Nop_CustomerRole { get; set; }
        public virtual Nop_ProductVariant Nop_ProductVariant { get; set; }
    }
}
