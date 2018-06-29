using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ShoppingCartType
    {
        public Nop_ShoppingCartType()
        {
            this.Nop_ShoppingCartItem = new List<Nop_ShoppingCartItem>();
        }

        public int ShoppingCartTypeID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Nop_ShoppingCartItem> Nop_ShoppingCartItem { get; set; }
    }
}
