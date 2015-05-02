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
    /// <summary>
    /// 赞助活动信息
    /// </summary>
    public class zzActivityInfo_BLL
    {

        #region 赞助活动基本信息接口定义
        zzActivityInfo_IDAL z_zzActivityInfo_DAL = new zzActivityInfo_DAL();
        #endregion


        #region 添加赞助活动信息
        /// <summary>
        /// 添加赞助活动信息
        /// </summary>
        /// <param name="z_zzActivityInfo">赞助活动信息</param>
        /// <returns>数据库受影响行数0错1对-1异常</returns>
        public bool insertZzActivityInfo(zzActivityInfo z_zzActivityInfo)
        {
            int result;
            result = z_zzActivityInfo_DAL.insertZzActivityInfo(z_zzActivityInfo);
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

        #region 更新赞助活动信息
        /// <summary>
        /// 更新赞助活动信息
        /// </summary>
        /// <param name="z_zzSponsorInfo">赞助活动当前信息</param>
        /// <returns>影响数据库的行数</returns>
        public bool updateActivityInfo(zzActivityInfo z_zzActivityInfo)
        {
            int result;
            result = z_zzActivityInfo_DAL.updateActivityInfo(z_zzActivityInfo);
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

        #region 只更新新赞助活动中状态信息
        /// <summary>
        /// 只更新赞助活动中状态信息
        /// </summary>
        /// <param name="z_zzSponsorInfo">赞助活动当前信息</param>
        /// <returns>影响数据库的行数</returns>
        public bool updateStatusInfo(string status, string slzzId)//todo:更新状态status！！
        {
            int result;
            result = z_zzActivityInfo_DAL.updateStatusInfo(status, slzzId);
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

        #region 查询赞助活动列表（无用）
        /// <summary>
        /// 查询赞助活动列表,供一般查询使用
        /// </summary>
        /// <returns>查询结果集</returns>
        public List<zzActivityInfo> queryZzActivityInfoList()
        {
            List<zzActivityInfo> z_zzActivityInfo_list = new List<zzActivityInfo>();
            z_zzActivityInfo_list = z_zzActivityInfo_DAL.queryZzActivityInfoList();
            if (z_zzActivityInfo_list == null)
            {
                return null;
            }
            else
            {
                return z_zzActivityInfo_list;
            }
        }
        #endregion

        #region 按状态查询赞助活动列表
        /// <summary>
        /// 按状态查询赞助活动列表,供待审核查询使用
        /// </summary>
        /// <param name="status">赞助活动状态</param>
        /// <returns>查询结果集</returns>
        public List<zzActivityInfo> queryZzActivityInfoList(string status)
        {
            List<zzActivityInfo> z_zzActivityInfo_list = new List<zzActivityInfo>();
            z_zzActivityInfo_list = z_zzActivityInfo_DAL.queryZzActivityInfoList(status);
            if (z_zzActivityInfo_list == null)
            {
                return null;
            }
            else
            {
                return z_zzActivityInfo_list;
            }
        }
        #endregion

        #region 按多条件查询赞助活动列表
        /// <summary>
        /// 按多条件查询赞助活动列表
        /// </summary>
        /// <param name="z_zzActivityInfoSelect">赞助活动信息查询条件</param>
        /// <returns>查询结果集</returns>
        public List<zzActivityInfo> queryZzActivityInfoList(zzActivityInfo z_zzActivityInfoSelect)
        {
            List<zzActivityInfo> z_zzActivityInfo_list = new List<zzActivityInfo>();
            z_zzActivityInfo_list = z_zzActivityInfo_DAL.queryZzActivityInfoList(z_zzActivityInfoSelect);
            if (z_zzActivityInfo_list == null)
            {
                return null;
            }
            else
            {
                return z_zzActivityInfo_list;
            }
        }
        #endregion

        #region 按联合主键查询赞助活动列表并返回唯一标识slzzId。
        /// <summary>
        /// 按多条件查询赞助活动列表(联合主键)
        /// </summary>
        /// <param name="z_zzActivityInfoSearch">赞助活动信息查询条件</param>
        /// <returns>是否有对应数据</returns>
        public string SearchZzActivityInfoList(zzActivityInfo z_zzActivityInfoSearch)
        {
            string result="";
            result = z_zzActivityInfo_DAL.SearchZzActivityInfoList(z_zzActivityInfoSearch);

                return result;
            
        }

        #endregion

        #region 按角色及标识号生成赞助活动详细信息链接地址,待完善（涉及权限）
        public string createUrlByRole(int role, string slzzId)//slzzId在list页面加载时进入并生成url
        {
            try
            {
                const int M = 0;
                const int A = 1;
                string url = "login.aspx";
                if (role == M)
                {
                    url = "zzglActDetailQueryM.aspx?slzzId=" + slzzId;
                }
                if (role == A)
                {
                    url = "zzglActDetailQueryA.aspx?slzzId=" + slzzId;
                }
                return url;
            }
            catch (System.Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw ex;
            }

        }
        #endregion

        #region 按标识号查询赞助活动详细信息
        /// <summary>
        /// 按标识号查询赞助活动详细信息
        /// </summary>
        /// <returns>查询结果</returns>
        public zzActivityInfo queryZzActivityInfoDetail(string slzzId)
        {
            zzActivityInfo z_zzActivityInfo = new zzActivityInfo();
            z_zzActivityInfo = z_zzActivityInfo_DAL.queryZzActivityInfoDetail(slzzId);
            if (z_zzActivityInfo == null)
            {
                return null;
            }
            else
            {
                return z_zzActivityInfo;
            }
        }
        #endregion

        #region (被注释)LINQ多条件筛选赞助活动列表，不确定无条件查出的结果集能存在多久,因此其他list到details的跳转可能也有问题
        /// <summary>
        /// 多条件筛选赞助活动列表
        /// </summary>
        /// <returns>查询结果</returns>
        /*
        public List<zzActivityInfo> selectZzActivityInfoList(zzActivityInfo z_zzActivityListSelect,List<zzActivityInfo> z_zzActivityInfoList)
        {
            //List<zzActivityInfo> z_zzActivityInfoList_selected=new List<zzActivityInfo>();
            var z_zzActivityInfoList_selected =
                from z_zzActivityInfo in z_zzActivityInfoList
                where z_zzActivityInfo.sponsorName == z_zzActivityListSelect.sponsorName
                select z_zzActivityInfo;
            return z_zzActivityInfoList_selected.ToList<zzActivityInfo>();
        }
         */
        #endregion

        
    }
}
