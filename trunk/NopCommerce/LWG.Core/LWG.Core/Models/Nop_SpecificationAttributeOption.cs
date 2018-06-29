using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_SpecificationAttributeOption
    {
        public Nop_SpecificationAttributeOption()
        {
            this.Nop_Product_SpecificationAttribute_Mapping = new List<Nop_Product_SpecificationAttribute_Mapping>();
            this.Nop_SpecificationAttributeOptionLocalized = new List<Nop_SpecificationAttributeOptionLocalized>();
        }

        public int SpecificationAttributeOptionID { get; set; }
        public int SpecificationAttributeID { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public virtual ICollection<Nop_Product_SpecificationAttribute_Mapping> Nop_Product_SpecificationAttribute_Mapping { get; set; }
        public virtual Nop_SpecificationAttribute Nop_SpecificationAttribute { get; set; }
        public virtual ICollection<Nop_SpecificationAttributeOptionLocalized> Nop_SpecificationAttributeOptionLocalized { get; set; }
    }
}
