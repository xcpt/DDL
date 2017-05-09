<%@ Page Language="C#" AutoEventWireup="true" Inherits="Sys_Commodity_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">
        商品管理:</div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=IsAdd?"":" style=\"padding-bottom:5px;\"" %>>
	  <div style="float:left" id="SearchInputValue">商品名称：<input name="Title" type="text" id="CommodityTitle" size="30" /></div>
	  <div style="float:left"><input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#CommodityGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <%if (IsAdd)
      { %>
    <div class="gnANk">
        <input type="submit" name="button" id="button" onclick="CreateWindow('Sys/Commodity/Add.aspx', '添加商品','Sys/Commodity/Add.aspx?action=save',400,190,'CommodityAdd')" icon="icon-addNew" value="添加商品" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="CommodityGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#CommodityGrid").flexigrid
    (
    {
        url: 'Sys/Commodity/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '名称', name: 'title', width: 200,autoSize:true, sortable: false, align: 'left'},
            { display: '价格', name: 'price', width: 100, sortable: false, align: 'right'},
            { display: '积分', name: 'score', width: 50, sortable: false, align: 'right'},
            { display: '卡次', name: 'iscard', width: 35, sortable: false, align: 'center',process:isCardFun},
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
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Sys.Commodity.View(StoresID, title)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function isCardFun(value,id)
    {
        return ShowTrueOrFalse(value);
    }
    function ManagerFun(value,id)
    {
        var str=new Array();
        <%if(IsModi){%>
        str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'Sys/Commodity/Modi.aspx','修改商品', 'Sys/Commodity/Modi.aspx?action=save', 400, 190,'CommodityModi');return false;\" >修改</a>");
        <%}
          if(IsDel){%>
        str.push("<a href=\"\" onclick=\"GridDel('"+id+"','Sys/Commodity/Del.aspx');return false;\" >删除</a>");
        <%}%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, <%=IsAdd?"167":"140" %>, 2);
</script>
<%}
  else
  {
      Response.Write(Web.UI.Sys.Commodity.View(StoresID, title));
  }%>