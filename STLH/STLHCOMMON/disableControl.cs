using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;//加入命名空间
using System.Web.UI.WebControls;//加入命名空间

namespace STLHCOMMON
{
    public class disableControl
    {
        /// <summary>
        /// 将页面所有控件disable  
        /// </summary>
        /// <param name="c">当前页面指针，一般为this</param>
       public static  void disableAllControl(Control c)
        {
            if (c is WebControl)
            {
                ((WebControl)c).Enabled = false;
                ((WebControl)c).Style["cursor"] = "not-allowed";
                if (c is TextBox)
                {
                    ((WebControl)c).Style["background-color"] = "white";
                }
            }
            if (c.HasControls() == false)
            {
                return;
            }
            foreach (Control child in c.Controls)
            {
                disableAllControl(child);
            }
        }
       /// <summary>
       /// 将页面中除了Button控件disable  
       /// </summary>
       /// <param name="c">当前页面指针，一般为this</param>
       public static void disableExceptBtn(Control c)
       {
           if (c is WebControl)
           {
               ((WebControl)c).Enabled = false;
               ((WebControl)c).Style["cursor"] = "not-allowed";
               if (c is TextBox)
               {
                   ((WebControl)c).Style["background-color"] = "white";
               }
               if(c is Button){
                   ((Button)c).Enabled = true;
                   ((WebControl)c).Style["cursor"] = "pointer";
               }

           }
           if (c.HasControls() == false)
           {
               return;
           }
           foreach (Control child in c.Controls)
           {
               disableExceptBtn(child);


           }
       }
       /// <summary>
       /// 将页面中除了ImageButton控件disable 
       /// </summary>
       /// <param name="c">当前页面指针，一般为this</param>
       public static void disableExceptImageButton(Control c)
       {
           if (c is WebControl)
           {
               ((WebControl)c).Enabled = false;
               if (c is TextBox)
               {
                   ((WebControl)c).Style["background-color"] = "white";
               }
               if (c is ImageButton)
               {
                   ((ImageButton)c).Enabled = true;
               }

           }
           if (c.HasControls() == false)
           {
               return;
           }
           foreach (Control child in c.Controls)
           {
               disableExceptImageButton(child);
           }
       }
       /// <summary>
       /// 将页面所有控件able  
       /// </summary>
       /// <param name="c">当前页面指针，一般为this</param>
       public static void ableAllControl(Control c)
       {
           if (c is WebControl)
           {
               ((WebControl)c).Enabled = true;
               ((WebControl)c).Style["cursor"] = "default";
               if (c is TextBox)
               {
                   ((WebControl)c).Style["background-color"] = "white";
               }
           }
           if (c.HasControls() == false)
           {
               return;
           }
           foreach (Control child in c.Controls)
           {
               ableAllControl(child);
           }
       }
    }

}
