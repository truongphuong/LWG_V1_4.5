using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class lwg_ReprintSourceMap : EntityTypeConfiguration<lwg_ReprintSource>
    {
        public lwg_ReprintSourceMap()
        {
            // Primary Key
            this.HasKey(t => t.ReprintSourceId);

            // Properties
            this.Property(t => t.ReprintSourceId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("lwg_ReprintSource");
            this.Property(t => t.ReprintSourceId).HasColumnName("ReprintSourceId");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
