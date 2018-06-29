using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_QueuedEmail
    {
        public int QueuedEmailID { get; set; }
        public int Priority { get; set; }
        public string From { get; set; }
        public string FromName { get; set; }
        public string To { get; set; }
        public string ToName { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public int SendTries { get; set; }
        public Nullable<System.DateTime> SentOn { get; set; }
    }
}
