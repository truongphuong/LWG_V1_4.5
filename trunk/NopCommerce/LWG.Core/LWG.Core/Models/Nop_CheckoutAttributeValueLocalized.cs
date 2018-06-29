using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_CheckoutAttributeValueLocalized
    {
        public int CheckoutAttributeValueLocalizedID { get; set; }
        public int CheckoutAttributeValueID { get; set; }
        public int LanguageID { get; set; }
        public string Name { get; set; }
        public virtual Nop_CheckoutAttributeValue Nop_CheckoutAttributeValue { get; set; }
        public virtual Nop_Language Nop_Language { get; set; }
    }
}
