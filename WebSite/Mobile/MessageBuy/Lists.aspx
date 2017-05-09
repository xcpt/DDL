<%@ Page Language="C#" AutoEventWireup="true" Inherits="Mobile_MessageBuy_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">购买短信:</div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=IsAdd?"":" style=\"padding-bottom:5px;\"" %>>
	  <div style="float:left" id="SearchInputValue">套餐：<select name="setupid" id="SearchMessageBuysetupid">
          <option value="">&nbsp;</option>
          <%=Web.UI.Mobile.MessageSetup.GetOption("") %>
        </select>&nbsp;&nbsp;状态：<select name="status" id="SearchMessageBuystatus">
          <option value="">&nbsp;</option>
          <%=Web.UI.Data.Basic.MessageBugStatus("") %>
        </select>
	  </div>
	  <div style="float:left"><input type="button" name="button" id="SearchButton" value="搜 索" onclick="$('#MessageBuyGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <div class="gnANk">
        <span style="float:right;padding-right:10px;color:blue;">门店短信数量：<b><%=Web.UI.Mobile.Message.GetNum(StoresID)%></b>条<%if (SuperAdmin) {
                                                                                                                                 Response.Write("；总剩余数量：" + Web.UI.Mobile.MessageLog.SmsNum() + "条。");
                                                                                                                             } %></span>
       <%if (IsAdd)
      { %>
        <input type="submit" name="button" id="button" onclick="CreateWindow('Mobile/MessageBuy/Add.aspx', '购买套餐','Mobile/MessageBuy/Add.aspx?action=save',500, 190,'MessageBuyAdd')" icon="icon-vcard_add" value="购买套餐" />
        <%} %>
    </div>
</div>
<div class="RtbK">
    <table id="MessageBuyGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#MessageBuyGrid").flexigrid
    (
    {
        url: 'Mobile/MessageBuy/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '门店名称', name: 'name',autoSize:true, width: 100, sortable: false, align: 'left'},
            { display: '套餐', name: 'setupname', width: 300, sortable: false, align: 'left'},
            { display: '备注', name: 'content', width: 300, sortable: false, align: 'left'},
            { display: '状态', name: 'status', width: 60, sortable: false, align: 'left',process:statusFun},
            { display: '状态说明', name: 'statuscontent', width: 200, sortable: false, align: 'left'},
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
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Mobile.MessageBuy.View(StoresID, setupid, status)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function statusFun(value,id)
    {
        var s=<%=Web.UI.Data.Basic.MessageBugStatusToJs("MessageBugStatus")%>;
        return s["MessageBugStatus"+value];
    }
    function ManagerFun(value,id,row)
    {
        var str=new Array();
        <%if(IsAudit){%>
        if(row.cell[4]!="1")
        {
            str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'Mobile/MessageBuy/Modi.aspx','修改状态', 'Mobile/MessageBuy/Modi.aspx?action=save', 500, 190,'MessageBuyModi');return false;\" >审核</a>");
        }
        <%}else{
        if(IsOperate){%>
        if(row.cell[4]=="0")
        {
            str.push("<a href=\"\" onclick=\"GridProperty('"+id+"','Mobile/MessageBuy/Operate.aspx');return false;\">放弃</a>");
        }
        <%}
        }%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, <%=IsAdd?"167":"140" %>, 2);
    $("#SearchMessageBuysetupid").chosen({ width:"200px"});
    $("#SearchMessageBuystatus").chosen({ disable_search_threshold: 10 ,width:"80px"});
</script>
<%}
  else
  {
      Response.Write(Web.UI.Mobile.MessageBuy.View(StoresID, setupid, status));
  }%>