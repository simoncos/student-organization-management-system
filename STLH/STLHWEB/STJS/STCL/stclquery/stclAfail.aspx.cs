using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using STLHBLL.STJS.STCL;
using STLHMODEL.STJS.STCL;
using STLHMODEL.LOGIN;
using STLHCOMMON;
using STLHWEB.App_Code;
using FrameWork;

namespace STLHWEB.STJS.STCL
{
    public partial class stclAfail : System.Web.UI.Page
    {
        string userStuId = UserData.GetUserDate.U_LoginName.Trim();
        afailInfo_BLL a_afailInfo_BLL = new afailInfo_BLL();
        //public afailInfo a_afailInfo = new afailInfo();
        /// <summary>
        /// 载入社团审核的修改意见列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            try
            {
                commonClass comcls = new commonClass();
                IList<afailInfo> a_afailInfo_list = new List<afailInfo>();

                a_afailInfo_list = a_afailInfo_BLL.getAfailInfoList(userStuId);//通过会长学号提取数据库中的社团修改意见列表
                if (a_afailInfo_list.Count != 0)
                {
                    for (int i = 0; i < a_afailInfo_list.Count; i++)
                    {
                        a_afailInfo_list[i].amendments = comcls.inHtml(a_afailInfo_list[i].amendments);
                    }


                    stcl_Afail.DataSource = a_afailInfo_list;
                    stcl_Afail.DataKeyField = "opinionDate";//注意字段的选取
                    stcl_Afail.DataBind();//数据绑定
                }
            }
            catch (System.Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }


        }
    }
}