using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Forums_Subscription
    {
        public int SubscriptionID { get; set; }
        public System.Guid SubscriptionGUID { get; set; }
        public int UserID { get; set; }
        public int ForumID { get; set; }
        public int TopicID { get; set; }
        public System.DateTime CreatedOn { get; set; }
    }
}
