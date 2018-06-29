using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_TopicLocalizedMap : EntityTypeConfiguration<Nop_TopicLocalized>
    {
        public Nop_TopicLocalizedMap()
        {
            // Primary Key
            this.HasKey(t => t.TopicLocalizedID);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Body)
                .IsRequired();

            this.Property(t => t.MetaTitle)
                .IsRequired()
                .HasMaxLength(400);

            this.Property(t => t.MetaKeywords)
                .IsRequired()
                .HasMaxLength(400);

            this.Property(t => t.MetaDescription)
                .IsRequired()
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("Nop_TopicLocalized");
            this.Property(t => t.TopicLocalizedID).HasColumnName("TopicLocalizedID");
            this.Property(t => t.TopicID).HasColumnName("TopicID");
            this.Property(t => t.LanguageID).HasColumnName("LanguageID");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Body).HasColumnName("Body");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");
            this.Property(t => t.MetaTitle).HasColumnName("MetaTitle");
            this.Property(t => t.MetaKeywords).HasColumnName("MetaKeywords");
            this.Property(t => t.MetaDescription).HasColumnName("MetaDescription");

            // Relationships
            this.HasRequired(t => t.Nop_Language)
                .WithMany(t => t.Nop_TopicLocalized)
                .HasForeignKey(d => d.LanguageID);
            this.HasRequired(t => t.Nop_Topic)
                .WithMany(t => t.Nop_TopicLocalized)
                .HasForeignKey(d => d.TopicID);

        }
    }
}
