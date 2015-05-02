using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLHMODEL.COMMON;

namespace STLHIDAL.COMMON
{
    /// <summary>
    /// 消息实体接口
    /// </summary>
    public interface iMessage_IDAL
    {

        /// <summary>
        /// 通过用户Id获取消息集合 包括其可见的所有消息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
         List<iMessage> getPerMessagesByUserId(int userId);
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="cMessage">消息</param>
        /// <returns></returns>
         bool sendMessage(iMessage cMessage );
        /// <summary>
        /// 获取公共消息
        /// </summary>
        /// <returns></returns>
         List<iMessage> getGerMessages();






    }
}
