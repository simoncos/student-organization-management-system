using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLHMODEL.SLWL.ZZGL;
namespace STLHIDAL.SLWL.ZZGL
{
    /// <summary>
    /// 赞助活动管理接口
    /// </summary>
    public interface zzActivityInfo_IDAL
    {
        /// <summary>
        /// 添加赞助活动信息
        /// </summary>
        /// <param name="z_zzActivityInfo">赞助活动信息</param>
        /// <returns>数据库受影响行数0错1对-1异常</returns>
        int insertZzActivityInfo(zzActivityInfo z_zzActivityInfo);

        /// <summary>
        /// 更新赞助活动信息
        /// </summary>
        /// <param name="z_zzSponsorInfo">赞助活动当前信息</param>
        /// <returns>数据库受影响行数</returns>
        int updateActivityInfo(zzActivityInfo z_zzActivityInfo);


        /// <summary>
        /// 只更新赞助活动中状态信息
        /// </summary>
        /// <param name="z_zzSponsorInfo">赞助活动当前信息</param>
        /// <returns>影响数据库的行数</returns>
        int updateStatusInfo(string status, string slzzId);



        /// <summary>
        /// 查询赞助活动列表,供一般查询使用
        /// </summary>
        /// <returns>查询结果集</returns>
        List<zzActivityInfo> queryZzActivityInfoList();

        /// <summary>
        /// 按状态查询赞助活动列表,供待审核查询使用
        /// </summary>
        /// <param name="status">赞助活动状态</param>
        /// <returns>查询结果集</returns>
        List<zzActivityInfo> queryZzActivityInfoList(string status);

        /// <summary>
        /// 按多条件查询赞助活动列表
        /// </summary>
        /// <param name="z_zzActivityInfoSelect">赞助活动信息查询条件</param>
        /// <returns>查询结果集</returns>
        List<zzActivityInfo> queryZzActivityInfoList(zzActivityInfo z_zzActivityInfoSelect);

        /// <summary>
        /// 按多条件查询赞助活动列表
        /// </summary>
        /// <param name="z_zzActivityInfoSearch">赞助活动信息查询条件</param>
        /// <returns>slzzId</returns>
        string  SearchZzActivityInfoList(zzActivityInfo z_zzActivityInfoSearch);


        /// <summary>
        /// 按标识号查询赞助活动详细信息
        /// </summary>
        /// <param name="status">赞助活动标识号</param>
        /// <returns>查询结果</returns>
        zzActivityInfo queryZzActivityInfoDetail(string slzzId);
        
        
    }
}
