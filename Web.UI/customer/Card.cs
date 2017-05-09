using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Web.UI.customer
{
    /// <summary>
    /// 会员卡
    /// </summary>
    public class Card
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="cardNo">卡号</param>
        /// <param name="name">会员姓名</param>
        /// <param name="cardtype">卡类型</param>
        /// <param name="cycletype">婴儿类型</param>
        /// <param name="startnum">开始剩余次数</param>
        /// <param name="endnum">结束剩余次数</param>
        /// <param name="cardstatus">卡状态</param>
        /// <returns></returns>
        public static string View(string storesid, string cardNo, string userid, string name, string cardtypeid, string cycletype, string startnum, string endnum, string cardstatus, string Mobile)
        {
            DAL.customer.Card cDAL = new DAL.customer.Card();
            return cDAL.View(UI.Sys.SiteInfo.GetPageSize(), storesid, cardNo, userid, name, cardtypeid, cycletype, startnum, endnum, cardstatus, Mobile);
        }
        /// <summary>
        /// 正价次数，使用一次
        /// </summary>
        /// <param name="cardid"></param>
        public static void Update_positivenum(string cardid)
        {
            DAL.customer.Card cDAL = new DAL.customer.Card();
            cDAL.Update_positivenum(cardid);
        }
        /// <summary>
        /// 正价次数，增加一次
        /// </summary>
        /// <param name="cardid"></param>
        public static void Update_Addpositivenum(string userid)
        {
            DAL.customer.User uDAL = new DAL.customer.User();
            string cardid = uDAL.Read(userid).cardid;
            if (Base.Fun.fun.pnumeric(cardid))
            {
                DAL.customer.Card cDAL = new DAL.customer.Card();
                cDAL.Update_Addpositivenum(cardid);
            }
        }
        /// <summary>
        /// 赠送次数，使用一次
        /// </summary>
        /// <param name="cardid"></param>
        public static void Update_negativenum(string cardid)
        {
            DAL.customer.Card cDAL = new DAL.customer.Card();
            cDAL.Update_negativenum(cardid);
        }
        /// <summary>
        /// 赠送次数，使用一次
        /// </summary>
        /// <param name="cardid"></param>
        public static void Update_Addnegativenum(string userid)
        {
            DAL.customer.User uDAL = new DAL.customer.User();
            string cardid = uDAL.Read(userid).cardid;
            if (Base.Fun.fun.pnumeric(cardid))
            {
                DAL.customer.Card cDAL = new DAL.customer.Card();
                cDAL.Update_Addnegativenum(cardid);
            }
        }
        /// <summary>
        /// 使用金额
        /// </summary>
        /// <param name="cardid"></param>
        public static void Update_price(string cardid, string price)
        {
            DAL.customer.Card cDAL = new DAL.customer.Card();
            cDAL.Update_price(cardid, price);
        }
        /// <summary>
        /// 判断是否继续
        /// </summary>
        /// <param name="cModel"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool GetGo(Model.customer.Card cModel)
        {
            string str="";
            return GetGo(cModel, ref str);
        }
        /// <summary>
        /// 判断是否继续
        /// </summary>
        /// <param name="cModel"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool GetGo(Model.customer.Card cModel,ref string str)
        {
            bool bo = true;
            str = "";
            if (cModel.cardstatus.Equals("-1"))
            {
                bo = false;
                str = "<font color=red>会员卡已经停卡";
                if (Base.Time.Time.TimeBad(cModel.stoptime, DateTime.Now.ToString(), "天") > 0)
                {
                    str += "；<font color=blue>已到停止日期，请为此卡开卡</font>";
                }
                else {
                    str += "；" + Ami.DateTimeFormat(cModel.stoptime, "YY04-MM-DD"); ;
                }
                str += "</font>";
            }
            else if (Base.Time.Time.TimeBad(cModel.starttime, DateTime.Now.ToString(),"天") <0)
            {
                bo = false;
                str = "<font color=red>未到会员卡生效时间【" + cModel.starttime + "】</font>";
            }
            else if (Base.Time.Time.TimeBad(cModel.endtime, DateTime.Now.ToString(), "天") > 0)
            {
                bo = false;
                str = "<font color=red>会员卡已到失效日期【" + cModel.endtime + "】</font>";
            }
            return bo;
        }
        /// <summary>
        /// 判断卡片是否存在
        /// </summary>
        /// <param name="StoresID"></param>
        /// <param name="cardNo"></param>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public static bool IsCardIs(string StoresID,string cardNo,string cardNumber)
        {
            string cardid = "";
            DAL.customer.Card cDAL = new DAL.customer.Card();
            if (UI.Sys.stores.ReadOutlets(StoresID))
            {
                cardid = cDAL.Read_CardNo_Outlets(cardNo, cardNumber);
            }
            else
            {
                cardid = cDAL.Read_CardNo(StoresID, cardNo, cardNumber);
            }
            return Base.Fun.fun.pnumeric(cardid);
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="cardNo">卡号</param>
        /// <param name="name">会员姓名</param>
        /// <param name="cardtype">卡类型</param>
        /// <param name="cycletype">婴儿类型</param>
        /// <param name="startnum">开始剩余次数</param>
        /// <param name="endnum">结束剩余次数</param>
        /// <param name="cardstatus">卡状态</param>
        /// <returns></returns>
        public static void ViewToXls(string adminuserid, string storesid, string cardNo, string userid, string name, string cardtypeid, string cycletype, string startnum, string endnum, string cardstatus, string Mobile)
        {
            DAL.customer.Card cDAL = new DAL.customer.Card();
            DataTable dt = cDAL.ViewToXls(storesid, cardNo, userid, name, cardtypeid, cycletype, startnum, endnum, cardstatus, Mobile);
            if (dt.Rows.Count > 0)
            {
                string FileName = Base.Fun.Management.RealDirectory(Sys.SiteInfo.UpFile + "Files/User_" + adminuserid + ".xls");
                Base.IO.Dir.CheckDir(Base.IO.Dir.ReMoveFileName(FileName));
                Base.Office.ExcelHelper.Export(dt, "会员卡", FileName);
                System.Web.HttpContext.Current.Response.Write(SyCms.Window.DownFile.DownFileName(FileName, "会员卡.xls", true));
            }
            dt.Dispose();
        }
    }
}
