using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_GiftCard
    {
        public Nop_GiftCard()
        {
            this.Nop_GiftCardUsageHistory = new List<Nop_GiftCardUsageHistory>();
        }

        public int GiftCardID { get; set; }
        public int PurchasedOrderProductVariantID { get; set; }
        public decimal Amount { get; set; }
        public bool IsGiftCardActivated { get; set; }
        public string GiftCardCouponCode { get; set; }
        public string RecipientName { get; set; }
        public string RecipientEmail { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string Message { get; set; }
        public bool IsRecipientNotified { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public virtual Nop_OrderProductVariant Nop_OrderProductVariant { get; set; }
        public virtual ICollection<Nop_GiftCardUsageHistory> Nop_GiftCardUsageHistory { get; set; }
    }
}
