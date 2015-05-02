using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLHMODEL.SLWL.ZZGL;
using STLHIDAL.SLWL.ZZGL;
using STLHCOMMON;
using System.Data;
using System.Data.SqlClient;

namespace STLHDAL.SLWL.ZZGL
{
    public class zzSponsorInfo_DAL : zzSponsorInfo_IDAL
    {
        #region 赞助商信息参数数组

        /// <summary>
        /// 在zzSponsorInfo.cs中定义了这些属性
        /// </summary>
        private const string PARA_SPONSORID = "@sponsorId";
        private const string PARA_FILLID = "@fillId";
        private const string PARA_SPONSORNAME = "@sponsorName";
        private const string PARA_LEADERNAME = "@leaderName";
        private const string PARA_LEADERPOSITION = "@leaderPosition";
        private const string PARA_LEADERTEL = "@leaderTel";
        private const string PARA_CONTACTNAME = "@contactName";
        private const string PARA_CONTACTPOSITION = "@contactPosition";
        private const string PARA_CONTACTTEL = "@contactTel";
        private const string PARA_STATUS = "status";
        private const string PARA_FILLDATE = "@fillDate";
        private const string PARA_FILLNAME = "@fillName";
        private const string PARA_NUM = "@num";

        #endregion


        #region 更新赞助商信息列表

        /// <summary>
        /// 更新赞助商信息列表
        /// </summary>
        /// <param name="z_zzSponsorInfoList">赞助商当前列表</param>
        /// <returns>影响数据库的行数</returns>
        public int updateZzSponsorInfo(zzSponsorInfo z_zzSponsorInfo)
        {
            //foreach (zzSponsorInfo z_zzSponsorInfo in z_zzSponsorInfo)
            //{
                SqlParameter[] param = new SqlParameter[]
                 {
                     new SqlParameter(PARA_SPONSORNAME,z_zzSponsorInfo.sponsorName),
                     new SqlParameter(PARA_FILLID,z_zzSponsorInfo.fillId),
                     new SqlParameter(PARA_LEADERNAME,z_zzSponsorInfo.leaderName),
                     new SqlParameter(PARA_LEADERPOSITION,z_zzSponsorInfo.leaderPosition),
                     new SqlParameter(PARA_LEADERTEL,z_zzSponsorInfo.leaderTel),
                     new SqlParameter(PARA_CONTACTNAME,z_zzSponsorInfo.contactName),
                     new SqlParameter(PARA_CONTACTPOSITION,z_zzSponsorInfo.contactPosition),
                     new SqlParameter(PARA_CONTACTTEL,z_zzSponsorInfo.contactTel),
                     new SqlParameter(PARA_STATUS,z_zzSponsorInfo.status),
                     new SqlParameter(PARA_FILLDATE,z_zzSponsorInfo.fillDate),
                 };
                try
                {
                    SqlHelper sq = new SqlHelper();
                    int dr = sq.ExecuteNonQuery("p_slzzSponsorList_update", param, CommandType.StoredProcedure);

                    if (dr <= 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                catch (System.Exception ex)
                {
                    ErrorHandler.WriteError(ex);
                    throw ex;
                }
        }
        #endregion

        #region 按状态查询赞助商信息列表
        /// <summary>
        /// 按状态查询赞助商信息列表,一般只显示“正常”状态的记录
        /// </summary>
        /// <returns>赞助商信息结果集</returns>
        public IList<zzSponsorInfo> queryZzSponsorInfo(string status)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter(PARA_STATUS,status)
            };

            try
            {
                SqlHelper sq = new SqlHelper();
                List<zzSponsorInfo> z_zzSponsorInfo_list = new List<zzSponsorInfo>();
                string str = "select * from View_slzzSponsorList where status=@status";
                using (SqlDataReader dr = sq.ExecuteDataReader(str, param, CommandType.Text))
                {
                    while (dr.Read())
                    {
                        zzSponsorInfo z_zzSponsorInfo = new zzSponsorInfo();

                        z_zzSponsorInfo.sponsorName = dr["sponsorName"].ToString().Trim();
                        z_zzSponsorInfo.leaderName = dr["leaderName"].ToString().Trim();
                        z_zzSponsorInfo.leaderPosition = dr["leaderPosition"].ToString().Trim();
                        z_zzSponsorInfo.leaderTel = dr["leaderTel"].ToString().Trim();
                        z_zzSponsorInfo.contactName = dr["contactName"].ToString().Trim();
                        z_zzSponsorInfo.contactPosition = dr["contactPosition"].ToString().Trim();
                        z_zzSponsorInfo.contactTel = dr["contactTel"].ToString().Trim();
                        z_zzSponsorInfo.fillDate = Convert.ToDateTime(dr["fillDate"].ToString().Trim());
                        z_zzSponsorInfo_list.Add(z_zzSponsorInfo);
                    }

                    dr.Close();
                    return z_zzSponsorInfo_list;
                }
            }
            catch (System.Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }


        }
        #endregion



        #region 删除赞助商信息列表中记录

        /// <summary>
        /// 删除赞助商信息列表中记录
        /// </summary>
        /// <param name="z_zzSponsorInfoList">赞助商当前列表</param>
        /// <returns>影响数据库的行数</returns>
        public int deleteZzSponsorInfo(string sponsorName)
        {
            zzSponsorInfo z_zzSponsorInfo = new zzSponsorInfo();
            SqlParameter[] param = new SqlParameter[]
                 {
                     new SqlParameter(PARA_SPONSORNAME,z_zzSponsorInfo.sponsorName)
                 };
            string str = "delete from slzzSponsorInfo where sponsorName= '" + sponsorName + "'";
            //string str = "delete from slzzSponsorInfo where sponsorName=@sponsorName";
            try
            {
                SqlHelper sq = new SqlHelper();
                int dr = sq.ExecuteNonQuery(str, param, CommandType.Text);

                if (dr > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (System.Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw ex;
            }
        }
        #endregion
    }
}