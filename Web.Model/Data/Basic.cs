using System.Collections.Generic;

namespace Web.Model.Data
{
    /// <summary>
    /// 基础数据
    /// </summary>
    public class Basic
    {
        /// <summary>
        /// 成长时期参数
        /// </summary>
        public static Dictionary<string, string> CycleType = new Dictionary<string, string> { { "1", "孕期" }, { "2", "新生儿" }, { "3", "婴儿" }, { "4", "婴幼儿" }, { "5", "学龄前" } };
        /// <summary>
        /// 性别
        /// </summary>
        public static Dictionary<string, string> Sex = new Dictionary<string, string> { { "0", "男" }, { "1", "女" } };
        /// <summary>
        /// 绩效类型
        /// </summary>
        public static Dictionary<string, string> performanceType = new Dictionary<string, string> { { "10", "提成" }, { "1", "加班" }, { "2", "事假" }, { "3", "病假" }, { "4", "旷工" }, { "5", "迟到" }, { "6", "早退" }, { "7", "投诉" }, { "8", "违纪" }, { "9", "卫生" } };
        /// <summary>
        /// 来源
        /// </summary>
        public static Dictionary<string, string> Usersource = new Dictionary<string, string> { { "1", "灯箱路牌" }, { "2", "朋友推荐" }, { "3", "网络推广" }, { "4", "小区宣传" }, { "5", "合作机构" }, { "100", "其它" } };
        /// <summary>
        /// 婴儿类型
        /// </summary>
        public static Dictionary<string, string> BabyType = new Dictionary<string, string> { { "1", "婴儿" }, { "2", "幼儿" } };
        /// <summary>
        /// 卡日志类型
        /// </summary>
        public static Dictionary<string, string> cardlogtype = new Dictionary<string, string> { { "1", "续卡" }, { "2", "调整" }, { "3", "建卡" }, { "4", "停卡" }, { "5", "重开卡" } };
        /// <summary>
        /// 卡时长
        /// </summary>
        public static Dictionary<string, string> effectivetime = new Dictionary<string, string> { { "1", "1个月" }, { "2", "2个月" }, { "3", "3个月" }, { "6", "6个月" }, { "12", "12个月" }, { "18", "18个月" }, { "24", "24个月" }, { "30", "30个月" }, { "32", "32个月" }, { "36", "36个月" }, { "48", "48个月" }, { "60", "60个月" } };
        /// <summary>
        /// 员工状态
        /// </summary>
        public static Dictionary<string, string> memberstatus = new Dictionary<string, string> { { "0", "兼职" }, { "1", "全职" }, { "2", "离职" }, { "3", "退休" } };
        /// <summary>
        /// 购买短消息套餐处理结果
        /// </summary>
        public static Dictionary<string, string> MessageBugStatus = new Dictionary<string, string> { { "0", "处理中" }, { "1", "处理成功" }, { "-1", "放弃" }, { "2", "未通过" } };

        /// <summary>
        /// 过敏史
        /// </summary>
        public static Dictionary<string, string> allergy = new Dictionary<string, string> { { "0", "无过敏史" }, { "1", "鸡蛋过敏" }, { "2", "花粉过敏" }, { "3", "酒精过敏" }, { "4", "其他过敏" } };
        /// <summary>
        /// 病史
        /// </summary>
        public static Dictionary<string, string> illness = new Dictionary<string, string> { { "0", "无病史" }, { "1", "皮肤病" }, { "2", "手足口病" }, { "3", "其他病症" } };

        /// <summary>
        /// 预约类型
        /// </summary>
        public static Dictionary<string, string> Userappointment = new Dictionary<string, string> { { "0", "门店" }, { "1", "App" } };

        /// <summary>
        /// 顾客满意度
        /// </summary>
        public static Dictionary<string, string> satisfactionid = new Dictionary<string, string> { { "0", "不好" }, { "1", "一般" }, { "2", "满意" }, { "3", "表扬" } };


        /// <summary>
        /// 支付方式
        /// </summary>
        public static Dictionary<string, string> IsCash = new Dictionary<string, string> { { "0", "会员卡" }, { "1", "现金" }, { "2", "刷卡" }, { "3", "其它" } };

        /// <summary>
        /// 用户会员状态
        /// </summary>
        public static Dictionary<string, string> UserState = new Dictionary<string, string> { { "0", "未办卡" }, { "1", "已办卡" }, { "2", "体验" }, { "3", "咨询未到店" }, { "4", "咨询已到店" } };

        /// <summary>
        /// 回访结果
        /// </summary>
        public static Dictionary<string, string> ReturnresultID = new Dictionary<string, string> { { "0", "未接触" }, { "1", "未定" }, { "2", "已办卡" }, { "3", "拒绝" } };
        /// <summary>
        /// 回访结果
        /// </summary>
        public static Dictionary<string, string> IsGiveup = new Dictionary<string, string> { { "0", "不放弃" }, { "1", "放弃" } };



        /// <summary>
        /// 返回月龄
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string GetMonth(string datetime)
        {
            return "((year(GetDate())-year(" + datetime + "))*12 + month(GetDate())-month(" + datetime + ")+case when day(GetDate()) > day(" + datetime + ") then 0 else -1 end)";
        }
    }
}
