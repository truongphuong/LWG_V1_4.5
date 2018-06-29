using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Discount
    {
        public Nop_Discount()
        {
            this.Nop_DiscountUsageHistory = new List<Nop_DiscountUsageHistory>();
            this.Nop_ProductVariant = new List<Nop_ProductVariant>();
            this.Nop_ProductVariant1 = new List<Nop_ProductVariant>();
        }

        public int DiscountID { get; set; }
        public int DiscountTypeID { get; set; }
        public int DiscountRequirementID { get; set; }
        public int DiscountLimitationID { get; set; }
        public string Name { get; set; }
        public bool UsePercentage { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public bool RequiresCouponCode { get; set; }
        public string CouponCode { get; set; }
        public bool Deleted { get; set; }
        public virtual Nop_DiscountLimitation Nop_DiscountLimitation { get; set; }
        public virtual Nop_DiscountRequirement Nop_DiscountRequirement { get; set; }
        public virtual Nop_DiscountType Nop_DiscountType { get; set; }
        public virtual ICollection<Nop_DiscountUsageHistory> Nop_DiscountUsageHistory { get; set; }
        public virtual ICollection<Nop_ProductVariant> Nop_ProductVariant { get; set; }
        public virtual ICollection<Nop_ProductVariant> Nop_ProductVariant1 { get; set; }
    }
}
