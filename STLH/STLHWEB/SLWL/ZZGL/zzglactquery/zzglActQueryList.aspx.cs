//********************************************************
//新增日期: 2012.12.2
//作 者: LX
//內容概述:绑定数据源，实现分页，增加正反排序,鼠标移过行变色，编号，根据输入检索信息(按多条件查询赞助活动列表)，获得详细信息，实现不同权限进入不同页面
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
using STLHBLL.SLWL.ZZGL;
using STLHMODEL.SLWL.ZZGL;
using STLHWEB.SLWL.ZZGL;
using STLHMODEL.LOGIN;
using System.IO;
using STLHCOMMON;
namespace STLHWEB.SLWL.ZZGL
{
    public partial class zzglActQueryList : System.Web.UI.Page
    {   
        string conn = ConfigurationManager.AppSettings["STLHDBConnectionString"];
        zzActivityInfo_BLL z_zzActivityInfo_BLL = new zzActivityInfo_BLL();
        zzActivityInfo z_zzActivityInfoSelect = new zzActivityInfo(); 
      

        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtbox_zzActName.Focus();
            z_zzActivityInfoSelect.sponsorName = txtbox_zzActName.Value;


            if (!IsPostBack)
            {
            
                    ;

                    ViewState["SortOrder"] = "fillDate";
                    ViewState["OrderDire"] = "ASC";

                    bind(conn);
                }
           

        }

        public void btn_query_onclick(object sender, EventArgs e)
        {
            //z_zzActivityInfo_BLL.queryZzActivityInfoList(z_zzActivityInfo);
            bind(conn);
        }
        
        public void bind(string conn)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("slzzId");
            dt.Columns.Add("sponsorName");
            dt.Columns.Add("sponsorType");
            dt.Columns.Add("reserTimeRange");
            dt.Columns.Add("responsName");
            dt.Columns.Add("status");
            dt.Columns.Add("fillDate");
            

            //z_zzActivityInfo_BLL.queryZzActivityInfoList(z_zzActivityInfo);
            foreach (zzActivityInfo z in z_zzActivityInfo_BLL.queryZzActivityInfoList(z_zzActivityInfoSelect))
            {
                dt.Rows.Add(z.slzzId, z.sponsorName, z.sponsorType, z.reserTimeRange, z.responsName, z.status, z.fillDate);
            }


            DataView view = dt.DefaultView; 
            string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
            view.Sort = sort;
            gvw_zzglQuery.DataSource = view;
            gvw_zzglQuery.DataBind();
        }

        #region 分页
        protected void gvw_zzglQuery_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvw_zzglQuery.PageIndex = e.NewPageIndex;
        }
        protected void gvw_zzglQuery_PageIndexChanged(object sender, EventArgs e)
        {
            //if (txtbox_zzActName.Value != string.Empty){z_zzActivityInfo_BLL.queryZzActivityInfoList(txtbox_zzActName.Value);}
            //else{ z_zzActivityInfo_BLL.queryZzActivityInfoList();}
            z_zzActivityInfo_BLL.queryZzActivityInfoList(z_zzActivityInfoSelect);
            bind(conn);
        }
        #endregion

        protected void gvw_zzglQuery_Sorting(object sender, GridViewSortEventArgs e)
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
        protected void gvw_zzglQuery_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int i;
            for (i = 0; i < gvw_zzglQuery.Rows.Count;i++ ) 
            {
                if(e.Row.RowType==DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;b=this.style.color;this.style.backgroundColor='#507CD1';this.style.color='white'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;this.style.color=b");
                }
            }
            if (e.Row.RowIndex != -1)
            {
                int indexID = this.gvw_zzglQuery.PageIndex * this.gvw_zzglQuery.PageSize + e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = indexID.ToString();
            }
        }
    }
    }
