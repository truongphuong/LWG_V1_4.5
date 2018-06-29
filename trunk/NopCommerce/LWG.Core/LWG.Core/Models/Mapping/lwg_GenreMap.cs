using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class lwg_GenreMap : EntityTypeConfiguration<lwg_Genre>
    {
        public lwg_GenreMap()
        {
            // Primary Key
            this.HasKey(t => t.GerneId);

            // Properties
            this.Property(t => t.GerneId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("lwg_Genre");
            this.Property(t => t.GerneId).HasColumnName("GerneId");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
