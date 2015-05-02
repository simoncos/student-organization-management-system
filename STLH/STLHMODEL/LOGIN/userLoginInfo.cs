using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STLHMODEL.LOGIN
{
    /// <summary>
    /// 用户登录信息
    /// </summary>
    [Serializable]
    public class userLoginInfo
    {
        public userLoginInfo()
        {
            stuId = "";
            stuName = "";
            stuPwd = "";
            stuRole = "";
        }
        /// <summary>
        /// 学生ID
        /// </summary>
        public string stuId { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string stuName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string stuPwd { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        public string stuRole { get; set; }

    }
}
