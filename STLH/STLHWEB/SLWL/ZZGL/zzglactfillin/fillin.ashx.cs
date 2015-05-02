using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using STLHDAL;

namespace STLHWEB.SLWL.ZZGL.zzglactfillin
{
    /// <summary>
    /// fillin 的摘要说明
    /// </summary>
    public class fillin : IHttpHandler
    {
         DataTable dl;
         ArrayList items = new ArrayList();
         ArrayList items1 = new ArrayList();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            
            string str = context.Request.QueryString["param"].ToString();
            context.Response.Write(GetSearchItems(str));
            context.Response.End();
        }
        public string GetSearchItems(string strQuery)
        {
            if (strQuery.Trim().Equals("")) { }
            else
            {
                    if (dl != null)
                    {
                        dl.Clear();
                        items.Clear();
                    }

                    string str = "select stuName,stuId from stuBasicInfo where stuName like '" + strQuery.Trim() + "%'";
                    //dl = DBHelp.GetDataTable(str);
                    SqlHelper sq=new SqlHelper();
                    dl = sq.ExecuteQuery(str, CommandType.Text);
                    for (int i = 0; i < dl.Rows.Count; i++)
                    {
                        items.Add(dl.Rows[i]["stuId"].ToString().Trim());
                        items1.Add(dl.Rows[i]["stuName"].ToString().Trim());

                    }
                    dl.Dispose();
            }
            //ArrayList selectItems = new ArrayList();
            string result = "";
            foreach (string str in items)
            {
                result += "," + str;
                //selectItems.Add(str);

            }
            foreach (string str in items1)
            {
                result += "," + str;
                //selectItems.Add(str);

            }
            //return selectItems;
            return result;
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