using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLHDAL.STJS.STCL;
using STLHIDAL.STJS.STCL;
using STLHMODEL.STJS.STCL;
using STLHCOMMON;


namespace STLHBLL.STJS.STCL
{
    /// <summary>
    /// 社团申请信息业务
    /// </summary>
    public class applyInfo_BLL
    {
        #region 社团申请信息业务接口引用类
        /// <summary>
        /// 社团申请信息业务接口引用类
        /// </summary>
        applyInfo_IDAL a_applyInfo_DAL = new applyInfo_DAL();
        #endregion

        #region 添加社团申请信息
        /// <summary>
        /// 添加社团申请信息
        /// </summary>
        /// <param name="a_applyInfo">社团申请信息实体</param>
        /// <returns>返回true则成功false则失败</returns>
        public bool addApplyInfo(applyInfo a_applyInfo)
        {
            int result;
            result = a_applyInfo_DAL.addApplyInfo(a_applyInfo);
            if (result == 1)
            {
                return true;

            }
            else if (result == 0)
            {
                return false;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region 通过社长(会长)学号获取社团申请信息

        /// <summary>
        /// 通过社长(会长)学号获取社团申请信息
        /// </summary>
        /// <param name="UserId">社长(会长)学号</param>
        /// <returns>成功则返回社团申请信息失败则返回null</returns>
        public applyInfo getApplyInfo(string UserId)
        {
            applyInfo a_applyInfo = new applyInfo();
            a_applyInfo = a_applyInfo_DAL.getApplyInfo(UserId);
            if (a_applyInfo != null)
            {
                return a_applyInfo;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region 通过会长学号获取社团基本信息
        ///<summary>
        /// 通过会长学号获取社团基本信息
        ///</summary>
        ///<param name="UserId">社长(会长)学号</param>
        /// <returns>返回社团基本信息</returns>
        public applyInfo getSTBasicInfo(string UserId)
        {
            /*获取社团转正信息
            //applyInfo a_positiveInfo = new applyInfo();
            //a_positiveInfo = a_applyInfo_DAL.getPositiveInfo(UserId);
            //if (a_positiveInfo != null)
            //{
            //    return a_positiveInfo;
            //} 
            //else
            //{
            //    return null;
            //}
            */
            applyInfo a_applyInfo = new applyInfo();
            a_applyInfo = a_applyInfo_DAL.getSTBasicInfo(UserId);
            if (a_applyInfo != null)
            {
                return a_applyInfo;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region  通过提交申请时间、通过审核时间是否为空 获取待审核社团信息列表
         ///<summary>
        /// 通过提交申请时间、通过审核时间是否为空 获取待审核社团信息列表
        ///</summary>
        ///<param name="applyDate">申请时间</param>
        ///<param name="positiveDate">审核时间</param>
        /// <returns>查询结果集</returns>
        public List<applyInfo> queryExamListInfo() {  
            List<applyInfo> a_applyInfo_list=new List<applyInfo>();
            a_applyInfo_list = a_applyInfo_DAL.queryExamListInfo();
            if (a_applyInfo_list == null)
            {
                return null;
            }
            else {
                return a_applyInfo_list;
            }
        
        }
        #endregion

        public string stApplyPassInfo(string presidentId, string positiveId, byte fee, byte stStates)
        {
            try
            {
                int result = a_applyInfo_DAL.stApplyPassInfo(presidentId, positiveId,fee,stStates);
                if (result == 1)
                {
                    return "审核通过";
                }
                else
                {
                    return "审核不通过";
                }
            }
            catch (System.Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }
            
        }
    }
}
