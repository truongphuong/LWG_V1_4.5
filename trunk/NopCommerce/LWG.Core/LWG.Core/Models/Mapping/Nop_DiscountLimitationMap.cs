using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_DiscountLimitationMap : EntityTypeConfiguration<Nop_DiscountLimitation>
    {
        public Nop_DiscountLimitationMap()
        {
            // Primary Key
            this.HasKey(t => t.DiscountLimitationID);

            // Properties
            this.Property(t => t.DiscountLimitationID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_DiscountLimitation");
            this.Property(t => t.DiscountLimitationID).HasColumnName("DiscountLimitationID");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
