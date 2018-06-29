using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_PollAnswer
    {
        public Nop_PollAnswer()
        {
            this.Nop_PollVotingRecord = new List<Nop_PollVotingRecord>();
        }

        public int PollAnswerID { get; set; }
        public int PollID { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int DisplayOrder { get; set; }
        public virtual Nop_Poll Nop_Poll { get; set; }
        public virtual ICollection<Nop_PollVotingRecord> Nop_PollVotingRecord { get; set; }
    }
}
