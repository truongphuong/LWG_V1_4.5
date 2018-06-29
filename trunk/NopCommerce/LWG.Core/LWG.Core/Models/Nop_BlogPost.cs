using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_BlogPost
    {
        public Nop_BlogPost()
        {
            this.Nop_BlogComment = new List<Nop_BlogComment>();
        }

        public int BlogPostID { get; set; }
        public int LanguageID { get; set; }
        public string BlogPostTitle { get; set; }
        public string BlogPostBody { get; set; }
        public bool BlogPostAllowComments { get; set; }
        public int CreatedByID { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public virtual ICollection<Nop_BlogComment> Nop_BlogComment { get; set; }
        public virtual Nop_Customer Nop_Customer { get; set; }
        public virtual Nop_Language Nop_Language { get; set; }
    }
}
