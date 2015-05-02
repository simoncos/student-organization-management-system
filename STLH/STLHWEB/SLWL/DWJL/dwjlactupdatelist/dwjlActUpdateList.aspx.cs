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
using STLHCOMMON;
namespace STLHWEB.SLWL.DWJL
{
    public partial class dwjlActUpdateList : System.Web.UI.Page
    {
        string conn = ConfigurationManager.AppSettings["STLHDBConnectionString"];
        jlBasicInfo_BLL j_jlBasicInfo_BLL = new jlBasicInfo_BLL();
        jlBasicInfo j_jlBasicInfoSelect = new jlBasicInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtbox_activityName4.Focus();
            j_jlBasicInfoSelect.sljlName = txtbox_activityName4.Value;
            j_jlBasicInfoSelect.inviter = txtbox_sponsor4.Value;
            j_jlBasicInfoSelect.invited = txtbox_invitee4.Value;

            if (!IsPostBack)
            {
                //加载页面时候即调用数据源
                ViewState["SortOrder"] = "sljlDate";
                ViewState["OrderDire"] = "ASC";

                bind(conn);
            }
        }
        public void btn_query_onclick(object sender, EventArgs e)
        {
            //j_jlBasicInfo_BLL.queryJlActivityInfoList(j_jlBasicInfo);
            bind(conn);
        }
        public void bind(string conn)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("sljlId");
            dt.Columns.Add("sljlName");
            dt.Columns.Add("inviter");
            dt.Columns.Add("invited");
            dt.Columns.Add("sljlDate");
            dt.Columns.Add("status");

            //j_jlBasicInfo_BLL.queryJlActivityInfoList(j_jlBasicInfo);
            foreach (jlBasicInfo j in j_jlBasicInfo_BLL.queryJlActivityInfoList(j_jlBasicInfoSelect))
            {
                dt.Rows.Add(j.sljlId,j.sljlName, j.inviter, j.invited, j.sljlDate, j.status);
            }

            /*if (j_jlBasicInfo.sljlName!=string.Empty || j_jlBasicInfo.inviter!=string.Empty || j_jlBasicInfo.invited!=string.Empty)
            //if (j_jlBasicInfo != null)
            { 
                        j_jlBasicInfo_BLL.queryJlActivityInfoList(j_jlBasicInfo);
                        foreach (jlBasicInfo j in j_jlBasicInfo_BLL.queryJlActivityInfoList(j_jlBasicInfo))
                        {
                            dt.Rows.Add(j.sljlName, j.inviter, j.invited, j.sljlDate, j.status);
                        }
             }
            else 
            {
                        j_jlBasicInfo_BLL.queryJlActivityInfoList();
                        foreach (jlBasicInfo j in j_jlBasicInfo_BLL.queryJlActivityInfoList())
                        {
                            dt.Rows.Add(j.sljlName, j.inviter, j.invited, j.sljlDate, j.status);
                        }
            }
            */

            DataView view = dt.DefaultView;
            string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
            view.Sort = sort;
            gvw_dwjlQuerry.DataSource = view;
            gvw_dwjlQuerry.DataBind();
        }
        #region 分页
        protected void gvw_dwjlQuerry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvw_dwjlQuerry.PageIndex = e.NewPageIndex;
        }
        protected void gvw_dwjlQuerry_PageIndexChanged(object sender, EventArgs e)
        {
            /*
            if (j_jlBasicInfo != null) 
            { 
                j_jlBasicInfo_BLL.queryJlActivityInfoList(j_jlBasicInfo);
                //this.contrlRepeater();
            }
            else 
            {
                j_jlBasicInfo_BLL.queryJlActivityInfoList();
                //this.contrlRepeater();
            }
             */
            j_jlBasicInfo_BLL.queryJlActivityInfoList(j_jlBasicInfoSelect);
            bind(conn);
        }
        #endregion
        #region 正反排序
        protected void gvw_dwjlQuerry_Sorting(object sender, GridViewSortEventArgs e)
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
        #endregion
        #region 移动变色 自动编号
        protected void gvw_dwjlQuerry_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int i;
            for (i = 0; i < gvw_dwjlQuerry.Rows.Count; i++)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;b=this.style.color;this.style.backgroundColor='#507CD1';this.style.color='white'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;this.style.color=b");
                }
                try
                {
                    string gvw_status = gvw_dwjlQuerry.Rows[i].Cells[6].Text.ToString().Trim();
                    if (gvw_status == "活动结束" || gvw_status == "活动取消")
                    { 
                        gvw_dwjlQuerry.Rows[i].Cells[7].Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    ErrorHandler.WriteError(ex);
                    throw;
                }
                
            }
            if (e.Row.RowIndex != -1)
            {
                int indexID = this.gvw_dwjlQuerry.PageIndex * this.gvw_dwjlQuerry.PageSize + e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = indexID.ToString();
            }
        }
#endregion



        protected void add_Click(object sender, EventArgs e)
        {
            //Response.Redirect("./dwjlActFillIn.aspx");
            Server.Transfer("/SLWL/DWJL/dwjlfillin/dwjlActFillIn.aspx");
        }
    }
}