using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_OrderStatusMap : EntityTypeConfiguration<Nop_OrderStatus>
    {
        public Nop_OrderStatusMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderStatusID);

            // Properties
            this.Property(t => t.OrderStatusID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_OrderStatus");
            this.Property(t => t.OrderStatusID).HasColumnName("OrderStatusID");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
