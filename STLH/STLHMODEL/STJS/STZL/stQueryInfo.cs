using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STLHMODEL.STJS.STZL
{
    /// <summary>
    /// 社团基本信息
    /// </summary>
    [Serializable]
    public class stQueryInfo
    {
        public stQueryInfo()
        {
            stId = "";
            stName = "";
            star = 0;
            topTen = "";
            presidentId = "";
            presidentName = "";
            stuTel = "";
            stuDormitory = "";
            stuEmail = "";
            stuQQ = "";
            positiveId = "";
            stType = "";
            guideTeacher = "";
            guideUnit = "";
            fee = 0;
            DateTime applyDate = Convert.ToDateTime("1900-1-1");
            DateTime positiveDate = Convert.ToDateTime("1900-1-1");
        }
        /// <summary>
        /// 社团标示号
        /// </summary>
        public string stId { get; set; }
        /// <summary>
        /// 社团名称
        /// </summary>
        public string stName { get; set; }
        /// <summary>
        /// 社团星级
        /// </summary>
        public byte star { get; set; }
        /// <summary>
        /// 十佳称号
        /// </summary>
        public string topTen { get; set; }
        /// <summary>
        /// 会长学号
        /// </summary>
        public string presidentId { get; set; }
        /// <summary>
        /// 会长姓名
        /// </summary>
        public string presidentName { get; set; }
        /// <summary>
        /// 会长电话
        /// </summary>
        public string stuTel { get; set; }
        /// <summary>
        /// 会长QQ
        /// </summary>
        public string stuQQ { get; set; }
        /// <summary>
        /// 会长宿舍
        /// </summary>
        public string stuDormitory { get; set; }
        ///<summary>
        ///会长邮箱
        ///</summary>
        public string stuEmail { get; set; }
        /// <summary>
        /// 转正批准人学号
        /// </summary>
        public string positiveId { get; set; }
        /// <summary>
        /// 社团类别
        /// </summary>
        public string stType { get; set; }
        /// <summary>
        /// 指导教师
        /// </summary>
        public string guideTeacher { get; set; }
        /// <summary>
        /// 挂靠单位
        /// </summary>
        public string guideUnit { get; set; }
        /// <summary>
        /// 会费
        /// </summary>
        public byte fee { get; set; }
        /// <summary>
        /// 申请提交时间
        /// </summary>
        public DateTime applyDate { get; set; }
        /// <summary>
        /// 转正时间
        /// </summary>
        public DateTime positiveDate { get; set; }    
    }
}
