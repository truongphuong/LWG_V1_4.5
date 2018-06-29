using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Country
    {
        public Nop_Country()
        {
            this.Nop_ShippingByWeightAndCountry = new List<Nop_ShippingByWeightAndCountry>();
            this.Nop_StateProvince = new List<Nop_StateProvince>();
            this.Nop_TaxRate = new List<Nop_TaxRate>();
            this.Nop_PaymentMethod = new List<Nop_PaymentMethod>();
            this.Nop_ShippingMethod = new List<Nop_ShippingMethod>();
        }

        public int CountryID { get; set; }
        public string Name { get; set; }
        public bool AllowsRegistration { get; set; }
        public bool AllowsBilling { get; set; }
        public bool AllowsShipping { get; set; }
        public string TwoLetterISOCode { get; set; }
        public string ThreeLetterISOCode { get; set; }
        public int NumericISOCode { get; set; }
        public byte Published { get; set; }
        public int DisplayOrder { get; set; }
        public virtual ICollection<Nop_ShippingByWeightAndCountry> Nop_ShippingByWeightAndCountry { get; set; }
        public virtual ICollection<Nop_StateProvince> Nop_StateProvince { get; set; }
        public virtual ICollection<Nop_TaxRate> Nop_TaxRate { get; set; }
        public virtual ICollection<Nop_PaymentMethod> Nop_PaymentMethod { get; set; }
        public virtual ICollection<Nop_ShippingMethod> Nop_ShippingMethod { get; set; }
    }
}
