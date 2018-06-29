using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class lwg_AudioMap : EntityTypeConfiguration<lwg_Audio>
    {
        public lwg_AudioMap()
        {
            // Primary Key
            this.HasKey(t => t.AudioId);

            // Properties
            this.Property(t => t.SoundFile)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("lwg_Audio");
            this.Property(t => t.AudioId).HasColumnName("AudioId");
            this.Property(t => t.CatalogId).HasColumnName("CatalogId");
            this.Property(t => t.SoundFile).HasColumnName("SoundFile");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");

            // Relationships
            this.HasRequired(t => t.lwg_Catalog)
                .WithMany(t => t.lwg_Audio)
                .HasForeignKey(d => d.CatalogId);

        }
    }
}
