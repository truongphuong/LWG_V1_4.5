using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ProductVariant_Pricelist_Mapping
    {
        public int ProductVariantPricelistID { get; set; }
        public int ProductVariantID { get; set; }
        public int PricelistID { get; set; }
        public int PriceAdjustmentTypeID { get; set; }
        public decimal PriceAdjustment { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public virtual Nop_Pricelist Nop_Pricelist { get; set; }
        public virtual Nop_ProductVariant Nop_ProductVariant { get; set; }
    }
}
