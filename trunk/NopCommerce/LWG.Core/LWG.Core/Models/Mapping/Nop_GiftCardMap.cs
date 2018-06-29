using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_GiftCardMap : EntityTypeConfiguration<Nop_GiftCard>
    {
        public Nop_GiftCardMap()
        {
            // Primary Key
            this.HasKey(t => t.GiftCardID);

            // Properties
            this.Property(t => t.GiftCardCouponCode)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.RecipientName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.RecipientEmail)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.SenderName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.SenderEmail)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Message)
                .IsRequired()
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("Nop_GiftCard");
            this.Property(t => t.GiftCardID).HasColumnName("GiftCardID");
            this.Property(t => t.PurchasedOrderProductVariantID).HasColumnName("PurchasedOrderProductVariantID");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.IsGiftCardActivated).HasColumnName("IsGiftCardActivated");
            this.Property(t => t.GiftCardCouponCode).HasColumnName("GiftCardCouponCode");
            this.Property(t => t.RecipientName).HasColumnName("RecipientName");
            this.Property(t => t.RecipientEmail).HasColumnName("RecipientEmail");
            this.Property(t => t.SenderName).HasColumnName("SenderName");
            this.Property(t => t.SenderEmail).HasColumnName("SenderEmail");
            this.Property(t => t.Message).HasColumnName("Message");
            this.Property(t => t.IsRecipientNotified).HasColumnName("IsRecipientNotified");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");

            // Relationships
            this.HasRequired(t => t.Nop_OrderProductVariant)
                .WithMany(t => t.Nop_GiftCard)
                .HasForeignKey(d => d.PurchasedOrderProductVariantID);

        }
    }
}
