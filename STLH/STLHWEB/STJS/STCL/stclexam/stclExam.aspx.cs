//******************************************************** 
//內容概述:获取ID,并通过ID取得数据显示，两种状态的更新。输入数据并存放于数据库。
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
    public partial class stclExam : System.Web.UI.Page
    {
        //声明需要用到的业务层类
        applyInfo_BLL a_applyInfo_BLL = new applyInfo_BLL();
        afailInfo_BLL a_afailInfo_BLL = new afailInfo_BLL();
        applyInfo a_applyInfo = new applyInfo();
        static string sId = "";
        //页面载入时，通过社团会长的学号，提取社团申请的详细信息
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
            try
            {
                commonClass comcls = new commonClass();
                string userStuId = UserData.GetUserDate.U_LoginName.Trim();
                putIn.Attributes.Add("onclick", "return confirm('提交后将无权限更改数据！您确定执行此操作吗？');");

                //页面传值，获取ID
                string id = Request.QueryString["ID"].ToString().Trim();
                sId = EncryptHandler.AsymmectricDecrypts(id, stclExamList.bobPrivateKey);
                a_applyInfo = a_applyInfo_BLL.getApplyInfo(sId);

                //从数据源绑定数据
                stName.Text = a_applyInfo.stName.ToString().Trim();
                stType.Text = a_applyInfo.stType.ToString().Trim();
                fee.Text = a_applyInfo.fee.ToString().Trim();
                stuId.Text = a_applyInfo.presidentId.ToString().Trim();
                stuTel.Text = a_applyInfo.stuTel.ToString().Trim();
                stuDormitory.Text = a_applyInfo.stuDormitory.ToString().Trim();
                guideTeacher.Text = a_applyInfo.guideTeacher.ToString().Trim();
                guideUnit.Text = a_applyInfo.guideUnit.ToString().Trim();

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


            }
            catch (System.Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }


        }
        
        protected void imgbtn_stAppPic_Click(object sender, ImageClickEventArgs e)
        {
            //commonClass cls = new commonClass();
            //cls.DownLoad(this.img_stAppPic.ImageUrl);
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
        /// <summary>
        /// 通过提交按钮提交修改建议
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void save_Click(object sender, EventArgs e)
        {
            if (txtbox_amendments.Text=="")
            {    //messageBox.Show(this, "请填写修改建议！");
                this.txtbox_amendments.Focus();
                //save.Attributes.Add("onclick", "return confirm('提交后将无权限更改数据！您确定执行此操作吗？');");
            }
            else
            {
                save.Attributes.Add("onclick", "return confirm('提交后将无权限更改数据！您确定执行此操作吗？');");
                try
                {
                    commonClass comcls = new commonClass();
                    string userStuId = UserData.GetUserDate.U_LoginName.Trim();
                    afailInfo a_afailInfo = new afailInfo();
                    a_afailInfo.amendments = comcls.NoHtml(txtbox_amendments.Text.Trim());
                    a_afailInfo.presidentId = sId;
                    a_afailInfo.opiniorId = userStuId;
                    a_afailInfo.opinionDate = DateTime.Now;

                    a_applyInfo.applyDate = Convert.ToDateTime("1900-1-1");
                    a_applyInfo.fee = Convert.ToByte(fee.Text.ToString().Trim());
                    a_applyInfo.stStates = Convert.ToByte("0");//修改建议状态为0

                    string result = a_afailInfo_BLL.addAfaildInfo(a_afailInfo, a_applyInfo);
                    if (result.ToString().Trim() == "提交修改建议失败！！！")
                    {
                        messageBox.Show(this, result);
                    }
                    else
                    {
                        disableControl.disableAllControl(this);

                        messageBox.Show(this, result);
                    }
                }


                catch (System.Exception ex)
                {
                    ErrorHandler.WriteError(ex);
                    throw;
                }
                

            }
        }

        protected void putIn_Click(object sender, EventArgs e)
        {

            string userStuId = UserData.GetUserDate.U_LoginName.Trim();
            a_applyInfo.fee =Convert.ToByte(fee.Text.ToString().Trim());
            a_applyInfo.stStates = Convert.ToByte("0");//修改建议状态为0
            string result = a_applyInfo_BLL.stApplyPassInfo(sId,userStuId,a_applyInfo.fee,a_applyInfo.stStates);
            if (result=="审核通过")
            {
                disableControl.disableAllControl(this);
                messageBox.Show(this,"操作成功！");
            } 
            else
            {
                messageBox.Show(this, "操作失败！");
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
            string path = this.a_otherFile.HRef;
            string[] pathG = path.Split('.');
            path = pathG[0] +"."+ a_applyInfo.wordDocument.ToString().Trim().Split('.')[1];
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