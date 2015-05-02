using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STLHMODEL.ZYGL.CDGL
{
    /// <summary>
    /// 场地管理信息
    /// </summary>
    [Serializable]
    public class cdLocationInfo
    {
        public cdLocationInfo()
        {
            locationId="";
            fillId = "";
            location = "";
            allowedTimeRange = "";
            fillDate = Convert.ToDateTime("1900-1-1");
            num = 0;
         }
        /// <summary>
        /// 场地信息标识号
        /// </summary>
        public string locationId{ get; set; }
        /// <summary>
        /// 填表人学号
        /// </summary>
        public string fillId{ get; set; }
        /// <summary>
        /// 场地名称
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// 可借时段
        /// </summary>
        public string allowedTimeRange { get; set; }
        /// <summary>
        /// 填表时间
        /// </summary>
        public DateTime fillDate { get; set; }
        /// <summary>
        /// 序列号
        /// </summary>
        public int num { get; set; }
 
     }
  }

