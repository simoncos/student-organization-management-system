//********************************************************
//新增日期: 2012.12.2
//作 者: LX
//內容概述:绑定数据源，实现分页，增加正反排序,鼠标移过行变色，编号
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

using System.Security.Cryptography;
namespace STLHWEB.SLWL.DWJL
{
    public partial class dwjlActExamineList : System.Web.UI.Page
    {
        public static string bobPrivateKey;
        public static string bobPublicKey;
        string conn = ConfigurationManager.AppSettings["STLHDBConnectionString"];
        jlBasicInfo_BLL j_jlBasicInfo_BLL = new jlBasicInfo_BLL();
        jlBasicInfo j_jlBasicInfo = new jlBasicInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                bobPrivateKey = rsa.ToXmlString(true);
                bobPublicKey = rsa.ToXmlString(false);

                //加载页面时候即调用数据源
                ViewState["SortOrder"] = "sljlDate";
                ViewState["OrderDire"] = "ASC";

                bind(conn);
            }
        }
        public void bind(string conn)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("sljlId");
            dt.Columns.Add("sljlName");
            dt.Columns.Add("inviter");
            dt.Columns.Add("invited");
            dt.Columns.Add("sljlDate");
            dt.Columns.Add("responsName");

            //j_jlBasicInfo_BLL.queryJlActivityInfoList(j_jlBasicInfo);
            foreach (jlBasicInfo j in j_jlBasicInfo_BLL.queryJlActivityInfoList("正常进行"))
            {
                dt.Rows.Add(j.sljlId,j.sljlName, j.inviter, j.invited, j.sljlDate, j.responsName);
            }

            DataView view = dt.DefaultView;
            string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
            view.Sort = sort;
            gvw_dwjlActExamineList.DataSource = view;
            gvw_dwjlActExamineList.DataBind();
        }
        #region 分页
        protected void gvw_dwjlActExamineList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvw_dwjlActExamineList.PageIndex = e.NewPageIndex;
        }
        protected void gvw_dwjlActExamineList_PageIndexChanged(object sender, EventArgs e)
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
            j_jlBasicInfo_BLL.queryJlActivityInfoList(j_jlBasicInfo);
            bind(conn);
        }
        #endregion
        protected void gvw_dwjlActExamineList_Sorting(object sender, GridViewSortEventArgs e)
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
        protected void gvw_dwjlActExamineList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int i;
            for (i = 0; i < gvw_dwjlActExamineList.Rows.Count; i++)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;b=this.style.color;this.style.backgroundColor='#507CD1';this.style.color='white'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;this.style.color=b");
                }
            }
            if (e.Row.RowIndex != -1)
            {
                int indexID = this.gvw_dwjlActExamineList.PageIndex * this.gvw_dwjlActExamineList.PageSize + e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = indexID.ToString();
            }
        }
    }
}