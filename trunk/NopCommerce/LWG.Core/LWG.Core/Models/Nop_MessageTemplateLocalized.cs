using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_MessageTemplateLocalized
    {
        public int MessageTemplateLocalizedID { get; set; }
        public int MessageTemplateID { get; set; }
        public int LanguageID { get; set; }
        public string BCCEmailAddresses { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsActive { get; set; }
        public virtual Nop_Language Nop_Language { get; set; }
        public virtual Nop_MessageTemplate Nop_MessageTemplate { get; set; }
    }
}
