using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_CustomerActionMap : EntityTypeConfiguration<Nop_CustomerAction>
    {
        public Nop_CustomerActionMap()
        {
            // Primary Key
            this.HasKey(t => t.CustomerActionID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.SystemKeyword)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Comment)
                .IsRequired()
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("Nop_CustomerAction");
            this.Property(t => t.CustomerActionID).HasColumnName("CustomerActionID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.SystemKeyword).HasColumnName("SystemKeyword");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
        }
    }
}
