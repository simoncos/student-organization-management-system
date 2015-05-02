using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STLHMODEL.SLWL.DWJL
{
    /// <summary>
    /// 对外交流联络信息
    /// </summary>
    [Serializable]
    public class jlContactInfo
    {
        public jlContactInfo()
        {
            fillId = "";
            fillName = "";
            contactSchool = "";
            contactOrganization = "";
            contactName = "";
            contactPosition = "";
            contactTel="";
            contactEmail = "";
            fillDate = Convert.ToDateTime("1900-1-1");

        }
        /// <summary>
        /// 填表人学号
        /// </summary>
        public string fillId { get; set; }
        /// <summary>
        /// 填表人姓名
        /// </summary>
        public string fillName { get; set; }
        /// <summary>
        /// 联络学校
        /// </summary>
        public string contactSchool { get; set; }
        /// <summary>
        /// 联络组织
        /// </summary>
        public string contactOrganization { get; set; }
        /// <summary>
        /// 联络人姓名
        /// </summary>
        public string contactName { get; set; }
        /// <summary>
        /// 联络人职务
        /// </summary>
        public string contactPosition { get; set; }
        /// <summary>
        /// 联络电话
        /// </summary>
        public string contactTel { get; set; }
        /// <summary>
        /// 联络邮箱
        /// </summary>
        public string contactEmail { get; set; }
        /// <summary>
        /// /填表时间
        /// </summary>
        public DateTime fillDate { get; set; }
    }
}
