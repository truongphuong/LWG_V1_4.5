using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_GiftCardUsageHistoryMap : EntityTypeConfiguration<Nop_GiftCardUsageHistory>
    {
        public Nop_GiftCardUsageHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.GiftCardUsageHistoryID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Nop_GiftCardUsageHistory");
            this.Property(t => t.GiftCardUsageHistoryID).HasColumnName("GiftCardUsageHistoryID");
            this.Property(t => t.GiftCardID).HasColumnName("GiftCardID");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.UsedValue).HasColumnName("UsedValue");
            this.Property(t => t.UsedValueInCustomerCurrency).HasColumnName("UsedValueInCustomerCurrency");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");

            // Relationships
            this.HasRequired(t => t.Nop_Customer)
                .WithMany(t => t.Nop_GiftCardUsageHistory)
                .HasForeignKey(d => d.CustomerID);
            this.HasRequired(t => t.Nop_GiftCard)
                .WithMany(t => t.Nop_GiftCardUsageHistory)
                .HasForeignKey(d => d.GiftCardID);

        }
    }
}
