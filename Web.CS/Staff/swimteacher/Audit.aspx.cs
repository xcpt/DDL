using System;

public partial class Staff_swimteacher_Audit : Web.UI.Permissions
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
                string isOpen = "1";
                if (sModel.isopen.Equals("1"))
                {
                    isOpen = "0";
                }
                if (sDAL.Update_IsOpen(id, isOpen) > 0)
                {
                    Base.Log.Log.Add(7, "Staff_swimteacher", id);
                    Response.Write(isOpen);
                }
            }
        }
        Response.End();
    }
}