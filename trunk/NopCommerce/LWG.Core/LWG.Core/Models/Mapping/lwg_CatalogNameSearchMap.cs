using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class lwg_CatalogNameSearchMap : EntityTypeConfiguration<lwg_CatalogNameSearch>
    {
        public lwg_CatalogNameSearchMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(2000);

            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("lwg_CatalogNameSearch");
            this.Property(t => t.CatalogId).HasColumnName("CatalogId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Id).HasColumnName("Id");

            // Relationships
            this.HasRequired(t => t.lwg_Catalog)
                .WithMany(t => t.lwg_CatalogNameSearch)
                .HasForeignKey(d => d.CatalogId);

        }
    }
}
