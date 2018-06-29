using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_SpecificationAttribute
    {
        public Nop_SpecificationAttribute()
        {
            this.Nop_SpecificationAttributeLocalized = new List<Nop_SpecificationAttributeLocalized>();
            this.Nop_SpecificationAttributeOption = new List<Nop_SpecificationAttributeOption>();
        }

        public int SpecificationAttributeID { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public virtual ICollection<Nop_SpecificationAttributeLocalized> Nop_SpecificationAttributeLocalized { get; set; }
        public virtual ICollection<Nop_SpecificationAttributeOption> Nop_SpecificationAttributeOption { get; set; }
    }
}
