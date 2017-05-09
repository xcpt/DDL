<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web.CS.Manager.Log.Lists_Modi" %>
<%if (action == "view")
  { %>
<div class="Tgnk" style="padding-bottom:10px;">
	<div class="Rtss">
	  <div style="float:left" id="OldLogSearchInputValue">
          时间：<input type="text" name="stime" id="stime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'etime\')}'})" size="9"/><select name="stimeH"><%=strHour.ToString() %></select>时-<input type="text" name="etime" id="etime" readonly="readonly" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'stime\')}'})" size="9"/><select name="etimeH"><%=strHour.ToString() %></select>时
      </div>
      <div style="float:left"><input type="submit" name="button" id="Submit2" value="搜 索" onclick="$('#flex1Old').flexReload(ReadInputValue('OldLogSearchInputValue'));" icon="icon-zoom" /><input type="button" name="button" value="导出向后10页" onclick="    AjaxFun('Manager/Log/Lists_Export.aspx?action=page10', 'Description=<%=HttpUtility.UrlEncode(Description) %>&TableName=<%=HttpUtility.UrlEncode(TableName) %>&page='+$('#flex1Old').flexPage()+ReadInputValue('OldLogSearchInputValue'), '正在生成导出的文件，请稍候...', '');" icon="icon-xls" /></div>
    </div>
</div>
<div class="RtbK">
    <table id="flex1Old" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    var gridList= $("#flex1Old").flexigrid
    (
    {
        url: 'Manager/Log/Lists_Modi.aspx?Description=<%=HttpUtility.UrlEncode(Description) %>&TableName=<%=HttpUtility.UrlEncode(TableName) %>',
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'LogID', width: 50, sortable: false, align: 'left' },
            { display: '操作人', name: 'Name',width: 100, sortable: false, align: 'left' },
            { display: 'IP地址', name: 'Ip',width: 95, sortable: false, align: 'left' },
            { display: '操作时间', name: 'AddTime',width: 120, sortable: false, align: 'left' },
            { display: '类型', name: 'OID',width:25, sortable: false, align: 'left'},
            { display: '对应表', name: 'TableName',width:210, sortable: false, align: 'left',hide:true},
            { display: '访问地址', name: 'URL',width:200,autoSize:true, sortable: false, align: 'left',hide:true},
            { display: '查看', name: 'M',width:25, sortable: false, align: 'left',process:FieldFun }
        ],
        showcheckbox:false,
        sortname: "ID",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        autoload:true,
        PageOneValue:<%Base.Log.Log log = new Base.Log.Log();log.TableName = TableName;log.Description = Description;Response.Write(log.ShowPageLists(int.Parse(Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("rp"))), null,null, null,null));%>,
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 242,
        rowbinddata: true
        }
    );
    function FieldFun(value,id)
    {
        return "<a href=\"#\" onclick=\"LogView("+id+");return false;\" target='_blank'>查看</a>";
    }
</script>
<%}
  else
  {
      Base.Log.Log log = new Base.Log.Log();
      log.TableName = TableName;
      log.Description = Description;
      Response.Write(log.ShowPageLists(int.Parse(Base.Fun.fun.IsZero(Base.Fun.Fetch.getpost("rp"))), Stime, StimeH, Etime, EtimeH));
  }%>