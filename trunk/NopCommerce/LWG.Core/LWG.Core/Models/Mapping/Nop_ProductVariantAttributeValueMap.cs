using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ProductVariantAttributeValueMap : EntityTypeConfiguration<Nop_ProductVariantAttributeValue>
    {
        public Nop_ProductVariantAttributeValueMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductVariantAttributeValueID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_ProductVariantAttributeValue");
            this.Property(t => t.ProductVariantAttributeValueID).HasColumnName("ProductVariantAttributeValueID");
            this.Property(t => t.ProductVariantAttributeID).HasColumnName("ProductVariantAttributeID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.PriceAdjustment).HasColumnName("PriceAdjustment");
            this.Property(t => t.WeightAdjustment).HasColumnName("WeightAdjustment");
            this.Property(t => t.IsPreSelected).HasColumnName("IsPreSelected");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");

            // Relationships
            this.HasRequired(t => t.Nop_ProductVariant_ProductAttribute_Mapping)
                .WithMany(t => t.Nop_ProductVariantAttributeValue)
                .HasForeignKey(d => d.ProductVariantAttributeID);

        }
    }
}
