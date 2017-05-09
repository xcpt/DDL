using System;

public partial class Mobile_MessageBuy_Operate :Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Mobile.MessageBuy mbDAL = new Web.DAL.Mobile.MessageBuy();
            Web.Model.Mobile.MessageBuy mbModel = mbDAL.Read(StoresID, id);
            if (mbModel.id.Equals(id))
            {
                if (mbModel.status.Equals("0"))
                {
                    Base.Log.Log.Add(4, "Mobile_MessageBuy", id);
                    mbDAL.Update(StoresID, id, "-1", "门店放弃");
                }
            }
        }
        Response.End();
    }
}