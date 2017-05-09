using System;
namespace Web.CS.Manager.Log
{
    public partial class Lists_View : Web.UI.Permissions
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Base.Fun.fun.NoCon(Base.Fun.Fetch.post("id"));
            if (Base.Fun.fun.pnumeric(id))
            {
                string Content = Base.Fun.fun.NoSql(Base.Fun.Encrypt.Decrypt3DES(Base.IO.File.ReadFile(Base.Fun.Management.RealDirectory() + "Log/Operating/" + id + ".txt")));
                Response.Write("<font color=\"blue\">" + Content.Replace("/>{", "/><font color=\"blue\">{").Replace("}", "}</font>"));
            }
            else if (id.Length > 0)
            {
                string line;
                Response.Write("<div style=\"font-size:12px;\">");
                int i = 1;
                Server.ScriptTimeout = 900000;
                using (System.IO.StreamReader file = new System.IO.StreamReader(Base.Fun.Management.RealDirectory("Log/Error/" + id), System.Text.Encoding.GetEncoding("utf-8")))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        try
                        {
                            Response.Write("<fieldset style=\"padding:10px;\"><legend style=\"padding:5px;\">错误：<font color=\"red\">" + i.ToString() + "</font></legend>" + Base.Fun.fun.NoSql(Base.Fun.Encrypt.Decrypt3DES(line)) + "</fieldset>");
                            i++;
                        }
                        catch (Exception) { }
                    }
                    file.Close();
                }
                Response.Write("</div>");
            }
            Response.End();
        }
    }
}