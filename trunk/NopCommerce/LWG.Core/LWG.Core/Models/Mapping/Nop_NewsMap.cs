using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_NewsMap : EntityTypeConfiguration<Nop_News>
    {
        public Nop_NewsMap()
        {
            // Primary Key
            this.HasKey(t => t.NewsID);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(1000);

            this.Property(t => t.Short)
                .IsRequired()
                .HasMaxLength(4000);

            this.Property(t => t.Full)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Nop_News");
            this.Property(t => t.NewsID).HasColumnName("NewsID");
            this.Property(t => t.LanguageID).HasColumnName("LanguageID");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Short).HasColumnName("Short");
            this.Property(t => t.Full).HasColumnName("Full");
            this.Property(t => t.Published).HasColumnName("Published");
            this.Property(t => t.AllowComments).HasColumnName("AllowComments");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");

            // Relationships
            this.HasRequired(t => t.Nop_Language)
                .WithMany(t => t.Nop_News)
                .HasForeignKey(d => d.LanguageID);

        }
    }
}
