using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.baby
{
    /// <summary>
    /// 成长相册
    /// </summary>
    public class album
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="aModel"></param>
        /// <returns></returns>
        public string Insert(Model.baby.album aModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@monthage",aModel.monthage,DbType.Int32),
                               db.CreateParameter("@UserID",aModel.UserID,DbType.Int32),
                               db.CreateParameter("@addtime",aModel.addtime,DbType.DateTime),
                               db.CreateParameter("@picurl",aModel.picurl,DbType.String),
                               db.CreateParameter("@picmd5",aModel.picmd5,DbType.String),
                               db.CreateParameter("@Praise",aModel.Praise,DbType.Int32),
                               db.CreateParameter("@Hits",aModel.hits,DbType.Int32)
                               };
            string id = db.GetNewID(@"INSERT INTO [baby_album]
           ([monthage]
           ,[UserID]
           ,[addtime]
           ,[picurl]
           ,[picmd5]
           ,[Praise]
           ,[hits])
     VALUES
           (@monthage
           ,@UserID
           ,@addtime
           ,@picurl
           ,@picmd5
           ,@Praise
           ,@Hits)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount("DELETE FROM [baby_album] WHERE [ID]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 显示内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.baby.album Read(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[monthage]
      ,[UserID]
      ,[addtime]
      ,[picurl]
      ,[picmd5]
      ,[Praise]
      ,[hits]
  FROM [baby_album] Where [ID]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            Model.baby.album aModel = new Model.baby.album();
            if (dt.Rows.Count > 0)
            {
                aModel.id = dt.Rows[0]["id"].ToString();
                aModel.monthage = dt.Rows[0]["monthage"].ToString();
                aModel.UserID = dt.Rows[0]["UserID"].ToString();
                aModel.addtime = dt.Rows[0]["addtime"].ToString();
                aModel.picurl = dt.Rows[0]["picurl"].ToString();
                aModel.picmd5 = dt.Rows[0]["picmd5"].ToString();
                aModel.Praise = dt.Rows[0]["Praise"].ToString();
                aModel.hits = dt.Rows[0]["hits"].ToString();
            }
            dt.Dispose();
            return aModel;
        }

        /// <summary>
        /// 读取数量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Read_PhotoNum(string UserID)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string num = db.GetValue(@"SELECT count([id]) FROM [baby_album] Where [UserID]=@UserID", db.CreateParameter("@UserID", UserID, DbType.Int32)).ToString();
            db.Dispose();
            return num;
        }

        /// <summary>
        /// 读取照片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Read_LastPhoto(string UserID)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string picurl = db.GetValue(@"SELECT top 1 picurl FROM [baby_album] Where [UserID]=@UserID order by [id] desc", db.CreateParameter("@UserID", UserID, DbType.Int32)).ToString();
            db.Dispose();
            return picurl;
        }

        /// <summary>
        /// 更新赞
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Update_Praise(string UserID,string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string picurl = db.GetValue(@"Update [baby_album] set [Praise]=[Praise]+1 Where [UserID]=@UserID and [id]=@id", db.CreateParameter("@UserID", UserID, DbType.Int32), db.CreateParameter("@id", id, DbType.Int32)).ToString();
            db.Dispose();
            return picurl;
        }
        /// <summary>
        /// 更新赞
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Update_PraiseCancel(string UserID, string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string picurl = db.GetValue(@"Update [baby_album] set [Praise]=[Praise]-1 Where [UserID]=@UserID and [id]=@id", db.CreateParameter("@UserID", UserID, DbType.Int32), db.CreateParameter("@id", id, DbType.Int32)).ToString();
            db.Dispose();
            return picurl;
        }
        /// <summary>
        /// 更新单照片人气
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Update_Hits(string UserID, string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string picurl = db.GetValue(@"Update [baby_album] set [Hits]=[Hits]+1 Where [UserID]=@UserID and [id]=@id", db.CreateParameter("@UserID", UserID, DbType.Int32), db.CreateParameter("@id", id, DbType.Int32)).ToString();
            db.Dispose();
            return picurl;
        }

        /// <summary>
        /// 读取用户照片
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Page"></param>
        /// <returns></returns>
        public DataTable Read_AppList(string PhotoUserID, string monthage, string UserID, string addtime, string Page)
        {
            Base.Page.Dividepage page = new Base.Page.Dividepage();
            page.TableName = "[baby_album] as a";
            page.OrderBy = "order by a.[id] desc";
            page.Index = "a.[id]";
            page.Filter = "a.[userid]=" + PhotoUserID + " and a.[monthage]=" + monthage + (Base.Fun.fun.pnumeric(addtime) ? " and datediff(d,a.[addtime],'" + DateTime.Now.ToString() + "')==0" : "");
            page.Field = "a.[id],a.[picurl],CONVERT(varchar(100), a.[addtime], 23) as addtime,a.[monthage],a.[praise],a.[hits] as photohits,(select top 1 [id] From [baby_album_Praise] Where [albumid]=a.[id] and [UserID]=" + UserID + ") as praiseid";
            page.PageSize = 10;
            DataTable dt = page.getrows();
            int maxpage = page.MaxPage;
            page.Dispose();
            if (int.Parse(Page) > maxpage)
            {
                return new DataTable();
            }
            else
            {
                return dt;
            }
        }

        /// <summary>
        /// 读取用户照片
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Page"></param>
        /// <returns></returns>
        public DataTable Read_AppList(string PhotoUserID)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT distinct
		a.[UserID]
      ,a.[monthage]
      ,(select top 1 CONVERT(varchar(100), [addtime], 23) from [baby_album] where UserID=a.UserID and monthage=a.monthage order by id desc) as addtime
      ,(select COUNT(id) from [baby_album] where UserID=a.UserID and monthage=a.monthage) as photonum
      ,(select sum(hits) from [baby_album] where UserID=a.UserID and monthage=a.monthage) as photohits
      ,(select top 1 picurl from [baby_album] where UserID=a.UserID and monthage=a.monthage order by id desc) as lastphotourl
  FROM [baby_album] as a where a.[UserID]=" + PhotoUserID + " order by a.[monthage] desc,addtime desc");
            db.Dispose();
            return dt;
        }

        /// <summary>
        /// 读取用户照片
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Page"></param>
        /// <returns></returns>
        public DataTable Read_AppList(string UserID, string Page)
        {
            Base.Page.Dividepage page = new Base.Page.Dividepage();
            page.TableName = "[baby_album] as a inner join [customer_User] as b on a.[userid]=b.[userid] inner join [Sys_stores] as c on b.[storesid]=c.[storesid]";
            page.OrderBy = "order by a.[Praise] desc,a.[hits] desc";
            page.Index = "a.[id]";
            page.Field = "a.[id],a.[userid],b.[name],b.[nickname],b.[userface],c.[province],a.[picurl],CONVERT(varchar(100), a.[addtime], 23) as addtime,a.[monthage],a.[praise],a.[hits],(select top 1 [id] From [baby_album_Praise] Where [albumid]=a.[id] and [UserID]=" + UserID + ") as praiseid";
            page.PageSize = 10;
            DataTable dt = page.getrows();
            int maxpage = page.MaxPage;
            page.Dispose();
            if (int.Parse(Page) > maxpage)
            {
                return new DataTable();
            }
            else
            {
                return dt;
            }
        }
        /// <summary>
        /// 显示内容
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="CardNo"></param>
        /// <param name="MonthAge"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public string View(int PageSize, string storesid, string userid, string CardNo, string MonthAge, string StartTime, string EndTime)
        {
            StringBuilder str = new StringBuilder();
            DataTable dt = new DataTable();
            Base.Page.Dividepage page = new Base.Page.Dividepage();
            try
            {
                if (PageSize <= 0)
                {
                    PageSize = 15;
                }
                page.PageSize = PageSize;
                page.TableName = "[baby_album] as a inner join [customer_User] as b on a.[UserID]=b.[UserID] inner join [customer_Card] as c on b.[CardID]=c.[CardID]";
                page.OrderBy = "order by a.[id] desc";
                page.Index = "a.[ID]";
                page.Field = "a.[ID],a.[picurl],c.[CardNo],b.[Name],b.[NickName],b.[Sex],a.[monthage],a.[addtime],[Praise],a.[picurl]";
                List<string> Filter = new List<string>();
                Filter.Add("b.[storesid]=" + storesid);
                if (Base.Fun.fun.pnumeric(userid))
                {
                    Filter.Add("a.[userid]=" + userid);
                }
                if (CardNo.Length > 0)
                {
                    if (CardNo.Length >= 10)
                    {
                        Filter.Add("c.[cardNumber]='" + CardNo + "'");
                    }
                    else
                    {
                        Filter.Add("c.[CardNo]='" + CardNo + "'");
                    }
                }
                if (Base.Fun.fun.pnumeric(MonthAge))
                {
                    Filter.Add("a.[monthage]=" + MonthAge);
                }
                if (StartTime.Length > 0 && Base.Fun.fun.IsDate(StartTime))
                {
                    Filter.Add("a.[addtime]>='" + StartTime + "'");
                }
                if (EndTime.Length > 0 && Base.Fun.fun.IsDate(EndTime))
                {
                    Filter.Add("a.[addtime]<='" + EndTime + "'");
                }
                page.Filter = string.Join(" and ", Filter.ToArray());
                dt = page.getrows();
                str.Append(Base.Conn.Json.DataTable2Json(page.Page, page.TotalRow, dt, null));
            }
            catch (Exception e)
            {
                Base.Error.Error.WriteError(e);
                //错误记录
            }
            finally
            {
                dt.Dispose();
                page.Dispose();
            }
            return str.ToString();
        }
    }
}
