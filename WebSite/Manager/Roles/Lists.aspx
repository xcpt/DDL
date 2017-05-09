<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web.CS.Manager.Roles.Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">
        角色管理:</div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=IsAdd?"":" style=\"padding-bottom:5px;\"" %>>
	  <div style="float:left" id="SearchInputValue">角色名称：<input name="RoleName" type="text" id="RoleName" size="30" /></div>
	  <div style="float:left"><input type="submit" name="button" id="Submit1" value="搜 索" onclick="$('#flex1').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <%if(IsAdd){ %>
    <div class="gnANk">
        <input type="submit" name="button" id="Submit2" onclick="CreateWindow('Manager/Roles/Add.aspx', '添加角色','Manager/Roles/Add.aspx?action=save',450, 210,'RolesAdd')" icon='icon-vcard_add' value="添加角色" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="flex1" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    var gridList= $("#flex1").flexigrid
    (
    {
        url: 'Manager/Roles/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: 'ID', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '所属门店', name: 'StoresName',hide:true,width: 150, sortable: false, align: 'left'},
            { display: '角色名称', name: 'RoleName',width: 200, sortable: false, align: 'left' ,process:RoleNameFun},
            { display: '角色描述', name: 'RoleDescription',width: 450,autoSize:true, sortable: false, align: 'left' },
            { display: '权限设置', name: 'Q',width:130, sortable: false, align: 'left',process:RolesFun}
        ],
        showcheckbox:false,
        sortname: "ID",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Web.UI.Roles role = new Web.UI.Roles(); Response.Write(role.ViewList(RoleName, SuperAdmin, StoresID)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function StoresNameFun(value)
    {
        if(value=="" || value=="&nbsp;")
        {
            return "【全局】&nbsp;";
        }else{
            return "【"+value+"】&nbsp;";
        }
    }
    function RoleNameFun(value,id,row)
    {
        if(id=="1")
        {
            return StoresNameFun(row.cell[1])+value;
        }else{
            <%if(IsModi){ %>
            return StoresNameFun(row.cell[1])+"<a href='#nogo' onclick=\"GridModiy('"+id+"', 'Manager/Roles/Modi.aspx','修改', 'Manager/Roles/Modi.aspx?action=save', 450, 210,'RolesModi',{ Name: '另存为', Url: 'Manager/Roles/Add.aspx?action=save'});return false;\" >"+value+"</a>";
            <%}else{ %>
            return StoresNameFun(row.cell[1])+value;
            <%} %>
        }
    }
    function RolesFun(value,id)
    {
        var isDisableStr=""
        if(id=="1")
        {
            return "<font style=\"color:#c0c0c0;\">修改 | 设置权限 | 删除</font>";
        }
        else
        {
            var str=new Array();
            <%if(IsModi){ %>
            str.push("<a href='#nogo' onclick=\"GridModiy('"+id+"', 'Manager/Roles/Modi.aspx','修改', 'Manager/Roles/Modi.aspx?action=save', 450, 210,'RolesModi',{ Name: '另存为', Url: 'Manager/Roles/Add.aspx?action=save'});return false;\" >修改</a>");
            <%} %>
            <%if(IsOperate){ %>
            str.push("<a href='#nogo' onclick=\"GridModiy('"+id+"', 'Manager/Roles/Operate.aspx','设置权限', 'Manager/Roles/Operate.aspx?action=save', 700, 500);return false;\" >设置权限</a>");
            <%} %>
            <%if(IsDel){ %>
            str.push("<a href=\"\" onclick=\"GridDel('"+id+"','Manager/Roles/Del.aspx');return false;\" >删除</a>");
            <%} %>
            return str.join(" | ");
        }
    }
    GridFun(".Rnr", gridList, <%=IsAdd?"167":"140" %>, 2);
</script>
<%}
  else
  {
      Web.UI.Roles role = new Web.UI.Roles();
      Response.Write(role.ViewList(RoleName, SuperAdmin, StoresID));
  }%>