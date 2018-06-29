using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_LogTypeMap : EntityTypeConfiguration<Nop_LogType>
    {
        public Nop_LogTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.LogTypeID);

            // Properties
            this.Property(t => t.LogTypeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("Nop_LogType");
            this.Property(t => t.LogTypeID).HasColumnName("LogTypeID");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
