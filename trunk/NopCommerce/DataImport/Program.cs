using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Text.RegularExpressions;

//\Tungnho insert
using NopSolutions.NopCommerce.BusinessLogic;
using NopSolutions.NopCommerce.BusinessLogic.Categories;
using NopSolutions.NopCommerce.BusinessLogic.Manufacturers;
using NopSolutions.NopCommerce.BusinessLogic.Media;
using NopSolutions.NopCommerce.BusinessLogic.Products;
using NopSolutions.NopCommerce.BusinessLogic.Promo.Discounts;
using NopSolutions.NopCommerce.BusinessLogic.Tax;
using NopSolutions.NopCommerce.BusinessLogic.Templates;
using NopSolutions.NopCommerce.Common.Utils;
using NopSolutions.NopCommerce.BusinessLogic.Warehouses;
using LWG.Business;
using LWG.Core;
using System.IO;
//\

namespace DataImport
{
    class Program
    {
        public static StringBuilder tempBuilder = new StringBuilder();

        static void Main(string[] args)
        {
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\LudMasters.xls;Extended Properties=Excel 8.0";
            OleDbConnection conn = new OleDbConnection(connectionString);

            conn.Open();
            OleDbCommand cmd = conn.CreateCommand();
            DataTable sheetNameTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            cmd.CommandText = "SELECT [ArrEd],[BdWECat],[Blurb],[BrCat],[Cat],[category],[CatNo],[ChEnsCat],[CompDisp],[CompList],[CompSort],[duration],[EnsCat],[format1],[format2],[format3],[format4],[format5],[format6],[format7],[format8],[format9],[format10],[FSCprodcode],[Genre],[Grade],[insCatAll],[instr],[InstrDetail],[InstrSearch],[KaldbNo],[KbdCat],[NameSearch],[pages],[PDF],[PercCat],[period],[price1],[price2],[price3],[price4],[price5],[price6],[price7],[price8],[price9],[price10],[PTSprodcode],[Publisher],[QTfile01],[QTfile02],[QTfile03],[QTfile04],[QTfile05],[QTfile06],[QTfile07],[QTfile08],[QTfile09],[QTfile10],[QTfile11],[recid],[ReprintSource],[s4 masters series],[s5 masters categories],[Series],[SoundFile01],[SoundFile02],[SoundFile03],[SoundFile04],[SoundFile05],[SoundFile06],[SoundFile07],[SoundFile08],[SoundFile09],[SoundFile10],[SoundFile11],[SoundFile12],[SoundFile13],[SoundFile14],[SoundFile15],[SoundIcon],[StrCat],[SubtitleConts],[test],[TextLang],[TitleDisp],[TitleList],[TitleSearch],[TitleSort],[Track01],[Track02],[Track03],[Track04],[Track05],[Track06],[Track07],[Track08],[Track09],[Track10],[VocAccomp],[VocalCat],[WWCat],[xform1],[xform2],[xform3],[xform4],[xform5],[year],[arranger_firstletter],[composer_firstletter] FROM [Sheet1$]";
            OleDbDataReader reader = cmd.ExecuteReader();
            List<FP7Record> records = new List<FP7Record>();
            while (reader.Read())
            {
                FP7Record rec = ParseRecord(reader);
                records.Add(rec);
                rec = null;
            }

            conn.Close();
            //\Tungnho
            // create a writer and open the file
            TextWriter tw = new StreamWriter("LWG_Log_" + DateTime.Now.Ticks + "_.txt");

            //\
            if (records.Count > 0)
            {
                int i = 1;
                foreach (FP7Record fpr in records)
                {
                    try
                    {
                        Console.WriteLine("Record " + i);
                        tempBuilder.Append("Record " + i + " - " + fpr.CatNo + System.Environment.NewLine);

                        if (!fpr.CatNo.Equals(string.Empty))
                        {
                            CreateNopProudct(fpr);
                        }
                        else
                        {
                            Console.WriteLine("CatNo = String.Empty!");
                        }
                        i++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Record " + i + " Error: " + ex.Message);
                        tempBuilder.Append("Record " + i + " - " + fpr.CatNo + " Error " + ex.Message + System.Environment.NewLine);
                        i++;
                        continue;
                    }
                }
            }
            else
            {
                Console.WriteLine("Have no record! teen ten tenf ");
            }

            // write a line of text to the file
            tw.WriteLine(tempBuilder.ToString());
            // close the stream
            tw.Close();
            //\           
        }

        private static FP7Record ParseRecord(OleDbDataReader reader)
        {
            FP7Record rec = new FP7Record();
            rec.ArrEd = GetArrangerInfo(reader[0].ToString());
            rec.BdWECat = GetListItem(reader[1].ToString());
            rec.Blurb = reader[2].ToString();
            rec.BrCat = GetListItem(reader[3].ToString());
            rec.Cat = reader[4].ToString();
            rec.Category = GetListItem(reader[5].ToString());
            rec.CatNo = reader[6].ToString();
            rec.ChEnsCat = GetListItem(reader[7].ToString());
            rec.CompDist = reader[8].ToString();
            rec.CompList = reader[9].ToString();
            rec.CompSort = reader[10].ToString();
            rec.Duration = reader[11].ToString();
            rec.EnsCat = GetListItem(reader[12].ToString());
            rec.Format1 = reader[13].ToString();
            rec.Format2 = reader[14].ToString();
            rec.Format3 = reader[15].ToString();
            rec.Format4 = reader[16].ToString();
            rec.Format5 = reader[17].ToString();
            rec.Format6 = reader[18].ToString();
            rec.Format7 = reader[19].ToString();
            rec.Format8 = reader[20].ToString();
            rec.Format9 = reader[21].ToString();
            rec.Format10 = reader[22].ToString();
            rec.FSCprodcode = reader[23].ToString();
            rec.Genre = GetListItem(reader[24].ToString());
            rec.Grade = reader[25].ToString();
            rec.InsCatAll = reader[26].ToString();
            rec.Instr = reader[27].ToString();
            rec.InstrDetail = reader[28].ToString();
            rec.InstrSearch = reader[29].ToString();
            rec.KaldbNo = reader[30].ToString();
            rec.KbdCat = GetListItem(reader[31].ToString());
            rec.NameSearch = reader[32].ToString();
            rec.Pages = reader[33].ToString();
            rec.PDF = reader[34].ToString();
            rec.PercCat = GetListItem(reader[35].ToString());
            rec.Period = GetListItem(reader[36].ToString());
            rec.Price1 = reader[37].ToString();
            rec.Price2 = reader[38].ToString();
            rec.Price3 = reader[39].ToString();
            rec.Price4 = reader[40].ToString();
            rec.Price5 = reader[41].ToString();
            rec.Price6 = reader[42].ToString();
            rec.Price7 = reader[43].ToString();
            rec.Price8 = reader[44].ToString();
            rec.Price9 = reader[45].ToString();
            rec.Price10 = reader[46].ToString();
            rec.PTSprodcode = reader[47].ToString();
            rec.Publisher = reader[48].ToString();
            rec.QTFile1 = reader[49].ToString();
            rec.QTFile2 = reader[50].ToString();
            rec.QTFile3 = reader[51].ToString();
            rec.QTFile4 = reader[52].ToString();
            rec.QTFile5 = reader[53].ToString();
            rec.QTFile6 = reader[54].ToString();
            rec.QTFile7 = reader[55].ToString();
            rec.QTFile8 = reader[56].ToString();
            rec.QTFile9 = reader[57].ToString();
            rec.QTFile10 = reader[58].ToString();
            rec.QTFile11 = reader[59].ToString();
            rec.recid = reader[60].ToString();
            rec.ReprintSource = GetListItem(reader[61].ToString());
            rec.s4MasterSeries = reader[62].ToString();
            rec.s5MasterSeries = reader[63].ToString();
            rec.Series = GetListItem(reader[64].ToString());
            rec.SoundFile1 = reader[65].ToString();
            rec.SoundFile2 = reader[66].ToString();
            rec.SoundFile3 = reader[67].ToString();
            rec.SoundFile4 = reader[68].ToString();
            rec.SoundFile5 = reader[69].ToString();
            rec.SoundFile6 = reader[70].ToString();
            rec.SoundFile7 = reader[71].ToString();
            rec.SoundFile8 = reader[72].ToString();
            rec.SoundFile9 = reader[73].ToString();
            rec.SoundFile10 = reader[74].ToString();
            rec.SoundFile11 = reader[75].ToString();
            rec.SoundFile12 = reader[76].ToString();
            rec.SoundFile13 = reader[77].ToString();
            rec.SoundFile14 = reader[78].ToString();
            rec.SoundFile15 = reader[79].ToString();
            rec.SoundIcon = reader[80].ToString();
            rec.StrCat = GetListItem(reader[81].ToString());
            rec.SubtitleConts = GetListItem(reader[82].ToString());
            rec.Test = reader[83].ToString();
            rec.TextLang = reader[84].ToString();
            rec.TitleDisp = reader[85].ToString();
            rec.TitleList = reader[86].ToString();
            rec.TitleSearch = reader[87].ToString();
            rec.TitleSort = reader[88].ToString();
            rec.Track1 = reader[89].ToString();
            rec.Track2 = reader[90].ToString();
            rec.Track3 = reader[91].ToString();
            rec.Track4 = reader[92].ToString();
            rec.Track5 = reader[93].ToString();
            rec.Track6 = reader[94].ToString();
            rec.Track7 = reader[95].ToString();
            rec.Track8 = reader[96].ToString();
            rec.Track9 = reader[97].ToString();
            rec.Track10 = reader[98].ToString();
            rec.VocAccomp = reader[99].ToString();
            rec.VocalCat = GetListItem(reader[100].ToString());
            rec.WWCat = GetListItem(reader[101].ToString());
            rec.XForm1 = reader[102].ToString();
            rec.XForm2 = reader[103].ToString();
            rec.XForm3 = reader[104].ToString();
            rec.XForm4 = reader[105].ToString();
            rec.XForm5 = reader[106].ToString();
            rec.Year = reader[107].ToString();
            rec.Arranger_FirstLetter = reader[108].ToString();
            rec.Composer_FirstLetter = reader[109].ToString();
            return rec;
        }

        public static List<string> GetListItem(string input)
        {
            string[] arr = input.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            List<string> ret = new List<string>();
            if (arr != null && arr.Length > 0)
            {
                foreach (string item in arr)
                {
                    ret.Add(item);
                }
            }
            return ret;
        }

        public static List<string[]> GetArrangerInfo(string input)
        {
            List<string> firstParse = GetListItem(input);
            List<string[]> result = new List<string[]>();

            foreach (string item in firstParse)
            {
                int index = item.LastIndexOf(',');
                if (index > 0)
                {
                    string[] secondParse = new string[2];
                    secondParse[0] = item.Substring(0, index);
                    secondParse[1] = item.Substring(index + 2, item.Length - index - 2);
                    result.Add(secondParse);
                }
                else
                {
                    string[] secondParse = new string[2];
                    secondParse[0] = string.Empty;
                    secondParse[1] = item;
                    result.Add(secondParse);
                }
            }
            return result;
        }

        //\Tungnho insert
        private static void CreateNopProudct(FP7Record obj)
        {
            //TODO: nop save product include 4 function 
            //NopCommerceStore\Administration\Modules\ProductAdd.ascx.cs
            //product = ctrlProductInfoAdd.SaveInfo();
            //ctrlProductSEO.SaveInfo(product.ProductId);
            //ctrlProductCategory.SaveInfo(product.ProductId);
            //ctrlProductManufacturer.SaveInfo(product.ProductId);
            Product product = SaveInfo(obj);
            SaveProductSEO(product.ProductId);
            SaveProductCatagory(product.ProductId);
            SaveProductManufacturer(product.ProductId);

            // Save Picture
            InsertPicture(obj.CatNo.Trim(), product.ProductId);
            // Save LWG infor
            CreateCatalogLWG(product.ProductId, obj);
        }

        // Save ProductInfo
        public static Product SaveInfo(FP7Record obj)
        {
            DateTime nowDT = DateTime.Now;
            string productName = obj.TitleList.TrimStart().TrimEnd().Equals(string.Empty) ? obj.TitleDisp.TrimStart().TrimEnd() : obj.TitleList.TrimStart().TrimEnd();
            string name = productName;
            string shortDescription = obj.TitleSort.TrimStart().TrimEnd();
            string fullDescription = obj.TitleDisp.TrimStart().TrimEnd();
            string adminComment = string.Empty;
            int productTypeId = 1;
            int templateId = 4;
            bool showOnHomePage = false;
            bool allowCustomerReviews = true;
            bool allowCustomerRatings = true;
            bool published = true;
            string sku = obj.CatNo.ToString(); // TODO:
            string manufacturerPartNumber = string.Empty;
            bool isGiftCard = false;
            bool isDownload = false;
            int productVariantDownloadId = 0;

            bool unlimitedDownloads = true;
            int maxNumberOfDownloads = 10;
            int? downloadExpirationDays = null;
            DownloadActivationTypeEnum downloadActivationType = DownloadActivationTypeEnum.WhenOrderIsPaid;
            bool hasUserAgreement = false;
            string userAgreementText = string.Empty;

            bool hasSampleDownload = false;
            int productVariantSampleDownloadId = 0;

            bool isRecurring = false;
            int cycleLength = 100;
            RecurringProductCyclePeriodEnum cyclePeriod = RecurringProductCyclePeriodEnum.Days;
            int totalCycles = 10;

            bool isShipEnabled = true;
            bool isFreeShipping = false;
            decimal additionalShippingCharge = 0;
            bool isTaxExempt = false;
            int taxCategoryId = 0;
            int manageStock = 1;
            int stockQuantity = 10000;
            bool displayStockAvailability = false;
            int minStockQuantity = 0;
            LowStockActivityEnum lowStockActivity = LowStockActivityEnum.Nothing;
            int notifyForQuantityBelow = 1;
            bool allowOutOfStockOrders = false;
            int orderMinimumQuantity = 1;
            int orderMaximumQuantity = 10000;
            int warehouseId = 0;
            bool disableBuyButton = false;
            //\
            decimal tempPrice = 0; //TODO:
            decimal price = decimal.TryParse(obj.Price1, out tempPrice) == true ? tempPrice : 0;
            decimal oldPrice = 0;
            decimal productCost = 0;
            bool customerEntersPrice = false;
            decimal minimumCustomerEnteredPrice = 0;
            decimal maximumCustomerEnteredPrice = 1000;
            decimal weight = 0;
            decimal length = 0;
            decimal width = 0;
            decimal height = 0;
            DateTime? availableStartDateTime = null;
            DateTime? availableEndDateTime = null;

            Product product = ProductManager.InsertProduct(name, shortDescription, fullDescription,
                adminComment, productTypeId, templateId, showOnHomePage, string.Empty, string.Empty,
                string.Empty, string.Empty, allowCustomerReviews, allowCustomerRatings, 0, 0,
                 published, false, DateTime.Now, DateTime.Now);

            ProductVariant productVariant = ProductManager.InsertProductVariant(product.ProductId,
                 string.Empty, sku, string.Empty, string.Empty, manufacturerPartNumber,
                 isGiftCard, isDownload, productVariantDownloadId, unlimitedDownloads,
                 maxNumberOfDownloads, downloadExpirationDays, downloadActivationType,
                 hasSampleDownload, productVariantSampleDownloadId,
                 hasUserAgreement, userAgreementText,
                 isRecurring, cycleLength, (int)cyclePeriod, totalCycles,
                 isShipEnabled, isFreeShipping, additionalShippingCharge, isTaxExempt,
                 taxCategoryId, manageStock, stockQuantity, displayStockAvailability,
                 minStockQuantity, lowStockActivity, notifyForQuantityBelow, allowOutOfStockOrders,
                 orderMinimumQuantity, orderMaximumQuantity, warehouseId, disableBuyButton,
                 price, oldPrice, productCost, customerEntersPrice,
                 minimumCustomerEnteredPrice, maximumCustomerEnteredPrice,
                 weight, length, width, height, 0, availableStartDateTime, availableEndDateTime,
                 published, false, 1, DateTime.Now, DateTime.Now, string.Empty);
            //SaveLocalizableContent(product); only one language

            return product;
        }

        // Save ProductSEO
        public static void SaveProductSEO(int prodId)
        {
            Product product = ProductManager.GetProductById(prodId, 0);
            if (product != null)
            {
                product = ProductManager.UpdateProduct(product.ProductId, product.Name, product.ShortDescription,
                    product.FullDescription, product.AdminComment, product.ProductTypeId,
                    product.TemplateId, product.ShowOnHomePage, string.Empty,
                    string.Empty, string.Empty, string.Empty,
                    product.AllowCustomerReviews, product.AllowCustomerRatings, product.RatingSum,
                    product.TotalRatingVotes, product.Published, product.Deleted, product.CreatedOn, DateTime.Now);
            }
        }

        // Save ProductCatagory  //TODO: hard code info
        public static void SaveProductCatagory(int prodId)
        {
            CategoryManager.InsertProductCategory(prodId, 74, false, 1);
        }

        // Save ProductManufacturer
        public static void SaveProductManufacturer(int prodId)
        {
            //TODO: not using this function
        }

        ///////
        public static int CreateCatalogLWG(int productID, FP7Record obj)
        {
            try
            {
                CatalogBiz cBiz = new CatalogBiz();
                lwg_Catalog p = cBiz.GetByID(productID);
                if (p == null)
                {
                    p = new lwg_Catalog();
                }
                // insert data
                p.ArrangerGroupId = 1;
                p.Blurb = obj.Blurb;
                p.CatalogNumber = obj.CatNo;
                p.Duration = obj.Duration;
                p.Format1 = obj.Format1;
                p.Format10 = obj.Format10;
                p.Format2 = obj.Format2;
                p.Format3 = obj.Format3;
                p.Format4 = obj.Format4;
                p.Format5 = obj.Format5;
                p.Format6 = obj.Format6;
                p.Format7 = obj.Format7;
                p.Format8 = obj.Format8;
                p.Format9 = obj.Format9;
                p.FSCprodcode = obj.FSCprodcode;
                p.Grade = obj.Grade;

                //Instrumental
                InstrumentalBiz lBiz = new InstrumentalBiz();
                if (!string.IsNullOrEmpty(obj.Instr))
                {
                    int instrumentalID = lBiz.CheckAndInsertInstrumental(obj.Instr);
                    if (instrumentalID > 0)
                    {
                        p.InstrumentalId = instrumentalID;
                    }
                }

                p.KaldbNumber = obj.KaldbNo;
                p.pages = obj.Pages;
                //string tempPDF = string.Empty;
                //string strPDF = SavePDFFile(uploadPDF, ref tempPDF);
                //if (string.IsNullOrEmpty(tempPDF))
                //{
                //    LWGUtils.ClearOldFile(string.Format("{0}{1}", LWGUtils.GetPDFPath(), p.PDF));
                //    p.PDF = strPDF;  // txtPDF.Text;// "PDF1"; //TODO: change to uploadfile control
                //}
                //p.PDF = p.PDF == null ? string.Empty : p.PDF;
                p.PDF = obj.PDF; //TODO: fix here.

                double tempPrice = 0;
                if (double.TryParse(obj.Price1, out tempPrice))
                {
                    p.Price1 = tempPrice;
                }
                if (double.TryParse(obj.Price2, out tempPrice))
                {
                    p.Price2 = tempPrice;
                }
                if (double.TryParse(obj.Price3, out tempPrice))
                {
                    p.Price3 = tempPrice;
                }
                if (double.TryParse(obj.Price4, out tempPrice))
                {
                    p.Price4 = tempPrice;
                }
                if (double.TryParse(obj.Price5, out tempPrice))
                {
                    p.Price5 = tempPrice;
                }
                if (double.TryParse(obj.Price6, out tempPrice))
                {
                    p.Price6 = tempPrice;
                }
                if (double.TryParse(obj.Price7, out tempPrice))
                {
                    p.Price7 = tempPrice;
                }
                if (double.TryParse(obj.Price8, out tempPrice))
                {
                    p.Price8 = tempPrice;
                }
                if (double.TryParse(obj.Price9, out tempPrice))
                {
                    p.Price9 = tempPrice;
                }
                if (double.TryParse(obj.Price10, out tempPrice))
                {
                    p.Price10 = tempPrice;
                }

                p.PTSprodcode = obj.PTSprodcode;

                //p.QTFile1 = obj.QTFile1;

                //p.QTFile2 = obj.QTFile2;

                //p.QTFile3 = obj.QTFile3;

                //p.QTFile4 = obj.QTFile4;

                //p.QTFile5 = obj.QTFile5;

                //p.QTFile6 = obj.QTFile6;

                //p.QTFile7 = obj.QTFile7;

                //p.QTFile8 = obj.QTFile8;

                //p.QTFile9 = obj.QTFile9;

                //p.QTFile10 = obj.QTFile10;

                //p.QTFile11 = obj.QTFile11;

                //p.recid = string.IsNullOrEmpty(txtrecid.Text.Trim()) ? 0 : int.Parse(txtrecid.Text);// 1;// what's recid ?
                p.recid = int.Parse(obj.recid);

                p.S4MasterSeries = obj.s4MasterSeries;
                p.S5MasterCategories = obj.s5MasterSeries;

                //p.SoundFile1 = obj.SoundFile1;

                //p.SoundFile2 = obj.SoundFile2;

                //p.SoundFile3 = obj.SoundFile3;

                //p.SoundFile4 = obj.SoundFile4;

                //p.SoundFile5 = obj.SoundFile5;

                //p.SoundFile6 = obj.SoundFile6;

                //p.SoundFile7 = obj.SoundFile7;

                //p.SoundFile8 = obj.SoundFile8;

                //p.SoundFile9 = obj.SoundFile9;

                //p.SoundFile10 = obj.SoundFile10;

                //p.SoundFile11 = obj.SoundFile11;

                //p.SoundFile12 = obj.SoundFile12;

                //p.SoundFile13 = obj.SoundFile13;

                //p.SoundFile14 = obj.SoundFile14;

                //p.SoundFile15 = obj.SoundFile15;

                p.SoundIcon = string.Empty;
                if (!string.IsNullOrEmpty(obj.SoundIcon))
                {
                    p.SoundIcon = InsertSoundIcon(obj.SoundIcon);//obj.SoundIcon;
                }
                p.Subtitle = string.Empty; //TODO: chua biet lam sao ?
                p.TextLang = obj.TextLang;
                p.TitleDisplay = obj.TitleDisp;
                p.TitleList = obj.TitleList;
                p.TitleSort = obj.TitleSort;

                p.Track01 = obj.Track1;

                p.Track02 = obj.Track2;

                p.Track03 = obj.Track3;

                p.Track04 = obj.Track4;

                p.Track05 = obj.Track5;

                p.Track06 = obj.Track6;

                p.Track07 = obj.Track7;

                p.Track08 = obj.Track8;

                p.Track09 = obj.Track9;

                p.Track10 = obj.Track10;

                p.Xform1 = obj.XForm1;
                p.Xform2 = obj.XForm2;
                p.Xform3 = obj.XForm3;
                p.Xform4 = obj.XForm4;
                p.Xform5 = obj.XForm5;
                //TODO: obj.Year ;
                if (!string.IsNullOrEmpty(obj.Year))
                {
                    p.Year = obj.Year;
                    //try
                    //{
                    //    int yearForm = 0;
                    //    int yearTo = 0;
                    //    string tempYear = ConverStringYear(obj.Year);
                    //    if (tempYear.Length == 4 || tempYear.Length == 8)
                    //    {

                    //        if (tempYear.Length == 4 && int.TryParse(tempYear, out yearForm))
                    //        {
                    //            p.YearFrom = yearForm;
                    //            p.YearTo = yearForm;
                    //        }
                    //        else if (tempYear.Length == 8)
                    //        {
                    //            if (int.TryParse(tempYear.Substring(0, 4), out yearForm))
                    //            {
                    //                p.YearFrom = yearForm;
                    //            }
                    //            if (int.TryParse(tempYear.Substring(4), out yearTo))
                    //            {
                    //                p.YearTo = yearTo;
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        string[] lstYear = tempYear.Split('/');
                    //        if (lstYear != null && lstYear.Count() > 0)
                    //        {
                    //            string strYear = string.Empty;
                    //            if (!string.IsNullOrEmpty(lstYear[0]))
                    //            {
                    //                strYear = lstYear[0];
                    //                if (lstYear[0].Length > 4)
                    //                {
                    //                    strYear = lstYear[0].Substring(0, 4);
                    //                }
                    //                if (int.TryParse(strYear, out yearForm))
                    //                {
                    //                    p.YearFrom = yearForm;
                    //                }
                    //            }
                    //            if (lstYear.Count() > 1 && !string.IsNullOrEmpty(lstYear[1]))
                    //            {
                    //                strYear = lstYear[1];
                    //                if (lstYear[1].Length > 4)
                    //                {
                    //                    strYear = lstYear[1].Substring(0, 4);
                    //                }
                    //                if (int.TryParse(lstYear[1], out yearTo))
                    //                {
                    //                    p.YearTo = yearTo;
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    Console.WriteLine(obj.CatNo + " Parse Year Error: " + ex.Message);
                    //    tempBuilder.Append(obj.CatNo + " -- Parse Year Error " + ex.Message + System.Environment.NewLine);
                    //}
                }
                //p.YearFrom = ; 
                //p.YearTo = ;

                p.InstrDetail = obj.InstrDetail;
                if (!string.IsNullOrEmpty(obj.VocAccomp))
                {
                    p.VocAccomp = obj.VocAccomp.ToUpper().Equals("YES") ? true : false;
                }
                p.CatalogId = productID;
                //Save Catalog
                if (cBiz.SaveCatalog(p))
                {
                    // save publisher, genre,...                               

                    if (!string.IsNullOrEmpty(obj.InstrSearch))
                    {
                        lwg_CatalogInstrumentSearch lwg = new lwg_CatalogInstrumentSearch();
                        lwg.CatalogId = p.CatalogId;
                        lwg.IntrText = obj.InstrSearch;
                        cBiz.SaveCatalogInstrumentalSearch(lwg);
                    }

                    if (!string.IsNullOrEmpty(obj.NameSearch))
                    {
                        lwg_CatalogNameSearch lwg = new lwg_CatalogNameSearch();
                        lwg.CatalogId = p.CatalogId;
                        lwg.Name = obj.NameSearch;
                        cBiz.SaveCatalogNameSearch(lwg);
                    }

                    if (!string.IsNullOrEmpty(obj.TitleSearch))
                    {
                        lwg_CatalogTitleSearch lwg = new lwg_CatalogTitleSearch();
                        lwg.CatalogId = p.CatalogId;
                        lwg.Title = obj.TitleSearch;
                        cBiz.SaveCatalogTitleSearch(lwg);
                    }
                    // insert data with multi record
                    //cBiz.SaveCatalogPublisher(p.CatalogId, int.Parse(drpCatalogPublisher.SelectedValue));
                    if (!string.IsNullOrEmpty(obj.Publisher.TrimStart()))
                    {
                        InsertPublisher(obj.Publisher, p.CatalogId);
                    }

                    //Insert Series list
                    if (obj.Series != null && obj.Series.Count > 0)
                    {
                        InsertSeries(obj.Series, p.CatalogId);
                    }

                    // Insert ReprintSource
                    if (obj.ReprintSource != null && obj.ReprintSource.Count > 0)
                    {
                        InsertReprintSource(obj.ReprintSource, p.CatalogId);
                    }

                    // Insert Period
                    if (obj.Period != null && obj.Period.Count > 0)
                    {
                        InsertPeriod(obj.Period, p.CatalogId);
                    }

                    // Insert Genre
                    if (obj.Genre != null && obj.Genre.Count > 0)
                    {
                        InsertGenre(obj.Genre, p.CatalogId);
                    }

                    //Insert InStrTitle, have 9 Title type ( see TitleType )
                    if (obj.BdWECat != null && obj.BdWECat.Count > 0) // Band/Wind Ens
                    {
                        InsertInstrTitle(obj.BdWECat, p.CatalogId, 8); //TODO: hard code TitleTypeID        
                    }
                    if (obj.BrCat != null && obj.BrCat.Count > 0) //Brass
                    {
                        InsertInstrTitle(obj.BrCat, p.CatalogId, 4); //TODO: hard code TitleTypeID        
                    }
                    if (obj.ChEnsCat != null && obj.ChEnsCat.Count > 0)  // Chamber Ens
                    {
                        InsertInstrTitle(obj.ChEnsCat, p.CatalogId, 6); //TODO: hard code TitleTypeID        
                    }
                    if (obj.EnsCat != null && obj.EnsCat.Count > 0) // ens Cat
                    {
                        InsertInstrTitle(obj.EnsCat, p.CatalogId, 7); //TODO: hard code TitleTypeID        
                    }
                    if (obj.KbdCat != null && obj.KbdCat.Count > 0) //keyboard
                    {
                        InsertInstrTitle(obj.KbdCat, p.CatalogId, 1); //TODO: hard code TitleTypeID        
                    }
                    if (obj.PercCat != null && obj.PercCat.Count > 0) // Percussion
                    {
                        InsertInstrTitle(obj.PercCat, p.CatalogId, 5); //TODO: hard code TitleTypeID        
                    }
                    if (obj.StrCat != null && obj.StrCat.Count > 0)//String
                    {
                        InsertInstrTitle(obj.StrCat, p.CatalogId, 2); //TODO: hard code TitleTypeID        
                    }
                    if (obj.VocalCat != null && obj.VocalCat.Count > 0) // Vocal/Choral
                    {
                        InsertInstrTitle(obj.VocalCat, p.CatalogId, 9); //TODO: hard code TitleTypeID        
                    }
                    if (obj.WWCat != null && obj.WWCat.Count > 0) //WoodWind
                    {
                        InsertInstrTitle(obj.WWCat, p.CatalogId, 3); //TODO: hard code TitleTypeID        
                    }

                    //CompDisp
                    if (!string.IsNullOrEmpty(obj.CompDist))
                    {
                        CreateComposer(obj.CompDist, obj.CompList, obj.CompSort, p.CatalogId);
                    }
                    //ArrEd
                    if (obj.ArrEd != null && obj.ArrEd.Count > 0)
                    {
                        InsertArrEd(obj.ArrEd, p.CatalogId);
                    }

                    //Insert Catagory
                    if (obj.Category != null && obj.Category.Count > 0)
                    {
                        foreach (string catagoryName in obj.Category)
                        {
                            if (!string.IsNullOrEmpty(catagoryName.TrimStart()))
                            {
                                int catagoryID = InsertCatagory(catagoryName);
                                if (catagoryID > 0)
                                {
                                    CategoryManager.InsertProductCategory(productID, catagoryID, false, 1);
                                }
                            }
                        }
                    }

                    // Insert catagory insert by NopCommerce.

                    return p.CatalogId;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("   CreateCatalogLWG Error: " + ex.Message);
                tempBuilder.Append("Record - " + obj.CatNo + " Error " + ex.Message + System.Environment.NewLine);
            }
            return 0;
        }

        private static void InsertArrEd(List<string[]> lst, int catalogID)
        {
            foreach (string[] lstArrEd in lst)
            {
                PersonBiz pBiz = new PersonBiz();
                if (lstArrEd.Count() == 2)
                {
                    string fullName = lstArrEd[0];
                    string position = lstArrEd[1];
                    int persionID = CheckAndInsertPerson(fullName);
                    if (persionID > 0)
                    {
                        string[] lstPosition;
                        if (position.IndexOf('/') > 0)
                        {
                            lstPosition = position.Split('/');
                            foreach (string subPesition in lstPosition)
                            {
                                int roleID = CheckAndInsertRole(subPesition);
                                lwg_PersonInRole personInRole = new lwg_PersonInRole();
                                personInRole.PersonId = persionID;
                                personInRole.RoleId = roleID;
                                personInRole.CatalogId = catalogID;
                                pBiz.SavePersonInRole(personInRole);
                            }
                        }
                        else
                        {
                            int roleID = CheckAndInsertRole(position);
                            lwg_PersonInRole personInRole = new lwg_PersonInRole();
                            personInRole.PersonId = persionID;
                            personInRole.RoleId = roleID;
                            personInRole.CatalogId = catalogID;
                            pBiz.SavePersonInRole(personInRole);
                        }
                    }
                    else
                    {
                        // Invalid person infor
                    }
                }
            }
        }

        private static void CreateComposer(string compDisp, string compList, string compSort, int catalogID)
        {
            PersonBiz pBiz = new PersonBiz();
            lwg_Person person;
            string[] lst = compDisp.Split(',');
            if (lst != null && lst.Count() == 2)
            {
                string fName = lst[0].TrimStart().TrimEnd();
                string lName = lst[1].TrimStart();
                string temp = string.Empty;
                int index = lName.IndexOf('(');
                if (index > 0)
                {
                    lName = lName.Substring(0, index);
                }
                person = pBiz.GetPersonByName(fName, lName);
                if (person == null)
                {
                    person = new lwg_Person();
                    person.Biography = compDisp;
                    person.FirstName = fName.ToUpper();
                    person.LastName = lName;
                    person.NameDisplay = compDisp;
                    person.NameList = compList;
                    person.NameSort = compSort;
                    person.FirstLetter = fName.Substring(0, 1).ToUpper();
                    person = pBiz.SaveImport(person);
                }
                lwg_PersonInRole personInrole = new lwg_PersonInRole();
                personInrole.CatalogId = catalogID;
                personInrole.PersonId = person.PersonId;
                personInrole.RoleId = 1;// TODO hard code-> 1	Composer
                pBiz.SavePersonInRole(personInrole);
            }
            else
            {
                //TODO: case error compDisp have two record
                //McQUAIDE, George - pseudonym for
                //BARNARD, George Daniel (1858-1933)
            }
        }

        private static void InsertInstrTitle(List<string> lstInstrTitle, int catalogID, int titleTypeID)
        {
            InstrTitleBiz iBiz = new InstrTitleBiz();
            foreach (string instrTitleName in lstInstrTitle)
            {
                if (!string.IsNullOrEmpty(instrTitleName.TrimStart().TrimEnd()))
                {
                    iBiz.CheckAndInsertInstrTitle(instrTitleName, catalogID, titleTypeID);
                }
            }
        }

        private static void InsertGenre(List<string> lstGenreName, int catalogID)
        {
            GenerBiz gBiz = new GenerBiz();
            foreach (string genreName in lstGenreName)
            {
                if (!string.IsNullOrEmpty(genreName.TrimStart().TrimEnd()))
                {
                    gBiz.CheckAndInsertGenre(genreName, catalogID);
                }
            }
        }

        private static void InsertPeriod(List<string> lstPeriodName, int catalogID)
        {
            PeriodBiz pBiz = new PeriodBiz();
            foreach (string periodName in lstPeriodName)
            {
                if (!string.IsNullOrEmpty(periodName.TrimStart().TrimEnd()))
                {
                    pBiz.CheckAndInsertPeriod(periodName, catalogID);
                }
            }
        }

        private static void InsertReprintSource(List<string> lstRepringSourceName, int catalogID)
        {
            ReprintSourceBiz rBiz = new ReprintSourceBiz();
            foreach (string repringSourceName in lstRepringSourceName)
            {
                if (!string.IsNullOrEmpty(repringSourceName.TrimStart().TrimEnd()))
                {
                    rBiz.CheckAndInsertRepringSource(repringSourceName, catalogID);
                    //TODO: what happen if insert fail ?
                }
            }
        }

        private static void InsertSeries(List<string> lstSeriesName, int catalogID)
        {
            SeriesBiz sBiz = new SeriesBiz();
            foreach (string seriesName in lstSeriesName)
            {
                if (!string.IsNullOrEmpty(seriesName.TrimStart().TrimEnd()))
                {
                    sBiz.CheckAndInsertSeries(seriesName, catalogID);
                    //TODO: what happen if insert fail ?
                }
            }

        }

        private static void InsertPublisher(string publisherName, int catalogID)
        {
            PublisherBiz pBiz = new PublisherBiz();
            pBiz.CheckAndInsertPublisher(publisherName, catalogID);
            //TODO: what happen if insert fail ?
        }

        // check person, return personID
        private static int CheckAndInsertPerson(string fullDescription)
        {
            PersonBiz pBiz = new PersonBiz();
            lwg_Person person;
            string[] lst = fullDescription.Split(',');
            if (lst != null && lst.Count() == 2)
            {
                string fName = lst[0].TrimStart().TrimEnd();
                string lName = lst[1].TrimStart();
                string temp = string.Empty;
                int index = lName.IndexOf('(');
                if (index > 0)
                {
                    lName = lName.Substring(0, index);
                }
                person = pBiz.GetPersonByName(fName, lName);
                if (person == null)
                {
                    person = new lwg_Person();
                    person.Biography = fullDescription;
                    person.FirstName = fName.ToUpper();
                    person.LastName = lName;
                    person.NameDisplay = fullDescription;
                    person.NameList = string.Empty;
                    person.NameSort = string.Empty;
                    person.FirstLetter = fName.Substring(0, 1).ToUpper();
                    person = pBiz.SaveImport(person);
                }
                return person.PersonId;
            }
            else
            {
                return -1; // Invalid person
            }
        }

        // check and insert Role by roleName
        private static int CheckAndInsertRole(string roleName)
        {
            RoleBiz rBiz = new RoleBiz();
            return rBiz.CheckAndInsertRole(roleName.TrimStart().TrimEnd());
        }

        // Insert Catagory : American // hard code parentCatagory
        private static int InsertCatagory(string catagoryName)
        {
            try
            {
                catagoryName = catagoryName.TrimStart().TrimEnd();
                Category category;
                CategoryCollection coll = CategoryManager.GetAllCategories(92, true, 7);
                if (coll != null && coll.Count > 0)
                {
                    foreach (Category c in coll)
                    {
                        if (c.Name.ToLower().Equals(catagoryName.ToLower()))
                        {
                            return c.CategoryId;
                        }
                    }
                }
                // Save catagory
                category = CategoryManager.InsertCategory(catagoryName, catagoryName, 3,
                              string.Empty, string.Empty, string.Empty, string.Empty, 92,
                              0, 10, string.Empty, false, true, false, 1, DateTime.Now, DateTime.Now);
                category = CategoryManager.UpdateCategory(category.CategoryId, category.Name, category.Description, category.TemplateId,
                         string.Empty, string.Empty, string.Empty, string.Empty, category.ParentCategoryId,
                         category.PictureId, 10, category.PriceRanges, category.ShowOnHomePage, category.Published, category.Deleted, category.DisplayOrder, category.CreatedOn, DateTime.Now);
                return category.CategoryId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(catagoryName + " InsertCatagory Error: " + ex.Message);
                tempBuilder.Append(catagoryName + " -- InsertCatagory Error " + ex.Message + System.Environment.NewLine);
                return -1;
            }
        }

        // Insert Picture
        private static void InsertPicture(string fileName, int productID)
        {
            string[] lstFiles;
            try
            {
                if (Directory.Exists(@"D:\ImageLWG\"))
                {
                    lstFiles = Directory.GetFiles(@"D:\ImageLWG\");
                    if (lstFiles != null && lstFiles.Count() > 0)
                    {
                        var lFile = lstFiles.Where(o => o.Contains(fileName));
                        if (lFile != null && lFile.Count() > 0)
                        {
                            foreach (var temp in lFile)
                            {
                                FileInfo fInfo = new FileInfo(temp);
                                string name = fInfo.Name.Substring(0, fInfo.Name.LastIndexOf('.'));
                                if (name.Equals(fileName))
                                {
                                    Byte[] buffer = File.ReadAllBytes(temp);

                                    Product product = ProductManager.GetProductById(productID);
                                    Picture picture = PictureManager.InsertPicture(buffer, fInfo.Extension, true);
                                    if (picture != null)
                                    {
                                        ProductPicture productPicture = ProductManager.InsertProductPicture(product.ProductId, picture.PictureId, 1);
                                    }
                                }
                                //or
                                /*byte[] data = null;
                                FileInfo fInfo = new FileInfo(sPath);
                                long numBytes = fInfo.Length;
                                FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
                                BinaryReader br = new BinaryReader(fStream);
                                data = br.ReadBytes((int)numBytes);
                                return data;*/
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetImageFile Error : " + ex.Message);
                tempBuilder.Append("GetImageFile Error : " + ex.Message + System.Environment.NewLine);
            }
        }

        private static string ConverStringYear(string str)
        {
            string result = string.Empty;
            result = str.Replace('c', ' ');
            result = result.Replace('(', ' ');
            result = result.Replace(')', ' ');
            result = result.Replace('[', ' ');
            result = result.Replace(']', ' ');
            result = result.Replace('a', ' ');
            result = result.Replace('.', ' ');
            result = result.Replace('\n', '/');
            result = result.Replace(';', '/');
            result = result.Replace('-', '/');
            result = result.Replace(',', '/');
            return result.Trim();
        }

        private static string InsertSoundIcon(string soundIcon)
        {
            try
            {
                string fullPath = string.Format(@"D:\ImageLWG\{0}", soundIcon);
                if (File.Exists(fullPath))
                {
                    FileInfo fInfo = new FileInfo(fullPath);
                    Byte[] buffer = File.ReadAllBytes(fullPath);                     
                    Picture picture = PictureManager.InsertPicture(buffer, fInfo.Extension, true);
                    if (picture != null)
                    {
                        return picture.PictureId.ToString();
                    }
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Save SoundIcon Error : " + ex.Message);
                tempBuilder.Append("Save SoundIcon Error : " + ex.Message + System.Environment.NewLine);
                return string.Empty;
            }
        }
        //\ end
    }

    class FP7Record
    {
        public List<string[]> ArrEd { get; set; }
        public List<string> BdWECat { get; set; }
        public string Blurb { get; set; }
        public List<string> BrCat { get; set; }
        public string Cat { get; set; }
        public List<string> Category { get; set; }
        public string CatNo { get; set; }
        public List<string> ChEnsCat { get; set; }
        public string CompDist { get; set; }
        public string CompList { get; set; }
        public string CompSort { get; set; }
        public string Duration { get; set; }
        public List<string> EnsCat { get; set; }
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
        public string FSCprodcode { get; set; }
        public List<string> Genre { get; set; }
        public string Grade { get; set; }
        public string InsCatAll { get; set; }
        public string Instr { get; set; }
        public string InstrDetail { get; set; }
        public string InstrSearch { get; set; }
        public string KaldbNo { get; set; }
        public List<string> KbdCat { get; set; }
        public string NameSearch { get; set; }
        public string Pages { get; set; }
        public string PDF { get; set; }
        public List<string> PercCat { get; set; }
        public List<string> Period { get; set; }
        public string Price1 { get; set; }
        public string Price2 { get; set; }
        public string Price3 { get; set; }
        public string Price4 { get; set; }
        public string Price5 { get; set; }
        public string Price6 { get; set; }
        public string Price7 { get; set; }
        public string Price8 { get; set; }
        public string Price9 { get; set; }
        public string Price10 { get; set; }
        public string PTSprodcode { get; set; }
        public string Publisher { get; set; }
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
        public string recid { get; set; }
        public List<string> ReprintSource { get; set; }
        public string s4MasterSeries { get; set; }
        public string s5MasterSeries { get; set; }
        public List<string> Series { get; set; }
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
        public List<string> StrCat { get; set; }
        public List<string> SubtitleConts { get; set; }
        public string Test { get; set; }
        public string TextLang { get; set; }
        public string TitleDisp { get; set; }
        public string TitleList { get; set; }
        public string TitleSearch { get; set; }
        public string TitleSort { get; set; }
        public string Track1 { get; set; }
        public string Track2 { get; set; }
        public string Track3 { get; set; }
        public string Track4 { get; set; }
        public string Track5 { get; set; }
        public string Track6 { get; set; }
        public string Track7 { get; set; }
        public string Track8 { get; set; }
        public string Track9 { get; set; }
        public string Track10 { get; set; }
        public string VocAccomp { get; set; }
        public List<string> VocalCat { get; set; }
        public List<string> WWCat { get; set; }
        public string XForm1 { get; set; }
        public string XForm2 { get; set; }
        public string XForm3 { get; set; }
        public string XForm4 { get; set; }
        public string XForm5 { get; set; }
        public string Year { get; set; }
        public string Arranger_FirstLetter { get; set; }
        public string Composer_FirstLetter { get; set; }
    }
}
