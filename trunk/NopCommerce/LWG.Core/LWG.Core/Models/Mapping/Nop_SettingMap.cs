using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_SettingMap : EntityTypeConfiguration<Nop_Setting>
    {
        public Nop_SettingMap()
        {
            // Primary Key
            this.HasKey(t => t.SettingID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Value)
                .IsRequired()
                .HasMaxLength(2000);

            this.Property(t => t.Description)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Nop_Setting");
            this.Property(t => t.SettingID).HasColumnName("SettingID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Value).HasColumnName("Value");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
