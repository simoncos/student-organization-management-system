using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using STLHCOMMON;
using STLHMODEL.SLWL.DWJL;
using STLHIDAL.SLWL.DWJL;

namespace STLHDAL.SLWL.DWJL
{
    public class jlParticipators_DAL:jlParticipators_IDAL
    {
        #region 对外交流人员信息定义
        /// <summary>
        /// jlParticipators.cs中定义的属性
        /// </summary>
        private const string PARA_SLJLID = "@sljlId";
        private const string PARA_PARTICIPATORID = "@participatorId";
        private const string PARA_PARTICIPATORNAME = "@participatorName";
        private const string PARA_PARTICIPATORTEL = "@participatorTel";
        private const string PARA_FILLID = "@fillId";
        private const string PARA_FILLNAME = "@fillName";
        private const string PARA_FILLDATE = "@fillDate";
        #endregion


        #region 添加对外交流人员信息
        /// <summary>
        /// 添加对外交流人员信息
        /// </summary>
        /// <param name="j_jlParticipators">对外交流人员信息</param>
        /// <returns>数据库受影响行数0错1对-1异常</returns>
        public int insertJlParticipators(jlParticipators j_jlParticipators)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter(PARA_SLJLID,j_jlParticipators.sljlId),
                new SqlParameter(PARA_PARTICIPATORID,j_jlParticipators.participatorId),
                new SqlParameter(PARA_FILLDATE,j_jlParticipators.fillDate)
            };
            try
            {
                SqlHelper sq = new SqlHelper();
              
                
                string strSelect = "select * from sljlParticipators where sljlId=@sljlId and participatorId=@participatorId";
                       SqlDataReader drSelect = sq.ExecuteDataReader(strSelect, param, CommandType.Text);
                if (drSelect.HasRows)
                {
                    return 1;
                }
                else
                {
                    drSelect.Close();
                    SqlHelper sq1 = new SqlHelper();
                    string str = @"insert into sljlParticipators(sljlId,participatorId,fillDate)
                values(@sljlId,@participatorId,@fillDate)";
                    int dr = sq1.ExecuteNonQuery(str, param, CommandType.Text);
                    if (dr > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                
          
               
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw ex;
            }
        }
        #endregion

        #region 删除对外交流人员信息
        /// <summary>
        /// 删除对外交流人员信息
        /// </summary>
        /// <param name="j_jlParticipators">对外交流人员信息</param>
        /// <returns>返回数据库受影响行数0错1对-1异常</returns>
        public int deleteJlParticipators(string participatorId, string sljlId)
        {
            jlParticipators j_jlParticipators = new jlParticipators();
            SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter(PARA_PARTICIPATORID,j_jlParticipators.participatorId),
                        new SqlParameter(PARA_SLJLID,j_jlParticipators.sljlId)
                };
            string str = "delete from sljlParticipators where participatorId='"+participatorId+"'and sljlId='"+sljlId+"'";
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
                throw;
            }
        }
        #endregion

        #region 通过标识号查询对外交流人员基本信息
        /// <summary>
        /// 通过标识号查询对外交流人员基本信息
        /// </summary>
        /// <param name="sljlId">对外交流活动标识号</param>
        /// <returns>对外交流人员信息</returns>
        public IList<jlParticipators> queryJlParticipators(string sljlId)
        {
            try
            {
                SqlHelper sq = new SqlHelper();
                List<jlParticipators> j_jlParticipators_list = new List<jlParticipators>();
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter(PARA_SLJLID,sljlId)
                };
                string str = "select * from View_sljlActParticipator where sljlId=@sljlId";
                using (SqlDataReader dr = sq.ExecuteDataReader(str, param, CommandType.Text))
                {
                    while (dr.Read())
                    {
                        jlParticipators j_jlParticipators = new jlParticipators();
                        //j_jlParticipators.sljlId = dr["sljlId"].ToString().Trim();
                        j_jlParticipators.participatorId = dr["participatorId"].ToString().Trim();
                        j_jlParticipators.participatorName = dr["stuName"].ToString().Trim();
                        j_jlParticipators.participatorGender=dr["stuGender"].ToString().Trim();
                        j_jlParticipators.fillDate = Convert.ToDateTime(dr["fillDate"].ToString().Trim());
                        j_jlParticipators_list.Add(j_jlParticipators);
                    }
                    dr.Close();
                    return j_jlParticipators_list;
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
