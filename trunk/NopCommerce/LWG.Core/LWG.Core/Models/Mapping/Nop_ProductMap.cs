using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ProductMap : EntityTypeConfiguration<Nop_Product>
    {
        public Nop_ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(400);

            this.Property(t => t.ShortDescription)
                .IsRequired();

            this.Property(t => t.FullDescription)
                .IsRequired();

            this.Property(t => t.AdminComment)
                .IsRequired();

            this.Property(t => t.MetaKeywords)
                .IsRequired()
                .HasMaxLength(400);

            this.Property(t => t.MetaDescription)
                .IsRequired()
                .HasMaxLength(4000);

            this.Property(t => t.MetaTitle)
                .IsRequired()
                .HasMaxLength(400);

            this.Property(t => t.SEName)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_Product");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ShortDescription).HasColumnName("ShortDescription");
            this.Property(t => t.FullDescription).HasColumnName("FullDescription");
            this.Property(t => t.AdminComment).HasColumnName("AdminComment");
            this.Property(t => t.ProductTypeID).HasColumnName("ProductTypeID");
            this.Property(t => t.TemplateID).HasColumnName("TemplateID");
            this.Property(t => t.ShowOnHomePage).HasColumnName("ShowOnHomePage");
            this.Property(t => t.MetaKeywords).HasColumnName("MetaKeywords");
            this.Property(t => t.MetaDescription).HasColumnName("MetaDescription");
            this.Property(t => t.MetaTitle).HasColumnName("MetaTitle");
            this.Property(t => t.SEName).HasColumnName("SEName");
            this.Property(t => t.AllowCustomerReviews).HasColumnName("AllowCustomerReviews");
            this.Property(t => t.AllowCustomerRatings).HasColumnName("AllowCustomerRatings");
            this.Property(t => t.RatingSum).HasColumnName("RatingSum");
            this.Property(t => t.TotalRatingVotes).HasColumnName("TotalRatingVotes");
            this.Property(t => t.Published).HasColumnName("Published");
            this.Property(t => t.Deleted).HasColumnName("Deleted");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");

            // Relationships
            this.HasMany(t => t.Nop_ProductTag)
                .WithMany(t => t.Nop_Product)
                .Map(m =>
                    {
                        m.ToTable("Nop_ProductTag_Product_Mapping");
                        m.MapLeftKey("ProductID");
                        m.MapRightKey("ProductTagID");
                    });

            this.HasRequired(t => t.Nop_ProductTemplate)
                .WithMany(t => t.Nop_Product)
                .HasForeignKey(d => d.TemplateID);
            this.HasRequired(t => t.Nop_ProductType)
                .WithMany(t => t.Nop_Product)
                .HasForeignKey(d => d.ProductTypeID);

        }
    }
}
