<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web.CS.Manager.Users.Lists_Per" %>
<%if (action == "view")
  { %>
<div class="Tgnk">
	<div class="Rtss" style="padding-bottom:5px;">
	  <div style="float:left" id="SearchInputValuePer">
      对应表：<input type="text" name="tablename" size="20" />
      时间：<input type="text" name="stime" id="stime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'etime\')}'})" size="9"/>-<input type="text" name="etime" id="etime" readonly="readonly" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'stime\')}'})" size="9"/>
      </div>
	  <div style="float:left">
	  <input type="submit" name="button" id="Submit2" value="搜 索" onclick="$('#flex1Per').flexReload(ReadInputValue('SearchInputValuePer'));" icon="icon-zoom" />
      <input type="submit" name="button" id="Submit1" value="导 出" onclick="AjaxFun('Manager/Users/Lists_Excel.aspx?ID=<%=UserID %>', ReadInputValue('SearchInputValuePer'), '正在导出请稍候...');" icon="icon-xls" />
      <input type="submit" name="button" id="Submit3" value="查看曲线图（30天）" onclick="GridModiy('<%=UserID %>&'+ReadInputValue('SearchInputValuePer'), 'Manager/Users/Lists_Chart.aspx', '曲线图', null, 650, 350);" icon="icon-chart_curve" />
      </div>
	</div>
</div>
<div class="RtbK">
    <table id="flex1Per" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    var gridList= $("#flex1Per").flexigrid
    (
    {
        url: 'Manager/Users/Lists_Per.aspx?ID=<%=UserID %>',
        dataType: 'json',
        colModel: [
            { display: 'ID', name: 'id', width: 50, sortable: false,hide:true, align: 'left' },
            { display: '对应表', name: 'title', width: 330, sortable: false, align: 'left'},
            { display: '时间', name: 'DateTime', width: 70, sortable: false, align: 'left'},
            { display: '添加', name: 'AddNum', width: 40, sortable: false, align: 'left'},
            { display: '修改', name: 'ModiyNum', width: 40, sortable: false, align: 'left'},
            { display: '删除', name: 'DelNum', width:40, sortable: false, align: 'left'},
            { display: '审核', name: 'AuditNum', width: 40, sortable: false, align: 'left'},
            { display: '其它', name: 'OtherNum', width: 40, sortable: false, align: 'left'}
        ],
        showcheckbox:false,
        sortname: "ID",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        PageOneValue:<%Base.Log.Log log = new Base.Log.Log();log.TableName = TableName;Response.Write(log.UserTotalShowPageLists(PageSize, UserID, Stime, Etime)); %>,
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 700,
        height: 248
    }
    );
</script>
<%}
  else
  {
      Base.Log.Log log = new Base.Log.Log();
      log.TableName = TableName;
      Response.Write(log.UserTotalShowPageLists(PageSize, UserID, Stime, Etime));
  }%>