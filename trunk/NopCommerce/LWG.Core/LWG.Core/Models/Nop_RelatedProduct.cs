using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_RelatedProduct
    {
        public int RelatedProductID { get; set; }
        public int ProductID1 { get; set; }
        public int ProductID2 { get; set; }
        public int DisplayOrder { get; set; }
        public virtual Nop_Product Nop_Product { get; set; }
    }
}
