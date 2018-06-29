using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class lwg_PeriodMap : EntityTypeConfiguration<lwg_Period>
    {
        public lwg_PeriodMap()
        {
            // Primary Key
            this.HasKey(t => t.PeriodId);

            // Properties
            this.Property(t => t.PeriodId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("lwg_Period");
            this.Property(t => t.PeriodId).HasColumnName("PeriodId");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
