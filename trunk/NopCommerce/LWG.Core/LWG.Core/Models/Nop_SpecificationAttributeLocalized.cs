using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_SpecificationAttributeLocalized
    {
        public int SpecificationAttributeLocalizedID { get; set; }
        public int SpecificationAttributeID { get; set; }
        public int LanguageID { get; set; }
        public string Name { get; set; }
        public virtual Nop_Language Nop_Language { get; set; }
        public virtual Nop_SpecificationAttribute Nop_SpecificationAttribute { get; set; }
    }
}
