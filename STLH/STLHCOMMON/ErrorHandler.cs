using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.Web.UI;

namespace STLHCOMMON
{
    /// <summary>
    /// 记录错误日志
    /// </summary>
    public class ErrorHandler
    {
        /// <summary>
        /// 写入错误信息
        /// </summary>
        /// <param name="e">应用程序执行过程中发生的错误</param>
        public static void WriteError(Exception e)
        {
            try
            {
                string path = "~/Error Log/" + "logfile_" +DateTime.Now.ToShortDateString().Replace("/", "") + ".txt"; 
                string PathUrl = HttpContext.Current.Server.MapPath(path);
                if (!File.Exists(PathUrl))
                    File.Create(PathUrl).Close();
                using (StreamWriter sw = File.AppendText(PathUrl))
                {
                    sw.WriteLine("Error Date: " + DateTime.Now.ToString());
                    sw.WriteLine("Error Page: " + HttpContext.Current.Request.Url.ToString());
                    sw.WriteLine("Error Message: " + e.Message);
                    sw.WriteLine("Error TargetSite: " + e.TargetSite);
                    sw.WriteLine(" ");
                    sw.WriteLine("==============================================================================================");
                    sw.WriteLine(" ");
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                    WriteError(ex);
            }
        }
    }
}
