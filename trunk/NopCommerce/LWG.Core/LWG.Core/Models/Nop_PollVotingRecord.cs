using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_PollVotingRecord
    {
        public int PollVotingRecordID { get; set; }
        public int PollAnswerID { get; set; }
        public int CustomerID { get; set; }
        public virtual Nop_Customer Nop_Customer { get; set; }
        public virtual Nop_PollAnswer Nop_PollAnswer { get; set; }
    }
}
