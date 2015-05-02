using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace STLHMODEL.SLWL.ZZGL
{
    /// <summary>
    /// 赞助活动信息
    /// </summary>
    [Serializable]
    public class zzActivityInfo
    {
        public zzActivityInfo()
        {
            //slzzNum = -1;
            slzzId = "";
            sponsorId = "";
            sponsorName = "";
            responsId = "";
            responsName = "";
            fillId = "";
            fillName = "";
            sponsorType = "";
            location = "";
            reserTimeRange = "";
            budgetAmount = 0;
            actualTime = Convert.ToDateTime("1900-1-1");
            actualAmount = 0;
            status = "";
            fillDate = Convert.ToDateTime("1900-1-1");
        }

        /// <summary>
        /// 赞助活动序列号
        /// </summary>
        //public int slzzNum { get; set; }

        /// <summary>
        /// 赞助活动序列号
        /// </summary>
        public string slzzId { get; set; }

        /// <summary>
        /// 赞助商标识号
        /// </summary>
        public string sponsorId { get; set; }

        /// <summary>
        /// 赞助商名称
        /// </summary>
        public string sponsorName { get; set; }

        /// <summary>
        /// 社联负责人学号
        /// </summary>
        public string responsId { get; set; }

        /// <summary>
        /// 社联负责人姓名
        /// </summary>
        public string responsName { get; set; }

        /// <summary>
        /// 填表人学号
        /// </summary>
        public string fillId { get; set; }

        /// <summary>
        /// 填表人姓名
        /// </summary>
        public string fillName { get; set; }


        /// <summary>
        /// 赞助活动方式
        /// </summary>
        public string sponsorType { get; set; }

        /// <summary>
        /// 活动场地
        /// </summary>
        public string location { get; set; }

        /// <summary>
        /// 预约时间段
        /// </summary>
        public string reserTimeRange { get; set; }

        /// <summary>
        /// 预算资金
        /// </summary>
        public int budgetAmount { get; set; }

        /// <summary>
        /// 实际时间
        /// </summary>
        public DateTime actualTime { get; set; }

        /// <summary>
        /// 实际资金
        /// </summary>
        public int actualAmount { get; set; }

        /// <summary>
        /// 活动状态
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 填表时间
        /// </summary>
        public DateTime fillDate { get; set; }

    }
}
