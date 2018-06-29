using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Poll
    {
        public Nop_Poll()
        {
            this.Nop_PollAnswer = new List<Nop_PollAnswer>();
        }

        public int PollID { get; set; }
        public int LanguageID { get; set; }
        public string Name { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }
        public string SystemKeyword { get; set; }
        public virtual Nop_Language Nop_Language { get; set; }
        public virtual ICollection<Nop_PollAnswer> Nop_PollAnswer { get; set; }
    }
}
