using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.UI.Data
{
    public class Basic
    {
        /// <summary>
        /// 读取 绩效类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string performanceType(string id)
        {
            StringBuilder str = new StringBuilder();
            foreach (string s in Model.Data.Basic.performanceType.Keys)
            {
                str.Append("<option value=\"" + s + "\""+(s.Equals(id)?" selected=\"selected\"":"")+">" + Model.Data.Basic.performanceType[s] + "</option>");
            }
            return str.ToString();
        }
        /// <summary>
        /// 读取 绩效类型转JS
        /// </summary>
        /// <returns></returns>
        public static string performanceTypeToJs(string strStart)
        {
            StringBuilder str = new StringBuilder();
            str.Append("{");
            foreach (string s in Model.Data.Basic.performanceType.Keys)
            {
                str.Append("\"" + strStart + s + "\":\"" + Model.Data.Basic.performanceType[s] + "\",");
            }
            str.Append("}");
            return str.ToString().Replace(",}", "}");
        }
        /// <summary>
        /// 输出表格头
        /// </summary>
        /// <returns></returns>
        public static string performanceTypeToJsHead()
        {
            StringBuilder str = new StringBuilder();
            foreach (string s in Model.Data.Basic.performanceType.Keys)
            {
                str.Append("{ display: '" + Model.Data.Basic.performanceType[s] + "', name: 'type_" + s + "', width: 50, sortable: false, align: 'right',process:PriceNum},");
            }
            return str.ToString();
        }
        /// <summary>
        /// 短消息处理结果
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string MessageBugStatus(string id)
        {
            StringBuilder str = new StringBuilder();
            foreach (string s in Model.Data.Basic.MessageBugStatus.Keys)
            {
                str.Append("<option value=\"" + s + "\"" + (s.Equals(id) ? " selected=\"selected\"" : "") + ">" + Model.Data.Basic.MessageBugStatus[s] + "</option>");
            }
            return str.ToString();
        }
        /// <summary>
        /// 短消息处理结果
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string MessageBugStatusToJs(string strStart)
        {
            StringBuilder str = new StringBuilder();
            str.Append("{");
            foreach (string s in Model.Data.Basic.MessageBugStatus.Keys)
            {
                str.Append("\"" + strStart + s + "\":\"" + Model.Data.Basic.MessageBugStatus[s] + "\",");
            }
            str.Append("}");
            return str.ToString().Replace(",}", "}");
        }

        /// <summary>
        /// 婴儿类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string BabyType(string id)
        {
            StringBuilder str = new StringBuilder();
            foreach (string s in Model.Data.Basic.BabyType.Keys)
            {
                str.Append("<option value=\"" + s + "\"" + (s.Equals(id) ? " selected=\"selected\"" : "") + ">" + Model.Data.Basic.BabyType[s] + "</option>");
            }
            return str.ToString();
        }
        /// <summary>
        /// 获得婴儿类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetBabyType(string id)
        {
            if (Model.Data.Basic.BabyType.ContainsKey(id))
            {
                return Model.Data.Basic.BabyType[id];
            }
            else {
                return "";
            }
        }
        /// <summary>
        /// 婴儿类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string BabyTypeToJs(string strStart)
        {
            StringBuilder str = new StringBuilder();
            str.Append("{");
            foreach (string s in Model.Data.Basic.BabyType.Keys)
            {
                str.Append("\"" + strStart + s + "\":\"" + Model.Data.Basic.BabyType[s] + "\",");
            }
            str.Append("}");
            return str.ToString().Replace(",}", "}");
        }



        /// <summary>
        /// 卡日期变更
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string cardlogtypeType(string id)
        {
            StringBuilder str = new StringBuilder();
            foreach (string s in Model.Data.Basic.cardlogtype.Keys)
            {
                str.Append("<option value=\"" + s + "\"" + (s.Equals(id) ? " selected=\"selected\"" : "") + ">" + Model.Data.Basic.cardlogtype[s] + "</option>");
            }
            return str.ToString();
        }
        /// <summary>
        /// 卡日期变更
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string cardlogtypeToJs(string strStart)
        {
            StringBuilder str = new StringBuilder();
            str.Append("{");
            foreach (string s in Model.Data.Basic.cardlogtype.Keys)
            {
                str.Append("\"" + strStart + s + "\":\"" + Model.Data.Basic.cardlogtype[s] + "\",");
            }
            str.Append("}");
            return str.ToString().Replace(",}", "}");
        }
        /// <summary>
        /// 时长
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string effectivetime(string id)
        {
            StringBuilder str = new StringBuilder();
            foreach (string s in Model.Data.Basic.effectivetime.Keys)
            {
                str.Append("<option value=\"" + s + "\"" + (s.Equals(id) ? " selected=\"selected\"" : "") + ">" + Model.Data.Basic.effectivetime[s] + "</option>");
            }
            return str.ToString();
        }

        /// <summary>
        /// 过敏史
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string allergy(string id)
        {
            StringBuilder str = new StringBuilder();
            foreach (string s in Model.Data.Basic.allergy.Keys)
            {
                str.Append("<option value=\"" + s + "\"" + (s.Equals(id) ? " selected=\"selected\"" : "") + ">" + Model.Data.Basic.allergy[s] + "</option>");
            }
            return str.ToString();
        }
        /// <summary>
        /// 获得过敏史名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string Getallergy(string id)
        {
            if (Model.Data.Basic.allergy.ContainsKey(id))
            {
                return Model.Data.Basic.allergy[id];
            }
            else {
                return "";
            }
        }
        /// <summary>
        /// 病史
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string illness(string id)
        {
            StringBuilder str = new StringBuilder();
            foreach (string s in Model.Data.Basic.illness.Keys)
            {
                str.Append("<option value=\"" + s + "\"" + (s.Equals(id) ? " selected=\"selected\"" : "") + ">" + Model.Data.Basic.illness[s] + "</option>");
            }
            return str.ToString();
        }
        /// <summary>
        /// 获得病史名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string Getillness(string id)
        {
            if (Model.Data.Basic.illness.ContainsKey(id))
            {
                return Model.Data.Basic.illness[id];
            }
            else {
                return "";
            }
        }
        /// <summary>
        /// 客户来源
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string Usersource(string id)
        {
            StringBuilder str = new StringBuilder();
            foreach (string s in Model.Data.Basic.Usersource.Keys)
            {
                str.Append("<option value=\"" + s + "\"" + (s.Equals(id) ? " selected=\"selected\"" : "") + ">" + Model.Data.Basic.Usersource[s] + "</option>");
            }
            return str.ToString();
        }
        /// <summary>
        /// 获得客户来源
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetUsersource(string id)
        {
            if (Model.Data.Basic.Usersource.ContainsKey(id))
            {
                return Model.Data.Basic.Usersource[id];
            }
            else {
                return "";
            }
        }


        /// <summary>
        /// 婴儿类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string UserappointmentToJs(string strStart)
        {
            StringBuilder str = new StringBuilder();
            str.Append("{");
            foreach (string s in Model.Data.Basic.Userappointment.Keys)
            {
                str.Append("\"" + strStart + s + "\":\"" + Model.Data.Basic.Userappointment[s] + "\",");
            }
            str.Append("}");
            return str.ToString().Replace(",}", "}");
        }


        /// <summary>
        /// 消费满意度
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string satisfactionid(string id)
        {
            StringBuilder str = new StringBuilder();
            foreach (string s in Model.Data.Basic.satisfactionid.Keys)
            {
                str.Append("<option value=\"" + s + "\"" + (s.Equals(id) ? " selected=\"selected\"" : "") + ">" + Model.Data.Basic.satisfactionid[s] + "</option>");
            }
            return str.ToString();
        }
        /// <summary>
        /// 消费满意度
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string satisfactionidToJs(string strStart)
        {
            StringBuilder str = new StringBuilder();
            str.Append("{");
            foreach (string s in Model.Data.Basic.satisfactionid.Keys)
            {
                str.Append("\"" + strStart + s + "\":\"" + Model.Data.Basic.satisfactionid[s] + "\",");
            }
            str.Append("}");
            return str.ToString().Replace(",}", "}");
        }

        /// <summary>
        /// 支付方式
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string IsCash(string id)
        {
            StringBuilder str = new StringBuilder();
            foreach (string s in Model.Data.Basic.IsCash.Keys)
            {
                str.Append("<option value=\"" + s + "\"" + (s.Equals(id) ? " selected=\"selected\"" : "") + ">" + Model.Data.Basic.IsCash[s] + "</option>");
            }
            return str.ToString();
        }
        /// <summary>
        /// 支付方式
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string IsCashToJs(string strStart)
        {
            StringBuilder str = new StringBuilder();
            str.Append("{");
            foreach (string s in Model.Data.Basic.IsCash.Keys)
            {
                str.Append("\"" + strStart + s + "\":\"" + Model.Data.Basic.IsCash[s] + "\",");
            }
            str.Append("}");
            return str.ToString().Replace(",}", "}");
        }


        /// <summary>
        /// 成长周期
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string CycleType(string id)
        {
            StringBuilder str = new StringBuilder();
            foreach (string s in Model.Data.Basic.CycleType.Keys)
            {
                str.Append("<option value=\"" + s + "\"" + (s.Equals(id) ? " selected=\"selected\"" : "") + ">" + Model.Data.Basic.CycleType[s] + "</option>");
            }
            return str.ToString();
        }
        /// <summary>
        /// 成长周期
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string CycleTypeToJs(string strStart)
        {
            StringBuilder str = new StringBuilder();
            str.Append("{");
            foreach (string s in Model.Data.Basic.CycleType.Keys)
            {
                str.Append("\"" + strStart + s + "\":\"" + Model.Data.Basic.CycleType[s] + "\",");
            }
            str.Append("}");
            return str.ToString().Replace(",}", "}");
        }
        /// <summary>
        /// 用户状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string UserState(string id)
        {
            StringBuilder str = new StringBuilder();
            foreach (string s in Model.Data.Basic.UserState.Keys)
            {
                str.Append("<option value=\"" + s + "\"" + (s.Equals(id) ? " selected=\"selected\"" : "") + ">" + Model.Data.Basic.UserState[s] + "</option>");
            }
            return str.ToString();
        }

        /// <summary>
        /// 回访结果
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string ReturnresultID(string id)
        {
            StringBuilder str = new StringBuilder();
            foreach (string s in Model.Data.Basic.ReturnresultID.Keys)
            {
                str.Append("<option value=\"" + s + "\"" + (s.Equals(id) ? " selected=\"selected\"" : "") + ">" + Model.Data.Basic.ReturnresultID[s] + "</option>");
            }
            return str.ToString();
        }
        /// <summary>
        /// 回访结果
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string ReturnresultIDToJs(string strStart)
        {
            StringBuilder str = new StringBuilder();
            str.Append("{");
            foreach (string s in Model.Data.Basic.ReturnresultID.Keys)
            {
                str.Append("\"" + strStart + s + "\":\"" + Model.Data.Basic.ReturnresultID[s] + "\",");
            }
            str.Append("}");
            return str.ToString().Replace(",}", "}");
        }


        /// <summary>
        /// 是否放弃
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string IsGiveup(string id)
        {
            StringBuilder str = new StringBuilder();
            foreach (string s in Model.Data.Basic.IsGiveup.Keys)
            {
                str.Append("<option value=\"" + s + "\"" + (s.Equals(id) ? " selected=\"selected\"" : "") + ">" + Model.Data.Basic.IsGiveup[s] + "</option>");
            }
            return str.ToString();
        }
        /// <summary>
        /// 是否放弃
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string IsGiveupToJs(string strStart)
        {
            StringBuilder str = new StringBuilder();
            str.Append("{");
            foreach (string s in Model.Data.Basic.IsGiveup.Keys)
            {
                str.Append("\"" + strStart + s + "\":\"" + Model.Data.Basic.IsGiveup[s] + "\",");
            }
            str.Append("}");
            return str.ToString().Replace(",}", "}");
        }
        
    }
}
