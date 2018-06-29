using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ManufacturerLocalizedMap : EntityTypeConfiguration<Nop_ManufacturerLocalized>
    {
        public Nop_ManufacturerLocalizedMap()
        {
            // Primary Key
            this.HasKey(t => t.ManufacturerLocalizedID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(400);

            this.Property(t => t.Description)
                .IsRequired();

            this.Property(t => t.MetaKeywords)
                .IsRequired()
                .HasMaxLength(400);

            this.Property(t => t.MetaDescription)
                .IsRequired()
                .HasMaxLength(4000);

            this.Property(t => t.MetaTitle)
                .IsRequired()
                .HasMaxLength(400);

            this.Property(t => t.SEName)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_ManufacturerLocalized");
            this.Property(t => t.ManufacturerLocalizedID).HasColumnName("ManufacturerLocalizedID");
            this.Property(t => t.ManufacturerID).HasColumnName("ManufacturerID");
            this.Property(t => t.LanguageID).HasColumnName("LanguageID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.MetaKeywords).HasColumnName("MetaKeywords");
            this.Property(t => t.MetaDescription).HasColumnName("MetaDescription");
            this.Property(t => t.MetaTitle).HasColumnName("MetaTitle");
            this.Property(t => t.SEName).HasColumnName("SEName");

            // Relationships
            this.HasRequired(t => t.Nop_Language)
                .WithMany(t => t.Nop_ManufacturerLocalized)
                .HasForeignKey(d => d.LanguageID);
            this.HasRequired(t => t.Nop_Manufacturer)
                .WithMany(t => t.Nop_ManufacturerLocalized)
                .HasForeignKey(d => d.ManufacturerID);

        }
    }
}
