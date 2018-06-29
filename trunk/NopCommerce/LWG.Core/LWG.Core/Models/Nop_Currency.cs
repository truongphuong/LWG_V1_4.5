using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Currency
    {
        public int CurrencyID { get; set; }
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public string DisplayLocale { get; set; }
        public decimal Rate { get; set; }
        public string CustomFormatting { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
    }
}
