using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_CustomerAction
    {
        public Nop_CustomerAction()
        {
            this.Nop_ACL = new List<Nop_ACL>();
        }

        public int CustomerActionID { get; set; }
        public string Name { get; set; }
        public string SystemKeyword { get; set; }
        public string Comment { get; set; }
        public int DisplayOrder { get; set; }
        public virtual ICollection<Nop_ACL> Nop_ACL { get; set; }
    }
}
