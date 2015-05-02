using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLHMODEL.STJS.STZL;
using STLHIDAL.STJS.STZL;
using STLHCOMMON;
using System.Data;
using System.Data.SqlClient;

namespace STLHDAL.STJS.STZL
{
    public class stBasicInfo_DAL:stBasicInfo_IDAL
    {
        #region 社团基本信息定义
        /// <summary>
        /// stBasicInfo.cs中定义的属性
        /// </summary>
        private const string PARA_STID = "@stId";
        private const string PARA_STNAME = "@stName";
        private const string PARA_STAR = "@star";
        private const string PARA_TOPTEN = "@topTen";
        private const string PARA_PRESIDENTID = "@presidentId";
        private const string PARA_PRESIDENTNAME = "@presidentName";
        private const string PARA_STUTEL = "@stuTel";
        private const string PARA_STUDORMITORY = "@stuDormitory";
        private const string PARA_STUEMAIL = "@stuEmail";
        private const string PARA_POSITIVEID = "@positiveId";
        private const string PARA_STTYPE = "@stType";
        private const string PARA_GUIDETEACHER = "@guideTeacher";
        private const string PARA_GUIDEUNIT = "@guideUnit";
        private const string PARA_FEE = "@fee";
        private const string PARA_APPLYDATE = "@applyDate";
        private const string PARA_POSITIVEDATE = "@positiveDate";
        #endregion

        #region 查询社团资料列表
        /// <summary>
        /// 查询社团资料列表
        /// </summary>
        /// <returns>社团资料列表</returns>
        public List<stQueryInfo> queryStBasicInfoList()
        {
            try
            {
                SqlHelper sq = new SqlHelper();
                List<stQueryInfo> s_stBasicInfo_list = new List<stQueryInfo>();

                string str = "SELECT * FROM View_stzlInfo WHERE applyDate<>'1900-1-1' AND positiveDate<>'1900-1-1'";
                using (SqlDataReader dr = sq.ExecuteDataReader(str, CommandType.Text))
                {
                    while (dr.Read())
                    {
                        stQueryInfo s_stBasicInfo = new stQueryInfo();

                        s_stBasicInfo.stId = dr["stId"].ToString().Trim();
                        s_stBasicInfo.stName = dr["stName"].ToString().Trim();
                        s_stBasicInfo.stType = dr["stType"].ToString().Trim();
                        s_stBasicInfo.star = Convert.ToByte(dr["star"].ToString().Trim()); 
                        s_stBasicInfo.topTen=dr["topTen"].ToString().Trim();
                        s_stBasicInfo.fee = Convert.ToByte(dr["fee"].ToString().Trim()); 
                        s_stBasicInfo.presidentName = dr["presidentName"].ToString().Trim();
                        s_stBasicInfo.stuTel=dr["stuTel"].ToString().Trim();
                        s_stBasicInfo.stuEmail = dr["stuEmail"].ToString().Trim();
                        s_stBasicInfo.stuQQ = dr["stuQQ"].ToString().Trim();
                        s_stBasicInfo.guideUnit = dr["guideUnit"].ToString().Trim();
                        s_stBasicInfo.guideTeacher = dr["guideTeacher"].ToString().Trim();
                        
/*                        s_stBasicInfo.applyDate = Convert.ToDateTime(dr["applyDate"].ToString().Trim());*/
                        //须要此句不？

                        s_stBasicInfo_list.Add(s_stBasicInfo);
                    }
                    dr.Close();
                    return s_stBasicInfo_list;
                }
            }
            catch (System.Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }
        }
        #endregion

        #region 更新社团资料
        /// <summary>
        /// 更新社团资料
        /// </summary>
        /// <param name="z_zzSponsorInfo">社团当前资料</param>
        /// <returns>是否更改成功</returns>
        public int updateStBasicInfo(stQueryInfo s_stBasicInfo)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter(PARA_STID,s_stBasicInfo.stId),
                new SqlParameter(PARA_STNAME,s_stBasicInfo.stName),
                new SqlParameter(PARA_STAR,s_stBasicInfo.star),
                new SqlParameter(PARA_TOPTEN,s_stBasicInfo.topTen),
                new SqlParameter(PARA_STTYPE,s_stBasicInfo.stType),
                new SqlParameter(PARA_FEE,s_stBasicInfo.fee),
                new SqlParameter(PARA_PRESIDENTID,s_stBasicInfo.presidentId),            
                new SqlParameter(PARA_GUIDETEACHER,s_stBasicInfo.guideTeacher),
                new SqlParameter(PARA_GUIDEUNIT,s_stBasicInfo.guideUnit)
            };
            string str = @"UPDATE stBasicInfo 
                                  SET stName=" + "'" + s_stBasicInfo.stName + "'" + ",star=" + "'" + s_stBasicInfo.star + "'" + 
                                  ",star=" + "'" + s_stBasicInfo.star + "'" +",stType=" + "'" +s_stBasicInfo.stType + "'" + 
                                  ",fee=" + "'" + s_stBasicInfo.fee + "'" +",presidentId=" + "'" + s_stBasicInfo.presidentId + "'" + 
                                  ",guideTeacher=" + "'" + s_stBasicInfo.guideTeacher + "'" +",guideUnit=" + "'" + s_stBasicInfo.guideUnit+ "'"+ 
                                  " WHERE stId=" + "'" + s_stBasicInfo.stId + "'";//星级十佳不在stBasicInfo表里，可能得用存储过程
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
