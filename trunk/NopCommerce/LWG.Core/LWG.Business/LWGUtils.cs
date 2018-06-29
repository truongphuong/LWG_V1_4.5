using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;

namespace LWG.Business
{
    public class LWGUtils
    {
        public const int COMPOSER_ROLE_ID = 1;
        public const string INVALID_FILE_EXTENSION = "INVALID_FILE_EXTENSION";
        public const string INVALID_FILE_SIZE = "INVALID_FILE_SIZE";
        public const string NO_FILE = "NO_FILE";
                
        public static string GetPDFPath()
        {
            return ConfigurationManager.AppSettings["PDFPath"];
        }

        public static string GetCSVPath()
        {
            return ConfigurationManager.AppSettings["CSVPath"];
        }
        public static string GetSoundPath()
        {
            return ConfigurationManager.AppSettings["SoundPath"];
        }

        public static string GetVideoPath()
        {
            return ConfigurationManager.AppSettings["VideoPath"];
        }

        public static string SaveSoundFile(FileUpload uploadfile, string path, ref string strError)
        {
            strError = string.Empty;
            string fileName = uploadfile.FileName; //string.Format("{0}_{1}", DateTime.Now.Ticks, uploadfile.FileName);
            if (uploadfile.HasFile)
            {
                string physicPath = HttpContext.Current.Server.MapPath(path);
                
                // check valid file extension
                string extension = System.IO.Path.GetExtension(uploadfile.PostedFile.FileName);
                if (!extension.Contains(".mp3") && !extension.Contains(".wav"))
                {
                    strError = INVALID_FILE_EXTENSION;
                    return string.Empty;
                }

                // check valid file size 
                int fileSizeMax = Convert.ToInt32(ConfigurationManager.AppSettings["MaxSizeMP3"]);
                if (uploadfile.PostedFile.ContentLength > fileSizeMax)
                {
                    strError = INVALID_FILE_SIZE;
                    return string.Empty;
                }
                // save file 
                try
                {
                    uploadfile.SaveAs(physicPath + fileName);
                }
                catch (HttpException)
                {
                    throw;
                }
                catch (DirectoryNotFoundException)
                {
                    throw;
                }
            }
            else
            {
                strError = NO_FILE;
            }
            return fileName ;// string.Format("{0}{1}", path, fileName);
        }
        public static string SaveVideoFile(FileUpload uploadfile, string path, ref string strError)
        {
            strError = string.Empty;
            string fileName = uploadfile.FileName; //string.Format("{0}_{1}", DateTime.Now.Ticks, uploadfile.FileName);
            if (uploadfile.HasFile)
            {
                string physicPath = HttpContext.Current.Server.MapPath(path);
                
                // check valid file extension
                string extension = System.IO.Path.GetExtension(uploadfile.PostedFile.FileName);
                if (!extension.Contains(".wmv") && !extension.Contains(".avi") && !extension.Contains(".mp4") )
                {
                    strError = INVALID_FILE_EXTENSION;
                    return string.Empty;
                }

                // check valid file size 
                int fileSizeMax = Convert.ToInt32(ConfigurationManager.AppSettings["MaxSizeMOV"]);
                if (uploadfile.PostedFile.ContentLength > fileSizeMax)
                {
                    strError = INVALID_FILE_SIZE;
                    return string.Empty;
                }
                // save file 
                try
                {
                    uploadfile.SaveAs(physicPath + fileName);
                }
                catch (HttpException)
                {
                    throw;
                }
                catch (DirectoryNotFoundException)
                {
                    throw;
                }
            }
            else
            {
                strError = NO_FILE;
            }
            return fileName;// string.Format("{0}{1}", path, fileName);
        }
        public static string SavePDFFile(FileUpload uploadfile, string path, ref string strError)
        {
            strError = string.Empty;
            string fileName = uploadfile.FileName; //string.Format("{0}_{1}", DateTime.Now.Ticks, uploadfile.FileName);
            if (uploadfile.HasFile)
            {
                string physicPath = HttpContext.Current.Server.MapPath(path);
                // check valid file size 
                int fileSizeMax = Convert.ToInt32(ConfigurationManager.AppSettings["MaxSizePDF"]);
                if (uploadfile.PostedFile.ContentLength > fileSizeMax)
                {
                    strError = INVALID_FILE_SIZE;
                    return string.Empty;
                }
                // check valid file extension
                string extension = System.IO.Path.GetExtension(uploadfile.PostedFile.FileName);
                if (!extension.Contains(".pdf"))
                {
                    strError = INVALID_FILE_EXTENSION;
                    return string.Empty;
                }
                // save file 
                try
                {
                    uploadfile.SaveAs(physicPath + fileName);
                }
                catch (HttpException)
                {
                    throw;
                }
                catch (DirectoryNotFoundException)
                {
                    throw;
                }
            }
            else
            {
                strError = NO_FILE;
            }
            return fileName ;// string.Format("{0}{1}", path, fileName);
        }

        public static void ClearOldFile(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                try
                {                     
                    string physicalPath = HttpContext.Current.Server.MapPath(fileName);
                    if (File.Exists(physicalPath))
                    {
                        File.Delete(physicalPath);
                    }
                }
                catch (Exception ex)
                {
                    //TODO: handle exception
                    return;
                }
            }
        }

        public static string CodePlayAudio(string urlFile)
        {
            string temp = string.Format("<embed src='{0}' loop='false' autoplay='true' width='145' height='60'></embed>",urlFile);
            string temp1 = string.Format("<object width='300' height='270'><param name='quality' value='high' /><param name='wmode' value='transparent' /><embed src='{0}' quality='high' wmode='transparent' type='application/x-shockwave-flash' width='300' height='270'></embed></object>",urlFile);
            return temp1;
        }
    }
}
