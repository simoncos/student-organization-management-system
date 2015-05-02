using System;
using System.Collections;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Collections.Generic;
using System.Web.UI.WebControls.WebParts;
using System.Linq;
using System.Web;
using System.Drawing;
using System.ComponentModel;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using STLHBLL.SLWL.ZZGL;
using STLHMODEL.SLWL.ZZGL;
using STLHWEB.SLWL.ZZGL;
using STLHCOMMON;
using STLHWEB.App_Code;
using STLHMODEL.LOGIN;
using System.IO;
using FrameWork;
using STLHDAL.LOGIN;
namespace STLHWEB.SLWL.ZZGL
{
    public partial class zzglActFillIn : System.Web.UI.Page
    {
       
        zzActivityInfo_BLL z_zzActivityInfo_BLL = new zzActivityInfo_BLL();
        zzActivityInfo z_zzActivityInfo = new zzActivityInfo();
        userLoginInfo u_userLoginInfo = new userLoginInfo();
      
        static ArrayList items = new ArrayList();
       
        static string stuId = "";
        static  string  id= "";
        protected void Page_Load(object sender, EventArgs e){
            if (!IsPostBack) {

                stuId = UserData.GetUserDate.U_LoginName.Trim();
                userLoginInfo_DAL u_userLoginInfo_DAL = new userLoginInfo_DAL();
                u_userLoginInfo = u_userLoginInfo_DAL.getLoginInfoByLoginId(stuId);
                
                lab_positiveListPerson1.Text = u_userLoginInfo.stuName.ToString().Trim();
                    
                putIn.Attributes.Add("onclick", "return confirm('提交后将无权限更改数据！您确定执行此操作吗？');");
   
                commonClass clsAdd = new commonClass();
                    clsAdd.dropDownList(zzActName1, "SELECT DISTINCT [sponsorName] FROM [slzzSponsorInfo]");
                    clsAdd.dropDownList(zzActPlace1, "SELECT distinct [location] FROM [cdglLocationInfo]");


                    if(HttpContext.Current.Request["ID"]!=null){
                       string sId = Request.QueryString["ID"].ToString().Trim();
                       id = EncryptHandler.AsymmectricDecrypts(sId, zzglActUpdateList.bobPrivateKey);
                       z_zzActivityInfo = z_zzActivityInfo_BLL.queryZzActivityInfoDetail(id);

                       getBind();
                       if(z_zzActivityInfo.status=="待审核"){
                           disableControl.disableAllControl(this);
                       }
                       
                    }
                
            }
        }

        #region 点击按钮——保存草稿
        protected void Save_Click(object sender, EventArgs e)
        {       
            bool result = false;
               
            if (id.Trim() == "")
            {
                unionBind();//联合主键扫描记录，如果存在则根据slzzId将原记录覆盖，如果不存在则插入新数据，并获得此Id
                string searchResult = "";
                searchResult = z_zzActivityInfo_BLL.SearchZzActivityInfoList(z_zzActivityInfo);
                try
                {
                    bind();
                    z_zzActivityInfo.status = "正在填表";
                    if (searchResult == null)
                    {
                        result = z_zzActivityInfo_BLL.insertZzActivityInfo(z_zzActivityInfo);
                        z_zzActivityInfo.slzzId = z_zzActivityInfo_BLL.SearchZzActivityInfoList(z_zzActivityInfo);
                        id = z_zzActivityInfo.slzzId.Trim();
                    }
                    else
                    {
                        z_zzActivityInfo.slzzId = searchResult.Trim();
                        result = z_zzActivityInfo_BLL.updateActivityInfo(z_zzActivityInfo);
                        id = z_zzActivityInfo.slzzId.Trim();

                    }
                }
                catch (Exception ex)
                {
                    ErrorHandler.WriteError(ex);
                    throw;
                }
            }
            else{
                 bind();
                 z_zzActivityInfo.slzzId = id.Trim();
                 z_zzActivityInfo.status = "正在填表";
                 result = z_zzActivityInfo_BLL.updateActivityInfo(z_zzActivityInfo);

            }


                if (result)
                {
                    messageBox.Show(this, "保存成功！！！");

                    lab_positiveListDate1.Text = z_zzActivityInfo.fillDate.ToString().Trim();
                    lab_positiveListState1.Text = z_zzActivityInfo.status.ToString().Trim();
                    //z_zzActivityInfo.sponsorName = lab_positiveListDate1.Text.ToString().Trim();


                }
                else
                {
                    messageBox.Show(this, "保存失败！！！");

                }

            }

        #endregion

        #region 点击按钮——提交
        protected void putIn_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (id.Trim() == "")
            {
                unionBind();//联合主键扫描记录，如果存在则根据slzzId将原记录覆盖，如果不存在则插入新数据，并获得此Id
                string searchResult = "";
                searchResult = z_zzActivityInfo_BLL.SearchZzActivityInfoList(z_zzActivityInfo);//扫描是否存在此记录
                try
                {
                    bind();
                    z_zzActivityInfo.status = "待审核";
                    if (searchResult == null)//如果不存在旧记录，则插入新纪录
                    {
                        result = z_zzActivityInfo_BLL.insertZzActivityInfo(z_zzActivityInfo);
                    }
                    else//如果存在旧记录，则获取其ID，并通过此ID将旧记录更新
                    {
                        z_zzActivityInfo.slzzId = searchResult.Trim();
                        result = z_zzActivityInfo_BLL.updateActivityInfo(z_zzActivityInfo);
                    }
                }
                catch (Exception ex)
                {
                    ErrorHandler.WriteError(ex);
                    throw;
                }
            }
            else
            {
                bind();
                z_zzActivityInfo.slzzId = id.Trim();
                z_zzActivityInfo.status = "待审核";
                result = z_zzActivityInfo_BLL.updateActivityInfo(z_zzActivityInfo);

            }


            if (result)
            {
                  
                messageBox.Show(this, "提交成功！！！");
                disableControl.disableAllControl(this);
                lab_positiveListDate1.Text = z_zzActivityInfo.fillDate.ToString().Trim();
                lab_positiveListState1.Text = z_zzActivityInfo.status.ToString().Trim();
                //z_zzActivityInfo.sponsorName = lab_positiveListDate1.Text.ToString().Trim();//通过此ID将旧记录更新


            }
            else
            {
                messageBox.Show(this, "提交失败！！！");

            }

        }
        #endregion

        #region 将用户输入的数据放入数据集
       
        public void bind()
        {   
            u_userLoginInfo = SessionData.GetLoginInfo();
            z_zzActivityInfo.fillId = u_userLoginInfo.stuId.ToString().Trim();
            z_zzActivityInfo.sponsorName = zzActName1.Text.ToString().Trim();
            z_zzActivityInfo.sponsorType = zzActType1.Text.ToString().Trim();
            if (this.location.Visible == true)
            {
                z_zzActivityInfo.location = location.Text.ToString().Trim();
            }
            else
            {
                z_zzActivityInfo.location = zzActPlace1.Text.ToString().Trim();
            }
            z_zzActivityInfo.reserTimeRange = zzActTime1.Text.ToString().Trim();
            z_zzActivityInfo.budgetAmount = timeForm.foreIntToDb(zzActFund1.Text.ToString().Trim());
            z_zzActivityInfo.actualAmount = timeForm.foreIntToDb(zzActNowFund1.Text.ToString().Trim());
            z_zzActivityInfo.actualTime = timeForm.foreTimeToDb(zzActNowTime1.Text.ToString().Trim());
            z_zzActivityInfo.responsId = zzActManager1.Text.ToString().Trim();//todo:姓名还是ID?
            z_zzActivityInfo.fillDate = DateTime.Now;
        }
        #endregion

        #region 用户输入联合主键放入数据集
        public void unionBind()
        {

            z_zzActivityInfo.sponsorName = zzActName1.Text.ToString().Trim();
            z_zzActivityInfo.sponsorType = zzActType1.Text.ToString().Trim();
          //  z_zzActivityInfo.setupTime = zzActTime1.Text.ToString().Trim();//todo:新增datetime类型
            z_zzActivityInfo.responsId = zzActManager1.Text.ToString().Trim();//todo:是ID！

        }
        #endregion

        #region 数据集中的数据在前台显示
        public void getBind() {

            u_userLoginInfo = SessionData.GetLoginInfo();

            lab_positiveListPerson1.Text = z_zzActivityInfo.fillName.ToString().Trim();
            lab_positiveListDate1.Text = z_zzActivityInfo.fillDate.ToString().Trim();
            lab_positiveListState1.Text = z_zzActivityInfo.status.ToString().Trim();

            commonClass cls = new commonClass();
            cls.dropDownList(zzActName1, "SELECT distinct [sponsorName] FROM [View_slzzActDetail]");
            cls.dropDownList(zzActPlace1, "SELECT distinct [location] FROM [View_slzzActDetail]");
            zzActPlace1.SelectedValue = z_zzActivityInfo.location.ToString().Trim();
            zzActName1.SelectedValue = z_zzActivityInfo.sponsorName.ToString().Trim();
            
            zzActType1.Text=z_zzActivityInfo.sponsorType.ToString().Trim();
            zzActTime1.Text=z_zzActivityInfo.reserTimeRange.ToString().Trim();
            zzActFund1.Text=z_zzActivityInfo.budgetAmount.ToString().Trim();
            zzActNowTime1.Text=z_zzActivityInfo.actualTime.ToString().Trim();
            zzActNowFund1.Text = z_zzActivityInfo.actualAmount.ToString().Trim();
            zzActManager1.Text=z_zzActivityInfo.responsName.ToString().Trim();//todo:姓名还是ID?
        }
#endregion

        #region 活动场地 "其他"触发事件的设置，与场地管理相连

        protected void zzActPlace1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string StrPower = ((DropDownList)sender).SelectedItem.ToString();


            if (StrPower.Trim() == "其他")
            {
                this.location.Visible = true;
                this.location.Focus();
            }
        }
        #endregion
     
    }
}