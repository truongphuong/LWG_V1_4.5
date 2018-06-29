using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_PictureMap : EntityTypeConfiguration<Nop_Picture>
    {
        public Nop_PictureMap()
        {
            // Primary Key
            this.HasKey(t => t.PictureID);

            // Properties
            this.Property(t => t.PictureBinary)
                .IsRequired();

            this.Property(t => t.Extension)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Nop_Picture");
            this.Property(t => t.PictureID).HasColumnName("PictureID");
            this.Property(t => t.PictureBinary).HasColumnName("PictureBinary");
            this.Property(t => t.Extension).HasColumnName("Extension");
            this.Property(t => t.IsNew).HasColumnName("IsNew");
        }
    }
}
