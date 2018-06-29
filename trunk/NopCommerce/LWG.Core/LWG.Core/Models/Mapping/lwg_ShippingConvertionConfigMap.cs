using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class lwg_ShippingConvertionConfigMap : EntityTypeConfiguration<lwg_ShippingConvertionConfig>
    {
        public lwg_ShippingConvertionConfigMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("lwg_ShippingConvertionConfig");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.PriceFrom).HasColumnName("PriceFrom");
            this.Property(t => t.PriceTo).HasColumnName("PriceTo");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.ChargeWeight).HasColumnName("ChargeWeight");
        }
    }
}
