using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ProductVariant_ProductAttribute_Mapping
    {
        public Nop_ProductVariant_ProductAttribute_Mapping()
        {
            this.Nop_ProductVariantAttributeValue = new List<Nop_ProductVariantAttributeValue>();
        }

        public int ProductVariantAttributeID { get; set; }
        public int ProductVariantID { get; set; }
        public int ProductAttributeID { get; set; }
        public string TextPrompt { get; set; }
        public bool IsRequired { get; set; }
        public int AttributeControlTypeID { get; set; }
        public int DisplayOrder { get; set; }
        public virtual Nop_ProductAttribute Nop_ProductAttribute { get; set; }
        public virtual Nop_ProductVariant Nop_ProductVariant { get; set; }
        public virtual ICollection<Nop_ProductVariantAttributeValue> Nop_ProductVariantAttributeValue { get; set; }
    }
}
