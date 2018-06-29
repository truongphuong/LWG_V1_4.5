using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ShippingByTotal
    {
        public int ShippingByTotalID { get; set; }
        public int ShippingMethodID { get; set; }
        public decimal From { get; set; }
        public decimal To { get; set; }
        public bool UsePercentage { get; set; }
        public decimal ShippingChargePercentage { get; set; }
        public decimal ShippingChargeAmount { get; set; }
        public virtual Nop_ShippingMethod Nop_ShippingMethod { get; set; }
    }
}
