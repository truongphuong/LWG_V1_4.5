using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_MeasureDimension
    {
        public int MeasureDimensionID { get; set; }
        public string Name { get; set; }
        public string SystemKeyword { get; set; }
        public decimal Ratio { get; set; }
        public int DisplayOrder { get; set; }
    }
}
