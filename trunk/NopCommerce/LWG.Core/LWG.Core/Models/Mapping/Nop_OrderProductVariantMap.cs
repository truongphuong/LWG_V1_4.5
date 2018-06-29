using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_OrderProductVariantMap : EntityTypeConfiguration<Nop_OrderProductVariant>
    {
        public Nop_OrderProductVariantMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderProductVariantID);

            // Properties
            this.Property(t => t.AttributeDescription)
                .IsRequired()
                .HasMaxLength(4000);

            this.Property(t => t.AttributesXML)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Nop_OrderProductVariant");
            this.Property(t => t.OrderProductVariantID).HasColumnName("OrderProductVariantID");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.ProductVariantID).HasColumnName("ProductVariantID");
            this.Property(t => t.UnitPriceInclTax).HasColumnName("UnitPriceInclTax");
            this.Property(t => t.UnitPriceExclTax).HasColumnName("UnitPriceExclTax");
            this.Property(t => t.PriceInclTax).HasColumnName("PriceInclTax");
            this.Property(t => t.PriceExclTax).HasColumnName("PriceExclTax");
            this.Property(t => t.UnitPriceInclTaxInCustomerCurrency).HasColumnName("UnitPriceInclTaxInCustomerCurrency");
            this.Property(t => t.UnitPriceExclTaxInCustomerCurrency).HasColumnName("UnitPriceExclTaxInCustomerCurrency");
            this.Property(t => t.PriceInclTaxInCustomerCurrency).HasColumnName("PriceInclTaxInCustomerCurrency");
            this.Property(t => t.PriceExclTaxInCustomerCurrency).HasColumnName("PriceExclTaxInCustomerCurrency");
            this.Property(t => t.AttributeDescription).HasColumnName("AttributeDescription");
            this.Property(t => t.AttributesXML).HasColumnName("AttributesXML");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.DiscountAmountInclTax).HasColumnName("DiscountAmountInclTax");
            this.Property(t => t.DiscountAmountExclTax).HasColumnName("DiscountAmountExclTax");
            this.Property(t => t.DownloadCount).HasColumnName("DownloadCount");
            this.Property(t => t.OrderProductVariantGUID).HasColumnName("OrderProductVariantGUID");
            this.Property(t => t.IsDownloadActivated).HasColumnName("IsDownloadActivated");
            this.Property(t => t.LicenseDownloadID).HasColumnName("LicenseDownloadID");

            // Relationships
            this.HasRequired(t => t.Nop_Order)
                .WithMany(t => t.Nop_OrderProductVariant)
                .HasForeignKey(d => d.OrderID);
            this.HasRequired(t => t.Nop_ProductVariant)
                .WithMany(t => t.Nop_OrderProductVariant)
                .HasForeignKey(d => d.ProductVariantID);

        }
    }
}
