using System;
using System.Collections.Generic;

namespace Web.UI
{
    /// <summary>
    /// 角色关联菜单权限
    /// </summary>
    public class FilePermissions
    {
        /// <summary>
        /// 角色权限保存
        /// </summary>
        /// <param name="roleid">角色ID</param>
        /// <param name="chk_3">文件权限ID</param>
        public static string Update(string roleid, string chk_3)
        {
            string str = "['0','角色权限保存失败！']";
            try
            {
                Web.DAL.FilePermissions MFBLL = new Web.DAL.FilePermissions();
                MFBLL.Delete(roleid);
                string[] _chk_3 = chk_3.Split(',');
                int sum = 0;
                string active = "";
                for (int i = 0; i < _chk_3.Length; i++)///循环看选取了那些文件
                {
                    sum = 0;
                    active = Base.Fun.Fetch.getpost("active_" + _chk_3[i]);///获取对应文件的添加删除修改属性权限，看是否选中
                    if (!String.IsNullOrEmpty(active))
                    {
                        string[] _active = active.Split(',');
                        for (int k = 0; k < _active.Length; k++)
                        {
                            sum += int.Parse(_active[k]);
                        }
                    }
                    else
                    {
                        sum = 0;
                    }
                    MFBLL.Insert(roleid, _chk_3[i], sum.ToString());
                }
                Users.UpdateUserRole(roleid);
                str = "['1','角色权限保存成功！']";
            }
            catch (Exception ex)
            {
                Base.Error.Error.WriteError(ex);
            }
            return str;
        }
        /// <summary>
        /// 获取对应的权限
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns>特殊返回，第一个|分隔的文件ID值，第二个|分隔的ID,pvalue值</returns>
        public static Web.Model.FilePermissions GetFilePermissions(string roleid)
        {
            Web.DAL.FilePermissions MFBLL = new Web.DAL.FilePermissions();
            string reval1 = "|", reval2 = "|";
            Web.Model.FilePermissions arr = new Web.Model.FilePermissions();
            List<Web.Model.FilePermissions> MFModelList = MFBLL.ReadList(roleid);
            foreach (Web.Model.FilePermissions mfp in MFModelList)
            {
                reval1 += mfp.FileID + "|";
                reval2 += mfp.FileID + "," + mfp.Pvalue + "|";
            }
            arr.FileID = reval1;
            arr.Pvalue = reval2;
            return arr;
        }
    }
}
