using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Product_Manufacturer_Mapping
    {
        public int ProductManufacturerID { get; set; }
        public int ProductID { get; set; }
        public int ManufacturerID { get; set; }
        public bool IsFeaturedProduct { get; set; }
        public int DisplayOrder { get; set; }
        public virtual Nop_Manufacturer Nop_Manufacturer { get; set; }
        public virtual Nop_Product Nop_Product { get; set; }
    }
}
