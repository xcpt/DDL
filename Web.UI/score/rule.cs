using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.UI.score
{
    /// <summary>
    /// 积分规则
    /// </summary>
    public class rule
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="title"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static string View(string storesid, string title, string starttime, string endtime)
        {
            DAL.score.rule rDAL = new DAL.score.rule();
            return rDAL.View(UI.Sys.SiteInfo.GetPageSize(), storesid, title, starttime, endtime);
        }
        /// <summary>
        /// 给用户增加积分（消费成功的时候）
        /// </summary>
        /// <param name="storesid">门店</param>
        /// <param name="userid">用户ID</param>
        /// <param name="Price">价格</param>
        /// <param name="content">消费名称</param>
        public static void UserRule(string storesid, string userid, Model.customer.UserConsumption ucModel, string content)
        {
            double Price = 0;

            if (Base.Fun.fun.pnumeric(ucModel.CommodityID))
            {
                Web.DAL.Sys.Commodity cDAL = new DAL.Sys.Commodity();
                Web.Model.Sys.Commodity cModel = cDAL.Read(storesid, ucModel.CommodityID);
                Price = double.Parse(Base.Fun.fun.IsZero(cModel.score));
            }
            if (Price > 0)
            {
                DAL.score.rule rDAL = new DAL.score.rule();
                Model.score.rule rModel = rDAL.ReadOnNow(storesid);
                if (Base.Fun.fun.pnumeric(rModel.id))
                {
                    double coefficient = double.Parse(rModel.coefficient);
                    Price *= coefficient;
                    content += "；积分规则：" + rModel.title;
                }
                string PriceStr = Price.ToString().Split('.')[0];
                log.AddLog(storesid, userid, "0", PriceStr, content);
            }
        }
    }
}
