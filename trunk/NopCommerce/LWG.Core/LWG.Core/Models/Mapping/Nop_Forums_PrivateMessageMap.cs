using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_Forums_PrivateMessageMap : EntityTypeConfiguration<Nop_Forums_PrivateMessage>
    {
        public Nop_Forums_PrivateMessageMap()
        {
            // Primary Key
            this.HasKey(t => t.PrivateMessageID);

            // Properties
            this.Property(t => t.Subject)
                .IsRequired()
                .HasMaxLength(450);

            this.Property(t => t.Text)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Nop_Forums_PrivateMessage");
            this.Property(t => t.PrivateMessageID).HasColumnName("PrivateMessageID");
            this.Property(t => t.FromUserID).HasColumnName("FromUserID");
            this.Property(t => t.ToUserID).HasColumnName("ToUserID");
            this.Property(t => t.Subject).HasColumnName("Subject");
            this.Property(t => t.Text).HasColumnName("Text");
            this.Property(t => t.IsRead).HasColumnName("IsRead");
            this.Property(t => t.IsDeletedByAuthor).HasColumnName("IsDeletedByAuthor");
            this.Property(t => t.IsDeletedByRecipient).HasColumnName("IsDeletedByRecipient");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
        }
    }
}
