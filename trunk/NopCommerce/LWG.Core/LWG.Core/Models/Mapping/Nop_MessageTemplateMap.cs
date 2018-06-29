using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_MessageTemplateMap : EntityTypeConfiguration<Nop_MessageTemplate>
    {
        public Nop_MessageTemplateMap()
        {
            // Primary Key
            this.HasKey(t => t.MessageTemplateID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Nop_MessageTemplate");
            this.Property(t => t.MessageTemplateID).HasColumnName("MessageTemplateID");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
