using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_StateProvince
    {
        public int StateProvinceID { get; set; }
        public int CountryID { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public int DisplayOrder { get; set; }
        public virtual Nop_Country Nop_Country { get; set; }
    }
}
