using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Product_Category_Mapping
    {
        public int ProductCategoryID { get; set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public bool IsFeaturedProduct { get; set; }
        public int DisplayOrder { get; set; }
        public virtual Nop_Category Nop_Category { get; set; }
        public virtual Nop_Product Nop_Product { get; set; }
    }
}
