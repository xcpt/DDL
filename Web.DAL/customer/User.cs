using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Web.DAL.customer
{
    public class User
    {
        private string SqlStr = @"SELECT [userid]
      ,[userpass]
      ,[storesid]
      ,[userstoresid]
      ,[name]
      ,[nickname]
      ,[sex]
      ,[birthday]
      ,[parentName]
      ,[tel]
      ,[mobile]
      ,[communityid]
      ,[illness]
      ,[allergy]
      ,[cycletype]
      ,[source]
      ,[content]
      ,[addtime]
      ,[cardid]
      ,[IsMeasure]
      ,[IsPhoto]
      ,[scorenum]
      ,[IsPush]
      ,[Error]
      ,[ErrorTime]
      ,[AppID]
      ,[Client]
      ,[Model]
      ,[State]
      ,[userface]
      ,[photonum]
      ,[maxtimenum]
      ,[lasttime]
  FROM [customer_User] Where ";
        private string SqlStr_Join = @"SELECT a.[userid]
      ,a.[userpass]
      ,a.[storesid]
      ,a.[userstoresid]
      ,a.[name]
      ,a.[nickname]
      ,a.[sex]
      ,a.[birthday]
      ,a.[parentName]
      ,a.[tel]
      ,a.[mobile]
      ,a.[communityid]
      ,a.[illness]
      ,a.[allergy]
      ,a.[cycletype]
      ,a.[source]
      ,a.[content]
      ,a.[addtime]
      ,a.[cardid]
      ,a.[IsMeasure]
      ,a.[IsPhoto]
      ,a.[scorenum]
      ,a.[IsPush]
      ,a.[Error]
      ,a.[ErrorTime]
      ,a.[AppID]
      ,a.[Client]
      ,a.[Model]
      ,a.[State]
      ,a.[userface]
      ,a.[photonum]
      ,a.[maxtimenum]
      ,a.[lasttime]";
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="uModel"></param>
        /// <returns></returns>
        public string Insert(Model.customer.User uModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@userpass",uModel.userpass,DbType.String),
                               db.CreateParameter("@storesid",uModel.storesid,DbType.Int32),
                               db.CreateParameter("@userstoresid",uModel.storesid,DbType.Int32),
                               db.CreateParameter("@name",uModel.name,DbType.String),
                               db.CreateParameter("@nickname",uModel.nickname,DbType.String),
                               db.CreateParameter("@sex",uModel.sex,DbType.Int32),
                               db.CreateParameter("@birthday",uModel.birthday,DbType.DateTime),
                               db.CreateParameter("@parentName",uModel.parentName,DbType.String),
                               db.CreateParameter("@tel",uModel.tel,DbType.String),
                               db.CreateParameter("@mobile",uModel.mobile,DbType.String),
                               db.CreateParameter("@communityid",uModel.communityid,DbType.Int32),
                               db.CreateParameter("@illness",uModel.illness,DbType.String),
                               db.CreateParameter("@allergy",uModel.allergy,DbType.String),
                               db.CreateParameter("@cycletype",uModel.cycletype,DbType.Int32),
                               db.CreateParameter("@source",uModel.source,DbType.Int32),
                               db.CreateParameter("@content",uModel.content,DbType.String),
                               db.CreateParameter("@addtime",Base.Fun.fun.IsDate(uModel.addtime)?uModel.addtime:DateTime.Now.ToString(),DbType.DateTime),
                               db.CreateParameter("@cardid",uModel.cardid,DbType.Int32),
                               db.CreateParameter("@IsMeasure",uModel.IsMeasure,DbType.Int32),
                               db.CreateParameter("@IsPhoto",uModel.IsPhoto,DbType.Int32),
                               db.CreateParameter("@scorenum",uModel.scorenum,DbType.Int32),
                               db.CreateParameter("@State",uModel.State,DbType.Int32),
                               db.CreateParameter("@IsPush",uModel.IsPush,DbType.Int32),
                               db.CreateParameter("@Error",uModel.Error,DbType.Int32),
                               db.CreateParameter("@ErrorTime",Base.Fun.fun.IsDate(uModel.ErrorTime)?uModel.ErrorTime:null,DbType.DateTime),
                               db.CreateParameter("@maxtimenum",uModel.maxtimenum,DbType.Int32),
                               db.CreateParameter("@lasttime",Base.Fun.fun.IsDate(uModel.lasttime)?uModel.lasttime:null,DbType.DateTime)
                               };
            string id = db.GetNewID(@"INSERT INTO [customer_User]
           ([userpass]
           ,[storesid]
           ,[userstoresid]
           ,[name]
           ,[nickname]
           ,[sex]
           ,[birthday]
           ,[parentName]
           ,[tel]
           ,[mobile]
           ,[communityid]
           ,[illness]
           ,[allergy]
           ,[cycletype]
           ,[source]
           ,[content]
           ,[addtime]
           ,[cardid]
           ,[IsMeasure]
           ,[IsPhoto]
           ,[scorenum]
           ,[State]
           ,[IsPush]
           ,[Error]
           ,[ErrorTime]
           ,[maxtimenum]
           ,[lasttime])
     VALUES
           (@userpass
           ,@storesid
           ,@userstoresid
           ,@name
           ,@nickname
           ,@sex
           ,@birthday
           ,@parentName
           ,@tel
           ,@mobile
           ,@communityid
           ,@illness
           ,@allergy
           ,@cycletype
           ,@source
           ,@content
           ,@addtime
           ,@cardid
           ,@IsMeasure
           ,@IsPhoto
           ,@scorenum
           ,@State
           ,@IsPush
           ,@Error
           ,@ErrorTime
           ,@maxtimenum
           ,@lasttime)", ps).ToString();
            db.Dispose();
            return id;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="uModel"></param>
        /// <returns></returns>
        public int Update(Model.customer.User uModel)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@userpass",uModel.userpass,DbType.String),
                               db.CreateParameter("@name",uModel.name,DbType.String),
                               db.CreateParameter("@nickname",uModel.nickname,DbType.String),
                               db.CreateParameter("@sex",uModel.sex,DbType.Int32),
                               db.CreateParameter("@birthday",uModel.birthday,DbType.DateTime),
                               db.CreateParameter("@parentName",uModel.parentName,DbType.String),
                               db.CreateParameter("@tel",uModel.tel,DbType.String),
                               db.CreateParameter("@mobile",uModel.mobile,DbType.String),
                               db.CreateParameter("@communityid",uModel.communityid,DbType.Int32),
                               db.CreateParameter("@illness",uModel.illness,DbType.String),
                               db.CreateParameter("@allergy",uModel.allergy,DbType.String),
                               db.CreateParameter("@cycletype",uModel.cycletype,DbType.Int32),
                               db.CreateParameter("@source",uModel.source,DbType.Int32),
                               db.CreateParameter("@content",uModel.content,DbType.String),
                               db.CreateParameter("@IsMeasure",uModel.IsMeasure,DbType.Int32),
                               db.CreateParameter("@IsPhoto",uModel.IsPhoto,DbType.Int32),
                               db.CreateParameter("@userstoresid",uModel.userstoresid,DbType.Int32),
                               db.CreateParameter("@State",uModel.State,DbType.Int32),
                               db.CreateParameter("@userid",uModel.userid,DbType.Int32)
                               };
            int icount = db.GetRowCount(@"UPDATE [customer_User]
   SET [userpass] = @userpass
      ,[userstoresid] = @userstoresid
      ,[name] = @name
      ,[nickname] = @nickname
      ,[sex] = @sex
      ,[birthday] = @birthday
      ,[parentName] = @parentName
      ,[tel] = @tel
      ,[mobile] = @mobile
      ,[communityid] = @communityid
      ,[illness] = @illness
      ,[allergy] = @allergy
      ,[cycletype] = @cycletype
      ,[source] = @source
      ,[content] = @content
      ,[IsMeasure] = @IsMeasure
      ,[IsPhoto] = @IsPhoto
      ,[State]=@State
 WHERE [userid]=@userid", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="State"></param>
        /// <returns></returns>
        public bool SetAppID(string UserID, string Client, string AppID,string Model)
        {
            bool bo = false;
            Base.Conn.Database db = new Base.Conn.Database();
            bo = db.ExeSql("UPDATE [customer_User] SET [AppID] = @AppID,[Client]=@Client,[Model]=@Model WHERE [UserID]=@UserID", db.CreateParameter("@AppID", AppID, DbType.String), db.CreateParameter("@Client", Client, DbType.String), db.CreateParameter("@Model", Model, DbType.String), db.CreateParameter("@UserID", UserID, DbType.Int32));
            db.Dispose();
            return bo;
        }
        /// <summary>
        /// 用户修改自己的默认门店ID
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="userstoresid"></param>
        /// <returns></returns>
        public bool SetUserStoresid(string UserID, string userstoresid)
        {
            bool bo = false;
            Base.Conn.Database db = new Base.Conn.Database();
            bo = db.ExeSql("UPDATE [customer_User] SET [userstoresid] = @userstoresid WHERE [UserID]=@UserID", db.CreateParameter("@userstoresid", userstoresid, DbType.Int32), db.CreateParameter("@UserID", UserID, DbType.Int32));
            db.Dispose();
            return bo;
        }
        /// <summary>
        /// 更新相册人气
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="State"></param>
        /// <returns></returns>
        public bool UpdatePhotoHits(string UserID)
        {
            bool bo = false;
            Base.Conn.Database db = new Base.Conn.Database();
            bo = db.ExeSql("UPDATE [customer_User] SET [PhotoHits] = [PhotoHits]+1 WHERE [UserID]=@UserID", db.CreateParameter("@UserID", UserID, DbType.Int32));
            db.Dispose();
            return bo;
        }
        /// <summary>
        /// 最大消费天数
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="maxtimenum"></param>
        /// <returns></returns>
        public bool Updatemaxtimenum(string UserID, string maxtimenum)
        {
            bool bo = false;
            Base.Conn.Database db = new Base.Conn.Database();
            bo = db.ExeSql("UPDATE [customer_User] SET [maxtimenum] = @maxtimenum,[lasttime]=@lasttime WHERE [UserID]=@UserID", db.CreateParameter("@maxtimenum", maxtimenum, DbType.Int32), db.CreateParameter("@lasttime", DateTime.Now, DbType.DateTime), db.CreateParameter("@UserID", UserID, DbType.Int32));
            db.Dispose();
            return bo;
        }
        /// <summary>
        /// 最后消费时间
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="maxtimenum"></param>
        /// <returns></returns>
        public bool Updatelasttime(string UserID, string lasttime)
        {
            bool bo = false;
            Base.Conn.Database db = new Base.Conn.Database();
            bo = db.ExeSql("UPDATE [customer_User] SET [lasttime]=@lasttime WHERE [UserID]=@UserID", db.CreateParameter("@lasttime", lasttime, DbType.DateTime), db.CreateParameter("@UserID", UserID, DbType.Int32));
            db.Dispose();
            return bo;
        }

        /// <summary>
        /// 手机读取设备号
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public string ReadOnMobile(string storesid, string mobile)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",storesid,DbType.Int32),
                               db.CreateParameter("@mobile",mobile,DbType.String)
                               };
            string client = db.GetValue(@"SELECT [Client] FROM [customer_User] Where [storesid]=@storesid and [mobile]=@mobile", ps).ToString();
            db.Dispose();
            return client;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public Model.customer.User ReadOnLogin(string mobile)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@mobile",mobile,DbType.String)
                               };
            DataTable dt = db.GetData(SqlStr + "[mobile]=@mobile", ps);
            db.Dispose();
            Model.customer.User uModel = new Model.customer.User();
            if (dt.Rows.Count > 0)
            {
                uModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return uModel;
        }
        /// <summary>
        /// 读取单条
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Model.customer.User Read(string userid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@userid",userid,DbType.Int32)
                               };
            DataTable dt = db.GetData(SqlStr + "[userid]=@userid", ps);
            db.Dispose();
            Model.customer.User uModel = new Model.customer.User();
            if (dt.Rows.Count > 0)
            {
                uModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return uModel;
        }
        /// <summary>
        /// 读取单条
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Model.customer.User Read(string storesid, string userid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                                   db.CreateParameter("@storesid",storesid,DbType.Int32),
                               db.CreateParameter("@userid",userid,DbType.Int32)
                               };
            DataTable dt = db.GetData(SqlStr + "[storesid]=@storesid and [userid]=@userid", ps);
            db.Dispose();
            Model.customer.User uModel = new Model.customer.User();
            if (dt.Rows.Count > 0)
            {
                uModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return uModel;
        }
        /// <summary>
        /// 读取单条（关联，直营）
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Model.customer.User Read_Outlets(string userid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@userid",userid,DbType.Int32)
                               };
            DataTable dt = db.GetData(SqlStr_Join + " FROM [customer_User] as a inner join [Sys_stores] as b on a.[storesid]=b.[storesid] and b.[Isoutlets]=1 Where a.[userid]=@userid", ps);
            db.Dispose();
            Model.customer.User uModel = new Model.customer.User();
            if (dt.Rows.Count > 0)
            {
                uModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return uModel;
        }
        /// <summary>
        /// 读取APP用户信息单条
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataTable Read_AppInfo(string userid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@userid",userid,DbType.Int32)
                               };
            DataTable dt = db.GetData(@"SELECT a.[name]
      ,a.[userface]
      ,CONVERT(varchar(100), a.[birthday], 23) as birthday,
CASE a.[cycletype]
         WHEN 2 THEN 0
ELSE 1 END as babytype
      ,CONVERT(varchar(100), b.[starttime], 23) as starttime
      ,CONVERT(varchar(100), b.[endtime], 23) as endtime
,Case b.[cardstatus]
 When -1 then DATEDIFF(day,(select top 1 [AddTime] From [customer_CardLog] Where [cardid]=b.[cardid] and [cardlogtype]=4 order by [id] desc),b.[endtime])
 else
    DATEDIFF(day,getdate(),b.[endtime])
  end enddaynum
      ,a.[cardid]
      ,b.[surpluspositivenum]
      ,b.[surplusnegativenum]
      ,b.[surplusnum]
      ,b.[cardstatus]
      ,b.[userpositivenum]+b.[usernegativenum] as usernum
      ,b.[cardno]
      ,c.[title] as cardtype,
      (select top 1 CONVERT(varchar(100), [addtime], 23) From [customer_Userappointment] Where [UserID]=a.[userID] order by [id] desc) as appointmenttime,
      (select top 1 datediff(day,[addtime],GETDATE()) From [customer_UserConsumption] Where [userid]=a.[userID] order by [ID] asc) as alldaynum,
      (select count([id]) From [customer_UserConsumption] Where [userID]=a.[userID] and [satisfactionuserid]=0 and datediff(day,[addtime],getdate())<=7) as nocommentnum
      ,a.[photonum]
      ,(select top 1 [picurl] From [baby_album] Where [userid]=a.[userid] order by [id] desc) as lastphotourl,(SELECT top 1 [height] FROM [customer_UserConsumption] where height<>0 and [userid]=a.userid order by [id] desc) as lastheight1
      ,(select top 1 [height] from(SELECT top 2 [height],ROW_NUMBER() over(order by [id] desc) as p FROM [customer_UserConsumption] where height<>0 and [userid]=a.userid) t where t.p=2) as lastheight2,(SELECT top 1 [weight] FROM [customer_UserConsumption] where [weight]<>0 and [userid]=a.userid order by [id] desc) as lastweight1,(select top 1 [weight] from(SELECT top 2 [weight],ROW_NUMBER() over(order by [id] desc) as p FROM [customer_UserConsumption] where [weight]<>0 and [userid]=a.userid) t where t.p=2) as lastweight2
      ,s.tel
      ,s.title as storesname
      ,s.isoutlets
  FROM [customer_User] as a inner join [customer_Card] as b on a.[cardid]=b.[cardid] left join [customer_CardType] as c on b.[cardtypeid]=c.[id] left join [Sys_stores] as s on a.[userstoresid]=s.[storesid] Where a.[userid]=@userid", ps);
            db.Dispose();
            return dt;
        }

        /// <summary>
        /// 读取APP用户相册
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataTable Read_AppPhotoClass(string Page)
        {
            Base.Page.Dividepage page = new Base.Page.Dividepage();

            page.TableName = "[customer_User] as a inner join [Sys_stores] as b on a.[userstoresid]=b.[storesid]";
            page.OrderBy = "order by a.[photohits] desc";
            page.Index = "a.[userid]";
            page.Filter = "a.[photonum]>0";
            page.Field= @"a.[userid],a.[name]
      ,a.[userface]
      ,CONVERT(varchar(100), a.[birthday], 23) as birthday
      ,a.[photonum],(select top 1 [picurl] From [baby_album] Where [userid]=a.[userid] order by [id] desc) as lastphotourl,b.[province],a.[photohits]";
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
        /// 读取单条
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Model.customer.User Read1(string storesid, string userid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",storesid,DbType.Int32),
                               db.CreateParameter("@userid",userid,DbType.Int32)
                               };
            DataTable dt = db.GetData(SqlStr + "[storesid]=@storesid and [userid]=@userid", ps);
            db.Dispose();
            Model.customer.User uModel = new Model.customer.User();
            if (dt.Rows.Count > 0)
            {
                uModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return uModel;
        }
        /// <summary>
        /// 读取单条
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Model.customer.User Read1_CardID(string cardid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@cardid",cardid,DbType.Int32)
                               };
            DataTable dt = db.GetData(SqlStr + "[cardid]=@cardid", ps);
            db.Dispose();
            Model.customer.User uModel = new Model.customer.User();
            if (dt.Rows.Count > 0)
            {
                uModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return uModel;
        }
        /// <summary>
        /// 读取月龄
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string Read_MonthAge(string userid)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string age = db.GetValue(@"SELECT " + Model.Data.Basic.GetMonth("[birthday]") + " FROM [customer_User] Where [userid]=@userid", db.CreateParameter("@userid", userid, DbType.Int32)).ToString();
            db.Dispose();
            return age;
        }
        /// <summary>
        /// 读取婴儿类型
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Read_cycletype(string id)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string cycletype = db.GetValue(@"SELECT [cycletype] FROM [customer_User] Where [userid]=@id", db.CreateParameter("@id", id, DbType.Int32)).ToString();
            db.Dispose();
            return cycletype;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<Model.customer.User> Read_Name(string storesid, string Name)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(SqlStr.Replace("SELECT ", "SELECT top 6 ") + "[storesid]=@storesid and ([name] like '%" + Name + "%' or [nickname] like '%" + Name + "%') order by [UserID] desc", db.CreateParameter("@storesid", storesid, DbType.Int32));
            db.Dispose();
            List<Model.customer.User> uModel = new List<Model.customer.User>();
            foreach(DataRow dr in dt.Rows)
            {
                uModel.Add(DataRow2Model(dr));
            }
            dt.Dispose();
            return uModel;
        }
        /// <summary>
        /// 搜索名称
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public List<Model.customer.User> Read_Name_Outlets(string Name)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(SqlStr_Join.Replace("SELECT ", "SELECT top 6 ") + " FROM [customer_User] as a inner join [Sys_stores] as b on a.[storesid]=b.[storesid] Where b.[Isoutlets]=1 and ([name] like '%" + Name + "%' or [nickname] like '%" + Name + "%') order by [UserID] desc");
            db.Dispose();
            List<Model.customer.User> uModel = new List<Model.customer.User>();
            foreach (DataRow dr in dt.Rows)
            {
                uModel.Add(DataRow2Model(dr));
            }
            dt.Dispose();
            return uModel;
        }
        /// <summary>
        /// 读取单条
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Model.customer.User Read_CardNo(string storesid, string CardNo)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(SqlStr_Join + "FROM [customer_User] as a inner join [customer_Card] as b on a.[cardid]=b.[cardid] Where a.[storesid]=@storesid and " + (CardNo.Length >= 10 ? "b.[cardNumber]=@CardNo" : "b.[CardNo]=@CardNo"), db.CreateParameter("@storesid", storesid, DbType.Int32), db.CreateParameter("@CardNo", CardNo, DbType.String));
            db.Dispose();
            Model.customer.User uModel = new Model.customer.User();
            if (dt.Rows.Count > 0)
            {
                uModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return uModel;
        }
        /// <summary>
        /// 读取单条（所有）
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Model.customer.User Read_CardNo_Outlets(string CardNo)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(SqlStr_Join + "FROM [customer_User] as a inner join [customer_Card] as b on a.[cardid]=b.[cardid] inner join [Sys_stores] as c on a.[storesid]=c.[storesid] and c.[Isoutlets]=1 Where " + (CardNo.Length >= 10 ? "b.[cardNumber]=@CardNo" : "b.[CardNo]=@CardNo"), db.CreateParameter("@CardNo", CardNo, DbType.String));
            db.Dispose();
            Model.customer.User uModel = new Model.customer.User();
            if (dt.Rows.Count > 0)
            {
                uModel = DataRow2Model(dt.Rows[0]);
            }
            dt.Dispose();
            return uModel;
        }
        /// <summary>
        /// 读取所有的范围内的办新卡数量
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="statustime"></param>
        /// <param name="endtime"></param>
        /// <param name="title">小区名称</param>
        /// <param name="usersource"></param>
        /// <returns></returns>
        public List<Model.customer.User> ReadList_AllNewCard(string storesid, string statustime, string endtime, string title, string usersource)
        {
            Base.Conn.Database db = new Base.Conn.Database();
//            DataTable dt = db.GetData(@"SELECT a.[userid]
//      ,a.[userpass]
//      ,a.[storesid]
//      ,a.[name]
//      ,a.[nickname]
//      ,a.[sex]
//      ,a.[birthday]
//      ,a.[parentName]
//      ,a.[tel]
//      ,a.[mobile]
//      ,a.[communityid]
//      ,a.[illness]
//      ,a.[allergy]
//      ,a.[cycletype]
//      ,a.[source]
//      ,a.[content]
//      ,a.[addtime]
//      ,a.[cardid]
//      ,a.[IsMeasure]
//      ,a.[IsPhoto]
//      ,a.[scorenum]
//      ,a.[IsPush]
//      ,a.[Error]
//      ,a.[ErrorTime]
//      ,a.[AppID]
//      ,a.[Client],[Model]
//      ,a.[State],a.[userface],a.[photonum],a.[maxtimenum],a.[lasttime]
//      ,b.[cardtypeid],b.[price],c.[price] as cPrice
//  FROM [customer_User] as a inner join [customer_Card] as b on a.[cardid]=b.[cardid] inner join [customer_CardType] as c on b.[cardtypeid]=c.[id]" + (title.Length > 0 ? " inner join [Sys_community] as d on a.[communityid]=d.[id]" : "") + " Where a.[storesid]=@storesid" + (Base.Fun.fun.IsDate(statustime) ? " and DATEDIFF(day,'" + statustime + "',b.[AddTime])>=0" : "") + (Base.Fun.fun.IsDate(endtime) ? " and DATEDIFF(day,'" + endtime + "',b.[AddTime])<=0" : "") + (Base.Fun.fun.IsNumeric(usersource) ? " and a.[source]=" + usersource : "") + (title.Length > 0 ? (Base.Fun.fun.pnumeric(title) ? " and d.[id]=" + title : " and d.[title]='%" + title + "%'") : ""), db.CreateParameter("@storesid", storesid, DbType.Int32));

            DataTable dt1 = db.GetData(SqlStr_Join + @",b.[cardtypeid],b.[price],c.[newprice],c.[oldprice]
  FROM [customer_User] as a inner join [customer_Card] as b on a.[cardid]=b.[cardid] inner join [customer_CardLog] as c on b.[cardid]=c.[cardid] and c.[cardlogtype]=3 and c.[newprice]<>''" + (title.Length > 0 ? " inner join [Sys_community] as d on a.[communityid]=d.[id]" : "") + " Where c.[storesid]=@storesid" + (Base.Fun.fun.IsDate(statustime) ? " and DATEDIFF(day,'" + statustime + "',c.[addtime])>=0" : "") + (Base.Fun.fun.IsDate(endtime) ? " and DATEDIFF(day,'" + endtime + "',c.[addtime])<=0" : "") + (Base.Fun.fun.IsNumeric(usersource) ? " and a.[source]=" + usersource : "") + (title.Length > 0 ? (Base.Fun.fun.pnumeric(title) ? " and d.[id]=" + title : " and d.[title]='%" + title + "%'") : ""), db.CreateParameter("@storesid", storesid, DbType.Int32));
           
            db.Dispose();
            List<Model.customer.User> uList = new List<Model.customer.User>();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    uList.Add(DataRow2Model(dr));
            //    uList[uList.Count - 1].cModel.cardtypeid = dr["cardtypeid"].ToString();
            //    uList[uList.Count - 1].cModel.price = dr["price"].ToString();
            //    uList[uList.Count - 1].cModel.ctModel.price = dr["cPrice"].ToString();
            //}
            //dt.Dispose();
            foreach (DataRow dr in dt1.Rows)
            {
                uList.Add(DataRow2Model(dr));
                uList[uList.Count - 1].cModel.cardtypeid = dr["cardtypeid"].ToString();
                uList[uList.Count - 1].cModel.price = uList[uList.Count - 1].cModel.ctModel.price = (double.Parse(dr["newprice"].ToString()) - double.Parse(Base.Fun.fun.IsZero(dr["oldprice"].ToString()))).ToString();
            }
            dt1.Dispose();

            return uList;
        }
        /// <summary>
        /// 所有续卡
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="statustime"></param>
        /// <param name="endtime"></param>
        /// <param name="title"></param>
        /// <param name="usersource"></param>
        /// <returns></returns>
        public List<Model.customer.User> ReadList_AllRenewalCard(string storesid, string statustime, string endtime, string title, string usersource)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            //            DataTable dt = db.GetData(@"SELECT a.[userid]
            //      ,a.[userpass]
            //      ,a.[storesid]
            //      ,a.[name]
            //      ,a.[nickname]
            //      ,a.[sex]
            //      ,a.[birthday]
            //      ,a.[parentName]
            //      ,a.[tel]
            //      ,a.[mobile]
            //      ,a.[communityid]
            //      ,a.[illness]
            //      ,a.[allergy]
            //      ,a.[cycletype]
            //      ,a.[source]
            //      ,a.[content]
            //      ,a.[addtime]
            //      ,a.[cardid]
            //      ,a.[IsMeasure]
            //      ,a.[IsPhoto]
            //      ,a.[scorenum]
            //      ,a.[IsPush]
            //      ,a.[Error]
            //      ,a.[ErrorTime]
            //      ,a.[AppID]
            //      ,a.[Client],[Model]
            //      ,a.[State],a.[userface],a.[photonum],a.[maxtimenum],a.[lasttime]
            //      ,b.[cardtypeid],b.[price],c.[price] as cPrice
            //  FROM [customer_User] as a inner join [customer_Card] as b on a.[cardid]=b.[cardid] inner join [customer_CardType] as c on b.[cardtypeid]=c.[id]" + (title.Length > 0 ? " inner join [Sys_community] as d on a.[communityid]=d.[id]" : "") + " Where a.[storesid]=@storesid" + (Base.Fun.fun.IsDate(statustime) ? " and DATEDIFF(day,'" + statustime + "',b.[AddTime])>=0" : "") + (Base.Fun.fun.IsDate(endtime) ? " and DATEDIFF(day,'" + endtime + "',b.[AddTime])<=0" : "") + (Base.Fun.fun.IsNumeric(usersource) ? " and a.[source]=" + usersource : "") + (title.Length > 0 ? (Base.Fun.fun.pnumeric(title) ? " and d.[id]=" + title : " and d.[title]='%" + title + "%'") : ""), db.CreateParameter("@storesid", storesid, DbType.Int32));
//            Base.Error.Error.WriteError(SqlStr_Join + @",b.[cardtypeid],b.[price],c.[newprice],c.[oldprice]
//  FROM [customer_User] as a inner join [customer_Card] as b on a.[cardid]=b.[cardid] inner join [customer_CardLog] as c on b.[cardid]=c.[cardid] and c.[cardlogtype] =1 and c.[newprice]<>''" + (title.Length > 0 ? " inner join [Sys_community] as d on a.[communityid]=d.[id]" : "") + " Where c.[storesid]=@storesid" + (Base.Fun.fun.IsDate(statustime) ? " and DATEDIFF(day,'" + statustime + "',c.[addtime])>=0" : "") + (Base.Fun.fun.IsDate(endtime) ? " and DATEDIFF(day,'" + endtime + "',c.[addtime])<=0" : "") + (Base.Fun.fun.IsNumeric(usersource) ? " and a.[source]=" + usersource : "") + (title.Length > 0 ? (Base.Fun.fun.pnumeric(title) ? " and d.[id]=" + title : " and d.[title]='%" + title + "%'") : ""));
            DataTable dt1 = db.GetData(SqlStr_Join + @",b.[cardtypeid],b.[price],c.[newprice],c.[oldprice]
  FROM [customer_User] as a inner join [customer_Card] as b on a.[cardid]=b.[cardid] inner join [customer_CardLog] as c on b.[cardid]=c.[cardid] and c.[cardlogtype] =1 and c.[newprice]<>''" + (title.Length > 0 ? " inner join [Sys_community] as d on a.[communityid]=d.[id]" : "") + " Where c.[storesid]=@storesid" + (Base.Fun.fun.IsDate(statustime) ? " and DATEDIFF(day,'" + statustime + "',c.[addtime])>=0" : "") + (Base.Fun.fun.IsDate(endtime) ? " and DATEDIFF(day,'" + endtime + "',c.[addtime])<=0" : "") + (Base.Fun.fun.IsNumeric(usersource) ? " and a.[source]=" + usersource : "") + (title.Length > 0 ? (Base.Fun.fun.pnumeric(title) ? " and d.[id]=" + title : " and d.[title]='%" + title + "%'") : ""), db.CreateParameter("@storesid", storesid, DbType.Int32));

            db.Dispose();
            List<Model.customer.User> uList = new List<Model.customer.User>();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    uList.Add(DataRow2Model(dr));
            //    uList[uList.Count - 1].cModel.cardtypeid = dr["cardtypeid"].ToString();
            //    uList[uList.Count - 1].cModel.price = dr["price"].ToString();
            //    uList[uList.Count - 1].cModel.ctModel.price = dr["cPrice"].ToString();
            //}
            //dt.Dispose();
            foreach (DataRow dr in dt1.Rows)
            {
                uList.Add(DataRow2Model(dr));
                uList[uList.Count - 1].cModel.cardtypeid = dr["cardtypeid"].ToString();
                uList[uList.Count - 1].cModel.price = uList[uList.Count - 1].cModel.ctModel.price = (double.Parse(dr["newprice"].ToString()) - double.Parse(Base.Fun.fun.IsZero(dr["oldprice"].ToString()))).ToString();
            }
            dt1.Dispose();

            return uList;
        }
        /// <summary>
        /// 所有调整
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="statustime"></param>
        /// <param name="endtime"></param>
        /// <param name="title"></param>
        /// <param name="usersource"></param>
        /// <returns></returns>
        public List<Model.customer.User> ReadList_AllAdjustmentCard(string storesid, string statustime, string endtime, string title, string usersource)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            //            DataTable dt = db.GetData(@"SELECT a.[userid]
            //      ,a.[userpass]
            //      ,a.[storesid]
            //      ,a.[name]
            //      ,a.[nickname]
            //      ,a.[sex]
            //      ,a.[birthday]
            //      ,a.[parentName]
            //      ,a.[tel]
            //      ,a.[mobile]
            //      ,a.[communityid]
            //      ,a.[illness]
            //      ,a.[allergy]
            //      ,a.[cycletype]
            //      ,a.[source]
            //      ,a.[content]
            //      ,a.[addtime]
            //      ,a.[cardid]
            //      ,a.[IsMeasure]
            //      ,a.[IsPhoto]
            //      ,a.[scorenum]
            //      ,a.[IsPush]
            //      ,a.[Error]
            //      ,a.[ErrorTime]
            //      ,a.[AppID]
            //      ,a.[Client],[Model]
            //      ,a.[State],a.[userface],a.[photonum],a.[maxtimenum],a.[lasttime]
            //      ,b.[cardtypeid],b.[price],c.[price] as cPrice
            //  FROM [customer_User] as a inner join [customer_Card] as b on a.[cardid]=b.[cardid] inner join [customer_CardType] as c on b.[cardtypeid]=c.[id]" + (title.Length > 0 ? " inner join [Sys_community] as d on a.[communityid]=d.[id]" : "") + " Where a.[storesid]=@storesid" + (Base.Fun.fun.IsDate(statustime) ? " and DATEDIFF(day,'" + statustime + "',b.[AddTime])>=0" : "") + (Base.Fun.fun.IsDate(endtime) ? " and DATEDIFF(day,'" + endtime + "',b.[AddTime])<=0" : "") + (Base.Fun.fun.IsNumeric(usersource) ? " and a.[source]=" + usersource : "") + (title.Length > 0 ? (Base.Fun.fun.pnumeric(title) ? " and d.[id]=" + title : " and d.[title]='%" + title + "%'") : ""), db.CreateParameter("@storesid", storesid, DbType.Int32));

            DataTable dt1 = db.GetData(SqlStr_Join + @",b.[cardtypeid],b.[price],c.[newprice],c.[oldprice]
  FROM [customer_User] as a inner join [customer_Card] as b on a.[cardid]=b.[cardid] inner join [customer_CardLog] as c on b.[cardid]=c.[cardid] and c.[cardlogtype] =2 and c.[newprice]<>''" + (title.Length > 0 ? " inner join [Sys_community] as d on a.[communityid]=d.[id]" : "") + " Where c.[storesid]=@storesid" + (Base.Fun.fun.IsDate(statustime) ? " and DATEDIFF(day,'" + statustime + "',c.[addtime])>=0" : "") + (Base.Fun.fun.IsDate(endtime) ? " and DATEDIFF(day,'" + endtime + "',c.[addtime])<=0" : "") + (Base.Fun.fun.IsNumeric(usersource) ? " and a.[source]=" + usersource : "") + (title.Length > 0 ? (Base.Fun.fun.pnumeric(title) ? " and d.[id]=" + title : " and d.[title]='%" + title + "%'") : ""), db.CreateParameter("@storesid", storesid, DbType.Int32));

            db.Dispose();
            List<Model.customer.User> uList = new List<Model.customer.User>();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    uList.Add(DataRow2Model(dr));
            //    uList[uList.Count - 1].cModel.cardtypeid = dr["cardtypeid"].ToString();
            //    uList[uList.Count - 1].cModel.price = dr["price"].ToString();
            //    uList[uList.Count - 1].cModel.ctModel.price = dr["cPrice"].ToString();
            //}
            //dt.Dispose();
            foreach (DataRow dr in dt1.Rows)
            {
                uList.Add(DataRow2Model(dr));
                uList[uList.Count - 1].cModel.cardtypeid = dr["cardtypeid"].ToString();
                uList[uList.Count - 1].cModel.price = uList[uList.Count - 1].cModel.ctModel.price = (double.Parse(dr["newprice"].ToString()) - double.Parse(Base.Fun.fun.IsZero(dr["oldprice"].ToString()))).ToString();
            }
            dt1.Dispose();

            return uList;
        }
        /// <summary>
        /// 读取所有的IDS的会员信息(Userstoresid)
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="statustime"></param>
        /// <param name="endtime"></param>
        /// <param name="usersource"></param>
        /// <returns></returns>
        public List<Model.customer.User> ReadList_All(string storesid, string ids)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(SqlStr_Join + @",b.[cardNo]
  FROM [customer_User] as a left join [customer_Card] as b on a.[cardid]=b.[cardid] Where a.[Userstoresid]=@storesid and a.[userid] in (" + ids+")", db.CreateParameter("@storesid", storesid, DbType.Int32));
            db.Dispose();
            List<Model.customer.User> uList = new List<Model.customer.User>();
            foreach (DataRow dr in dt.Rows)
            {
                uList.Add(DataRow2Model(dr));
                uList[uList.Count - 1].cModel.cardNo = dr["cardNo"].ToString();
            }
            dt.Dispose();
            return uList;
        }
        /// <summary>
        /// 更新对应的卡号ID
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="userid"></param>
        /// <param name="cardid"></param>
        /// <returns></returns>
        public int Update_CordIDAndContent(string userid, string cardid, string content)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@cardid",cardid,DbType.Int32),
                               db.CreateParameter("@content",content,DbType.String),
                               db.CreateParameter("@State",1,DbType.Int32),
                               db.CreateParameter("@userid",userid,DbType.Int32)
                               };
            int icount = db.GetRowCount("UPDATE [customer_User] SET [cardid] = @cardid,[content]=@content,[State]=@State WHERE [userid]=@userid", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 更新积分
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="userid"></param>
        /// <param name="scorenum"></param>
        /// <returns></returns>
        public int Update_scorenum(string userid, string scorenum)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@scorenum",scorenum,DbType.Int32),
                               db.CreateParameter("@userid",userid,DbType.Int32)
                               };
            int icount = db.GetRowCount("UPDATE [customer_User] SET [scorenum] = [scorenum]+@scorenum WHERE [userid]=@userid", ps);
            db.Dispose();
            return icount;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="scorenum"></param>
        /// <returns></returns>
        public int Update_PassWord(string userid, string userpass)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@userpass",userpass,DbType.String),
                               db.CreateParameter("@userid",userid,DbType.Int32)
                               };
            int icount = db.GetRowCount("UPDATE [customer_User] SET [userpass] = @userpass,[Error] =0,[errortime]=getdate() WHERE [userid]=@userid", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 更新头像
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="userface"></param>
        /// <param name="photonum"></param>
        /// <returns></returns>
        public int Update_UserFaceAndPhotoNum(string userid, string userface, string photonum)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@userface",userface,DbType.String),
                               db.CreateParameter("@photonum",photonum,DbType.Int32),
                               db.CreateParameter("@userid",userid,DbType.Int32)
                               };
            int icount = db.GetRowCount("UPDATE [customer_User] SET [userface] = @userface,[photonum] =@photonum WHERE [userid]=@userid", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 更新头像
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="userface"></param>
        /// <param name="photonum"></param>
        /// <returns></returns>
        public int Update_UserFace(string userid, string userface)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@userface",userface,DbType.String),
                               db.CreateParameter("@userid",userid,DbType.Int32)
                               };
            int icount = db.GetRowCount("UPDATE [customer_User] SET [userface] = @userface WHERE [userid]=@userid", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 修改错误次数
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="scorenum"></param>
        /// <returns></returns>
        public int Update_Error(string userid, string error)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@error",error,DbType.Int32),
                               db.CreateParameter("@errortime",DateTime.Now,DbType.DateTime),
                               db.CreateParameter("@userid",userid,DbType.Int32)
                               };
            int icount = db.GetRowCount("UPDATE [customer_User] SET [Error] = @error,[errortime]=@errortime WHERE [userid]=@userid", ps);
            db.Dispose();
            return icount;
        }

        /// <summary>
        /// 修改用户状态
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="scorenum"></param>
        /// <returns></returns>
        public int Update_State(string userid, string State)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@State",State,DbType.Int32),
                               db.CreateParameter("@userid",userid,DbType.Int32)
                               };
            int icount = db.GetRowCount("UPDATE [customer_User] SET [State] = @State WHERE [userid]=@userid", ps);
            db.Dispose();
            return icount;
        }
        /// <summary>
        /// 更新婴儿类型
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="cycletype"></param>
        /// <returns></returns>
        public int Update_cycletype(string userid, string cycletype)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@cycletype",cycletype,DbType.Int32),
                               db.CreateParameter("@userid",userid,DbType.Int32)
                               };
            int icount = db.GetRowCount("UPDATE [customer_User] SET [cycletype] = @cycletype WHERE [userid]=@userid", ps);
            db.Dispose();
            return icount;
        }

        /// <summary>
        /// 修改推送关系
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="scorenum"></param>
        /// <returns></returns>
        public int Update_Push(string userid, string IsPush)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@IsPush",IsPush,DbType.Int32),
                               db.CreateParameter("@userid",userid,DbType.Int32)
                               };
            int icount = db.GetRowCount("UPDATE [customer_User] SET [IsPush] = @IsPush WHERE [userid]=@userid", ps);
            db.Dispose();
            return icount;
        }

        /// <summary>
        /// 获得所有用户(UserStoresid)
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="userid"></param>
        /// <param name="scorenum"></param>
        /// <returns></returns>
        public string Read_UserCount(string storesid, string stime, string etime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",storesid,DbType.Int32)
                               };
            string count = db.GetValue("Select count([UserID]) From [customer_User] Where [UserStoresid]=@storesid" + (Base.Fun.fun.IsDate(stime) ? " and datediff(day,[addtime],'" + stime + "')<=0" : "") + (Base.Fun.fun.IsDate(etime) ? " and datediff(day,[addtime],'" + etime + "')>=0" : ""), ps).ToString();
            db.Dispose();
            return count;
        }
        /// <summary>
        /// 条件发送
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="UserConsumptionTime"></param>
        /// <param name="CardNum"></param>
        /// <param name="CardEndTime"></param>
        /// <param name="CardType"></param>
        /// <param name="CardState"></param>
        /// <returns></returns>
        public List<Model.customer.User> Read_SendMobileApp(string storesid, string UserConsumptionTime, string CardNum, string CardEndTime, string CardType, string CardState,string yueling1,string yueling2)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DbParameter[] ps = { 
                               db.CreateParameter("@storesid",storesid,DbType.Int32)
                               };
            List<string> wherestr = new List<string>();
            if (Base.Fun.fun.IsNumeric(UserConsumptionTime))
            {
                wherestr.Add("(select top 1 datediff(day,[addtime],GETDATE()) from [customer_UserConsumption] where [userid]=a.[userid] order by [id] desc)<=" + UserConsumptionTime);
            }
            if (Base.Fun.fun.IsNumeric(CardNum))
            {
                wherestr.Add("b.[surplusnum]<=" + CardNum);
            }
            if (Base.Fun.fun.IsNumeric(CardEndTime))
            {
                wherestr.Add("datediff(day,GETDATE(),b.[endtime])<=" + CardEndTime);
                wherestr.Add("datediff(day,GETDATE(),b.[endtime])>=0");
            }
            if (Base.Fun.fun.IsNumeric(CardType))
            {
                wherestr.Add("b.[cardtypeid]=" + CardType);
            }
            if (CardState.Equals("1"))
            {
                wherestr.Add("b.[cardstatus]=1");
            }
            else if (CardState.Equals("-1"))
            {
                wherestr.Add("b.[cardstatus]=-1");
            }
            else if(CardState.Equals("2"))
            {
                wherestr.Add("datediff(day,GETDATE(),b.[endtime])<0");
            }
            if (Base.Fun.fun.IsNumeric(yueling1))
            {
                wherestr.Add(Model.Data.Basic.GetMonth("a.[birthday]") + ">=" + yueling1);
            }
            if (Base.Fun.fun.IsNumeric(yueling2))
            {
                wherestr.Add(Model.Data.Basic.GetMonth("a.[birthday]") + "<=" + yueling2);
            }
            DataTable dt = db.GetData("Select a.[userid],a.[Mobile],a.[Client] From [customer_User] as a left join [customer] as b on a.[cardID]=b.[cardID] Where a.[Storesid]=@storesid", ps);
            db.Dispose();
            List<Model.customer.User> uList = new List<Model.customer.User>();
            foreach (DataRow dr in dt.Rows)
            {
                Model.customer.User uModel = new Model.customer.User();
                uModel.userid = dr["userid"].ToString();
                uModel.mobile = dr["mobile"].ToString();
                uModel.Client = dr["client"].ToString();
                uList.Add(uModel);
            }
            return uList;
        }
        /// <summary>
        /// 读取还有30就要过生日的会员
        /// </summary>
        /// <returns></returns>
        public List<Model.customer.User> ReadBirthday2_10()
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData("select * from (SELECT [UserID],[Name],[Mobile],[client],[storesid],[userstoresid],CONVERT(VARCHAR(10), DATEADD(yy,DATEDIFF(yy, birthday, GETDATE()),birthday), 111)  AS birthday FROM [customer_User] where [IsPush]=1 and [mobile]<>'') as t where DATEDIFF(day,getdate(),birthday) BETWEEN 2 AND 10");
            db.Dispose();
            List<Model.customer.User> UserList = new List<Model.customer.User>();
            foreach (DataRow dr in dt.Rows)
            {
                Model.customer.User uModel = new Model.customer.User();
                uModel.userid =dr["UserID"].ToString();
                uModel.name = dr["Name"].ToString();
                uModel.storesid = dr["storesid"].ToString();
                uModel.userstoresid = dr["userstoresid"].ToString();
                uModel.mobile = dr["mobile"].ToString();
                uModel.Client = dr["client"].ToString();
                uModel.birthday = dr["birthday"].ToString();
                UserList.Add(uModel);
            }
            return UserList;
        }
        /// <summary>
        /// 读取30天就要过期的卡用户
        /// </summary>
        /// <returns></returns>
        public List<Model.customer.User> ReadCardEndTime30()
        {
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(@"SELECT a.[cardNo]
      ,a.[endtime]
      ,b.[userid]
      ,b.[name]
      ,b.[storesid]
      ,b.[userstoresid]
      ,b.[client]
      ,b.[mobile] FROM [customer_Card] as a inner join [customer_User] as b on a.[cardid]=b.[cardid] where a.[cardstatus]=1 and DATEDIFF(day,GETDATE(),a.[endtime]) BETWEEN 1 AND 30");
            db.Dispose();
            List<Model.customer.User> UserList = new List<Model.customer.User>();
            foreach (DataRow dr in dt.Rows)
            {
                Model.customer.User uModel = new Model.customer.User();
                uModel.userid = dr["UserID"].ToString();
                uModel.name = dr["Name"].ToString();
                uModel.storesid = dr["storesid"].ToString();
                uModel.userstoresid = dr["userstoresid"].ToString();
                uModel.mobile = dr["mobile"].ToString();
                uModel.Client = dr["client"].ToString();
                uModel.cModel = new Model.customer.Card();
                uModel.cModel.cardNo = dr["cardNo"].ToString();
                uModel.cModel.endtime = dr["endtime"].ToString();
                UserList.Add(uModel);
            }
            return UserList;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="PageSize">分页</param>
        /// <param name="cardNo">卡号</param>
        /// <param name="name">姓名</param>
        /// <param name="communityid">小区</param>
        /// <param name="mobile">妈妈手机</param>
        /// <param name="nickname">小名</param>
        /// <param name="cycletype">婴儿类型</param>
        /// <param name="statusmonthnum">开始月龄</param>
        /// <param name="endmonthnum">结束月龄</param>
        /// <param name="statusdaynum">开始日龄</param>
        /// <param name="enddaynum">结束日龄</param>
        /// <param name="statusbirthday">开始生日</param>
        /// <param name="endbirthday">结束生日</param>
        /// <param name="loginnum">登录次数</param>
        /// <param name="startnum">剩余次数开始</param>
        /// <param name="endnum">剩余次数结束</param>
        /// <returns></returns>
        public string View(int PageSize, string storesid, string cardNo, string name, string communityid, string mobile, string nickname, string cycletype, string statusmonthnum, string endmonthnum, string statusdaynum, string enddaynum, string statusbirthday, string endbirthday, string loginnum, string startnum, string endnum,string cardtypeid,string cardstatus)
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
                page.TableName = "[customer_User_Stores] as s inner join [customer_User] as a on a.[userid]=s.[userid] left join [Sys_stores] as ss on a.[storesid]=ss.[storesid] left join [customer_Card] as b on a.[cardid]=b.[cardid] left join [Sys_community] as c on a.[communityid]=c.[id]";
                page.OrderBy = "order by s.[userid] desc";
                page.Index = "s.[userid]";
                page.Field = "s.[userid],a.[userface],b.[cardNo],a.[storesid],ss.[title],a.[name],a.[nickname],a.[sex]," + Model.Data.Basic.GetMonth("a.[birthday]") + ",a.[parentname],a.[mobile],c.[title] as communityname,a.[cycletype],a.[scorenum],datediff(DAY,getdate(),b.[endtime]),a.[IsMeasure],a.[IsPhoto],a.[addtime],a.[content]";
                List<string> Filter = new List<string>();
                Filter.Add("s.[storesid]=" + storesid);
                if (cardNo.Length > 0)
                {
                    if (cardNo.Length >= 10)
                    {
                        Filter.Add("b.[cardNumber]='" + cardNo + "'");
                    }
                    else
                    {
                        Filter.Add("b.[CardNo]='" + cardNo + "'");
                    }
                }
                if (name.Length > 0)
                {
                    Filter.Add("a.[name] like '%" + name + "%'");
                }
                if (Base.Fun.fun.pnumeric(communityid))
                {
                    Filter.Add("a.[communityid]=" + communityid);
                }
                if (mobile.Length > 0)
                {
                    Filter.Add("a.[mobile] like '%" + mobile + "%'");
                }
                if (nickname.Length > 0)
                {
                    Filter.Add("a.[nickname] like '%" + nickname + "%'");
                }
                if (Base.Fun.fun.IsNumeric(cycletype))
                {
                    Filter.Add("a.[cycletype]=" + cycletype);
                }
                if (Base.Fun.fun.IsNumeric(statusmonthnum))
                {
                    Filter.Add(Model.Data.Basic.GetMonth("a.[birthday]") + ">=" + statusmonthnum);
                }
                if (Base.Fun.fun.IsNumeric(endmonthnum))
                {
                    Filter.Add(Model.Data.Basic.GetMonth("a.[birthday]") + "<=" + endmonthnum);
                }
                if (Base.Fun.fun.IsNumeric(statusdaynum))
                {
                    Filter.Add("datediff(DAY,getdate(),a.[birthday])>=" + statusdaynum);
                }
                if (Base.Fun.fun.IsNumeric(enddaynum))
                {
                    Filter.Add("datediff(DAY,getdate(),a.[birthday])<=" + enddaynum);
                }
                if (Base.Fun.fun.IsDate(statusbirthday))
                {
                    Filter.Add("datediff(day,a.[birthday],'" + statusbirthday + "')<=0");
                }
                if (Base.Fun.fun.IsDate(endbirthday))
                {
                    Filter.Add("datediff(day,a.[birthday],'" + endbirthday + "')>=0");
                }
                if (Base.Fun.fun.IsNumeric(startnum))
                {
                    Filter.Add("b.[surplusnum]>=" + startnum);
                }
                if (Base.Fun.fun.IsNumeric(endnum))
                {
                    Filter.Add("b.[surplusnum]<=" + endnum);
                }
                if (Base.Fun.fun.IsNumeric(cardtypeid))
                {
                    Filter.Add("b.[cardtypeid]=" + cardtypeid);
                }
                if (Base.Fun.fun.IsNumeric(cardstatus))
                {
                    Filter.Add("b.[cardstatus]=" + cardstatus);
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
        /// 导出Excel
        /// </summary>
        /// <param name="PageSize">分页</param>
        /// <param name="cardNo">卡号</param>
        /// <param name="name">姓名</param>
        /// <param name="communityid">小区</param>
        /// <param name="mobile">妈妈手机</param>
        /// <param name="nickname">小名</param>
        /// <param name="cycletype">婴儿类型</param>
        /// <param name="statusmonthnum">开始月龄</param>
        /// <param name="endmonthnum">结束月龄</param>
        /// <param name="statusdaynum">开始日龄</param>
        /// <param name="enddaynum">结束日龄</param>
        /// <param name="statusbirthday">开始生日</param>
        /// <param name="endbirthday">结束生日</param>
        /// <param name="loginnum">登录次数</param>
        /// <param name="startnum">剩余次数开始</param>
        /// <param name="endnum">剩余次数结束</param>
        /// <returns></returns>
        public DataTable ViewToXLS(string storesid, string cardNo, string name, string communityid, string mobile, string nickname, string cycletype, string statusmonthnum, string endmonthnum, string statusdaynum, string enddaynum, string statusbirthday, string endbirthday, string loginnum, string startnum, string endnum, string cardtypeid, string cardstatus)
        {
            DataTable dt = new DataTable();
            Base.Conn.Database db = new Base.Conn.Database();

            List<string> Filter = new List<string>();
            Filter.Add("s.[storesid]=" + storesid);
            if (cardNo.Length > 0)
            {
                if (cardNo.Length >= 10)
                {
                    Filter.Add("b.[cardNumber]='" + cardNo + "'");
                }
                else
                {
                    Filter.Add("b.[CardNo]='" + cardNo + "'");
                }
            }
            if (name.Length > 0)
            {
                Filter.Add("a.[name] like '%" + name + "%'");
            }
            if (Base.Fun.fun.pnumeric(communityid))
            {
                Filter.Add("a.[communityid]=" + communityid);
            }
            if (mobile.Length > 0)
            {
                Filter.Add("a.[mobile] like '%" + mobile + "%'");
            }
            if (nickname.Length > 0)
            {
                Filter.Add("a.[nickname] like '%" + nickname + "%'");
            }
            if (Base.Fun.fun.IsNumeric(cycletype))
            {
                Filter.Add("a.[cycletype]=" + cycletype);
            }
            if (Base.Fun.fun.IsNumeric(statusmonthnum))
            {
                Filter.Add(Model.Data.Basic.GetMonth("a.[birthday]") + ">=" + statusmonthnum);
            }
            if (Base.Fun.fun.IsNumeric(endmonthnum))
            {
                Filter.Add(Model.Data.Basic.GetMonth("a.[birthday]") + "<=" + endmonthnum);
            }
            if (Base.Fun.fun.IsNumeric(statusdaynum))
            {
                Filter.Add("datediff(DAY,getdate(),a.[birthday])>=" + statusdaynum);
            }
            if (Base.Fun.fun.IsNumeric(enddaynum))
            {
                Filter.Add("datediff(DAY,getdate(),a.[birthday])<=" + enddaynum);
            }
            if (Base.Fun.fun.IsDate(statusbirthday))
            {
                Filter.Add("datediff(day,a.[birthday],'" + statusbirthday + "')<=0");
            }
            if (Base.Fun.fun.IsDate(endbirthday))
            {
                Filter.Add("datediff(day,a.[birthday],'" + endbirthday + "')>=0");
            }
            if (Base.Fun.fun.IsNumeric(startnum))
            {
                Filter.Add("b.[surplusnum]>=" + startnum);
            }
            if (Base.Fun.fun.IsNumeric(endnum))
            {
                Filter.Add("b.[surplusnum]<=" + endnum);
            }
            if (Base.Fun.fun.IsNumeric(cardtypeid))
            {
                Filter.Add("b.[cardtypeid]=" + cardtypeid);
            }
            if (Base.Fun.fun.IsNumeric(cardstatus))
            {
                Filter.Add("b.[cardstatus]=" + cardstatus);
            }
            dt = db.GetData("Select s.[userid] as 编号,b.[cardNo] as 卡号,a.[storesid] 店ID,ss.[title] 店名称,a.[name] as 姓名,a.[nickname] as 小名,CASE a.[sex] WHEN 0 THEN '男' ELSE '女' END AS 性别," + Model.Data.Basic.GetMonth("a.[birthday]") + " as 月龄,a.[parentname] as 家长,a.[mobile] as 手机,c.[title] as 小区,a.[cycletype] as 婴儿类型,a.[scorenum] as 积分,datediff(DAY,getdate(),b.[endtime]) as 有效期,a.[IsMeasure] as 测量,a.[IsPhoto] as 拍照,a.[addtime] as 建档时间,a.[content] as 备注 From [customer_User_Stores] as s inner join [customer_User] as a on a.[userid]=s.[userid] left join [Sys_stores] as ss on a.[storesid]=ss.[storesid] left join [customer_Card] as b on a.[cardid]=b.[cardid] left join [Sys_community] as c on a.[communityid]=c.[id] where " + string.Join(" and ", Filter.ToArray()) + " order by s.[userid] desc");
            db.Dispose();
            return dt;
        }

        /// <summary>
        /// 过期客户查询
        /// </summary>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public string View_expired(int PageSize,string storesid,string statusendtime,string endendtime)
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
                page.TableName = "[customer_User] as a inner join [customer_Card] as b on a.[cardid]=b.[cardid] left join [Sys_community] as c on a.[communityid]=c.[id]";
                page.OrderBy = "order by datediff(DAY,b.[endtime],getdate()) asc,a.[userid] desc";
                page.Index = "a.[userid]";
                page.Field = "a.[userid],b.[cardNo],a.[name],a.[nickname],a.[sex]," + Model.Data.Basic.GetMonth("a.[birthday]") + ",a.[parentname],a.[mobile],c.[title] as communityname,a.[cycletype],a.[scorenum],datediff(DAY,getdate(),b.[endtime]),a.[IsMeasure],a.[IsPhoto],a.[addtime],a.[content]";
                List<string> Filter = new List<string>();
                Filter.Add("a.[storesid]=" + storesid);
                Filter.Add("datediff(DAY,b.[endtime],getdate())>=20");
                if (Base.Fun.fun.IsDate(statusendtime))
                {
                    Filter.Add("b.[endtime]>='" + statusendtime + "'");
                }
                if (Base.Fun.fun.IsDate(endendtime))
                {
                    Filter.Add("b.[endtime]<='"+endendtime+"'");
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
        /// 潜在客户显示（所有未办卡的客户）
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid"></param>
        /// <param name="name">姓名</param>
        /// <param name="nickname">小名</param>
        /// <param name="communityid">小区</param>
        /// <param name="mobile">手机号</param>
        /// <param name="cycletype">婴儿类型</param>
        /// <param name="ReturnresultID">最后回访结果</param>
        /// <param name="statusmonthnum">开始月龄</param>
        /// <param name="endmonthnum">结束月龄</param>
        /// <returns></returns>
        public string View_Potential(int PageSize, string storesid, string name, string nickname, string communityid, string mobile, string cycletype, string ReturnresultID, string statusmonthnum, string endmonthnum)
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
                page.TableName = "[customer_User] as a left join [Sys_community] as c on a.[communityid]=c.[id] left join (select * from(select *,px = row_number() over (partition by [userid] order by [id] desc) from [Marketing_Visit])e where px = 1) as t on a.[userid]=t.[userid] left join [Staff_Member] as b on t.[memberid]=b.[id]";
                page.OrderBy = "order by a.[userid] desc";
                page.Index = "a.[userid]";
                page.Field = "a.[userid],a.[name],a.[nickname],a.[sex]," + Model.Data.Basic.GetMonth("a.[birthday]") + ",a.[parentname],a.[mobile],c.[title] as communityname,a.[cycletype],(select top 1 addtime From [customer_UserConsumption] Where [userid]=a.[userid] order by id desc) as lasttime,(select count([id]) From [Marketing_Visit] Where [UserID]=a.[userid]) as hfnum,t.[IsGiveup],t.[addtime],b.[name] as membername,t.[ReturnresultID],t.[content]";
                List<string> Filter = new List<string>();
                Filter.Add("a.[storesid]=" + storesid);
                Filter.Add("a.[State]<>1");
                if (name.Length > 0)
                {
                    Filter.Add("a.[name] like '%" + name + "%'");
                }
                if (Base.Fun.fun.pnumeric(communityid))
                {
                    Filter.Add("a.[communityid]=" + communityid);
                }
                if (mobile.Length > 0)
                {
                    Filter.Add("a.[mobile] like '%" + mobile + "%'");
                }
                if (nickname.Length > 0)
                {
                    Filter.Add("a.[nickname] like '%" + nickname + "%'");
                }
                if (Base.Fun.fun.IsNumeric(cycletype))
                {
                    Filter.Add("a.[cycletype]=" + cycletype);
                }
                if (Base.Fun.fun.IsNumeric(statusmonthnum))
                {
                    Filter.Add(Model.Data.Basic.GetMonth("a.[birthday]") + ">=" + statusmonthnum);
                }
                if (Base.Fun.fun.IsNumeric(endmonthnum))
                {
                    Filter.Add(Model.Data.Basic.GetMonth("a.[birthday]") + "<=" + endmonthnum);
                }
                if (Base.Fun.fun.IsNumeric(ReturnresultID))
                {
                    Filter.Add("t.[ReturnresultID]=" + ReturnresultID);
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
        /// 潜在客户显示（咨询未到店）数量
        /// </summary>
        /// <param name="storesid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public string View_consult(string storesid, string starttime, string endtime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string icount = db.GetValue("Select count([userid]) From [customer_User] Where [storesid]=" + storesid + " and [State]=3" + (Base.Fun.fun.IsDate("starttime") ? " and datediff(day,'" + starttime + "',a.[addtime])>=0" : "") + (Base.Fun.fun.IsDate("endtime") ? " and datediff(day,'" + endtime + "',a.[addtime])>=0" : "")).ToString();
            db.Dispose();
            return icount;
        }

        /// <summary>
        /// 潜在客户显示（咨询未到店）
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public string View_consult(int PageSize, string storesid, string starttime, string endtime)
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
                page.TableName = "[customer_User] as a left join [Sys_community] as c on a.[communityid]=c.[id]";
                page.OrderBy = "order by a.[userid] desc";
                page.Index = "a.[userid]";
                page.Field = "a.[userid],a.[name],a.[nickname],a.[sex]," + Model.Data.Basic.GetMonth("a.[birthday]") + ",a.[parentname],a.[tel],a.[mobile],c.[title] as communityname,a.[cycletype],a.[addtime],a.[content]";
                List<string> Filter = new List<string>();
                Filter.Add("a.[storesid]=" + storesid);
                Filter.Add("a.[State]=3");
                if (Base.Fun.fun.IsDate(starttime))
                {
                    Filter.Add("datediff(day,'" + starttime + "',a.[addtime])>=0");
                }
                if (Base.Fun.fun.IsDate(endtime))
                {
                    Filter.Add("datediff(day,'" + endtime + "',a.[addtime])<=0");
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
        /// 潜在客户显示（咨询未到店）
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public string View_consultTotal(string storesid, string starttime, string endtime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string count = db.GetValue("Select count([userid]) From [customer_User] Where [storesid]=" + storesid + " and [State]=3 and datediff(month,'" + starttime + "',[addtime])>=0 and datediff(month,'" + endtime + "',[addtime])<=0").ToString();
            db.Dispose();
            return count;
        }

        /// <summary>
        /// 潜在客户显示（咨询未办卡）
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public string View_consultNoCard(int PageSize, string storesid, string starttime, string endtime)
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
                page.TableName = "[customer_User] as a left join [Sys_community] as c on a.[communityid]=c.[id]";
                page.OrderBy = "order by a.[userid] desc";
                page.Index = "a.[userid]";
                page.Field = "a.[userid],a.[name],a.[nickname],a.[sex]," + Model.Data.Basic.GetMonth("a.[birthday]") + ",a.[parentname],a.[tel],a.[mobile],c.[title] as communityname,a.[cycletype],a.[addtime],a.[content]";
                List<string> Filter = new List<string>();
                Filter.Add("a.[storesid]=" + storesid);
                Filter.Add("a.[State] in(4,2,0)");
                if (Base.Fun.fun.IsDate(starttime))
                {
                    Filter.Add("datediff(day,'" + starttime + "',a.[addtime])>=0");
                }
                if (Base.Fun.fun.IsDate(endtime))
                {
                    Filter.Add("datediff(day,'" + endtime + "',a.[addtime])<=0");
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
        /// 潜在客户显示（咨询未办卡）
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public string View_consultNoCardTotal(string storesid, string starttime, string endtime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string count = db.GetValue("Select count([userid]) From [customer_User] Where [storesid]=" + storesid + " and [State] in (4,2,0) and datediff(month,'" + starttime + "',[addtime])>=0 and datediff(month,'" + endtime + "',[addtime])<=0").ToString();
            db.Dispose();
            return count;
        }

        /// <summary>
        /// 新来店
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public string View_Total(string storesid, string starttime, string endtime)
        {
            Base.Conn.Database db = new Base.Conn.Database();
            string count = db.GetValue("Select count([userid]) From [customer_User] Where [storesid]=" + storesid + " and datediff(month,'" + starttime + "',[addtime])>=0 and datediff(month,'" + endtime + "',[addtime])<=0").ToString();
            db.Dispose();
            return count;
        }


        /// <summary>
        /// 潜在客户显示（到店时长）
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public string View_LastTimeUser(int PageSize, string storesid, string num1, string num2)
        {
            StringBuilder str = new StringBuilder();
            DataTable dt = new DataTable();
            Base.Page.Dividepage page = new Base.Page.Dividepage();
            try
            {
                if (Base.Fun.fun.pnumeric(num1) || Base.Fun.fun.pnumeric(num2))
                {
                    if (PageSize <= 0)
                    {
                        PageSize = 15;
                    }
                    page.PageSize = PageSize;
                    page.TableName = "[customer_User] as a left join [Sys_community] as c on a.[communityid]=c.[id]";
                    page.OrderBy = "order by a.[userid] desc";
                    page.Index = "a.[userid]";
                    page.Field = "a.[userid],a.[name],a.[nickname],a.[sex]," + Model.Data.Basic.GetMonth("a.[birthday]") + ",a.[parentname],a.[mobile],c.[title] as communityname,a.[cycletype],a.[content]";
                    List<string> Filter = new List<string>();
                    Filter.Add("a.[storesid]=" + storesid);
                    if (Base.Fun.fun.IsNumeric(num1))
                    {
                        Filter.Add("a.[maxtimenum]>=" + num1);
                    }
                    if (Base.Fun.fun.IsNumeric(num2))
                    {
                        Filter.Add("datediff(day,a.[lasttime],getdate())>=" + num2);
                    }
                    page.Filter = string.Join(" and ", Filter.ToArray());
                    dt = page.getrows();
                }
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
        /// 潜在客户显示（到店时长）
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="storesid"></param>
        /// <returns></returns>
        public DataTable View_LastTimeUser＿DataTable(int PageSize, string storesid, string num1, string num2)
        {
            StringBuilder str = new StringBuilder();
            DataTable dt = new DataTable();
            Base.Conn.Database db = new Base.Conn.Database();
            try
            {
                if (Base.Fun.fun.pnumeric(num1) || Base.Fun.fun.pnumeric(num2))
                {
                    dt=db.GetData("select a.[userid],a.[name],a.[nickname],a.[sex]," + Model.Data.Basic.GetMonth("a.[birthday]") + ",a.[parentname],a.[mobile],c.[title] as communityname,a.[cycletype],a.[content] From [customer_User] as a left join [Sys_community] as c on a.[communityid]=c.[id] where a.[storesid]=" + storesid +(Base.Fun.fun.IsNumeric(num1)?" and a.[maxtimenum]>=" + num1:"")+(Base.Fun.fun.IsNumeric(num2)?" and datediff(day,a.[lasttime],getdate())>=" + num2:"")+" order by a.[userid] desc");

                }
            }
            catch (Exception e)
            {
                Base.Error.Error.WriteError(e);
                //错误记录
            }
            finally
            {
                db.Dispose();
            }
            return dt;
        }
        /// <summary>
        /// 获得所有停卡后要开的会员
        /// </summary>
        /// <returns></returns>
        public List<Model.customer.User> ReadList_StopOpen()
        {
            List<Model.customer.User> uList = new List<Model.customer.User>();
            Base.Conn.Database db = new Base.Conn.Database();
            DataTable dt = db.GetData(SqlStr_Join + @",b.[surplusnum],b.[starttime],b.[stoptime],b.[endtime] From [customer_User] as a inner join [customer_Card] as b on a.[Cardid]=b.[Cardid] where b.[cardstatus]=-1 and b.[surplusnum]>0 and DATEDIFF(d,b.[stoptime],GETDATE())>=1 and DATEDIFF(d,b.[endtime],GETDATE())<=0");
            db.Dispose();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Model.customer.User uModel = DataRow2Model(dr);
                    uModel.cModel = new Model.customer.Card();
                    uModel.cModel.surplusnum = dr["surplusnum"].ToString();
                    uModel.cModel.starttime = dr["starttime"].ToString();
                    uModel.cModel.stoptime = dr["stoptime"].ToString();
                    uModel.cModel.endtime = dr["endtime"].ToString();
                    uList.Add(uModel);
                }
            }
            dt.Dispose();
            return uList;
        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.customer.User DataRow2Model(DataRow dr)
        {
            Model.customer.User uModel = new Model.customer.User();
            uModel.userid = dr["userid"].ToString();
            uModel.userpass = dr["userpass"].ToString();
            uModel.storesid = dr["storesid"].ToString();
            uModel.userstoresid = dr["userstoresid"].ToString();
            uModel.name = dr["name"].ToString();
            uModel.nickname = dr["nickname"].ToString();
            uModel.sex = dr["sex"].ToString();
            uModel.birthday = dr["birthday"].ToString();
            uModel.parentName = dr["parentName"].ToString();
            uModel.tel = dr["tel"].ToString();
            uModel.mobile = dr["mobile"].ToString();
            uModel.communityid = dr["communityid"].ToString();
            uModel.illness = dr["illness"].ToString();
            uModel.allergy = dr["allergy"].ToString();
            uModel.cycletype = dr["cycletype"].ToString();
            uModel.source = dr["source"].ToString();
            uModel.content = dr["content"].ToString();
            uModel.addtime = dr["addtime"].ToString();
            uModel.cardid = dr["cardid"].ToString();
            uModel.IsMeasure = dr["IsMeasure"].ToString();
            uModel.IsPhoto = dr["IsPhoto"].ToString();
            uModel.scorenum = dr["scorenum"].ToString();
            uModel.IsPush = dr["IsPush"].ToString();
            uModel.Error = dr["Error"].ToString();
            uModel.ErrorTime = dr["ErrorTime"].ToString();
            uModel.AppID = dr["AppID"].ToString();
            uModel.Client = dr["Client"].ToString();
            uModel.Model = dr["Model"].ToString();
            uModel.State = dr["State"].ToString();
            uModel.userface = dr["userface"].ToString();
            uModel.photonum = dr["photonum"].ToString();
            uModel.maxtimenum = dr["maxtimenum"].ToString();
            uModel.lasttime = dr["lasttime"].ToString();
            return uModel;
        }
    }
}
