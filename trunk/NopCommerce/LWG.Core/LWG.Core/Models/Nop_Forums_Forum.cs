using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Forums_Forum
    {
        public Nop_Forums_Forum()
        {
            this.Nop_Forums_Topic = new List<Nop_Forums_Topic>();
        }

        public int ForumID { get; set; }
        public int ForumGroupID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumTopics { get; set; }
        public int NumPosts { get; set; }
        public int LastTopicID { get; set; }
        public int LastPostID { get; set; }
        public int LastPostUserID { get; set; }
        public Nullable<System.DateTime> LastPostTime { get; set; }
        public int DisplayOrder { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public virtual Nop_Forums_Group Nop_Forums_Group { get; set; }
        public virtual ICollection<Nop_Forums_Topic> Nop_Forums_Topic { get; set; }
    }
}
