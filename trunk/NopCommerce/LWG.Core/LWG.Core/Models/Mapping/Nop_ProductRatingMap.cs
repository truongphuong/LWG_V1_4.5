using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ProductRatingMap : EntityTypeConfiguration<Nop_ProductRating>
    {
        public Nop_ProductRatingMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductRatingID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Nop_ProductRating");
            this.Property(t => t.ProductRatingID).HasColumnName("ProductRatingID");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.Rating).HasColumnName("Rating");
            this.Property(t => t.RatedOn).HasColumnName("RatedOn");

            // Relationships
            this.HasRequired(t => t.Nop_Customer)
                .WithMany(t => t.Nop_ProductRating)
                .HasForeignKey(d => d.CustomerID);
            this.HasRequired(t => t.Nop_Product)
                .WithMany(t => t.Nop_ProductRating)
                .HasForeignKey(d => d.ProductID);

        }
    }
}
