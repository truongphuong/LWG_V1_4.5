using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_PricelistMap : EntityTypeConfiguration<Nop_Pricelist>
    {
        public Nop_PricelistMap()
        {
            // Primary Key
            this.HasKey(t => t.PricelistID);

            // Properties
            this.Property(t => t.DisplayName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ShortName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.PricelistGuid)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.FormatLocalization)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.AdminNotes)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.Header)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.Body)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.Footer)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Nop_Pricelist");
            this.Property(t => t.PricelistID).HasColumnName("PricelistID");
            this.Property(t => t.ExportModeID).HasColumnName("ExportModeID");
            this.Property(t => t.ExportTypeID).HasColumnName("ExportTypeID");
            this.Property(t => t.AffiliateID).HasColumnName("AffiliateID");
            this.Property(t => t.DisplayName).HasColumnName("DisplayName");
            this.Property(t => t.ShortName).HasColumnName("ShortName");
            this.Property(t => t.PricelistGuid).HasColumnName("PricelistGuid");
            this.Property(t => t.CacheTime).HasColumnName("CacheTime");
            this.Property(t => t.FormatLocalization).HasColumnName("FormatLocalization");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.AdminNotes).HasColumnName("AdminNotes");
            this.Property(t => t.Header).HasColumnName("Header");
            this.Property(t => t.Body).HasColumnName("Body");
            this.Property(t => t.Footer).HasColumnName("Footer");
            this.Property(t => t.PriceAdjustmentTypeID).HasColumnName("PriceAdjustmentTypeID");
            this.Property(t => t.PriceAdjustment).HasColumnName("PriceAdjustment");
            this.Property(t => t.OverrideIndivAdjustment).HasColumnName("OverrideIndivAdjustment");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");
        }
    }
}
