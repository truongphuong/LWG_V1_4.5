using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_BannedIpNetworkMap : EntityTypeConfiguration<Nop_BannedIpNetwork>
    {
        public Nop_BannedIpNetworkMap()
        {
            // Primary Key
            this.HasKey(t => t.BannedIpNetworkID);

            // Properties
            this.Property(t => t.StartAddress)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.EndAddress)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Comment)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Nop_BannedIpNetwork");
            this.Property(t => t.BannedIpNetworkID).HasColumnName("BannedIpNetworkID");
            this.Property(t => t.StartAddress).HasColumnName("StartAddress");
            this.Property(t => t.EndAddress).HasColumnName("EndAddress");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.IpException).HasColumnName("IpException");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");
        }
    }
}
