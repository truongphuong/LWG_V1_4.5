using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ProductPictureMap : EntityTypeConfiguration<Nop_ProductPicture>
    {
        public Nop_ProductPictureMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductPictureID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Nop_ProductPicture");
            this.Property(t => t.ProductPictureID).HasColumnName("ProductPictureID");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.PictureID).HasColumnName("PictureID");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");

            // Relationships
            this.HasRequired(t => t.Nop_Picture)
                .WithMany(t => t.Nop_ProductPicture)
                .HasForeignKey(d => d.PictureID);
            this.HasRequired(t => t.Nop_Product)
                .WithMany(t => t.Nop_ProductPicture)
                .HasForeignKey(d => d.ProductID);

        }
    }
}
