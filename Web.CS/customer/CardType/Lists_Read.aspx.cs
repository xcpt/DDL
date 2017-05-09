using System;

public partial class customer_CardType_Lists_Read : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Web.Model.UserLogin ulModel = Web.UI.Users.GetUserInfo();
        if (Base.Fun.fun.pnumeric(ulModel.UserID))
        {
            string id = Base.Fun.Fetch.getpost("id");
            if (Base.Fun.fun.pnumeric(id))
            {
                Web.DAL.customer.CardType ctDAL = new Web.DAL.customer.CardType();
                Web.Model.customer.CardType ctModel = ctDAL.Read(id);
                if (ctModel.id.Equals(id))
                {
                    Response.Write("<script type=\"text/javascript\">");
                    if (Base.Fun.fun.pnumeric(ctModel.effectivetime))
                    {
                        Response.Write("$('#Cardstarttime').val('" + DateTime.Now.ToString("yyyy-MM-dd") + "');");
                        Response.Write("$('#Cardendtime').val('" + DateTime.Now.AddMonths(int.Parse(ctModel.effectivetime)).ToString("yyyy-MM-dd") + "');");
                        Response.Write("$('#Cardnegativenum').val('" + ctModel.negativenum + "');");
                        Response.Write("$('#CardopenCardScore').val('" + ctModel.opencardexchange + "');");
                        Response.Write("$('#Cardcardpaidmode').html('" + (ctModel.paidmode.Equals("0") ? "按次" : "按金额") + "');");
                        Response.Write("$('#Cardpositivenum').val('" + ctModel.positivenum + "');");
                        Response.Write("$('#Cardprice').val('" + ctModel.price + "');");
                    }
                    Response.Write("</script>");
                }
            }
        }
        Response.End();
    }
}