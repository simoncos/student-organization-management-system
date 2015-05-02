using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLHDAL.ZYGL.CDGL;
using STLHIDAL.ZYGL.CDGL;
using STLHMODEL.ZYGL.CDGL;
using STLHCOMMON;

namespace STLHBLL.ZYGL.CDGL
{
    public class cdLocationInfo_BLL
    {
        #region  场地基本信息接口定义
        cdLocationInfo_IDAL c_cdLocationInfo_DAL = new cdLocationInfo_DAL();
        #endregion

        #region 显示场地基本信息表
        /// <summary>
        /// 列出场地基本信息表
        /// </summary>
        /// <returns>场地基本信息表</returns>
        public List<cdLocationInfo> queryCdLocationInfoList()
        {
            List<cdLocationInfo> c_cdLocationInfo_list = new List<cdLocationInfo>();
            c_cdLocationInfo_list = c_cdLocationInfo_DAL.queryCdLocationInfoList();
            if (c_cdLocationInfo_list == null)
                return null;
            else return c_cdLocationInfo_list;
        }
        #endregion

        #region 更新场地基本信息
        /// <summary>
        /// 更新场地基本信息
        /// </summary>
        /// <param name="c_cdLocationInfo">场地当前信息</param>
        /// <returns>影响数据库的行数</returns>
        public bool updateCdLocationInfo(cdLocationInfo c_cdLocationInfo)
        {
            int result;
            result = c_cdLocationInfo_DAL.updateCdLocationInfo(c_cdLocationInfo);
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

        #region 删除场地信息
        /// <summary>
        /// 删除场地信息
        /// </summary>
        /// <param name="location">场地名</param>
        /// <returns>影响数据库行数</returns>
        public bool deleteCdLocationInfo(string location)
        {
            int result;
            result = c_cdLocationInfo_DAL.deleteCdLocationInfo(location);
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
