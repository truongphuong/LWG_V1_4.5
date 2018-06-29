using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ProductTag
    {
        public Nop_ProductTag()
        {
            this.Nop_Product = new List<Nop_Product>();
        }

        public int ProductTagID { get; set; }
        public string Name { get; set; }
        public int ProductCount { get; set; }
        public virtual ICollection<Nop_Product> Nop_Product { get; set; }
    }
}
