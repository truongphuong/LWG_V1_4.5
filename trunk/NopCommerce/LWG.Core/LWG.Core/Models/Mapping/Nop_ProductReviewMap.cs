using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ProductReviewMap : EntityTypeConfiguration<Nop_ProductReview>
    {
        public Nop_ProductReviewMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductReviewID);

            // Properties
            this.Property(t => t.IPAddress)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(1000);

            this.Property(t => t.ReviewText)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Nop_ProductReview");
            this.Property(t => t.ProductReviewID).HasColumnName("ProductReviewID");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.IPAddress).HasColumnName("IPAddress");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.ReviewText).HasColumnName("ReviewText");
            this.Property(t => t.Rating).HasColumnName("Rating");
            this.Property(t => t.HelpfulYesTotal).HasColumnName("HelpfulYesTotal");
            this.Property(t => t.HelpfulNoTotal).HasColumnName("HelpfulNoTotal");
            this.Property(t => t.IsApproved).HasColumnName("IsApproved");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");

            // Relationships
            this.HasRequired(t => t.Nop_Customer)
                .WithMany(t => t.Nop_ProductReview)
                .HasForeignKey(d => d.CustomerID);
            this.HasRequired(t => t.Nop_Product)
                .WithMany(t => t.Nop_ProductReview)
                .HasForeignKey(d => d.ProductID);

        }
    }
}
