using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_BlogCommentMap : EntityTypeConfiguration<Nop_BlogComment>
    {
        public Nop_BlogCommentMap()
        {
            // Primary Key
            this.HasKey(t => t.BlogCommentID);

            // Properties
            this.Property(t => t.IPAddress)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CommentText)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Nop_BlogComment");
            this.Property(t => t.BlogCommentID).HasColumnName("BlogCommentID");
            this.Property(t => t.BlogPostID).HasColumnName("BlogPostID");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.IPAddress).HasColumnName("IPAddress");
            this.Property(t => t.CommentText).HasColumnName("CommentText");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");

            // Relationships
            this.HasRequired(t => t.Nop_BlogPost)
                .WithMany(t => t.Nop_BlogComment)
                .HasForeignKey(d => d.BlogPostID);

        }
    }
}
