using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_PollMap : EntityTypeConfiguration<Nop_Poll>
    {
        public Nop_PollMap()
        {
            // Primary Key
            this.HasKey(t => t.PollID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(400);

            this.Property(t => t.SystemKeyword)
                .IsRequired()
                .HasMaxLength(400);

            // Table & Column Mappings
            this.ToTable("Nop_Poll");
            this.Property(t => t.PollID).HasColumnName("PollID");
            this.Property(t => t.LanguageID).HasColumnName("LanguageID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Published).HasColumnName("Published");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
            this.Property(t => t.SystemKeyword).HasColumnName("SystemKeyword");

            // Relationships
            this.HasRequired(t => t.Nop_Language)
                .WithMany(t => t.Nop_Poll)
                .HasForeignKey(d => d.LanguageID);

        }
    }
}
