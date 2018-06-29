using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ShippingByWeightAndCountry
    {
        public int ShippingByWeightAndCountryID { get; set; }
        public int ShippingMethodID { get; set; }
        public int CountryID { get; set; }
        public decimal From { get; set; }
        public decimal To { get; set; }
        public bool UsePercentage { get; set; }
        public decimal ShippingChargePercentage { get; set; }
        public decimal ShippingChargeAmount { get; set; }
        public virtual Nop_Country Nop_Country { get; set; }
        public virtual Nop_ShippingMethod Nop_ShippingMethod { get; set; }
    }
}
