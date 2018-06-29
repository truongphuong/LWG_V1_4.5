using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ActivityLogTypeMap : EntityTypeConfiguration<Nop_ActivityLogType>
    {
        public Nop_ActivityLogTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ActivityLogTypeID);

            // Properties
            this.Property(t => t.SystemKeyword)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_ActivityLogType");
            this.Property(t => t.ActivityLogTypeID).HasColumnName("ActivityLogTypeID");
            this.Property(t => t.SystemKeyword).HasColumnName("SystemKeyword");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Enabled).HasColumnName("Enabled");
        }
    }
}
