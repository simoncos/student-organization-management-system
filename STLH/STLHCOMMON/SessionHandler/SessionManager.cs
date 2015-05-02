using System.Web;

/// <summary>
/// session管理类（泛型）
/// </summary>
/// <typeparam name="T"></typeparam>
public  class SessionManager<T>
{
    /// <summary>
    /// 获取session对象
    /// </summary>
    /// <param name="key">对象名</param>
    /// <returns>对象值</returns>
    public static  T GetSessionObject(string key)
    {
         object  obj = HttpContext.Current.Session[key];
        if (obj == null)
            return default(T);
        else
            return (T)obj;
    }
    /// <summary>
    /// 添加session对象
    /// </summary>
    /// <param name="key">对象名</param>
    /// <param name="obj">对象值</param>
    public static void SetSessionObject(string key, T obj)
    {
        HttpContext.Current.Session[key] = obj;
    }
}
