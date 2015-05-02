using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLHMODEL.LOGIN;

namespace STLHIDAL.LOGIN
{
    /// <summary>
    /// 用户登录信息接口
    /// </summary>
    public interface userLoginInfo_IDAL
    {
        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="LoginId">用户登录名</param>
        /// <returns>用户信息</returns>
        userLoginInfo getLoginInfoByLoginId(string stuId);
    }
}
