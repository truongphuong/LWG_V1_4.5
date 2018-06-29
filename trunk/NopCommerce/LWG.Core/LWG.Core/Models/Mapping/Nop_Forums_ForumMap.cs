using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_Forums_ForumMap : EntityTypeConfiguration<Nop_Forums_Forum>
    {
        public Nop_Forums_ForumMap()
        {
            // Primary Key
            this.HasKey(t => t.ForumID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Nop_Forums_Forum");
            this.Property(t => t.ForumID).HasColumnName("ForumID");
            this.Property(t => t.ForumGroupID).HasColumnName("ForumGroupID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.NumTopics).HasColumnName("NumTopics");
            this.Property(t => t.NumPosts).HasColumnName("NumPosts");
            this.Property(t => t.LastTopicID).HasColumnName("LastTopicID");
            this.Property(t => t.LastPostID).HasColumnName("LastPostID");
            this.Property(t => t.LastPostUserID).HasColumnName("LastPostUserID");
            this.Property(t => t.LastPostTime).HasColumnName("LastPostTime");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");

            // Relationships
            this.HasRequired(t => t.Nop_Forums_Group)
                .WithMany(t => t.Nop_Forums_Forum)
                .HasForeignKey(d => d.ForumGroupID);

        }
    }
}
