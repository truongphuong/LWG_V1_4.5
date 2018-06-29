using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_BlogComment
    {
        public int BlogCommentID { get; set; }
        public int BlogPostID { get; set; }
        public int CustomerID { get; set; }
        public string IPAddress { get; set; }
        public string CommentText { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public virtual Nop_BlogPost Nop_BlogPost { get; set; }
    }
}
