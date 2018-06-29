using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_CustomerRole_Discount_MappingMap : EntityTypeConfiguration<Nop_CustomerRole_Discount_Mapping>
    {
        public Nop_CustomerRole_Discount_MappingMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CustomerRoleID, t.DiscountID });

            // Properties
            this.Property(t => t.CustomerRoleID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DiscountID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Nop_CustomerRole_Discount_Mapping");
            this.Property(t => t.CustomerRoleID).HasColumnName("CustomerRoleID");
            this.Property(t => t.DiscountID).HasColumnName("DiscountID");
        }
    }
}
