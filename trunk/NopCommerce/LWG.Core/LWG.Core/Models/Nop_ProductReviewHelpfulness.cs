using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ProductReviewHelpfulness
    {
        public int ProductReviewHelpfulnessID { get; set; }
        public int ProductReviewID { get; set; }
        public int CustomerID { get; set; }
        public bool WasHelpful { get; set; }
        public virtual Nop_ProductReview Nop_ProductReview { get; set; }
    }
}
