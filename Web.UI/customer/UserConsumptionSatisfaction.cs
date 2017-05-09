using System;

namespace Web.UI.customer
{
    /// <summary>
    /// 消费修改记录
    /// </summary>
    public class UserConsumptionSatisfaction
    {
        /// <summary>
        /// 修改消费信息
        /// </summary>
        /// <param name="adminid"></param>
        /// <param name="ucid"></param>
        /// <param name="type">0满意度，1为体重，2为身体，3游泳时长</param>
        /// <param name="oldsatisfactionid">原值</param>
        /// <param name="satisfactionid">新值</param>
        /// <param name="content"></param>
        public static bool UpdateUserConsumptionSatisfaction(string storesid, string userid, string adminid, string ucid, string type, string oldsatisfactionid, string satisfactionid, string content)
        {
            DAL.customer.UserConsumptionSatisfaction ucsDAL = new DAL.customer.UserConsumptionSatisfaction();
            Model.customer.UserConsumptionSatisfaction ucsModel = new Model.customer.UserConsumptionSatisfaction();
            ucsModel.addtime = DateTime.Now.ToString();
            ucsModel.administratorid = adminid;
            ucsModel.type = type;
            ucsModel.content = content;
            ucsModel.oldsatisfactionid = oldsatisfactionid;
            ucsModel.satisfactionid = satisfactionid;
            ucsModel.UserConsumptionID = ucid;
            ucsModel.num = ucsDAL.View_Num(storesid, userid, ucid);
            return Base.Fun.fun.pnumeric(ucsDAL.Insert(ucsModel));
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="cardNo"></param>
        /// <param name="name"></param>
        /// <param name="administratorid"></param>
        /// <param name="statustime"></param>
        /// <param name="endtime"></param>
        /// <param name="adminstatustime"></param>
        /// <param name="adminendtime"></param>
        /// <returns></returns>
        public static string View(string storesid, string ucid, string cardNo, string name, string administratorid, string statustime, string endtime, string adminstatustime, string adminendtime)
        {
            DAL.customer.UserConsumptionSatisfaction ucsDAL = new DAL.customer.UserConsumptionSatisfaction();
            return ucsDAL.View(UI.Sys.SiteInfo.GetPageSize(), storesid, ucid, cardNo, name, administratorid, statustime, endtime, adminstatustime, adminendtime);
        }
    }
}
