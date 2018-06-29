using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ProductReviewHelpfulnessMap : EntityTypeConfiguration<Nop_ProductReviewHelpfulness>
    {
        public Nop_ProductReviewHelpfulnessMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductReviewHelpfulnessID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Nop_ProductReviewHelpfulness");
            this.Property(t => t.ProductReviewHelpfulnessID).HasColumnName("ProductReviewHelpfulnessID");
            this.Property(t => t.ProductReviewID).HasColumnName("ProductReviewID");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.WasHelpful).HasColumnName("WasHelpful");

            // Relationships
            this.HasRequired(t => t.Nop_ProductReview)
                .WithMany(t => t.Nop_ProductReviewHelpfulness)
                .HasForeignKey(d => d.ProductReviewID);

        }
    }
}
