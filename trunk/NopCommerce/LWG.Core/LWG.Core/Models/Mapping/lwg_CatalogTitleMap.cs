using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class lwg_CatalogTitleMap : EntityTypeConfiguration<lwg_CatalogTitle>
    {
        public lwg_CatalogTitleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("lwg_CatalogTitle");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CatalogId).HasColumnName("CatalogId");
            this.Property(t => t.InstrTitleId).HasColumnName("InstrTitleId");

            // Relationships
            this.HasRequired(t => t.lwg_Catalog)
                .WithMany(t => t.lwg_CatalogTitle)
                .HasForeignKey(d => d.CatalogId);
            this.HasRequired(t => t.lwg_InstrTitle)
                .WithMany(t => t.lwg_CatalogTitle)
                .HasForeignKey(d => d.InstrTitleId);

        }
    }
}
