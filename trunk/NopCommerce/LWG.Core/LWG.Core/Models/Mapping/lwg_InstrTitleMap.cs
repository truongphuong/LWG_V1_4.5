using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class lwg_InstrTitleMap : EntityTypeConfiguration<lwg_InstrTitle>
    {
        public lwg_InstrTitleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("lwg_InstrTitle");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.TitleTypeId).HasColumnName("TitleTypeId");

            // Relationships
            this.HasRequired(t => t.lwg_TitleType)
                .WithMany(t => t.lwg_InstrTitle)
                .HasForeignKey(d => d.TitleTypeId);

        }
    }
}
