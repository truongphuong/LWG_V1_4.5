using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ShoppingCartTypeMap : EntityTypeConfiguration<Nop_ShoppingCartType>
    {
        public Nop_ShoppingCartTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ShoppingCartTypeID);

            // Properties
            this.Property(t => t.ShoppingCartTypeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_ShoppingCartType");
            this.Property(t => t.ShoppingCartTypeID).HasColumnName("ShoppingCartTypeID");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
