<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web.CS.Manager.Log.Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">
        日志管理:</div><a href="#" class="dq">操作日志</a><a href="#" onclick="AjaxFun('Manager/Log/Lists_Error.aspx?action=view', '', ' ', '.Rnr', '.Rnr');return false;">错误日志</a>
</div>
<div class="Tgnk">
	<div class="Rtss">
	  <div style="float:left" id="SearchInputValue">
	  操作人：<input type="text" name="Name" value="<%=Name %>" size="10" />&nbsp;对应表：<input type="text" name="TableName" value="<%=TableName %>" size="10" />&nbsp;
      访问地址：<input type="text" name="SUrl" size="10" />
      时间：<input type="text" name="stime" id="stime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'etime\')}'})" size="9"/><select name="stimeH"><%=strHour.ToString() %></select>时-<input type="text" name="etime" id="etime" readonly="readonly" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'stime\')}'})" size="9"/><select name="etimeH"><%=strHour.ToString() %></select>时
      </div>
	  <div style="float:left">
	  <input type="submit" name="button" id="Submit2" value="搜 索" onclick="$('#flex1').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <div class="gnANk">
    <%if (IsDel)
      { %>
        <input icon="icon-delete" type="submit" name="button" value="删  除" onclick="GridDel($('#flex1'),'Manager/Log/Del.aspx');" />
        <input icon="icon-delete" type="submit" name="button" value="删除半月前日志" onclick="GridDel('0','Manager/Log/Del.aspx?action=del');" />
        <input icon="icon-delete" type="submit" name="button" value="清空所有日志" onclick="GridDel('0','Manager/Log/Del.aspx?action=all');" />
        <span style="float:left;">&nbsp;&nbsp;</span>
        <%} %>
        <input type="button" name="button" value="导出当前页" onclick="AjaxFun('Manager/Log/Lists_Export.aspx?action=page', 'id='+GridReadCheckBoxID($('#flex1')), '正在生成导出的文件，请稍候...', '');" icon="icon-xls" />
        <input type="button" name="button" value="导出当前开始10页" onclick="AjaxFun('Manager/Log/Lists_Export.aspx?action=page10', 'page='+$('#flex1').flexPage()+ReadInputValue('SearchInputValue'), '正在生成导出的文件，请稍候...', '');" icon="icon-xls" />
    </div>
</div>
<div class="RtbK">
    <table id="flex1" style="display: none;">
    </table>
</div>
<script type="text/javascript">
        var gridList= $("#flex1").flexigrid
        (
        {
        url: 'Manager/Log/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'LogID', width: 50, sortable: false, align: 'left' },
            { display: '操作人', name: 'Name',width: 100, sortable: false, align: 'left' },
            { display: 'IP地址', name: 'Ip',width: 100, sortable: false, align: 'left' },
            { display: '操作时间', name: 'AddTime',width: 120, sortable: false, align: 'left' },
            { display: '类型', name: 'OID',width:30, sortable: false, align: 'left'},
            { display: '对应表', name: 'TableName',width:210, sortable: false, align: 'left' },
            { display: '访问地址', name: 'URL',width:200,autoSize:true, sortable: false, align: 'left',process:OUrlFun },
            { display: '查看', name: 'M',width:30, sortable: false, align: 'left',process:FieldFun }
        ],
        showcheckbox:true,
        sortname: "ModelID",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Base.Log.Log log = new Base.Log.Log();log.Name = Name;log.TableName = TableName;log.Url = Url;Response.Write(log.ShowPageLists(int.Parse(Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("rp"))), Stime,StimeH, Etime,EtimeH)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
        }
        );
	    function OUrlFun(value,id)
		{
		    value=unescape(value);
		    var time=getParameter("time",value);
		    value=value.replace("?time="+time,"").replace("&time="+time,"");
		    return value;
		}
	    function FieldFun(value,id)
	    {
	        return "<a href=\"#\" onclick=\"LogView("+id+");return false;\" target='_blank'>查看</a>";
	    }
	    GridFun(".Rnr", gridList, 167, 2);
</script>
<%}
  else
  {
      Base.Log.Log log = new Base.Log.Log();
      log.Name = Name;
      log.TableName = TableName;
      log.Url = Url;
      Response.Write(log.ShowPageLists(int.Parse(Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("rp"))), Stime, StimeH, Etime, EtimeH));
  }%>