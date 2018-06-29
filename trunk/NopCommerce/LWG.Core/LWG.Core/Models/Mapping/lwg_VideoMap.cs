using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class lwg_VideoMap : EntityTypeConfiguration<lwg_Video>
    {
        public lwg_VideoMap()
        {
            // Primary Key
            this.HasKey(t => t.VideoId);

            // Properties
            this.Property(t => t.QTFile)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("lwg_Video");
            this.Property(t => t.VideoId).HasColumnName("VideoId");
            this.Property(t => t.CatalogId).HasColumnName("CatalogId");
            this.Property(t => t.QTFile).HasColumnName("QTFile");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");

            // Relationships
            this.HasRequired(t => t.lwg_Catalog)
                .WithMany(t => t.lwg_Video)
                .HasForeignKey(d => d.CatalogId);

        }
    }
}
