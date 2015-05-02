using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLHMODEL.STJS.STCL;
using STLHIDAL.STJS.STCL;
using STLHCOMMON;
using System.Data;
using System.Data.SqlClient;

namespace STLHDAL.STJS.STCL
{
    /// <summary>
    /// 社团申请修改意见
    /// </summary>
    public class afailInfo_DAL:afailInfo_IDAL
    {
        #region 社团申请修改意见参数数组

        /// <summary>
        /// 在afailInfo中定义了这些属性
        /// </summary>
        private const string PARA_PRESIDENTID = "@presidentId";
        private const string PARA_AMENDMENTS = "@amendments";
        private const string PARA_OPINIORID = "@opiniorId";
        private const string PARA_OPINIONDATE = "@opinionDate";

        private const string PARA_FEE = "@fee";
        private const string PARA_APPLYDATE = "@applyDate";
        private const string PARA_STSTATES = "@stStates";

        #endregion



        #region 添加社团申请修改意见

        /// <summary>
        /// 添加社团申请修改意见
        /// </summary>
        /// <param name="a_afailInfo">社团申请修改意见信息</param>
        /// <returns>数据库受影响行数0错1对</returns>
        public int addAfaildInfo(afailInfo a_afailInfo, applyInfo a_applyInfo)
        {

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter(PARA_PRESIDENTID,a_afailInfo.presidentId),
                new SqlParameter(PARA_AMENDMENTS,a_afailInfo.amendments),
                new SqlParameter(PARA_OPINIORID,a_afailInfo.opiniorId),
                new SqlParameter(PARA_OPINIONDATE,a_afailInfo.opinionDate),
                new SqlParameter(PARA_FEE,a_applyInfo.fee),
                new SqlParameter(PARA_APPLYDATE,a_applyInfo.applyDate),
                new SqlParameter(PARA_STSTATES,a_applyInfo.stStates)
                       
            };
            try
            {
                SqlHelper sq = new SqlHelper();
                int dr = sq.ExecuteNonQuery("p_stclExam", param, CommandType.StoredProcedure);
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
                throw;
            }
            
            
        }
        #endregion

        #region 通过社长(会长)学号获取修改意见列表
        /// <summary>
        /// 通过社长(会长)学号获取修改意见列表
        /// </summary>
        /// <param name="UserId">社长(会长)学号</param>
        /// <returns>返回社团申请修改意见列表</returns>
        public IList<afailInfo> getAfailInfoList(string UserId)
        {
            try
            {
                SqlHelper sq = new SqlHelper();
                List<afailInfo> a_afailInfo_list = new List<afailInfo>();
                SqlParameter[] param=new SqlParameter[]
                {
                    new SqlParameter(PARA_PRESIDENTID,UserId)
                };
                string str = "select amendments,opiniorId,opinionDate,opiniorName from View_stclAmendments where presidentId=@presidentId order by opinionDate desc";
                using (SqlDataReader dr = sq.ExecuteDataReader(str, param,CommandType.Text))
                {
                    while (dr.Read())
                    {
                        afailInfo a_afailInfo = new afailInfo();
                        a_afailInfo.amendments = dr["amendments"].ToString().Trim();
                        a_afailInfo.opiniorId = dr["opiniorId"].ToString().Trim();


                        DateTime Flag = Convert.ToDateTime("1900-1-1");
                        string opinionDateFlag = dr["opinionDate"].ToString().Trim();
                        if (opinionDateFlag == "")
                        {
                            a_afailInfo.opinionDate = Flag;
                        }
                        else
                        {
                            a_afailInfo.opinionDate = Convert.ToDateTime(dr["opinionDate"].ToString().Trim());
                        }
                        a_afailInfo.opiniorName = dr["opiniorName"].ToString().Trim();
                        a_afailInfo_list.Add(a_afailInfo);
                    }

                    dr.Close();
                    return a_afailInfo_list;
                }
            }
            catch (System.Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }    
        }

        #endregion

        #region   通过学号获取修改意见信息（审核修改意见时间）
        ///<summary>
        /// 通过会长学号获取修改意见信息（审核修改意见时间）
        ///</summary>
        ///<param name="UserId">社长(会长)学号</param>
        /// <returns>返回修改意见信息或null</returns>
        public afailInfo getAfailInfo(string presidentId)
        {

            afailInfo a_afailInfo = new afailInfo();
            string str = "select * from View_stclAmendments where presidentId=@presidentId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter(PARA_PRESIDENTID,presidentId)
            };
            try
            {
                SqlHelper sq = new SqlHelper();
                SqlDataReader dr = sq.ExecuteDataReader(str, param, CommandType.Text);
                if (dr.Read())
                {
                    DateTime Flag = Convert.ToDateTime("1900-1-1");
                    string opinionDateFlag = dr["opinionDate"].ToString().Trim();
                    if (opinionDateFlag == "")
                    {
                        a_afailInfo.opinionDate = Flag;
                    }
                    else
                    {
                        a_afailInfo.opinionDate = Convert.ToDateTime(dr["opinionDate"].ToString().Trim());
                    }

                    return a_afailInfo;

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

        //todo:#region apply页面中用来更改opinionDate的状态
        //public int updateOpinionDate() { }

        //#endregion
    }
    
}