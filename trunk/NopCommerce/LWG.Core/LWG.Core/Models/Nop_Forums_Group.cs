using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Forums_Group
    {
        public Nop_Forums_Group()
        {
            this.Nop_Forums_Forum = new List<Nop_Forums_Forum>();
        }

        public int ForumGroupID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public virtual ICollection<Nop_Forums_Forum> Nop_Forums_Forum { get; set; }
    }
}
