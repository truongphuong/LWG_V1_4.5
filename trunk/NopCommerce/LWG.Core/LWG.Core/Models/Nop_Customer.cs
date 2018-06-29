using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Customer
    {
        public Nop_Customer()
        {
            this.Nop_ActivityLog = new List<Nop_ActivityLog>();
            this.Nop_Address = new List<Nop_Address>();
            this.Nop_BlogPost = new List<Nop_BlogPost>();
            this.Nop_CustomerAttribute = new List<Nop_CustomerAttribute>();
            this.Nop_DiscountUsageHistory = new List<Nop_DiscountUsageHistory>();
            this.Nop_GiftCardUsageHistory = new List<Nop_GiftCardUsageHistory>();
            this.Nop_PollVotingRecord = new List<Nop_PollVotingRecord>();
            this.Nop_ProductRating = new List<Nop_ProductRating>();
            this.Nop_ProductReview = new List<Nop_ProductReview>();
            this.Nop_RewardPointsHistory = new List<Nop_RewardPointsHistory>();
            this.Nop_CustomerRole = new List<Nop_CustomerRole>();
        }

        public int CustomerID { get; set; }
        public System.Guid CustomerGUID { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string SaltKey { get; set; }
        public int AffiliateID { get; set; }
        public int BillingAddressID { get; set; }
        public int ShippingAddressID { get; set; }
        public int LastPaymentMethodID { get; set; }
        public string LastAppliedCouponCode { get; set; }
        public string GiftCardCouponCodes { get; set; }
        public string CheckoutAttributes { get; set; }
        public int LanguageID { get; set; }
        public int CurrencyID { get; set; }
        public int TaxDisplayTypeID { get; set; }
        public bool IsTaxExempt { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsGuest { get; set; }
        public bool IsForumModerator { get; set; }
        public int TotalForumPosts { get; set; }
        public string Signature { get; set; }
        public string AdminComment { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime RegistrationDate { get; set; }
        public string TimeZoneID { get; set; }
        public int AvatarID { get; set; }
        public string DealerID { get; set; }
        public virtual ICollection<Nop_ActivityLog> Nop_ActivityLog { get; set; }
        public virtual ICollection<Nop_Address> Nop_Address { get; set; }
        public virtual ICollection<Nop_BlogPost> Nop_BlogPost { get; set; }
        public virtual ICollection<Nop_CustomerAttribute> Nop_CustomerAttribute { get; set; }
        public virtual ICollection<Nop_DiscountUsageHistory> Nop_DiscountUsageHistory { get; set; }
        public virtual ICollection<Nop_GiftCardUsageHistory> Nop_GiftCardUsageHistory { get; set; }
        public virtual ICollection<Nop_PollVotingRecord> Nop_PollVotingRecord { get; set; }
        public virtual ICollection<Nop_ProductRating> Nop_ProductRating { get; set; }
        public virtual ICollection<Nop_ProductReview> Nop_ProductReview { get; set; }
        public virtual ICollection<Nop_RewardPointsHistory> Nop_RewardPointsHistory { get; set; }
        public virtual ICollection<Nop_CustomerRole> Nop_CustomerRole { get; set; }
    }
}
