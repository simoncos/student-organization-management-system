using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLHMODEL.ZYGL.CDGL;
using STLHIDAL.ZYGL.CDGL;
using STLHCOMMON;
using System.Data;
using System.Data.SqlClient;

namespace STLHDAL.ZYGL.CDGL
{
    public class cdLocationInfo_DAL : cdLocationInfo_IDAL
    {
        #region 场地基本信息定义
        /// <summary>
        /// cdLocationInfo.cs中定义的属性
        /// </summary>
        private const string PARA_LOCATIONID = "@locationId";
        private const string PARA_FILLID = "@fillId";
        private const string PARA_LOCATION = "@location";
        private const string PARA_ALLOWEDTIMERANGE = "@allowedTimeRange";
        private const string PARA_FILLDATE = "@fillDate";
        private const string PARA_NUM = "@num";
        #endregion

        #region 查询场地资料列表
        public List<cdLocationInfo> queryCdLocationInfoList()
        {
            try
            {
                SqlHelper sq = new SqlHelper();
                List<cdLocationInfo> c_cdLocationInfo_list = new List<cdLocationInfo>();

                string str = "SELECT *FROM cdglLocationInfo WHERE fillDate<>'1900-1-1'";
                using (SqlDataReader dr = sq.ExecuteDataReader(str, CommandType.Text))
                {
                    while (dr.Read())
                    {
                        cdLocationInfo c_cdLocationInfo = new cdLocationInfo();

                        c_cdLocationInfo.locationId = dr["locationId"].ToString().Trim();
                        c_cdLocationInfo.fillId = dr["fillId"].ToString().Trim();
                        c_cdLocationInfo.location = dr["location"].ToString().Trim();
                        c_cdLocationInfo.allowedTimeRange = dr["allowedTimeRange"].ToString().Trim();
                        //c_cdLocationInfo.num = Convert.ToByte(dr["num"].ToString().Trim());
                        c_cdLocationInfo.fillDate = Convert.ToDateTime(dr["fillDate"].ToString().Trim());

                        c_cdLocationInfo_list.Add(c_cdLocationInfo);
                    }
                    dr.Close();
                    return c_cdLocationInfo_list;
                }
            }
            catch (System.Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }
        }
        #endregion

        #region 更新场地资料
        /// <summary>
        /// 更新场地资料
        /// </summary>
        /// <param name="c_cdLocationInfo">场地当前资料</param>
        /// <returns>是否更改成功</returns>
        public int updateCdLocationInfo(cdLocationInfo c_cdLocationInfo)
        {
            SqlParameter[] param = new SqlParameter[]
            {

                //new SqlParameter(PARA_LOCATIONID,c_cdLocationInfo.locationId),
                new SqlParameter(PARA_FILLID,c_cdLocationInfo.fillId),
                new SqlParameter(PARA_LOCATION,c_cdLocationInfo.location),
                new SqlParameter(PARA_ALLOWEDTIMERANGE, c_cdLocationInfo.allowedTimeRange),
                //new SqlParameter(PARA_NUM,c_cdLocationInfo.num)
                new SqlParameter(PARA_FILLDATE,c_cdLocationInfo.fillDate)
            };

            string str = "INSERT INTO cdglLocationInfo(location,allowedTimeRange,fillId,fillDate) VALUES( @location,@allowedTimeRange,@fillId,@fillDate)";
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

        #region 删除列表中场地信息中记录
        /// <summary>
        /// 删除列表中的场地信息
        /// </summary>
        /// <param name="location">场地信息名</param>
        /// <returns>影响数据库行数</returns>
        public int deleteCdLocationInfo(string location)
        {       
            cdLocationInfo c_cdLocationInfo = new cdLocationInfo();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter(PARA_LOCATION,c_cdLocationInfo.location)
            };
            string str ="delete from cdglLocationInfo where location='" + location + "'";
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
