using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_Forums_PostMap : EntityTypeConfiguration<Nop_Forums_Post>
    {
        public Nop_Forums_PostMap()
        {
            // Primary Key
            this.HasKey(t => t.PostID);

            // Properties
            this.Property(t => t.Text)
                .IsRequired();

            this.Property(t => t.IPAddress)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_Forums_Post");
            this.Property(t => t.PostID).HasColumnName("PostID");
            this.Property(t => t.TopicID).HasColumnName("TopicID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.Text).HasColumnName("Text");
            this.Property(t => t.IPAddress).HasColumnName("IPAddress");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");

            // Relationships
            this.HasRequired(t => t.Nop_Forums_Topic)
                .WithMany(t => t.Nop_Forums_Post)
                .HasForeignKey(d => d.TopicID);

        }
    }
}
