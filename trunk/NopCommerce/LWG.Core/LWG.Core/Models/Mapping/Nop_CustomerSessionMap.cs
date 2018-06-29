using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_CustomerSessionMap : EntityTypeConfiguration<Nop_CustomerSession>
    {
        public Nop_CustomerSessionMap()
        {
            // Primary Key
            this.HasKey(t => t.CustomerSessionGUID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Nop_CustomerSession");
            this.Property(t => t.CustomerSessionGUID).HasColumnName("CustomerSessionGUID");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.LastAccessed).HasColumnName("LastAccessed");
            this.Property(t => t.IsExpired).HasColumnName("IsExpired");
        }
    }
}
