using System;

public partial class Staff_swimteacher_Operate : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.Staff.swimteacher sDAL = new Web.DAL.Staff.swimteacher();
            Web.Model.Staff.swimteacher sModel = sDAL.Read(id);
            if (sModel.id.Equals(id))
            {
                string isWWW = "1";
                if (sModel.iswww.Equals("1"))
                {
                    isWWW = "0";
                }
                if (sDAL.Update_IsWWW(id, isWWW) > 0)
                {
                    Base.Log.Log.Add(4, "Staff_swimteacher", id);
                    Response.Write(isWWW);
                }
            }
        }
        Response.End();
    }
}