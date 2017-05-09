using System;
using System.Collections.Generic;
using System.Text;

namespace Web.UI.customer
{
    /// <summary>
    /// 卡类型
    /// </summary>
    public class CardType
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="title"></param>
        /// <param name="paidmode"></param>
        /// <param name="businessid"></param>
        /// <returns></returns>
        public static string View(string storesid, string title, string paidmode, string businessid)
        {
            DAL.customer.CardType ctDAL = new DAL.customer.CardType();
            return ctDAL.View(UI.Sys.SiteInfo.GetPageSize(), storesid, title, paidmode, businessid);
        }
        /// <summary>
        /// 获得名称
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="ctid"></param>
        /// <returns></returns>
        public static string GetName(string ctid)
        {
            DAL.customer.CardType ctDAL = new DAL.customer.CardType();
            Model.customer.CardType ctModel = ctDAL.Read(ctid);
            return ctModel.title;
        }
        /// <summary>
        /// 返回Option
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetOption(string storesid, string id)
        {
            StringBuilder str = new StringBuilder();
            DAL.customer.CardType ctDAL = new DAL.customer.CardType();
            List<Model.customer.CardType> ctList = ctDAL.ReadList(storesid);
            bool bo = false;
            foreach (Model.customer.CardType ct in ctList)
            {
                if (!bo)
                {
                    bo = ct.id.Equals(id);
                }
                str.Append("<option value=\"" + ct.id + "\"" + Base.Fun.fun.isSelected(ct.id, id) + ">" + ct.title + "[" + (ct.paidmode.Equals("0") ? "卡次" : "金额") + "]</option>");
            }
            if (!bo && Base.Fun.fun.pnumeric(id))
            {
                Model.customer.CardType ct = ctDAL.Read(id);
                if (Base.Fun.fun.pnumeric(ct.id))
                {
                    string Storesname = Sys.stores.GetStoresName(ct.storesid);
                    str.Append("<option value=\"" + ct.id + "\"" + Base.Fun.fun.isSelected(ct.id, id) + ">【" + Storesname + "】" + ct.title + "[" + (ct.paidmode.Equals("0") ? "卡次" : "金额") + "]</option>");
                }
            }
            return str.ToString();
        }
        /// <summary>
        /// 返回表头
        /// </summary>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public static string GetJson(string storesid)
        {
            StringBuilder str = new StringBuilder();
            DAL.customer.CardType ctDAL = new DAL.customer.CardType();
            List<Model.customer.CardType> ctList = ctDAL.ReadList(storesid);
            foreach (Model.customer.CardType ct in ctList)
            {
                str.Append("{ display: '" + ct.title + "', name: 'cardtype_" + ct.id + "', width: 50, sortable: false, align: 'center'},");
            }
            return str.ToString();
        }
        /// <summary>
        /// 读取折扣金额
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public static double ReadPrice(Model.customer.CardType ctModel, double price)
        {
            if (double.Parse(ctModel.discount) > 0)
            {
                price = Math.Round(price * double.Parse(ctModel.discount) / 100, 2);
            }
            return price;
        }
        /// <summary>
        /// 读取金额
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public static double ReadPrice(string cardtypeid)
        {
            DAL.customer.CardType ctDAL = new DAL.customer.CardType();
            return double.Parse(ctDAL.Read(cardtypeid).price);
        }
        /// <summary>
        /// 读取金额
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public static Model.customer.CardType Read(string cardtypeid)
        {
            DAL.customer.CardType ctDAL = new DAL.customer.CardType();
            return ctDAL.Read(cardtypeid);
        }
        /// <summary>
        /// 读取卡次金额
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="userid"></param>
        /// <param name="ctModel"></param>
        /// <returns></returns>
        public static double ReadPriceAndCardNum(string storesid, string userid, Model.customer.CardType ctModel)
        {
            double price = User_Card_Log.ReadPrice(storesid, userid);
            if (price == -1)
            {
                price = 0;
                if (double.Parse(ctModel.price) > 0 && double.Parse(ctModel.positivenum) > 0 && ctModel.paidmode.Equals("0"))
                {
                    price = Math.Round(double.Parse(ctModel.price) / (double.Parse(ctModel.positivenum) + double.Parse(ctModel.negativenum)), 2);
                }
            }
            return price;
        }
    }
}
