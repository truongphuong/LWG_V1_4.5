using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_NewsCommentMap : EntityTypeConfiguration<Nop_NewsComment>
    {
        public Nop_NewsCommentMap()
        {
            // Primary Key
            this.HasKey(t => t.NewsCommentID);

            // Properties
            this.Property(t => t.IPAddress)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(1000);

            this.Property(t => t.Comment)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Nop_NewsComment");
            this.Property(t => t.NewsCommentID).HasColumnName("NewsCommentID");
            this.Property(t => t.NewsID).HasColumnName("NewsID");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.IPAddress).HasColumnName("IPAddress");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");

            // Relationships
            this.HasRequired(t => t.Nop_News)
                .WithMany(t => t.Nop_NewsComment)
                .HasForeignKey(d => d.NewsID);

        }
    }
}
