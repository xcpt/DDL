
namespace Web.UI.customer
{
    public class User_Stores_Consumption
    {
        /// <summary>
        /// 读取信息
        /// </summary>
        /// <param name="cardstoresid"></param>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string View(string storesid, string userid, string cardNo, string CommodityID, string swimteacherid, string name, string satisfactionid, string constoresid, string statustime, string endtime)
        {
            DAL.customer.User_Stores_Consumption uscDAL = new DAL.customer.User_Stores_Consumption();
            return uscDAL.View(100, storesid, userid, cardNo, CommodityID, swimteacherid, name, satisfactionid, constoresid, statustime, endtime);
        }
    }
}
