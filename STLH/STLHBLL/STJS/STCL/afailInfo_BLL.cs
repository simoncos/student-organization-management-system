using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLHMODEL.STJS.STCL;
using STLHIDAL.STJS.STCL;
using STLHDAL.STJS.STCL;

namespace STLHBLL.STJS.STCL
{
    public class afailInfo_BLL
    {
        /// <summary>
        /// 接口引用类（约束数据操作函数的范围）
        /// </summary>
        afailInfo_IDAL a_afailInfo_DAL = new afailInfo_DAL();



        #region 添加社团申请修改意见

        /// <summary>
        /// 添加社团申请修改意见
        /// </summary>
        /// <param name="a_afailInfo">社团申请修改意见信息</param>
        /// <returns>返回操作成功或失败的字符串</returns>
        public string addAfaildInfo(afailInfo a_afailInfo,applyInfo a_applyInfo)
        {
            int result;
            result=a_afailInfo_DAL.addAfaildInfo(a_afailInfo,a_applyInfo);
            if (result==0)
            {
                return "提交修改建议失败！！！";
            } 
            else
            {
                return "提交修改建议成功！！！";
            }

        }
        #endregion

        #region 通过社长(会长)学号获取修改意见列表
        /// <summary>
        /// 通过社长(会长)学号获取修改意见列表
        /// </summary>
        /// <param name="UserId">社长(会长)学号</param>
        /// <returns>返回社团申请修改意见列表</returns>
        public IList<afailInfo> getAfailInfoList(string UserId)
        {
            IList<afailInfo>  a_afailInfo_list=new List<afailInfo>();
            a_afailInfo_list = a_afailInfo_DAL.getAfailInfoList(UserId);
            if (a_afailInfo_list==null)
            {
                return null;
            } 
            else
            {
                return a_afailInfo_list;
            }
        }
        
        #endregion


        #region   通过学号获取修改意见信息（审核修改意见时间）
        ///<summary>
        /// 通过会长学号获取修改意见信息
        ///</summary>
        ///<param name="UserId">社长(会长)学号</param>
        /// <returns>返回修改意见信息或null</returns>
        public afailInfo getAfailInfo(string presidentId) {
            afailInfo a_afailInfo = new afailInfo();
            a_afailInfo = a_afailInfo_DAL.getAfailInfo(presidentId);
            if (a_afailInfo != null)
            {
                return a_afailInfo;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region apply页面中用来更改opinionDate的状态
           

        #endregion
    }
}
       