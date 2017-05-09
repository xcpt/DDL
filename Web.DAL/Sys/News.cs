using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.Sys
{
    /// <summary>
    /// 信息类
    /// </summary>
    public class News
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="nModel"></param>
        /// <returns></returns>
        public string Insert(Model.Sys.News nModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",nModel.storesid,DbType.Int32),
                               db.CreateParameter("@classid",nModel.classid,DbType.Int32),
                               db.CreateParameter("@title",nModel.title,DbType.String),
                               db.CreateParameter("@tag",nModel.tag,DbType.String),
                               db.CreateParameter("@pic",nModel.pic,DbType.String),
                               db.CreateParameter("@fileurl",nModel.fileurl,DbType.String),
                               db.CreateParameter("@addtime",DateTime.Now,DbType.DateTime),
                               db.CreateParameter("@content",nModel.content,DbType.String),
                               db.CreateParameter("@orderid",nModel.orderid,DbType.Int32),
                               db.CreateParameter("@Province",nModel.Province,DbType.String),
                               db.CreateParameter("@sday",nModel.sday,DbType.Int32),
                               db.CreateParameter("@eday",nModel.eday,DbType.Int32),
                               db.CreateParameter("@author",nModel.author,DbType.String)
                               };
            string id = db.GetNewID(@"INSERT INTO [Sys_News]
           ([storesid]
           ,[classid]
           ,[title]
           ,[tag]
           ,[pic]
           ,[fileurl]
           ,[addtime]
           ,[content]
           ,[orderid]
           ,[Province]
           ,[sday]
           ,[eday]
           ,[author])
     VALUES
           (@storesid
           ,@classid
           ,@title
           ,@tag
           ,@pic
           ,@fileurl
           ,@addtime
           ,@content
           ,@orderid
           ,@Province
           ,@sday
           ,@eday
           ,@author)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="nModel"></param>
        /// <returns></returns>
        public int Update(Model.Sys.News nModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",nModel.storesid,DbType.Int32),
                               db.CreateParameter("@classid",nModel.classid,DbType.Int32),
                               db.CreateParameter("@title",nModel.title,DbType.String),
                               db.CreateParameter("@tag",nModel.tag,DbType.String),
                               db.CreateParameter("@pic",nModel.pic,DbType.String),
                               db.CreateParameter("@fileurl",nModel.fileurl,DbType.String),
                               db.CreateParameter("@content",nModel.content,DbType.String),
                               db.CreateParameter("@Province",nModel.Province,DbType.String),
                               db.CreateParameter("@sday",nModel.sday,DbType.Int32),
                               db.CreateParameter("@eday",nModel.eday,DbType.Int32),
                               db.CreateParameter("@author",nModel.author,DbType.String),
                               db.CreateParameter("@id",nModel.id,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [Sys_News]
   SET [storesid]=@storesid
      ,[classid] = @classid
      ,[title] = @title
      ,[tag] = @tag
      ,[pic] = @pic
      ,[fileurl] = @fileurl
      ,[content]=@content
      ,[Province]=@Province
      ,[sday]=@sday
      ,[eday]=@eday
      ,[author]=@author
 WHERE [id]=@id", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            int icount = db.GetRowCount(@"DELETE FROM [Sys_News] WHERE [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="id"></param>
        /// <param name="orderid"></param>
        public void SetOrder(string id, string orderid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            db.ExeSql("Update [Sys_News] set [orderid]=@orderid where [id]=@id", db.CreateParameter("@orderid", orderid, DbType.Int32), db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
        }
        /// <summary>
        /// 更新人气
        /// </summary>
        /// <param name="id"></param>
        public void UpdateHits(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            db.ExeSql("Update [Sys_News] set [hits]=[hits]+1 where [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Sys.News Read(string id)
        {
            Model.Sys.News nModel = new Model.Sys.News();
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[classid]
      ,[title]
      ,[tag]
      ,[pic]
      ,[fileurl]
      ,[addtime]
      ,[content]
      ,[orderid]
      ,[Province]
      ,[sday]
      ,[eday]
      ,[author]
  FROM [Sys_News] Where [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            if (dt.Rows.Count > 0)
            {
                nModel.id = dt.Rows[0]["id"].ToString();
                nModel.storesid = dt.Rows[0]["storesid"].ToString();
                nModel.classid = dt.Rows[0]["classid"].ToString();
                nModel.title = dt.Rows[0]["title"].ToString();
                nModel.tag = dt.Rows[0]["tag"].ToString();
                nModel.pic = dt.Rows[0]["pic"].ToString();
                nModel.fileurl = dt.Rows[0]["fileurl"].ToString();
                nModel.addtime = dt.Rows[0]["addtime"].ToString();
                nModel.content = dt.Rows[0]["content"].ToString();
                nModel.sday = dt.Rows[0]["sday"].ToString();
                nModel.eday = dt.Rows[0]["eday"].ToString();
                nModel.author = dt.Rows[0]["author"].ToString();
            }
            dt.Dispose();
            return nModel;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Sys.News Read(string classid, string SysName)
        {
            Model.Sys.News nModel = new Model.Sys.News();
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT top 1 [id]
      ,[storesid]
      ,[classid]
      ,[title]
      ,[tag]
      ,[pic]
      ,[fileurl]
      ,[addtime]
      ,[content]
      ,[orderid]
      ,[Province]
      ,[sday]
      ,[eday]
      ,[author]
  FROM [Sys_News] Where [classid]=@classid and [pic]=@pic order by [ID] desc", db.CreateParameter("@classid", classid, DbType.Int32), db.CreateParameter("@pic", SysName, DbType.String));
            db.Dispose();
            if (dt.Rows.Count > 0)
            {
                nModel.id = dt.Rows[0]["id"].ToString();
                nModel.storesid = dt.Rows[0]["storesid"].ToString();
                nModel.classid = dt.Rows[0]["classid"].ToString();
                nModel.title = dt.Rows[0]["title"].ToString();
                nModel.tag = dt.Rows[0]["tag"].ToString();
                nModel.pic = dt.Rows[0]["pic"].ToString();
                nModel.fileurl = dt.Rows[0]["fileurl"].ToString();
                nModel.addtime = dt.Rows[0]["addtime"].ToString();
                nModel.content = dt.Rows[0]["content"].ToString();
                nModel.sday = dt.Rows[0]["sday"].ToString();
                nModel.eday = dt.Rows[0]["eday"].ToString();
                nModel.author = dt.Rows[0]["author"].ToString();
            }
            dt.Dispose();
            return nModel;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable Read_DataTable(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT [id]
      ,[storesid]
      ,[classid]
      ,[title]
      ,[tag]
      ,[pic]
      ,[fileurl]
      ,[addtime]
      ,[content]
      ,[province]
      ,[orderid]
      ,[sday]
      ,[eday]
      ,[author]
      ,[hits]
  FROM [Sys_News] Where [id]=@id", db.CreateParameter("@id", id, DbType.Int32));
            db.Dispose();
            return dt;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public string View(int PageSize, string classid, string storesid, string title)
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
                page.TableName = "[Sys_News] as a left join [Sys_stores] as b on a.[storesid]=b.[storesid] left join [Sys_Category] as c on a.[classid]=c.[classid]";
                page.OrderBy = "order by a.[OrderID] asc,a.[id] desc";
                page.Index = "a.[id]";
                page.Field = "a.[id],c.[classname],a.[orderid],a.[pic],a.[title],a.[tag],a.[Province],b.[title] as storesName,a.[addtime]";
                List<string> Filter = new List<string>();
                if (Base.Fun.fun.pnumeric(storesid))
                {
                    Filter.Add("a.[storesid]=" + storesid);
                }
                if (Base.Fun.fun.pnumeric(classid))
                {
                    Filter.Add("a.[classid]=" + classid);
                }
                else
                {
                    Filter.Add("a.[classid]<>2 and a.[classid]<>3");
                }
                if (title.Length > 0)
                {
                    Filter.Add("a.[title] like '%" + title + "%'");
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
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public DataTable ReadListApp(string storesid, string classid, string Page)
        {
            DataTable dt = new DataTable();
            Base.Page.Dividepage page = new Base.Page.Dividepage();
            page.PageSize = 10;
            page.TableName = "[Sys_News]";
            page.OrderBy = "order by [id] desc";
            page.Index = "[id]";
            page.Field = "[id],[pic],[fileurl],[title],[tag],[addtime],[hits]";
            List<string> Filter = new List<string>();
            if (Base.Fun.fun.pnumeric(storesid))
            {
                Filter.Add("[storesid]=" + storesid);
            }
            if(Base.Fun.fun.pnumeric(classid))
            {
                Filter.Add("[classid]=" + classid);
            }
            page.Filter = string.Join(" and ", Filter.ToArray());
            dt = page.getrows();
            int maxPage = page.MaxPage;
            page.Dispose();
            if (int.Parse(Page) > maxPage)
            {
                return new DataTable();
            }
            else
            {
                return dt;
            }
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public DataTable ReadListApp(string storesid, string classid, int day, string Page)
        {
            DataTable dt = new DataTable();
            Base.Page.Dividepage page = new Base.Page.Dividepage();
            page.PageSize = 10;
            page.TableName = "[Sys_News]";
            page.OrderBy = "order by [id] desc";
            page.Index = "[id]";
            page.Field = "[id],[pic],[fileurl],[title],[tag],[addtime],[hits]";
            List<string> Filter = new List<string>();
            if (Base.Fun.fun.pnumeric(storesid))
            {
                Filter.Add("[storesid]=" + storesid);
            }
            if (Base.Fun.fun.pnumeric(classid))
            {
                Filter.Add("[classid]=" + classid);
            }
            Filter.Add("(([sday]=0 and [eday]=0) or ([sday]>=" + day + " and [eday]<=" + day + "))");
            page.Filter = string.Join(" and ", Filter.ToArray());
            dt = page.getrows();
            int maxPage = page.MaxPage;
            page.Dispose();
            if (int.Parse(Page) > maxPage)
            {
                return new DataTable();
            }
            else
            {
                return dt;
            }
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public DataTable ReadListApp(string storesid, string Province, string classid, int Num)
        {
            DataTable dt = new DataTable();
            Base.Conn.Database db = new Base.Conn.Database();
            dt = db.GetData("select top " + Num.ToString() + " [id],[pic],[fileurl],[title],[tag],[addtime] From [Sys_News] Where ([storesid]=" + storesid + " or [storesid]=0) and ([Province]='' or Province like '" + Province + "') and [classid]=" + classid + " order by [OrderID] asc,[id] desc");
            return dt;
        }

        /// <summary>
        /// 显示（不读取8，9，10）
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public DataTable ReadListAppIndex(int Num, int Days)
        {
            DataTable dt = new DataTable();
            Base.Conn.Database db = new Base.Conn.Database();
            dt = db.GetData("select top " + Num.ToString() + " a.[id],a.[pic],a.[title],a.[fileurl],a.[tag],a.[hits] From [Sys_News] as a inner join [Sys_Category] as b on a.[classid]=b.[classid] and b.[parentid] not in(8,9,10) Where b.[sday]<=" + Days + " and b.[eday]>=" + Days + " order by NEWID() desc");
            return dt;
        }
        /// <summary>
        /// 显示（不读取8，9，10）
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public DataTable ReadListAppIndex(int Num, int Days, string ParentID)
        {
            DataTable dt = new DataTable();
            Base.Conn.Database db = new Base.Conn.Database();
            dt = db.GetData("select top " + Num.ToString() + " a.[id],a.[pic],a.[fileurl],a.[title],a.[tag],a.[hits] From [Sys_News] as a inner join [Sys_Category] as b on a.[classid]=b.[classid] and b.[parentid] =" + ParentID + " Where b.[sday]<=" + Days + " and b.[eday]>=" + Days + " order by NEWID() desc");
            return dt;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public DataTable ReadListAppParentCate(int Num, string ParentID)
        {
            DataTable dt = new DataTable();
            Base.Conn.Database db = new Base.Conn.Database();
            dt = db.GetData("select top " + Num.ToString() + " a.[id],a.[pic],a.[title],[fileurl],a.[tag],a.[hits] From [Sys_News] as a inner join [Sys_Category] as b on a.[classid]=b.[classid] Where b.[ParentID]=" + ParentID + " order by a.[id] desc");
            return dt;
        }
    }
}
