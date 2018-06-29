using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ProductVariantAttributeValueLocalized
    {
        public int ProductVariantAttributeValueLocalizedID { get; set; }
        public int ProductVariantAttributeValueID { get; set; }
        public int LanguageID { get; set; }
        public string Name { get; set; }
        public virtual Nop_Language Nop_Language { get; set; }
        public virtual Nop_ProductVariantAttributeValue Nop_ProductVariantAttributeValue { get; set; }
    }
}
