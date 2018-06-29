using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ProductVariantAttributeCombinationMap : EntityTypeConfiguration<Nop_ProductVariantAttributeCombination>
    {
        public Nop_ProductVariantAttributeCombinationMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductVariantAttributeCombinationID);

            // Properties
            this.Property(t => t.AttributesXML)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Nop_ProductVariantAttributeCombination");
            this.Property(t => t.ProductVariantAttributeCombinationID).HasColumnName("ProductVariantAttributeCombinationID");
            this.Property(t => t.ProductVariantID).HasColumnName("ProductVariantID");
            this.Property(t => t.AttributesXML).HasColumnName("AttributesXML");
            this.Property(t => t.StockQuantity).HasColumnName("StockQuantity");
            this.Property(t => t.AllowOutOfStockOrders).HasColumnName("AllowOutOfStockOrders");

            // Relationships
            this.HasRequired(t => t.Nop_ProductVariant)
                .WithMany(t => t.Nop_ProductVariantAttributeCombination)
                .HasForeignKey(d => d.ProductVariantID);

        }
    }
}
