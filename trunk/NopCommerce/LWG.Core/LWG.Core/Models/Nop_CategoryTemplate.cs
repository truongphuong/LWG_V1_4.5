using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_CategoryTemplate
    {
        public Nop_CategoryTemplate()
        {
            this.Nop_Category = new List<Nop_Category>();
        }

        public int CategoryTemplateId { get; set; }
        public string Name { get; set; }
        public string TemplatePath { get; set; }
        public int DisplayOrder { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public virtual ICollection<Nop_Category> Nop_Category { get; set; }
    }
}
