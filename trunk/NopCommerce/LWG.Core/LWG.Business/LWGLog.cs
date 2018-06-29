using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Web.UI;
using System.Web;

namespace LWG.Business
{
    public class LWGLog  
    {
        private static void WriteLineLog(string title, string logMsg, TextWriter w)
        {
            //w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            w.WriteLine(" : {0}", title);
            w.WriteLine(" : {0}", logMsg);
            w.WriteLine("-------------------------------");
            w.Flush();
        }

        public static void WriteLog(string title, string logMsg)
        {
            try
            {
                DateTime d = DateTime.Now;
                //DirectoryInfo path = new DirectoryInfo(".");  path.FullName + "\\" +
                string path = HttpContext.Current.Request.PhysicalApplicationPath + "PDFFiles\\"; //ConfigurationManager.AppSettings["PDFPath"].ToString();
                string pathLog = path + "LogFile_" + d.Day + d.Month + d.Year + "_.txt";
                using (StreamWriter w = File.AppendText(pathLog))
                {
                    WriteLineLog(title, logMsg, w);
                    w.Close();
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
