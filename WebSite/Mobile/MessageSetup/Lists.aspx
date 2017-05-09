<%@ Page Language="C#" AutoEventWireup="true" Inherits="Mobile_MessageSetup_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">短信套餐:</div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=IsAdd?"":" style=\"padding-bottom:5px;\"" %>>
	  <div style="float:left" id="SearchInputValue">
          名称：<input name="title" type="text" id="SearchMessageSetupTitle" size="30" />
	  </div>
	  <div style="float:left"><input type="button" name="button" id="SearchButton" value="搜 索" onclick="$('#MessageSetupGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <%if (IsAdd)
      { %>
    <div class="gnANk">
        <input type="button" name="button" id="button" onclick="CreateWindow('Mobile/MessageSetup/Add.aspx', '添加套餐','Mobile/MessageSetup/Add.aspx?action=save',500, 140,'MessageSetupAdd')" icon="icon-addNew" value="添加套餐" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="MessageSetupGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#MessageSetupGrid").flexigrid
    (
    {
        url: 'Mobile/MessageSetup/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '名称', name: 'title', width: 100,autoSize:true, sortable: false, align: 'left'},
            { display: '短信数量', name: 'Num', width: 60, sortable: false, align: 'right'},
            { display: '价格', name: 'Price', width: 50, sortable: false, align: 'right'},
            { display: '启用', name: 'status', width: 35, sortable: false, align: 'left',process:OperateImgFun},
            { display: '管理', name: 'Q', width: 34, sortable: false, align: 'left',process:ManagerFun }
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Mobile.MessageSetup.View(title)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function OperateImgFun(value,id)
    {
        <%if(IsOperate){ %>
        return "<a href=\"#\" onclick=\"var obj=this;AjaxFun('Mobile/MessageSetup/Operate.aspx', 'id="+id+"', '正在设置属性，请稍候...',function(html){if (html){$(obj).html(ShowTrueOrFalse(html,''));}});return false;\">"+ShowTrueOrFalse(value,"")+"</a>";
        <%}else{ %>
        return ShowTrueOrFalse(value);
        <%} %>
    }
    function ManagerFun(value,id,row)
    {
        var str=new Array();
        <%if(IsModi){%>
        str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'Mobile/MessageSetup/Modi.aspx','修改套餐', 'Mobile/MessageSetup/Modi.aspx?action=save', 500, 140,'MessageSetupModi');return false;\" >修改</a>");
        <%}%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, <%=IsAdd?"167":"140" %>, 2);
</script>
<%}
  else
  {
      Response.Write(Web.UI.Mobile.MessageSetup.View(title));
  }%>