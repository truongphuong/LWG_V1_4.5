using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_Product_SpecificationAttribute_MappingMap : EntityTypeConfiguration<Nop_Product_SpecificationAttribute_Mapping>
    {
        public Nop_Product_SpecificationAttribute_MappingMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductSpecificationAttributeID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Nop_Product_SpecificationAttribute_Mapping");
            this.Property(t => t.ProductSpecificationAttributeID).HasColumnName("ProductSpecificationAttributeID");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.SpecificationAttributeOptionID).HasColumnName("SpecificationAttributeOptionID");
            this.Property(t => t.AllowFiltering).HasColumnName("AllowFiltering");
            this.Property(t => t.ShowOnProductPage).HasColumnName("ShowOnProductPage");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");

            // Relationships
            this.HasRequired(t => t.Nop_Product)
                .WithMany(t => t.Nop_Product_SpecificationAttribute_Mapping)
                .HasForeignKey(d => d.ProductID);
            this.HasRequired(t => t.Nop_SpecificationAttributeOption)
                .WithMany(t => t.Nop_Product_SpecificationAttribute_Mapping)
                .HasForeignKey(d => d.SpecificationAttributeOptionID);

        }
    }
}
