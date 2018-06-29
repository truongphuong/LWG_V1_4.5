using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_TaxCategory
    {
        public Nop_TaxCategory()
        {
            this.Nop_TaxRate = new List<Nop_TaxRate>();
        }

        public int TaxCategoryID { get; set; }
        public string Name { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public virtual ICollection<Nop_TaxRate> Nop_TaxRate { get; set; }
    }
}
