using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLHMODEL.STJS.STCL;

namespace STLHIDAL.STJS.STCL
{
    public interface afailInfo_IDAL
    {
        #region 添加社团申请修改意见

        /// <summary>
        /// 添加社团申请修改意见
        /// </summary>
        /// <param name="a_afailInfo">社团申请修改意见信息</param>
        /// <returns>数据库受影响行数0错1对</returns>
        int addAfaildInfo(afailInfo a_afailInfo, applyInfo a_applyInfo);
#endregion

        #region 通过社长(会长)学号获取修改意见列表
        /// <summary>
        /// 通过社长(会长)学号获取修改意见列表
        /// </summary>
        /// <param name="UserId">社长(会长)学号</param>
        /// <returns>返回社团申请修改意见列表</returns>
        IList<afailInfo> getAfailInfoList(string UserId);
#endregion

        ///<summary>
        /// 通过会长学号获取修改意见信息
        ///</summary>
        ///<param name="UserId">社长(会长)学号</param>
        /// <returns>返回修改意见信息或null</returns>
        afailInfo getAfailInfo(string presidentId);

    }
}
