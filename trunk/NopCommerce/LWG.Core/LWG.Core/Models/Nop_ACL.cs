using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ACL
    {
        public int ACLID { get; set; }
        public int CustomerActionID { get; set; }
        public int CustomerRoleID { get; set; }
        public bool Allow { get; set; }
        public virtual Nop_CustomerAction Nop_CustomerAction { get; set; }
        public virtual Nop_CustomerRole Nop_CustomerRole { get; set; }
    }
}
