using System;
using FrameWork;
using STLHDAL.LOGIN;
using STLHMODEL.LOGIN;
namespace STLHWEB.MASTER
{
    public partial class Main1 : System.Web.UI.MasterPage
    {
        public string userName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string stuId = UserData.GetUserDate.U_LoginName.Trim();
            userLoginInfo_DAL u_userLoginInfo_DAL=new userLoginInfo_DAL();
            userLoginInfo u_userLoginInfo = u_userLoginInfo_DAL.getLoginInfoByLoginId(stuId);
            userName = u_userLoginInfo.stuName;

        }
    }
}