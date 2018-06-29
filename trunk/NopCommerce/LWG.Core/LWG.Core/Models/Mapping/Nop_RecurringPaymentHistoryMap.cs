using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_RecurringPaymentHistoryMap : EntityTypeConfiguration<Nop_RecurringPaymentHistory>
    {
        public Nop_RecurringPaymentHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.RecurringPaymentHistoryID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Nop_RecurringPaymentHistory");
            this.Property(t => t.RecurringPaymentHistoryID).HasColumnName("RecurringPaymentHistoryID");
            this.Property(t => t.RecurringPaymentID).HasColumnName("RecurringPaymentID");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");

            // Relationships
            this.HasRequired(t => t.Nop_RecurringPayment)
                .WithMany(t => t.Nop_RecurringPaymentHistory)
                .HasForeignKey(d => d.RecurringPaymentID);

        }
    }
}
