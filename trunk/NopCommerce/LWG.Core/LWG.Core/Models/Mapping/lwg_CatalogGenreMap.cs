using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class lwg_CatalogGenreMap : EntityTypeConfiguration<lwg_CatalogGenre>
    {
        public lwg_CatalogGenreMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("lwg_CatalogGenre");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CatalogId).HasColumnName("CatalogId");
            this.Property(t => t.GerneId).HasColumnName("GerneId");

            // Relationships
            this.HasRequired(t => t.lwg_Catalog)
                .WithMany(t => t.lwg_CatalogGenre)
                .HasForeignKey(d => d.CatalogId);
            this.HasRequired(t => t.lwg_Genre)
                .WithMany(t => t.lwg_CatalogGenre)
                .HasForeignKey(d => d.GerneId);

        }
    }
}
