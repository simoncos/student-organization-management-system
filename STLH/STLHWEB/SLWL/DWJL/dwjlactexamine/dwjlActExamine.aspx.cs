//********************************************************
//新增日期: 2013.3.10
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
using STLHBLL.SLWL.DWJL;
using STLHMODEL.SLWL.DWJL;
using STLHWEB.SLWL.DWJL;
using STLHCOMMON;

using STLHMODEL.LOGIN;
using System.IO;
using System.Security.Cryptography;
using FrameWork;

namespace STLHWEB.SLWL.DWJL
{
    public partial class dwjlActExamine : System.Web.UI.Page
    {
        string conn = ConfigurationManager.AppSettings["STLHDBConnectionString"];
        jlBasicInfo_BLL j_jlBasicInfo_BLL= new jlBasicInfo_BLL();
        jlBasicInfo j_jlBasicInfo = new jlBasicInfo();
        jlParticipators j_jlParticipators = new jlParticipators();
        jlParticipators_BLL j_jlParticipators_BLL = new jlParticipators_BLL();

        static string sId = "";
        static string stuId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                

                    stuId = UserData.GetUserDate.U_LoginName.Trim();
                    string id = Request.QueryString["ID"].ToString().Trim();
                    sId = id.Trim();
                    j_jlBasicInfo = j_jlBasicInfo_BLL.queryJlActivityInfoDetail(sId);
                    ViewState["SortOrder"] = "fillDate";
                    ViewState["OrderDire"] = "DESC";
                    DBbind();
                    bind(conn);

                    pass.Attributes.Add("onclick", "return confirm('确定结束活动吗？');");
                    cancel.Attributes.Add("onclick", "return confirm('确定取消活动吗？');");
                    save.Attributes.Add("onclick", "return confirm('确定保存活动吗？');");
            }
        }

        #region 点击按钮——结束活动
        protected void pass_Click(object sender, EventArgs e)
        {
            j_jlBasicInfo.sljlId = sId.Trim();
            bindDb();
            j_jlBasicInfo.fillId = stuId.Trim();
            j_jlBasicInfo.status = "活动结束";
            j_jlBasicInfo.fillDate = DateTime.Now;
            bool result = j_jlBasicInfo_BLL.updateJlBasicInfo(j_jlBasicInfo);
            try
            {
                if (result)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "pass", "alert('结束活动请求成功！！！');", true);
                    //messageBox.Show(this, "结束活动请求成功！！！");
                    lab_positiveListDate2.Text = j_jlBasicInfo.fillDate.ToString().Trim();
                    lab_positiveListState2.Text = j_jlBasicInfo.status.ToString().Trim();
                    disableControl.disableAllControl(this);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "pass", "alert('结束活动请求失败！！！');", true);
                    //messageBox.Show(this, "结束活动请求失败！！！");

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
           j_jlBasicInfo.sljlId = sId.Trim();
           bindDb();
           j_jlBasicInfo.fillId = stuId.Trim();
           j_jlBasicInfo.status = "活动取消";
           j_jlBasicInfo.fillDate = DateTime.Now;
           bool result = j_jlBasicInfo_BLL.updateJlBasicInfo(j_jlBasicInfo);
            try
            {
                if (result)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "cancel", "alert('活动取消请求成功！');", true);
                    lab_positiveListDate2.Text = j_jlBasicInfo.fillDate.ToString().Trim();
                    lab_positiveListState2.Text = j_jlBasicInfo.status.ToString().Trim();
                    //messageBox.Show(this, "活动取消请求成功！！！");
                    disableControl.disableAllControl(this);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "cancel", "alert('活动取消请求失败！');", true);
                    //messageBox.Show(this, "活动取消请求失败！！！");

                }
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }
        }
        #endregion

        #region 点击按钮——保存
        protected void save_Click(object sender, EventArgs e)
        {
           j_jlBasicInfo.sljlId = sId.Trim();
           bindDb();
           j_jlBasicInfo.fillId =stuId.Trim();
           j_jlBasicInfo.status = "正常进行";
           j_jlBasicInfo.fillDate = DateTime.Now;
            bool result = j_jlBasicInfo_BLL.updateJlBasicInfo(j_jlBasicInfo);
            try
            {
                if (result)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "save ", "alert('保存成功！');", true);
                    //messageBox.Show(this, "保存成功！！！");
                    lab_positiveListDate2.Text = j_jlBasicInfo.fillDate.ToString().Trim();
                    lab_positiveListState2.Text = j_jlBasicInfo.status.ToString().Trim();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "save ", "alert('保存失败！');", true);

                }
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }
        }

        #endregion

        #region 点击按钮——添加
        protected void btn_add_Click(object sender, EventArgs e)
        {
            j_jlParticipators.participatorId = txtbox_participatorId.Text.ToString().Trim();
            if (sId.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), " btn_add ", "alert('必须填写基本信息！');", true);
                //messageBox.Show(this, "");
                txtbox_sponsor2.Focus();
            }
            else
            {
                j_jlParticipators.sljlId = sId.Trim();
                j_jlParticipators.fillDate = DateTime.Now;
                bool result = false;
                result = j_jlParticipators_BLL.insertJlParticipators(j_jlParticipators);
                try
                {
                    if (result == true)
                    {
                        bind(conn);
                        //messageBox.Show(this, "提交成功！！！");
                        ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), " btn_add ", "alert('提交成功,产生一条新纪录！');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), " btn_add ", "alert('提交失败！！！');", true);
                        //messageBox.Show(this, "提交失败！！！");
                    }
                }
                catch (Exception ex)
                {
                    ErrorHandler.WriteError(ex);
                    throw;
                }

            }
        }
        #endregion
              
        #region 数据绑定将数据显示在前台
        public void DBbind()
        {
            lab_positiveListPerson2.Text = j_jlBasicInfo.fillName.ToString().Trim();
            lab_positiveListDate2.Text = j_jlBasicInfo.fillDate.ToString().Trim();
            lab_positiveListState2.Text = j_jlBasicInfo.status.ToString().Trim();

            txtbox_sponsor2.Text = j_jlBasicInfo.inviter.ToString().Trim();
            txtbox_invitee2.Text = j_jlBasicInfo.invited.ToString().Trim();
            txtbox_activityName2.Text = j_jlBasicInfo.sljlName.ToString().Trim();
            txtbox_activityTime2.Text = j_jlBasicInfo.sljlDate.ToString().Trim();
            txtbox_activityPlace2.Text = j_jlBasicInfo.sljlLocation.ToString().Trim();
            txtbox_invitedNumber2.Text = j_jlBasicInfo.invitedAmount.ToString().Trim();
            txtbox_linkmanName2.Text = j_jlBasicInfo.contactName.ToString().Trim();
            txtbox_linkmanPhone2.Text = j_jlBasicInfo.contactTel.ToString().Trim();
            txtbox_schoolPrincipal2.Text=j_jlBasicInfo.responsName.ToString().Trim();
            txtbox_schoolPrincipalPhone2.Text=j_jlBasicInfo.responsTel.ToString().Trim();
        }
        #endregion

        #region 数据绑定将前台数据放入数据库
        public void bindDb()
        {
            j_jlBasicInfo.inviter=txtbox_sponsor2.Text.ToString().Trim();
            j_jlBasicInfo.invited=txtbox_invitee2.Text.ToString().Trim();
            j_jlBasicInfo.sljlName=txtbox_activityName2.Text.ToString().Trim();
            j_jlBasicInfo.sljlDate=Convert.ToDateTime(txtbox_activityTime2.Text.ToString().Trim());
            j_jlBasicInfo.sljlLocation=txtbox_activityPlace2.Text.ToString().Trim();
            j_jlBasicInfo.invitedAmount=Convert.ToByte(txtbox_invitedNumber2.Text .ToString().Trim());
            j_jlBasicInfo.contactName= txtbox_linkmanName2.Text.ToString().Trim();
            j_jlBasicInfo.contactTel=txtbox_linkmanPhone2.Text.ToString().Trim();
            j_jlBasicInfo.responsName=txtbox_schoolPrincipal2.Text.ToString().Trim();
            j_jlBasicInfo.responsTel=txtbox_schoolPrincipalPhone2.Text.ToString().Trim();
        }
        #endregion








        #region GridView绑定数据库
        public void bind(string conn)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("participatorId");
            dt.Columns.Add("participatorName");
            dt.Columns.Add("participatorGender");
            dt.Columns.Add("fillDate");
            //z_zzActivityInfo_BLL.queryZzActivityInfoList(z_zzActivityInfo);
            foreach (jlParticipators j in j_jlParticipators_BLL.queryJlParticipators(sId))
            {
                dt.Rows.Add(j.participatorId, j.participatorName, j.participatorGender, j.fillDate);
            }

            DataView view = dt.DefaultView;
            string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
            view.Sort = sort;
            gvw_dwjlActExamine.DataSource = view;
            gvw_dwjlActExamine.DataBind();

        }
        #endregion

        #region gridview——分页
        protected void gvw_dwjlActExamine_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvw_dwjlActExamine.PageIndex = e.NewPageIndex;
        }

        protected void gvw_dwjlActExamine_PageIndexChanged(object sender, EventArgs e)
        {
            j_jlParticipators_BLL.queryJlParticipators(sId);
            bind(conn);
        }
        #endregion

        #region gridview——正反排序
        protected void gvw_dwjlActExamine_Sorting(object sender, GridViewSortEventArgs e)
        {

            string sPage = e.SortExpression;
            if (ViewState["SortOrder"].ToString() == sPage)
            {
                if (ViewState["OrderDire"].ToString() == "DESC")
                {
                    ViewState["OrderDire"] = "ASC";
                }
                else
                {
                    ViewState["OrderDire"] = "DESC";
                }
            }
            else
            {
                ViewState["SortOrder"] = e.SortExpression;
            }
            bind(conn);
        }
        #endregion

        #region gridview ——移过变色，序号
        protected void gvw_dwjlActExamine_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int i;
            for (i = 0; i < gvw_dwjlActExamine.Rows.Count; i++)
            {


                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;b=this.style.color;this.style.backgroundColor='#507CD1';this.style.color='white'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;this.style.color=b");
                }
            }
            if (e.Row.RowIndex != -1)
            {
                int indexID = this.gvw_dwjlActExamine.PageIndex * this.gvw_dwjlActExamine.PageSize + e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = indexID.ToString();
            }
        }
        #endregion

        #region gridview——删除记录
        protected void gvw_dwjlActExamine_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (gvw_dwjlActExamine.Rows.Count <= 1)
            {
                e.Cancel = true;
                messageBox.Show(this, "没有记录！");

            }
            else
            {
                bool result = false;
                string participatorId = gvw_dwjlActExamine.DataKeys[e.RowIndex].Value.ToString().Trim();
                result = j_jlParticipators_BLL.deleteJlParticipators(participatorId, sId);
                try
                {
                    if (result == true)
                    {
                        bind(conn);
                        //messageBox.Show(this, "删除此记录成功！");
                        ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "btn_add ", "alert('删除成功！');", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "btn_add ", "alert('删除失败！');", true);
                    }
                }
                catch (Exception ex)
                {
                    ErrorHandler.WriteError(ex);
                    throw;
                }
            }
        }
        #endregion
    }
}