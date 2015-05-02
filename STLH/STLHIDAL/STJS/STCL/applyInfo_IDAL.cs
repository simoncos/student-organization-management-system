using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLHMODEL.STJS.STCL;

namespace STLHIDAL.STJS.STCL
{
    /// <summary>
    /// 社团申请信息接口
    /// </summary>
    public interface applyInfo_IDAL
    {
        /// <summary>
        /// 添加社团申请信息
        /// </summary>
        /// <param name="a_applyInfo"> 社团申请信息</param>
        /// <returns>数据库受影响行数0错1对-1异常</returns>
        int addApplyInfo(applyInfo a_applyInfo);
        /// <summary>
        /// 通过社长(会长)学号获取社团申请信息
        /// </summary>
        /// <param name="UserId">社长(会长)学号</param>
        /// <returns>返回社团申请信息或null</returns>
        applyInfo getApplyInfo(string UserId);

        ///<summary>
        /// 通过会长学号获取社团基本信息
        ///</summary>
        ///<param name="UserId">社长(会长)学号</param>
        /// <returns>返回社团基本信息或null</returns>
        applyInfo getSTBasicInfo(string UserId);
       /// <summary>
        /// 社团申请审核通过
       /// </summary>
       /// <param name="presidentId">会长Id</param>
       /// <param name="positiveId">审核人Id</param>
       /// <returns>返回1或0</returns>
        int stApplyPassInfo(string presidentId, string positiveId, byte fee, byte stStates);

         ///<summary>
        /// 通过提交申请时间、通过审核时间是否为空 获取待审核社团信息列表
        ///</summary>
        ///<param name="applyDate">申请时间</param>
        ///<param name="positiveDate">审核时间</param>
        /// <returns>查询结果集</returns>
        List<applyInfo> queryExamListInfo();
    
    }
}
