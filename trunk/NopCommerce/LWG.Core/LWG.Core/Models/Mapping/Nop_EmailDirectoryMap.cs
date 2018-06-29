using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_EmailDirectoryMap : EntityTypeConfiguration<Nop_EmailDirectory>
    {
        public Nop_EmailDirectoryMap()
        {
            // Primary Key
            this.HasKey(t => t.EmailID);

            // Properties
            this.Property(t => t.FirstName)
                .HasMaxLength(500);

            this.Property(t => t.LastName)
                .HasMaxLength(500);

            this.Property(t => t.JobTitle)
                .HasMaxLength(500);

            this.Property(t => t.PhoneNumber)
                .HasMaxLength(500);

            this.Property(t => t.EmailAddress)
                .HasMaxLength(500);

            this.Property(t => t.Description)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Nop_EmailDirectory");
            this.Property(t => t.EmailID).HasColumnName("EmailID");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.JobTitle).HasColumnName("JobTitle");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.EmailAddress).HasColumnName("EmailAddress");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.PictureID).HasColumnName("PictureID");
        }
    }
}
