using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class lwg_InstrumentalMap : EntityTypeConfiguration<lwg_Instrumental>
    {
        public lwg_InstrumentalMap()
        {
            // Primary Key
            this.HasKey(t => t.InstrumentalId);

            // Properties
            this.Property(t => t.InstrumentalId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ShortName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.LongName)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("lwg_Instrumental");
            this.Property(t => t.InstrumentalId).HasColumnName("InstrumentalId");
            this.Property(t => t.ShortName).HasColumnName("ShortName");
            this.Property(t => t.LongName).HasColumnName("LongName");
        }
    }
}
