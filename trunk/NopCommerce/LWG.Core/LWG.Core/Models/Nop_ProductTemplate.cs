using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ProductTemplate
    {
        public Nop_ProductTemplate()
        {
            this.Nop_Product = new List<Nop_Product>();
        }

        public int ProductTemplateId { get; set; }
        public string Name { get; set; }
        public string TemplatePath { get; set; }
        public int DisplayOrder { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public virtual ICollection<Nop_Product> Nop_Product { get; set; }
    }
}
