using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLHMODEL.STJS.STZL;

namespace STLHIDAL.STJS.STZL
{
    public interface stBasicInfo_IDAL
    {
        #region 载入社团信息表
        /// <summary>
        /// 载入社团信息表
        /// </summary>
        /// <returns>数据库中的信息表</returns>
        List<stQueryInfo> queryStBasicInfoList();
        #endregion

        #region 更新社团信息
        /// <summary>
        /// 在保存页面内容时，更新社团信息
        /// </summary>
        /// <param name="s_stBasicInfo">社团当前信息</param>
        /// <returns>数据库中的社团信息表</returns>
        int updateStBasicInfo(stQueryInfo s_stBasicInfo);
        #endregion
    }
}
