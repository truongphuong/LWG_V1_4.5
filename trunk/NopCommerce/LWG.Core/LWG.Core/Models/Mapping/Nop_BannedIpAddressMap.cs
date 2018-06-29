using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_BannedIpAddressMap : EntityTypeConfiguration<Nop_BannedIpAddress>
    {
        public Nop_BannedIpAddressMap()
        {
            // Primary Key
            this.HasKey(t => t.BannedIpAddressID);

            // Properties
            this.Property(t => t.Address)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Comment)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Nop_BannedIpAddress");
            this.Property(t => t.BannedIpAddressID).HasColumnName("BannedIpAddressID");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");
        }
    }
}
