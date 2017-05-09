<%@ Page Language="C#" AutoEventWireup="true" Inherits="Sys_Activities_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">
        <%=classname %>管理:</div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=IsAdd?"":" style=\"padding-bottom:5px;\"" %>>
	  <div style="float:left" id="SearchInputValue"><%=classname %>名称：<input name="Title" type="text" id="SearchNewsTitle" size="30" /></div>
	  <div style="float:left"><input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#NewsGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <%if (IsAdd)
      { %>
    <div class="gnANk">
        <input type="submit" name="button" id="button" onclick="CreateWindow('Sys/Version/Add.aspx?classid=<%=classid%>', '添加<%=classname%>','Sys/Version/Add.aspx?action=save&classid=<%=classid%>',500,285,'NewsAdd')" icon="icon-addNew" value="添加<%=classname %>" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="NewsGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#NewsGrid").flexigrid
    (
    {
        url: 'Sys/Version/Lists.aspx?classid=<%=classid%>',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '栏目', name: 'classname', width: 50,hide:true, sortable: false, align: 'left' },
            { display: '排序', name: 'orderid', width: 50,hide:true, sortable: false, align: 'left' },
            { display: '系统', name: 'Pic', width: 50, sortable: false, align: 'left'},
            { display: '版本名称', name: 'title', width: 200,autoSize:true, sortable: false, align: 'left'},
            { display: '版本号', name: 'tag', width: 100, sortable: false, align: 'left'},
            { display: '城市', name: 'tag', width: 100,hide:true, sortable: false, align: 'left'},
            { display: '门店', name: 'tag', width: 100,hide:true, sortable: false, align: 'left'},
            { display: '添加时间', name: 'addtime',hide:true, width: 130, sortable: false, align: 'left'},
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
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Sys.News.View("0", classid, title)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        showOkFun:function(obj){obj.find("img.jTip").JT_init();},
        width: 500,
        height: 200
    }
    );
    function titleFun(value,id,row)
    {
        if(row.cell[2].length>10)
        {
            return "<img src=images/icon/picture.png width=16 height=16 style=\"padding:5px;\" align=\"absmiddle\" alt=\"" + row.cell[2] + "?width=200&height=200\" class=\"jTip\" name=\"配图\" />"+value;
        }else{
            return value;
        }
    }
    function ManagerFun(value,id)
    {
        var str=new Array();
        <%if(IsModi){%>
        str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'Sys/Version/Modi.aspx','修改<%=classname%>', 'Sys/Version/Modi.aspx?action=save&classid=<%=classid%>', 500, 285,'NewsModi');return false;\" >修改</a>");
        <%}
          if(IsDel){%>
        str.push("<a href=\"\" onclick=\"GridDel('"+id+"','Sys/Version/Del.aspx');return false;\" >删除</a>");
        <%}%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, <%=IsAdd?"167":"140" %>, 2);
</script>
<%}
  else
  {
      Response.Write(Web.UI.Sys.News.View("0", classid, title));
  }%>