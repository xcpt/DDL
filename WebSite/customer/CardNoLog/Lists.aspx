<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_CardNoLog_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">换卡日志管理:</div>
</div>
<div class="Tgnk">
	<div class="Rtss" style="padding-bottom:5px;">
	  <div style="float:left" id="SearchInputValue">老卡号：<input name="OldCardNo" placeholder="输入卡号或刷卡" type="text" id="CardNoLogOldCardNo" size="30" />&nbsp;&nbsp;新卡号：<input name="NewCardNo" placeholder="输入卡号或刷卡" type="text" id="CardNoLogNewCardNo" size="30" />&nbsp;&nbsp;时间：<input type="text" name="stime" id="SearchCardNoLogstime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'SearchCardNoLogetime\')}'})" size="9"/>-<input type="text" name="etime" id="SearchCardNoLogetime" readonly="readonly" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'SearchCardNoLogstime\')}'})" size="9"/>
	  </div>
	  <div style="float:left"><input type="button" name="button" id="SearchButton" value="搜 索" onclick="$('#CardNoLogGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
</div>
<div class="RtbK">
    <table id="CardNoLogGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#CardNoLogGrid").flexigrid
(
{
    url: 'customer/CardNoLog/Lists.aspx',
    newp:<%=page %>,
    dataType: 'json',
    colModel: [
        { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
        { display: '原卡号', name: 'OldcardNo', width: 200,autoSize:true, sortable: false, align: 'left'},
        { display: '新卡号', name: 'NewcardNo', width: 200, sortable: false, align: 'left'},
        { display: '操作人', name: 'username', width: 100, sortable: false, align: 'left'},
        { display: '操作时间', name: 'addtime', width: 130, sortable: false, align: 'left'}
    ],
    showcheckbox:false,
    sortname: "id",
    sortorder: "asc",
    usepager: true,
    singleSelect: false,
    useRp: false,
    rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
    <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.customer.CardNoLog.View(StoresID, OldcardNo, NewcardNo, starttime, endtime)); %>,<%}%>
    showTableToggleBtn: false,
    showToggleBtn:false,
    width: 500,
    height: 200
}
    );
    GridFun(".Rnr", gridList, 135, 2);
</script>
<%}
  else
  {
      Response.Write(Web.UI.customer.CardNoLog.View(StoresID, OldcardNo, NewcardNo, starttime, endtime));
  }%>