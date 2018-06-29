using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Manufacturer
    {
        public Nop_Manufacturer()
        {
            this.Nop_ManufacturerLocalized = new List<Nop_ManufacturerLocalized>();
            this.Nop_Product_Manufacturer_Mapping = new List<Nop_Product_Manufacturer_Mapping>();
        }

        public int ManufacturerID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TemplateID { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string SEName { get; set; }
        public int PictureID { get; set; }
        public int PageSize { get; set; }
        public string PriceRanges { get; set; }
        public bool Published { get; set; }
        public bool Deleted { get; set; }
        public int DisplayOrder { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public virtual Nop_ManufacturerTemplate Nop_ManufacturerTemplate { get; set; }
        public virtual ICollection<Nop_ManufacturerLocalized> Nop_ManufacturerLocalized { get; set; }
        public virtual ICollection<Nop_Product_Manufacturer_Mapping> Nop_Product_Manufacturer_Mapping { get; set; }
    }
}
