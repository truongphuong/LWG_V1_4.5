using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_NewsLetterSubscription
    {
        public int NewsLetterSubscriptionID { get; set; }
        public System.Guid NewsLetterSubscriptionGuid { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public System.DateTime CreatedOn { get; set; }
    }
}
