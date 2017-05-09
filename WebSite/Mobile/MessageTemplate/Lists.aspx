<%@ Page Language="C#" AutoEventWireup="true" Inherits="Mobile_MessageTemplate_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">短信模板:</div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=IsAdd?"":" style=\"padding-bottom:5px;\"" %>>
	  <div style="float:left" id="SearchInputValue">
          标题：<input name="title" type="text" id="SearchMessageTemplateTitle" size="30" />
	  </div>
	  <div style="float:left"><input type="button" name="button" id="SearchButton" value="搜 索" onclick="$('#MessageTemplateGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <%if (IsAdd)
      { %>
    <div class="gnANk">
        <input type="button" name="button" id="button" onclick="CreateWindow('Mobile/MessageTemplate/Add.aspx', '添加短信模板','Mobile/MessageTemplate/Add.aspx?action=save',500, 155,'MessageTemplateAdd')" icon="icon-addNew" value="添加短信模板" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="MessageTemplateGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#MessageTemplateGrid").flexigrid
    (
    {
        url: 'Mobile/MessageTemplate/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '标题', name: 'title', width: 250, sortable: false, align: 'left'},
            { display: '内容', name: 'Num', width:200,autoSize:true, sortable: false, align: 'left'},
            { display: '管理', name: 'Q', width: 70, sortable: false, align: 'left',process:ManagerFun }
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Mobile.MessageTemplate.View(StoresID, title)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function ManagerFun(value,id,row)
    {
        var str=new Array();
        <%if(IsModi){%>
        str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'Mobile/MessageTemplate/Modi.aspx','短信模板修改', 'Mobile/MessageTemplate/Modi.aspx?action=save', 500, 155,'MessageTemplateModi');return false;\" >修改</a>");
        <%}
          if(IsDel){%>
        str.push("<a href=\"\" onclick=\"GridDel('"+id+"','Mobile/MessageTemplate/Del.aspx');return false;\" >删除</a>");
        <%}%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, <%=IsAdd?"167":"140" %>, 2);
</script>
<%}
  else
  {
      Response.Write(Web.UI.Mobile.MessageTemplate.View(StoresID, title));
  }%>