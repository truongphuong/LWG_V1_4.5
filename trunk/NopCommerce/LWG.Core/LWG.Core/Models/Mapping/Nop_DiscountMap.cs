using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_DiscountMap : EntityTypeConfiguration<Nop_Discount>
    {
        public Nop_DiscountMap()
        {
            // Primary Key
            this.HasKey(t => t.DiscountID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CouponCode)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_Discount");
            this.Property(t => t.DiscountID).HasColumnName("DiscountID");
            this.Property(t => t.DiscountTypeID).HasColumnName("DiscountTypeID");
            this.Property(t => t.DiscountRequirementID).HasColumnName("DiscountRequirementID");
            this.Property(t => t.DiscountLimitationID).HasColumnName("DiscountLimitationID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.UsePercentage).HasColumnName("UsePercentage");
            this.Property(t => t.DiscountPercentage).HasColumnName("DiscountPercentage");
            this.Property(t => t.DiscountAmount).HasColumnName("DiscountAmount");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.RequiresCouponCode).HasColumnName("RequiresCouponCode");
            this.Property(t => t.CouponCode).HasColumnName("CouponCode");
            this.Property(t => t.Deleted).HasColumnName("Deleted");

            // Relationships
            this.HasMany(t => t.Nop_ProductVariant)
                .WithMany(t => t.Nop_Discount)
                .Map(m =>
                    {
                        m.ToTable("Nop_DiscountRestriction");
                        m.MapLeftKey("DiscountID");
                        m.MapRightKey("ProductVariantID");
                    });

            this.HasMany(t => t.Nop_ProductVariant1)
                .WithMany(t => t.Nop_Discount1)
                .Map(m =>
                    {
                        m.ToTable("Nop_ProductVariant_Discount_Mapping");
                        m.MapLeftKey("DiscountID");
                        m.MapRightKey("ProductVariantID");
                    });

            this.HasRequired(t => t.Nop_DiscountLimitation)
                .WithMany(t => t.Nop_Discount)
                .HasForeignKey(d => d.DiscountLimitationID);
            this.HasRequired(t => t.Nop_DiscountRequirement)
                .WithMany(t => t.Nop_Discount)
                .HasForeignKey(d => d.DiscountRequirementID);
            this.HasRequired(t => t.Nop_DiscountType)
                .WithMany(t => t.Nop_Discount)
                .HasForeignKey(d => d.DiscountTypeID);

        }
    }
}
