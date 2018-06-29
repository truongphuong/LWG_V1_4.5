using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_MeasureDimensionMap : EntityTypeConfiguration<Nop_MeasureDimension>
    {
        public Nop_MeasureDimensionMap()
        {
            // Primary Key
            this.HasKey(t => t.MeasureDimensionID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.SystemKeyword)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_MeasureDimension");
            this.Property(t => t.MeasureDimensionID).HasColumnName("MeasureDimensionID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.SystemKeyword).HasColumnName("SystemKeyword");
            this.Property(t => t.Ratio).HasColumnName("Ratio");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
        }
    }
}
