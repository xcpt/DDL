using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.UI.Mobile
{
    /// <summary>
    /// 购买短消息
    /// </summary>
    public class MessageBuy
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="storesname"></param>
        /// <param name="setupid"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string View(string storesid, string setupid, string status)
        {
            DAL.Mobile.MessageBuy mbDAL = new DAL.Mobile.MessageBuy();
            return mbDAL.View(UI.Sys.SiteInfo.GetPageSize(), storesid, setupid, status);
        }
        /// <summary>
        /// 添加购买数量
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="setupid"></param>
        public static void AddMessageNum(string storesid, string setupid)
        {
            DAL.Mobile.MessageSetup msDAL = new DAL.Mobile.MessageSetup();
            Model.Mobile.MessageSetup msModel = msDAL.Read(setupid);
            string Num = msModel.num;
            DAL.Mobile.Message mDAL = new DAL.Mobile.Message();
            Model.Mobile.Message mModel = mDAL.Read(storesid);
            if (mModel.storesid.Equals(storesid))
            {
                mDAL.Update_Num(storesid, Num);
            }
            else {
                mModel = new Model.Mobile.Message();
                mModel.num = Num;
                mModel.storesid = storesid;
                mModel.usernum = "0";
                mDAL.Insert(mModel);
            }
        }
    }
}
