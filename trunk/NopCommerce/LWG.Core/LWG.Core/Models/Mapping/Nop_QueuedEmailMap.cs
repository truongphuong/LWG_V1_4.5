using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_QueuedEmailMap : EntityTypeConfiguration<Nop_QueuedEmail>
    {
        public Nop_QueuedEmailMap()
        {
            // Primary Key
            this.HasKey(t => t.QueuedEmailID);

            // Properties
            this.Property(t => t.From)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.FromName)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.To)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.ToName)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.Cc)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.Bcc)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.Subject)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.Body)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Nop_QueuedEmail");
            this.Property(t => t.QueuedEmailID).HasColumnName("QueuedEmailID");
            this.Property(t => t.Priority).HasColumnName("Priority");
            this.Property(t => t.From).HasColumnName("From");
            this.Property(t => t.FromName).HasColumnName("FromName");
            this.Property(t => t.To).HasColumnName("To");
            this.Property(t => t.ToName).HasColumnName("ToName");
            this.Property(t => t.Cc).HasColumnName("Cc");
            this.Property(t => t.Bcc).HasColumnName("Bcc");
            this.Property(t => t.Subject).HasColumnName("Subject");
            this.Property(t => t.Body).HasColumnName("Body");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.SendTries).HasColumnName("SendTries");
            this.Property(t => t.SentOn).HasColumnName("SentOn");
        }
    }
}
