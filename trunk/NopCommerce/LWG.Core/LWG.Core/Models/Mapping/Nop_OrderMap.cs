using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_OrderMap : EntityTypeConfiguration<Nop_Order>
    {
        public Nop_OrderMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderID);

            // Properties
            this.Property(t => t.CustomerIP)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CustomerCurrencyCode)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.CheckoutAttributeDescription)
                .IsRequired()
                .HasMaxLength(4000);

            this.Property(t => t.CheckoutAttributesXML)
                .IsRequired();

            this.Property(t => t.CardType)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CardName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CardNumber)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.MaskedCreditCardNumber)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CardCVV2)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CardExpirationMonth)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CardExpirationYear)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.PaymentMethodName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.AuthorizationTransactionID)
                .IsRequired()
                .HasMaxLength(4000);

            this.Property(t => t.AuthorizationTransactionCode)
                .IsRequired()
                .HasMaxLength(4000);

            this.Property(t => t.AuthorizationTransactionResult)
                .IsRequired()
                .HasMaxLength(4000);

            this.Property(t => t.CaptureTransactionID)
                .IsRequired()
                .HasMaxLength(4000);

            this.Property(t => t.CaptureTransactionResult)
                .IsRequired()
                .HasMaxLength(4000);

            this.Property(t => t.SubscriptionTransactionID)
                .IsRequired()
                .HasMaxLength(4000);

            this.Property(t => t.PurchaseOrderNumber)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.BillingFirstName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.BillingLastName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.BillingPhoneNumber)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.BillingEmail)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.BillingFaxNumber)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.BillingCompany)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.BillingAddress1)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.BillingAddress2)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.BillingCity)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.BillingStateProvince)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.BillingZipPostalCode)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.BillingCountry)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ShippingFirstName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ShippingLastName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ShippingPhoneNumber)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ShippingEmail)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.ShippingFaxNumber)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ShippingCompany)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ShippingAddress1)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ShippingAddress2)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ShippingCity)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ShippingStateProvince)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ShippingZipPostalCode)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.ShippingCountry)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ShippingMethod)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.TrackingNumber)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_Order");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.OrderGUID).HasColumnName("OrderGUID");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.CustomerLanguageID).HasColumnName("CustomerLanguageID");
            this.Property(t => t.CustomerTaxDisplayTypeID).HasColumnName("CustomerTaxDisplayTypeID");
            this.Property(t => t.CustomerIP).HasColumnName("CustomerIP");
            this.Property(t => t.OrderSubtotalInclTax).HasColumnName("OrderSubtotalInclTax");
            this.Property(t => t.OrderSubtotalExclTax).HasColumnName("OrderSubtotalExclTax");
            this.Property(t => t.OrderShippingInclTax).HasColumnName("OrderShippingInclTax");
            this.Property(t => t.OrderShippingExclTax).HasColumnName("OrderShippingExclTax");
            this.Property(t => t.PaymentMethodAdditionalFeeInclTax).HasColumnName("PaymentMethodAdditionalFeeInclTax");
            this.Property(t => t.PaymentMethodAdditionalFeeExclTax).HasColumnName("PaymentMethodAdditionalFeeExclTax");
            this.Property(t => t.OrderTax).HasColumnName("OrderTax");
            this.Property(t => t.OrderTotal).HasColumnName("OrderTotal");
            this.Property(t => t.OrderDiscount).HasColumnName("OrderDiscount");
            this.Property(t => t.OrderSubtotalInclTaxInCustomerCurrency).HasColumnName("OrderSubtotalInclTaxInCustomerCurrency");
            this.Property(t => t.OrderSubtotalExclTaxInCustomerCurrency).HasColumnName("OrderSubtotalExclTaxInCustomerCurrency");
            this.Property(t => t.OrderShippingInclTaxInCustomerCurrency).HasColumnName("OrderShippingInclTaxInCustomerCurrency");
            this.Property(t => t.OrderShippingExclTaxInCustomerCurrency).HasColumnName("OrderShippingExclTaxInCustomerCurrency");
            this.Property(t => t.PaymentMethodAdditionalFeeInclTaxInCustomerCurrency).HasColumnName("PaymentMethodAdditionalFeeInclTaxInCustomerCurrency");
            this.Property(t => t.PaymentMethodAdditionalFeeExclTaxInCustomerCurrency).HasColumnName("PaymentMethodAdditionalFeeExclTaxInCustomerCurrency");
            this.Property(t => t.OrderTaxInCustomerCurrency).HasColumnName("OrderTaxInCustomerCurrency");
            this.Property(t => t.OrderTotalInCustomerCurrency).HasColumnName("OrderTotalInCustomerCurrency");
            this.Property(t => t.OrderDiscountInCustomerCurrency).HasColumnName("OrderDiscountInCustomerCurrency");
            this.Property(t => t.CustomerCurrencyCode).HasColumnName("CustomerCurrencyCode");
            this.Property(t => t.CheckoutAttributeDescription).HasColumnName("CheckoutAttributeDescription");
            this.Property(t => t.CheckoutAttributesXML).HasColumnName("CheckoutAttributesXML");
            this.Property(t => t.OrderWeight).HasColumnName("OrderWeight");
            this.Property(t => t.AffiliateID).HasColumnName("AffiliateID");
            this.Property(t => t.OrderStatusID).HasColumnName("OrderStatusID");
            this.Property(t => t.AllowStoringCreditCardNumber).HasColumnName("AllowStoringCreditCardNumber");
            this.Property(t => t.CardType).HasColumnName("CardType");
            this.Property(t => t.CardName).HasColumnName("CardName");
            this.Property(t => t.CardNumber).HasColumnName("CardNumber");
            this.Property(t => t.MaskedCreditCardNumber).HasColumnName("MaskedCreditCardNumber");
            this.Property(t => t.CardCVV2).HasColumnName("CardCVV2");
            this.Property(t => t.CardExpirationMonth).HasColumnName("CardExpirationMonth");
            this.Property(t => t.CardExpirationYear).HasColumnName("CardExpirationYear");
            this.Property(t => t.PaymentMethodID).HasColumnName("PaymentMethodID");
            this.Property(t => t.PaymentMethodName).HasColumnName("PaymentMethodName");
            this.Property(t => t.AuthorizationTransactionID).HasColumnName("AuthorizationTransactionID");
            this.Property(t => t.AuthorizationTransactionCode).HasColumnName("AuthorizationTransactionCode");
            this.Property(t => t.AuthorizationTransactionResult).HasColumnName("AuthorizationTransactionResult");
            this.Property(t => t.CaptureTransactionID).HasColumnName("CaptureTransactionID");
            this.Property(t => t.CaptureTransactionResult).HasColumnName("CaptureTransactionResult");
            this.Property(t => t.SubscriptionTransactionID).HasColumnName("SubscriptionTransactionID");
            this.Property(t => t.PurchaseOrderNumber).HasColumnName("PurchaseOrderNumber");
            this.Property(t => t.PaymentStatusID).HasColumnName("PaymentStatusID");
            this.Property(t => t.PaidDate).HasColumnName("PaidDate");
            this.Property(t => t.BillingFirstName).HasColumnName("BillingFirstName");
            this.Property(t => t.BillingLastName).HasColumnName("BillingLastName");
            this.Property(t => t.BillingPhoneNumber).HasColumnName("BillingPhoneNumber");
            this.Property(t => t.BillingEmail).HasColumnName("BillingEmail");
            this.Property(t => t.BillingFaxNumber).HasColumnName("BillingFaxNumber");
            this.Property(t => t.BillingCompany).HasColumnName("BillingCompany");
            this.Property(t => t.BillingAddress1).HasColumnName("BillingAddress1");
            this.Property(t => t.BillingAddress2).HasColumnName("BillingAddress2");
            this.Property(t => t.BillingCity).HasColumnName("BillingCity");
            this.Property(t => t.BillingStateProvince).HasColumnName("BillingStateProvince");
            this.Property(t => t.BillingStateProvinceID).HasColumnName("BillingStateProvinceID");
            this.Property(t => t.BillingZipPostalCode).HasColumnName("BillingZipPostalCode");
            this.Property(t => t.BillingCountry).HasColumnName("BillingCountry");
            this.Property(t => t.BillingCountryID).HasColumnName("BillingCountryID");
            this.Property(t => t.ShippingStatusID).HasColumnName("ShippingStatusID");
            this.Property(t => t.ShippingFirstName).HasColumnName("ShippingFirstName");
            this.Property(t => t.ShippingLastName).HasColumnName("ShippingLastName");
            this.Property(t => t.ShippingPhoneNumber).HasColumnName("ShippingPhoneNumber");
            this.Property(t => t.ShippingEmail).HasColumnName("ShippingEmail");
            this.Property(t => t.ShippingFaxNumber).HasColumnName("ShippingFaxNumber");
            this.Property(t => t.ShippingCompany).HasColumnName("ShippingCompany");
            this.Property(t => t.ShippingAddress1).HasColumnName("ShippingAddress1");
            this.Property(t => t.ShippingAddress2).HasColumnName("ShippingAddress2");
            this.Property(t => t.ShippingCity).HasColumnName("ShippingCity");
            this.Property(t => t.ShippingStateProvince).HasColumnName("ShippingStateProvince");
            this.Property(t => t.ShippingStateProvinceID).HasColumnName("ShippingStateProvinceID");
            this.Property(t => t.ShippingZipPostalCode).HasColumnName("ShippingZipPostalCode");
            this.Property(t => t.ShippingCountry).HasColumnName("ShippingCountry");
            this.Property(t => t.ShippingCountryID).HasColumnName("ShippingCountryID");
            this.Property(t => t.ShippingMethod).HasColumnName("ShippingMethod");
            this.Property(t => t.ShippingRateComputationMethodID).HasColumnName("ShippingRateComputationMethodID");
            this.Property(t => t.ShippedDate).HasColumnName("ShippedDate");
            this.Property(t => t.TrackingNumber).HasColumnName("TrackingNumber");
            this.Property(t => t.DeliveryDate).HasColumnName("DeliveryDate");
            this.Property(t => t.Deleted).HasColumnName("Deleted");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");

            // Relationships
            this.HasRequired(t => t.Nop_OrderStatus)
                .WithMany(t => t.Nop_Order)
                .HasForeignKey(d => d.OrderStatusID);
            this.HasRequired(t => t.Nop_PaymentStatus)
                .WithMany(t => t.Nop_Order)
                .HasForeignKey(d => d.PaymentStatusID);
            this.HasRequired(t => t.Nop_ShippingStatus)
                .WithMany(t => t.Nop_Order)
                .HasForeignKey(d => d.ShippingStatusID);

        }
    }
}
