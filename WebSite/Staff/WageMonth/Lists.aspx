<%@ Page Language="C#" AutoEventWireup="true" Inherits="Staff_WageMonth_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">工资管理:</div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=IsAdd?"":" style=\"padding-bottom:5px;\"" %>>
	  <div style="float:left" id="SearchInputValue">姓名：<select name="memberid" id="SearchWageMonthmemberid">
          <option value="">&nbsp;</option>
          <%=Web.UI.Staff.member.GetOption(StoresID,"") %>
        </select>&nbsp;&nbsp;月份：<input type="text" name="datetime" id="SearchWageMonthdatetime" readonly="readonly" onClick="WdatePicker({skin:'ext',dateFmt:'yyyyMM'})" size="9"/></div>
	  <div style="float:left"><input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#swimteacherGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <%if (IsAdd)
      { %>
    <div class="gnANk">
        <input type="submit" name="button" id="button" onclick="CreateWindow('Staff/WageMonth/Add.aspx', '生成工资','Staff/WageMonth/Add.aspx?action=save',250, 50,'WageMonthAdd')" icon="icon-addNew" value="生成工资" /><input type="submit" name="button" id="Submit1" onclick="CreateWindow('Staff/WageMonth/Modi.aspx', '配置满意度提成比例','Staff/WageMonth/Modi.aspx?action=save',400, 190,'WageMonthModi')" icon="icon-addNew" value="配置满意度提成" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="WageMonthGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#WageMonthGrid").flexigrid
    (
    {
        url: 'Staff/WageMonth/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '月份', name: 'DateTime', width: 100, sortable: false, align: 'left'},
            { display: '姓名', name: 'Name', width: 120,autoSize:true, sortable: false, align: 'left'},
            { display: '级别', name: 'Level', width: 100, sortable: false, align: 'left'},
            { display: '底薪', name: 'salary', width:50, sortable: false, align: 'right'},
            { display: '保险', name: 'deducted', width:50, sortable: false, align: 'right'},
            <%=Web.UI.Data.Basic.performanceTypeToJsHead()%>
            { display: '实发工资', name: 'wagenum', width:80, sortable: false, align: 'right',process:WageNumFun},
            { display: '管理', name: 'M', width: 35, sortable: false, align: 'left',process:ManageFun}
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Staff.WageMonth.View(StoresID, memberid, datetime)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function PriceNum(value,id)
    {
        if(value.indexOf("-")!=-1)
        {
            value="<font color=red>"+value+"</font>";
        }
        return value;
    }
    function WageNumFun(value,id)
    {
        return "<font color=blue><b>"+value+"</b></font>";
    }
    function ManageFun(value,id)
    {
        return "<a href='#' onclick=\"GridModiy('"+id+"', 'Staff/WageMonth/Lists_View.aspx','详情',null, 600, 400);return false;\" >详情</a>";
    }
    GridFun(".Rnr", gridList, <%=IsAdd?"167":"140" %>, 2);
    $("#SearchWageMonthmemberid").chosen({ width:"120px"});
</script>
<%}
  else
  {
      Response.Write(Web.UI.Staff.WageMonth.View(StoresID, memberid, datetime));
  }%>