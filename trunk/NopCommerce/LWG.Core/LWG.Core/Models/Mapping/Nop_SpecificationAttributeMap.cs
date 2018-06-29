using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_SpecificationAttributeMap : EntityTypeConfiguration<Nop_SpecificationAttribute>
    {
        public Nop_SpecificationAttributeMap()
        {
            // Primary Key
            this.HasKey(t => t.SpecificationAttributeID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_SpecificationAttribute");
            this.Property(t => t.SpecificationAttributeID).HasColumnName("SpecificationAttributeID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
        }
    }
}
