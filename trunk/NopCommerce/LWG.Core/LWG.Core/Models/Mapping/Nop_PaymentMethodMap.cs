using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_PaymentMethodMap : EntityTypeConfiguration<Nop_PaymentMethod>
    {
        public Nop_PaymentMethodMap()
        {
            // Primary Key
            this.HasKey(t => t.PaymentMethodID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.VisibleName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(4000);

            this.Property(t => t.ConfigureTemplatePath)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.UserTemplatePath)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.ClassName)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.SystemKeyword)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Nop_PaymentMethod");
            this.Property(t => t.PaymentMethodID).HasColumnName("PaymentMethodID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.VisibleName).HasColumnName("VisibleName");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ConfigureTemplatePath).HasColumnName("ConfigureTemplatePath");
            this.Property(t => t.UserTemplatePath).HasColumnName("UserTemplatePath");
            this.Property(t => t.ClassName).HasColumnName("ClassName");
            this.Property(t => t.SystemKeyword).HasColumnName("SystemKeyword");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
        }
    }
}
