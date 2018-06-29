using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class lwg_CatalogTitleSearchMap : EntityTypeConfiguration<lwg_CatalogTitleSearch>
    {
        public lwg_CatalogTitleSearchMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(2000);

            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("lwg_CatalogTitleSearch");
            this.Property(t => t.CatalogId).HasColumnName("CatalogId");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Id).HasColumnName("Id");

            // Relationships
            this.HasRequired(t => t.lwg_Catalog)
                .WithMany(t => t.lwg_CatalogTitleSearch)
                .HasForeignKey(d => d.CatalogId);

        }
    }
}
