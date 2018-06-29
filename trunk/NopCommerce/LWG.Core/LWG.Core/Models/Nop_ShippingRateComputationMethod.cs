using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ShippingRateComputationMethod
    {
        public int ShippingRateComputationMethodID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ConfigureTemplatePath { get; set; }
        public string ClassName { get; set; }
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }
    }
}
