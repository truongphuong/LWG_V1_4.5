using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Forums_Post
    {
        public int PostID { get; set; }
        public int TopicID { get; set; }
        public int UserID { get; set; }
        public string Text { get; set; }
        public string IPAddress { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public virtual Nop_Forums_Topic Nop_Forums_Topic { get; set; }
    }
}
