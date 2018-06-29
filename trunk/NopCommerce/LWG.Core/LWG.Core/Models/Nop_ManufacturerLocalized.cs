using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ManufacturerLocalized
    {
        public int ManufacturerLocalizedID { get; set; }
        public int ManufacturerID { get; set; }
        public int LanguageID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string SEName { get; set; }
        public virtual Nop_Language Nop_Language { get; set; }
        public virtual Nop_Manufacturer Nop_Manufacturer { get; set; }
    }
}
