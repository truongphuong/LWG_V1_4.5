using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_CategoryLocalizedMap : EntityTypeConfiguration<Nop_CategoryLocalized>
    {
        public Nop_CategoryLocalizedMap()
        {
            // Primary Key
            this.HasKey(t => t.CategoryLocalizedID);

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
            this.ToTable("Nop_CategoryLocalized");
            this.Property(t => t.CategoryLocalizedID).HasColumnName("CategoryLocalizedID");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.LanguageID).HasColumnName("LanguageID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.MetaKeywords).HasColumnName("MetaKeywords");
            this.Property(t => t.MetaDescription).HasColumnName("MetaDescription");
            this.Property(t => t.MetaTitle).HasColumnName("MetaTitle");
            this.Property(t => t.SEName).HasColumnName("SEName");

            // Relationships
            this.HasRequired(t => t.Nop_Category)
                .WithMany(t => t.Nop_CategoryLocalized)
                .HasForeignKey(d => d.CategoryID);
            this.HasRequired(t => t.Nop_Language)
                .WithMany(t => t.Nop_CategoryLocalized)
                .HasForeignKey(d => d.LanguageID);

        }
    }
}
