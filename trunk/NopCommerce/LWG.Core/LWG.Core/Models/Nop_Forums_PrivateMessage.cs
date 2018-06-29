using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Forums_PrivateMessage
    {
        public int PrivateMessageID { get; set; }
        public int FromUserID { get; set; }
        public int ToUserID { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public bool IsRead { get; set; }
        public bool IsDeletedByAuthor { get; set; }
        public bool IsDeletedByRecipient { get; set; }
        public System.DateTime CreatedOn { get; set; }
    }
}
