using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using STLHMODEL.LOGIN;

public class SessionKey
{
    public const string LoginInfo = "userLoginInfo";
}

public  class SessionData
{
    /// <summary>
    /// 获取Session中的用户信息
    /// </summary>
    /// <returns></returns>
    public static userLoginInfo GetLoginInfo()
    {
        userLoginInfo u_logininfo = SessionManager<userLoginInfo>.GetSessionObject(SessionKey.LoginInfo);
        if (u_logininfo == null)
        {
            u_logininfo = new userLoginInfo();
            //把内容储存到应用程序
            SessionManager<userLoginInfo>.SetSessionObject(SessionKey.LoginInfo, u_logininfo);
        }
        return u_logininfo;
    }

    /// <summary>
    /// 设置Session中的用户信息
    /// </summary>
    /// <param name="userInfo"></param>
    public static void SetUserInfo(userLoginInfo zx_accountinfo)
    {
        SessionManager<userLoginInfo>.SetSessionObject(SessionKey.LoginInfo, zx_accountinfo);
    }

    /// <summary>
    /// 清除session
    /// </summary>
    public static void ClearUserInfo()
    {
        HttpContext.Current.Session.Abandon();
        HttpContext.Current.Session.Clear();
        FormsAuthentication.SignOut();
        //SessionManager<U_LoginInfo>.SetSessionObject(SessionKey.UserInfo, null);
    }

    /// <summary>
    /// 是否登入
    /// </summary>
    /// <returns></returns>
    public static bool IsLogin()
    {
        bool ret = false;
        userLoginInfo zx_accountinfo = SessionManager<userLoginInfo>.GetSessionObject(SessionKey.LoginInfo);
        if (zx_accountinfo != null)
            ret = true;
        return ret;
    }
}

