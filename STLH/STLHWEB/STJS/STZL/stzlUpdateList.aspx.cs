using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using STLHBLL.STJS.STZL;
using STLHMODEL.STJS.STZL;
using STLHWEB.STJS.STZL;
using STLHMODEL.LOGIN;
using STLHCOMMON;

namespace STLHWEB.STJS.STZL
{
    public partial class stzlUpdateList : System.Web.UI.Page
    {
        string conn = ConfigurationManager.AppSettings["STLHDBConnectionString"];
        stBasicInfo_BLL s_stBasicInfo_BLL = new stBasicInfo_BLL();
        stQueryInfo s_stBasicInfoSelect = new stQueryInfo();
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

                    //加载页面时候即调用数据源
                    ViewState["SortOrder"] = "applyDate";
                    ViewState["OrderDire"] = "ASC";
                    bind(conn);
                }
            }
        }

        public void bind(string conn)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("stId");
            dt.Columns.Add("stName");
            dt.Columns.Add("stType");
            dt.Columns.Add("presidentName");
            dt.Columns.Add("applyDate");

            foreach (stQueryInfo s in s_stBasicInfo_BLL.queryStBasicInfoList())
            {
                dt.Rows.Add(s.stId, s.stName, s.stType, s.presidentName, s.applyDate);
            }

            DataView view = dt.DefaultView;
            string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
            view.Sort = sort;
            gvw_stzlUpdateList.DataSource = view;
            gvw_stzlUpdateList.DataBind();
        }

        protected void gvw_stzlUpdateList_Sorting(object sender, GridViewSortEventArgs e)
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
    }
}