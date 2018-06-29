using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_MessageTemplate
    {
        public Nop_MessageTemplate()
        {
            this.Nop_MessageTemplateLocalized = new List<Nop_MessageTemplateLocalized>();
        }

        public int MessageTemplateID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Nop_MessageTemplateLocalized> Nop_MessageTemplateLocalized { get; set; }
    }
}
