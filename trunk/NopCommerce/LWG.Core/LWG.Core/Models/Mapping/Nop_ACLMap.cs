using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ACLMap : EntityTypeConfiguration<Nop_ACL>
    {
        public Nop_ACLMap()
        {
            // Primary Key
            this.HasKey(t => t.ACLID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Nop_ACL");
            this.Property(t => t.ACLID).HasColumnName("ACLID");
            this.Property(t => t.CustomerActionID).HasColumnName("CustomerActionID");
            this.Property(t => t.CustomerRoleID).HasColumnName("CustomerRoleID");
            this.Property(t => t.Allow).HasColumnName("Allow");

            // Relationships
            this.HasRequired(t => t.Nop_CustomerAction)
                .WithMany(t => t.Nop_ACL)
                .HasForeignKey(d => d.CustomerActionID);
            this.HasRequired(t => t.Nop_CustomerRole)
                .WithMany(t => t.Nop_ACL)
                .HasForeignKey(d => d.CustomerRoleID);

        }
    }
}
