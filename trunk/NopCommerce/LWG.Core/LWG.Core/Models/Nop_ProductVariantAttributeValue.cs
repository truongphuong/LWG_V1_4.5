using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ProductVariantAttributeValue
    {
        public Nop_ProductVariantAttributeValue()
        {
            this.Nop_ProductVariantAttributeValueLocalized = new List<Nop_ProductVariantAttributeValueLocalized>();
        }

        public int ProductVariantAttributeValueID { get; set; }
        public int ProductVariantAttributeID { get; set; }
        public string Name { get; set; }
        public decimal PriceAdjustment { get; set; }
        public decimal WeightAdjustment { get; set; }
        public bool IsPreSelected { get; set; }
        public int DisplayOrder { get; set; }
        public virtual Nop_ProductVariant_ProductAttribute_Mapping Nop_ProductVariant_ProductAttribute_Mapping { get; set; }
        public virtual ICollection<Nop_ProductVariantAttributeValueLocalized> Nop_ProductVariantAttributeValueLocalized { get; set; }
    }
}
