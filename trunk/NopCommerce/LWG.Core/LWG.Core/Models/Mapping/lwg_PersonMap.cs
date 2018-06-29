using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class lwg_PersonMap : EntityTypeConfiguration<lwg_Person>
    {
        public lwg_PersonMap()
        {
            // Primary Key
            this.HasKey(t => t.PersonId);

            // Properties
            this.Property(t => t.PersonId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.NameDisplay)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.NameList)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.NameSort)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Biography)
                .IsRequired();

            this.Property(t => t.FirstLetter)
                .IsRequired()
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("lwg_Person");
            this.Property(t => t.PersonId).HasColumnName("PersonId");
            this.Property(t => t.NameDisplay).HasColumnName("NameDisplay");
            this.Property(t => t.NameList).HasColumnName("NameList");
            this.Property(t => t.NameSort).HasColumnName("NameSort");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.DOB).HasColumnName("DOB");
            this.Property(t => t.DOD).HasColumnName("DOD");
            this.Property(t => t.Biography).HasColumnName("Biography");
            this.Property(t => t.FirstLetter).HasColumnName("FirstLetter");
            this.Property(t => t.PictureID).HasColumnName("PictureID");
        }
    }
}
