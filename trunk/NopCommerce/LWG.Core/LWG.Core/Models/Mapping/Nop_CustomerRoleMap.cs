using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_CustomerRoleMap : EntityTypeConfiguration<Nop_CustomerRole>
    {
        public Nop_CustomerRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.CustomerRoleID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Nop_CustomerRole");
            this.Property(t => t.CustomerRoleID).HasColumnName("CustomerRoleID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.FreeShipping).HasColumnName("FreeShipping");
            this.Property(t => t.TaxExempt).HasColumnName("TaxExempt");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.Deleted).HasColumnName("Deleted");
        }
    }
}
