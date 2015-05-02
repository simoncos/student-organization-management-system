using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLHDAL.STJS.STZL;
using STLHIDAL.STJS.STZL;
using STLHMODEL.STJS.STZL;
using STLHCOMMON;

namespace STLHBLL.STJS.STZL
{
    public class stBasicInfo_BLL
    {
        #region 社团基本信息接口定义
        stBasicInfo_IDAL s_stBasicInfo_DAL = new stBasicInfo_DAL();
        #endregion

        #region 显示社团基本信息表
        /// <summary>
        /// 列出社团基本信息表
        /// </summary>
        /// <returns>社团基本信息表</returns>
        public List<stQueryInfo> queryStBasicInfoList()
        {
            List<stQueryInfo> s_stBasicInfo_list = new List<stQueryInfo>();
            s_stBasicInfo_list = s_stBasicInfo_DAL.queryStBasicInfoList();
            if (s_stBasicInfo_list == null)
                return null;
            else return s_stBasicInfo_list;
        }
        #endregion

        #region 更新社团基本信息
        /// <summary>
        /// 更新社团基本信息
        /// </summary>
        /// <param name="z_zzSponsorInfo">赞助活动当前信息</param>
        /// <returns>影响数据库的行数</returns>
        public bool updateStBasicInfo(stQueryInfo s_stBasicInfo)
        {
            int result;
            result = s_stBasicInfo_DAL.updateStBasicInfo(s_stBasicInfo);
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
    }
}
