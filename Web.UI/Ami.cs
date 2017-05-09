
using System;
using System.Web;
namespace Web.UI
{
    public class Ami
    {
        /// <summary>
        /// 获取对与错的图标
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static string GetStateStr(string state)
        {
            string str = "";
            if (state.Equals("1"))
            {
                str = "true";
            }
            else
            {
                str = "false";
            }
            return str;
        }
        /// <summary>
        /// 根据格式输出
        /// </summary>
        /// <param name="Time"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public static string DateTimeFormat(string Time,string f_datestyle)
        {
            string str = "";
            if (Base.Fun.fun.IsDate(Time))
            {
                str = Base.Fun.fun.Get_Date(DateTime.Parse(Time), f_datestyle);
            }
            return str;
        }
        /// <summary>
        /// 用户操作的时候给出对应的信息
        /// </summary>
        /// <param name="i">[-1]未登录，[0]错误，[1]正确</param>
        /// <param name="str">对应的提示信息</param>
        public static void Message(int i, string str)
        {
            HttpContext.Current.Response.Write("['" + i + "','" + str + "']");
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 用户操作的时候给出对应的信息
        /// </summary>
        /// <param name="i">[-1]未登录，[0]错误，[1]正确</param>
        /// <param name="js">JS字符串包括script字符</param>
        /// <param name="str">对应的提示信息</param>
        public static void Message(int i, string str, string js)
        {
            HttpContext.Current.Response.Write("['" + i + "','" + str + "']" + js);
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 获得URL验证信息 HttpUtility.UrlEncode
        /// </summary>
        /// <returns></returns>
        public static string NoUserSessionSetString()
        {
            return NoUserSessionSetString(Web.UI.Users.GetUserInfo().UserID, UI.Sys.SiteInfo.VerSion);
        }
        /// <summary>
        /// 获得URL验证信息 HttpUtility.UrlEncode
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="VerSion"></param>
        /// <returns></returns>
        public static string NoUserSessionSetString(string UserID, string VerSion)
        {
            string PassWord = Web.UI.Users.ViewPass(UserID);
            string cookiesname = Base.Fun.fun.GetRealIP() + "_" + UserID + "_" + PassWord + "_" + VerSion + "_" + DateTime.Now.ToString();
            cookiesname = Base.Fun.Zip.Compress(cookiesname);
            cookiesname = HttpUtility.UrlEncode(cookiesname);
            return cookiesname;
        }

        /// <summary>
        /// 得到的值
        /// </summary>
        /// <param name="cookies"></param>
        /// <returns></returns>
        public static bool NoUserSessionGetStringBool(string cookies)
        {
            bool bo = false;
            if (cookies.Length > 0)
            {
                try
                {
                    cookies = Base.Fun.Zip.DeCompress(cookies);
                }
                catch (Exception)
                { }
                string[] cookies1 = cookies.Split('_');
                if (cookies1.Length >= 5)
                {
                    if (cookies1[0].Equals(Base.Fun.fun.GetRealIP()) && cookies1[3].Equals(UI.Sys.SiteInfo.VerSion) && Base.Fun.fun.pnumeric(cookies1[1]) && Base.Fun.fun.IsDate(cookies1[4]) && Web.UI.Users.UserPassBool(cookies1[1], cookies1[2]))
                    {
                        bo = true;
                    }
                }
            }
            return bo;
        }
    }
}
