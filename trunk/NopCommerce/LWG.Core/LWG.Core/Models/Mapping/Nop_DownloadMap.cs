using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_DownloadMap : EntityTypeConfiguration<Nop_Download>
    {
        public Nop_DownloadMap()
        {
            // Primary Key
            this.HasKey(t => t.DownloadID);

            // Properties
            this.Property(t => t.DownloadURL)
                .IsRequired()
                .HasMaxLength(400);

            this.Property(t => t.ContentType)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Filename)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Extension)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Nop_Download");
            this.Property(t => t.DownloadID).HasColumnName("DownloadID");
            this.Property(t => t.UseDownloadURL).HasColumnName("UseDownloadURL");
            this.Property(t => t.DownloadURL).HasColumnName("DownloadURL");
            this.Property(t => t.DownloadBinary).HasColumnName("DownloadBinary");
            this.Property(t => t.ContentType).HasColumnName("ContentType");
            this.Property(t => t.Filename).HasColumnName("Filename");
            this.Property(t => t.Extension).HasColumnName("Extension");
            this.Property(t => t.IsNew).HasColumnName("IsNew");
        }
    }
}
