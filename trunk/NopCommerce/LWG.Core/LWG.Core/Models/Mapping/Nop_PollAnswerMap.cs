using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_PollAnswerMap : EntityTypeConfiguration<Nop_PollAnswer>
    {
        public Nop_PollAnswerMap()
        {
            // Primary Key
            this.HasKey(t => t.PollAnswerID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(400);

            // Table & Column Mappings
            this.ToTable("Nop_PollAnswer");
            this.Property(t => t.PollAnswerID).HasColumnName("PollAnswerID");
            this.Property(t => t.PollID).HasColumnName("PollID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Count).HasColumnName("Count");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");

            // Relationships
            this.HasRequired(t => t.Nop_Poll)
                .WithMany(t => t.Nop_PollAnswer)
                .HasForeignKey(d => d.PollID);

        }
    }
}
