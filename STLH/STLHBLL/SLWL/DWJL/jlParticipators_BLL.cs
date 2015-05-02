using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLHCOMMON;
using STLHMODEL.SLWL.DWJL;
using STLHIDAL.SLWL.DWJL;
using STLHDAL.SLWL.DWJL;

namespace STLHBLL.SLWL.DWJL
{
    /// <summary>
    /// 对外交流参与人员
    /// </summary>
    public class jlParticipators_BLL
    {

        #region 对外交流参与人员基本接口定义
        jlParticipators_IDAL j_jlParticipators_DAL = new jlParticipators_DAL();
        #endregion

        #region 添加对外交流人员信息
        /// <summary>
        /// 添加对外交流人员信息
        /// </summary>
        /// <param name="j_jlParticipators">对外交流人员信息</param>
        /// <returns>数据库受影响行数0错1对-1异常</returns>
        public bool insertJlParticipators(jlParticipators j_jlParticipators)
        {
            int result;
            result = j_jlParticipators_DAL.insertJlParticipators(j_jlParticipators);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 删除对外交流人员信息
        /// <summary>
        /// 删除对外交流人员信息
        /// </summary>
        /// <param name="j_jlParticipators">对外交流人员信息</param>
        /// <returns>数据库受影响行数0错1对-1异常</returns>
        public bool deleteJlParticipators(string participatorId, string sljlId)
        {
            int result;
            result = j_jlParticipators_DAL.deleteJlParticipators(participatorId, sljlId);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
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
            IList<jlParticipators> j_jlParticipators_list =new List<jlParticipators>();
            j_jlParticipators_list = j_jlParticipators_DAL.queryJlParticipators(sljlId);
            if (j_jlParticipators_list == null)
            {
                return null;
            }
            else
            {
                return j_jlParticipators_list;
            }
        }
        #endregion

    }
}
