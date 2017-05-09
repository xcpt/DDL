<%@ Page Language="C#" AutoEventWireup="true" Inherits="Sys_community_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">
        小区管理:</div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=IsAdd?"":" style=\"padding-bottom:5px;\"" %>>
	  <div style="float:left" id="SearchInputValue">小区名称：<input name="Title" type="text" id="communityTitle" size="30" /></div>
	  <div style="float:left"><input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#communityGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <%if (IsAdd)
      { %>
    <div class="gnANk">
        <input type="submit" name="button" id="button" onclick="CreateWindow('Sys/community/Add.aspx', '添加小区','Sys/community/Add.aspx?action=save',500, 50,'communityAdd')" icon="icon-addNew" value="添加小区" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="communityGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#communityGrid").flexigrid
    (
    {
        url: 'Sys/community/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '名称', name: 'title', width: 200,autoSize:true, sortable: false, align: 'left'},
            { display: '操作管理', name: 'Q', width: 90, sortable: false, align: 'left',process:ManagerFun }
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Sys.community.View(StoresID, title)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function ManagerFun(value,id)
    {
        var str=new Array();
        <%if(IsModi){%>
        str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'Sys/community/Modi.aspx','修改小区', 'Sys/community/Modi.aspx?action=save', 500, 50,'communityModi');return false;\" >修改</a>");
        <%}
          if(IsDel){%>
        str.push("<a href=\"\" onclick=\"GridDel('"+id+"','Sys/community/Del.aspx');return false;\" >删除</a>");
        <%}%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, <%=IsAdd?"167":"140" %>, 2);
</script>
<%}
  else
  {
      Response.Write(Web.UI.Sys.community.View(StoresID, title));
  }%>