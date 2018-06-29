using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_Role
    {
        public lwg_Role()
        {
            this.lwg_PersonInRole = new List<lwg_PersonInRole>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<lwg_PersonInRole> lwg_PersonInRole { get; set; }
    }
}
