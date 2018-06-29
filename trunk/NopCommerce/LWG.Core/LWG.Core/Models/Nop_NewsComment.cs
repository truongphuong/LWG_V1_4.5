using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_NewsComment
    {
        public int NewsCommentID { get; set; }
        public int NewsID { get; set; }
        public int CustomerID { get; set; }
        public string IPAddress { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public virtual Nop_News Nop_News { get; set; }
    }
}
