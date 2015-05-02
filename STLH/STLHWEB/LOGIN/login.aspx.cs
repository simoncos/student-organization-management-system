﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using STLHCOMMON;
using STLHCOMMON.Enum;
using FrameWork;
using FrameWork.Components;
using System.Collections;

namespace STLHWEB.LOGIN
{
    public partial class login : System.Web.UI.Page
    {
        public string FrameName;
        public string FrameNameVer;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                //清除在线用户
                FrameWorkOnline.Instance().ClearOnlineUserTimeOut();
            }

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (sLoginName != UserData.GetUserDate.U_LoginName||sLoginName=="")
                {

                } 
                else
                {
                    int usertype = UserData.GetUserDate.U_Type;
                    if (usertype == 0 || usertype == 2)
                    {
                        HttpContext.Current.Response.Redirect("/Manager/default.aspx");
                    }
                    else
                    {
                        HttpContext.Current.Response.Redirect("/HOMEPAGE/personalCenter.aspx");
                    }
                }
                
                
            }
            FrameName = FrameSystemInfo.GetSystemInfoTable.S_Name;
            FrameNameVer = FrameSystemInfo.GetSystemInfoTable.S_Version;

            //Button1.Attributes.Add("Onclick", "javascript:return checkForm(ctl00);");
            string CMD = (string)Common.sink("CMD", MethodType.Get, 255, 0, DataType.Str);
            if (CMD == "OutOnline")
            {
                string U_LoginName = (string)Common.sink("U_LoginName", MethodType.Get, 20, 1, DataType.Str);
                string U_Password = (string)Common.sink("U_Password", MethodType.Get, 50, 1, DataType.Str);
                string OPCode = (string)Common.sink("OPCode", MethodType.Get, 4, 4, DataType.Str);

                MessageBox MBx = new MessageBox();
                MBx.M_Type = 2;
                MBx.M_Title = "强制下线！";
                MBx.M_IconType = Icon_Type.Error;
                MBx.M_Body = "强制下线失败.验证码无效，请确认您输入的验证码有效！";


                //if (Session["CheckCode"] == null || OPCode.ToLower() != Session["CheckCode"].ToString())
                //{
                //    MBx.M_ButtonList.Add(new sys_NavigationUrl("返回", "login.aspx", "点击按钮重新输入验证码！", UrlType.Href, true));
                //}
                //else
                //{
                    QueryParam qp = new QueryParam();
                    qp.Where = string.Format(" Where U_StatUs=0 and  U_LoginName='{0}' and U_Password='{1}'", Common.inSQL(U_LoginName), Common.inSQL(Common.md5(U_Password, 32)));
                    int iInt = 0;
                    ArrayList lst = BusinessFacade.sys_UserList(qp, out iInt);
                    if (iInt > 0)
                    {
                        //FrameWorkPermission.UserOnlineList.RemoveUserName(U_LoginName.ToLower());
                        string sessionid = (string)Common.sink("SessionID", MethodType.Get, 24, 0, DataType.Str);
                        FrameWorkOnline.Instance().OnlineRemove(sessionid);
                        MBx.M_IconType = Icon_Type.OK;
                        MBx.M_Body = string.Format("强制帐号{0}下线成功！", U_LoginName);
                        //写入强制帐号下线日志
                        EventMessage.EventWriteDB(2, MBx.M_Body, ((sys_UserTable)lst[0]).UserID);
                        LoginUser(U_LoginName, U_Password, UserKey);
                        //MBx.M_ButtonList.Add(new sys_NavigationUrl("返回", "login.aspx", "", UrlType.Href, true));
                        //设置用户为登陆状态

                    }
                    else
                    {
                        MBx.M_Body = "强制下线失败.用户名/密码无效！";
                        MBx.M_ButtonList.Add(new sys_NavigationUrl("返回", "/LOGIN/login.aspx", "", UrlType.Href, true));
                    }

                //}
                Session["CheckCode"] = Common.RndNum(4);
                EventMessage.MessageBox(MBx);


            }

            //if (!DispCode)
            //{
            //    Logincode_op.Src = "images/Logon/Logon_7no.gif";
            //    inputcode_op.Visible = false;
            //}


        }

        /// <summary>
        /// 是否显示验证码(出错6次,出现验证码)
        /// </summary>
        private bool DispCode
        {
            get
            {
                if (FrameWorkLogin.GetLoginUserError(UserKey) > 5)
                    return true;
                else
                    return false;
            }
        }

        protected void login_commit_onclick(object sender, EventArgs e)
        {
            //LoginUser(sLoginName, sLoginPass, sCode_op, UserKey);
            LoginUser(sLoginName, sLoginPass,UserKey);
        }

        /// <summary>
        /// 进行登陆操作
        /// </summary>
        /// <param name="sLoginName">用户名</param>
        /// <param name="sLoginPass">密码</param>
        /// <param name="sCode_op">验证码</param>
        /// <param name="UserKey">用户key</param>
        private void LoginUser(string sLoginName, string sLoginPass,  string UserKey)
        {
            MessageBox MBx = new MessageBox();
            MBx.M_Type = 2;
            MBx.M_Title = "登陆出错！";
            MBx.M_IconType = Icon_Type.Error;
            MBx.M_Body = "验证码无效，请确认您输入的验证码有效！";

            if (DispCode && (Session["CheckCode"] == null))//|| sCode_op != Session["CheckCode"].ToString()
            {
                MBx.M_WriteToDB = false;
                MBx.M_ButtonList.Add(new sys_NavigationUrl("返回", "/LOGIN/login.aspx", "点击按钮重新输入验证码！", UrlType.Href, true));
            }
            else if (!FrameWorkLogin.CheckDisableLoginUser(UserKey))
            {
                MBx.M_Body = string.Format("当前IP:{0}登陆出错次数({1})超过系统允许,已经禁止登陆.请联系管理员！", Common.GetIPAddress(), FrameSystemInfo.GetSystemInfoTable.S_SystemConfigData.C_LoginErrorMaxNum);
                MBx.M_ButtonList.Add(new sys_NavigationUrl("返回", "/LOGIN/login.aspx", "点击按钮返回！", UrlType.Href, true));

            }
            else if (new FrameWorkLogin().CheckLogin(sLoginName, sLoginPass, UserKey))
            {
                MBx.M_IconType = Icon_Type.OK;
                MBx.M_Title = "登陆成功！";
                MBx.M_Body = string.Format("欢迎您{0}，成功登入。您的IP为：{1}！", sLoginName, Common.GetIPAddress());
                MBx.M_WriteToDB = false;
                //MBx.M_ButtonList.Add(new sys_NavigationUrl("确定", "/HOMEPAGE/personalCenter.aspx", "点击按钮登陆！", UrlType.Href, true));//default.aspx
                FrameWorkLogin.MoveErrorLoginUser(UserKey);
                //写登入日志
                EventMessage.EventWriteDB(2, MBx.M_Body, UserData.Get_sys_UserTable(sLoginName).UserID);
                int usertype = UserData.Get_sys_UserTable(sLoginName).U_Type;
                if (usertype == 0 || usertype == 2)
                {
                    HttpContext.Current.Response.Redirect("/Manager/default.aspx");
                }
                else
                {
                    HttpContext.Current.Response.Redirect("/HOMEPAGE/personalCenter.aspx");
                }
            }
            else
            {
                MBx.M_Body = string.Format("用户名/密码({0}/{1})错误！", sLoginName, sLoginPass);
                MBx.M_ButtonList.Add(new sys_NavigationUrl("返回", "/LOGIN/login.aspx", "点击按钮重新输入！", UrlType.Href, true));
                EventMessage.MessageBox(MBx);
            }
            //Session["CheckCode"] = Common.RndNum(4);
            
        }

        /// <summary>
        /// 获得用户登陆Key(根据IP)
        /// </summary>
        string UserKey
        {
            get
            {
                return Common.GetIPAddress().Replace(".", "_");
            }
        }
        string sLoginName
        {
            get
            {
                return this.loginstuId.Value.Trim();
            }
        }
        /// <summary>
        /// 32位用户加密md5
        /// </summary>
        string sLoginPass
        {
            get
            {
                return this.loginPwd.Value.Trim();
            }
        }
        //string sCode_op
        //{
        //    get
        //    {
        //        return this.code_op.Text.Trim();
        //    }
        //}

    }
}