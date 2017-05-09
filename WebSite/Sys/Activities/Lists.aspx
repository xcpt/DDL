<%@ Page Language="C#" AutoEventWireup="true" Inherits="Sys_Activities_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">
        <%=classname %>管理:</div>
</div>
<div class="Tgnk">
	<div class="Rtss">
	  <div style="float:left" id="SearchInputValue"><%=classname %>名称：<input name="Title" type="text" id="SearchActivitiesTitle" size="30" /></div>
	  <div style="float:left"><input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#ActivitiesGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <div class="gnANk">
        <%if(IsOrder){ %>
        <input type="button" name="button" id="Button1" value="保存排序" onclick="AjaxFun('Sys/Activities/Order.aspx',ReadInputValue('ActivitiesGrid'),'正在排序中...',function(){$('#ActivitiesGrid').flexReload();});" icon="icon-table_Sort"/>
        <%} %>
       <%if (IsAdd)
      { %>
        <input type="submit" name="button" id="button" onclick="CreateWindow('Sys/Activities/Add.aspx?classid=<%=classid%>', '添加<%=classname%>','Sys/Activities/Add.aspx?action=save&classid=<%=classid%>',800,560,'ActivitiesAdd')" icon="icon-addNew" value="添加<%=classname %>" />
        <%} %>
    </div>
</div>
<div class="RtbK">
    <table id="ActivitiesGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#ActivitiesGrid").flexigrid
    (
    {
        url: 'Sys/Activities/Lists.aspx?classid=<%=classid%>',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '栏目', name: 'classname', width: 150,hide:true, sortable: false, align: 'left' },
            { display: '排序', name: 'orderid', width: 50, sortable: false, align: 'left',process:OrderFun},
            { display: '图片', name: 'Pic', width: 200,hide:true, sortable: false, align: 'left'},
            { display: '名称', name: 'title', width: 200,autoSize:true, sortable: false, align: 'left',process:titleFun},
            { display: '标签', name: 'tag', width: 100, sortable: false, align: 'left',hide:true},
            { display: '城市', name: 'pro', width: 150, sortable: false, align: 'left'},
            { display: '门店', name: 'storesname', width: 100, sortable: false, align: 'left'},
            { display: '添加时间', name: 'addtime', width: 130, sortable: false, align: 'left'},
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
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Sys.News.View("", classid, title)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        showOkFun:function(obj){obj.find("img.jTip").JT_init();},
        width: 500,
        height: 200
    }
    );
    function OrderFun(value,id)
    {
        return "<input type=\"hidden\" name=\"OrderID\" value=\""+id+"\"/><input type=\"text\" style=\"width:45px;\" name=\"OrderID\" value=\""+value+"\"/>";
    }
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
        str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'Sys/Activities/Modi.aspx','修改<%=classname%>', 'Sys/Activities/Modi.aspx?action=save', 800, 560,'ActivitiesModi');return false;\" >修改</a>");
        <%}
          if(IsDel){%>
        str.push("<a href=\"\" onclick=\"GridDel('"+id+"','Sys/Activities/Del.aspx');return false;\" >删除</a>");
        <%}%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, 167, 2);
</script>
<%}
  else
  {
      Response.Write(Web.UI.Sys.News.View("", classid, title));
  }%>