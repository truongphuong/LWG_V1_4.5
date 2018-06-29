using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ShippingMethod
    {
        public Nop_ShippingMethod()
        {
            this.Nop_ShippingByTotal = new List<Nop_ShippingByTotal>();
            this.Nop_ShippingByWeight = new List<Nop_ShippingByWeight>();
            this.Nop_ShippingByWeightAndCountry = new List<Nop_ShippingByWeightAndCountry>();
            this.Nop_Country = new List<Nop_Country>();
        }

        public int ShippingMethodID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public virtual ICollection<Nop_ShippingByTotal> Nop_ShippingByTotal { get; set; }
        public virtual ICollection<Nop_ShippingByWeight> Nop_ShippingByWeight { get; set; }
        public virtual ICollection<Nop_ShippingByWeightAndCountry> Nop_ShippingByWeightAndCountry { get; set; }
        public virtual ICollection<Nop_Country> Nop_Country { get; set; }
    }
}
