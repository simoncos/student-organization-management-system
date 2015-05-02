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
namespace STLHWEB.SLWL.ZZGL
{
    public partial class zzglSponsorList : System.Web.UI.Page
    {
        string conn = ConfigurationManager.AppSettings["STLHDBConnectionString"];
        zzSponsorInfo_BLL z_zzSponsorInfo_BLL = new zzSponsorInfo_BLL();
        zzSponsorInfo z_zzSponsorInfo = new zzSponsorInfo();
        static string stuId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                stuId=UserData.GetUserDate.U_LoginName.Trim();
                ViewState["SortOrder"] = "fillDate";
                ViewState["OrderDire"] = "DESC";

                bind(conn);
             }
            
        }

        #region 清除按钮
        protected void btn_clear_Click(object sender, EventArgs e)
        {
            txtbox_sponsorName.Text = "";
            txtbox_contactName.Text = "";
            txtbox_contactPosition.Text = "";
            txtbox_contactTel.Text = "";
            txtbox_leaderName.Text = "";
            txtbox_leaderPosition.Text = "";
            txtbox_leaderTel.Text = "";
        }
        #endregion

        #region 提交按钮
        protected void btn_putIn_Click(object sender, EventArgs e)
        {

            z_zzSponsorInfo.fillId = stuId.Trim();
            z_zzSponsorInfo.sponsorName = txtbox_sponsorName.Text.ToString().Trim();
            z_zzSponsorInfo.contactName = txtbox_contactName.Text.ToString().Trim();
            z_zzSponsorInfo.contactPosition = txtbox_contactPosition.Text.ToString().Trim();
            z_zzSponsorInfo.contactTel = txtbox_contactTel.Text.ToString().Trim();

            z_zzSponsorInfo.leaderName = txtbox_leaderName.Text.ToString().Trim();
            z_zzSponsorInfo.leaderPosition = txtbox_leaderPosition.Text.ToString().Trim();
            z_zzSponsorInfo.leaderTel = txtbox_leaderTel.Text.ToString().Trim();
            z_zzSponsorInfo.fillDate = DateTime.Now;
            z_zzSponsorInfo.status = "正常";
            bool result = false;
            result = z_zzSponsorInfo_BLL.updateZzSponsorInfo(z_zzSponsorInfo);
            try
            {
                if (result == true)
                {
                    bind(conn); 
                    //messageBox.Show(this, "提交成功！！！");
                    ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "btn_putIn ", "alert('提交成功,产生一条新纪录！');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "btn_putIn ", "alert('提交失败！！！');", true);
                    //messageBox.Show(this, "提交失败！！！");
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }
        }
        #endregion

        #region GridView绑定数据库
        public void bind(string conn)
        {
            
            DataTable dt = new DataTable();
            dt.Columns.Add("sponsorName");
            dt.Columns.Add("leaderName");
            dt.Columns.Add("leaderPosition");
            dt.Columns.Add("leaderTel");
            dt.Columns.Add("contactName");
            dt.Columns.Add("contactPosition");
            dt.Columns.Add("contactTel");
            dt.Columns.Add("fillDate");
            //z_zzActivityInfo_BLL.queryZzActivityInfoList(z_zzActivityInfo);
            foreach (zzSponsorInfo z in z_zzSponsorInfo_BLL.queryZzSponsorInfo("正常"))
            {
                dt.Rows.Add(z.sponsorName,z.leaderName,z.leaderPosition,z.leaderTel,z.contactName,z.contactPosition,z.contactTel,z.fillDate);
            }

                DataView view = dt.DefaultView;
                string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
                view.Sort = sort;
                gvw_zzglSponsorList.DataSource = view;
                gvw_zzglSponsorList.DataBind();
            
        }
        #endregion

        #region gridview——分页
        protected void gvw_zzglSponsorList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
                this.gvw_zzglSponsorList.PageIndex = e.NewPageIndex;
        }

        protected void gvw_zzglSponsorList_PageIndexChanged(object sender, EventArgs e)
        {
            z_zzSponsorInfo_BLL.queryZzSponsorInfo("正常");
            bind(conn);
        }
        #endregion

        #region gridview——正反排序
        protected void gvw_zzglSponsorList_Sorting(object sender, GridViewSortEventArgs e)
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
        protected void gvw_zzglSponsorList_RowDataBound (object sender, GridViewRowEventArgs e)
        {
            int i;
            for (i = 0; i < gvw_zzglSponsorList.Rows.Count; i++)
            {


                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;b=this.style.color;this.style.backgroundColor='#507CD1';this.style.color='white'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;this.style.color=b");
                }
            }
            if (e.Row.RowIndex != -1)
            {
                int indexID = this.gvw_zzglSponsorList.PageIndex * this.gvw_zzglSponsorList.PageSize + e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = indexID.ToString();
            }
        }
        #endregion


        #region gridview——删除记录
        protected void gvw_zzglSponsorList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (gvw_zzglSponsorList.Rows.Count <= 1)
            {
                e.Cancel = true;
                messageBox.Show(this, "没有记录！");

            }
            else
            {        bool result = false;
                string name =gvw_zzglSponsorList.DataKeys[e.RowIndex].Value.ToString().Trim();

                result = z_zzSponsorInfo_BLL.deleteZzSponsorInfo(name);
                try
                {
                    if (result == true)
                    {
                        bind(conn);
                        //messageBox.Show(this, "删除此记录成功！");
                        ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "btn_putIn ", "alert('删除成功！');", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "btn_putIn ", "alert('删除失败！');", true);
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

        #region gridview——编辑
        protected void gvw_zzglSponsorList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvw_zzglSponsorList.EditIndex = e.NewEditIndex;
            bind(conn);
        }
        protected void gvw_zzglSponsorList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvw_zzglSponsorList.EditIndex = -1;
            bind(conn);
        }
        protected void gvw_zzglSponsorList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var row= gvw_zzglSponsorList.Rows[e.RowIndex];

            gvw_zzglSponsorList.Columns[1].ExtractValuesFromCell(
                e.Keys,
                row.Cells[1] as DataControlFieldCell,
                DataControlRowState.Edit,
                true 
                );
            gvw_zzglSponsorList.Columns[2].ExtractValuesFromCell(
                e.NewValues,
                row.Cells[2] as DataControlFieldCell,
                DataControlRowState.Edit,
                true
                );
            gvw_zzglSponsorList.Columns[3].ExtractValuesFromCell(
                e.NewValues,
                row.Cells[3] as DataControlFieldCell,
                DataControlRowState.Edit,
                true
                );
            gvw_zzglSponsorList.Columns[4].ExtractValuesFromCell(
                e.NewValues,
                row.Cells[4] as DataControlFieldCell,
                DataControlRowState.Edit,
                true
            );
            gvw_zzglSponsorList.Columns[5].ExtractValuesFromCell(
                e.NewValues,
                row.Cells[5] as DataControlFieldCell,
                DataControlRowState.Edit,
                true
            );
            gvw_zzglSponsorList.Columns[6].ExtractValuesFromCell(
                e.NewValues,
                row.Cells[6] as DataControlFieldCell,
                DataControlRowState.Edit,
                true
            );
            gvw_zzglSponsorList.Columns[7].ExtractValuesFromCell(
                e.NewValues,
                row.Cells[7] as DataControlFieldCell,
                DataControlRowState.Edit,
                true
            );



            z_zzSponsorInfo.sponsorName = e.Keys["sponsorName"].ToString().Trim();
            if (e.NewValues["leaderName"] != null)
            {
                z_zzSponsorInfo.leaderName = (e.NewValues["leaderName"]).ToString().Trim();
            }
            else
            {
                z_zzSponsorInfo.leaderName = "";
            }

            if (e.NewValues["leaderPosition"] != null)
            {
                z_zzSponsorInfo.leaderPosition = e.NewValues["leaderPosition"].ToString().Trim();
            }
            else
            {
                z_zzSponsorInfo.leaderPosition = "";
            }

            if (e.NewValues["leaderTel"] != null)
            {
                z_zzSponsorInfo.leaderTel = e.NewValues["leaderTel"].ToString().Trim();
            }
            else
            {
                z_zzSponsorInfo.leaderTel = "";
            }

            if (e.NewValues["contactName"] != null)
            {
                z_zzSponsorInfo.contactName = e.NewValues["contactName"].ToString().Trim();
            }
            else
            {
                z_zzSponsorInfo.contactName = "";
            }

            if (e.NewValues["contactPosition"] != null)
            {
                z_zzSponsorInfo.contactPosition = e.NewValues["contactPosition"].ToString().Trim();
            }
            else
            {
                z_zzSponsorInfo.contactPosition = "";
            }

            if (e.NewValues["contactTel"] != null)
            {
                z_zzSponsorInfo.contactTel = e.NewValues["contactTel"].ToString().Trim();
            }
            else
            {
                z_zzSponsorInfo.contactTel = "";
            }

            z_zzSponsorInfo.fillId = stuId.Trim();
            z_zzSponsorInfo.fillDate = DateTime.Now;
            z_zzSponsorInfo.status = "正常";
            bool result = false;
            result = z_zzSponsorInfo_BLL.updateZzSponsorInfo(z_zzSponsorInfo);
            try
            {
                if (result == true)
                {
                    gvw_zzglSponsorList.EditIndex = -1;
                    bind(conn);
                    
                    //messageBox.Show(this, "提交成功！！！");
                    ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "btn_putIn ", "alert('修改成功！');", true);

                }
                else
                {
                    gvw_zzglSponsorList.EditIndex = -1;
                    ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "btn_putIn ", "alert('修改失败！');", true);
                    //messageBox.Show(this, "提交失败！！！");
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }


            //z_zzSponsorInfo.leaderName = ((TextBox)(gvw_zzglSponsorList.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim();
            //z_zzSponsorInfo.leaderPosition = ((TextBox)(gvw_zzglSponsorList.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim();
            //z_zzSponsorInfo.leaderTel = ((TextBox)(gvw_zzglSponsorList.Rows[e.RowIndex].Cells[4].Controls[0])).Text.Trim();

            //z_zzSponsorInfo.contactName = ((TextBox)(gvw_zzglSponsorList.Rows[e.RowIndex].Cells[5].Controls[0])).Text.Trim();
            //z_zzSponsorInfo.contactPosition= ((TextBox)(gvw_zzglSponsorList.Rows[e.RowIndex].Cells[6].Controls[0])).Text.Trim();
            //z_zzSponsorInfo.contactTel = ((TextBox)(gvw_zzglSponsorList.Rows[e.RowIndex].Cells[7].Controls[0])).Text.Trim();
        }
        #endregion




    }
}