using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_CheckoutAttributeValue
    {
        public Nop_CheckoutAttributeValue()
        {
            this.Nop_CheckoutAttributeValueLocalized = new List<Nop_CheckoutAttributeValueLocalized>();
        }

        public int CheckoutAttributeValueID { get; set; }
        public int CheckoutAttributeID { get; set; }
        public string Name { get; set; }
        public decimal PriceAdjustment { get; set; }
        public decimal WeightAdjustment { get; set; }
        public bool IsPreSelected { get; set; }
        public int DisplayOrder { get; set; }
        public virtual Nop_CheckoutAttribute Nop_CheckoutAttribute { get; set; }
        public virtual ICollection<Nop_CheckoutAttributeValueLocalized> Nop_CheckoutAttributeValueLocalized { get; set; }
    }
}
