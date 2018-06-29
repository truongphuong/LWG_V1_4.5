using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ProductVariantAttributeCombination
    {
        public int ProductVariantAttributeCombinationID { get; set; }
        public int ProductVariantID { get; set; }
        public string AttributesXML { get; set; }
        public int StockQuantity { get; set; }
        public bool AllowOutOfStockOrders { get; set; }
        public virtual Nop_ProductVariant Nop_ProductVariant { get; set; }
    }
}
