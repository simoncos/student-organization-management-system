using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrameWork;

namespace STLHWEB.LOGIN
{
    public partial class loginOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FrameWorkLogin.UserOut();
                Response.Redirect("Login.aspx");
            }
        }
    }
}