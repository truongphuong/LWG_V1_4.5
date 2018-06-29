using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class lwg_ReprintSourceMappingMap : EntityTypeConfiguration<lwg_ReprintSourceMapping>
    {
        public lwg_ReprintSourceMappingMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("lwg_ReprintSourceMapping");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ReprintSourceID).HasColumnName("ReprintSourceID");
            this.Property(t => t.CatalogID).HasColumnName("CatalogID");

            // Relationships
            this.HasRequired(t => t.lwg_Catalog)
                .WithMany(t => t.lwg_ReprintSourceMapping)
                .HasForeignKey(d => d.CatalogID);
            this.HasRequired(t => t.lwg_ReprintSource)
                .WithMany(t => t.lwg_ReprintSourceMapping)
                .HasForeignKey(d => d.ReprintSourceID);

        }
    }
}
