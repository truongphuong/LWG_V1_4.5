using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ProductLocalized
    {
        public int ProductLocalizedID { get; set; }
        public int ProductID { get; set; }
        public int LanguageID { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string SEName { get; set; }
        public virtual Nop_Language Nop_Language { get; set; }
        public virtual Nop_Product Nop_Product { get; set; }
    }
}
