using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_CheckoutAttributeLocalized
    {
        public int CheckoutAttributeLocalizedID { get; set; }
        public int CheckoutAttributeID { get; set; }
        public int LanguageID { get; set; }
        public string Name { get; set; }
        public string TextPrompt { get; set; }
        public virtual Nop_CheckoutAttribute Nop_CheckoutAttribute { get; set; }
        public virtual Nop_Language Nop_Language { get; set; }
    }
}
