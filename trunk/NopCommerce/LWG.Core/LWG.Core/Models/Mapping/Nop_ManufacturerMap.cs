using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ManufacturerMap : EntityTypeConfiguration<Nop_Manufacturer>
    {
        public Nop_ManufacturerMap()
        {
            // Primary Key
            this.HasKey(t => t.ManufacturerID);

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

            this.Property(t => t.PriceRanges)
                .IsRequired()
                .HasMaxLength(400);

            // Table & Column Mappings
            this.ToTable("Nop_Manufacturer");
            this.Property(t => t.ManufacturerID).HasColumnName("ManufacturerID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.TemplateID).HasColumnName("TemplateID");
            this.Property(t => t.MetaKeywords).HasColumnName("MetaKeywords");
            this.Property(t => t.MetaDescription).HasColumnName("MetaDescription");
            this.Property(t => t.MetaTitle).HasColumnName("MetaTitle");
            this.Property(t => t.SEName).HasColumnName("SEName");
            this.Property(t => t.PictureID).HasColumnName("PictureID");
            this.Property(t => t.PageSize).HasColumnName("PageSize");
            this.Property(t => t.PriceRanges).HasColumnName("PriceRanges");
            this.Property(t => t.Published).HasColumnName("Published");
            this.Property(t => t.Deleted).HasColumnName("Deleted");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");

            // Relationships
            this.HasRequired(t => t.Nop_ManufacturerTemplate)
                .WithMany(t => t.Nop_Manufacturer)
                .HasForeignKey(d => d.TemplateID);

        }
    }
}