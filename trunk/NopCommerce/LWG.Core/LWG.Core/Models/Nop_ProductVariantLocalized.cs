using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ProductVariantLocalized
    {
        public int ProductVariantLocalizedID { get; set; }
        public int ProductVariantID { get; set; }
        public int LanguageID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Nop_Language Nop_Language { get; set; }
        public virtual Nop_ProductVariant Nop_ProductVariant { get; set; }
    }
}
