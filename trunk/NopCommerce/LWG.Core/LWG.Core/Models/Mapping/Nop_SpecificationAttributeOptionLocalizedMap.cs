using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_SpecificationAttributeOptionLocalizedMap : EntityTypeConfiguration<Nop_SpecificationAttributeOptionLocalized>
    {
        public Nop_SpecificationAttributeOptionLocalizedMap()
        {
            // Primary Key
            this.HasKey(t => t.SpecificationAttributeOptionLocalizedID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Nop_SpecificationAttributeOptionLocalized");
            this.Property(t => t.SpecificationAttributeOptionLocalizedID).HasColumnName("SpecificationAttributeOptionLocalizedID");
            this.Property(t => t.SpecificationAttributeOptionID).HasColumnName("SpecificationAttributeOptionID");
            this.Property(t => t.LanguageID).HasColumnName("LanguageID");
            this.Property(t => t.Name).HasColumnName("Name");

            // Relationships
            this.HasRequired(t => t.Nop_Language)
                .WithMany(t => t.Nop_SpecificationAttributeOptionLocalized)
                .HasForeignKey(d => d.LanguageID);
            this.HasRequired(t => t.Nop_SpecificationAttributeOption)
                .WithMany(t => t.Nop_SpecificationAttributeOptionLocalized)
                .HasForeignKey(d => d.SpecificationAttributeOptionID);

        }
    }
}
