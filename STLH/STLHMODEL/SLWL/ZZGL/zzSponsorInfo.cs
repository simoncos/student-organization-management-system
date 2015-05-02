using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STLHMODEL.SLWL.ZZGL
{
    /// <summary>
    /// 赞助商管理信息
    /// </summary>
   [Serializable]
    public class zzSponsorInfo
   {
       public zzSponsorInfo()
       {
           sponsorId = "";
           fillId = "";
           fillName = "";
           sponsorName = "";
           leaderName = "";
           leaderPosition = "";
           leaderTel = "";
           contactName = "";
           contactPosition = "";
           contactTel = "";
           status = "";
           fillDate = Convert.ToDateTime("1900-1-1");
       }
       /// <summary>
       /// 赞助商标识号
       /// </summary>
       public string sponsorId { get; set; }

       /// <summary>
       /// 填表人学号
       /// </summary>
       public string fillId { get; set; }

       /// <summary>
       /// 填表人姓名
       /// </summary>
       public string fillName { get; set; }

       /// <summary>
       /// 赞助商名
       /// </summary>
       public string sponsorName { get; set; }

       /// <summary>
       /// 负责人姓名
       /// </summary>
       public string leaderName { get; set; }

       /// <summary>
       /// 负责人职位
       /// </summary>
       public string leaderPosition { get; set; }

       /// <summary>
       /// 负责人联系方式
       /// </summary>
       public string leaderTel { get; set; }

       /// <summary>
       /// 联系人姓名
       /// </summary>
       public string contactName { get; set; }

       /// <summary>
       /// 联系人职位
       /// </summary>
       public string contactPosition { get; set; }

       /// <summary>
       /// 联系人电话
       /// </summary>
       public string contactTel { get; set; }

       /// <summary>
       /// 赞助商状态
       /// </summary>
       public string status { get; set; }

       /// <summary>
       /// 填表时间
       /// </summary>
       public DateTime fillDate { get; set; }

    }
}
