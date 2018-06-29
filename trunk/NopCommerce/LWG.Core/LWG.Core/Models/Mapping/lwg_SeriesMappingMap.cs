using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class lwg_SeriesMappingMap : EntityTypeConfiguration<lwg_SeriesMapping>
    {
        public lwg_SeriesMappingMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("lwg_SeriesMapping");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SeriesID).HasColumnName("SeriesID");
            this.Property(t => t.CatalogID).HasColumnName("CatalogID");

            // Relationships
            this.HasRequired(t => t.lwg_Catalog)
                .WithMany(t => t.lwg_SeriesMapping)
                .HasForeignKey(d => d.CatalogID);
            this.HasRequired(t => t.lwg_Series)
                .WithMany(t => t.lwg_SeriesMapping)
                .HasForeignKey(d => d.SeriesID);

        }
    }
}
