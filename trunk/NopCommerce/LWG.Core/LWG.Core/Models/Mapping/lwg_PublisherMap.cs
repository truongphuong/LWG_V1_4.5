using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class lwg_PublisherMap : EntityTypeConfiguration<lwg_Publisher>
    {
        public lwg_PublisherMap()
        {
            // Primary Key
            this.HasKey(t => t.PublisherId);

            // Properties
            this.Property(t => t.PublisherId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("lwg_Publisher");
            this.Property(t => t.PublisherId).HasColumnName("PublisherId");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
