using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ManufacturerTemplate
    {
        public Nop_ManufacturerTemplate()
        {
            this.Nop_Manufacturer = new List<Nop_Manufacturer>();
        }

        public int ManufacturerTemplateId { get; set; }
        public string Name { get; set; }
        public string TemplatePath { get; set; }
        public int DisplayOrder { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public virtual ICollection<Nop_Manufacturer> Nop_Manufacturer { get; set; }
    }
}
