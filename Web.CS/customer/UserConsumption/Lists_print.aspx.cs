using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class customer_UserConsumption_Lists_print : Web.UI.Permissions
{
    protected string action = "";
    protected List<string> al = new List<string>();
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Base.Fun.Fetch.getpost("id");
        string dyprice = Base.Fun.Fetch.getpost("price");
        if (Base.Fun.fun.pnumeric(id.Replace(",", "")))
        {
            Web.DAL.customer.UserConsumption ucDAL = new Web.DAL.customer.UserConsumption();
            List<Web.Model.customer.UserConsumption> ucList = ucDAL.ReadList(id);
            Dictionary<string, string> uList = new Dictionary<string, string>();
            foreach (Web.Model.customer.UserConsumption uc in ucList)
            {
                if (!uList.ContainsKey(uc.userid))
                {
                    uList.Add(uc.userid, uc.userid);
                }
            }
            string lie = "-----------------------------------------";
            Web.DAL.customer.User uDAL = new Web.DAL.customer.User();
            Web.DAL.customer.Card cDAL = new Web.DAL.customer.Card();
            Web.Model.Sys.stores sModel = new Web.DAL.Sys.stores().Read(StoresID);
            StringBuilder str = new StringBuilder();
            foreach (string userid in uList.Keys)
            {
                str = new StringBuilder();
                str.Append("<br/><br/>");
                str.Append(lie + "<br/>");
                str.Append("<font size='14'><p align='center'>欢迎您的光临</p></font>");
                str.Append(lie + "<br/>");
                str.Append("<font size='16'><p align='center'><b>" + sModel.title + "</b></p></font>");
                str.Append("店名：" + Base.Fun.fun.getapp("comkey") + "<br/>");
                Web.Model.customer.User uModel = uDAL.Read(userid);
                Web.Model.customer.Card cModel = cDAL.Read(uModel.cardid);
                str.Append("交易号：" + DateTime.Now.ToString("yyyyMMdd") + cModel.cardNo + "<br/>");
                str.Append(lie + "<br/>");
                str.Append("卡号：" + cModel.cardNo + "<br/>");
                str.Append("姓名：" + uModel.name + "<br/>");
                str.Append("剩余卡次：" + cModel.surplusnum + "次<br/>");
                str.Append("卡类型：" + Web.UI.customer.CardType.GetName(cModel.cardtypeid) + "<br/>");
                str.Append("有效期至：" + DateTime.Parse(cModel.endtime).ToString("yyyy-MM-dd") + "<br/>");
                str.Append(lie + "<br/>");
                List<Web.Model.customer.UserConsumption> sucList = ucList.FindAll(delegate(Web.Model.customer.UserConsumption uc) { return uc.userid.Equals(userid); });
                double price = 0;
                double sprice = 0;
                string xfsj = "";
                foreach (Web.Model.customer.UserConsumption uc in sucList)
                {
                    str.Append("消费名称：" + Web.UI.Sys.Commodity.GetName(uc.storesid, uc.CommodityID) + "<br/>");
                    str.Append("消费数量：1<br/>");
                    if (!Base.Fun.fun.pnumeric(dyprice))
                    {
                        str.Append("消费金额：" + uc.price + "<br/>");
                        price += double.Parse(uc.price);
                    }
                    else
                    {
                        dyprice = Web.UI.Sys.Commodity.GetPrice(uc.storesid, uc.CommodityID);
                        str.Append("消费金额：" + double.Parse(dyprice).ToString("f2") + "<br/>");
                        price += double.Parse(dyprice);
                    }
                    str.Append("<br/>");
                    
                    if (!uc.IsCash.Equals("0"))
                    {
                        sprice += double.Parse(uc.price);
                    }
                    xfsj = uc.addtime;
                    if (Base.Fun.fun.pnumeric(dyprice))
                    {
                        break;
                    }
                }
                str.Append("合计金额：" + price.ToString("f2") + "<br/>");
                str.Append("实收金额：" + sprice.ToString("f2") + "<br/>");
                str.Append("消费时间：" + DateTime.Parse(xfsj).ToString("yyyy-MM-dd HH:mm") + "<br/>");
                str.Append(lie + "<br/>");
                //str.Append("<p><img src='http://112.126.81.86/images/erwm.jpg' align='center' width='170' height='170'></p><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>");
                str.Append("<p>电话：" + sModel.tel + "<br/>谢谢惠顾，欢迎再次光临！</p>");
                str.Append("<br/>");
                al.Add("\"" + Base.Fun.JScript.htmltojavascriptNoD(str.ToString()) + "\"");
            }
        }
        else
        {
            Response.End();
        }
    }
}