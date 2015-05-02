using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using STLHMODEL.LOGIN;
using STLHCOMMON;

namespace STLHWEB.USERCTRL
{
    public partial class mainMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SessionData.IsLogin())
                {
                    userLoginInfo u_userLoginInfo = SessionData.GetLoginInfo();
                    lab_userName.Text = "姓名:" + u_userLoginInfo.stuName.ToString().Trim();
                    lab_userNum.Text = "学号：" + u_userLoginInfo.stuId.ToString().Trim();
                }
            }
            
            

        }
    }
}