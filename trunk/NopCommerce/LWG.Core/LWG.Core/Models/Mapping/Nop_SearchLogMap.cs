using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_SearchLogMap : EntityTypeConfiguration<Nop_SearchLog>
    {
        public Nop_SearchLogMap()
        {
            // Primary Key
            this.HasKey(t => t.SearchLogID);

            // Properties
            this.Property(t => t.SearchTerm)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_SearchLog");
            this.Property(t => t.SearchLogID).HasColumnName("SearchLogID");
            this.Property(t => t.SearchTerm).HasColumnName("SearchTerm");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
        }
    }
}
