using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_BlogPostMap : EntityTypeConfiguration<Nop_BlogPost>
    {
        public Nop_BlogPostMap()
        {
            // Primary Key
            this.HasKey(t => t.BlogPostID);

            // Properties
            this.Property(t => t.BlogPostTitle)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.BlogPostBody)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Nop_BlogPost");
            this.Property(t => t.BlogPostID).HasColumnName("BlogPostID");
            this.Property(t => t.LanguageID).HasColumnName("LanguageID");
            this.Property(t => t.BlogPostTitle).HasColumnName("BlogPostTitle");
            this.Property(t => t.BlogPostBody).HasColumnName("BlogPostBody");
            this.Property(t => t.BlogPostAllowComments).HasColumnName("BlogPostAllowComments");
            this.Property(t => t.CreatedByID).HasColumnName("CreatedByID");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");

            // Relationships
            this.HasRequired(t => t.Nop_Customer)
                .WithMany(t => t.Nop_BlogPost)
                .HasForeignKey(d => d.CreatedByID);
            this.HasRequired(t => t.Nop_Language)
                .WithMany(t => t.Nop_BlogPost)
                .HasForeignKey(d => d.LanguageID);

        }
    }
}
