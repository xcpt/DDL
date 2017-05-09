
using System;
namespace Web.UI.customer
{
    /// <summary>
    /// 用户卡历史读取单价
    /// </summary>
    public class User_Card_Log
    {
        /// <summary>
        /// 读取单价（最早的单击）(并且减少次数）
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static double ReadPrice(string storesid, string userid)
        {
            DAL.customer.User_Card_Log uclDAL = new DAL.customer.User_Card_Log();
            Model.customer.User_Card_Log uclModel = uclDAL.Read(storesid, userid);
            double price = -1;
            if (Base.Fun.fun.pnumeric(uclModel.id))
            {
                price = uclModel.price;
                uclDAL.Update_Consumption(uclModel.id);
            }
            return price;
        }
        /// <summary>
        /// 添加价格进去
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="userid"></param>
        /// <param name="price">总金额</param>
        /// <param name="cardtypeid">卡类型</param>
        public static void AddPrice(string storesid, string userid, int usernum, string cardtypeid)
        {
            if (usernum > 0)
            {
                Model.customer.CardType utModel = Web.UI.customer.CardType.Read(cardtypeid);
                //如果卡类型有的时候继续
                System.Web.HttpContext.Current.Response.Write("="+utModel.id + "||" + utModel.paidmode);
                if (Base.Fun.fun.pnumeric(utModel.id) && utModel.paidmode.Equals("0"))
                {
                    double price = 0;
                    double allprice = double.Parse(utModel.price);
                    int num = int.Parse(utModel.positivenum) + int.Parse(utModel.negativenum);
                    if (num > 0)
                    {
                        price = (double)Math.Round(allprice / num, 2, MidpointRounding.AwayFromZero);
                    }
                    System.Web.HttpContext.Current.Response.Write(price + "||");
                    if (price > 0)
                    {
                        DAL.customer.User_Card_Log uclDAL = new DAL.customer.User_Card_Log();
                        Model.customer.User_Card_Log uclModel = uclDAL.Select(userid, storesid, utModel.id, num, allprice);
                        if (Base.Fun.fun.pnumeric(uclModel.id))
                        {
                            if (uclModel.num > 0)
                            {
                                if (uclModel.price == price)
                                {
                                    uclModel.num += usernum;
                                    uclDAL.Update(uclModel);
                                }
                                else
                                {
                                    uclModel.num = usernum;
                                    uclModel.cardnum = num;
                                    uclModel.price = price;
                                    uclModel.cardprice = allprice;
                                    uclDAL.Insert(uclModel);
                                }
                            }
                            else
                            {
                                uclModel.num = usernum;
                                uclModel.cardnum = num;
                                uclModel.price = price;
                                uclModel.cardprice = allprice;
                                uclDAL.Update(uclModel);
                            }
                        }
                        else
                        {
                            uclModel.cardtypeid = utModel.id;
                            uclModel.num = usernum;
                            uclModel.cardnum = num;
                            uclModel.price = price;
                            uclModel.cardprice = allprice;
                            uclModel.storesid = storesid;
                            uclModel.userid = userid;
                            uclDAL.Insert(uclModel);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 次数发生变更的时候
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="userid"></param>
        /// <param name="positivenum">正</param>
        /// <param name="negativenum">赠</param>
        /// <param name="price">总金额</param>
        /// <param name="cardtypeid">卡类型</param>
        public static void ModiPrice(string storesid, string userid, int positivenum, int negativenum, string cardtypeid, string newscardtypeid)
        {
            Model.customer.CardType utModel = Web.UI.customer.CardType.Read(cardtypeid);
            Model.customer.CardType nctModel = Web.UI.customer.CardType.Read(newscardtypeid);
            //如果卡类型有的时候继续
            if (Base.Fun.fun.pnumeric(utModel.id) && Base.Fun.fun.pnumeric(nctModel.id) && (utModel.paidmode.Equals("0") || nctModel.paidmode.Equals("0")))
            {
                double price = 0;
                double allprice = double.Parse(utModel.price);
                DAL.customer.User_Card_Log uclDAL = new DAL.customer.User_Card_Log();
                Model.customer.User_Card_Log uclModel = uclDAL.Select(userid, storesid, cardtypeid);
                if (Base.Fun.fun.pnumeric(uclModel.id))
                {
                    int num = (uclModel.num + (positivenum + negativenum));
                    if (num > 0)
                    {
                        price = (uclModel.price * uclModel.num) / (uclModel.num + (positivenum + negativenum));
                    }
                    if (nctModel.storesid.Equals(utModel.storesid))
                    {
                        uclModel.num += negativenum + positivenum;//使用次数增加
                        uclModel.cardtypeid = newscardtypeid;
                        uclModel.price = price;
                        uclDAL.Update(uclModel);
                    }
                    else
                    {
                        uclModel.cardtypeid = newscardtypeid;
                        uclModel.num = negativenum + positivenum;
                        uclModel.cardnum = negativenum + positivenum;
                        uclModel.price = 0;
                        uclModel.cardprice = 0;
                        uclModel.storesid = nctModel.storesid;
                        uclModel.userid = userid;
                        uclDAL.Insert(uclModel);
                    }
                }
                else
                {
                    uclModel.cardtypeid = newscardtypeid;
                    uclModel.num = negativenum + positivenum;
                    uclModel.cardnum = negativenum + positivenum;
                    uclModel.price = 0;
                    uclModel.cardprice = 0;
                    uclModel.storesid = nctModel.storesid;
                    uclModel.userid = userid;
                    uclDAL.Insert(uclModel);
                }
            }
        }
    }
}
