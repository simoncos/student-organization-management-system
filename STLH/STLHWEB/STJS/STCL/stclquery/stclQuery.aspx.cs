//******************************************************** 
//时间：2013/3/11
//作者：LX
//內容概述:获取登录者ID,并通过ID取得数据显示。三种审核状下的内容显示（根据ID从数据库提取出三种时间，表示三种状态）。
//********************************************************
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Collections.Generic;
using System.Web.UI.WebControls.WebParts;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using STLHBLL.STJS.STCL;
using STLHMODEL.STJS.STCL;
using STLHMODEL.LOGIN;
using STLHCOMMON;
using System.IO;
using System.Security.Cryptography;
using STLHWEB.App_Code;
using FrameWork;
namespace STLHWEB.STJS.STCL
{
    public partial class stclQuery : System.Web.UI.Page
    {
        applyInfo_BLL a_applyInfo_BLL = new applyInfo_BLL();
        afailInfo_BLL a_afailInfo_BLL = new afailInfo_BLL();
        applyInfo a_applyInfo = new applyInfo();
        afailInfo a_afailInfo = new afailInfo();
        string userStuId;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                
            }
            try
            {

                commonClass comcls = new commonClass();
                userStuId = UserData.GetUserDate.U_LoginName.Trim();
                //页面传值，获取ID
                a_applyInfo = a_applyInfo_BLL.getSTBasicInfo(userStuId);//通过登录用户的ID提取数据
                a_afailInfo = a_afailInfo_BLL.getAfailInfo(userStuId);
                DateTime timeFlag = Convert.ToDateTime("1900-1-1");

                if (a_applyInfo == null)
                {
                    messageBox.ShowAndRedirect(this, "尚未填写社团申请记录，请填写后再查看！", "/STJS/STCL/stclapply/stclApply.aspx");
                }

                else if (a_applyInfo.applyDate == timeFlag && a_applyInfo.positiveDate == timeFlag && (a_afailInfo == null || a_afailInfo.opinionDate == timeFlag))
                {
                    messageBox.ShowAndRedirect(this, "尚未提交社团申请记录，请提交后再查看！", "/STJS/STCL//stclapply/stclApply.aspx");
                }
                else
                {

                    //从数据源绑定数据
                    stName.Text = a_applyInfo.stName.ToString().Trim();
                    stType.Text = a_applyInfo.stType.ToString().Trim();
                    fee.Text = a_applyInfo.fee.ToString().Trim();
                    stuId.Text = a_applyInfo.presidentId.ToString().Trim();
                    stuTel.Text = a_applyInfo.stuTel.ToString().Trim();
                    hzDormitory.Text = a_applyInfo.stuDormitory.ToString().Trim();
                    guideTeacher.Text = a_applyInfo.guideTeacher.ToString().Trim();
                    guideUnit.Text = a_applyInfo.guideUnit.ToString().Trim();

                    lab_positiveDate.Text = a_applyInfo.positiveDate.ToString().Trim();
                    lab_positiveName.Text = a_applyInfo.positiveName.ToString().Trim();

                    stApplication.Text = comcls.inHtml(a_applyInfo.stApplication.ToString().TrimEnd());//进行html化，已格式化的形式输出文字

                    presidentRecommend.Text = comcls.inHtml(a_applyInfo.presidentRecommend.ToString().TrimEnd());//进行html化，已格式化的形式输出文字
                    this.a_stAppPic.HRef = "/STJS/stclFileUpload/" + userStuId + "/" + a_applyInfo.stAppPic.ToString().Trim();
                    this.a_unitPic.HRef = "/STJS/stclFileUpload/" + userStuId + "/" + a_applyInfo.unitPic.ToString().Trim();
                    this.a_guidTeacherPic.HRef = "/STJS/stclFileUpload/" + userStuId + "/" + a_applyInfo.guideTeacherPic.ToString().Trim();
                    this.a_otherFile.HRef = "/STJS/stclFileUpload/" + userStuId + "/Word全书.html";

                    this.img_stAppPic.ImageUrl = "/STJS/stclFileUpload/" + userStuId + "/" + a_applyInfo.stAppPic.ToString().Trim();
                    this.img_unitPic.ImageUrl = "/STJS/stclFileUpload/" + userStuId + "/" + a_applyInfo.unitPic.ToString().Trim();
                    this.img_guideTeacherPic.ImageUrl = "/STJS/stclFileUpload/" + userStuId + "/" + a_applyInfo.guideTeacherPic.ToString().Trim();
                    this.img_wordDocument.ImageUrl = "/IMAGE/word.png";


                    DateTime Apd = a_applyInfo.applyDate;
                    DateTime App = a_applyInfo.positiveDate;
                    DateTime Apo = timeFlag;
                    if (a_afailInfo != null)
                    {
                        Apo = a_afailInfo.opinionDate;
                    }
                    if (Apd != timeFlag && App == timeFlag)
                    {//待审核状态
                        pnl_examOn.Visible = true;
                        disableControl.disableExceptImageButton(this);
                    }
                    else if (Apd == timeFlag && App == timeFlag && Apo != timeFlag)
                    {//修改建议状态
                        pnl_examAfail.Visible = true;

                        disableControl.disableExceptImageButton(this);
                    }
                    else if (Apd != timeFlag && App != timeFlag && Apo == timeFlag)
                    {//成功状态且没有修改建议
                        pnl_examSuccess.Visible = true;
                    }
                    else if (Apd != timeFlag && App != timeFlag && Apo != timeFlag)
                    {//成功且有修改建议
                        pnl_examSuccess.Visible = true;
                        pnl_examAfail.Visible = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }


        }

        protected void imgbtn_stAppPic_Click(object sender, ImageClickEventArgs e)
        {
            string path = this.img_stAppPic.ImageUrl;
            string filePath = Server.MapPath(path);//这里注意了,你得指明要下载文件的路径.

            if (System.IO.File.Exists(filePath))
            {
                FileInfo file = new FileInfo(filePath);
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8"); //解决中文乱码
                Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(file.Name)); //解决中文文件名乱码    
                Response.AddHeader("Content-length", file.Length.ToString());
                Response.ContentType = "appliction/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
        }

        protected void imgbtn_unitPic_Click(object sender, ImageClickEventArgs e)
        {
            string path = this.img_unitPic.ImageUrl;
            string filePath = Server.MapPath(path);//这里注意了,你得指明要下载文件的路径.

            if (System.IO.File.Exists(filePath))
            {
                FileInfo file = new FileInfo(filePath);
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8"); //解决中文乱码
                Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(file.Name)); //解决中文文件名乱码    
                Response.AddHeader("Content-length", file.Length.ToString());
                Response.ContentType = "appliction/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
        }

        protected void imgbtn_guideTeacherPic_Click(object sender, ImageClickEventArgs e)
        {
            string path = this.img_guideTeacherPic.ImageUrl;
            string filePath = Server.MapPath(path);//这里注意了,你得指明要下载文件的路径.

            if (System.IO.File.Exists(filePath))
            {
                FileInfo file = new FileInfo(filePath);
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8"); //解决中文乱码
                Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(file.Name)); //解决中文文件名乱码    
                Response.AddHeader("Content-length", file.Length.ToString());
                Response.ContentType = "appliction/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
        }

        protected void imgbtn_wordDocument_Click(object sender, ImageClickEventArgs e)
        {


            string path = "/STJS/stclFileUpload/" + userStuId + "/" + a_applyInfo.wordDocument.ToString().Trim();
            string filePath = Server.MapPath(path);//这里注意了,你得指明要下载文件的路径.

            if (System.IO.File.Exists(filePath))
            {
                FileInfo file = new FileInfo(filePath);
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8"); //解决中文乱码
                Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(file.Name)); //解决中文文件名乱码    
                Response.AddHeader("Content-length", file.Length.ToString());
                Response.ContentType = "appliction/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
        }

    }
}
