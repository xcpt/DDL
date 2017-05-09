using System;

public partial class baby_album_Del : Web.UI.Permissions
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.UI.Users.ReadUserStoresID(StoresID);
        string id = Base.Fun.Fetch.getpost("id");
        if (Base.Fun.fun.pnumeric(id))
        {
            Web.DAL.baby.album aDAL = new Web.DAL.baby.album();
            Web.Model.baby.album aModel = aDAL.Read(id);
            if (aModel.id.Equals(id))
            {
                if (aDAL.Delete(id) > 0)
                {
                    Web.DAL.customer.User uDAL = new Web.DAL.customer.User();
                    Web.Model.customer.User uModel = uDAL.Read(aModel.UserID);
                    string userface = "";
                    if (uModel.Equals(aModel.picurl))
                    {
                        userface = aDAL.Read_LastPhoto(aModel.UserID);
                    }
                    else
                    {
                        userface = uModel.userface;
                    }
                    int Num = 0;
                    if (Base.Fun.fun.pnumeric(uModel.photonum))
                    {
                        Num = int.Parse(uModel.photonum) - 1;
                    }
                    uDAL.Update_UserFaceAndPhotoNum(aModel.UserID, userface, Num.ToString());

                    Base.IO.File.DelFileNoDir(aModel.picurl);
                    Base.Log.Log.Add(3, "baby_album", id);
                    SyCms.Window.WindowsReturn.WindowsReturnAlert(true, "删除成功。");
                    Response.Write(SyCms.Window.List.Grid.GridReload.flexReload("albumGrid", true));
                }
            }
        }
        Response.End();
    }
}