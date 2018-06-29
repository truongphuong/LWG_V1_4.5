using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class lwg_PeriodMappingMap : EntityTypeConfiguration<lwg_PeriodMapping>
    {
        public lwg_PeriodMappingMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("lwg_PeriodMapping");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PeriodID).HasColumnName("PeriodID");
            this.Property(t => t.CatalogID).HasColumnName("CatalogID");

            // Relationships
            this.HasRequired(t => t.lwg_Catalog)
                .WithMany(t => t.lwg_PeriodMapping)
                .HasForeignKey(d => d.CatalogID);
            this.HasRequired(t => t.lwg_Period)
                .WithMany(t => t.lwg_PeriodMapping)
                .HasForeignKey(d => d.PeriodID);

        }
    }
}
