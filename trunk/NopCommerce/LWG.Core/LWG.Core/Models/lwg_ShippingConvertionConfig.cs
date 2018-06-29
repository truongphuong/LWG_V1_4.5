using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_ShippingConvertionConfig
    {
        public int ID { get; set; }
        public int PriceFrom { get; set; }
        public int PriceTo { get; set; }
        public string Type { get; set; }
        public int ChargeWeight { get; set; }
    }
}
