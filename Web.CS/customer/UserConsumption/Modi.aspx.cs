using System;

public partial class customer_UserConsumption_Modi : Web.UI.Permissions
{
    protected string action = "";
    protected string id = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Base.Fun.Fetch.getpost("id");
        action = Base.Fun.Fetch.getpost("action");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.customer.UserConsumption ucDAL = new Web.DAL.customer.UserConsumption();
            Web.Model.customer.UserConsumption ucModel = ucDAL.Read(StoresID, id);
            if (ucModel.id.Equals(id))
            {
                if (ucModel.status.Equals("1"))
                {
                    if (action.Equals("save"))
                    {
                        if (ucDAL.Update_Cancel(StoresID, id, Base.Fun.Fetch.getpost("content")) > 0)
                        {
                            //修改综合满意度
                            if (Base.Fun.fun.pnumeric(ucModel.swimteacherid) && Base.Fun.fun.pnumeric(ucModel.satisfactionid))
                            {
                                Web.UI.customer.UserConsumption.Update_Member_membersatisfactionid(ucModel.swimteacherid);
                            }
                            if (ucModel.Consumptiontype.Equals("0"))
                            {
                                Web.UI.customer.Card.Update_Addpositivenum(ucModel.userid);
                            }
                            else if (ucModel.Consumptiontype.Equals("1"))
                            {
                                Web.UI.customer.Card.Update_Addnegativenum(ucModel.userid);
                            }

                            Base.Log.Log.Add(2, "customer_UserConsumption", id);
                            SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "会员消费撤销成功。");
                            Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("UserConsumptionGrid", ID, true));
                        }
                        else
                        {
                            SyCms.Window.WindowsReturn.WindowsReturnAlert("会员消费撤销失败。");
                        }
                        Response.End();
                    }
                }
            }
            else {
                SyCms.Window.WindowsReturn.WindowsReturnAlert("未找到相关记录");
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