using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_DiscountRequirementMap : EntityTypeConfiguration<Nop_DiscountRequirement>
    {
        public Nop_DiscountRequirementMap()
        {
            // Primary Key
            this.HasKey(t => t.DiscountRequirementID);

            // Properties
            this.Property(t => t.DiscountRequirementID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_DiscountRequirement");
            this.Property(t => t.DiscountRequirementID).HasColumnName("DiscountRequirementID");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
