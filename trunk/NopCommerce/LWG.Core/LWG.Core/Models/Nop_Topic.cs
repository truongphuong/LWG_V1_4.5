using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Topic
    {
        public Nop_Topic()
        {
            this.Nop_TopicLocalized = new List<Nop_TopicLocalized>();
        }

        public int TopicID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Nop_TopicLocalized> Nop_TopicLocalized { get; set; }
    }
}
