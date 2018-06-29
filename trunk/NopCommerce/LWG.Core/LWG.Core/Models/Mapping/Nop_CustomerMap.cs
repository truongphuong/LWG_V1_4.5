using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_CustomerMap : EntityTypeConfiguration<Nop_Customer>
    {
        public Nop_CustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.CustomerID);

            // Properties
            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Username)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.SaltKey)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.LastAppliedCouponCode)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.GiftCardCouponCodes)
                .IsRequired();

            this.Property(t => t.CheckoutAttributes)
                .IsRequired();

            this.Property(t => t.Signature)
                .IsRequired()
                .HasMaxLength(300);

            this.Property(t => t.AdminComment)
                .IsRequired()
                .HasMaxLength(4000);

            this.Property(t => t.TimeZoneID)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.DealerID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Nop_Customer");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.CustomerGUID).HasColumnName("CustomerGUID");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Username).HasColumnName("Username");
            this.Property(t => t.PasswordHash).HasColumnName("PasswordHash");
            this.Property(t => t.SaltKey).HasColumnName("SaltKey");
            this.Property(t => t.AffiliateID).HasColumnName("AffiliateID");
            this.Property(t => t.BillingAddressID).HasColumnName("BillingAddressID");
            this.Property(t => t.ShippingAddressID).HasColumnName("ShippingAddressID");
            this.Property(t => t.LastPaymentMethodID).HasColumnName("LastPaymentMethodID");
            this.Property(t => t.LastAppliedCouponCode).HasColumnName("LastAppliedCouponCode");
            this.Property(t => t.GiftCardCouponCodes).HasColumnName("GiftCardCouponCodes");
            this.Property(t => t.CheckoutAttributes).HasColumnName("CheckoutAttributes");
            this.Property(t => t.LanguageID).HasColumnName("LanguageID");
            this.Property(t => t.CurrencyID).HasColumnName("CurrencyID");
            this.Property(t => t.TaxDisplayTypeID).HasColumnName("TaxDisplayTypeID");
            this.Property(t => t.IsTaxExempt).HasColumnName("IsTaxExempt");
            this.Property(t => t.IsAdmin).HasColumnName("IsAdmin");
            this.Property(t => t.IsGuest).HasColumnName("IsGuest");
            this.Property(t => t.IsForumModerator).HasColumnName("IsForumModerator");
            this.Property(t => t.TotalForumPosts).HasColumnName("TotalForumPosts");
            this.Property(t => t.Signature).HasColumnName("Signature");
            this.Property(t => t.AdminComment).HasColumnName("AdminComment");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.Deleted).HasColumnName("Deleted");
            this.Property(t => t.RegistrationDate).HasColumnName("RegistrationDate");
            this.Property(t => t.TimeZoneID).HasColumnName("TimeZoneID");
            this.Property(t => t.AvatarID).HasColumnName("AvatarID");
            this.Property(t => t.DealerID).HasColumnName("DealerID");

            // Relationships
            this.HasMany(t => t.Nop_CustomerRole)
                .WithMany(t => t.Nop_Customer)
                .Map(m =>
                    {
                        m.ToTable("Nop_Customer_CustomerRole_Mapping");
                        m.MapLeftKey("CustomerID");
                        m.MapRightKey("CustomerRoleID");
                    });


        }
    }
}
