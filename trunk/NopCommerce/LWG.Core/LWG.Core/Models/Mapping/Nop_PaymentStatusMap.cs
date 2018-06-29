using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_PaymentStatusMap : EntityTypeConfiguration<Nop_PaymentStatus>
    {
        public Nop_PaymentStatusMap()
        {
            // Primary Key
            this.HasKey(t => t.PaymentStatusID);

            // Properties
            this.Property(t => t.PaymentStatusID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_PaymentStatus");
            this.Property(t => t.PaymentStatusID).HasColumnName("PaymentStatusID");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
