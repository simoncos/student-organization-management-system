//********************************************************
//新增日期: 2013.3.15
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
using STLHDAL.LOGIN;
namespace STLHWEB.SLWL.DWJL
{
    public partial class dwjlActFillIn : System.Web.UI.Page
    {
        bool result = false;
        bool corverstatus = false;
        string conn = ConfigurationManager.AppSettings["STLHDBConnectionString"];
        jlBasicInfo_BLL j_jlBasicInfo_BLL = new jlBasicInfo_BLL();
        jlBasicInfo j_jlBasicInfo = new jlBasicInfo();
        jlParticipators j_jlParticipators = new jlParticipators();
        jlParticipators_BLL j_jlParticipators_BLL = new jlParticipators_BLL();
        userLoginInfo u_userLoginInfo = new userLoginInfo();
        
        static string sId = "";
        static string stuId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              

                    stuId = UserData.GetUserDate.U_LoginName.Trim();
                userLoginInfo_DAL u_userLoginInfo_DAL=new userLoginInfo_DAL();
                u_userLoginInfo = u_userLoginInfo_DAL.getLoginInfoByLoginId(stuId);
                    lab_positiveListPerson2.Text = u_userLoginInfo.stuName.ToString().Trim();
                    ViewState["SortOrder"] = "fillDate";
                    ViewState["OrderDire"] = "DESC";
                    #region 由列表进入
                    if (HttpContext.Current.Request["ID"] != null)
                    {
                        string id = Request.QueryString["ID"].ToString().Trim();
                        sId = id.Trim();
                        j_jlBasicInfo = j_jlBasicInfo_BLL.queryJlActivityInfoDetail(sId);

                        if (j_jlBasicInfo.status == "正常进行")
                        {
                            u_userLoginInfo = SessionData.GetLoginInfo();
                            lab_positiveListPerson2.Text = j_jlBasicInfo.fillName.ToString().Trim();
                            lab_positiveListDate2.Text = j_jlBasicInfo.fillDate.ToString().Trim();
                            lab_positiveListState2.Text = j_jlBasicInfo.status.ToString().Trim();

                            txtbox_sponsor1.Text = j_jlBasicInfo.inviter.ToString().Trim();
                            txtbox_invitee1.Text = j_jlBasicInfo.invited.ToString().Trim();
                            txtbox_activityName1.Text = j_jlBasicInfo.sljlName.ToString().Trim();
                            txtbox_activityTime1.Text = j_jlBasicInfo.sljlDate.ToString().Trim();

                            txtbox_activityName1.ReadOnly = true;
                            txtbox_sponsor1.ReadOnly = true;
                            txtbox_invitee1.ReadOnly = true;
                            txtbox_activityTime1.ReadOnly = true;

                            txtbox_activityName1.Style["cursor"] = "not-allowed";
                            txtbox_sponsor1.Style["cursor"] = "not-allowed";
                            txtbox_invitee1.Style["cursor"] = "not-allowed";
                            txtbox_activityTime1.Style["cursor"] = "not-allowed";

                            txtbox_activityPlace1.Text = j_jlBasicInfo.sljlLocation.ToString().Trim();
                            txtbox_invitedNumber1.Text = j_jlBasicInfo.invitedAmount.ToString().Trim();
                            txtbox_linkmanName1.Text = j_jlBasicInfo.contactName.ToString().Trim();
                            txtbox_linkmanPhone1.Text = j_jlBasicInfo.contactTel.ToString().Trim();
                            txtbox_schoolPrincipal1.Text = j_jlBasicInfo.responsName.ToString().Trim();
                            txtbox_schoolPrincipalPhone1.Text = j_jlBasicInfo.responsTel.ToString().Trim();
                            bind(conn);
                        }

                    }
                    #endregion
                    cancel.Attributes.Add("onclick", "return confirm('确定清空已填写内容吗？');");
                    //save.Attributes.Add("onclick", "return confirm('保存后可继续修改！');");
                
            }
        }
        
        #region 按钮——保存
        protected void save_Click(object sender, EventArgs e)
        {

            unionBind(); 
            string s_searchResult = j_jlBasicInfo_BLL.SearchSlijlActBasicInfoList(j_jlBasicInfo);
            if (s_searchResult == null)
            {
                sId = "";
            }
            else { sId = s_searchResult; }
            if(sId.Trim()==""){
                unionBind();//联合主键扫描记录，如果存在则根据slzzId将原记录覆盖，如果不存在则插入新数据，并获得此Id;添加时未避免覆盖原来的记录,应该有提示
                string searchResult = "";

                searchResult = j_jlBasicInfo_BLL.SearchSlijlActBasicInfoList(j_jlBasicInfo);
                try {
                    bindDb();
                    if (searchResult == null)
                    {
                        result = j_jlBasicInfo_BLL.insertJlBasicInfo(j_jlBasicInfo);
                        j_jlBasicInfo.sljlId = j_jlBasicInfo_BLL.SearchSlijlActBasicInfoList(j_jlBasicInfo);
                        sId = j_jlBasicInfo.sljlId.Trim();
                    }
                    else
                    {
                        j_jlBasicInfo.sljlId = searchResult.Trim();
                        result = j_jlBasicInfo_BLL.updateJlBasicInfo(j_jlBasicInfo);
                        sId = j_jlBasicInfo.sljlId.Trim();
                    }
                }
                 catch (Exception ex)
                {
                    ErrorHandler.WriteError(ex);
                    throw;
                }
            }
            else{
                //messageBox.Show(this, "保存成功！！！");
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('已存在该活动记录!');", true);
            //    this.save.Style["Style"] = "display:none;";
            //    this.cover.Style["Style"] = "display:block;";
                this.save.Visible = false;
                this.cover.Visible = true;
                this.uncover.Visible = true;
                corverstatus = true;
                disableControl.disableExceptBtn(this);
                
            }


            if(result){
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "save ", "alert('保存成功！');", true);
                   //messageBox.Show(this, "保存成功！！！");
                    lab_positiveListDate2.Text = j_jlBasicInfo.fillDate.ToString().Trim();
                    lab_positiveListState2.Text = j_jlBasicInfo.status.ToString().Trim();

            }
             else
                {
                    if (corverstatus == false)
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "save ", "alert('保存失败！');", true);
                        //messageBox.Show(this, "保存失败！！！");
                    }

                }
     
          
        }
        #endregion

        #region 按钮——清空
        protected void cancel_Click(object sender, EventArgs e)
        {  // 清空按钮时候，基本信息和人员安排部分都清空。
            txtbox_sponsor1.Text = "";
            txtbox_invitee1.Text = "";
            txtbox_activityName1.Text = "";
            txtbox_activityTime1.Text = "";
            txtbox_activityPlace1.Text = "";
            txtbox_invitedNumber1.Text = "";
            txtbox_linkmanName1.Text = "";
            txtbox_linkmanPhone1.Text = "";
            txtbox_schoolPrincipal1.Text = "";
            txtbox_schoolPrincipalPhone1.Text = "";
            txtbox_participatorId.Text = "";
            sId = "";

        gvw_dwjlActFillIn.DataSource = null;
        gvw_dwjlActFillIn.DataBind();

            lab_positiveListDate2.Text ="";
            lab_positiveListState2.Text = "";
        }
        #endregion

        #region 数据绑定将前台数据放入数据库
        public void bindDb()
        {
            j_jlBasicInfo.fillId = stuId.ToString().Trim();

            j_jlBasicInfo.inviter = txtbox_sponsor1.Text.ToString().Trim();
            j_jlBasicInfo.invited = txtbox_invitee1.Text.ToString().Trim();
            j_jlBasicInfo.sljlName = txtbox_activityName1.Text.ToString().Trim();
            j_jlBasicInfo.sljlDate = timeForm.foreTimeToDb(txtbox_activityTime1.Text.ToString());
            j_jlBasicInfo.sljlLocation = txtbox_activityPlace1.Text.ToString().Trim();

            j_jlBasicInfo.invitedAmount = timeForm.foreByteToDb(txtbox_invitedNumber1.Text.ToString());

            j_jlBasicInfo.contactName = txtbox_linkmanName1.Text.ToString().Trim();
            j_jlBasicInfo.contactTel = txtbox_linkmanPhone1.Text.ToString().Trim();
            j_jlBasicInfo.responsName = txtbox_schoolPrincipal1.Text.ToString().Trim();
            j_jlBasicInfo.responsTel = txtbox_schoolPrincipalPhone1.Text.ToString().Trim();
            j_jlBasicInfo.fillDate = DateTime.Now;

            j_jlBasicInfo.status = "正常进行";
        }
        #endregion

        #region 用户输入联合主键放入数据集
        public void unionBind()
        {
            j_jlBasicInfo.sljlName = txtbox_activityName1.Text.ToString().Trim();
            j_jlBasicInfo.inviter = txtbox_sponsor1.Text.ToString().Trim();
            j_jlBasicInfo.invited = txtbox_invitee1.Text.ToString().Trim();
            j_jlBasicInfo.sljlDate = timeForm.foreTimeToDb(txtbox_activityTime1.Text.ToString().Trim());
        }
        #endregion

        #region 按钮——添加
        protected void btn_add_Click(object sender, EventArgs e)
        {
            j_jlParticipators.participatorId = txtbox_participatorId.Text.ToString().Trim();
            if (sId.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), " btn_add ", "alert('必须填写基本信息！');", true);
                //messageBox.Show(this, "");
                txtbox_sponsor1.Focus();
            }
            else { 
            j_jlParticipators.sljlId = sId.Trim();
            j_jlParticipators.fillDate = DateTime.Now;
            bool result = false;
            result = j_jlParticipators_BLL.insertJlParticipators(j_jlParticipators);
            try {
                if (result == true)
                {
                    bind(conn);
                    //messageBox.Show(this, "提交成功！！！");
                    ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), " btn_add ", "alert('提交成功,产生一条新记录！');", true);
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
            gvw_dwjlActFillIn.DataSource = view;
            gvw_dwjlActFillIn.DataBind();

        }
        #endregion

        #region gridview——分页
        protected void gvw_dwjlActFillIn_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvw_dwjlActFillIn.PageIndex = e.NewPageIndex;
        }

        protected void gvw_dwjlActFillIn_PageIndexChanged(object sender, EventArgs e)
        {
            j_jlParticipators_BLL.queryJlParticipators(sId);
            bind(conn);
        }
        #endregion

        #region gridview——正反排序
        protected void gvw_dwjlActFillIn_Sorting(object sender, GridViewSortEventArgs e)
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
        protected void gvw_dwjlActFillIn_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int i;
            for (i = 0; i < gvw_dwjlActFillIn.Rows.Count; i++)
            {


                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;b=this.style.color;this.style.backgroundColor='#507CD1';this.style.color='white'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;this.style.color=b");
                }
            }
            if (e.Row.RowIndex != -1)
            {
                int indexID = this.gvw_dwjlActFillIn.PageIndex * this.gvw_dwjlActFillIn.PageSize + e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = indexID.ToString();
            }
        }
        #endregion

        #region gridview——删除记录
        protected void gvw_dwjlActFillIn_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (gvw_dwjlActFillIn.Rows.Count < 1)
            {
                e.Cancel = true;
                messageBox.Show(this, "没有记录！");

            }
            else
            {
                bool result = false;
                string participatorId = gvw_dwjlActFillIn.DataKeys[e.RowIndex].Value.ToString().Trim();
                result = j_jlParticipators_BLL.deleteJlParticipators(participatorId,sId);
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

        protected void cover_Click(object sender, EventArgs e)
        {
            bindDb();
            j_jlBasicInfo.sljlId = sId.Trim();
            result = j_jlBasicInfo_BLL.updateJlBasicInfo(j_jlBasicInfo);
            if (result)
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "save ", "alert('覆盖成功！');", true);
                //messageBox.Show(this, "保存成功！！！");
                lab_positiveListDate2.Text = j_jlBasicInfo.fillDate.ToString().Trim();
                lab_positiveListState2.Text = j_jlBasicInfo.status.ToString().Trim();
                corverstatus = false;
                this.cover.Visible = false;
                this.save.Visible = true;
                this.uncover.Visible = false;
                disableControl.ableAllControl(this);
            }
            else
            {

                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "save ", "alert('覆盖失败！');", true);

            }
        }

        protected void uncover_Click(object sender, EventArgs e)
        {
            this.save.Visible =true;
            this.cover.Visible = false;
            this.uncover.Visible = false;
            disableControl.ableAllControl(this);
        }
    }
}