using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_PollVotingRecordMap : EntityTypeConfiguration<Nop_PollVotingRecord>
    {
        public Nop_PollVotingRecordMap()
        {
            // Primary Key
            this.HasKey(t => t.PollVotingRecordID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Nop_PollVotingRecord");
            this.Property(t => t.PollVotingRecordID).HasColumnName("PollVotingRecordID");
            this.Property(t => t.PollAnswerID).HasColumnName("PollAnswerID");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");

            // Relationships
            this.HasRequired(t => t.Nop_Customer)
                .WithMany(t => t.Nop_PollVotingRecord)
                .HasForeignKey(d => d.CustomerID);
            this.HasRequired(t => t.Nop_PollAnswer)
                .WithMany(t => t.Nop_PollVotingRecord)
                .HasForeignKey(d => d.PollAnswerID);

        }
    }
}
