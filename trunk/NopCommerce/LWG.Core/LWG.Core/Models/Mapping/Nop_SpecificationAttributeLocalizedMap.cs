using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_SpecificationAttributeLocalizedMap : EntityTypeConfiguration<Nop_SpecificationAttributeLocalized>
    {
        public Nop_SpecificationAttributeLocalizedMap()
        {
            // Primary Key
            this.HasKey(t => t.SpecificationAttributeLocalizedID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_SpecificationAttributeLocalized");
            this.Property(t => t.SpecificationAttributeLocalizedID).HasColumnName("SpecificationAttributeLocalizedID");
            this.Property(t => t.SpecificationAttributeID).HasColumnName("SpecificationAttributeID");
            this.Property(t => t.LanguageID).HasColumnName("LanguageID");
            this.Property(t => t.Name).HasColumnName("Name");

            // Relationships
            this.HasRequired(t => t.Nop_Language)
                .WithMany(t => t.Nop_SpecificationAttributeLocalized)
                .HasForeignKey(d => d.LanguageID);
            this.HasRequired(t => t.Nop_SpecificationAttribute)
                .WithMany(t => t.Nop_SpecificationAttributeLocalized)
                .HasForeignKey(d => d.SpecificationAttributeID);

        }
    }
}
