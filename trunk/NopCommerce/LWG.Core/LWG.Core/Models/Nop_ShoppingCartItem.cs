using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ShoppingCartItem
    {
        public int ShoppingCartItemID { get; set; }
        public int ShoppingCartTypeID { get; set; }
        public System.Guid CustomerSessionGUID { get; set; }
        public int ProductVariantID { get; set; }
        public string AttributesXML { get; set; }
        public decimal CustomerEnteredPrice { get; set; }
        public int Quantity { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public virtual Nop_CustomerSession Nop_CustomerSession { get; set; }
        public virtual Nop_ProductVariant Nop_ProductVariant { get; set; }
        public virtual Nop_ShoppingCartType Nop_ShoppingCartType { get; set; }
    }
}
