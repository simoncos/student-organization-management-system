using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using STLHMODEL.COMMON;
using STLHDAL.COMMON;
using FrameWork;

namespace STLHWEB.HOMEPAGE
{
    public partial class publishNotice : System.Web.UI.Page
    {
        iMessage_DAL imd = new iMessage_DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
        }



        protected void putIn_Click(object sender, EventArgs e)
        {

            int type = -1;
            
            if (rb_Type0.Checked==true)
            {
                type = 0;
            } 
            else if(rb_Type1.Checked==true)
            {
                type = 1;
            }
            else if (rb_Type2.Checked == true)
            {
                type = 2;
            }
            else if (rb_Type3.Checked == true)
            {
                type = 3;
            }
            else if (rb_Type4.Checked == true)
            {
                type = 4;
            }
            ArrayList roles=new ArrayList();

            foreach(ListItem li in this.CheckBoxList1.Items)
            {
                if(li.Selected==true)
                {
                    roles.Add(li.Value);
                 }
             }
            string[] receive = tx_receiveId.Text.Split(new Char[] { ';', '；',',','，' }, StringSplitOptions.RemoveEmptyEntries);
            ArrayList receiveId = new ArrayList();
            foreach(string i in receive)
            {
                int t=imd.GetUserIdByStuId(i);
                if (t!=-1)
                {
                    receiveId.Add(t);
                } 
                else
                {

                }
                
            }
            string content = tahtml.Value.ToString();
            sendmessage(type, roles, receiveId, Common.Get_UserID, content);
        }

        public void sendmessage(int type,ArrayList role,ArrayList receiveId,int senderId,string content)
        {

        }

       
    }
}