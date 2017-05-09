<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web.CS.Manager.Users.Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">
        用户管理:</div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=IsAdd?"":" style=\"padding-bottom:5px;\"" %>>
	  <div style="float:left" id="SearchInputValue">用户名：<input name="UserName" type="text" id="UserName" size="30" /></div>
	  <div style="float:left"><input type="submit" name="button" id="Submit1" value="搜 索" onclick="$('#flex1').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <%if (IsAdd)
      { %>
    <div class="gnANk">
        <input type="submit" name="button" id="button" onclick="CreateWindow('Manager/Users/Add.aspx', '添加用户','Manager/Users/Add.aspx?action=save',500, 320,'UsersAdd')" icon="icon-user_add" value="添加用户" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="flex1" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    var GroupName=<%=Web.UI.Users.GetGroupName() %>;
    var RoleName=<%=Web.UI.Roles.GetManagerRole() %>;
    var gridList= $("#flex1").flexigrid
    (
    {
        url: 'Manager/Users/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'userID', width: 50, sortable: false, align: 'left' },
            { display: '所属门店', name: 'Department', width: 200, sortable: false, align: 'left',process:DepartmentFun},
            { display: '用户名', name: 'userName', width: 200,autoSize:true, sortable: false, align: 'left',process:UserNameFun},
            { display: '所属角色', name: 'RoleIDS', width: 300, sortable: false, align: 'left',process:ManagerRoleFun },
            { display: '最后登录IP', name: 'LastLoginIP', width: 100, sortable: false, align: 'left' },
            { display: '最后登录时间', name: 'LastLoginTime', width: 120, sortable: false, align: 'left' },
            { display: '登录次数', name: 'LoginTimes', width: 50, sortable: false, align: 'left'},
            { display: '锁定', name: 'isLock', width: 30, sortable: false, align: 'center',process:ImgFun},
            { display: '操作管理', name: 'Q', width: 90, sortable: false, align: 'left',process:OperateFun }
        ],
        showcheckbox:false,
        sortname: "userID",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Web.UI.Users user = new Web.UI.Users(); Response.Write(user.ViewList(UserName, StoresID, SuperAdmin)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function DepartmentFun(value,id,row)
    {
        if(row.cell[3]=="1")
        {
            return "&nbsp;";
        }else{
            return value;
        }
    }
    function ImgFun(value,id)
    {
        <%if(IsOperate){ %>
        return "<a href=\"#\" onclick=\"var obj=this;AjaxFun('Manager/Users/Operate.aspx', 'Userid="+id+"', '正在设置属性，请稍候...',function(html){if (html){$(obj).html(ShowTrueOrFalse(html,''));}});return false;\">"+ShowTrueOrFalse(value,"")+"</a>";
        <%}else{ %>
        return ShowTrueOrFalse(value);
        <%} %>
    }
    function GroupNameFun(value,id)
    {
        return ReadClass("GroupName_"+value,GroupName);
    }
    function UserNameFun(value,id)
    {
        <%if(IsModi){ %>
        return "<a href='#' onclick=\"GridModiy('"+id+"', 'Manager/Users/Modi.aspx','修改用户信息', 'Manager/Users/Modi.aspx?action=save', 500, 320,'UsersModi');return false;\" >"+value+"</a>";
        <%}else{ %>
        return value;
        <%} %>
    }
    function OperateFun(value,id)
    {
        var str=new Array();
        str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'Manager/Users/Lists_Per.aspx?action=view', '绩效', null, 700, 350);return false;\" title=\"显示用户最终操作统计\">绩效</a>");
        <%if(IsModi){ %>
        str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'Manager/Users/Modi.aspx','修改用户信息', 'Manager/Users/Modi.aspx?action=save', 700, 320,'UsersModi');return false;\" >修改</a>");
        <%} %>
        <%if(IsDel){ %>
        str.push("<a href=\"\" onclick=\"GridDel('"+id+"','Manager/Users/Del.aspx');return false;\" >删除</a>");
        <%} %>
        return str.join(" | ");
    }
    function ManagerRoleFun(value,id)
    {
        var _value=value.split(",");
        var reval="";
        for(var i=0;i<_value.length;i++)
        {
            reval+=ReadClass("RoleName_"+_value[i],RoleName)+"，";
        }
        if(reval.length>2)
        {
            reval=reval.substring(0,reval.length-1);
        }
        if(reval && reval!="undefined")
        {
            return reval;
        }else{
            return "";
        }
    }
    GridFun(".Rnr", gridList, <%=IsAdd?"167":"140" %>, 2);
</script>
<%}
  else
  {
      Web.UI.Users user = new Web.UI.Users();
      Response.Write(user.ViewList(UserName, StoresID, SuperAdmin));
  }%>