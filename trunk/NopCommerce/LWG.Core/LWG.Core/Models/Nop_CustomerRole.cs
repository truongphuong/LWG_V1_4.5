using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_CustomerRole
    {
        public Nop_CustomerRole()
        {
            this.Nop_ACL = new List<Nop_ACL>();
            this.Nop_CustomerRole_ProductPrice = new List<Nop_CustomerRole_ProductPrice>();
            this.Nop_Customer = new List<Nop_Customer>();
        }

        public int CustomerRoleID { get; set; }
        public string Name { get; set; }
        public bool FreeShipping { get; set; }
        public bool TaxExempt { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<Nop_ACL> Nop_ACL { get; set; }
        public virtual ICollection<Nop_CustomerRole_ProductPrice> Nop_CustomerRole_ProductPrice { get; set; }
        public virtual ICollection<Nop_Customer> Nop_Customer { get; set; }
    }
}
