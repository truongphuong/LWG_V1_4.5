using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class lwg_PersonInRoleMap : EntityTypeConfiguration<lwg_PersonInRole>
    {
        public lwg_PersonInRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("lwg_PersonInRole");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PersonId).HasColumnName("PersonId");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
            this.Property(t => t.CatalogId).HasColumnName("CatalogId");

            // Relationships
            this.HasRequired(t => t.lwg_Catalog)
                .WithMany(t => t.lwg_PersonInRole)
                .HasForeignKey(d => d.CatalogId);
            this.HasRequired(t => t.lwg_Person)
                .WithMany(t => t.lwg_PersonInRole)
                .HasForeignKey(d => d.PersonId);
            this.HasRequired(t => t.lwg_Role)
                .WithMany(t => t.lwg_PersonInRole)
                .HasForeignKey(d => d.RoleId);

        }
    }
}
