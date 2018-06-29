using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class lwg_CatalogInstrumentSearchMap : EntityTypeConfiguration<lwg_CatalogInstrumentSearch>
    {
        public lwg_CatalogInstrumentSearchMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.IntrText)
                .IsRequired()
                .HasMaxLength(2000);

            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("lwg_CatalogInstrumentSearch");
            this.Property(t => t.CatalogId).HasColumnName("CatalogId");
            this.Property(t => t.IntrText).HasColumnName("IntrText");
            this.Property(t => t.Id).HasColumnName("Id");

            // Relationships
            this.HasRequired(t => t.lwg_Catalog)
                .WithMany(t => t.lwg_CatalogInstrumentSearch)
                .HasForeignKey(d => d.CatalogId);

        }
    }
}
