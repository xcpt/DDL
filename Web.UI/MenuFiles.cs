using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Web.UI
{
    public class MenuFiles
    {
        Web.DAL.MenuFiles MFBLL = new Web.DAL.MenuFiles();
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="OrderID"></param>
        public static void SetOrder(string OrderID)
        {
            string[] _OrderID = OrderID.Split(',');
            Web.DAL.MenuFiles MFBLL = new DAL.MenuFiles();
            for (int i = 0; i < _OrderID.Length; i = i + 2)
            {
                MFBLL.SetOrder(Base.Fun.fun.IsZero(_OrderID[i]), _OrderID[i + 1]);
            }
        }
        #region 添加内容
        /// <summary>
        /// 添加内容
        /// </summary>
        /// <returns>返回真假</returns>

        public bool Add(ref Web.Model.MenuFiles MFModel)
        {
            bool bo = true;
            MFModel = MFBLL.Insert(MFModel);
            if (Base.Fun.fun.pnumeric(MFModel.Id))
            {
                ModiyAllUrl(MFModel.Id);
                Base.Log.Log.Add(1, "Manager_MenuFiles");
            }
            else
            {
                bo = false;
            }
            return bo;
        }
        #endregion


        #region 修改记录
        /// <summary>
        /// 修改记录
        /// </summary>
        /// <returns>返回真假</returns>

        public bool Modi(Web.Model.MenuFiles MFModel)
        {
            bool bo = true;
            if (MFBLL.Update(MFModel) == 0)
            {
                bo = false;
            }
            else
            {
                ModiyAllUrl(MFModel.Id);
                Base.Log.Log.Add(2, "Manager_MenuFiles");
            }
            return bo;
        }
        #endregion


        #region 删除信息
        /// <summary>
        /// 删除信息
        /// </summary>
        /// <returns>返回真假</returns>
        public bool Del(string ID)
        {
            bool bo = true;
            if (MFBLL.Delete(ID) == 0)
            {
                bo = false;
            }
            else
            {
                Base.Log.Log.Add(3, "Manager_MenuFiles");
            }
            return bo;
        }
        #endregion
        /// <summary>
        /// 获取一个目录下一个文件路径的存在filename,mcid
        /// </summary>
        /// <returns></returns>
        public int GetFileNameCount(string mcid, string fileName)
        {
            return MFBLL.GetFileNameCount(mcid, fileName);
        }
        #region 显示单条记录
        /// <summary>
        /// 显示单条记录
        /// </summary>
        /// <returns>返回真假</returns>
        public Web.Model.MenuFiles View(string id)
        {
            return MFBLL.Read(id);
        }
        #endregion

        /// <summary>
        /// 显示树形数据
        /// </summary>
        /// <param name="IsAdd">添加</param>
        /// <param name="IsModi">修改</param>
        /// <param name="IsDel">删除</param>
        /// <param name="IsOperate">属性</param>
        /// <returns></returns>
        public static string ViewTreeData(Web.Model.MenuFiles MFModel, bool IsAdd, bool IsModi, bool IsDel, bool IsOperate)
        {
            StringBuilder reval = new StringBuilder();
            reval.Append("<tr align=\"center\" id=\"node-3-" + MFModel.Id + "\" Depth=\"2\" class=\"child-of-node-2-" + MFModel.Mcid + "\" sizset=\"27\" sizcache=\"6\">\n");
            reval.Append("<td align=\"left\" sizset=\"27\" sizcache=\"6\" style=\"padding-left: 56px\"><span class=\"file\">");
            if (IsOperate)
            {
                reval.Append("排序：<input name=\"OrderID\" type=\"text\" class=\"Ipx\" id=\"OrderID\" size=\"5\" value=\"" + MFModel.OrderId + "\" onKeyUp=\"this.value=this.value.replace(/\\D/g,'')\" onafterpaste=\"this.value=this.value.replace(/\\D/g,'')\"/><INPUT type='hidden' name='OrderID' id='OrderID' value='" + MFModel.Id + "' />&nbsp;");
            }
            reval.Append(MFModel.FileName + "</span></td>\n");
            reval.Append("<td>&nbsp;</td>\n");
            if (MFModel.Issys.Equals("0"))
            {
                if (IsOperate)
                {
                    reval.Append("<td><a href=\"#\" onclick=\"var obj=this;AjaxFun('Manager/MenuFiles/Operate.aspx', 'id=" + MFModel.Id + "', '正在设置属性，请稍候...',function(html){if (html){$(obj).html(html);}});return false;\" ><img src='images/icon/" + Ami.GetStateStr(MFModel.Ishow) + ".png' /></a></td>\n");
                }
                else
                {
                    reval.Append("<td><img src='images/icon/" + Ami.GetStateStr(MFModel.Issys) + "_Gray.png' /></td>\n");
                }
            }
            else
            {
                reval.Append("<td><img src='images/icon/" + Ami.GetStateStr(MFModel.Ishow) + "_Gray.png' /></td>\n");
            }
            if (IsModi)
            {
                reval.Append("<td>" + (MFModel.Issys.Equals("0") ? "<a href=\"#\" onclick=\"GridModiy('" + MFModel.Id + "', 'Manager/MenuFiles/Modi.aspx','修改', 'Manager/MenuFiles/Modi.aspx?action=save', 400, 240, 'MenuFilesModi');return false;\" ><img src='images/icon/page_edit.png' /></a>" : "&nbsp;") + "</td>\n");
            }
            else
            {
                reval.Append("<td>&nbsp;</td>\n");
            }
            if (IsDel)
            {
                reval.Append("<td>" + (MFModel.Issys.Equals("0") ? "<a href=\"#\" onclick=\"GridDel('" + MFModel.Id + "','Manager/MenuFiles/Del.aspx');return false;\" ><img src='images/icon/page_delete.png' /></a>" : "&nbsp;") + "</td>\n");
            }
            else
            {
                reval.Append("<td>&nbsp;</td>\n");
            }
            reval.Append("</tr>\n");
            return reval.ToString();
        }
        /// <summary>
        /// 设置是否可见
        /// </summary>
        /// <returns></returns>
        public string SetShow(string id)
        {
            string str = "";
            Web.Model.MenuFiles MFModel = View(id);
            if (MFModel != null)
            {
                string St = (MFModel.Ishow.Equals("0") ? "1" : "0");
                int count = MFBLL.SetShow(St, id);
                if (count > 0)
                {
                    str = "<img src=images/icon/" + (St == "1" ? "true" : "false") + ".png width=16 height=16 />";
                }
            }
            return str;
        }

        /// <summary>
        /// 获得同级里面的它上面的ID，如果没有返回父级ID
        /// </summary>
        /// <returns></returns>
        public string GetParentId(string mcid, string id, string orderId)
        {
            string str = "node-2-" + mcid;
            List<Web.Model.MenuFiles> MFList = new List<Web.Model.MenuFiles>();
            if (MFList.Count > 0)
            {
                Web.Model.MenuFiles MFModel = MFList.Find(delegate(Web.Model.MenuFiles f) { return f.OrderId == orderId && int.Parse(f.Id) < int.Parse(id); });
                if (MFModel != null)
                {
                    str = "node-3-" + MFModel.Id;
                }
                else
                {
                    MFModel = MFList.Find(delegate(Web.Model.MenuFiles f) { return int.Parse(f.OrderId) < int.Parse(orderId); });
                    if (MFModel != null)
                    {
                        str = "node-3-" + MFModel.Id;
                    }
                }
            }
            return str;
        }

        /// <summary>
        /// 写入全的
        /// </summary>
        /// <param name="Id"></param>
        private void ModiyAllUrl(string Id)
        {
            string str = "";
            Web.Model.MenuClassFile MCFModel = MFBLL.ReadAllUrl(Id);
            if (MCFModel != null)
            {
                str = AllUrl(MCFModel.PClassDir, MCFModel.ClassDir, MCFModel.Url);
                MFBLL.SetUrl(Id, str);
            }
        }
        /// <summary>
        /// 获得 所有所有 地址 的加
        /// </summary>
        /// <param name="str1">地址1</param>
        /// <param name="str2">地址2</param>
        /// <param name="str3">地址3</param>
        /// <returns></returns>
        public static string AllUrl(string str1, string str2, string str3)
        {
            string str = "";
            str = str1;
            if (str2.Contains("../"))
            {
                string[] s = Regex.Split(str2, "../");
                int i1 = 0;
                if (str.EndsWith("/"))
                {
                    i1 = s.Length;
                }
                else
                {
                    i1 = s.Length - 1;
                }
                string[] s1 = str.Split('/');
                str = "";
                for (int i = 0; i < s1.Length - i1; i++)
                {
                    if (s1[i].Length > 0)
                    {
                        str += "/" + s1[i];
                    }
                }
                str += "/" + str2.Replace("../", "");
            }
            else
            {
                str += "/" + str2;
            }
            if (str3.Contains("../"))
            {
                string[] s = Regex.Split(str3, "../");
                int i1 = 0;
                if (str.EndsWith("/"))
                {
                    i1 = s.Length;
                }
                else
                {
                    i1 = s.Length - 1;
                }
                string[] s1 = str.Split('/');
                str = "";
                for (int i = 0; i < s1.Length - i1; i++)
                {
                    if (s1[i].Length > 0)
                    {
                        str += "/" + s1[i];
                    }
                }
                str += "/" + str3.Replace("../", "");
            }
            else
            {
                str += "/" + str3;
            }
            str = string.Join("/", str.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries));
            if (!str.StartsWith("/"))
            {
                str = "/" + str;
            }
            return str;
        }
    }
}
