using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ProductRating
    {
        public int ProductRatingID { get; set; }
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public int Rating { get; set; }
        public System.DateTime RatedOn { get; set; }
        public virtual Nop_Customer Nop_Customer { get; set; }
        public virtual Nop_Product Nop_Product { get; set; }
    }
}
