using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using STLHBLL.STJS.STCL;
using STLHMODEL.STJS.STCL;
using STLHWEB.App_Code;
using STLHCOMMON;
using STLHMODEL.LOGIN;
using System.IO;
using FrameWork;


namespace STLHWEB.STJS.STCL
{
    public partial class stclApply : System.Web.UI.Page
    {
        applyInfo_BLL a_applyInfo_BLL = new applyInfo_BLL();
        string userStuId = UserData.GetUserDate.U_LoginName.Trim();
        static string s_stAppPic = "";
        static string s_guideTeacherPic = "";
        static string s_wordDocument = "";
        static string s_unitPic = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                imgbtn_otherFile.Attributes.Add("onclick", "alertWin('提示','正在上传,请耐心等候...',200,76);");
                    commonClass comcls = new commonClass();
                    applyInfo a_applyInfo = a_applyInfo_BLL.getApplyInfo(userStuId);//通过用户学号查询是否存在已经保存的记录
                   
                    if (a_applyInfo == null)
                    {
                        //this.img_stAppPic.ImageUrl = "/IMAGE/img.png";
                        //this.img_unitPic.ImageUrl = "/IMAGE/img.png";
                        //this.img_guidTeacherPic.ImageUrl = "/IMAGE/img.png";
                        //this.img_otherFile.ImageUrl = "/IMAGE/word.png";
                        stuId.Text = userStuId;
                        string creatpath = (Server.MapPath("/STJS/stclFileUpload/") + userStuId).ToString();
                        comcls.creatfolder(creatpath);
                    }
                    else
                    {


                        string userFileUploadPath = (Server.MapPath("/STJS/stclFileUpload/") + userStuId).ToString();
                        stName.Text = a_applyInfo.stName.ToString().Trim();
                        stType.SelectedValue = a_applyInfo.stType.ToString().Trim();//todo:是否写死？
                        fee.Text = a_applyInfo.fee.ToString().Trim();
                        stuId.Text = a_applyInfo.presidentId.ToString().Trim();
                        stuTel.Text = a_applyInfo.stuTel.ToString().Trim();
                        stuDormitory.Text = a_applyInfo.stuDormitory.ToString().Trim();
                        guideTeacher.Text = a_applyInfo.guideTeacher.ToString().Trim();
                        guideUnit.Text = a_applyInfo.guideUnit.ToString().Trim();
                        stApplication.Text = a_applyInfo.stApplication.ToString().TrimEnd();
                        presidentRecommend.Text = a_applyInfo.presidentRecommend.ToString().TrimEnd();
                        if (Directory.Exists(userFileUploadPath))
                        {


                            if (a_applyInfo.stAppPic != "")
                            {
                                this.lab_stAppPic.Visible = true;
                                this.lab_stAppPic.Text += "文件名:" + a_applyInfo.stAppPic.ToString().Trim();
                                this.img_stAppPic.Visible = true;
                                this.a_stAppPic.HRef = "/STJS/stclFileUpload/" + a_applyInfo.presidentId + "/" + a_applyInfo.stAppPic.ToString().Trim();
                                this.img_stAppPic.ImageUrl = "/STJS/stclFileUpload/" + a_applyInfo.presidentId + "/" + a_applyInfo.stAppPic.ToString().Trim();
                                s_stAppPic = a_applyInfo.stAppPic.ToString().Trim();
                            }
                            if (a_applyInfo.unitPic != "")
                            {
                                this.lab_unitPic.Visible = true;
                                this.lab_unitPic.Text += "文件名:" + a_applyInfo.unitPic.ToString().Trim();
                                this.img_unitPic.Visible = true;
                                this.a_unitPic.HRef = "/STJS/stclFileUpload/" + a_applyInfo.presidentId + "/" + a_applyInfo.unitPic.ToString().Trim();
                                this.img_unitPic.ImageUrl = "/STJS/stclFileUpload/" + a_applyInfo.presidentId + "/" + a_applyInfo.unitPic.ToString().Trim();
                                s_unitPic = a_applyInfo.unitPic.ToString().Trim();
                            }
                            if (a_applyInfo.guideTeacherPic != "")
                            {
                                this.lab_guidTeacherPic.Visible = true;
                                this.lab_guidTeacherPic.Text += "文件名:" + a_applyInfo.stAppPic.ToString().Trim();
                                this.img_guidTeacherPic.Visible = true;
                                this.a_guidTeacherPic.HRef = "/STJS/stclFileUpload/" + a_applyInfo.presidentId + "/" + a_applyInfo.guideTeacherPic.ToString().Trim();
                                this.img_guidTeacherPic.ImageUrl = "/STJS/stclFileUpload/" + a_applyInfo.presidentId + "/" + a_applyInfo.guideTeacherPic.ToString().Trim();
                                s_guideTeacherPic = a_applyInfo.guideTeacherPic.ToString().Trim();
                            }

                            if (a_applyInfo.wordDocument != "")
                            {
                                this.lab_otherFile.Visible = true;
                                this.lab_otherFile.Text += "文件名:" + a_applyInfo.wordDocument.ToString().Trim();
                                this.img_otherFile.Visible = true;
                                this.a_otherFile.HRef = "/STJS/stclFileUpload/" + a_applyInfo.presidentId + "/Word全书.html";
                                this.img_otherFile.ImageUrl = "/IMAGE/word.png";
                                s_wordDocument = a_applyInfo.wordDocument.ToString().Trim();
                            }
                        }
                        else
                        {
                            string creatpath = (Server.MapPath("/STJS/stclFileUpload/") + userStuId).ToString();
                            comcls.creatfolder(creatpath);
                        }


                        if (a_applyInfo.applyDate != Convert.ToDateTime("1900-1-1"))
                        {
                            //加载页面时候判断是否标灰。
                            disableControl.disableAllControl(this);
                        }
                    }
            }
        }

        protected void save_Click(object sender, EventArgs e)
        {
            applyInfo new_applyInfo = new applyInfo();
            commonClass comcls = new commonClass();
            new_applyInfo.stName = stName.Text.ToString().Trim();
            new_applyInfo.stType = stType.SelectedValue.ToString().Trim();
            if (fee.Text.ToString().Trim() == "")//fee对象为int型，必须有值才行
            {
                fee.Text = "0";
            }
            new_applyInfo.fee = Convert.ToByte(fee.Text.ToString().Trim());
            new_applyInfo.guideTeacher = guideTeacher.Text.ToString().Trim();
            new_applyInfo.guideUnit = guideUnit.Text.ToString().Trim();
            new_applyInfo.stApplication = comcls.NoHtml(stApplication.Text.ToString().Trim());
            new_applyInfo.presidentRecommend = comcls.NoHtml(presidentRecommend.Text.ToString().Trim());
            new_applyInfo.applyDate = Convert.ToDateTime("1900-1-1");
            new_applyInfo.presidentId = userStuId;
            new_applyInfo.stuTel = stuTel.Text.ToString().Trim();
            new_applyInfo.stuDormitory = stuDormitory.Text.ToString().Trim();
            new_applyInfo.stAppPic = s_stAppPic.ToString().Trim();
            new_applyInfo.unitPic = s_unitPic.ToString().Trim();
            new_applyInfo.guideTeacherPic = s_guideTeacherPic.ToString().Trim();
            new_applyInfo.wordDocument = s_wordDocument.ToString().Trim();

            applyInfo_BLL a_applyInfo_BLL = new applyInfo_BLL();
            bool result = false;
            result = a_applyInfo_BLL.addApplyInfo(new_applyInfo);
            try
            {
                if (result)
                {
                    messageBox.Show(this, "保存成功！！！");

                }
                else
                {
                    messageBox.Show(this, "保存失败！！！");
                }

            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }
        }
        protected void putIn_Click(object sender, EventArgs e)
        {
            putIn.Attributes.Add("onclick", "return confirm('提交后将无权限更改数据！您确定执行此操作吗？');");
            applyInfo new_applyInfo = new applyInfo();
            commonClass comcls = new commonClass();
            new_applyInfo.stName = stName.Text.ToString().Trim();
            new_applyInfo.stType = stType.SelectedValue.ToString().Trim();
            if (fee.Text.ToString().Trim() == "")//fee对象为int型，必须有值才行
            {
                fee.Text = "0";
            }
            new_applyInfo.fee = Convert.ToByte(fee.Text.ToString().Trim());
            new_applyInfo.guideTeacher = guideTeacher.Text.ToString().Trim();
            new_applyInfo.guideUnit = guideUnit.Text.ToString().Trim();
            new_applyInfo.stApplication = comcls.NoHtml(stApplication.Text.ToString().Trim());
            new_applyInfo.presidentRecommend = comcls.NoHtml(presidentRecommend.Text.ToString().Trim());
            new_applyInfo.applyDate = DateTime.Now;//状态的更改。
            new_applyInfo.presidentId = userStuId;
            new_applyInfo.stuTel = stuTel.Text.ToString().Trim();
            new_applyInfo.stuDormitory = stuDormitory.Text.ToString().Trim();
            new_applyInfo.stAppPic = s_stAppPic.ToString().Trim();
            new_applyInfo.unitPic = s_unitPic.ToString().Trim();
            new_applyInfo.guideTeacherPic = s_guideTeacherPic.ToString().Trim();
            new_applyInfo.wordDocument = s_wordDocument.ToString().Trim();

            new_applyInfo.stStates = Convert.ToByte("1");//待审核状态为1

            applyInfo_BLL a_applyInfo_BLL = new applyInfo_BLL();
            bool result = false;
            result = a_applyInfo_BLL.addApplyInfo(new_applyInfo);
            try
            {
                if (result)
                {
                    disableControl.disableAllControl(this);
                    messageBox.Show(this, "提交成功！！！");

                }
                else
                {
                    messageBox.Show(this, "提交失败！！！");
                }

            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }
        }



        protected void imgbtn_stAppPic_Click(object sender, ImageClickEventArgs e)
        {
            commonClass comcls = new commonClass();
            string path = Server.MapPath("/STJS/stclFileUpload/") + userStuId;
            string result = comcls.uploadImgFile(fpd_stAppPic, path, "社团成立申请表");

            if (result == "请选择文件！！！")
            {
                messageBox.Show(this, "请选择文件！！！");
            }
            else if (result == "文件上传不成功!只能够上传后缀为.jpg、.jepg、.gif、.png,不超过1M的文件!")
            {
                messageBox.Show(this, "文件上传不成功!只能够上传后缀为.jpg、.jepg、.gif、.png,不超过1M的文件!");
            }
            else if (result == "文件上传成功!")
            {
                img_stAppPic.Visible = true;
                lab_stAppPic.Visible = true;
                string fileExtension = System.IO.Path.GetExtension(fpd_stAppPic.FileName).ToLower();
                s_stAppPic = "社团成立申请表" + fileExtension;
                this.a_stAppPic.HRef = "/STJS/stclFileUpload/" + userStuId + "/" + s_stAppPic.ToString().Trim();
                this.img_stAppPic.ImageUrl = "/STJS/stclFileUpload/" + userStuId + "/" + s_stAppPic.ToString().Trim();
                this.lab_stAppPic.Text = "文件上传成功";
                this.lab_stAppPic.Text += "<br/>";
                this.lab_stAppPic.Text += "文件名:" + this.fpd_stAppPic.FileName;
                messageBox.Show(this, "文件上传成功!");
                this.imgbtn_otherFile.Focus();
            }
            else
            {
                this.lab_stAppPic.Text = "文件上传不成功!";
                //
            }

        }

        protected void imgbtn_unitPic_Click(object sender, ImageClickEventArgs e)
        {
            if (this.guideUnit.Text.Trim() == "")
            {

                messageBox.Show(this, "必须填写“挂靠单位”才能上传！");
                this.guideUnit.Focus();
            }
            else
            {
                commonClass comcls = new commonClass();
                string path = Server.MapPath("/STJS/stclFileUpload/") + userStuId.ToString().Trim();
                string result = comcls.uploadImgFile(fpd_unitPic, path, "挂靠单位申请表");

                if (result == "请选择文件！！！")
                {
                    messageBox.Show(this, "请选择文件！！！");
                }
                else if (result == "文件上传不成功!只能够上传后缀为.jpg、.jepg、.gif、.png,不超过1M的文件!")
                {
                    messageBox.Show(this, "文件上传不成功!只能够上传后缀为.jpg、.jepg、.gif、.png,不超过1M的文件!");
                }
                else if (result == "文件上传成功!")
                {
                    img_unitPic.Visible = true;
                    lab_unitPic.Visible = true;
                    string fileExtension = System.IO.Path.GetExtension(fpd_unitPic.FileName).ToLower();
                    s_unitPic = "挂靠单位申请表" + fileExtension;
                    this.a_unitPic.HRef = "/STJS/stclFileUpload/" + userStuId + "/" + s_unitPic.ToString().Trim();
                    this.img_unitPic.ImageUrl = "/STJS/stclFileUpload/" + userStuId + "/" + s_unitPic.ToString().Trim();
                    this.lab_unitPic.Text = "文件上传成功";
                    this.lab_unitPic.Text += "<br/>";
                    this.lab_unitPic.Text += "文件名:" + this.fpd_unitPic.FileName;
                    messageBox.Show(this, "文件上传成功!");
                    this.imgbtn_otherFile.Focus();
                }
                else
                {
                    this.lab_unitPic.Text = "文件上传不成功!";
                    //此处还要加上错误警告；
                }
            }
        }

        protected void imgbtn_guideTeacherPic_Click(object sender, ImageClickEventArgs e)
        {
              if (this.guideTeacher.Text.Trim() == "")
            {

                messageBox.Show(this, "必须填写“指导老师”才能上传！");
                this.guideTeacher.Focus();
            }
              else
              {
            commonClass comcls = new commonClass();
            string path = Server.MapPath("/STJS/stclFileUpload/") + userStuId.ToString().Trim();
            string result = comcls.uploadImgFile(fpd_guideTeacherPic, path, "指导老师简介");

            if (result == "请选择文件！！！")
            {
                messageBox.Show(this, "请选择文件！！！");
            }
            else if (result == "文件上传不成功!只能够上传后缀为.jpg、.jepg、.gif、.png,不超过1M的文件!")
            {
                messageBox.Show(this, "文件上传不成功!只能够上传后缀为.jpg、.jepg、.gif、.png,不超过1M的文件!");
            }
            else if (result == "文件上传成功!")
            {
                img_guidTeacherPic.Visible = true;
                lab_guidTeacherPic.Visible = true;
                string fileExtension = System.IO.Path.GetExtension(fpd_guideTeacherPic.FileName).ToLower();
                s_guideTeacherPic = "指导老师简介" + fileExtension;
                this.a_guidTeacherPic.HRef = "/STJS/stclFileUpload/" + userStuId + "/" + s_guideTeacherPic.ToString().Trim();
                this.img_guidTeacherPic.ImageUrl = "/STJS/stclFileUpload/" + userStuId + "/" + s_guideTeacherPic.ToString().Trim();
                this.lab_guidTeacherPic.Text = "文件上传成功";
                this.lab_guidTeacherPic.Text += "<br/>";
                this.lab_guidTeacherPic.Text += "文件名:" + this.fpd_guideTeacherPic.FileName;
                messageBox.Show(this, "文件上传成功!");
                this.imgbtn_otherFile.Focus();
            }
            else
            {
                this.lab_guidTeacherPic.Text = "文件上传不成功!";
                //此处还要加上错误警告；
            }
              }
        }

        protected void imgbtn_otherFile_Click(object sender, ImageClickEventArgs e)
        {
            commonClass comcls = new commonClass();
            string path = Server.MapPath("/STJS/stclFileUpload/") + userStuId.ToString().Trim();
            string result = comcls.uploadWordFile(fpd_otherFile, path, "Word全书");

            if (result == "请选择文件！！！")
            {
                messageBox.Show(this, "请选择文件！！！");
            }
            else if (result == "文件上传不成功!只能够上传后缀为.doc或.docx,不超过1M的文件!")
            {
                messageBox.Show(this, "文件上传不成功!只能够上传后缀为.doc或.docx,不超过1M的文件!");
            }
            else if (result == "文件上传成功!")
            {
                img_otherFile.Visible = true;
                lab_otherFile.Visible = true;
                string fileExtension = System.IO.Path.GetExtension(fpd_otherFile.FileName).ToLower();
                s_wordDocument = "Word全书" + fileExtension;
                this.a_otherFile.HRef = "/STJS/stclFileUpload/" + userStuId + "/Word全书.html";
                this.img_otherFile.ImageUrl = "/IMAGE/word.png";
                this.lab_otherFile.Text = "文件上传成功";
                this.lab_otherFile.Text += "<br/>";
                this.lab_otherFile.Text += "文件名:" + this.fpd_otherFile.FileName;
                messageBox.Show(this, "文件上传成功!");
                this.imgbtn_otherFile.Focus();
            }
            else
            {
                this.lab_otherFile.Text = "文件上传不成功!";
                //此处还要加上错误警告；
            }
        }


    }
}