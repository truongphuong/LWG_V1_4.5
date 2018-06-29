using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_OrderNoteMap : EntityTypeConfiguration<Nop_OrderNote>
    {
        public Nop_OrderNoteMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderNoteID);

            // Properties
            this.Property(t => t.Note)
                .IsRequired()
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("Nop_OrderNote");
            this.Property(t => t.OrderNoteID).HasColumnName("OrderNoteID");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.Note).HasColumnName("Note");
            this.Property(t => t.DisplayToCustomer).HasColumnName("DisplayToCustomer");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");

            // Relationships
            this.HasRequired(t => t.Nop_Order)
                .WithMany(t => t.Nop_OrderNote)
                .HasForeignKey(d => d.OrderID);

        }
    }
}
