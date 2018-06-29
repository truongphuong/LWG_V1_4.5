using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_RelatedProductMap : EntityTypeConfiguration<Nop_RelatedProduct>
    {
        public Nop_RelatedProductMap()
        {
            // Primary Key
            this.HasKey(t => t.RelatedProductID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Nop_RelatedProduct");
            this.Property(t => t.RelatedProductID).HasColumnName("RelatedProductID");
            this.Property(t => t.ProductID1).HasColumnName("ProductID1");
            this.Property(t => t.ProductID2).HasColumnName("ProductID2");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");

            // Relationships
            this.HasRequired(t => t.Nop_Product)
                .WithMany(t => t.Nop_RelatedProduct)
                .HasForeignKey(d => d.ProductID1);

        }
    }
}
