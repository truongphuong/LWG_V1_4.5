using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_CheckoutAttribute
    {
        public Nop_CheckoutAttribute()
        {
            this.Nop_CheckoutAttributeLocalized = new List<Nop_CheckoutAttributeLocalized>();
            this.Nop_CheckoutAttributeValue = new List<Nop_CheckoutAttributeValue>();
        }

        public int CheckoutAttributeID { get; set; }
        public string Name { get; set; }
        public string TextPrompt { get; set; }
        public bool IsRequired { get; set; }
        public bool ShippableProductRequired { get; set; }
        public bool IsTaxExempt { get; set; }
        public int TaxCategoryID { get; set; }
        public int AttributeControlTypeID { get; set; }
        public int DisplayOrder { get; set; }
        public virtual ICollection<Nop_CheckoutAttributeLocalized> Nop_CheckoutAttributeLocalized { get; set; }
        public virtual ICollection<Nop_CheckoutAttributeValue> Nop_CheckoutAttributeValue { get; set; }
    }
}
