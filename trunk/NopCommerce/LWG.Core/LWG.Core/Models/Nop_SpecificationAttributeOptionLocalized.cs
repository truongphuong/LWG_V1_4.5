using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_SpecificationAttributeOptionLocalized
    {
        public int SpecificationAttributeOptionLocalizedID { get; set; }
        public int SpecificationAttributeOptionID { get; set; }
        public int LanguageID { get; set; }
        public string Name { get; set; }
        public virtual Nop_Language Nop_Language { get; set; }
        public virtual Nop_SpecificationAttributeOption Nop_SpecificationAttributeOption { get; set; }
    }
}
