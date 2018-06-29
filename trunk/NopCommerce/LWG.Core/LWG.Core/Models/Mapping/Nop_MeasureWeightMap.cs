using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_MeasureWeightMap : EntityTypeConfiguration<Nop_MeasureWeight>
    {
        public Nop_MeasureWeightMap()
        {
            // Primary Key
            this.HasKey(t => t.MeasureWeightID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.SystemKeyword)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_MeasureWeight");
            this.Property(t => t.MeasureWeightID).HasColumnName("MeasureWeightID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.SystemKeyword).HasColumnName("SystemKeyword");
            this.Property(t => t.Ratio).HasColumnName("Ratio");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
        }
    }
}
