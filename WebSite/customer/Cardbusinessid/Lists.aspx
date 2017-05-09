<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_Cardbusinessid_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">卡业务类型管理:</div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=IsAdd?"":" style=\"padding-bottom:5px;\"" %>>
	  <div style="float:left" id="SearchInputValue">业务名称：<input name="Title" type="text" id="CardbusinessidTitle" size="30" /></div>
	  <div style="float:left"><input type="button" name="button" id="SearchButton" value="搜 索" onclick="$('#CardbusinessidGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <%if (IsAdd)
      { %>
    <div class="gnANk">
        <input type="submit" name="button" id="button" onclick="CreateWindow('customer/Cardbusinessid/Add.aspx', '添加业务类型','customer/Cardbusinessid/Add.aspx?action=save',400, 50,'CardbusinessidAdd')" icon="icon-addNew" value="添加业务类型" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="CardbusinessidGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#CardbusinessidGrid").flexigrid
     (
     {
         url: 'customer/Cardbusinessid/Lists.aspx',
         newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '名称', name: 'title', width: 200,autoSize:true, sortable: false, align: 'left'},
            { display: '操作管理', name: 'Q', width: 70, sortable: false, align: 'left',process:ManagerFun }
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.customer.Cardbusinessid.View(StoresID, title)); %>,<%}%>
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
        str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'customer/Cardbusinessid/Modi.aspx','修改', 'customer/Cardbusinessid/Modi.aspx?action=save', 400, 50,'CardbusinessidModi');return false;\" >修改</a>");
        <%}
          if(IsDel){%>
        str.push("<a href=\"\" onclick=\"GridDel('"+id+"','customer/Cardbusinessid/Del.aspx');return false;\" >删除</a>");
        <%}%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, <%=IsAdd?"167":"140" %>, 2);
</script>
<%}
  else
  {
      Response.Write(Web.UI.customer.Cardbusinessid.View(StoresID, title));
  }%>