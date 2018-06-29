using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_RewardPointsHistoryMap : EntityTypeConfiguration<Nop_RewardPointsHistory>
    {
        public Nop_RewardPointsHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.RewardPointsHistoryID);

            // Properties
            this.Property(t => t.CustomerCurrencyCode)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.Message)
                .IsRequired()
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("Nop_RewardPointsHistory");
            this.Property(t => t.RewardPointsHistoryID).HasColumnName("RewardPointsHistoryID");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.Points).HasColumnName("Points");
            this.Property(t => t.PointsBalance).HasColumnName("PointsBalance");
            this.Property(t => t.UsedAmount).HasColumnName("UsedAmount");
            this.Property(t => t.UsedAmountInCustomerCurrency).HasColumnName("UsedAmountInCustomerCurrency");
            this.Property(t => t.CustomerCurrencyCode).HasColumnName("CustomerCurrencyCode");
            this.Property(t => t.Message).HasColumnName("Message");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");

            // Relationships
            this.HasRequired(t => t.Nop_Customer)
                .WithMany(t => t.Nop_RewardPointsHistory)
                .HasForeignKey(d => d.CustomerID);

        }
    }
}
