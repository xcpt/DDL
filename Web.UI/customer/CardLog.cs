using System;

namespace Web.UI.customer
{
    /// <summary>
    /// 卡变更日志
    /// </summary>
    public class CardLog
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="cardNo"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="cardlogtype"></param>
        /// <returns></returns>
        public static string View(string storesid, string cardNo, string starttime, string endtime, string cardlogtype)
        {
            DAL.customer.CardLog clDAL = new DAL.customer.CardLog();
            return clDAL.View(UI.Sys.SiteInfo.GetPageSize(), storesid, cardNo, starttime, endtime, cardlogtype);
        }
        /// <summary>
        /// 卡变更日志查询
        /// </summary>
        /// <param name="cardid">卡ID</param>
        /// <param name="cardlogtype"></param>
        /// <param name="content">操作内容</param>
        /// <returns></returns>
        public static void AddCardLog(Model.customer.CardLog clModel)
        {
            clModel.addtime = DateTime.Now.ToString();
            clModel.administratorid = Web.UI.Users.GetUserInfo().UserID;
            DAL.customer.CardLog clDAL = new DAL.customer.CardLog();
            clDAL.Insert(clModel);
        }
        /// <summary>
        /// 卡变更日志查询
        /// </summary>
        /// <param name="cardid">卡ID</param>
        /// <param name="cardlogtype"></param>
        /// <param name="content">操作内容</param>
        /// <returns></returns>
        public static void SysAddCardLog(Model.customer.CardLog clModel)
        {
            clModel.addtime = DateTime.Now.ToString();
            clModel.administratorid = "0";
            DAL.customer.CardLog clDAL = new DAL.customer.CardLog();
            clDAL.Insert(clModel);
        }
        /// <summary>
        /// 卡变更日志查询
        /// </summary>
        /// <param name="cardid">卡ID</param>
        /// <param name="cardlogtype"></param>
        /// <param name="content">操作内容</param>
        /// <returns></returns>
        public static void AppAddCardLog(Model.customer.CardLog clModel)
        {
            clModel.addtime = DateTime.Now.ToString();
            clModel.administratorid = "-1";
            DAL.customer.CardLog clDAL = new DAL.customer.CardLog();
            clDAL.Insert(clModel);
        }
    }
}
