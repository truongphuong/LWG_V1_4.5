using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class lwg_DealerMap : EntityTypeConfiguration<lwg_Dealer>
    {
        public lwg_DealerMap()
        {
            // Primary Key
            this.HasKey(t => t.DealerID);

            // Properties
            this.Property(t => t.DealerID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(400);

            this.Property(t => t.AddressLine1)
                .HasMaxLength(500);

            this.Property(t => t.AddressLine2)
                .HasMaxLength(500);

            this.Property(t => t.City)
                .HasMaxLength(100);

            this.Property(t => t.Zip)
                .HasMaxLength(100);

            this.Property(t => t.State)
                .HasMaxLength(50);

            this.Property(t => t.Phone)
                .HasMaxLength(50);

            this.Property(t => t.Fax)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("lwg_Dealer");
            this.Property(t => t.DealerID).HasColumnName("DealerID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.AddressLine1).HasColumnName("AddressLine1");
            this.Property(t => t.AddressLine2).HasColumnName("AddressLine2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Zip).HasColumnName("Zip");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.WebAddress).HasColumnName("WebAddress");
            this.Property(t => t.Contact).HasColumnName("Contact");
            this.Property(t => t.NewIssue).HasColumnName("NewIssue");
            this.Property(t => t.AddressSearch).HasColumnName("AddressSearch");
        }
    }
}
