using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_LowStockActivityMap : EntityTypeConfiguration<Nop_LowStockActivity>
    {
        public Nop_LowStockActivityMap()
        {
            // Primary Key
            this.HasKey(t => t.LowStockActivityID);

            // Properties
            this.Property(t => t.LowStockActivityID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_LowStockActivity");
            this.Property(t => t.LowStockActivityID).HasColumnName("LowStockActivityID");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
