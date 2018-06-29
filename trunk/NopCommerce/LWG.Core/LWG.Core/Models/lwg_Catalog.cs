using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_Catalog
    {
        public lwg_Catalog()
        {
            this.lwg_Audio = new List<lwg_Audio>();
            this.lwg_CatalogGenre = new List<lwg_CatalogGenre>();
            this.lwg_CatalogInstrumentSearch = new List<lwg_CatalogInstrumentSearch>();
            this.lwg_CatalogNameSearch = new List<lwg_CatalogNameSearch>();
            this.lwg_CatalogPublisher = new List<lwg_CatalogPublisher>();
            this.lwg_CatalogTitle = new List<lwg_CatalogTitle>();
            this.lwg_CatalogTitleSearch = new List<lwg_CatalogTitleSearch>();
            this.lwg_PeriodMapping = new List<lwg_PeriodMapping>();
            this.lwg_PersonInRole = new List<lwg_PersonInRole>();
            this.lwg_ReprintSourceMapping = new List<lwg_ReprintSourceMapping>();
            this.lwg_SeriesMapping = new List<lwg_SeriesMapping>();
            this.lwg_Video = new List<lwg_Video>();
        }

        public int CatalogId { get; set; }
        public string CatalogNumber { get; set; }
        public string TitleDisplay { get; set; }
        public string TitleList { get; set; }
        public string TitleSort { get; set; }
        public string Subtitle { get; set; }
        public string Duration { get; set; }
        public string Grade { get; set; }
        public string TextLang { get; set; }
        public string FSCprodcode { get; set; }
        public string PTSprodcode { get; set; }
        public Nullable<int> recid { get; set; }
        public string KaldbNumber { get; set; }
        public string Format1 { get; set; }
        public string Format2 { get; set; }
        public string Format3 { get; set; }
        public string Format4 { get; set; }
        public string Format5 { get; set; }
        public string Format6 { get; set; }
        public string Format7 { get; set; }
        public string Format8 { get; set; }
        public string Format9 { get; set; }
        public string Format10 { get; set; }
        public Nullable<double> Price1 { get; set; }
        public Nullable<double> Price2 { get; set; }
        public Nullable<double> Price3 { get; set; }
        public Nullable<double> Price4 { get; set; }
        public Nullable<double> Price5 { get; set; }
        public Nullable<double> Price6 { get; set; }
        public Nullable<double> Price7 { get; set; }
        public Nullable<double> Price8 { get; set; }
        public Nullable<double> Price9 { get; set; }
        public Nullable<double> Price10 { get; set; }
        public string SoundFile1 { get; set; }
        public string SoundFile2 { get; set; }
        public string SoundFile3 { get; set; }
        public string SoundFile4 { get; set; }
        public string SoundFile5 { get; set; }
        public string SoundFile6 { get; set; }
        public string SoundFile7 { get; set; }
        public string SoundFile8 { get; set; }
        public string SoundFile9 { get; set; }
        public string SoundFile10 { get; set; }
        public string SoundFile11 { get; set; }
        public string SoundFile12 { get; set; }
        public string SoundFile13 { get; set; }
        public string SoundFile14 { get; set; }
        public string SoundFile15 { get; set; }
        public string SoundIcon { get; set; }
        public string QTFile1 { get; set; }
        public string QTFile2 { get; set; }
        public string QTFile3 { get; set; }
        public string QTFile4 { get; set; }
        public string QTFile5 { get; set; }
        public string QTFile6 { get; set; }
        public string QTFile7 { get; set; }
        public string QTFile8 { get; set; }
        public string QTFile9 { get; set; }
        public string QTFile10 { get; set; }
        public string QTFile11 { get; set; }
        public string Track01 { get; set; }
        public string Track02 { get; set; }
        public string Track03 { get; set; }
        public string Track04 { get; set; }
        public string Track05 { get; set; }
        public string Track06 { get; set; }
        public string Track07 { get; set; }
        public string Track08 { get; set; }
        public string Track09 { get; set; }
        public string Track10 { get; set; }
        public string Xform1 { get; set; }
        public string Xform2 { get; set; }
        public string Xform3 { get; set; }
        public string Xform4 { get; set; }
        public string Xform5 { get; set; }
        public string PDF { get; set; }
        public string pages { get; set; }
        public Nullable<int> ReprintSourceId { get; set; }
        public Nullable<int> ArrangerGroupId { get; set; }
        public Nullable<int> PeriodId { get; set; }
        public Nullable<int> InstrumentalId { get; set; }
        public Nullable<int> SeriesId { get; set; }
        public string Blurb { get; set; }
        public string S4MasterSeries { get; set; }
        public string S5MasterCategories { get; set; }
        public string InstrDetail { get; set; }
        public Nullable<bool> VocAccomp { get; set; }
        public string Year { get; set; }
        public string TableofContents { get; set; }
        public string CopyrightYear { get; set; }
        public virtual ICollection<lwg_Audio> lwg_Audio { get; set; }
        public virtual lwg_Instrumental lwg_Instrumental { get; set; }
        public virtual ICollection<lwg_CatalogGenre> lwg_CatalogGenre { get; set; }
        public virtual ICollection<lwg_CatalogInstrumentSearch> lwg_CatalogInstrumentSearch { get; set; }
        public virtual ICollection<lwg_CatalogNameSearch> lwg_CatalogNameSearch { get; set; }
        public virtual ICollection<lwg_CatalogPublisher> lwg_CatalogPublisher { get; set; }
        public virtual ICollection<lwg_CatalogTitle> lwg_CatalogTitle { get; set; }
        public virtual ICollection<lwg_CatalogTitleSearch> lwg_CatalogTitleSearch { get; set; }
        public virtual ICollection<lwg_PeriodMapping> lwg_PeriodMapping { get; set; }
        public virtual ICollection<lwg_PersonInRole> lwg_PersonInRole { get; set; }
        public virtual ICollection<lwg_ReprintSourceMapping> lwg_ReprintSourceMapping { get; set; }
        public virtual ICollection<lwg_SeriesMapping> lwg_SeriesMapping { get; set; }
        public virtual ICollection<lwg_Video> lwg_Video { get; set; }
    }
}
