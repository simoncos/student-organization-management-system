using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLHIDAL.LOGIN;
using STLHMODEL.LOGIN;
using System.Data.SqlClient;
using System.Data;
using STLHCOMMON;

namespace STLHDAL.LOGIN
{
    /// <summary>
    /// 用户登录信息类
    /// </summary>
    public class userLoginInfo_DAL:userLoginInfo_IDAL
    {
        /// <summary>
        /// 定义关于登录信息的sql语句及参数数组，在userLoginInfo.cs中定义了相关属性
        /// </summary>
        private const string str = "select * from View_userLogin where stuId=@stuId";
        private const string PARA_LOGINID = "@stuId";
        /// <summary>
        /// 根据用户ID返回用户登录信息
        /// </summary>
        /// <param name="stuId">用户ID</param>
        /// <returns>用户登录信息</returns>
        public userLoginInfo getLoginInfoByLoginId(string stuId)
        {
            userLoginInfo u_useLoginInfo = new userLoginInfo();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter(PARA_LOGINID, stuId)
            };

            try
            {
                SqlHelper sq = new SqlHelper();
                SqlDataReader dr = sq.ExecuteDataReader(str, param, CommandType.Text);
                if (dr.Read())
                {
                    u_useLoginInfo.stuId = dr["stuId"].ToString().Trim();
                    u_useLoginInfo.stuName = dr["stuName"].ToString().Trim();
                    u_useLoginInfo.stuPwd = dr["stuPwd"].ToString().Trim();
                    u_useLoginInfo.stuRole = dr["stuRole"].ToString().Trim();
                    return u_useLoginInfo;
                }
                else
                {
                    return null;
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
