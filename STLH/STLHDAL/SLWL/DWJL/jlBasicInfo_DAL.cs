using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLHMODEL.SLWL.DWJL;
using STLHIDAL.SLWL.DWJL;
using STLHCOMMON;
using System.Data;
using System.Data.SqlClient;

namespace STLHDAL.SLWL.DWJL
{
    public class jlBasicInfo_DAL:jlBasicInfo_IDAL
    {
        #region 对外交流基本信息参数数组
        /// <summary>
        /// jlBasicInfo.cs中定义的属性
        /// </summary>
        private const string PARA_SLJLID = "@sljlId";
        private const string PARA_FILLID="@fillId";
        private const string PARA_INVITER="@inviter";
        private const string PARA_SLJLNAME="@sljlName";
        private const string PARA_SLJLDATE="@sljlDate";
        private const string PARA_SLJLLOCATION="@sljlLocation";
        private const string PARA_INVITED="@invited";
        private const string PARA_INVITEDAMOUNT="@invitedAmount";
        private const string PARA_CONTACTNAME="@contactName";
        private const string PARA_CONTACTTEL="@contactTel";
        private const string PARA_RESPONSNAME="@responsName";
        private const string PARA_RESPONSTEL="@responsTel";
        private const string PARA_STATUS="@status";
        private const string PARA_FILLDATE = "@fillDate";
        private const string PARA_PARTICIPATORID = "@participatorId";

        #endregion


        #region 添加对外交流基本信息
        /// <summary>
        /// 添加对外交流基本信息
        /// </summary>
        /// <param name="j_jlBasicInfo">对外交流基本信息</param>
        /// <returns>数据库受影响行数0错1对-1异常</returns>
        public int insertJlBasicInfo(jlBasicInfo j_jlBasicInfo)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter(PARA_SLJLID,j_jlBasicInfo.sljlId),
                new SqlParameter(PARA_FILLID,j_jlBasicInfo.fillId),
                new SqlParameter(PARA_INVITER,j_jlBasicInfo.inviter),
                new SqlParameter(PARA_SLJLNAME,j_jlBasicInfo.sljlName),
                new SqlParameter(PARA_SLJLDATE,j_jlBasicInfo.sljlDate),
                new SqlParameter(PARA_SLJLLOCATION,j_jlBasicInfo.sljlLocation),
                new SqlParameter(PARA_INVITED,j_jlBasicInfo.invited),
                new SqlParameter(PARA_INVITEDAMOUNT,j_jlBasicInfo.invitedAmount),
                new SqlParameter(PARA_CONTACTNAME,j_jlBasicInfo.contactName),
                new SqlParameter(PARA_CONTACTTEL,j_jlBasicInfo.contactTel),
                new SqlParameter(PARA_RESPONSNAME,j_jlBasicInfo.responsName),
                new SqlParameter(PARA_RESPONSTEL,j_jlBasicInfo.responsTel),
                new SqlParameter(PARA_STATUS,j_jlBasicInfo.status),
                new SqlParameter(PARA_FILLDATE,j_jlBasicInfo.fillDate)
            };
            string str = @"INSERT INTO sljlBasicInfo(fillId,inviter,invited,sljlName,sljlDate,sljlLocation,invitedAmount,contactName,contactTel,responsName,responsTel,fillDate,status)
                VALUES((select stuId from stuBasicInfo where stuId=@fillId),@inviter,@invited,@sljlName,@sljlDate,@sljlLocation,@invitedAmount,@contactName,@contactTel,@responsName,@responsTel,@fillDate,@status)";
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
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw ex;
            }
        }
        #endregion

        #region 添加对外交流参与人员信息
        /// <summary>
        /// 添加对外交流参与人员信息
        /// </summary>
        /// <param name="j_jlParticipators ">对外交流参与人员信息</param>
        /// <returns>数据库受影响行数0错1对-1异常</returns>
        public int insertJlParticipatorsInfo(jlParticipators j_jlParticipators)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter(PARA_SLJLID,j_jlParticipators.sljlId),
                new SqlParameter(PARA_FILLDATE,j_jlParticipators.fillDate),
                new SqlParameter(PARA_PARTICIPATORID,j_jlParticipators.participatorId)
            };
            string str = @"INSERT INTO sljlParticipators(sljlId,fillDate,participatorId)
                VALUE(@sljlId,@fillDate,@participatorId)";
            try
            {

                SqlHelper sq = new SqlHelper();
                int dr = sq.ExecuteNonQuery(str, param, CommandType.StoredProcedure);
                if (dr > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw ex;
            }
        }
        #endregion

        #region 更新对外交流基本信息
        /// <summary>
        /// 更新对外交流基本信息
        /// </summary>
        /// <param name="j_jlBasicInfo">对外交流基本信息</param>
        /// <returns>数据库受影响行数0错1对-1异常</returns>
        public int updateJlBasicInfo(jlBasicInfo j_jlBasicInfo)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter(PARA_SLJLID,j_jlBasicInfo.sljlId),
                new SqlParameter(PARA_FILLID,j_jlBasicInfo.fillId),
                new SqlParameter(PARA_INVITER,j_jlBasicInfo.inviter),
                new SqlParameter(PARA_SLJLNAME,j_jlBasicInfo.sljlName),
                new SqlParameter(PARA_SLJLDATE,j_jlBasicInfo.sljlDate),
                new SqlParameter(PARA_SLJLLOCATION,j_jlBasicInfo.sljlLocation),
                new SqlParameter(PARA_INVITED,j_jlBasicInfo.invited),
                new SqlParameter(PARA_INVITEDAMOUNT,j_jlBasicInfo.invitedAmount),
                new SqlParameter(PARA_CONTACTNAME,j_jlBasicInfo.contactName),
                new SqlParameter(PARA_CONTACTTEL,j_jlBasicInfo.contactTel),
                new SqlParameter(PARA_RESPONSNAME,j_jlBasicInfo.responsName),
                new SqlParameter(PARA_RESPONSTEL,j_jlBasicInfo.responsTel),
                new SqlParameter(PARA_STATUS,j_jlBasicInfo.status),
                new SqlParameter(PARA_FILLDATE,j_jlBasicInfo.fillDate)
            };
            string str = @"UPDATE sljlBasicInfo
                              SET
                                  fillId=@fillId,
                                  inviter=@inviter,
                                  sljlName=@sljlName,
                                  sljlDate=@sljlDate,
                                  sljlLocation=@sljlLocation,
                                  invited=@invited,
                                  invitedAmount=@invitedAmount,
                                  contactName=@contactName,
                                  responsName=@responsName,
                                  responsTel=@responsTel,
                                  status=@status,
                                  fillDate=@fillDate
                                 
                             WHERE sljlId=@sljlId";
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
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw ex;
            }
        }
        #endregion

        #region 对外交流活动状态更改
        /// <summary>
        /// 对外交流活动状态更改
        /// </summary>
        /// <param name="status">对外交流状态</param>
        /// <returns>数据库受影响行数0错1对-1异常</returns>
        public int statusJlBasicInfo(jlBasicInfo j_jlBasicInfo)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter(PARA_STATUS,j_jlBasicInfo.status),
                new SqlParameter(PARA_SLJLID,j_jlBasicInfo.sljlId)
            };
            try
            {
                SqlHelper sq = new SqlHelper();
                string str = "update sljlBasicInfo set status=@status where sljlId=@sljlId ";
                int dr = sq.ExecuteNonQuery(str, param, CommandType.StoredProcedure);
                if (dr > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw ex;
            }
        }
        #endregion

        #region 查询对外交流活动列表,已无用
        /// <summary>
        /// 查询对外交流活动列表,供一般查询使用
        /// </summary>
        /// <returns>查询结果集</returns>
        public List<jlBasicInfo> queryJlActivityInfoList()
        {
            try
            {
                SqlHelper sq = new SqlHelper();
                List<jlBasicInfo> j_jlBasicInfo_list = new List<jlBasicInfo>();

                string str = "select * from sljlBasicInfo";
                using (SqlDataReader dr = sq.ExecuteDataReader(str, CommandType.Text))
                {
                    while (dr.Read())
                    {
                        jlBasicInfo j_jlBasicInfo = new jlBasicInfo();
                        j_jlBasicInfo.sljlId = dr["sljlId"].ToString().Trim();
                        j_jlBasicInfo.sljlName = dr["sljlName"].ToString().Trim();
                        j_jlBasicInfo.inviter = dr["inviter"].ToString().Trim();
                        j_jlBasicInfo.invited = dr["invited"].ToString().Trim();
                        j_jlBasicInfo.sljlDate = Convert.ToDateTime(dr["sljlDate"].ToString().Trim());
                        j_jlBasicInfo.status = dr["status"].ToString().Trim();
                        j_jlBasicInfo_list.Add(j_jlBasicInfo);
                    }
                    dr.Close();
                    return j_jlBasicInfo_list;
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
        /// 按状态查询交流活动列表
        /// </summary>
        /// <param name="status">交流活动状态</param>
        /// <returns>查询结果集</returns>
        public List<jlBasicInfo> queryJlActivityInfoList(string status)
        {
            try
            {
                SqlHelper sq = new SqlHelper();
                List<jlBasicInfo> j_jlBasicInfo_list = new List<jlBasicInfo>();
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter(PARA_STATUS,status)
                };
                string str = "select * from sljlBasicInfo where status=@status";
                using (SqlDataReader dr = sq.ExecuteDataReader(str, param,CommandType.Text))
                {
                    while (dr.Read())
                    {
                        jlBasicInfo j_jlBasicInfo = new jlBasicInfo();
                        j_jlBasicInfo.sljlId = dr["sljlId"].ToString().Trim();
                        j_jlBasicInfo.sljlName = dr["sljlName"].ToString().Trim();
                        j_jlBasicInfo.inviter = dr["inviter"].ToString().Trim();
                        j_jlBasicInfo.invited = dr["invited"].ToString().Trim();
                        j_jlBasicInfo.sljlDate = Convert.ToDateTime(dr["sljlDate"].ToString().Trim());
                        j_jlBasicInfo.status = dr["status"].ToString().Trim();
                        j_jlBasicInfo.responsName = dr["responsName"].ToString().Trim();
                        j_jlBasicInfo_list.Add(j_jlBasicInfo);

                    }
                    dr.Close();
                    return j_jlBasicInfo_list;
                }
            }
            catch (System.Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }
        }
        #endregion

        #region  按多条件查询交流活动列表,切词待完善
        /// <summary>
        /// 按多条件查询交流活动列表，供条件筛选
        /// </summary>
        /// <param name="j_jlBasicInfoSelect">交流活动信息查询条件</param>
        /// <returns>查询结果集</returns>
        public List<jlBasicInfo> queryJlActivityInfoList(jlBasicInfo j_jlBasicInfoSelect)
        {
            try
            {
                SqlHelper sq = new SqlHelper();
                List<jlBasicInfo> j_jlBasicInfo_list = new List<jlBasicInfo>();
                SqlParameter[] param = new SqlParameter[]
                 { 
                     /*
                    new SqlParameter(PARA_SLJLNAME,"'%"+j_jlBasicInfoSelect.sljlName+"%'"),
                    new SqlParameter(PARA_INVITER,"'%"+j_jlBasicInfoSelect.inviter+"%'"),
                    new SqlParameter(PARA_INVITED,"'%"+j_jlBasicInfoSelect.invited+"%'")
                     */
                    new SqlParameter(PARA_SLJLNAME,j_jlBasicInfoSelect.sljlName),
                    new SqlParameter(PARA_INVITER,j_jlBasicInfoSelect.inviter),
                    new SqlParameter(PARA_INVITED,j_jlBasicInfoSelect.invited)
                 };
              
                #region 生成多条件模糊查询语句

                string select="";
                if (j_jlBasicInfoSelect.sljlName!="")
                {
                    select = " where sljlName like ('%' + @sljlName + '%')"; 
                }
                if (j_jlBasicInfoSelect.inviter != "")
                {
                    if (select=="")
                    {
                        select = " where inviter like ('%' + @inviter + '%')";
                    }
                    else
                    {
                        select += " and inviter like ('%' + @inviter + '%')";
                    }
                }
                if (j_jlBasicInfoSelect.invited != "")
                {
                    if (select == "")
                    {
                        select = " where invited like ('%' + @invited + '%')";
                    }
                    else
                    {
                        select += " and invited like ('%' + @invited + '%')";
                    }
                }

                string str = "select * from sljlBasicInfo" + select;
                #endregion
              
                using (SqlDataReader dr = sq.ExecuteDataReader(str, param, CommandType.Text))//一定要加param，对应上面的param数组
                {
                    while (dr.Read())
                    {
                        jlBasicInfo j_jlBasicInfo = new jlBasicInfo();
                        j_jlBasicInfo.sljlId = dr["sljlId"].ToString().Trim();
                        j_jlBasicInfo.inviter = dr["inviter"].ToString().Trim();
                        j_jlBasicInfo.sljlName = dr["sljlName"].ToString().Trim();
                       
                        //同理
                        j_jlBasicInfo.sljlDate = Convert.ToDateTime(dr["sljlDate"].ToString().Trim());
                       
                        j_jlBasicInfo.sljlLocation = dr["sljlLocation"].ToString().Trim();
                        j_jlBasicInfo.invited = dr["invited"].ToString().Trim();

                        //时间和数字转换必须要求从数据库提取出来的值非null,如何解决?
                        j_jlBasicInfo.invitedAmount = Convert.ToByte(dr["invitedAmount"].ToString().Trim());
                        
                        j_jlBasicInfo.contactName = dr["contactName"].ToString().Trim();
                        j_jlBasicInfo.contactTel = dr["contactTel"].ToString().Trim();
                        j_jlBasicInfo.responsName = dr["responsName"].ToString().Trim();
                        j_jlBasicInfo.responsTel = dr["responsTel"].ToString().Trim();
                        j_jlBasicInfo.status = dr["status"].ToString().Trim();
                       
                        //同理
                        j_jlBasicInfo.fillDate = Convert.ToDateTime(dr["fillDate"].ToString().Trim());
                       
                        j_jlBasicInfo_list.Add(j_jlBasicInfo);
                    }   
                    dr.Close();
                    return j_jlBasicInfo_list;
                }
            }
            catch (System.Exception ex)
            {
                ErrorHandler.WriteError(ex);
                //return new List<jlBasicInfo>();
                throw;
            }
        }
        #endregion

        #region 按多条件（联合主键）查询对外交流活动列表，查看有无记录。
        /// <summary>
        /// 按多条件（联合主键）查询对外交流活动列表
        /// </summary>
        /// <param name="z_zzActivityInfoSearch">对外交流活动信息查询条件</param>
        /// <returns>sljlName</returns>
        public string SearchSlijlActBasicInfoList(jlBasicInfo j_jlBasicInfoSearch)
        {

            try
            {

                SqlHelper sq = new SqlHelper();
                List<jlBasicInfo> j_jlBasicInfo_list = new List<jlBasicInfo>();

                SqlParameter[] param = new SqlParameter[]
                {
                 new SqlParameter(PARA_SLJLNAME,j_jlBasicInfoSearch.sljlName),
                 new SqlParameter(PARA_INVITER,j_jlBasicInfoSearch.inviter), 
                 new SqlParameter(PARA_INVITED,j_jlBasicInfoSearch.invited),
                 new SqlParameter(PARA_SLJLDATE,j_jlBasicInfoSearch.sljlDate)
                };
                string str = "select * from View_sljlActBasicInfo where sljlName=" + "'" + j_jlBasicInfoSearch.sljlName + "'and inviter= " + "'" + j_jlBasicInfoSearch.inviter + "'" + "and invited=" + "'" + j_jlBasicInfoSearch.invited + "'" + " and sljlDate= " + "'" + j_jlBasicInfoSearch.sljlDate + "'";
           
                using (SqlDataReader dr = sq.ExecuteDataReader(str, param, CommandType.Text))
                {
                    while (dr.Read())
                    {
                        jlBasicInfo j_jlBasicInfo = new jlBasicInfo();

                        j_jlBasicInfo.sljlId = dr["sljlId"].ToString().Trim();
                        j_jlBasicInfo_list.Add(j_jlBasicInfo);
                    }
                    dr.Close();
                    if (j_jlBasicInfo_list.Count <= 0) { return null; }
                    else
                    {
                        return j_jlBasicInfo_list[0].sljlId.ToString().Trim();
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

        #region 按标识号查询对外交流活动详细信息
        /// <summary>
        /// 查询对外交流活动详细信息
        /// </summary>
        /// <returns>查询结果</returns>
        public jlBasicInfo queryJlActivityInfoDetail(string sljlId)
        {
            jlBasicInfo j_jlBasicInfo = new jlBasicInfo();
            string str = "select * from View_sljlActBasicInfo where sljlId=@sljlId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter(PARA_SLJLID,sljlId)
            };
            try
            {
                SqlHelper sq = new SqlHelper();
                SqlDataReader dr=sq.ExecuteDataReader(str,param,CommandType.Text);
                if (dr.Read())
                {
                    j_jlBasicInfo.sljlId = dr["sljlId"].ToString().Trim();
                    j_jlBasicInfo.fillId = dr["fillId"].ToString().Trim();
                    j_jlBasicInfo.fillName = dr["stuName"].ToString().Trim();
                    j_jlBasicInfo.inviter = dr["inviter"].ToString().Trim();
                    j_jlBasicInfo.sljlName = dr["sljlName"].ToString().Trim();

                    DateTime Flag = Convert.ToDateTime("1900-01-01");
                    string sljlDateFlag = dr["sljlDate"].ToString().Trim();
                    if (sljlDateFlag == "")
                    {
                        j_jlBasicInfo.sljlDate = Flag;
                    }
                    else
                    {
                        j_jlBasicInfo.sljlDate = Convert.ToDateTime(sljlDateFlag);
                    }
                    j_jlBasicInfo.sljlLocation = dr["sljlLocation"].ToString().Trim();
                    j_jlBasicInfo.invited = dr["invited"].ToString().Trim();

                    string invitedAmountFlag = dr["invitedAmount"].ToString().Trim();
                    if (invitedAmountFlag == "")
                    {
                        j_jlBasicInfo.invitedAmount = 0;
                    }
                    else
                    {
                        j_jlBasicInfo.invitedAmount = Convert.ToByte(invitedAmountFlag);
                    }
                    j_jlBasicInfo.contactName = dr["contactName"].ToString().Trim();
                    j_jlBasicInfo.contactTel = dr["contactTel"].ToString().Trim();
                    j_jlBasicInfo.responsName = dr["responsName"].ToString().Trim();
                    j_jlBasicInfo.responsTel = dr["responsTel"].ToString().Trim();
                    j_jlBasicInfo.status = dr["status"].ToString().Trim();
                    string fillDateFlag = dr["fillDate"].ToString().Trim();
                    if (fillDateFlag == "")
                    {
                        j_jlBasicInfo.fillDate = Flag;
                    }
                    else
                    {
                        j_jlBasicInfo.fillDate = Convert.ToDateTime(fillDateFlag);
                    }
                  
                    return j_jlBasicInfo;
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
    }
}
