using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFUploadService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UploadFileService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UploadFileService.svc or UploadFileService.svc.cs at the Solution Explorer and start debugging.
    public class UploadFileService : IUploadFileService
    {
        public bool UploadFile(Stream file)
        {
            string uploadDirectory = System.AppDomain.CurrentDomain.BaseDirectory + @"\" + ConfigurationSettings.AppSettings["UploadedFiles"];
            try
            {
                byte[] data = null;
                if (file != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        data = ms.ToArray();
                    }
                }

                if (!Directory.Exists(uploadDirectory))
                    Directory.CreateDirectory(uploadDirectory);
                File.WriteAllBytes(uploadDirectory + @"\" + DateTime.Now.ToString("hhmmss") + ".jpg", data);
                return true;
            }
            catch (Exception ex) 
            {
                StreamWriter sw = new StreamWriter(uploadDirectory + @"\Error.txt");
                sw.WriteLine(ex.Message);
                sw.Close();
                sw.Dispose();
                return false;
            }
        }
    }
}
