using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class lwg_SeriesMap : EntityTypeConfiguration<lwg_Series>
    {
        public lwg_SeriesMap()
        {
            // Primary Key
            this.HasKey(t => t.SeriesId);

            // Properties
            this.Property(t => t.SeriesId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("lwg_Series");
            this.Property(t => t.SeriesId).HasColumnName("SeriesId");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
