using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLHMODEL.ZYGL.CDGL;
namespace STLHIDAL.ZYGL.CDGL
{
    public interface cdLocationInfo_IDAL
    {
        #region 载入场地信息表
        /// <summary>
        /// 载入场地信息表
        /// </summary>
        /// <returns>数据库中的信息表</returns>
        List<cdLocationInfo> queryCdLocationInfoList();
        #endregion

        #region 更新场地信息
        /// <summary>
        /// 在保存页面内容时，更新场地信息
        /// </summary>
        /// <param name="c_cdLocationInfo">场地当前信息</param>
        /// <returns>数据库中的场地信息表</returns>
        int updateCdLocationInfo(cdLocationInfo c_cdLocationInfo);
        /// <summary>
        /// 删除场地信息
        /// </summary>
        /// <param name="location">场地当前列表</param>
        /// <returns>影响数据库的行数</returns>
        int deleteCdLocationInfo(string location);
        #endregion
    }
}
