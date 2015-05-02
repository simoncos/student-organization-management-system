using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STLHMODEL.SLWL.DWJL
{
    /// <summary>
    /// 对外交流基本信息
    /// </summary>
   [Serializable]
   public class jlBasicInfo
   {
       public jlBasicInfo()
       {
           sljlId = "";
           fillId = "";
           fillName = "";
           inviter = "";
           sljlName = "";
           sljlDate = Convert.ToDateTime("1900-1-1");
           sljlLocation = "";
           invited = "";
           invitedAmount =0;
           contactName = "";
           contactTel = "";
           responsName = "";
           responsTel = "";
           status = "";
           fillDate = Convert.ToDateTime("1900-1-1");
   
       }
       /// <summary>
       /// 对外交流活动标识号
       /// </summary>
       public string sljlId = "";
       /// <summary>
       /// 填表人学号
       /// </summary>
       public string fillId = "";
       /// <summary>
       /// 填表人姓名
       /// </summary>
       public string fillName = "";
       /// <summary>
       /// 发起方
       /// </summary>
       public string inviter { get; set; }
       /// <summary>
       /// 交流活动名称
       /// </summary>
       public string sljlName { get; set; }
       /// <summary>
       /// 交流活动日期
       /// </summary>
       public DateTime sljlDate { get; set; }
       /// <summary>
       /// 交流活动地点
       /// </summary>
       public string sljlLocation { get; set; }
       /// <summary>
       /// 受邀方
       /// </summary>
       public string invited { get; set; }
       /// <summary>
       /// 邀请人数
       /// </summary>
       public byte invitedAmount { get; set; }
       /// <summary>
       /// 联系人姓名
       /// </summary>
       public string contactName { get; set; }
       /// <summary>
       /// 联系人电话
       /// </summary>
       public string contactTel { get; set; }
       /// <summary>
       /// 校内负责人姓名
       /// </summary>
       public string responsName { get; set; }
       /// <summary>
       /// 校内负责人电话
       /// </summary>
       public string responsTel { get; set; }
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
