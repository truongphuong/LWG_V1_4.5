using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_LogMap : EntityTypeConfiguration<Nop_Log>
    {
        public Nop_LogMap()
        {
            // Primary Key
            this.HasKey(t => t.LogID);

            // Properties
            this.Property(t => t.Message)
                .IsRequired()
                .HasMaxLength(1000);

            this.Property(t => t.Exception)
                .IsRequired()
                .HasMaxLength(4000);

            this.Property(t => t.IPAddress)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.PageURL)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ReferrerURL)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_Log");
            this.Property(t => t.LogID).HasColumnName("LogID");
            this.Property(t => t.LogTypeID).HasColumnName("LogTypeID");
            this.Property(t => t.Severity).HasColumnName("Severity");
            this.Property(t => t.Message).HasColumnName("Message");
            this.Property(t => t.Exception).HasColumnName("Exception");
            this.Property(t => t.IPAddress).HasColumnName("IPAddress");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.PageURL).HasColumnName("PageURL");
            this.Property(t => t.ReferrerURL).HasColumnName("ReferrerURL");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");

            // Relationships
            this.HasRequired(t => t.Nop_LogType)
                .WithMany(t => t.Nop_Log)
                .HasForeignKey(d => d.LogTypeID);

        }
    }
}
