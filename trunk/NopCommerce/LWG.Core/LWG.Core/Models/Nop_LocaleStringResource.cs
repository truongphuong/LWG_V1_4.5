using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_LocaleStringResource
    {
        public int LocaleStringResourceID { get; set; }
        public int LanguageID { get; set; }
        public string ResourceName { get; set; }
        public string ResourceValue { get; set; }
        public virtual Nop_Language Nop_Language { get; set; }
    }
}
