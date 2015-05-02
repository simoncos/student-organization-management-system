//********************************************************
//新增日期: 2013.3.5
//作 者: LX
//內容概述:获取ID,并通过ID取得数据显示，实现三种状态的更新
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
using STLHBLL.SLWL.ZZGL;
using STLHMODEL.SLWL.ZZGL;
using STLHWEB.SLWL.ZZGL;
using STLHCOMMON;

using STLHMODEL.LOGIN;
using System.IO;
namespace STLHWEB.SLWL.ZZGL
{
    public partial class zzglActExamine : System.Web.UI.Page
    {
        zzActivityInfo_BLL z_zzActivityInfo_BLL = new zzActivityInfo_BLL();
        zzActivityInfo z_zzActivityInfo = new zzActivityInfo();
        static string sId = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
        
                   
                    string id = Request.QueryString["ID"].ToString().Trim();
                    sId = EncryptHandler.AsymmectricDecrypts(id, zzglActExamineList.bobPrivateKey);
                    z_zzActivityInfo = z_zzActivityInfo_BLL.queryZzActivityInfoDetail(sId);
                    bind();
                    disableControl.disableExceptBtn(this);
                    pass.Attributes.Add("onclick", "return confirm('确定结束活动吗？');");
                    cancel.Attributes.Add("onclick", "return confirm('确定取消活动吗？');");
                    unPass.Attributes.Add("onclick", "return confirm('确定活动未通过吗？');");
                }
            
        }
        #region 数据绑定将数据显示在前台
        public void bind()
        {
            lab_positiveListPerson2.Text = z_zzActivityInfo.fillName.ToString().Trim();
            lab_positiveListDate2.Text = z_zzActivityInfo.fillDate.ToString().Trim();
            lab_positiveListState2.Text = z_zzActivityInfo.status.ToString().Trim();


            zzActName2.Text = z_zzActivityInfo.sponsorName.ToString().Trim();
            zzActType2.Text = z_zzActivityInfo.sponsorType.ToString().Trim();
            zzActPlace2.Text = z_zzActivityInfo.location.ToString().Trim();
            zzActTime2.Text = z_zzActivityInfo.reserTimeRange.ToString().Trim();
            zzActFund2.Text = z_zzActivityInfo.budgetAmount.ToString().Trim();
            zzActNowFund2.Text = z_zzActivityInfo.actualAmount.ToString().Trim();
            zzActManager2.Text = z_zzActivityInfo.responsName.ToString().Trim();
            zzActNowTime2.Text = z_zzActivityInfo.actualTime.ToString().Trim();

        }
        #endregion

        #region 点击按钮——结束活动
        protected void pass_Click(object sender, EventArgs e)
        {

            z_zzActivityInfo.slzzId = sId;
            
            z_zzActivityInfo.status = "活动结束";
            bool result = z_zzActivityInfo_BLL.updateStatusInfo(z_zzActivityInfo.status, z_zzActivityInfo.slzzId);
            try
            {
                if (result)
                {
                    messageBox.Show(this, "结束活动请求成功！！！");
                    lab_positiveListState2.Text = z_zzActivityInfo.status.ToString().Trim();

                }
                else
                {
                    messageBox.Show(this, "结束活动请求失败！！！");

                }
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }
        }
        #endregion

        #region 点击按钮——取消活动
        protected void cancel_Click(object sender, EventArgs e)
        {
            z_zzActivityInfo.slzzId = Request.QueryString["ID"].ToString();
            z_zzActivityInfo.status = "活动取消";
            bool result = z_zzActivityInfo_BLL.updateStatusInfo(z_zzActivityInfo.status, z_zzActivityInfo.slzzId);
            try
            {
                if (result)
                {
                    messageBox.Show(this, "活动取消请求成功！！！");
                    lab_positiveListState2.Text = z_zzActivityInfo.status.ToString().Trim();

                }
                else
                {
                    messageBox.Show(this, "活动取消请求失败！！！");

                }
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }
        }
        #endregion

        #region 点击按钮——未通过
        protected void unPass_Click(object sender, EventArgs e)
        {
            z_zzActivityInfo.slzzId = Request.QueryString["ID"].ToString();
            z_zzActivityInfo.status = "未通过";
            bool result = z_zzActivityInfo_BLL.updateStatusInfo(z_zzActivityInfo.status, z_zzActivityInfo.slzzId);
            try
            {
                if (result)
                {
                    messageBox.Show(this, "未通过请求成功！！！");
                    lab_positiveListState2.Text = z_zzActivityInfo.status.ToString().Trim();

                }
                else
                {
                    messageBox.Show(this, "未通过请求失败！！！");

                }
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }
        }

        #endregion

    }
}
        