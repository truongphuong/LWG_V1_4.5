using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_CategoryTemplateMap : EntityTypeConfiguration<Nop_CategoryTemplate>
    {
        public Nop_CategoryTemplateMap()
        {
            // Primary Key
            this.HasKey(t => t.CategoryTemplateId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.TemplatePath)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Nop_CategoryTemplate");
            this.Property(t => t.CategoryTemplateId).HasColumnName("CategoryTemplateId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.TemplatePath).HasColumnName("TemplatePath");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");
        }
    }
}
