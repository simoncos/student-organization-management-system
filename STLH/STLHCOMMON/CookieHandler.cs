using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Web;
using STLHCOMMON.Enum;

namespace STLHCOMMON
{

    /// <summary>
    /// Cookie Key
    /// </summary>
    public class CookieKey
    {
        /// <summary>
        /// 验证码Key
        /// </summary>
        public const string VerificationCode = "VerificationCode";

        /// <summary>
        /// 用户名Key
        /// </summary>
        public const string stuId = "stuId";
    }

    #region Cookie管理类

    /// <summary>
    /// Cookie管理类
    /// </summary>
    public class CookieHandler
    {
        /// <summary>
        /// 写入Cookie(Cookie将在浏览器关闭时删除)
        /// </summary>
        /// <param name="name">Cookie名称</param>
        /// <param name="value">Cookie值</param>
        public static void SetCookie(string name, string value)
        {
            HttpCookie cookie = new HttpCookie(name);
            cookie.Value = EncryptHandler.SymmetricEncrypts(value, EncryptHandler.key);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 写入Cookie
        /// </summary>
        /// <param name="name">Cookie名称</param>
        /// <param name="value">Cookie值</param>
        /// <param name="cookietime">Cookie时间的单位，枚举值</param>
        /// <param name="time">Cookie的有效时间</param>
        public static void SetCookie(string name, string value, CookieTime cookietime, int time)
        {
            HttpCookie cookie = new HttpCookie(name);
            cookie.Value = EncryptHandler.SymmetricEncrypts(value, EncryptHandler.key);
            switch (cookietime)
            {
                case CookieTime.Milliseconds:
                    cookie.Expires = DateTime.Now.AddMilliseconds(Convert.ToDouble(time));
                    break;
                case CookieTime.Seconds:
                    cookie.Expires = DateTime.Now.AddSeconds(Convert.ToDouble(time));
                    break;
                case CookieTime.Minutes:
                    cookie.Expires = DateTime.Now.AddMinutes(Convert.ToDouble(time));
                    break;
                case CookieTime.Hours:
                    cookie.Expires = DateTime.Now.AddHours(Convert.ToDouble(time));
                    break;
                case CookieTime.Days:
                    cookie.Expires = DateTime.Now.AddDays(Convert.ToDouble(time));
                    break;
                case CookieTime.Months:
                    cookie.Expires = DateTime.Now.AddMonths(time);
                    break;
                case CookieTime.Years:
                    cookie.Expires = DateTime.Now.AddYears(time);
                    break;
            }
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 写入Cookie集合(不提供加密)
        /// </summary>
        /// <param name="name">Cookie名称</param>
        /// <param name="keys">键</param>
        /// <param name="values">值</param>
        public static void SetCookie(string name, string[] keys, string[] values)
        {
            HttpCookie cookie = new HttpCookie(name);
            int num = keys.Length;
            for (int i = 0; i < num; i++)
                cookie.Values.Add(keys[i], values[i]);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 获取Cookie
        /// </summary>
        /// <param name="name">Cookie名称</param>
        public static string GetCookie(string name)
        {
            string result = string.Empty;
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie != null)
                result = EncryptHandler.SymmectricDecrypts(cookie.Value, EncryptHandler.key);
            return result;
        }

        /// <summary>
        /// 获取Cookie集合
        /// </summary>
        /// <param name="name">Cookie名称</param>
        /// <param name="keys">键</param>
        /// <returns></returns>
        public static Hashtable GetCookie(string name, string[] keys)
        {
            Hashtable hb = new Hashtable();
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie != null)
            {
                int num = cookie.Values.Count;
                for (int i = 0; i < num; i++)
                    hb.Add(keys[i], cookie[keys[i]]);
                return hb;
            }
            else
                return null;
        }
    }
#endregion

}
