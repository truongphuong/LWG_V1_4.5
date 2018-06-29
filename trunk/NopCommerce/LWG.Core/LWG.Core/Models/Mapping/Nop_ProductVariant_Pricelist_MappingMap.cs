using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ProductVariant_Pricelist_MappingMap : EntityTypeConfiguration<Nop_ProductVariant_Pricelist_Mapping>
    {
        public Nop_ProductVariant_Pricelist_MappingMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductVariantPricelistID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Nop_ProductVariant_Pricelist_Mapping");
            this.Property(t => t.ProductVariantPricelistID).HasColumnName("ProductVariantPricelistID");
            this.Property(t => t.ProductVariantID).HasColumnName("ProductVariantID");
            this.Property(t => t.PricelistID).HasColumnName("PricelistID");
            this.Property(t => t.PriceAdjustmentTypeID).HasColumnName("PriceAdjustmentTypeID");
            this.Property(t => t.PriceAdjustment).HasColumnName("PriceAdjustment");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");

            // Relationships
            this.HasRequired(t => t.Nop_Pricelist)
                .WithMany(t => t.Nop_ProductVariant_Pricelist_Mapping)
                .HasForeignKey(d => d.PricelistID);
            this.HasRequired(t => t.Nop_ProductVariant)
                .WithMany(t => t.Nop_ProductVariant_Pricelist_Mapping)
                .HasForeignKey(d => d.ProductVariantID);

        }
    }
}
