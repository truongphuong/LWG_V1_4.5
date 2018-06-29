using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_Forums_SubscriptionMap : EntityTypeConfiguration<Nop_Forums_Subscription>
    {
        public Nop_Forums_SubscriptionMap()
        {
            // Primary Key
            this.HasKey(t => t.SubscriptionID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Nop_Forums_Subscription");
            this.Property(t => t.SubscriptionID).HasColumnName("SubscriptionID");
            this.Property(t => t.SubscriptionGUID).HasColumnName("SubscriptionGUID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.ForumID).HasColumnName("ForumID");
            this.Property(t => t.TopicID).HasColumnName("TopicID");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
        }
    }
}
