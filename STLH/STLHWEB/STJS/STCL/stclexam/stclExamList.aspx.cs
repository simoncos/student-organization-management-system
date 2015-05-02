//********************************************************
//新增日期: 2013.3.10
//作 者: LX
//內容概述:绑定数据源（只显示状态为待审核的记录），实现分页，增加正反排序,鼠标移过行变色，编号，实现审核信息的跳转，
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
using STLHBLL.STJS.STCL;
using STLHMODEL.STJS.STCL;
using STLHMODEL.LOGIN;
using STLHCOMMON;
using System.IO;
using System.Security.Cryptography;
using STLHWEB.App_Code;
using FrameWork;

namespace STLHWEB.STJS.STCL
{
    public partial class stclExamList : System.Web.UI.Page
    {
        string conn = ConfigurationManager.AppSettings["STLHDBConnectionString"];
        applyInfo_BLL a_applyInfo_BLL = new applyInfo_BLL();
        applyInfo a_applyInfo = new applyInfo();
        string userStuId = UserData.GetUserDate.U_LoginName.Trim();
        public static string bobPrivateKey;
        public static string bobPublicKey;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                    bobPrivateKey = rsa.ToXmlString(true);
                    bobPublicKey = rsa.ToXmlString(false);

                    userStuId = UserData.GetUserDate.U_LoginName.Trim();
                    //加载页面时候即调用数据源
                    //ViewState["SortOrder"] = "sljlDate";
                    ViewState["SortOrder"] = "applyDate";
                    ViewState["Orde1rDire"] = "ASC";

                    bind(conn);
            }

        }
        public void bind(string conn)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("presidentId");
            dt.Columns.Add("stName");
            dt.Columns.Add("stuName");
            dt.Columns.Add("stuTel");
            dt.Columns.Add("applyDate");



            //z_zzActivityInfo_BLL.queryZzActivityInfoList(z_zzActivityInfo);
            foreach (applyInfo a in a_applyInfo_BLL.queryExamListInfo())
            {
                dt.Rows.Add(HttpUtility.UrlEncode(EncryptHandler.AsymmectricEncrypts(a.presidentId, bobPublicKey)), a.stName, a.stuName, a.stuTel, a.applyDate);
            }
            DataView view = dt.DefaultView;
            string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
            view.Sort = sort;//用以排序的应是fillDate
            gvw_stclExamList.DataSource = view;
            gvw_stclExamList.DataBind();
        }


        #region 分页
        protected void gvw_stclExamList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvw_stclExamList.PageIndex = e.NewPageIndex;
        }
        protected void gvw_stclExamList_PageIndexChanged(object sender, EventArgs e)
        {
            //if (txtbox_zzActName.Value != string.Empty){z_zzActivityInfo_BLL.queryZzActivityInfoList(txtbox_zzActName.Value);}
            //else{ z_zzActivityInfo_BLL.queryZzActivityInfoList();}
            a_applyInfo_BLL.queryExamListInfo();
            bind(conn);
        }
        #endregion

        protected void gvw_stclExamList_Sorting(object sender, GridViewSortEventArgs e)
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
        protected void gvw_stclExamList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int i;
            for (i = 0; i < gvw_stclExamList.Rows.Count; i++)
            {


                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;b=this.style.color;this.style.backgroundColor='#507CD1';this.style.color='white'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;this.style.color=b");
                }
            }
            if (e.Row.RowIndex != -1)
            {
                int indexID = this.gvw_stclExamList.PageIndex * this.gvw_stclExamList.PageSize + e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = indexID.ToString();
            }
        }


    }
}