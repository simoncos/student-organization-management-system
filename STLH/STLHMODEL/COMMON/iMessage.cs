using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STLHMODEL.COMMON
{
    /// <summary>
    ///消息实体类
    /// </summary>
    public class iMessage
    {

        /// <summary>
        /// 消息Id
        /// </summary>
        public string messageId { get; set; }
        /// <summary>
        /// 消息title
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 发送者Id
        /// </summary>
        public int senderId { get; set; }
        /// <summary>
        /// 发送者name
        /// </summary>
        public string  sendName { get; set; }
        /// <summary>
        /// 接受 者Id
        /// </summary>
        public int receiverId { get; set; }
        /// <summary>
        /// 消息类型 0:系统消息 1：角色的 2：外部公共消息（针对系统角色全部接收者） 3：全局公共消息（全网可见） 4：个人消息
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime sendtime { get; set; }
        /// <summary>
        /// 接受时间
        /// </summary>
        public DateTime readtime { get; set; }
        /// <summary>
        /// 其他状态
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 接受者是否删除
        /// </summary>
        public int receiveisdelete { get; set; }
        /// <summary>
        /// 发送者是否删除
        /// </summary>
        public int sendisdelete { get; set; }
        /// <summary>
        /// 是否可回复
        /// </summary>
        public int isCallback { get; set; }
        /// <summary>
        /// 回复的消息Id，若为空，则不是回复消息
        /// </summary>
        public string backMessageId { get; set; }

    }
    /// <summary>
    /// 角色类
    /// </summary>
    public class iRole
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleID { get; set; }
        /// <summary>
        /// 角色名
        /// </summary>
        public string R_RoleName { get; set; }
    }
}
