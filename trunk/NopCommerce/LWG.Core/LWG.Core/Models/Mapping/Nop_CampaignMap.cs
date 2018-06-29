using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_CampaignMap : EntityTypeConfiguration<Nop_Campaign>
    {
        public Nop_CampaignMap()
        {
            // Primary Key
            this.HasKey(t => t.CampaignID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Subject)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Body)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Nop_Campaign");
            this.Property(t => t.CampaignID).HasColumnName("CampaignID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Subject).HasColumnName("Subject");
            this.Property(t => t.Body).HasColumnName("Body");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
        }
    }
}
