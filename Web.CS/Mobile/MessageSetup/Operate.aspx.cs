using System;

public partial class Mobile_MessageSetup_Operate : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Mobile.MessageSetup msDAL = new Web.DAL.Mobile.MessageSetup();
            Web.Model.Mobile.MessageSetup msModel = msDAL.Read(id);
            if (msModel.id.Equals(id))
            {
                Base.Log.Log.Add(4, "Mobile_MessageSetup", id);
                string isopen = "1";
                if (msModel.isopen.Equals("1"))
                {
                    isopen = "0";
                }
                msDAL.Update_IsOpen(id, isopen);
                Response.Write(isopen);
            }
        }
        Response.End();
    }
}