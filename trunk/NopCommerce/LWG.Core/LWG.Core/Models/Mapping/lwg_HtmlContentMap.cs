using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class lwg_HtmlContentMap : EntityTypeConfiguration<lwg_HtmlContent>
    {
        public lwg_HtmlContentMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ContentHtml)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("lwg_HtmlContent");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ContentHtml).HasColumnName("ContentHtml");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
        }
    }
}
