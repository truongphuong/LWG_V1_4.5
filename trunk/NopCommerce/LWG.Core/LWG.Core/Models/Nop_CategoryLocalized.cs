using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_CategoryLocalized
    {
        public int CategoryLocalizedID { get; set; }
        public int CategoryID { get; set; }
        public int LanguageID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string SEName { get; set; }
        public virtual Nop_Category Nop_Category { get; set; }
        public virtual Nop_Language Nop_Language { get; set; }
    }
}
