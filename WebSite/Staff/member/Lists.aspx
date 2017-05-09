<%@ Page Language="C#" AutoEventWireup="true" Inherits="Staff_member_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">
        员工管理:</div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=IsAdd?"":" style=\"padding-bottom:5px;\"" %>>
	  <div style="float:left" id="SearchInputValue">姓名：<input name="Name" type="text" id="membername" size="30" /></div>
	  <div style="float:left"><input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#memberGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <%if (IsAdd)
      { %>
    <div class="gnANk">
        <input type="submit" name="button" id="button" onclick="CreateWindow('Staff/member/Add.aspx', '添加员工','Staff/member/Add.aspx?action=save',600, 555,'memberAdd')" icon="icon-user_add" value="添加员工" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="memberGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#memberGrid").flexigrid
    (
    {
        url: 'Staff/member/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '姓名', name: 'name', width: 50,autoSize:true, sortable: false, align: 'left'},
            { display: '英文名称', name: 'enname', width: 50, sortable: false, align: 'left'},
            { display: '性别', name: 'sex', width: 25, sortable: false, align: 'left',process:SexFun},
            { display: '手机', name: 'mobile', width: 80, sortable: false, align: 'left'},
            { display: '信箱', name: 'email', width: 120, sortable: false, align: 'left'},
            { display: 'QQ', name: 'qq', width: 80, sortable: false, align: 'left'},
            { display: '部门', name: 'title', width: 60, sortable: false, align: 'left',process:titleFun},
            { display: '主管', name: 'headmemberid', width: 120,hide:true, sortable: false, align: 'left'},
            { display: '生日', name: 'birthday', width: 60, sortable: false, align: 'left',process:TimeFun},
            { display: '年龄', name: 'age', width: 25, sortable: false, align: 'left'},
            { display: '职位', name: 'positionname', width: 50, sortable: false, align: 'left'},
            { display: '级别', name: 'level', width: 30, sortable: false, align: 'left'},
            { display: '状态', name: 'status', width: 30, sortable: false, align: 'left',process:statusFun},
            { display: '保险', name: 'isinsurance', width: 30, sortable: false, align: 'left',process:isinsuranceFun},
            { display: '入职时间', name: 'entrytime', width: 60, sortable: false, align: 'left',process:TimeFun},
            { display: '离职时间', name: 'quittime', width: 60, sortable: false, align: 'left',process:TimeFun},
            { display: '操作管理', name: 'Q', width: 190, sortable: false, align: 'left',process:ManagerFun }
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Staff.member.View(StoresID, name, status, departmentid)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function titleFun(value,id,row)
    {
        if(row.cell[8]==id)
        {
            return "<span style=\"float:right;\">[主管]</span>"+value;
        }else{
            return value;
        }
    }
    function TimeFun(value,id)
    {
        if(value.length>0)
        {
            value=value.split(' ')[0].replace("/","-").replace("/","-");
        }
        return value;
    }
    function isinsuranceFun(value,id)
    {
        return ShowTrueOrFalse(value);
    }
    function statusFun(value,id)
    {
        if(value=="1")
        {
            value="全职";
        }else if(value=="0"){
            value="兼职";
        }else if(value=="2")
        {
            value="离职";
        }else if(value=="3")
        {
            value="退休";
        }
        return value;
    }
    function SexFun(value,id)
    {
        if(value=="0")
        {
            value="男";
        }else{
            value="女";
        }
        return value;
    }
    function ManagerFun(value,id)
    {
        var str=new Array();
        str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'Staff/member/Lists_View.aspx','员工信息', null, 600, 555);return false;\" >查看</a>");
        str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'Staff/member/Lists_Total.aspx','员工绩效', null, 500, 400);return false;\" >绩效考核</a>");
        <%if(WageMonthIsAdd){%>
        str.push("<a href='#' onclick=\"AjaxFun('Staff/WageMonth/Lists.aspx', 'action=view&memberid="+id+"', ' ', '.Rnr');return false;\" >工资</a>");
        <%}
          if(IsModi){%>
        str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'Staff/member/Modi.aspx','修改员工信息', 'Staff/member/Modi.aspx?action=save', 600, 555,'memberModi');return false;\" >修改</a>");
        <%}
          if(IsDel){%>
        str.push("<a href=\"\" onclick=\"GridDel('"+id+"','Staff/member/Del.aspx');return false;\" >删除</a>");
        <%}%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, <%=IsAdd?"167":"140" %>, 2);
</script>
<%}
  else
  {
      Response.Write(Web.UI.Staff.member.View(StoresID, name, status, departmentid));
  }%>