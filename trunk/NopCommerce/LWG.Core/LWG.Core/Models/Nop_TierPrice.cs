using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_TierPrice
    {
        public int TierPriceID { get; set; }
        public int ProductVariantID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual Nop_ProductVariant Nop_ProductVariant { get; set; }
    }
}
