using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STLHMODEL.STJS.STCL
{
    /// <summary>
    /// 社团申请信息
    /// </summary>  
    [Serializable]
     public class applyInfo
    {
        public applyInfo()
        {
            stName = "";
            stType="";
            presidentId = "";
            stuTel = "";
            stuDormitory = "";
            guideTeacher = "";
            guideUnit = "";
            DateTime applyDate = Convert.ToDateTime("1900-1-1");
            fee = 0;
            stApplication = "";
            presidentRecommend = "";
            stAppPic = "";
            unitPic = "";
            guideTeacherPic="";
            wordDocument = "";
            DateTime positiveDate = Convert.ToDateTime("1900-1-1");
            positiveName = "";
            stuName = "";
            stStates = 3;
            star = 0;

        }
        /// <summary>
        /// 社团名称
        /// </summary>
        public string stName { get; set;}
        /// <summary>
        /// 社团类别
        /// </summary>
        public string stType { get;set;}

        /// <summary>
        /// 状态
        /// </summary>
        public byte stStates { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string stuName { get; set; }
        /// <summary>
        /// 会长学号
        /// </summary>
        public string presidentId { get; set; }
        /// <summary>
        /// 会长联系方式
        /// </summary>
        public string stuTel { get; set; }
        /// <summary>
        /// 会长宿舍
        /// </summary>
        public string stuDormitory { get; set; }
        /// <summary>
        /// 指导教师
        /// </summary>
        public string guideTeacher { get; set; }
        /// <summary>
        /// 挂靠单位
        /// </summary>
        public string guideUnit { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime applyDate { get; set; }
        /// <summary>
        /// 会费
        /// </summary>
        public byte fee { get; set; }
        /// <summary>
        /// 社团申请书
        /// </summary>
        public string stApplication { get; set; }
        /// <summary>
        /// 会长自荐书
        /// </summary>
        public string presidentRecommend { get; set; }
        /// <summary>
        /// 社团成立申请书picture
        /// </summary>
        public string stAppPic { get; set; }
        /// <summary>
        /// 挂靠单位申请书picture
        /// </summary>
        public string unitPic { get; set; }
        /// <summary>
        /// 指导老师简介picture
        /// </summary>
        public string guideTeacherPic { get; set; }
        /// <summary>
        /// Word全书word
        /// </summary>
        public string wordDocument { get; set; }
       
        //todo:
        /// <summary>
        /// 转正时间
        /// </summary>
        public DateTime positiveDate { get; set; }
        /// <summary>
        /// 转正批准人姓名
        /// </summary>
        public string positiveName { get; set; }

        /// <summary>
        /// 社团星级
        /// </summary>
        public byte star { get; set; }

    }
}
