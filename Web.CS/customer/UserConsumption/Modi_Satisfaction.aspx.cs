using System;

public partial class customer_UserConsumption_Modi_Satisfaction : Web.UI.Permissions
{
    protected string action = "";
    protected string id = "";
    protected string satisfactionid = "";
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
                        string satisfactionid = Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("satisfactionid"));
                        //if (!Base.Fun.fun.pnumeric(ucModel.satisfactionuserid))
                        //{
                        if (!ucModel.satisfactionid.Equals(satisfactionid))
                        {
                            string content = Base.Fun.Fetch.getpost("content");
                            if (ucDAL.Update_satisfactionid(StoresID, id, satisfactionid) > 0)
                            {
                                //修改综合满意度
                                if (Base.Fun.fun.pnumeric(ucModel.swimteacherid) && Base.Fun.fun.pnumeric(ucModel.satisfactionid))
                                {
                                    Web.UI.customer.UserConsumption.Update_Member_membersatisfactionid(ucModel.swimteacherid);
                                }
                                Web.UI.customer.UserConsumptionSatisfaction.UpdateUserConsumptionSatisfaction(StoresID, ucModel.userid, UserID, id, "0", ucModel.satisfactionid, satisfactionid, content);
                                Base.Log.Log.Add(2, "customer_UserConsumption", id);
                                SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "修改满意度成功。");
                                Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("UserConsumptionGrid", id, true));
                            }
                            else
                            {
                                SyCms.Window.WindowsReturn.WindowsReturnAlert("修改满意度失败。");
                            }
                        }
                        else
                        {
                            SyCms.Window.WindowsReturn.WindowsReturnAlert("新旧满意度一样，无需修改。");
                        }
                        //}
                        //else {
                        //    SyCms.Window.WindowsReturn.WindowsReturnAlert("消费用户修改过满意度了，暂不能修改了。");
                        //}
                        Response.End();
                    }
                    else
                    {
                        satisfactionid = ucModel.satisfactionid;
                    }
                }
            }
            else
            {
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