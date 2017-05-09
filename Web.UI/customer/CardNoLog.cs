using System;
namespace Web.UI.customer
{
    /// <summary>
    /// 换卡日志
    /// </summary>
    public class CardNoLog
    {
        /// <summary>
        /// 添加换卡日志
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="oldCardNo"></param>
        /// <param name="newCardNo"></param>
        public static void AddCardNoLog(string storesid, string oldCardNo, string newCardNo)
        {
            Model.customer.CardNoLog cnlModel = new Model.customer.CardNoLog();
            cnlModel.addtime = DateTime.Now.ToString();
            cnlModel.administratorid = UI.Users.GetUserInfo().UserID;
            cnlModel.storesid = storesid;
            cnlModel.newcardNo = newCardNo;
            cnlModel.oldcardNo = oldCardNo;
            DAL.customer.CardNoLog cnlDAL = new DAL.customer.CardNoLog();
            cnlDAL.Insert(cnlModel);
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="oldcardNo"></param>
        /// <param name="newcardNo"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static string View(string storesid, string oldcardNo, string newcardNo, string starttime, string endtime)
        {
            DAL.customer.CardNoLog cnlDAL = new DAL.customer.CardNoLog();
            return cnlDAL.View(UI.Sys.SiteInfo.GetPageSize(), storesid, oldcardNo, newcardNo, starttime, endtime);
        }
    }
}
