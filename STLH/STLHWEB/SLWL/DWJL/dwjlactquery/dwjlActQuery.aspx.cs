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

using STLHMODEL.LOGIN;
using System.IO;
using FrameWork;
namespace STLHWEB.SLWL.DWJL
{
    public partial class dwjlActQuery : System.Web.UI.Page
    {
        string conn = ConfigurationManager.AppSettings["STLHDBConnectionString"];
        jlBasicInfo j_jlBasicInfo = new jlBasicInfo();
        jlBasicInfo_BLL j_jlBasicInfo_BLL = new jlBasicInfo_BLL();
        jlParticipators j_jlParticipators = new jlParticipators();
        jlParticipators_BLL j_jlParticipators_BLL = new jlParticipators_BLL();

     
        static string sId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            
                    ViewState["SortOrder"] = "fillDate";
                    ViewState["OrderDire"] = "DESC";
                    
                    sId = Request.QueryString["ID"].ToString();
                    j_jlBasicInfo = j_jlBasicInfo_BLL.queryJlActivityInfoDetail(sId);
                    bind(conn);

                    lab_positiveListPerson2.Text = j_jlBasicInfo.fillName.ToString().Trim();
                    lab_positiveListDate2.Text = j_jlBasicInfo.fillDate.ToString().Trim();
                    lab_positiveListState2.Text = j_jlBasicInfo.status.ToString().Trim();

                    txtbox_sponsor3.Text = j_jlBasicInfo.inviter.ToString().Trim();
                    txtbox_invitee3.Text = j_jlBasicInfo.invited.ToString().Trim();
                    txtbox_activityName3.Text = j_jlBasicInfo.sljlName.ToString().Trim();

                    txtbox_activityTime3.Text = j_jlBasicInfo.sljlDate.ToString().Trim();

                    txtbox_activityPlace3.Text = j_jlBasicInfo.sljlLocation.ToString().Trim();

                    txtbox_invitedNumber3.Text = j_jlBasicInfo.invitedAmount.ToString().Trim();

                    txtbox_linkmanName3.Text = j_jlBasicInfo.contactName.ToString().Trim();
                    txtbox_linkmanPhone3.Text = j_jlBasicInfo.contactTel.ToString().Trim();
                    
                    disableControl.disableAllControl(this);
            }
        }

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
                dt.Rows.Add(j.participatorId, j.participatorName,j.participatorGender,j.fillDate);
            }

            DataView view = dt.DefaultView;
            string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
            view.Sort = sort;
            gvw_dwjlActDetailQuery.DataSource = view;
            gvw_dwjlActDetailQuery.DataBind();

        }
        #endregion

        #region gridview——分页
        protected void gvw_dwjlActDetailQuery_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvw_dwjlActDetailQuery.PageIndex = e.NewPageIndex;
        }

        protected void gvw_dwjlActDetailQuery_PageIndexChanged(object sender, EventArgs e)
        {
            j_jlParticipators_BLL.queryJlParticipators(sId);
            bind(conn);
        }
        #endregion

        #region gridview——正反排序
        protected void gvw_dwjlActDetailQuery_Sorting(object sender, GridViewSortEventArgs e)
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
        protected void gvw_dwjlActDetailQuery_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int i;
            for (i = 0; i < gvw_dwjlActDetailQuery.Rows.Count; i++)
            {


                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;b=this.style.color;this.style.backgroundColor='#507CD1';this.style.color='white'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;this.style.color=b");
                }
            }
            if (e.Row.RowIndex != -1)
            {
                int indexID = this.gvw_dwjlActDetailQuery.PageIndex * this.gvw_dwjlActDetailQuery.PageSize + e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = indexID.ToString();
            }
        }
        #endregion
    }
}