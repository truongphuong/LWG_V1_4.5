using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_DiscountTypeMap : EntityTypeConfiguration<Nop_DiscountType>
    {
        public Nop_DiscountTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.DiscountTypeID);

            // Properties
            this.Property(t => t.DiscountTypeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_DiscountType");
            this.Property(t => t.DiscountTypeID).HasColumnName("DiscountTypeID");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
