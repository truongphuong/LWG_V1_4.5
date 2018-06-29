using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_PaymentMethod
    {
        public Nop_PaymentMethod()
        {
            this.Nop_Country = new List<Nop_Country>();
        }

        public int PaymentMethodID { get; set; }
        public string Name { get; set; }
        public string VisibleName { get; set; }
        public string Description { get; set; }
        public string ConfigureTemplatePath { get; set; }
        public string UserTemplatePath { get; set; }
        public string ClassName { get; set; }
        public string SystemKeyword { get; set; }
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }
        public virtual ICollection<Nop_Country> Nop_Country { get; set; }
    }
}
