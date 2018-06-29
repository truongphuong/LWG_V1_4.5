using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_SpecificationAttributeOptionMap : EntityTypeConfiguration<Nop_SpecificationAttributeOption>
    {
        public Nop_SpecificationAttributeOptionMap()
        {
            // Primary Key
            this.HasKey(t => t.SpecificationAttributeOptionID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Nop_SpecificationAttributeOption");
            this.Property(t => t.SpecificationAttributeOptionID).HasColumnName("SpecificationAttributeOptionID");
            this.Property(t => t.SpecificationAttributeID).HasColumnName("SpecificationAttributeID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");

            // Relationships
            this.HasRequired(t => t.Nop_SpecificationAttribute)
                .WithMany(t => t.Nop_SpecificationAttributeOption)
                .HasForeignKey(d => d.SpecificationAttributeID);

        }
    }
}
