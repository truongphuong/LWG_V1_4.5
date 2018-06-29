using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ProductReview
    {
        public Nop_ProductReview()
        {
            this.Nop_ProductReviewHelpfulness = new List<Nop_ProductReviewHelpfulness>();
        }

        public int ProductReviewID { get; set; }
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public string IPAddress { get; set; }
        public string Title { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public int HelpfulYesTotal { get; set; }
        public int HelpfulNoTotal { get; set; }
        public bool IsApproved { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public virtual Nop_Customer Nop_Customer { get; set; }
        public virtual Nop_Product Nop_Product { get; set; }
        public virtual ICollection<Nop_ProductReviewHelpfulness> Nop_ProductReviewHelpfulness { get; set; }
    }
}
