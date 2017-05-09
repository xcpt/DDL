using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class customer_Card_Modi_Change : Web.UI.Permissions
{
    protected string action = "";
    protected Web.Model.customer.Card cModel = new Web.Model.customer.Card();
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        action = Base.Fun.Fetch.getpost("action");
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.customer.Card cDAL = new Web.DAL.customer.Card();
            cModel = cDAL.Read(id);
            if (cModel.cardid.Equals(id))
            {
                if (action.Equals("save"))
                {
                    string cardtypeid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("cardtypeid"));
                    string positivenum = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("positivenum"));
                    string negativenum = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("negativenum"));
                    string price = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("price"));
                    string endtime = Base.Fun.Fetch.getpost("endtime");
                    StringBuilder str = new StringBuilder();
                    Web.Model.customer.CardLog clModel = new Web.Model.customer.CardLog();
                    clModel.storesid = StoresID;
                    clModel.cardid = id;
                    clModel.cardlogtype = "2";
                    clModel.newcardtype = Web.UI.customer.CardType.GetName(cardtypeid);
                    if (!cModel.cardtypeid.Equals(cardtypeid))
                    {
                        if (Base.Fun.fun.pnumeric(cModel.cardtypeid))
                        {
                            clModel.oldcardtype = Web.UI.customer.CardType.GetName(cModel.cardtypeid);
                        }
                        str.Append("卡类型" + (Base.Fun.fun.pnumeric(cModel.cardtypeid) ? "【" + clModel.oldcardtype + "】" : "") + "调整为【" + Web.UI.customer.CardType.GetName(cardtypeid) + "】；");
                    }
                    if (Base.Fun.fun.IsNumeric(positivenum) && positivenum != "0")
                    {
                        clModel.oldnum = cModel.surpluspositivenum;
                        clModel.newnum = (int.Parse(cModel.surpluspositivenum) + int.Parse(positivenum)).ToString();
                        str.Append("正价次数添加：" + positivenum + "【" + clModel.newnum + "】；");
                    }
                    else
                    {
                        clModel.newnum = clModel.oldnum = cModel.surpluspositivenum;
                    }
                    if (Base.Fun.fun.IsNumeric(negativenum) && negativenum != "0")
                    {
                        clModel.oldnum += "/" + cModel.surplusnegativenum;
                        clModel.newnum += "/" + (int.Parse(cModel.surplusnegativenum) + int.Parse(negativenum)).ToString();
                        str.Append("赠送次数添加：" + negativenum + "【" + clModel.newnum + "】；");
                    }
                    else
                    {
                        clModel.oldnum += "/" + cModel.surplusnegativenum;
                        clModel.newnum += "/" + cModel.surplusnegativenum;
                    }
                    if (Base.Fun.fun.IsNumeric(price) && double.Parse(price) != 0)
                    {
                        clModel.oldprice = cModel.surplusprice;
                        clModel.newprice = (double.Parse(cModel.surplusprice) + double.Parse(price)).ToString("f");
                        str.Append("金额添加：" + price + "【" + clModel.newprice + "】；");
                    }
                    if (Base.Fun.fun.IsDate(endtime) && Base.Time.Time.TimeBad(endtime, cModel.endtime, "天") != 0)
                    {
                        clModel.oldendtime = Web.UI.Ami.DateTimeFormat(cModel.endtime, "YY04-MM-DD");
                        clModel.newendtime = endtime;
                        str.Append("失效日期：" + Web.UI.Ami.DateTimeFormat(cModel.endtime, "YY04-MM-DD") + "调整为" + endtime + "；");
                        cModel.endtime = endtime;
                    }
                    if (str.Length > 0)
                    {
                        cModel.cardtypeid = cardtypeid;
                        cModel.positivenum = positivenum;
                        cModel.negativenum = negativenum;
                        cModel.price = price;
                        if (cDAL.Update(cModel) > 0)
                        {
                            Base.Log.Log.Add(2, "customer_Card", id);
                            Web.Model.customer.User uModel = new Web.DAL.customer.User().Read1_CardID(cModel.cardid);
                            if (Base.Fun.fun.pnumeric(uModel.userid))
                            {
                                Web.UI.customer.User_Card_Log.ModiPrice(StoresID, uModel.userid, int.Parse(cModel.positivenum), int.Parse(cModel.negativenum), cModel.cardtypeid, cardtypeid);
                                //增加卡次
                                Web.UI.customer.User_Stores.AddStores(clModel.storesid, uModel.userid, int.Parse(cModel.positivenum), int.Parse(cModel.negativenum), cardtypeid);
                            }
                            Web.UI.customer.CardLog.AddCardLog(clModel);
                            SyCms.Window.WindowsReturn.WindowsReturnAlert(true, str.ToString(), true);
                            Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("CardGrid", id, true));
                        }
                        else
                        {
                            SyCms.Window.WindowsReturn.WindowsReturnAlert("调整失败");
                        }
                    }
                    else
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("没有作调整，不需要保存。");
                    }
                    Response.End();
                }
                else
                {
                    if (cModel.cardstatus.Equals("-1"))
                    {
                        SyCms.Window.WindowsReturn.WindowsReturnAlert("此卡已停，请先开卡。");
                        Response.End();
                    }
                }
            }
            else
            {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("会员卡项错误");
                Response.End();
            }
        }
        else
        {
            SyCms.Window.WindowsReturn.WindowsReturnAlert("参数传递错误");
            Response.End();
        }
    }
}