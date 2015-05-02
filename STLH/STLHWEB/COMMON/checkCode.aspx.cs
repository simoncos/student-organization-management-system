using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using STLHCOMMON;
using System.Drawing;

namespace STLHWEB.COMMON
{
    public partial class checkCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string validateNum = CreateRandomNum(4);

                CreateImage(validateNum);
                Session["ValidateNum"] = validateNum;//保存验证码
            }
        }
        private string CreateRandomNum(int NumCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] allCharArry = allChar.Split(',');//拆分成数组
            string randomNum = "";
            int temp = -1;//记录上次随机数的数值，尽量避免产生几个相同的随机数
            Random rand = new Random();
            for (int i = 0; i < NumCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(35);
                if (temp == 1)
                {
                    return CreateRandomNum(NumCount);
                }
                temp = t;
                randomNum += allCharArry[t];
            }
            return randomNum;
        }
        private void CreateImage(string validateNum)
        {//将字符串validatenum转换为图形码
            if (validateNum == null || validateNum.Trim() == string.Empty) { return; }
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(validateNum.Length * 12 + 10, 22);
            Graphics g = Graphics.FromImage(image);
            try
            {
                Random random = new Random();//生成随机生成器
                g.Clear(Color.White);//清空图片背景色
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }
                Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
                System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(validateNum, font, brush, 2, 2);//背景噪音线
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }//前景噪音点
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);//图片边框线
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                Response.ClearContent();
                Response.ContentType = "image/Gif";
                Response.BinaryWrite(ms.ToArray());//图形保存到指定流
            }
            finally { g.Dispose(); image.Dispose(); }
        }


    }
}