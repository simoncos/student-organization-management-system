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
using STLHBLL.ZYGL.CDGL;
using STLHMODEL.ZYGL.CDGL;
using STLHWEB.ZYGL.CDGL;
using STLHCOMMON;
using STLHWEB.App_Code;
using STLHMODEL.LOGIN;
using System.IO;
namespace STLHWEB.ZYGL.CDGL
{
    public partial class cdglLocationList : System.Web.UI.Page
    {
        string conn = ConfigurationManager.AppSettings["STLHDBConnectionString"];
        cdLocationInfo_BLL c_cdLocationInfo_BLL = new cdLocationInfo_BLL();
        cdLocationInfo c_cdLocationInfo = new cdLocationInfo();
        userLoginInfo u_userLoginInfo=new userLoginInfo();
        static string stuId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!SessionData.IsLogin())
                {
                    messageBox.ShowAndRedirect(this, "您未登入或登入时间过长，请返回登入后再进行申请！", "/LOGIN/login.aspx");
                }
                else
                {
                    u_userLoginInfo = SessionData.GetLoginInfo();
                    stuId = u_userLoginInfo.stuId;
                    ViewState["SortOrder"] = "fillDate";
                    ViewState["OrderDire"] = "DESC";
                    bind(conn);
                }
            }
            ViewState["SortOrder"] = "fillDate";
            ViewState["OrderDire"] = "DESC";
            bind(conn);
        }
        protected void btn_clear_Click(object sender, EventArgs e)
        {
            txtbox_location.Text = "";
            txtbox_allowedTimeRange.Text = "";
        }

        protected void btn_putIn_Click(object sender, EventArgs e)
        {
            c_cdLocationInfo.fillId = stuId.Trim();
            c_cdLocationInfo.location = txtbox_location.Text.ToString();
            c_cdLocationInfo.allowedTimeRange = txtbox_allowedTimeRange.Text.ToString();
            c_cdLocationInfo.fillDate = DateTime.Now;
            c_cdLocationInfo.fillId = stuId;
            bool result = false;
            result = c_cdLocationInfo_BLL.updateCdLocationInfo(c_cdLocationInfo);
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
            catch (System.Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }
        }
        public void bind(string conn)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("location");
            dt.Columns.Add("allowedTimeRange");
            dt.Columns.Add("fillDate");
            foreach (cdLocationInfo c in c_cdLocationInfo_BLL.queryCdLocationInfoList())
            {
                dt.Rows.Add(c.location, c.allowedTimeRange, c.fillDate);
            }
            DataView view = dt.DefaultView;
            string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
            view.Sort = sort;
            gvw_cdglLocationList.DataSource = view;
            gvw_cdglLocationList.DataBind();
            dt.Dispose();

        }

        #region
        protected void gvw_cdglLocationList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvw_cdglLocationList.PageIndex = e.NewPageIndex;
        }

        protected void gvw_cdglLocationList_PageIndexChanged(object sender, EventArgs e)
        {
            c_cdLocationInfo_BLL.queryCdLocationInfoList();
            bind(conn);
        }
        #endregion

        protected void gvw_cdglLocationList_Sorting(object sender, GridViewSortEventArgs e)
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
        protected void gvw_cdglLocationList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int i;
            for (i = 0; i < gvw_cdglLocationList.Rows.Count; i++)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;b=this.style.color;this.style.backgroundColor='#507CD1';this.style.color='white'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;this.style.color=b");
                }
            }
            if (e.Row.RowIndex != -1)
            {
                int indexID = this.gvw_cdglLocationList.PageIndex * this.gvw_cdglLocationList.PageSize + e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = indexID.ToString();
            }
        }
        protected void gvw_cdglLocationList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (gvw_cdglLocationList.Rows.Count <= 1)
            {
                e.Cancel = true;
                messageBox.Show(this, "没有记录！");
            }
            else
            {
                bool result = false;
                string name = gvw_cdglLocationList.DataKeys[e.RowIndex].Value.ToString().Trim();
                result = c_cdLocationInfo_BLL.deleteCdLocationInfo(name);
                try
                {
                    if (result == true)
                    {
                        bind(conn);
                        //messageBox.Show(this, "提交成功！！！");
                        ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "btn_putIn ", "alert('删除此记录成功！');", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "btn_putIn ", "alert('删除此记录失败！！！');", true);
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


    }
}