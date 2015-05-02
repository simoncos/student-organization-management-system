using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using STLHMODEL.COMMON;
using STLHDAL.COMMON;
using FrameWork;
using FrameWork.Components;
namespace STLHWEB.HOMEPAGE
{
    /// <summary>
    /// personalCenter1 的摘要说明
    /// </summary>
    public class personalCenter1 : IHttpHandler
    {
        iMessage im=new iMessage();
        iMessage_DAL imd=new iMessage_DAL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string str = context.Request.QueryString["param"].ToString();
            if (str=="pc")
            {
                context.Response.Write(getNewNotice());
            }
            //else if (str == "type1")
            //{
            //    context.Response.Write(getType1());
            //}

            context.Response.End();
        }


        /// <summary>
        /// 通过userid获取最新消息
        /// </summary>
        /// <returns></returns>
        public string getNewNotice(){
            
            StringBuilder resultReturn = new StringBuilder();
            
            string ulhtml=@"<ul>{0}
				</ul>";
           
            StringBuilder nlihtml = new StringBuilder();        
            IList<iMessage>  iMessage_list=new List<iMessage>();
            iMessage_list = imd.getPerMessagesByUserId(Common.Get_UserID);
            if (iMessage_list.Count<1)
            {
                return "无消息";
            } 
            else
            {
                foreach(iMessage i in iMessage_list){
                     string lihtml=@"<li>
                        <span>[{0}][{1}]</span>
                        <a href='{2}' title='{5}'>{3}</a>
                        {4}
					</li>";
                    string str1="";
                    if (i.readtime == Convert.ToDateTime("1900-1-1 00:00:00"))
                    {
                         str1 = "<img src='/MASTER/perCenterM/new.gif' border='0' style='height:9px;width:21px;' alt=''/> ";
                    } 
                    else
                    {
                        str1 = "";
                    }
                    string temp = Common.leftx(i.title,30)+"...";
                   lihtml = string.Format(lihtml,i.sendName,i.sendtime.ToShortDateString(),"#",temp,str1,i.title);    
                nlihtml.Append(lihtml);
                }
                ulhtml=string.Format(ulhtml,nlihtml);
            }
            return ulhtml;
        
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}