using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLHIDAL.LOGIN;
using STLHDAL.LOGIN;
using STLHMODEL.LOGIN;
using STLHCOMMON;

namespace STLHBLL.LOGIN
{
    public class userLoginInfo_BLL
    {
        #region 用户登录信息接口引用类
        /// <summary>
        /// 用户登录信息接口引用类
        /// </summary>
        userLoginInfo_IDAL u_userLoginInfo_DAL = new userLoginInfo_DAL();
        #endregion



        /// <summary>
        /// 检查用户登录信息
        /// </summary>
        /// <param name="LoginId">用户名</param>
        /// <param name="LoginPwd">密码</param>
        /// <returns>错误信息 无错误返回:true</returns>
        public string CheckUserLogin(string stuId, string stuPwd, out userLoginInfo u_userLoginInfo)//out 关键字，必须在函数内对其赋值。通过方法操作后，把最后的值赋给 out 后面的变量
        {
            u_userLoginInfo = u_userLoginInfo_DAL.getLoginInfoByLoginId(stuId);
            if (u_userLoginInfo == null)
            {
                return "用户名不存在！！！";
            }
            else if (u_userLoginInfo.stuPwd != EncryptHandler.MD5Encrypts(stuPwd)) 
            {
                return "用户密码错误";
            }
            else
            {
                return "true";
            }
        }

    }
}
