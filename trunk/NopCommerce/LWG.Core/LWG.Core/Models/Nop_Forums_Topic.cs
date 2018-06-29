using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Forums_Topic
    {
        public Nop_Forums_Topic()
        {
            this.Nop_Forums_Post = new List<Nop_Forums_Post>();
        }

        public int TopicID { get; set; }
        public int ForumID { get; set; }
        public int UserID { get; set; }
        public int TopicTypeID { get; set; }
        public string Subject { get; set; }
        public int NumPosts { get; set; }
        public int Views { get; set; }
        public int LastPostID { get; set; }
        public int LastPostUserID { get; set; }
        public Nullable<System.DateTime> LastPostTime { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public virtual Nop_Forums_Forum Nop_Forums_Forum { get; set; }
        public virtual ICollection<Nop_Forums_Post> Nop_Forums_Post { get; set; }
    }
}
