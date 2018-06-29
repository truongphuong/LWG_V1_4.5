using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_TopicMap : EntityTypeConfiguration<Nop_Topic>
    {
        public Nop_TopicMap()
        {
            // Primary Key
            this.HasKey(t => t.TopicID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Nop_Topic");
            this.Property(t => t.TopicID).HasColumnName("TopicID");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
