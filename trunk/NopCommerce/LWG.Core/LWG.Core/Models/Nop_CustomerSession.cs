using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_CustomerSession
    {
        public Nop_CustomerSession()
        {
            this.Nop_ShoppingCartItem = new List<Nop_ShoppingCartItem>();
        }

        public System.Guid CustomerSessionGUID { get; set; }
        public int CustomerID { get; set; }
        public System.DateTime LastAccessed { get; set; }
        public bool IsExpired { get; set; }
        public virtual ICollection<Nop_ShoppingCartItem> Nop_ShoppingCartItem { get; set; }
    }
}
