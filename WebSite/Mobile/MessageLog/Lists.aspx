<%@ Page Language="C#" AutoEventWireup="true" Inherits="Mobile_MessageLog_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">发送日志:</div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=IsAdd?"":" style=\"padding-bottom:5px;\"" %>>
	  <div style="float:left" id="SearchInputValue">
          手机号：<input name="mobile" type="text" id="SearchMessageLogmobile" size="30" />
          &nbsp;&nbsp;发送内容：<input name="content" type="text" id="SearchMessageLogContent" size="30" />
          &nbsp;&nbsp;时间：<input type="text" name="stime" id="SearchMessageLogstime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'SearchMessageLogetime\')}'})" size="9"/>-<input type="text" name="etime" id="SearchMessageLogetime" readonly="readonly" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'SearchMessageLogstime\')}'})" size="9"/>
	  </div>
	  <div style="float:left"><input type="button" name="button" id="SearchButton" value="搜 索" onclick="$('#MessageLogGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <%if (IsAdd)
      { %>
    <div class="gnANk">
        <span style="float:right;padding-right:10px;color:blue;">门店短信数量：<b><%=Web.UI.Mobile.Message.GetNum(StoresID)%></b>条</span>
        <input type="button" name="button" id="button" onclick="CreateWindow('Mobile/MessageLog/Add.aspx', '发送消息','Mobile/MessageLog/Add.aspx?action=save',600, 400,'MessageLogAdd')" icon="icon-resultset_next" value="发送消息" />
        <input type="button" name="button" id="Submit2" onclick="CreateWindow('Mobile/MessageLog/Add_For.aspx', '条件发送','Mobile/MessageLog/Add_For.aspx?action=save',600, 425,'MessageLogAdd')" icon="icon-resultset_next" value="条件发送" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="MessageLogGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#MessageLogGrid").flexigrid
    (
    {
        url: 'Mobile/MessageLog/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '手机号/APP', name: 'Mobile', width: 150, sortable: false, align: 'left'},
            { display: '发送时间', name: 'SendTime', width: 120, sortable: false, align: 'left',process:SendTimeFun},
            { display: '提交时间', name: 'AddTime', width: 120, sortable: false, align: 'left'},
            { display: '内容', name: 'content',autoSize:true, width: 200, sortable: false, align: 'left'},
            { display: '接收', name: 'sendtype', width: 35, sortable: false, align: 'left',process:sendtypeFun},
            { display: '状态', name: 'status', width: 35, sortable: false, align: 'left',process:statusFun},
            { display: '状态码', name: 'message', width: 100, sortable: false, align: 'left'},
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
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Mobile.MessageLog.View(StoresID, mobile, title, statustime, endtime)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function sendtypeFun(value,id)
    {
        if(value=="1")
        {
            return "APP";
        }else{
            return "手机";
        }
    }
    function SendTimeFun(value,id)
    {
        if(value.length>6)
        {
            return value;
        }else{
            return "立即";
        }
    }
    function statusFun(value,id)
    {
        if(value=="1")
        {
            return "<font color=blue>成功</font>";
        }else if(value=="0"){
            return "等待";
        }else if(value=="-1"){
            return "<font color=red>失败</font>";
        }
    }
    function ManagerFun(value,id,row)
    {
        var str=new Array();
        <%if(IsAdd){%>
        if(row.cell[6]=="0")
        {
            str.push("<a href=\"\" onclick=\"GridProperty('"+id+"','Mobile/MessageLog/Add_Send.aspx');return false;\">发送</a>");
        }
        <%}%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, <%=IsAdd?"167":"140" %>, 2);
</script>
<%}
  else
  {
      Response.Write(Web.UI.Mobile.MessageLog.View(StoresID, mobile, title, statustime, endtime));
  }%>