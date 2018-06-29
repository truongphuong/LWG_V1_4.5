using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ProductLocalizedMap : EntityTypeConfiguration<Nop_ProductLocalized>
    {
        public Nop_ProductLocalizedMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductLocalizedID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(400);

            this.Property(t => t.ShortDescription)
                .IsRequired();

            this.Property(t => t.FullDescription)
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
            this.ToTable("Nop_ProductLocalized");
            this.Property(t => t.ProductLocalizedID).HasColumnName("ProductLocalizedID");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.LanguageID).HasColumnName("LanguageID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ShortDescription).HasColumnName("ShortDescription");
            this.Property(t => t.FullDescription).HasColumnName("FullDescription");
            this.Property(t => t.MetaKeywords).HasColumnName("MetaKeywords");
            this.Property(t => t.MetaDescription).HasColumnName("MetaDescription");
            this.Property(t => t.MetaTitle).HasColumnName("MetaTitle");
            this.Property(t => t.SEName).HasColumnName("SEName");

            // Relationships
            this.HasRequired(t => t.Nop_Language)
                .WithMany(t => t.Nop_ProductLocalized)
                .HasForeignKey(d => d.LanguageID);
            this.HasRequired(t => t.Nop_Product)
                .WithMany(t => t.Nop_ProductLocalized)
                .HasForeignKey(d => d.ProductID);

        }
    }
}
