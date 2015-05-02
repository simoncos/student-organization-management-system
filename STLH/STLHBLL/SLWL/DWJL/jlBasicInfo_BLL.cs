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
    /// 对外交流信息业务
    /// </summary>
    public class jlBasicInfo_BLL
    {

        #region 对外交流基本信息接口定义
        jlBasicInfo_IDAL j_jlBasicInfo_DAL = new jlBasicInfo_DAL();
        #endregion

        #region 添加对外交流基本信息
        /// <summary>
        /// 添加对外交流基本信息
        /// </summary>
        /// <param name="j_jlBasicInfo">对外交流基本信息</param>
        /// <returns>返回数据库受影响行数0错1对-1异常</returns>
        public bool insertJlBasicInfo(jlBasicInfo j_jlBasicInfo)
        {
            int result;
            result = j_jlBasicInfo_DAL.insertJlBasicInfo(j_jlBasicInfo);
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

        #region 更新对外交流基本信息
        /// <summary>
        /// 更新对外交流基本信息
        /// </summary>
        /// <param name="j_jlBasicInfo">对外交流基本信息</param>
        /// <returns>数据库受影响行数0错1对-1异常</returns>
        public bool updateJlBasicInfo(jlBasicInfo j_jlBasicInfo)
        {
            int result;
            result = j_jlBasicInfo_DAL.updateJlBasicInfo(j_jlBasicInfo);
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

        #region 对外交流活动状态更改
        /// <summary>
        /// 对外交流活动状态更改
        /// </summary>
        /// <param name="status">对外交流状态</param>
        /// <returns>数据库受影响行数0错1对-1异常</returns>
        public bool statusJlBasicInfo(jlBasicInfo j_jlBasicInfo)
        {
            int result;
            result = j_jlBasicInfo_DAL.statusJlBasicInfo(j_jlBasicInfo);
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

        #region 查询对外交流活动列表
        /// <summary>
        /// 查询对外交流活动列表,,供一般查询使用
        /// </summary>
        /// <returns>查询结果集</returns>
        public List<jlBasicInfo> queryJlActivityInfoList()
        {
            List<jlBasicInfo> j_jlBasicInfo_list = new List<jlBasicInfo>();
            j_jlBasicInfo_list = j_jlBasicInfo_DAL.queryJlActivityInfoList();
            if (j_jlBasicInfo_list == null)
            {
                return null;
            }
            else
            {
                return j_jlBasicInfo_list;
            }
        }
        #endregion

        #region 按状态查询交流活动列表
        /// <summary>
        /// 按状态查询交流活动列表,供待审核查询使用
        /// </summary>
        /// <param name="status">交流活动状态</param>
        /// <returns>查询结果集</returns>
        public List<jlBasicInfo> queryJlActivityInfoList(string status)
        {
            List<jlBasicInfo> j_jlBasicInfo_list = new List<jlBasicInfo>();
            j_jlBasicInfo_list = j_jlBasicInfo_DAL.queryJlActivityInfoList(status);
            if (j_jlBasicInfo_list == null)
            {
                return null;
            }
            else
            {
                return j_jlBasicInfo_list;
            }
        }
        #endregion

        #region 按多条件查询交流活动列表
        /// <summary>
        /// 按多条件查询交流活动列表，供条件筛选
        /// </summary>
        /// <param name="j_jlBasicInfoSelect">交流活动信息查询条件</param>
        /// <returns>查询结果集</returns>
        public List<jlBasicInfo> queryJlActivityInfoList(jlBasicInfo j_jlBasicInfoSelect)
        {
            List<jlBasicInfo> j_jlBasicInfo_list = new List<jlBasicInfo>();
            j_jlBasicInfo_list = j_jlBasicInfo_DAL.queryJlActivityInfoList(j_jlBasicInfoSelect);
            if (j_jlBasicInfo_list == null)
            {
                return null;
            }
            else
            {
                return j_jlBasicInfo_list;
            }
        }
        #endregion

        #region 按标识号查询对外交流活动详细信息
        /// <summary>
        /// 按标识号查询对外交流活动详细信息
        /// </summary>
        /// <returns>查询结果</returns>
        public jlBasicInfo queryJlActivityInfoDetail(string sljlId)
        {
            jlBasicInfo j_jlBasicInfo = new jlBasicInfo();
            j_jlBasicInfo = j_jlBasicInfo_DAL.queryJlActivityInfoDetail(sljlId);
            if (j_jlBasicInfo == null)
            {
                return null;
            }
            else
            {
                return j_jlBasicInfo;
            }
        }
        #endregion

        #region 按角色及标识号生成交流活动详细信息链接地址,似乎可以写在aspx.cs文件中，参考MusicIn中方法
        public string createUrlByRole(int role, string sljlId)//slzzId在list页面加载时进入并生成url
        {
            string url="";
            try
            {
                if (role==1)
                {
                    url = "dwjlActDetailQuery.aspx?sljlId=" + sljlId;
                }
            }
            catch (System.Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw ex;
            }
            return url;
        }
        #endregion

        #region 按多条件（联合主键）查询对外交流活动列表
        /// <summary>
        /// 按多条件（联合主键）查询对外交流活动列表
        /// </summary>
        /// <param name="z_zzActivityInfoSearch">对外交流活动信息查询条件</param>
        /// <returns>sljlName</returns>
        public string SearchSlijlActBasicInfoList(jlBasicInfo j_jlBasicInfoSearch) {
            string result = "";
            result = j_jlBasicInfo_DAL.SearchSlijlActBasicInfoList(j_jlBasicInfoSearch);
            return result;
        }
        #endregion
    }
}
