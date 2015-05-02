using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STLHMODEL.STJS.STCL
{
    /// <summary>
    /// 社团申请修改建议信息
    /// </summary>
    [Serializable]
    public class afailInfo
    {
        public afailInfo()
        {
            presidentId = "";
            stName = "";
            amendments = "";
            opiniorId = "";
            opiniorName = "";
            DateTime opinionDate = Convert.ToDateTime("1900-1-1");

            DateTime applyDate = Convert.ToDateTime("1900-1-1");
            fee = 0;
        }
        /// <summary>
        /// 申请社团会长学号
        /// </summary>
        public string presidentId { get; set; }
        /// <summary>
        /// 申请社团名称
        /// </summary>
        public string stName { get; set; }
        /// <summary>
        /// 社团申请修改建议
        /// </summary>
        public string amendments { get; set; }
        /// <summary>
        /// 社团申请建议提出人学号
        /// </summary>
        public string opiniorId { get; set; }
        /// <summary>
        /// 社团申请建议提出人姓名
        /// </summary>
        public string opiniorName { get; set; }
        ///<summary>
        /// 修改建议提出时间
        ///</summary>
        public DateTime opinionDate { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime applyDate { get; set; }
        /// <summary>
        /// 会费
        /// </summary>
        public byte fee { get; set; }
    }
}
