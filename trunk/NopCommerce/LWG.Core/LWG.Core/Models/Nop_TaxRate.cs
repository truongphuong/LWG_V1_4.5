using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_TaxRate
    {
        public int TaxRateID { get; set; }
        public int TaxCategoryID { get; set; }
        public int CountryID { get; set; }
        public int StateProvinceID { get; set; }
        public string Zip { get; set; }
        public decimal Percentage { get; set; }
        public virtual Nop_Country Nop_Country { get; set; }
        public virtual Nop_TaxCategory Nop_TaxCategory { get; set; }
    }
}
