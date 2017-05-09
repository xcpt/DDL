using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.UI.Sys
{
    public class Category
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public static string ViewHtml(string Type, bool IsModi, bool IsAdd, bool IsDel)
        {
            StringBuilder str = new StringBuilder();
            DAL.Sys.Category CateDAL = new DAL.Sys.Category();
            List<Model.Sys.Category> CateList = CateDAL.ReadList(Type);
            List<Model.Sys.Category> sCateList = CateList.FindAll(delegate(Model.Sys.Category wc) { return wc.parentid == "0"; });
            if (sCateList.Count > 0)
            {
                foreach (Model.Sys.Category c in sCateList)
                {
                    str.Append("<tr id='node-" + c.classid + "'><td align='left'><span class='folder'><input type=\"hidden\" size=\"5\" name=\"orderid\" value=\"" + c.classid + "\"/><input type=\"text\" size=\"5\" name=\"orderid\" value=\"" + c.orderid + "\"/>" + c.classname + "</span></td><td>" + (c.isnavi.Equals("1") ? "显示" : "&nbsp;") + "</td><td>");
                    if (IsAdd)
                    {
                        str.Append("<a href=\"\" onclick=\"CreateWindow('Sys/Category/Add.aspx?ParentID=" + c.classid + "', '添加二级栏目', 'Sys/Category/Add.aspx?action=save&ParentID=" + c.classid + "', 500, 230, 'WeiXin_MenuAdd');return false;\">添加子栏目</a> | ");
                    }
                    if (IsModi)
                    {
                        str.Append("<a href=\"\" onclick=\"CreateWindow('Sys/Category/Modi.aspx?ID=" + c.classid + "', '修改栏目', 'Sys/Category/Modi.aspx?action=save&ID=" + c.classid + "', 500, 230, 'WeiXin_MenuModi');return false;\">修改</a> | ");
                    }
                    if (IsDel)
                    {
                        str.Append("<a href=\"\" onclick=\"GridDel('" + c.classid + "','Sys/Category/Del.aspx');return false;\">删除</a>");
                    }
                    str.Append("</td></tr>");
                    List<Model.Sys.Category> sCateList1 = CateList.FindAll(delegate(Model.Sys.Category wc) { return wc.parentid == c.classid; });
                    if (sCateList1.Count > 0)
                    {
                        foreach (Model.Sys.Category c1 in sCateList1)
                        {
                            str.Append("<tr id='node-" + c1.classid + "' class='child-of-node-" + c1.parentid + "'><td align='left'><span class='file'><input type=\"hidden\" size=\"5\" name=\"orderid\" value=\"" + c1.classid + "\"/><input type=\"text\" size=\"5\" name=\"orderid\" value=\"" + c1.orderid + "\"/>" + c1.classname + "</span></td><td>&nbsp;</td><td>");
                            str.Append("<a href=\"\" onclick=\"AjaxFun('Sys/News/Lists.aspx?action=view&classid=" + c1.classid + "&classname=" + c.classname + "&gt;&gt;" + c1.classname + "','','','.Rnr');return false;\">内容列表</a> | ");
                            if (IsModi)
                            {
                                str.Append("<a href=\"\" onclick=\"CreateWindow('Sys/Category/Modi.aspx?ID=" + c1.classid + "', '修改栏目', 'Sys/Category/Modi.aspx?action=save&ID=" + c1.classid + "', 500, 230, 'WeiXin_MenuModi');return false;\">修改</a> | ");
                            }
                            if (IsDel)
                            {
                                str.Append("<a href=\"\" onclick=\"GridDel('" + c1.parentid + "','Sys/Category/Del.aspx');return false;\">删除</a></td></tr>");
                            }
                        }
                    }
                }
            }
            return str.ToString();
        }
        /// <summary>
        /// 读取列表
        /// </summary>
        /// <returns></returns>
        public static string ViewOption(string type, string classid)
        {
            StringBuilder str = new StringBuilder();
            DAL.Sys.Category CateDAL = new DAL.Sys.Category();
            List<Model.Sys.Category> CateList = CateDAL.ReadList(type);
            List<Model.Sys.Category> sCateList = CateList.FindAll(delegate(Model.Sys.Category wc) { return wc.parentid == "0"; });
            if (sCateList.Count > 0)
            {
                foreach (Model.Sys.Category c in sCateList)
                {
                    str.Append("<optgroup label=\"" + c.classname + "\">");
                    List<Model.Sys.Category> sCateList1 = CateList.FindAll(delegate(Model.Sys.Category wc) { return wc.parentid == c.classid; });
                    if (sCateList1.Count > 0)
                    {
                        foreach (Model.Sys.Category c1 in sCateList1)
                        {
                            str.Append("<option value=\"" + c1.classid + "\"" + Base.Fun.fun.isSelected(c1.classid, classid) + ">" + c1.classname + "</option>");
                        }
                    }
                    str.Append("</optgroup>");
                }
            }
            return str.ToString();
        }
    }
}
