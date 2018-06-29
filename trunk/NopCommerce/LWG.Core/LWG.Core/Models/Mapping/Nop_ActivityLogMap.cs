using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ActivityLogMap : EntityTypeConfiguration<Nop_ActivityLog>
    {
        public Nop_ActivityLogMap()
        {
            // Primary Key
            this.HasKey(t => t.ActivityLogID);

            // Properties
            this.Property(t => t.Comment)
                .IsRequired()
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("Nop_ActivityLog");
            this.Property(t => t.ActivityLogID).HasColumnName("ActivityLogID");
            this.Property(t => t.ActivityLogTypeID).HasColumnName("ActivityLogTypeID");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");

            // Relationships
            this.HasRequired(t => t.Nop_ActivityLogType)
                .WithMany(t => t.Nop_ActivityLog)
                .HasForeignKey(d => d.ActivityLogTypeID);
            this.HasRequired(t => t.Nop_Customer)
                .WithMany(t => t.Nop_ActivityLog)
                .HasForeignKey(d => d.CustomerID);

        }
    }
}
