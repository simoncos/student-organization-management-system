using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLHMODEL.STJS.STCL;
using STLHIDAL.STJS.STCL;
using STLHCOMMON;
using System.Data;
using System.Data.SqlClient;

namespace STLHDAL.STJS.STCL
{
    /// <summary>
    /// 社团申请信息类
    /// </summary>
    public  class applyInfo_DAL:applyInfo_IDAL
    {
        #region 社团申请信息参数数组

        /// <summary>
        /// 在applyInfo.cs中定义了这些属性
        /// </summary>
        private const string PARA_STNAME = "@stName";
        private const string PARA_STTYPE = "@stType";
        private const string PARA_PRESIDENTID = "@presidentId";
        private const string PARA_STUTEL = "@stuTel";
        private const string PARA_STUDORMITORT = "@stuDormitory";
        private const string PARA_GUIDETEACHER = "@guideTeacher";
        private const string PARA_GUIDEUNIT = "@guideUnit";
        private const string PARA_FEE = "@fee";
        private const string PARA_APPLYDATE = "@applyDate";
        private const string PARA_STAPPLICATION = "@stApplication";
        private const string PARA_PRESIDENTRECOMMEND = "@presidentRecommend";
        private const string PARA_STAPPPIC = "@stAppPic";
        private const string PARA_UNITPIC= "@unitPic";
        private const string PARA_GUIDETEACHERPIC = "@guideTeacherPic";
        private const string PARA_WORDDOCUMENT = "@wordDocument";

        private const string PARA_POSITIVEDATE = "@positiveDate ";
        private const string PARA_POSITIVENAME = "@positiveName ";
        private const string PARA_POSITIVEID = "@positiveId";
        private const string PARA_STSTATES = "@stStates";
        private const string PARA_STAR = "@star";

#endregion


        #region 添加社团申请信息

        /// <summary>
        /// 添加社团申请信息
        /// </summary>
        /// <param name="a_applyInfo"> 社团申请信息</param>
        /// <returns>数据库受影响行数0错1对-1出现异常</returns>
        public int addApplyInfo(applyInfo a_applyInfo)
        {
            
            SqlParameter[] param = new SqlParameter[]
            {
                
                new SqlParameter(PARA_STNAME,a_applyInfo.stName),
                new SqlParameter(PARA_PRESIDENTID,a_applyInfo.presidentId),
                new SqlParameter(PARA_STTYPE,a_applyInfo.stType),
                new SqlParameter(PARA_STUTEL,a_applyInfo.stuTel),
                new SqlParameter(PARA_FEE,a_applyInfo.fee),
                new SqlParameter(PARA_STUDORMITORT,a_applyInfo.stuDormitory),
                new SqlParameter(PARA_GUIDETEACHER,a_applyInfo.guideTeacher),
                new SqlParameter(PARA_GUIDEUNIT,a_applyInfo.guideUnit),
                new SqlParameter(PARA_APPLYDATE,a_applyInfo.applyDate),
                new SqlParameter(PARA_STAPPLICATION,a_applyInfo.stApplication),
                new SqlParameter(PARA_PRESIDENTRECOMMEND,a_applyInfo.presidentRecommend),
                new SqlParameter(PARA_STAPPPIC,a_applyInfo.stAppPic),
                new SqlParameter(PARA_UNITPIC,a_applyInfo.unitPic),
                new SqlParameter(PARA_GUIDETEACHERPIC,a_applyInfo.guideTeacherPic),
                new SqlParameter(PARA_WORDDOCUMENT,a_applyInfo.wordDocument),
                new SqlParameter(PARA_STSTATES,a_applyInfo.stStates)
            };
            try
            {
                SqlHelper sq = new SqlHelper();
                int dr = sq.ExecuteNonQuery("p_stclApply", param, CommandType.StoredProcedure);
                if (dr >0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch(Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw ex;
            }

        }
        #endregion

        #region 通过社长(会长)学号获取社团申请信息

        /// <summary>
        /// 通过社长(会长)学号获取社团申请信息
        /// </summary>
        /// <param name="UserId">社长(会长)学号</param>
        /// <returns>返回社团申请信息</returns>
        public applyInfo getApplyInfo(string presidentId)
        {
            applyInfo a_applyInfo = new applyInfo();
            string str = "select * from View_stclSaveInfo where presidentId=@presidentId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter(PARA_PRESIDENTID,presidentId)
            };
            try
            {
                SqlHelper sq = new SqlHelper();
                SqlDataReader dr = sq.ExecuteDataReader(str, param, CommandType.Text);
                if (dr.Read())
                {
                    a_applyInfo.stName = dr["stName"].ToString().Trim();
                    a_applyInfo.presidentId = dr["presidentId"].ToString().Trim();
                    a_applyInfo.stType = dr["stType"].ToString().Trim();

                    string feeFlag = dr["fee"].ToString().Trim();
                    if (feeFlag == "")
                    {
                        a_applyInfo.fee = 0;
                    }
                    else
                    {
                        a_applyInfo.fee = Convert.ToByte(dr["fee"].ToString().Trim());
                    }



                    a_applyInfo.stuTel = dr["stuTel"].ToString().Trim();
                    a_applyInfo.stuDormitory = dr["stuDormitory"].ToString().Trim();
                    a_applyInfo.guideTeacher = dr["guideTeacher"].ToString().Trim();
                    a_applyInfo.guideUnit = dr["guideUnit"].ToString().Trim();

                    DateTime Flag = Convert.ToDateTime("1900-1-1");//系统健壮性！！！
                    string applyDateFlag = dr["applyDate"].ToString().Trim();
                    if (applyDateFlag == "")
                    {
                        a_applyInfo.applyDate = Flag;
                    }
                    else
                    {
                        a_applyInfo.applyDate = Convert.ToDateTime(dr["applyDate"].ToString().Trim());
                    }

                    
                    a_applyInfo.stApplication = dr["stApplication"].ToString().Trim();
                    a_applyInfo.presidentRecommend = dr["presidentRecommend"].ToString().Trim();
                    a_applyInfo.stAppPic = dr["stAppPic"].ToString().Trim();
                    a_applyInfo.unitPic = dr["unitPic"].ToString().Trim();
                    a_applyInfo.guideTeacherPic = dr["guideTeacherPic"].ToString().Trim();
                    a_applyInfo.wordDocument = dr["wordDocument"].ToString().Trim();
                    dr.Dispose();
                    return a_applyInfo;

                }
                else
                {
                    dr.Dispose();
                    return null;
                }
            }
            catch (System.Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }
            finally
            {
                
            }
        }
#endregion

        #region 通过会长学号获取社团基本信息
        ///<summary>
        /// 通过会长学号获取社团基本信息
        ///</summary>
        ///<param name="UserId">社长(会长)学号</param>
        /// <returns>返回社团基本信息或null</returns>
        public applyInfo getSTBasicInfo(string presidentId){

            applyInfo a_applyInfo = new applyInfo();
            string str = "select * from View_stBasicInfo where presidentId=@presidentId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter(PARA_PRESIDENTID,presidentId)
            };
            try
            {
                SqlHelper sq = new SqlHelper();
                SqlDataReader dr = sq.ExecuteDataReader(str, param, CommandType.Text);
                if (dr.Read())
                {
                    a_applyInfo.stName = dr["stName"].ToString().Trim();
                    a_applyInfo.presidentId = dr["presidentId"].ToString().Trim();
                    a_applyInfo.stType = dr["stType"].ToString().Trim();
                    a_applyInfo.fee = Convert.ToByte(dr["fee"].ToString().Trim());
                    a_applyInfo.stuTel = dr["stuTel"].ToString().Trim();
                    a_applyInfo.stuDormitory = dr["stuDormitory"].ToString().Trim();
                    a_applyInfo.guideTeacher = dr["guideTeacher"].ToString().Trim();
                    a_applyInfo.guideUnit = dr["guideUnit"].ToString().Trim();

                    a_applyInfo.stApplication = dr["stApplication"].ToString().Trim();
                    a_applyInfo.presidentRecommend = dr["presidentRecommend"].ToString().Trim();
                    a_applyInfo.stAppPic = dr["stAppPic"].ToString().Trim();
                    a_applyInfo.unitPic = dr["unitPic"].ToString().Trim();
                    a_applyInfo.guideTeacherPic = dr["guideTeacherPic"].ToString().Trim();
                    a_applyInfo.wordDocument = dr["wordDocument"].ToString().Trim();

                    DateTime Flag = Convert.ToDateTime("1900-1-1");//系统健壮性！！！
                    string applyDateFlag = dr["applyDate"].ToString().Trim();
                    if (applyDateFlag == "")
                    {
                        a_applyInfo.applyDate = Flag;
                    }
                    else
                    {
                        a_applyInfo.applyDate = Convert.ToDateTime(dr["applyDate"].ToString().Trim());
                    }


               
                    string positiveDateFlag = dr["positiveDate"].ToString().Trim();
                    if (positiveDateFlag == "")
                    {
                        a_applyInfo.positiveDate = Flag;
                    }
                    else
                    {
                        a_applyInfo.positiveDate = Convert.ToDateTime(dr["positiveDate"].ToString().Trim());
                    }

      
                    a_applyInfo.positiveName = dr["positiveName"].ToString().Trim();
                    return a_applyInfo;

                }
                else
                {
                    return null;
                }
            }
            catch (System.Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }

        }
#endregion

        #region  通过提交申请时间、通过审核时间是否为空 获取待审核社团信息列表
         ///<summary>
        /// 通过提交申请时间、通过审核时间是否为空 获取待审核社团信息列表
        ///</summary>
        ///<param name="applyDate">申请时间</param>
        ///<param name="positiveDate">审核时间</param>
        /// <returns>查询结果集</returns>
        public  List<applyInfo> queryExamListInfo(){

        
            //string str = "select View_stBasicInfo.presidentId,stName,stuName,stuTel,applyDate,stStates from View_stBasicInfo,stclApplyAmendments where positiveDate is null and applyDate is not null and opinionDate is not null and stStates=1";
            string str = "select distinct View_stBasicInfo.presidentId,stName,stuName,stuTel,applyDate,stStates from View_stBasicInfo where stStates=1";
            try
            {
                SqlHelper sq = new SqlHelper();
                List<applyInfo> a_applyInfo_list = new List<applyInfo>();
                 using(SqlDataReader dr = sq.ExecuteDataReader(str, CommandType.Text))
                {
                    while (dr.Read())
                    {
                        applyInfo a_applyInfo = new applyInfo();
                    a_applyInfo.presidentId = dr["presidentId"].ToString().Trim();
                    a_applyInfo.stName = dr["stName"].ToString().Trim();
                    a_applyInfo.stuName=dr["stuName"].ToString().Trim();
                    a_applyInfo.stuTel = dr["stuTel"].ToString().Trim();
                    a_applyInfo.applyDate = Convert.ToDateTime(dr["applyDate"].ToString().Trim());
                    a_applyInfo_list.Add(a_applyInfo);
                    }
                     dr.Close();
                    return a_applyInfo_list;
            }}
            catch (System.Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }

        }
#endregion

        #region 社团申请通过审核
        /// <summary>
        /// 社团申请通过审核
        /// </summary>
        /// <param name="presidentId"></param>
        /// <param name="positiveId"></param>
        /// <returns></returns>
        public int stApplyPassInfo(string presidentId,string positiveId,byte fee,byte stStates)
        {
            try
            {
                DateTime positiveDate = DateTime.Now;//修改状态
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter(PARA_POSITIVEDATE,positiveDate),
                    new SqlParameter(PARA_POSITIVEID,positiveId),
                    new SqlParameter(PARA_PRESIDENTID,presidentId),
                    new SqlParameter(PARA_FEE,fee),
                    new SqlParameter(PARA_STSTATES,stStates)
                
                };
                SqlHelper sq = new SqlHelper();
                //Todo 3-24:
                int dr = sq.ExecuteNonQuery("p_stclPass", param, CommandType.StoredProcedure);
                if (dr > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch (System.Exception ex)
            {
                ErrorHandler.WriteError(ex);
                throw;
            }

        }
        #endregion

    }
}
