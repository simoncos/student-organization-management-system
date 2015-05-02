using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLHIDAL.COMMON;
using STLHMODEL.COMMON;
using System.Data;
using System.Data.SqlClient;
using STLHCOMMON;

namespace STLHDAL.COMMON
{
   

    /// <summary>
    /// 消息实体数据类
    /// </summary>
    public class iMessage_DAL:iMessage_IDAL
    {   private const string PARA_CONTENT = "@content";
        private const string PARA_title = "@title";
        private const string PARA_sendName = "@sendName";
        private const string PARA_sendStuId = "@sendStuId";

        private const string PARA_messageId = "@messageId";
        private const string PARA_senderId = "@senderId";
         private const string PARA_receiverId= "@receiverId";
         private const string PARA_type = "@type";
         private const string PARA_status = "@status";
         private const string PARA_sendtime = "@sendtime";
         private const string PARA_readtime = "@readtime";
         private const string PARA_receiveisdelete = "@receiveisdelete";


                private const string PARA_sendisdelete = "@sendisdelete";
       private const string PARA_iscallback = "@iscallback";
        private const string PARA_backMessageId = "@backMessageId";
        private const string PARA_receiveStuId = "@receiveStuId";
        private const string PARA_receiveName = "@receiveName";
        private const string PARA_LOGINID = "@stuId";

        public List<iMessage> getPerMessagesByUserId(int userId)
        {
            try
            {
                SqlHelper sq = new SqlHelper();
                List<iMessage> iMessage_list = new List<iMessage>();
                SqlParameter[] param = new SqlParameter[]
                 { 

                    new SqlParameter(PARA_receiverId,userId),
                 };
                string str = "select top 10 title,content,sendName,sendtime,readtime from View_iMessage  where receiverId=@receiverId and receiveisdelete=0 and type=4 or type=1 and  receiverId in (select R_RoleID from sys_UserRoles where R_UserID=@receiverId) or type=0 or  type=3 or type=2 and  exists(select R_RoleID from sys_UserRoles where R_UserID=@receiverId) order by sendtime desc ";
                    using (SqlDataReader dr = sq.ExecuteDataReader(str, param, CommandType.Text))//一定要加param，对应上面的param数组
                {
                    while (dr.Read())
                    {
                        iMessage iMessageInfo = new iMessage();
                        iMessageInfo.content=dr["content"].ToString().Trim();
                        iMessageInfo.sendName = dr["sendName"].ToString().Trim();
                        iMessageInfo.sendtime = timeForm.foreTimeToDb(dr["sendtime"].ToString().Trim());
                        iMessageInfo.readtime =timeForm.foreTimeToDb(dr["readtime"].ToString().Trim());
                        iMessageInfo.title = dr["title"].ToString().Trim();


                        iMessage_list.Add(iMessageInfo);
                    }   
                    dr.Close();
                    return iMessage_list;
                }
            }
            catch (System.Exception ex)
            {
                ErrorHandler.WriteError(ex);
                //return new List<jlBasicInfo>();
                throw;
            }
            
        }

        public bool sendMessage(iMessage cMessage)
        {

            return false;
        }

        public List<iMessage> getGerMessages()
        {
             List<iMessage> a=new List<iMessage>();
            return a;
        }
        public List<iRole> getRoleInfo()
        {
            SqlHelper sq = new SqlHelper();
            List<iRole> ir_list=new List<iRole>();
            string str="select RoleID,R_RoleName from sys_Roles";
            SqlDataReader dr=sq.ExecuteDataReader(str, CommandType.Text);
            while (dr.Read())
            {
                iRole ir = new iRole();
                ir.RoleID = Convert.ToInt32(dr["RoleID"]);
                ir.R_RoleName = dr["R_RoleName"].ToString().Trim();
                ir_list.Add(ir);
            }
            return ir_list;
        }

        #region "根据学号获取用户Id"
        /// <summary>
        /// 根据学号获取用户Id
        /// </summary>
        public int GetUserIdByStuId(string stuId)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter(PARA_LOGINID, stuId)
            };
            try
            {
                string str = "select UserID from sys_User where U_LoginName=@stuId";
                SqlHelper sq = new SqlHelper();
                SqlDataReader dr = sq.ExecuteDataReader(str, param, CommandType.Text);
                if (dr.Read())
                {
                    return Convert.ToInt32(dr["UserID"]);
                }
                else
                {
                    return -1;
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
