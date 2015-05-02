using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLHCOMMON;
using STLHMODEL.SLWL.ZZGL;
using STLHIDAL.SLWL.ZZGL;
using STLHDAL.SLWL.ZZGL;

namespace STLHBLL.SLWL.ZZGL
{
    public class zzSponsorInfo_BLL
    {

        #region 赞助活动基本信息接口定义
        zzSponsorInfo_IDAL z_zzSponsorInfo_DAL = new zzSponsorInfo_DAL();
        #endregion


        #region 更新赞助商信息列表
        /// <summary>
        /// 更新赞助商信息列表
        /// </summary>
        /// <param name="z_zzSponsorInfoList">赞助商当前列表</param>
        /// <returns>影响数据库的行数</returns>
        public bool updateZzSponsorInfo(zzSponsorInfo z_zzSponsorInfo)
        {
            int result;
            result = z_zzSponsorInfo_DAL.updateZzSponsorInfo(z_zzSponsorInfo);
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
         #region 删除赞助商信息列表中记录
                        /// <summary>
        /// 删除赞助商信息列表中记录
        /// </summary>
        /// <param name="z_zzSponsorInfoList">赞助商当前列表</param>
        /// <returns>影响数据库的行数</returns>
        public bool deleteZzSponsorInfo(string sponsoreName) {
            int result;
            result = z_zzSponsorInfo_DAL.deleteZzSponsorInfo(sponsoreName);
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

        #region 按状态查询赞助商信息列表
        /// <summary>
        /// 按状态查询赞助商信息列表，一般只查询“正常”状态的记录
        /// </summary>
        /// <returns>赞助商信息结果集</returns>
        public IList<zzSponsorInfo> queryZzSponsorInfo(string status)
        {
            IList<zzSponsorInfo> z_zzSponsorInfo_list=new List<zzSponsorInfo>();
            z_zzSponsorInfo_list = z_zzSponsorInfo_DAL.queryZzSponsorInfo(status);
            if (z_zzSponsorInfo_list==null)
            {
                return null;
            } 
            else
            {
                return z_zzSponsorInfo_list;
            }
        }
       #endregion



    }
}
