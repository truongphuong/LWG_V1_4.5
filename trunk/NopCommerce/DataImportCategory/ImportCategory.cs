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

namespace DataImportCategory
{
    class ImportCategory
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
            TextWriter tw = new StreamWriter("LWG_Log_Category_" + DateTime.Now.Ticks + "_.txt");

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

                        if (fpr.Category !=null && fpr.Category.Count >0)
                        {
                            foreach (string catagoryName in fpr.Category)
                            {
                                if (!string.IsNullOrEmpty(catagoryName))
                                {
                                    int catagoryID = InsertCatagory(catagoryName.TrimStart().TrimEnd());                                    
                                    Console.WriteLine("Record " + i + " Category: " + catagoryName + " CategoryID : " + catagoryID);
                                    tempBuilder.Append("Record " + i + " - " + fpr.CatNo + " Category: "+catagoryName +" CategoryID "+ catagoryID + System.Environment.NewLine);
                                    if (catagoryID <= 0)
                                    {
                                        Console.WriteLine("---------------------------------------------------------------------------------");
                                        tempBuilder.Append("--------------------------------------------------------------------------------" + System.Environment.NewLine);    
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Category = String.Empty!");
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
           
            rec.Category = GetListItem(reader[5].ToString());
            rec.CatNo = reader[6].ToString();
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

    }

    class FP7Record
    {
        public string CatNo { get; set; } 
        public List<string> Category { get; set; }        
    }
}
