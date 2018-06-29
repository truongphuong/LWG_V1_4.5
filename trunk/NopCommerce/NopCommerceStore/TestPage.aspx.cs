using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using LumenWorks.Framework.IO.Csv;
using LWG.Business;
using LWG.Core.Models;
using NopSolutions.NopCommerce.BusinessLogic.Categories;
using NopSolutions.NopCommerce.BusinessLogic.Products;


namespace NopSolutions.NopCommerce.Web
{
    public partial class TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            //ReadCsv();        
            SyncProductCatalog();
        }
        private void ReadCsv()
        {
            // open the file "data.csv" which is a CSV file with headers
            using (CsvReader csv =
                   new CsvReader(new StreamReader(@"D:\\LudwigMasters04072011.csv"), true))
            {
                int fieldCount = csv.FieldCount;
                string[] headers = csv.GetFieldHeaders();

                while (csv.ReadNextRecord())
                {
                    for (int i = 0; i < fieldCount; i++)
                        Console.Write(string.Format("{0} = {1};",
                                      headers[i], csv[i]));

                    Console.WriteLine();
                }
            }
        }

        public void SyncProductCatalog()
        {
            // open the file "data.csv" which is a CSV file with headers
            using (CsvReader csv =
                   new CsvReader(new StreamReader(@"D:\\LudwigMasters04072011.csv"), true))
            {
                int fieldCount = csv.FieldCount;
                string[] headers = csv.GetFieldHeaders();

                CatalogBiz cBiz = new CatalogBiz();
                int count = 0;
                int catalogID = 0;
                string catNo = string.Empty;
                while (csv.ReadNextRecord())
                {
                    try
                    {
                        catalogID = 0;
                        catNo = string.Empty;
                        for (int i = 0; i < fieldCount; i++)
                        {
                            //Console.Write(string.Format("{0} = {1};", headers[i], csv[i]));

                            if (headers[i].Equals("CategoryID"))
                            {
                                int.TryParse(csv[i], out catalogID);
                            }
                            if (headers[i].Equals("Catno"))
                            {
                                catNo = csv[i];
                            }
                        }
                        //Console.WriteLine();
                        List<lwg_Catalog> lst = cBiz.GetListLWGCatalog(catNo);
                        LWGLog.WriteLog("catNo: "+ catNo +" product Count: " + lst.Count, " updating ... "); 
                        if (lst != null && lst.Count > 0)
                        {
                            foreach (lwg_Catalog item in lst)
                            {
                                if (catalogID > 0)
                                {
                                    Product product = ProductManager.GetProductById(item.CatalogId);
                                    if (product != null)
                                    {
                                        ProductCategoryCollection existingProductCategoryCollection = product.ProductCategories;
                                        LWGLog.WriteLog("productID: " + product.ProductId + " productCatagoryCollection: " + existingProductCategoryCollection.Count, " updating ... "); 
                                        if (existingProductCategoryCollection != null && existingProductCategoryCollection.Count > 0)
                                        {
                                            //CategoryManager.InsertProductCategory(item.CatalogId, catalogID, false, 1);
                                            foreach (ProductCategory pc in existingProductCategoryCollection)
                                            {
                                                if (pc.CategoryId == 74)
                                                {
                                                    CategoryManager.UpdateProductCategory(pc.ProductCategoryId,pc.ProductId,catalogID,pc.IsFeaturedProduct,pc.DisplayOrder);
                                                    count++;
                                                    LWGLog.WriteLog("Sync Product to catalog Count: " + count + " productID: "+pc.ProductId+" catagoryID: "+ catalogID, " updating ... "); 

                                                }
                                            }
                                        }
                                        
                                    }
                                }
                            }                             
                        }                          
                    }
                    catch (Exception ex)
                    {
                        LWGLog.WriteLog("Sync Product to catalog Error: " + catNo + " ", ex.Message);           
                    }
                }
                LWGLog.WriteLog("Sync Product to catalog Count: " + count + " ", " OK "); 
            }
        }
    }
}