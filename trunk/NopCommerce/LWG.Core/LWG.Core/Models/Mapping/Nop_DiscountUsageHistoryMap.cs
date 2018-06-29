using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_DiscountUsageHistoryMap : EntityTypeConfiguration<Nop_DiscountUsageHistory>
    {
        public Nop_DiscountUsageHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.DiscountUsageHistoryID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Nop_DiscountUsageHistory");
            this.Property(t => t.DiscountUsageHistoryID).HasColumnName("DiscountUsageHistoryID");
            this.Property(t => t.DiscountID).HasColumnName("DiscountID");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");

            // Relationships
            this.HasRequired(t => t.Nop_Customer)
                .WithMany(t => t.Nop_DiscountUsageHistory)
                .HasForeignKey(d => d.CustomerID);
            this.HasRequired(t => t.Nop_Discount)
                .WithMany(t => t.Nop_DiscountUsageHistory)
                .HasForeignKey(d => d.DiscountID);
            this.HasRequired(t => t.Nop_Order)
                .WithMany(t => t.Nop_DiscountUsageHistory)
                .HasForeignKey(d => d.OrderID);

        }
    }
}
