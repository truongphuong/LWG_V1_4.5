using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_NewsLetterSubscriptionMap : EntityTypeConfiguration<Nop_NewsLetterSubscription>
    {
        public Nop_NewsLetterSubscriptionMap()
        {
            // Primary Key
            this.HasKey(t => t.NewsLetterSubscriptionID);

            // Properties
            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Nop_NewsLetterSubscription");
            this.Property(t => t.NewsLetterSubscriptionID).HasColumnName("NewsLetterSubscriptionID");
            this.Property(t => t.NewsLetterSubscriptionGuid).HasColumnName("NewsLetterSubscriptionGuid");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
        }
    }
}
