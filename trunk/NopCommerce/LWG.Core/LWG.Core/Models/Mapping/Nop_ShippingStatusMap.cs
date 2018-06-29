using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ShippingStatusMap : EntityTypeConfiguration<Nop_ShippingStatus>
    {
        public Nop_ShippingStatusMap()
        {
            // Primary Key
            this.HasKey(t => t.ShippingStatusID);

            // Properties
            this.Property(t => t.ShippingStatusID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_ShippingStatus");
            this.Property(t => t.ShippingStatusID).HasColumnName("ShippingStatusID");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
