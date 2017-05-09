
namespace Web.UI.customer
{
    /// <summary>
    /// 消费
    /// </summary>
    public class UserConsumption
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="cardNo"></param>
        /// <param name="CommodityID"></param>
        /// <param name="swimteacherid"></param>
        /// <param name="name"></param>
        /// <param name="satisfactionid"></param>
        /// <param name="statustime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static string View(string storesid,string userid, string cardNo, string CommodityID, string swimteacherid, string name, string satisfactionid, string statustime, string endtime)
        {
            DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
            return ucDAL.View(100, storesid, userid, cardNo, CommodityID, swimteacherid, name, satisfactionid, statustime, endtime);
        }
        /// <summary>
        /// 显示取消
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="cardNo"></param>
        /// <param name="CommodityID"></param>
        /// <param name="swimteacherid"></param>
        /// <param name="name"></param>
        /// <param name="satisfactionid"></param>
        /// <param name="statustime"></param>
        /// <param name="endtime"></param>
        /// <param name="cancelstatustime"></param>
        /// <param name="cancelendtime"></param>
        /// <returns></returns>
        public static string View_Cancel(string storesid, string cardNo, string CommodityID, string swimteacherid, string name, string satisfactionid, string statustime, string endtime, string cancelstatustime, string cancelendtime)
        {
            DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
            return ucDAL.View_Cancel(UI.Sys.SiteInfo.GetPageSize(), storesid, cardNo, CommodityID, swimteacherid, name, satisfactionid, statustime, endtime, cancelstatustime, cancelendtime);
        }
        /// <summary>
        /// 更新综合评价
        /// </summary>
        /// <param name="MemberID"></param>
        /// <returns></returns>
        public static void Update_Member_membersatisfactionid(string MemberID)
        {
            DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
            string satisfactionid = ucDAL.ReadList_member(MemberID);
            Staff.member.Update_membersatisfactionid(MemberID, satisfactionid);
        }
        /// <summary>
        /// 读取最后消费的泳圈
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static string ReadUser_mamasid(string userid)
        {
            if (Base.Fun.fun.pnumeric(userid))
            {
                DAL.customer.UserConsumption ucDAL = new DAL.customer.UserConsumption();
                return ucDAL.ReadOnUserID(userid).mamasid;
            }
            else
            {
                return "";
            }
        }
    }
}
