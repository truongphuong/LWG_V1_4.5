using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ProductTagMap : EntityTypeConfiguration<Nop_ProductTag>
    {
        public Nop_ProductTagMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductTagID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_ProductTag");
            this.Property(t => t.ProductTagID).HasColumnName("ProductTagID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ProductCount).HasColumnName("ProductCount");
        }
    }
}
