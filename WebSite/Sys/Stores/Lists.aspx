<%@ Page Language="C#" AutoEventWireup="true" Inherits="Sys_Stores_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">
        门店管理:</div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=IsAdd?"":" style=\"padding-bottom:5px;\"" %>>
	  <div style="float:left" id="SearchInputValue">门店名称：<input name="Title" type="text" id="storesTitle" size="30" />&nbsp;开店时间：<input type="text" name="stime" id="storesstime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'storesetime\')}'})" size="9"/>-<input type="text" name="etime" id="storesetime" readonly="readonly" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'storesstime\')}'})" size="9"/>&nbsp;省：<input name="Province" type="text" id="storesProvince" size="20" />&nbsp;市：<input name="City" type="text" id="storesCity" size="20" /></div>
	  <div style="float:left"><input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#storesGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <%if (IsAdd)
      { %>
    <div class="gnANk">
        <input type="submit" name="button" id="button" onclick="CreateWindow('Sys/Stores/Add.aspx', '添加门店','Sys/Stores/Add.aspx?action=save',500, 325,'StoresAdd')" icon="icon-addNew" value="添加门店" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="storesGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#storesGrid").flexigrid
    (
    {
        url: 'Sys/Stores/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '名称', name: 'title', width: 200, sortable: false, align: 'left'},
            { display: '开店时间', name: 'opentime', width:160, sortable: false, align: 'left',process:TimeFun},
            { display: '省', name: 'Province', width: 80, sortable: false, align: 'left'},
            { display: '市', name: 'City', width: 80, sortable: false, align: 'left' },
            { display: '地址', name: 'address', width: 300,autoSize:true, sortable: false, align: 'left' },
            { display: '类型', name: 'istop', width: 50, sortable: false, align: 'left',process:istopFun },
            { display: '跨店', name: 'IsCross', width: 50, sortable: false, align: 'left',process:IsCrossFun },
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
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Sys.stores.View(title, stime, etime, Province, City)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function istopFun(value,id)
    {
        return value=="1"?"直营":"加盟";
    }
    function IsCrossFun(value,id)
    {
        return value=="1"?"是":"";
    }
    function TimeFun(value,id)
    {
        return value.split(' ')[0].split('/').join('-');
    }
    function ManagerFun(value,id)
    {
        var str=new Array();
        str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'Sys/Stores/Lists_View.aspx','门店信息', null, 500, 325);return false;\" >查看</a>");
        <%if(IsModi){%>
        str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'Sys/Stores/Modi.aspx','修改门店', 'Sys/Stores/Modi.aspx?action=save', 500, 325,'StoresModi');return false;\" >修改</a>");
        <%}
          if(IsDel){%>
        str.push("<a href=\"\" onclick=\"GridDel('"+id+"','Sys/Stores/Del.aspx');return false;\" >删除</a>");
        <%}%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, <%=IsAdd?"167":"140" %>, 2);
</script>
<%}
  else
  {
      Response.Write(Web.UI.Sys.stores.View(title, stime, etime, Province, City));
  }%>