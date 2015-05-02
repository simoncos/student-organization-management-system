using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLHMODEL.SLWL.DWJL;
namespace STLHIDAL.SLWL.DWJL
{
    /// <summary>
    /// 对外交流基本信息接口
    /// </summary>
    public interface jlBasicInfo_IDAL
    {
        /// <summary>
        /// 添加对外交流基本信息
        /// </summary>
        /// <param name="j_jlBasicInfo">对外交流基本信息</param>
        /// <returns>数据库受影响行数0错1对-1异常</returns>
        int insertJlBasicInfo(jlBasicInfo j_jlBasicInfo);

        /// <summary>
        /// 更新对外交流基本信息
        /// </summary>
        /// <param name="j_jlBasicInfo">对外交流基本信息</param>
        /// <returns>数据库受影响行数0错1对-1异常</returns>
        int updateJlBasicInfo(jlBasicInfo j_jlBasicInfo);

        /// <summary>
        /// 对外交流活动状态更改
        /// </summary>
        /// <param name="status">对外交流状态</param>
        /// <returns>数据库受影响行数0错1对-1异常</returns>
        int statusJlBasicInfo(jlBasicInfo j_jlBasicInfo);

        /// <summary>
        /// 查询对外交流活动列表,供一般查询使用
        /// </summary>
        /// <returns>查询结果集</returns>
        List<jlBasicInfo> queryJlActivityInfoList();

        /// <summary>
        /// 按状态查询交流活动列表,供待审核查询使用
        /// </summary>
        /// <param name="status">交流活动状态</param>
        /// <returns>查询结果集</returns>
        List<jlBasicInfo> queryJlActivityInfoList(string status);

        /// <summary>
        /// 按多条件查询交流活动列表,供条件筛选
        /// </summary>
        /// <param name="j_jlBasicInfoSelect">交流活动信息查询条件</param>
        /// <returns>查询结果集</returns>
        List<jlBasicInfo> queryJlActivityInfoList(jlBasicInfo j_jlBasicInfoSelect);

        /// <summary>
        /// 按标识号查询对外交流活动详细信息
        /// </summary>
        /// <returns>查询结果</returns>
        jlBasicInfo queryJlActivityInfoDetail(string sljlId);

        /// <summary>
        /// 按多条件（联合主键）查询对外交流活动列表
        /// </summary>
        /// <param name="z_zzActivityInfoSearch">对外交流活动信息查询条件</param>
        /// <returns>sljlName</returns>
        string SearchSlijlActBasicInfoList(jlBasicInfo j_jlBasicInfoSearch);
    }
}
