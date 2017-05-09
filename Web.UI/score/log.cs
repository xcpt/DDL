using System;

namespace Web.UI.score
{
    /// <summary>
    /// 积分日志
    /// </summary>
    public class log
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="name"></param>
        /// <param name="mobile"></param>
        /// <param name="type"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static string View(string storesid, string name, string mobile, string type, string starttime, string endtime)
        {
            DAL.score.log lDAL = new DAL.score.log();
            return lDAL.View(UI.Sys.SiteInfo.GetPageSize(), storesid, name, mobile, type, starttime, endtime);
        }
        /// <summary>
        /// 积分对换添加日志(并增加用户积分）
        /// </summary>
        /// <param name="storesid">门店</param>
        /// <param name="userid"></param>
        /// <param name="type">0为系统自动，1为积分兑换，2为手动增加</param>
        /// <param name="num"></param>
        /// <param name="content"></param>
        public static string AddLog(string storesid, string userid, string type, string num, string content)
        {
            DAL.score.log lDAL = new DAL.score.log();
            Model.score.log lModel = new Model.score.log();
            lModel.storesid = storesid;
            lModel.addtime = DateTime.Now.ToString();
            lModel.rulenum = num;
            lModel.content = content;
            lModel.type = type;
            lModel.userid = userid;
            string id = lDAL.Insert(lModel);

            DAL.customer.User uDAL = new DAL.customer.User();
            uDAL.Update_scorenum(userid, num);
            return id;
        }
    }
}
