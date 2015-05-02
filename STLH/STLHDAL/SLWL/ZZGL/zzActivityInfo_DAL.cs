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
    public class zzActivityInfo_DAL : zzActivityInfo_IDAL
    {
        #region 赞助活动信息参数数组
        /// <summary>
        /// 在zzActivityInfo.cs中定义了这些数组
        /// </summary>
       
        //private const string PARA_SLZZNUM = "@slzzNum";

        private const string PARA_SLZZID = "@slzzId";
        private const string PARA_SPONSORNAME = "@sponsorName";
        private const string PARA_SPONSORID = "@sponsorId";
        private const string PARA_RESPONSID = "@responsId";
        private const string PARA_RESPONSNAME = "@responsName";
        private const string PARA_FILLID = "@fillId";
        private const string PARA_FILLNAME = "@fillName";
        private const string PARA_SPONSORTYPE = "@sponsorType";
        private const string PARA_LOCATION = "@location";
        private const string PARA_RESERTIMERANGE = "@reserTimeRange";
        private const string PARA_BUDGETAMOUNT = "@budgetAmount";
        private const string PARA_ACTUALTIME = "@actualTime";
        private const string PARA_ACTUALAMOUNT = "@actualAmount";
        private const string PARA_STATUS = "@status";
        private const string PARA_FILLDATE = "@fillDate";

        #endregion


        #region 添加赞助活动信息

        /// <summary>
        /// 添加赞助活动信息
        /// </summary>
        /// <param name="z_zzActivityInfo">赞助活动信息</param>
        /// <returns>数据库受影响行数0错1对-1异常</returns>
        public int insertZzActivityInfo(zzActivityInfo z_zzActivityInfo)
        {
            SqlParameter[] param = new SqlParameter[]
            {

                new SqlParameter(PARA_SPONSORNAME,z_zzActivityInfo.sponsorName),
                new SqlParameter(PARA_SPONSORID,z_zzActivityInfo.sponsorId),
                new SqlParameter(PARA_RESPONSID,z_zzActivityInfo.responsId),
                new SqlParameter(PARA_FILLID,z_zzActivityInfo.fillId),
                new SqlParameter(PARA_SPONSORTYPE,z_zzActivityInfo.sponsorType),
                new SqlParameter(PARA_LOCATION,z_zzActivityInfo.location),
                new SqlParameter(PARA_RESERTIMERANGE,z_zzActivityInfo.reserTimeRange),
                new SqlParameter(PARA_BUDGETAMOUNT,z_zzActivityInfo.budgetAmount),
                new SqlParameter(PARA_ACTUALTIME,z_zzActivityInfo.actualTime),
                new SqlParameter(PARA_ACTUALAMOUNT,z_zzActivityInfo.actualAmount),
                new SqlParameter(PARA_STATUS,z_zzActivityInfo.status),
                new SqlParameter(PARA_FILLDATE,z_zzActivityInfo.fillDate)
            };
            try
            {
                SqlHelper sq = new SqlHelper();
                int dr = sq.ExecuteNonQuery("p_slzzActivityInfo_update", param,CommandType.StoredProcedure);
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

        #region 更新赞助活动信息
        /// <summary>
        /// 更新赞助活动信息
        /// </summary>
        /// <param name="z_zzSponsorInfo">赞助活动当前信息</param>
        /// <returns>是否更改成功</returns>
        public int updateActivityInfo(zzActivityInfo z_zzActivityInfo)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter(PARA_SLZZID,z_zzActivityInfo.slzzId),
                new SqlParameter(PARA_SPONSORNAME,z_zzActivityInfo.sponsorName),
                new SqlParameter(PARA_SPONSORID,z_zzActivityInfo.sponsorId),
                new SqlParameter(PARA_RESPONSID,z_zzActivityInfo.responsId),
                new SqlParameter(PARA_FILLID,z_zzActivityInfo.fillId),
                new SqlParameter(PARA_SPONSORTYPE,z_zzActivityInfo.sponsorType),
                new SqlParameter(PARA_LOCATION,z_zzActivityInfo.location),
                new SqlParameter(PARA_RESERTIMERANGE,z_zzActivityInfo.reserTimeRange),
                new SqlParameter(PARA_BUDGETAMOUNT,z_zzActivityInfo.budgetAmount),
                new SqlParameter(PARA_ACTUALTIME,z_zzActivityInfo.actualTime),
                new SqlParameter(PARA_ACTUALAMOUNT,z_zzActivityInfo.actualAmount),
                new SqlParameter(PARA_STATUS,z_zzActivityInfo.status),
                new SqlParameter(PARA_FILLDATE,z_zzActivityInfo.fillDate)//todo:todo:负责人ID还是Name
            };
            string str = @"UPDATE slzzActivityInfo 
SET fillId='" + z_zzActivityInfo.fillId + "'" + ",sponsorType=" + "'" + z_zzActivityInfo.sponsorType + "'" + ",status=" + "'" + z_zzActivityInfo.status + "'" + ",reserTimeRange=" + "'" + z_zzActivityInfo.reserTimeRange + "'" + ",budgetAmount=" + "'" + z_zzActivityInfo.budgetAmount + "'" + ",actualTime=" + "'" + z_zzActivityInfo.actualTime + "'" + ",actualAmount=" + "'" + z_zzActivityInfo.actualAmount + "'" + ",responsId=" + "'" + z_zzActivityInfo.responsId + "'" + ",fillDate=" + "'" + z_zzActivityInfo.fillDate + "'" + " WHERE slzzId=" + "'" + z_zzActivityInfo.slzzId + "'" + ";" + "UPDATE cdglLocationInfo SET fillId='" + z_zzActivityInfo.fillId + ",location=" + "'" + z_zzActivityInfo.location + ",fillDate=" + "'" + z_zzActivityInfo.fillDate + "'";

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

        #region 只更新赞助活动中状态信息
        /// <summary>
        /// 只更新赞助活动中状态信息
        /// </summary>
        /// <param name="z_zzSponsorInfo">赞助活动当前信息</param>
        /// <returns>影响数据库的行数</returns>
        public int updateStatusInfo(string status, string slzzId)
        {
            zzActivityInfo z_zzActivityInfo = new zzActivityInfo();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter(PARA_STATUS,z_zzActivityInfo.status),
                new SqlParameter(PARA_SLZZID,z_zzActivityInfo.slzzId)//填写时间是由数据库服务器自己生成？绑定getdate()
            };
            string str = @"UPDATE slzzActivityInfo 
                              SET status=" + "'" + status+ "'" + "WHERE slzzId=" + "'" + slzzId + "'";//todo:必须使用 + "'" + slzzId + "'"，使用slzzId=@slzzId";不行。。。
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

        
        
        #region 查询赞助活动列表，已无用
        /// <summary>
        /// 查询赞助活动列表,供一般查询使用
        /// </summary>
        /// <returns>返回查询结果集</returns>
        public List<zzActivityInfo> queryZzActivityInfoList()  
        {

            try
            {
                SqlHelper sq = new SqlHelper();
                List<zzActivityInfo> z_zzActivityInfo_list = new List<zzActivityInfo>();
                string str = "select * from View_slzzActList";

                using(SqlDataReader dr = sq.ExecuteDataReader(str, CommandType.Text))
                {
                    while (dr.Read())
                    {
                        zzActivityInfo z_zzActivityInfo = new zzActivityInfo();
                        z_zzActivityInfo.sponsorName = dr["sponsorName"].ToString().Trim();
                        z_zzActivityInfo.sponsorType = dr["sponsorType"].ToString().Trim();
                        z_zzActivityInfo.responsName = dr["responsName"].ToString().Trim();
                        z_zzActivityInfo.status = dr["status"].ToString().Trim();
                        z_zzActivityInfo.fillDate = timeForm.foreTimeToDb(dr["fillDate"].ToString().Trim());
                        z_zzActivityInfo.slzzId = dr["slzzId"].ToString().Trim();
                        z_zzActivityInfo_list.Add(z_zzActivityInfo);
                    }
                    dr.Close();
                    return z_zzActivityInfo_list;
                }
            }
            catch (System.Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }
        }
        #endregion 

        #region 按标识号查询赞助活动详细信息
        /// <summary>
        /// 按标识号查询赞助活动详细信息，实现从列表到详细信息页面
        /// </summary>
        /// <param name="status">赞助活动标识号</param>
        /// <returns>查询结果</returns>
        public zzActivityInfo queryZzActivityInfoDetail(string slzzId)
        {
            zzActivityInfo z_zzActivityInfo = new zzActivityInfo();
            //Guid g = Guid.Parse(slzzId);
            //string gs = g.ToString();
            //System.Guid g = new Guid(slzzId);
            //slzzId = g.ToString("D");

            string str = "select * from View_slzzActDetail where slzzId=" + "'" + slzzId + "'";//todo:string 与uniqueIdentifier的转换
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter(PARA_SLZZID,slzzId)
            };
            try
            {
                SqlHelper sq=new SqlHelper();
                SqlDataReader dr=sq.ExecuteDataReader(str, param, CommandType.Text);
                if(dr.Read())
                {
                    //z_zzActivityInfo.slzzNum=slzzNum;
                    z_zzActivityInfo.slzzId = slzzId;
                    //z_zzActivityInfo.slzzId = dr["slzzId"].ToString().Trim();
                    z_zzActivityInfo.fillId = dr["fillId"].ToString().Trim();
                    z_zzActivityInfo.fillName=dr["fillName"].ToString().Trim();
                    z_zzActivityInfo.sponsorId = dr["sponsorId"].ToString().Trim();
                    z_zzActivityInfo.sponsorName = dr["sponsorName"].ToString().Trim();
                    z_zzActivityInfo.responsId = dr["responsId"].ToString().Trim();
                    z_zzActivityInfo.responsName=dr["responsName"].ToString().Trim();
                    z_zzActivityInfo.sponsorType=dr["sponsorType"].ToString().Trim();
                    z_zzActivityInfo.location=dr["location"].ToString().Trim();
                    z_zzActivityInfo.reserTimeRange = dr["reserTimeRange"].ToString().Trim();
                    z_zzActivityInfo.status=dr["status"].ToString().Trim();
                    z_zzActivityInfo.budgetAmount = timeForm.foreIntToDb(dr["budgetAmount"].ToString().Trim());

                    z_zzActivityInfo.actualAmount = timeForm.foreIntToDb(dr["actualAmount"].ToString().Trim());
                    z_zzActivityInfo.fillDate = timeForm.foreTimeToDb(dr["fillDate"].ToString().Trim());
                    z_zzActivityInfo.actualTime = timeForm.foreTimeToDb(dr["actualTime"].ToString().Trim());
                    return z_zzActivityInfo;
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
        #endregion

        #region 按状态查询待审核列表
        /// <summary>
        /// 按状态查询赞助活动列表
        /// </summary>
        /// <param name="status">赞助活动状态</param>
        /// <returns>查询结果集</returns>
        public List<zzActivityInfo> queryZzActivityInfoList(string status)
        {

            try
            {
                
                SqlHelper sq = new SqlHelper();
                List<zzActivityInfo> z_zzActivityInfo_list = new List<zzActivityInfo>();
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter(PARA_STATUS,status)
                };
               
                string str = "select * from View_slzzActList where status=" + "'" + status + "'";
                using (SqlDataReader dr = sq.ExecuteDataReader(str, param, CommandType.Text))
                {
                    while (dr.Read())
                    {
                        zzActivityInfo z_zzActivityInfo = new zzActivityInfo();
                        z_zzActivityInfo.slzzId = dr["slzzId"].ToString().Trim();
                        z_zzActivityInfo.sponsorName = dr["sponsorName"].ToString().Trim();
                        z_zzActivityInfo.sponsorType = dr["sponsorType"].ToString().Trim();
              
                        
                        z_zzActivityInfo.responsName = dr["responsName"].ToString().Trim();
                        
                        DateTime Flag = Convert.ToDateTime("1753-01-01");
                        string fillDateFlag1 = dr["fillDate"].ToString().Trim();
                        if (fillDateFlag1 == "")
                        {
                            fillDateFlag1 = "1753-01-01";
                            z_zzActivityInfo.fillDate = Convert.ToDateTime(fillDateFlag1);
                        }
                        else
                        {
                            z_zzActivityInfo.fillDate = Convert.ToDateTime(dr["fillDate"].ToString().Trim());
                        }

                        z_zzActivityInfo.reserTimeRange = dr["reserTimeRange"].ToString().Trim();

                        z_zzActivityInfo_list.Add(z_zzActivityInfo);

                        
                    }
                    dr.Close();
                    return z_zzActivityInfo_list;
                }
            }
            catch (System.Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }
        }
        #endregion

        #region 按多条件（赞助商）查询赞助活动列表，返回查询结果。切词待完善
        /// <summary>
        /// 按多条件查询赞助活动列表
        /// </summary>
        /// <param name="z_zzActivityInfoSelect">赞助活动信息查询条件</param>
        /// <returns>查询结果集</returns>
        public List<zzActivityInfo> queryZzActivityInfoList(zzActivityInfo z_zzActivityInfoSelect)
        {
            try
            {
                SqlHelper sq = new SqlHelper();
                List<zzActivityInfo> z_zzActivityInfo_list = new List<zzActivityInfo>();
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter(PARA_SPONSORNAME,z_zzActivityInfoSelect.sponsorName)
                };
                string str = "select * from View_slzzActList where sponsorName like ('%' + @sponsorName + '%')";//切词？AJAX？

              
                    using (SqlDataReader dr = sq.ExecuteDataReader(str, param, CommandType.Text))
                    {
                        while (dr.Read())
                        {
                            zzActivityInfo z_zzActivityInfo = new zzActivityInfo();
                            z_zzActivityInfo.slzzId = dr["slzzId"].ToString().Trim();
                            z_zzActivityInfo.sponsorName = dr["sponsorName"].ToString().Trim();
                            z_zzActivityInfo.sponsorType = dr["sponsorType"].ToString().Trim();
                            z_zzActivityInfo.responsName = dr["responsName"].ToString().Trim();
                            z_zzActivityInfo.status = dr["status"].ToString().Trim();
                            z_zzActivityInfo.fillDate = Convert.ToDateTime(dr["fillDate"].ToString().Trim());
                            z_zzActivityInfo_list.Add(z_zzActivityInfo);
                        }
                        dr.Close();
                        return z_zzActivityInfo_list;
                    }
   
            }
            catch (System.Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }
        }
        #endregion

        #region 按多条件（联合主键）查询赞助活动列表，查看有无记录。
        /// <summary>
        /// 按多条件查询赞助活动列表
        /// </summary>
        /// <param name="z_zzActivityInfoSearch">赞助活动信息查询条件</param>
        /// <returns>slzzId</returns>
        public string SearchZzActivityInfoList(zzActivityInfo z_zzActivityInfoSearch)
        {

            try
            {

                SqlHelper sq = new SqlHelper();
                List<zzActivityInfo> z_zzActivityInfo_list = new List<zzActivityInfo>();

                SqlParameter[] param = new SqlParameter[]
                {
                new SqlParameter(PARA_SPONSORNAME,z_zzActivityInfoSearch.sponsorName),
                new SqlParameter(PARA_SPONSORTYPE,z_zzActivityInfoSearch.sponsorType),
                new SqlParameter(PARA_RESERTIMERANGE,z_zzActivityInfoSearch.reserTimeRange),
                new SqlParameter(PARA_RESPONSNAME,z_zzActivityInfoSearch.responsName)
                };
                string str = "select * from View_slzzActList where sponsorName=" + "'" + z_zzActivityInfoSearch.sponsorName + "'" + " and sponsorType= " + "'" + z_zzActivityInfoSearch.sponsorType + "'" + "and reserTimeRange=" + "'" + z_zzActivityInfoSearch.reserTimeRange + "'" + " and responsName= " + "'" + z_zzActivityInfoSearch.responsName + "'" + "";
             
                    using (SqlDataReader dr = sq.ExecuteDataReader(str, param, CommandType.Text))
                    {
                        while (dr.Read())
                        {
                            zzActivityInfo z_zzActivityInfo = new zzActivityInfo();

                            z_zzActivityInfo.slzzId = dr["slzzId"].ToString().Trim();
                            z_zzActivityInfo_list.Add(z_zzActivityInfo);
                        }
                        dr.Close();
                        if (z_zzActivityInfo_list.Count <= 0) { return null; }
                        else
                        {
                            return z_zzActivityInfo_list[0].slzzId.ToString().Trim();
                        }
                    }
         
            }
            catch (System.Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }
            }
        #endregion

        }
    } 

