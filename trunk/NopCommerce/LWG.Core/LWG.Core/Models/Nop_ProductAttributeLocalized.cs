using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ProductAttributeLocalized
    {
        public int ProductAttributeLocalizedID { get; set; }
        public int ProductAttributeID { get; set; }
        public int LanguageID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Nop_Language Nop_Language { get; set; }
        public virtual Nop_ProductAttribute Nop_ProductAttribute { get; set; }
    }
}
