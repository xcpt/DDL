using System;

namespace Web.UI.customer
{
    /// <summary>
    /// 用户多门店管理
    /// </summary>
    public class User_Stores
    {
        /// <summary>
        /// 用户预约时，用户消费时，添加信息到该门店
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="userid"></param>
        public static void AddStoresUser(string storesid, string userid)
        {
            AddStores(storesid, userid, 0, 0, "0");
        }
        /// <summary>
        /// 添加门店相关卡信息（添加卡次，第一次加卡等操作时）
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="userid"></param>
        /// <param name="positivenum">正价次数</param>
        /// <param name="negativenum">赠送次数</param>
        /// <param name="cardtypeid">卡类型</param>
        /// <returns></returns>
        public static void AddStores(string storesid, string userid, int positivenum, int negativenum, string cardtypeid)
        {
            DAL.customer.User_Stores usDAL = new DAL.customer.User_Stores();
            Model.customer.User_Stores usModel = usDAL.Read(storesid, userid);
            if (Base.Fun.fun.pnumeric(usModel.id))
            {
                if (negativenum > 0 || positivenum > 0)
                {
                    usModel.negativenum += negativenum;
                    usModel.positivenum += positivenum;
                    usModel.surplusnegativenum += negativenum;
                    usModel.surplusnum += negativenum + positivenum;
                    usModel.surpluspositivenum += positivenum;
                    usModel.cardtypeid = cardtypeid;
                    usDAL.Update(usModel);
                }
            }
            else
            {
                usModel.storesid = storesid;
                usModel.userid = userid;
                usModel.cardtypeid = cardtypeid;
                usModel.negativenum = negativenum;
                usModel.positivenum = positivenum;
                usModel.surplusnegativenum = negativenum;
                usModel.surplusnum = negativenum + positivenum;
                usModel.surpluspositivenum = positivenum;
                usModel.usernegativenum = 0;
                usModel.userpositivenum = 0;
                usDAL.Insert(usModel);
            }
        }
        /// <summary>
        /// 用户消费记录（先消费自己的，再消费跨店的）,读取价格
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="userid"></param>
        /// <param name="consumptionid">消费ID</param>
        /// <param name="isTop">是否正则次数</param>
        public static string UserConsumption(string storesid, string userid,string CardID, string consumptionid, bool isTop)
        {
            //判断有没有自已店里的卡信息
            DAL.customer.User_Stores usDAL = new DAL.customer.User_Stores();
            Model.customer.User_Stores usModel = usDAL.Read(storesid, userid);
            bool ismy = false;
            if (Base.Fun.fun.pnumeric(usModel.id) && usModel.surplusnum>0)
            {
                if (isTop && usModel.surpluspositivenum > 0)
                {
                    ismy = true;
                }
                else if (usModel.surplusnegativenum > 0)
                {
                    ismy = true;
                }
            }
            double price = 0;
            Model.customer.Card cModel = new DAL.customer.Card().Read(CardID);
            Model.customer.CardType ctModel = new Model.customer.CardType();
            if (Base.Fun.fun.pnumeric(cModel.cardtypeid))
            {
                ctModel = new DAL.customer.CardType().Read(cModel.cardtypeid);
            }
            if (ismy)
            {
                price = customer.CardType.ReadPriceAndCardNum(storesid, userid, ctModel);
                if (isTop)
                {
                    usDAL.Update_UserPositivenum(usModel.id);
                }
                else
                {
                    usDAL.Update_UserNegativenum(usModel.id);
                }
            }
            else
            {
                usModel = usDAL.ReadOther(storesid, userid);
                if (Base.Fun.fun.pnumeric(usModel.id))
                {
                    price = customer.CardType.ReadPriceAndCardNum(usModel.storesid, userid, ctModel);
                    if (isTop)
                    {
                        usDAL.Update_UserPositivenum(usModel.id);
                    }
                    else
                    {
                        usDAL.Update_UserNegativenum(usModel.id);
                    }
                    Model.customer.User_Stores_Consumption uscModel = new Model.customer.User_Stores_Consumption();
                    uscModel.addtime = DateTime.Now.ToString();
                    uscModel.cardstoresid = usModel.storesid;
                    uscModel.consumptionid = consumptionid;
                    uscModel.consumptionstoresid = storesid;
                    uscModel.isclose = "0";
                    uscModel.price = price.ToString("f2");
                    uscModel.userid = userid;
                    DAL.customer.User_Stores_Consumption uscDAL = new DAL.customer.User_Stores_Consumption();
                    uscDAL.Insert(uscModel);
                }
            }
            return price.ToString("f2");
        }
    }
}
