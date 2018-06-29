using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_AddressMap : EntityTypeConfiguration<Nop_Address>
    {
        public Nop_AddressMap()
        {
            // Primary Key
            this.HasKey(t => t.AddressId);

            // Properties
            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.LastName)
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

            this.Property(t => t.ZipPostalCode)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Nop_Address");
            this.Property(t => t.AddressId).HasColumnName("AddressId");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.IsBillingAddress).HasColumnName("IsBillingAddress");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.FaxNumber).HasColumnName("FaxNumber");
            this.Property(t => t.Company).HasColumnName("Company");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.Address2).HasColumnName("Address2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.StateProvinceID).HasColumnName("StateProvinceID");
            this.Property(t => t.ZipPostalCode).HasColumnName("ZipPostalCode");
            this.Property(t => t.CountryID).HasColumnName("CountryID");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");

            // Relationships
            this.HasRequired(t => t.Nop_Customer)
                .WithMany(t => t.Nop_Address)
                .HasForeignKey(d => d.CustomerID);

        }
    }
}
