using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace STLHMODEL.COMMON
{
    /// <summary>
    /// 学生基本信息
    /// </summary>
    [Serializable]
    public class stuBasicInfo
    {
       /// <summary>
       /// 学生学号
       /// </summary>
       public string stuId { get; set; }
       /// <summary>
       /// 学生姓名
       /// </summary>
       public string stuName { get; set; }
       /// <summary>
       /// 学生性别
       /// </summary>
       public string stuGender { get;set;}
       /// <summary>
       /// 出生日期
       /// </summary>
       public string stuBirth { get; set; }
       /// <summary>
       /// 联系方式
       /// </summary>
       public string stuTel { get; set; }
       /// <summary>
       /// 宿舍
       /// </summary>
       public string stuDormitory { get; set; }
    }
}
