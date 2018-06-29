using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class lwg_CatalogPublisherMap : EntityTypeConfiguration<lwg_CatalogPublisher>
    {
        public lwg_CatalogPublisherMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("lwg_CatalogPublisher");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CatalogId).HasColumnName("CatalogId");
            this.Property(t => t.PublisherId).HasColumnName("PublisherId");

            // Relationships
            this.HasRequired(t => t.lwg_Catalog)
                .WithMany(t => t.lwg_CatalogPublisher)
                .HasForeignKey(d => d.CatalogId);
            this.HasRequired(t => t.lwg_Publisher)
                .WithMany(t => t.lwg_CatalogPublisher)
                .HasForeignKey(d => d.PublisherId);

        }
    }
}
