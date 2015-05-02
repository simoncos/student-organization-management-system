using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Drawing;
using STLHCOMMON;
using STLHDAL;
using System.Data.SqlClient;
using System.Data;
using Word = Microsoft.Office.Interop.Word;


namespace STLHWEB.App_Code
{
    public class commonClass : System.Web.UI.Page
    {
        #region 去除html及脚本格式
        /// <summary> 
        /// 去除html及脚本格式
        /// </summary> 
        public string NoHtml(string text)
        {
            //删除脚本
            text = Regex.Replace(text, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            text = Regex.Replace(text, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, @"-->", "", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, @"<!--.*", "", RegexOptions.IgnoreCase);


            text = Regex.Replace(text, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            //text = Regex.Replace(text, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            //text.Replace("<", "");
            //text.Replace(">", "");
            // text.Replace("\r\n", "");

            text = HttpContext.Current.Server.HtmlEncode(text).Trim();
            return text;
        }
        #endregion

        #region asp.net上传图片并生成缩略图
        /// <summary> 
        /// asp.net上传图片并生成缩略图 
        /// </summary> 
        /// <param name="upImage">HtmlInputFile控件</param> 
        /// <param name="sSavePath">保存的路径,些为相对服务器路径的下的文件夹</param> 
        /// <param name="sThumbExtension">缩略图的thumb</param> 
        /// <param name="intThumbWidth">生成缩略图的宽度</param> 
        /// <param name="intThumbHeight">生成缩略图的高度</param> 
        /// <returns>缩略图名称</returns> 
        public string UpLoadImage(System.Web.UI.WebControls.FileUpload upImage, string sSavePath, string sThumbExtension, int intThumbWidth, int intThumbHeight)
        {
            string sThumbFile = "";
            string sFilename = "";

            if (upImage.HasFile)
            {
                HttpPostedFile myFile = upImage.PostedFile;
                int nFileLen = myFile.ContentLength;
                if (nFileLen == 0)
                    return "没有选择上传图片";

                //获取upImage选择文件的扩展名 
                string extendName = System.IO.Path.GetExtension(myFile.FileName).ToLower();
                //判断是否为图片格式 
                if (extendName != ".jpg" && extendName != ".jpge" && extendName != ".gif" && extendName != ".bmp" && extendName != ".png")
                    return "图片格式不正确";


                byte[] myData = new Byte[nFileLen];
                myFile.InputStream.Read(myData, 0, nFileLen);

                sFilename = System.IO.Path.GetFileName(myFile.FileName);
                int file_append = 0;
                //检查当前文件夹下是否有同名图片,有则在文件名+1 
                while (System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sFilename)))
                {
                    //file_append++;
                    sFilename = System.IO.Path.GetFileNameWithoutExtension(myFile.FileName)
                        /*+ file_append.ToString()*/ + extendName;
                }
                System.IO.FileStream newFile
                    = new System.IO.FileStream(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sFilename),
                    System.IO.FileMode.Create, System.IO.FileAccess.Write);
                newFile.Write(myData, 0, myData.Length);
                newFile.Close();

                //以上为上传原图 

                try
                {
                    //原图加载 
                    using (System.Drawing.Image sourceImage = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sFilename)))
                    {
                        //原图宽度和高度 
                        int width = sourceImage.Width;
                        int height = sourceImage.Height;
                        int smallWidth;
                        int smallHeight;

                        //获取第一张绘制图的大小,(比较 原图的宽/缩略图的宽  和 原图的高/缩略图的高) 
                        if (((decimal)width) / height <= ((decimal)intThumbWidth) / intThumbHeight)
                        {
                            smallWidth = intThumbWidth;
                            smallHeight = intThumbWidth * height / width;
                        }
                        else
                        {
                            smallWidth = intThumbHeight * width / height;
                            smallHeight = intThumbHeight;
                        }

                        //判断缩略图在当前文件夹下是否同名称文件存在 
                        file_append = 0;
                        sThumbFile = sThumbExtension + System.IO.Path.GetFileNameWithoutExtension(myFile.FileName) + extendName;

                        while (System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sThumbFile)))
                        {
                            file_append++;
                            sThumbFile = sThumbExtension + System.IO.Path.GetFileNameWithoutExtension(myFile.FileName) +
                                file_append.ToString() + extendName;
                        }
                        //缩略图保存的绝对路径 
                        string smallImagePath = System.Web.HttpContext.Current.Server.MapPath(sSavePath) + sThumbFile;

                        //新建一个图板,以最小等比例压缩大小绘制原图 
                        using (System.Drawing.Image bitmap = new System.Drawing.Bitmap(smallWidth, smallHeight))
                        {
                            //绘制中间图 
                            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap))
                            {
                                //高清,平滑 
                                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                g.Clear(Color.Black);
                                g.DrawImage(
                                sourceImage,
                                new System.Drawing.Rectangle(0, 0, smallWidth, smallHeight),
                                new System.Drawing.Rectangle(0, 0, width, height),
                                System.Drawing.GraphicsUnit.Pixel
                                );
                            }
                            //新建一个图板,以缩略图大小绘制中间图 
                            using (System.Drawing.Image bitmap1 = new System.Drawing.Bitmap(intThumbWidth, intThumbHeight))
                            {
                                //绘制缩略图 
                                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap1))
                                {
                                    //高清,平滑 
                                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                    g.Clear(Color.Black);
                                    int lwidth = (smallWidth - intThumbWidth) / 2;
                                    int bheight = (smallHeight - intThumbHeight) / 2;
                                    g.DrawImage(bitmap, new Rectangle(0, 0, intThumbWidth, intThumbHeight), lwidth, bheight, intThumbWidth, intThumbHeight, GraphicsUnit.Pixel);
                                    bitmap1.Save(smallImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                                }
                            }
                        }
                    }
                }
                catch
                {
                    //出错则删除 
                    System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath(sSavePath + sFilename));
                    return "图片格式不正确";
                }
                //返回缩略图名称 
                return sThumbFile;
            }
            return "没有选择图片";
        }
        #endregion

        #region 生成html格式
        /// <summary> 
        /// 生成html格式
        /// </summary> 
        public string inHtml(string text)
        {
            text = Regex.Replace(text, "\r\n", "<br>");
            text = Regex.Replace(text, " ", "&nbsp;&nbsp;&nbsp;");
            return text;
        }
        #endregion

        #region 上传图片文件
        /// <summary>
        /// 上传图片文件
        /// </summary>
        /// <param name="FileUploadName"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public string uploadImgFile(FileUpload FileUploadName, string path, string saveName)
        {
            bool filelsValid = false;
            if (FileUploadName.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUploadName.FileName).ToLower();
                string[] restrictExtension = { ".gif", ".jpg", ".bmp", ".png" };
                for (int i = 0; i < restrictExtension.Length; i++)
                {
                    if (fileExtension == restrictExtension[i])
                    {
                        filelsValid = true;
                    }
                }
                if (filelsValid == true)
                {
                    try
                    {
                        FileUploadName.SaveAs(path + "/" + saveName + fileExtension);
                        return "文件上传成功!";
                    }
                    catch (System.Exception ex)
                    {
                        ErrorHandler.WriteError(ex);
                        Response.Redirect("/COMMON/errorPage.aspx");
                        return "文件上传不成功！！！";
                    }
                    finally
                    {

                    }
                }
                else
                {
                    return "文件上传不成功!只能够上传后缀为.jpg、.jepg、.gif、.png,不超过1M的文件!";
                }

            }
            else
            {
                return "请选择文件！！！";
            }
        }

        #endregion

        #region 上传word文件
        /// <summary>
        /// 上传图片文件
        /// </summary>
        /// <param name="FileUploadName"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public string uploadWordFile(FileUpload FileUploadName, string path, string saveName)
        {
            bool filelsValid = false;
            if (FileUploadName.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUploadName.FileName).ToLower();
                string[] restrictExtension = { ".doc", ".docx" };
                for (int i = 0; i < restrictExtension.Length; i++)
                {
                    if (fileExtension == restrictExtension[i])
                    {
                        filelsValid = true;
                    }
                }
                if (filelsValid == true)
                {
                    try
                    {
                        FileUploadName.SaveAs(path + "/" + saveName + fileExtension);
                        WordToHtml(path + "/" + saveName + fileExtension);//生成相应的Html File
                        return "文件上传成功!";
                    }
                    catch (System.Exception ex)
                    {
                        ErrorHandler.WriteError(ex);
                        return "文件上传不成功！！！";
                    }
                    finally
                    {

                    }
                }
                else
                {
                    return "文件上传不成功!只能够上传后缀为.doc、.docx,不超过1M的文件!";
                }

            }
            else
            {
                return "请选择文件！！！";
            }
        }

        #endregion

        #region 创建文件夹
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="creatpath">文件路径</param>
        /// <param name="folderpathname">文件夹名称</param>
        public void creatfolder(string creatpath)
        {
            try
            {

                if (!Directory.Exists(creatpath))
                {
                    Directory.CreateDirectory(creatpath);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex);
            }
        }
        #endregion

        #region 动态下拉列表
        /// <summary>
        /// 带参数的动态下拉列表
        /// </summary>
        /// <param name="dropDownListName">下拉控件</param>
        /// <param name="str">带参数的sql语句</param>
        /// <param name="parameterName">参数名</param>
        /// <param name="parameterWord">参数值</param>
        public void dropDownList(DropDownList dropDownListName, string str, string[] parameterName, string parameterWord)
        {
            List<SqlParameter> ilist = new List<SqlParameter>();
            for (int i = 0; i < parameterName.Length; i++)
            {
                ilist.Add(new SqlParameter("@" + parameterName[i], parameterWord[i]));
            }
            SqlParameter[] param = ilist.ToArray();
            try
            {
                SqlHelper sq = new SqlHelper();
                SqlDataReader dr = sq.ExecuteDataReader(str, param, CommandType.Text);
                while (dr.Read())
                {
                    dropDownListName.Items.Add(new ListItem(dr[0].ToString().Trim(), dr[0].ToString().Trim()));
                }
            }
            catch (System.Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }


        }

        /// <summary>
        /// 不带参数的动态下拉列表
        /// </summary>
        /// <param name="dropDownListName">下拉控件名</param>
        /// <param name="str">不带参数的sql语句</param>
        public void dropDownList(DropDownList dropDownListName, string str)
        {
            try
            {
                SqlHelper sq = new SqlHelper();
                SqlDataReader dr = sq.ExecuteDataReader(str, CommandType.Text);
                while (dr.Read())
                {
                    dropDownListName.Items.Add(new ListItem(dr[0].ToString().Trim(), dr[0].ToString().Trim()));
                }
            }
            catch (System.Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }


        }
        #endregion

        #region  word转换html
        /// <summary>
        ///  word转换html
        /// </summary>
        /// <param name="wordFileName">word路径</param>
        /// <returns></returns>
        public string WordToHtml(object wordFileName)
        {

            //在此处放置用户代码以初始化页面
            Word.ApplicationClass word = new Word.ApplicationClass();

            Type wordType = word.GetType();

            Word.Documents docs = word.Documents;

            //打开文件
            Type docsType = docs.GetType();
            Word.Document doc = (Word.Document)docsType.InvokeMember("Open", System.Reflection.BindingFlags.InvokeMethod, null, docs, new Object[] { wordFileName, true, true });

            //转换格式，另存为
            Type docType = doc.GetType();
            
            string wordSaveFileName = wordFileName.ToString();
            string[] strSaveFileNameG = wordSaveFileName.Split('.');
            string strSaveFileName = "";
            for (int i = 0; i < strSaveFileNameG.Length - 1;i++ )
            {
                strSaveFileName += strSaveFileNameG[i]+".";
            }
            strSaveFileName+="html";
            //string strSaveFileName = wordSaveFileName.Substring(0, wordSaveFileName.Length - 3) + "html";

            object saveFileName = (object)strSaveFileName;

            docType.InvokeMember("SaveAs", System.Reflection.BindingFlags.InvokeMethod, null, doc, new object[] { saveFileName, Word.WdSaveFormat.wdFormatFilteredHTML });

            docType.InvokeMember("Close", System.Reflection.BindingFlags.InvokeMethod, null, doc, null);

            //退出 Word
            wordType.InvokeMember("Quit", System.Reflection.BindingFlags.InvokeMethod, null, word, null);

            return saveFileName.ToString();
        }
        #endregion

        #region 下载功能只能用于前台页面，请复制使用~~~
        //下载功能只能用于前台页面，请复制使用~~~
        /// <summary>
        /// 下载文件
        /// </summary>
        public void DownLoad(string path)
        {
            string filePath = Server.MapPath(path);//这里注意了,你得指明要下载文件的路径.

            if (System.IO.File.Exists(filePath))
            {
                FileInfo file = new FileInfo(filePath);
                // Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8"); //解决中文乱码
                Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(file.Name)); //解决中文文件名乱码    
                Response.AddHeader("Content-length", file.Length.ToString());
                Response.ContentType = "appliction/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DownLoad1(object sender, EventArgs e)
        {
            /*
                      微软为Response对象提供了一个新的方法TransmitFile来解决使用Response.BinaryWrite
                      下载超过400mb的文件时导致Aspnet_wp.exe进程回收而无法成功下载的问题。
                      代码如下：
            */

            Response.ContentType = "application/x-zip-compressed";
            Response.AddHeader("Content-Disposition", "attachment;filename=z.zip");
            string filename = Server.MapPath("DownLoad/aaa.zip");
            Response.TransmitFile(filename);
        }
        #endregion
    }
}