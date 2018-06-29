using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_RecurringPaymentMap : EntityTypeConfiguration<Nop_RecurringPayment>
    {
        public Nop_RecurringPaymentMap()
        {
            // Primary Key
            this.HasKey(t => t.RecurringPaymentID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Nop_RecurringPayment");
            this.Property(t => t.RecurringPaymentID).HasColumnName("RecurringPaymentID");
            this.Property(t => t.InitialOrderID).HasColumnName("InitialOrderID");
            this.Property(t => t.CycleLength).HasColumnName("CycleLength");
            this.Property(t => t.CyclePeriod).HasColumnName("CyclePeriod");
            this.Property(t => t.TotalCycles).HasColumnName("TotalCycles");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.Deleted).HasColumnName("Deleted");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
        }
    }
}
