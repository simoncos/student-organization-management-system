//********************************************************
//新增日期: 2013.3.5
//作 者: LX
//內容概述:外联部长、主席查看页面，数据库调用前台显示
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
    public partial class zzglActQuery: System.Web.UI.Page
    {
        zzActivityInfo_BLL z_zzActivityInfo_BLL = new zzActivityInfo_BLL();
        zzActivityInfo z_zzActivityInfo = new zzActivityInfo();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                    string sId = Request.QueryString["ID"].ToString();
                    z_zzActivityInfo = z_zzActivityInfo_BLL.queryZzActivityInfoDetail(sId);
                    bind();
                    disableControl.disableExceptBtn(this);

                }

        }
        public void bind()
        {
            lab_positiveListPerson3.Text = z_zzActivityInfo.fillName;
            lab_positiveListDate3.Text = z_zzActivityInfo.fillDate.ToString().Trim();
            lab_positiveListState3.Text = z_zzActivityInfo.status.ToString().Trim();

            zzActName3.Text = z_zzActivityInfo.sponsorName.ToString().Trim();
            zzActType3.Text = z_zzActivityInfo.sponsorType.ToString().Trim();
            zzActPlace3.Text = z_zzActivityInfo.location.ToString().Trim();
            zzActTime3.Text = z_zzActivityInfo.reserTimeRange.ToString().Trim();
            zzActFund3.Text = z_zzActivityInfo.budgetAmount.ToString().Trim();
            zzActNowTime3.Text = z_zzActivityInfo.actualTime.ToString().Trim();
            zzActNowFund3.Text = z_zzActivityInfo.actualAmount.ToString().Trim();
            zzActManager3.Text = z_zzActivityInfo.responsName.ToString().Trim();
        }
    }
}