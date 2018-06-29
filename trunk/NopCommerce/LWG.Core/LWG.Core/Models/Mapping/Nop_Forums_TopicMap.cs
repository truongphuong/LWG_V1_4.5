using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_Forums_TopicMap : EntityTypeConfiguration<Nop_Forums_Topic>
    {
        public Nop_Forums_TopicMap()
        {
            // Primary Key
            this.HasKey(t => t.TopicID);

            // Properties
            this.Property(t => t.Subject)
                .IsRequired()
                .HasMaxLength(450);

            // Table & Column Mappings
            this.ToTable("Nop_Forums_Topic");
            this.Property(t => t.TopicID).HasColumnName("TopicID");
            this.Property(t => t.ForumID).HasColumnName("ForumID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.TopicTypeID).HasColumnName("TopicTypeID");
            this.Property(t => t.Subject).HasColumnName("Subject");
            this.Property(t => t.NumPosts).HasColumnName("NumPosts");
            this.Property(t => t.Views).HasColumnName("Views");
            this.Property(t => t.LastPostID).HasColumnName("LastPostID");
            this.Property(t => t.LastPostUserID).HasColumnName("LastPostUserID");
            this.Property(t => t.LastPostTime).HasColumnName("LastPostTime");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");

            // Relationships
            this.HasRequired(t => t.Nop_Forums_Forum)
                .WithMany(t => t.Nop_Forums_Topic)
                .HasForeignKey(d => d.ForumID);

        }
    }
}
