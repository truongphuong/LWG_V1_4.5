using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_Product_Category_MappingMap : EntityTypeConfiguration<Nop_Product_Category_Mapping>
    {
        public Nop_Product_Category_MappingMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductCategoryID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Nop_Product_Category_Mapping");
            this.Property(t => t.ProductCategoryID).HasColumnName("ProductCategoryID");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.IsFeaturedProduct).HasColumnName("IsFeaturedProduct");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");

            // Relationships
            this.HasRequired(t => t.Nop_Category)
                .WithMany(t => t.Nop_Product_Category_Mapping)
                .HasForeignKey(d => d.CategoryID);
            this.HasRequired(t => t.Nop_Product)
                .WithMany(t => t.Nop_Product_Category_Mapping)
                .HasForeignKey(d => d.ProductID);

        }
    }
}
