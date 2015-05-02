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
using STLHBLL.STJS.STZL;
using STLHMODEL.STJS.STZL;
using STLHWEB.STJS.STZL;
using STLHCOMMON;
using STLHMODEL.LOGIN;
using System.IO;

namespace STLHWEB.STJS.STZL
{
    public partial class stzlQueryList : System.Web.UI.Page
    {
        string conn = ConfigurationManager.AppSettings["STLHDBConnectionString"];
        stBasicInfo_BLL s_stBasicInfo_BLL = new stBasicInfo_BLL();
        stQueryInfo s_stBasicInfo = new stQueryInfo();
        
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
                    //ViewState["SortOrder"] = "sljlDate";
                    ViewState["SortOrder"] = "stType";
                    ViewState["OrderDire"] = "ASC";

                    bind(conn);
                }
            }

        }
        public void bind(string conn)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("stName");
            dt.Columns.Add("stType");
            dt.Columns.Add("star");
            dt.Columns.Add("fee");
            dt.Columns.Add("presidentName");
            dt.Columns.Add("stuTel");
            dt.Columns.Add("stuEmail");
            dt.Columns.Add("stuQQ");

            //z_zzActivityInfo_BLL.queryZzActivityInfoList(z_zzActivityInfo);
            foreach (stQueryInfo s in s_stBasicInfo_BLL.queryStBasicInfoList())
            {
                dt.Rows.Add(s.stName, s.stType, s.star, s.fee, s.presidentName, s.stuTel, s.stuEmail, s.stuQQ);
            }
            DataView view = dt.DefaultView;
            string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
            view.Sort = sort;
            gvw_stzlQueryList.DataSource = view;
            gvw_stzlQueryList.DataBind();

        }

        #region 分页
        protected void gvw_stzlQueryList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvw_stzlQueryList.PageIndex = e.NewPageIndex;
        }
        protected void gvw_stzlQueryList_PageIndexChanged(object sender, EventArgs e)
        {
            //if (txtbox_zzActName.Value != string.Empty){z_zzActivityInfo_BLL.queryZzActivityInfoList(txtbox_zzActName.Value);}
            //else{ z_zzActivityInfo_BLL.queryZzActivityInfoList();}
            s_stBasicInfo_BLL.queryStBasicInfoList();
            bind(conn);
        }
        #endregion

        protected void gvw_stzlQueryList_Sorting(object sender, GridViewSortEventArgs e)
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
        protected void gvw_stzlQueryList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int i;
            for (i = 0; i < gvw_stzlQueryList.Rows.Count; i++)
            {


                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;b=this.style.color;this.style.backgroundColor='#507CD1';this.style.color='white'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;this.style.color=b");
                }
            }
            if (e.Row.RowIndex != -1)
            {
                int indexID = this.gvw_stzlQueryList.PageIndex * this.gvw_stzlQueryList.PageSize + e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = indexID.ToString();
            }
        }
    }
}