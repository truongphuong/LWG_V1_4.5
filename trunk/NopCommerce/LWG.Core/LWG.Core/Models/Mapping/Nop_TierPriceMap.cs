using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_TierPriceMap : EntityTypeConfiguration<Nop_TierPrice>
    {
        public Nop_TierPriceMap()
        {
            // Primary Key
            this.HasKey(t => t.TierPriceID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Nop_TierPrice");
            this.Property(t => t.TierPriceID).HasColumnName("TierPriceID");
            this.Property(t => t.ProductVariantID).HasColumnName("ProductVariantID");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.Price).HasColumnName("Price");

            // Relationships
            this.HasRequired(t => t.Nop_ProductVariant)
                .WithMany(t => t.Nop_TierPrice)
                .HasForeignKey(d => d.ProductVariantID);

        }
    }
}
