using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLHMODEL.SLWL.ZZGL;
namespace STLHIDAL.SLWL.ZZGL
{
    /// <summary>
    /// 赞助商信息管理接口
    /// </summary>
    public interface zzSponsorInfo_IDAL
    {
        /// <summary>
        /// 更新赞助商信息列表
        /// </summary>
        /// <param name="z_zzSponsorInfoList">赞助商当前列表</param>
        /// <returns>影响数据库的行数</returns>
        int updateZzSponsorInfo(zzSponsorInfo z_zzSponsorInfo);//fillId在哪里获取？BLL？WEB？

        /// <summary>
        /// 按状态查询赞助商信息列表
        /// </summary>
        /// <returns>赞助商信息结果集</returns>
        IList<zzSponsorInfo> queryZzSponsorInfo(string status);

                /// <summary>
        /// 删除赞助商信息列表中记录
        /// </summary>
        /// <param name="z_zzSponsorInfoList">赞助商当前列表</param>
        /// <returns>影响数据库的行数</returns>
        int deleteZzSponsorInfo(string sponsoreName);
        

    }
}
