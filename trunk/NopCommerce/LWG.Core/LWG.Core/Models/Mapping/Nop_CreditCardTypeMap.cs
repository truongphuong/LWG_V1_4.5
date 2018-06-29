using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_CreditCardTypeMap : EntityTypeConfiguration<Nop_CreditCardType>
    {
        public Nop_CreditCardTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.CreditCardTypeID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.SystemKeyword)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_CreditCardType");
            this.Property(t => t.CreditCardTypeID).HasColumnName("CreditCardTypeID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.SystemKeyword).HasColumnName("SystemKeyword");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
            this.Property(t => t.Deleted).HasColumnName("Deleted");
        }
    }
}
