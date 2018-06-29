using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ProductAttribute
    {
        public Nop_ProductAttribute()
        {
            this.Nop_ProductAttributeLocalized = new List<Nop_ProductAttributeLocalized>();
            this.Nop_ProductVariant_ProductAttribute_Mapping = new List<Nop_ProductVariant_ProductAttribute_Mapping>();
        }

        public int ProductAttributeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Nop_ProductAttributeLocalized> Nop_ProductAttributeLocalized { get; set; }
        public virtual ICollection<Nop_ProductVariant_ProductAttribute_Mapping> Nop_ProductVariant_ProductAttribute_Mapping { get; set; }
    }
}
