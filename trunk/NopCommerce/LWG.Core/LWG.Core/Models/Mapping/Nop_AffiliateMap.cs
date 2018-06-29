using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_AffiliateMap : EntityTypeConfiguration<Nop_Affiliate>
    {
        public Nop_AffiliateMap()
        {
            // Primary Key
            this.HasKey(t => t.AffiliateID);

            // Properties
            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.MiddleName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.PhoneNumber)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.FaxNumber)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Company)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Address1)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Address2)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.City)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.StateProvince)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ZipPostalCode)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Nop_Affiliate");
            this.Property(t => t.AffiliateID).HasColumnName("AffiliateID");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.MiddleName).HasColumnName("MiddleName");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.FaxNumber).HasColumnName("FaxNumber");
            this.Property(t => t.Company).HasColumnName("Company");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.Address2).HasColumnName("Address2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.StateProvince).HasColumnName("StateProvince");
            this.Property(t => t.ZipPostalCode).HasColumnName("ZipPostalCode");
            this.Property(t => t.CountryId).HasColumnName("CountryId");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.Deleted).HasColumnName("Deleted");
        }
    }
}
