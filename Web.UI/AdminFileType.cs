using System.Collections.Generic;
using System.Text;

namespace Web.UI
{
    /// <summary>
    /// 后台文件类型（权限相关）
    /// </summary>
    public class AdminFileType
    {
        /// <summary>
        /// 文件类型（英文，对应权限值）
        /// </summary>
        public Dictionary<string, Web.Model.AdminFileTypeValue> FileType = new Dictionary<string, Web.Model.AdminFileTypeValue>();
        /// <summary>
        /// 2为属性，4为添加，8为修改，16为删除，32为审核，64排序，128布局，256为推送，512回收站，1024还原
        /// </summary>
        public AdminFileType()
        {
            FileType.Add("Add", new Web.Model.AdminFileTypeValue(4, "添加", false));
            FileType.Add("Modi", new Web.Model.AdminFileTypeValue(8, "修改", false));
            FileType.Add("Del", new Web.Model.AdminFileTypeValue(16, "删除", false));
            FileType.Add("Operate", new Web.Model.AdminFileTypeValue(2, "属性", false));
            FileType.Add("Audit", new Web.Model.AdminFileTypeValue(32, "审核", false));
            FileType.Add("Order", new Web.Model.AdminFileTypeValue(64, "排序", false));
            FileType.Add("Layout", new Web.Model.AdminFileTypeValue(128, "布局", false));
            FileType.Add("Push", new Web.Model.AdminFileTypeValue(256, "推送", false));
            FileType.Add("Recycle", new Web.Model.AdminFileTypeValue(512, "回收站", false));
            FileType.Add("Restore", new Web.Model.AdminFileTypeValue(1024, "还原", false));
        }
        /// <summary>
        /// 根据文件名获取权限返回
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public int GetPermissionsValue(string fileName)
        {
            int value = 0;//0显示
            foreach (string key in FileType.Keys)
            {
                if (fileName.ToLower().StartsWith(key.ToLower()))
                {
                    value = FileType[key].FileValue;
                    break;
                }
            }
            return value;
        }

        /// <summary>
        /// 专题、栏目使用的权限去除
        /// </summary>
        /// <param name="Fpvalue">原权限值</param>
        /// <param name="pvalue">新的权限值</param>
        /// <param name="i">顺序</param>
        /// <param name="id">ID值</param>
        /// <param name="InputName">控件的名称</param>
        /// <param name="displyString">值为“display="display"”</param>
        /// <param name="OtherString">其它样式信息</param>
        /// <returns></returns>
        public string CategorySpecailRoles(int Fpvalue, int pvalue, int i, string id, string InputName, string displyString, string OtherString)
        {
            StringBuilder str = new StringBuilder();
            int addvalue = 0;
            foreach (string key in FileType.Keys)
            {
                addvalue = FileType[key].FileValue;
                if ((Fpvalue & addvalue) == addvalue)
                {
                    str.Append(string.Format("&nbsp;&nbsp;<input type=\"checkbox\" value=\"{0}\"{1} name=\"{2}\" id=\"{3}\"{5}/><label for=\"{3}\">{4}</label>", addvalue.ToString(), ((pvalue & addvalue) == addvalue ? " checked=\"checked\" " : "") + displyString, InputName + id, InputName + i.ToString() + "_" + addvalue.ToString(), FileType[key].FileName, OtherString));
                }
            }
            return str.ToString();
        }

        /// <summary>
        /// 根据目录显示权限信息
        /// </summary>
        /// <param name="FilePath">文件地址</param>
        /// <param name="obj">从父级下面的ID依|分隔</param>
        /// <param name="str">权限分隔的值</param>
        /// <returns></returns>
        public string FileRoles(string FilePath, string obj, string str, string Pvalue)
        {
            string[] arr_ = obj.Split('|');
            StringBuilder strR = new StringBuilder();
            List<string> FileList = Base.IO.Dir.ReadDirFile(Base.IO.Dir.ReMoveFileName(Base.Fun.Management.RealManagementDirectory() + FilePath));
            foreach (string key in FileType.Keys)
            {
                for (int i = 0; i < FileList.Count; i++)
                {
                    if (FileList[i].Contains(key) && (Pvalue.Equals("all") || Web.UI.Roles.GetCheckStr(Pvalue, arr_[2], FileType[key].FileValue).Length > 0))
                    {
                        strR.Append(string.Format("<input name=\"active_{0}\" {1} type=\"checkbox\" class='menu1_{2} menu2_{3} menu3_{0}' id=\"active_{0}\" value=\"{4}\" />{5}&nbsp;", arr_[2], Web.UI.Roles.GetCheckStr(str, arr_[2], FileType[key].FileValue), arr_[0], arr_[1], FileType[key].FileValue, FileType[key].FileName));
                        break;
                    }
                }
            }
            return strR.ToString();
        }
    }
}
