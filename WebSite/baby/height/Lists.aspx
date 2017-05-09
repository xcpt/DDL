<%@ Page Language="C#" AutoEventWireup="true" Inherits="baby_height_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">身高国际:</div>
</div>
<div class="Tgnk">
	<div class="Rtss">
	  <div style="float:left" id="SearchInputValue">月龄：<input name="monthage" type="text" id="Searchheightmonthage" size="30" />&nbsp;&nbsp;性别：<select name="sex" id="Searchheightsex">
          <option value="">&nbsp;</option>
          <option value="0">男</option>
          <option value="1">女</option>
        </select></div>
	  <div style="float:left"><input type="button" name="button" id="SearchButton" value="搜 索" onclick="$('#heightGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <div class="gnANk">
        <%if (IsAdd)
        { %>
        <input type="button" name="button" id="button" onclick="CreateWindow('baby/height/Add.aspx', '身高国际','baby/height/Add.aspx?action=save',400,185,'heightAdd')" icon="icon-addNew" value="新增" />
        <%} %>
        <input type="button" name="button" id="Submit2" onclick="CreateWindow('baby/height/Lists_Chart.aspx', '曲线图（男）',null,700,400)" icon="icon-chart_curve" value="曲线图（男）" />
        <input type="button" name="button" id="Button1" onclick="CreateWindow('baby/height/Lists_Chart.aspx?sex=1', '曲线图（女）',null,700,400)" icon="icon-chart_curve" value="曲线图（女）" />
    </div>
</div>
<div class="RtbK">
    <table id="heightGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#heightGrid").flexigrid
    (
    {
        url: 'baby/height/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '月龄', name: 'monthage', width: 100,autoSize:true, sortable: false, align: 'left'},
            { display: '性别', name: 'sex', width: 100, sortable: false, align: 'left',process:SexFun},
            { display: '最小', name: 'minnum', width: 100, sortable: false, align: 'left'},
            { display: '最大', name: 'maxnum', width: 60, sortable: false, align: 'left'},
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
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.baby.height.View(monthage, sex)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function SexFun(value,id)
    {
        if(value=="0")
        {
            value="男";
        }else{
            value="女";
        }
        return value;
    }
    function ManagerFun(value,id,row)
    {
        var str=new Array();
        <%if(IsModi){%>
        str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'baby/height/Modi.aspx','身高国际', 'baby/height/Modi.aspx?action=save', 400, 185,'heightModi');return false;\" >修改</a>");
        <%}
        if(IsDel){%>
        str.push("<a href=\"\" onclick=\"GridDel('"+id+"','baby/height/Del.aspx');return false;\" >删除</a>");
        <%}%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, 167, 2);
    $("#Searchheightsex").chosen({ disable_search_threshold: 10 , width:"100px"});
</script>
<%}
  else
  {
      Response.Write(Web.UI.baby.height.View(monthage, sex));
  }%>