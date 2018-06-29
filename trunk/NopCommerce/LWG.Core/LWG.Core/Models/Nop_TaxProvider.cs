using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_TaxProvider
    {
        public int TaxProviderID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ConfigureTemplatePath { get; set; }
        public string ClassName { get; set; }
        public int DisplayOrder { get; set; }
    }
}
