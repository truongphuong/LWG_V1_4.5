using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_Category_Discount_MappingMap : EntityTypeConfiguration<Nop_Category_Discount_Mapping>
    {
        public Nop_Category_Discount_MappingMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CategoryID, t.DiscountID });

            // Properties
            this.Property(t => t.CategoryID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DiscountID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Nop_Category_Discount_Mapping");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.DiscountID).HasColumnName("DiscountID");
        }
    }
}
