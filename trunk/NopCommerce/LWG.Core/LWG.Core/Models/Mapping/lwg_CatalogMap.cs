using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class lwg_CatalogMap : EntityTypeConfiguration<lwg_Catalog>
    {
        public lwg_CatalogMap()
        {
            // Primary Key
            this.HasKey(t => t.CatalogId);

            // Properties
            this.Property(t => t.CatalogId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CatalogNumber)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.TitleDisplay)
                .HasMaxLength(2000);

            this.Property(t => t.TitleList)
                .HasMaxLength(2000);

            this.Property(t => t.TitleSort)
                .HasMaxLength(2000);

            this.Property(t => t.Subtitle)
                .IsRequired()
                .HasMaxLength(2000);

            this.Property(t => t.Duration)
                .HasMaxLength(2000);

            this.Property(t => t.Grade)
                .HasMaxLength(50);

            this.Property(t => t.TextLang)
                .IsRequired()
                .HasMaxLength(2000);

            this.Property(t => t.FSCprodcode)
                .HasMaxLength(2000);

            this.Property(t => t.PTSprodcode)
                .HasMaxLength(2000);

            this.Property(t => t.KaldbNumber)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Format1)
                .HasMaxLength(200);

            this.Property(t => t.Format2)
                .HasMaxLength(200);

            this.Property(t => t.Format3)
                .HasMaxLength(200);

            this.Property(t => t.Format4)
                .HasMaxLength(200);

            this.Property(t => t.Format5)
                .HasMaxLength(200);

            this.Property(t => t.Format6)
                .HasMaxLength(200);

            this.Property(t => t.Format7)
                .HasMaxLength(200);

            this.Property(t => t.Format8)
                .HasMaxLength(200);

            this.Property(t => t.Format9)
                .HasMaxLength(200);

            this.Property(t => t.Format10)
                .HasMaxLength(200);

            this.Property(t => t.SoundFile1)
                .HasMaxLength(200);

            this.Property(t => t.SoundFile2)
                .HasMaxLength(200);

            this.Property(t => t.SoundFile3)
                .HasMaxLength(200);

            this.Property(t => t.SoundFile4)
                .HasMaxLength(200);

            this.Property(t => t.SoundFile5)
                .HasMaxLength(200);

            this.Property(t => t.SoundFile6)
                .HasMaxLength(200);

            this.Property(t => t.SoundFile7)
                .HasMaxLength(200);

            this.Property(t => t.SoundFile8)
                .HasMaxLength(200);

            this.Property(t => t.SoundFile9)
                .HasMaxLength(200);

            this.Property(t => t.SoundFile10)
                .HasMaxLength(200);

            this.Property(t => t.SoundFile11)
                .HasMaxLength(200);

            this.Property(t => t.SoundFile12)
                .HasMaxLength(200);

            this.Property(t => t.SoundFile13)
                .HasMaxLength(200);

            this.Property(t => t.SoundFile14)
                .HasMaxLength(200);

            this.Property(t => t.SoundFile15)
                .HasMaxLength(200);

            this.Property(t => t.SoundIcon)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.QTFile1)
                .HasMaxLength(200);

            this.Property(t => t.QTFile2)
                .HasMaxLength(200);

            this.Property(t => t.QTFile3)
                .HasMaxLength(200);

            this.Property(t => t.QTFile4)
                .HasMaxLength(200);

            this.Property(t => t.QTFile5)
                .HasMaxLength(200);

            this.Property(t => t.QTFile6)
                .HasMaxLength(200);

            this.Property(t => t.QTFile7)
                .HasMaxLength(200);

            this.Property(t => t.QTFile8)
                .HasMaxLength(200);

            this.Property(t => t.QTFile9)
                .HasMaxLength(200);

            this.Property(t => t.QTFile10)
                .HasMaxLength(200);

            this.Property(t => t.QTFile11)
                .HasMaxLength(200);

            this.Property(t => t.Track01)
                .HasMaxLength(200);

            this.Property(t => t.Track02)
                .HasMaxLength(200);

            this.Property(t => t.Track03)
                .HasMaxLength(200);

            this.Property(t => t.Track04)
                .HasMaxLength(200);

            this.Property(t => t.Track05)
                .HasMaxLength(200);

            this.Property(t => t.Track06)
                .HasMaxLength(200);

            this.Property(t => t.Track07)
                .HasMaxLength(200);

            this.Property(t => t.Track08)
                .HasMaxLength(200);

            this.Property(t => t.Track09)
                .HasMaxLength(200);

            this.Property(t => t.Track10)
                .HasMaxLength(200);

            this.Property(t => t.Xform1)
                .HasMaxLength(200);

            this.Property(t => t.Xform2)
                .HasMaxLength(200);

            this.Property(t => t.Xform3)
                .HasMaxLength(200);

            this.Property(t => t.Xform4)
                .HasMaxLength(200);

            this.Property(t => t.Xform5)
                .HasMaxLength(200);

            this.Property(t => t.PDF)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.pages)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Blurb)
                .HasMaxLength(4000);

            this.Property(t => t.S4MasterSeries)
                .HasMaxLength(2000);

            this.Property(t => t.S5MasterCategories)
                .HasMaxLength(2000);

            this.Property(t => t.InstrDetail)
                .HasMaxLength(2000);

            this.Property(t => t.Year)
                .HasMaxLength(500);

            this.Property(t => t.CopyrightYear)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("lwg_Catalog");
            this.Property(t => t.CatalogId).HasColumnName("CatalogId");
            this.Property(t => t.CatalogNumber).HasColumnName("CatalogNumber");
            this.Property(t => t.TitleDisplay).HasColumnName("TitleDisplay");
            this.Property(t => t.TitleList).HasColumnName("TitleList");
            this.Property(t => t.TitleSort).HasColumnName("TitleSort");
            this.Property(t => t.Subtitle).HasColumnName("Subtitle");
            this.Property(t => t.Duration).HasColumnName("Duration");
            this.Property(t => t.Grade).HasColumnName("Grade");
            this.Property(t => t.TextLang).HasColumnName("TextLang");
            this.Property(t => t.FSCprodcode).HasColumnName("FSCprodcode");
            this.Property(t => t.PTSprodcode).HasColumnName("PTSprodcode");
            this.Property(t => t.recid).HasColumnName("recid");
            this.Property(t => t.KaldbNumber).HasColumnName("KaldbNumber");
            this.Property(t => t.Format1).HasColumnName("Format1");
            this.Property(t => t.Format2).HasColumnName("Format2");
            this.Property(t => t.Format3).HasColumnName("Format3");
            this.Property(t => t.Format4).HasColumnName("Format4");
            this.Property(t => t.Format5).HasColumnName("Format5");
            this.Property(t => t.Format6).HasColumnName("Format6");
            this.Property(t => t.Format7).HasColumnName("Format7");
            this.Property(t => t.Format8).HasColumnName("Format8");
            this.Property(t => t.Format9).HasColumnName("Format9");
            this.Property(t => t.Format10).HasColumnName("Format10");
            this.Property(t => t.Price1).HasColumnName("Price1");
            this.Property(t => t.Price2).HasColumnName("Price2");
            this.Property(t => t.Price3).HasColumnName("Price3");
            this.Property(t => t.Price4).HasColumnName("Price4");
            this.Property(t => t.Price5).HasColumnName("Price5");
            this.Property(t => t.Price6).HasColumnName("Price6");
            this.Property(t => t.Price7).HasColumnName("Price7");
            this.Property(t => t.Price8).HasColumnName("Price8");
            this.Property(t => t.Price9).HasColumnName("Price9");
            this.Property(t => t.Price10).HasColumnName("Price10");
            this.Property(t => t.SoundFile1).HasColumnName("SoundFile1");
            this.Property(t => t.SoundFile2).HasColumnName("SoundFile2");
            this.Property(t => t.SoundFile3).HasColumnName("SoundFile3");
            this.Property(t => t.SoundFile4).HasColumnName("SoundFile4");
            this.Property(t => t.SoundFile5).HasColumnName("SoundFile5");
            this.Property(t => t.SoundFile6).HasColumnName("SoundFile6");
            this.Property(t => t.SoundFile7).HasColumnName("SoundFile7");
            this.Property(t => t.SoundFile8).HasColumnName("SoundFile8");
            this.Property(t => t.SoundFile9).HasColumnName("SoundFile9");
            this.Property(t => t.SoundFile10).HasColumnName("SoundFile10");
            this.Property(t => t.SoundFile11).HasColumnName("SoundFile11");
            this.Property(t => t.SoundFile12).HasColumnName("SoundFile12");
            this.Property(t => t.SoundFile13).HasColumnName("SoundFile13");
            this.Property(t => t.SoundFile14).HasColumnName("SoundFile14");
            this.Property(t => t.SoundFile15).HasColumnName("SoundFile15");
            this.Property(t => t.SoundIcon).HasColumnName("SoundIcon");
            this.Property(t => t.QTFile1).HasColumnName("QTFile1");
            this.Property(t => t.QTFile2).HasColumnName("QTFile2");
            this.Property(t => t.QTFile3).HasColumnName("QTFile3");
            this.Property(t => t.QTFile4).HasColumnName("QTFile4");
            this.Property(t => t.QTFile5).HasColumnName("QTFile5");
            this.Property(t => t.QTFile6).HasColumnName("QTFile6");
            this.Property(t => t.QTFile7).HasColumnName("QTFile7");
            this.Property(t => t.QTFile8).HasColumnName("QTFile8");
            this.Property(t => t.QTFile9).HasColumnName("QTFile9");
            this.Property(t => t.QTFile10).HasColumnName("QTFile10");
            this.Property(t => t.QTFile11).HasColumnName("QTFile11");
            this.Property(t => t.Track01).HasColumnName("Track01");
            this.Property(t => t.Track02).HasColumnName("Track02");
            this.Property(t => t.Track03).HasColumnName("Track03");
            this.Property(t => t.Track04).HasColumnName("Track04");
            this.Property(t => t.Track05).HasColumnName("Track05");
            this.Property(t => t.Track06).HasColumnName("Track06");
            this.Property(t => t.Track07).HasColumnName("Track07");
            this.Property(t => t.Track08).HasColumnName("Track08");
            this.Property(t => t.Track09).HasColumnName("Track09");
            this.Property(t => t.Track10).HasColumnName("Track10");
            this.Property(t => t.Xform1).HasColumnName("Xform1");
            this.Property(t => t.Xform2).HasColumnName("Xform2");
            this.Property(t => t.Xform3).HasColumnName("Xform3");
            this.Property(t => t.Xform4).HasColumnName("Xform4");
            this.Property(t => t.Xform5).HasColumnName("Xform5");
            this.Property(t => t.PDF).HasColumnName("PDF");
            this.Property(t => t.pages).HasColumnName("pages");
            this.Property(t => t.ReprintSourceId).HasColumnName("ReprintSourceId");
            this.Property(t => t.ArrangerGroupId).HasColumnName("ArrangerGroupId");
            this.Property(t => t.PeriodId).HasColumnName("PeriodId");
            this.Property(t => t.InstrumentalId).HasColumnName("InstrumentalId");
            this.Property(t => t.SeriesId).HasColumnName("SeriesId");
            this.Property(t => t.Blurb).HasColumnName("Blurb");
            this.Property(t => t.S4MasterSeries).HasColumnName("S4MasterSeries");
            this.Property(t => t.S5MasterCategories).HasColumnName("S5MasterCategories");
            this.Property(t => t.InstrDetail).HasColumnName("InstrDetail");
            this.Property(t => t.VocAccomp).HasColumnName("VocAccomp");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.TableofContents).HasColumnName("TableofContents");
            this.Property(t => t.CopyrightYear).HasColumnName("CopyrightYear");

            // Relationships
            this.HasOptional(t => t.lwg_Instrumental)
                .WithMany(t => t.lwg_Catalog)
                .HasForeignKey(d => d.InstrumentalId);

        }
    }
}
