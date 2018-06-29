using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Order
    {
        public Nop_Order()
        {
            this.Nop_DiscountUsageHistory = new List<Nop_DiscountUsageHistory>();
            this.Nop_OrderNote = new List<Nop_OrderNote>();
            this.Nop_OrderProductVariant = new List<Nop_OrderProductVariant>();
        }

        public int OrderID { get; set; }
        public System.Guid OrderGUID { get; set; }
        public int CustomerID { get; set; }
        public int CustomerLanguageID { get; set; }
        public int CustomerTaxDisplayTypeID { get; set; }
        public string CustomerIP { get; set; }
        public decimal OrderSubtotalInclTax { get; set; }
        public decimal OrderSubtotalExclTax { get; set; }
        public decimal OrderShippingInclTax { get; set; }
        public decimal OrderShippingExclTax { get; set; }
        public decimal PaymentMethodAdditionalFeeInclTax { get; set; }
        public decimal PaymentMethodAdditionalFeeExclTax { get; set; }
        public decimal OrderTax { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal OrderDiscount { get; set; }
        public decimal OrderSubtotalInclTaxInCustomerCurrency { get; set; }
        public decimal OrderSubtotalExclTaxInCustomerCurrency { get; set; }
        public decimal OrderShippingInclTaxInCustomerCurrency { get; set; }
        public decimal OrderShippingExclTaxInCustomerCurrency { get; set; }
        public decimal PaymentMethodAdditionalFeeInclTaxInCustomerCurrency { get; set; }
        public decimal PaymentMethodAdditionalFeeExclTaxInCustomerCurrency { get; set; }
        public decimal OrderTaxInCustomerCurrency { get; set; }
        public decimal OrderTotalInCustomerCurrency { get; set; }
        public decimal OrderDiscountInCustomerCurrency { get; set; }
        public string CustomerCurrencyCode { get; set; }
        public string CheckoutAttributeDescription { get; set; }
        public string CheckoutAttributesXML { get; set; }
        public double OrderWeight { get; set; }
        public int AffiliateID { get; set; }
        public int OrderStatusID { get; set; }
        public bool AllowStoringCreditCardNumber { get; set; }
        public string CardType { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string MaskedCreditCardNumber { get; set; }
        public string CardCVV2 { get; set; }
        public string CardExpirationMonth { get; set; }
        public string CardExpirationYear { get; set; }
        public int PaymentMethodID { get; set; }
        public string PaymentMethodName { get; set; }
        public string AuthorizationTransactionID { get; set; }
        public string AuthorizationTransactionCode { get; set; }
        public string AuthorizationTransactionResult { get; set; }
        public string CaptureTransactionID { get; set; }
        public string CaptureTransactionResult { get; set; }
        public string SubscriptionTransactionID { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public int PaymentStatusID { get; set; }
        public Nullable<System.DateTime> PaidDate { get; set; }
        public string BillingFirstName { get; set; }
        public string BillingLastName { get; set; }
        public string BillingPhoneNumber { get; set; }
        public string BillingEmail { get; set; }
        public string BillingFaxNumber { get; set; }
        public string BillingCompany { get; set; }
        public string BillingAddress1 { get; set; }
        public string BillingAddress2 { get; set; }
        public string BillingCity { get; set; }
        public string BillingStateProvince { get; set; }
        public int BillingStateProvinceID { get; set; }
        public string BillingZipPostalCode { get; set; }
        public string BillingCountry { get; set; }
        public int BillingCountryID { get; set; }
        public int ShippingStatusID { get; set; }
        public string ShippingFirstName { get; set; }
        public string ShippingLastName { get; set; }
        public string ShippingPhoneNumber { get; set; }
        public string ShippingEmail { get; set; }
        public string ShippingFaxNumber { get; set; }
        public string ShippingCompany { get; set; }
        public string ShippingAddress1 { get; set; }
        public string ShippingAddress2 { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingStateProvince { get; set; }
        public int ShippingStateProvinceID { get; set; }
        public string ShippingZipPostalCode { get; set; }
        public string ShippingCountry { get; set; }
        public int ShippingCountryID { get; set; }
        public string ShippingMethod { get; set; }
        public int ShippingRateComputationMethodID { get; set; }
        public Nullable<System.DateTime> ShippedDate { get; set; }
        public string TrackingNumber { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public virtual ICollection<Nop_DiscountUsageHistory> Nop_DiscountUsageHistory { get; set; }
        public virtual Nop_OrderStatus Nop_OrderStatus { get; set; }
        public virtual Nop_PaymentStatus Nop_PaymentStatus { get; set; }
        public virtual Nop_ShippingStatus Nop_ShippingStatus { get; set; }
        public virtual ICollection<Nop_OrderNote> Nop_OrderNote { get; set; }
        public virtual ICollection<Nop_OrderProductVariant> Nop_OrderProductVariant { get; set; }
    }
}
