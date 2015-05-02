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
using STLHBLL.ZYGL.CDGL;
using STLHMODEL.ZYGL.CDGL;
using STLHWEB.ZYGL.CDGL;
using STLHCOMMON;
using STLHMODEL.LOGIN;
using System.IO;

namespace STLHWEB.ZYGL.CDGL
{
    public partial class cdglLocationQueryList : System.Web.UI.Page
    {
        string conn = ConfigurationManager.AppSettings["STLHDBConnectionString"];
        cdLocationInfo_BLL c_cdLocationInfo_BLL = new cdLocationInfo_BLL();
        cdLocationInfo c_cdLocationInfo = new cdLocationInfo();

        userLoginInfo u_userLoginInfo = new userLoginInfo();
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
                    ViewState["SortOrder"] = "allowedTimeRange";
                    ViewState["OrderDire"] = "ASC";

                    bind(conn);
                }
            }
        }
        public void bind(string conn)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("location");
            dt.Columns.Add("allowedTimeRange");

            foreach (cdLocationInfo c in c_cdLocationInfo_BLL.queryCdLocationInfoList())
            {
                dt.Rows.Add(c.location, c.allowedTimeRange);
            }
            DataView view = dt.DefaultView;
            string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
            view.Sort = sort;
            gvw_cdglQueryList.DataSource = view;
            gvw_cdglQueryList.DataBind();

        }

        #region 分页
        protected void gvw_cdglQueryList_Sorting(object sender, GridViewSortEventArgs e)
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
            bind(conn);//todo:数据库绑定
        }
        protected void gvw_cdglQueryList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvw_cdglQueryList.PageIndex = e.NewPageIndex;
        }
        protected void gvw_cdglQueryList_PageIndexChanged(object sender, EventArgs e)
        {
            //if (txtbox_zzActName.Value != string.Empty){z_zzActivityInfo_BLL.queryZzActivityInfoList(txtbox_zzActName.Value);}
            //else{ z_zzActivityInfo_BLL.queryZzActivityInfoList();}
            c_cdLocationInfo_BLL.queryCdLocationInfoList();
            bind(conn);
        }
        protected void gvw_cdglQueryList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int i;
            for (i = 0; i < gvw_cdglQueryList.Rows.Count; i++)
            {


                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;b=this.style.color;this.style.backgroundColor='#507CD1';this.style.color='white'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;this.style.color=b");
                }
            }
            if (e.Row.RowIndex != -1)
            {
                int indexID = this.gvw_cdglQueryList.PageIndex * this.gvw_cdglQueryList.PageSize + e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = indexID.ToString();
            }
        }

    }
        #endregion
}