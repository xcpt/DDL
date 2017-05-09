using System;
using System.Collections.Generic;
using System.Text;
public partial class customer_users_intelligent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.Model.UserLogin ulModel = Web.UI.Users.GetUserInfo();
        if (Base.Fun.fun.pnumeric(ulModel.UserID))
        {
            string action = Base.Fun.Fetch.getpost("action");
            string q = Base.Fun.fun.NoCon(Base.Fun.Fetch.getpost("q"));
            string v = Base.Fun.Fetch.getpost("v");
            Web.DAL.customer.User uDAL = new Web.DAL.customer.User();
            Web.DAL.Sys.stores sDAL = new Web.DAL.Sys.stores();
            Dictionary<string, string> SortNameList = new Dictionary<string, string>();
            if (Base.Fun.fun.pnumeric(v))
            {
                Web.Model.customer.User uModel = new Web.Model.customer.User();
                if (Web.UI.Sys.stores.ReadOutlets(ulModel.StoresID))
                {
                    uModel = uDAL.Read_Outlets(v);
                }
                else
                {
                    uModel = uDAL.Read(ulModel.StoresID, v);
                }
                Response.Write(Write(action, ulModel.StoresID, ref SortNameList, uModel).TrimEnd(','));
            }
            else if (q.Length > 0)
            {
                List<Web.Model.customer.User> uModelList = new List<Web.Model.customer.User>();
                if (Base.Fun.fun.pnumeric(q))
                {
                    if (Web.UI.Sys.stores.ReadOutlets(ulModel.StoresID))
                    {
                        uModelList.Add(uDAL.Read_CardNo_Outlets(q));
                    }
                    else
                    {
                        uModelList.Add(uDAL.Read_CardNo(ulModel.StoresID, q));
                    }
                }
                else
                {
                    if (Web.UI.Sys.stores.ReadOutlets(ulModel.StoresID))
                    {
                        uModelList=uDAL.Read_Name_Outlets(q);
                    }
                    else
                    {
                        uModelList = uDAL.Read_Name(ulModel.StoresID, q);
                    }
                }
                StringBuilder str = new StringBuilder();
                foreach (Web.Model.customer.User u in uModelList)
                {
                    str.Append(Write(action, ulModel.StoresID, ref SortNameList, u));
                }
                Response.Write(str.ToString().TrimEnd(','));
            }
            
        }
        Response.End();
    }
    private string Write(string action, string StoresID, ref Dictionary<string, string> SortNameList, Web.Model.customer.User uModel)
    {
        string str = "";
        if (Base.Fun.fun.pnumeric(uModel.userid))
        {
            string cardNo = "";
            if (Base.Fun.fun.pnumeric(uModel.cardid))
            {
                if (action.Equals("nocard"))
                {
                    Response.End();
                }
                Web.DAL.customer.Card cDAL = new Web.DAL.customer.Card();
                Web.Model.customer.Card cModel = cDAL.Read(uModel.cardid);
                if (cModel.cardid.Equals(uModel.cardid))
                {
                    if (Web.UI.customer.Card.GetGo(cModel, ref cardNo))
                    {
                        string np = "0", nn = "0";
                        Web.DAL.customer.User_Stores usDAL = new Web.DAL.customer.User_Stores();
                        usDAL.ReadNum(StoresID, uModel.userid, ref np, ref nn);
                        cardNo = cModel.cardNo + "&nbsp;[正:" + cModel.surpluspositivenum + ((Base.Fun.fun.pnumeric(np) && np != cModel.surpluspositivenum) ? "(<font color=red>" + np + "</font>)" : "") + ";赠:" + cModel.surplusnegativenum + ((Base.Fun.fun.pnumeric(nn) && nn != cModel.surplusnegativenum) ? "(<font color=red>" + nn + "</font>)" : "") + ";金额:" + cModel.surplusprice + "]";
                    }
                    Web.DAL.Sys.stores sDAL = new Web.DAL.Sys.stores();
                    if (!uModel.storesid.Equals(StoresID))
                    {
                        string title = "";
                        if (!SortNameList.ContainsKey(uModel.storesid))
                        {
                            title = sDAL.Read(uModel.storesid).title;
                            SortNameList.Add(uModel.storesid, title);
                        }
                        else
                        {
                            title = SortNameList[uModel.storesid];
                        }
                        cardNo = "[<font color=red>" + title + "</font>]" + cardNo;
                    }
                }
            }
            str = "{value: \"" + uModel.userid + "\", name:\"" + uModel.name + (uModel.nickname.Length > 0 ? " " + uModel.nickname + "" : "") + cardNo + "\"},";
        }
        return str;
    }
}