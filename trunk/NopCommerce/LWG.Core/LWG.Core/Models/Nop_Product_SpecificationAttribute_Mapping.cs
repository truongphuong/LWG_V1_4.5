using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Product_SpecificationAttribute_Mapping
    {
        public int ProductSpecificationAttributeID { get; set; }
        public int ProductID { get; set; }
        public int SpecificationAttributeOptionID { get; set; }
        public bool AllowFiltering { get; set; }
        public bool ShowOnProductPage { get; set; }
        public int DisplayOrder { get; set; }
        public virtual Nop_Product Nop_Product { get; set; }
        public virtual Nop_SpecificationAttributeOption Nop_SpecificationAttributeOption { get; set; }
    }
}
