using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STLHMODEL.SLWL.DWJL
{
    /// <summary>
    /// 对外交流参与人员
    /// </summary>
    [Serializable]
     public class jlParticipators
    {
        public jlParticipators()
        {
            sljlId = "";
            participatorId = "";
            participatorName = "";
            participatorGender = "";
            fillId = "";
            fillName = "";
            fillDate = Convert.ToDateTime("1900-1-1");
        }
        
        /// <summary>
        /// 对外交流活动标识号
        /// </summary>
        public string sljlId { get; set; }

        /// <summary>
        /// 参加者学号
        /// </summary>
        public string participatorId { get; set; }

        /// <summary>
        /// 参加者姓名
        /// </summary>
        public string participatorName { get; set; }

        /// <summary>
        /// 参加者性别
        /// </summary>
        public string participatorGender { get; set; }

        /// <summary>
        /// 参加者电话
        /// </summary>
        public string participatorTel { get; set; }

        /// <summary>
        /// 填表人学号
        /// </summary>
        public string fillId { get; set; }

        /// <summary>
        /// 填表人姓名
        /// </summary>
        public string fillName { get; set; }

        /// <summary>
        /// 填表时间
        /// </summary>
        public DateTime fillDate { get; set; }

    }

}
