<%@ Page Language="C#" AutoEventWireup="true" Inherits="score_log_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">积分变更日志:</div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=IsAdd?"":" style=\"padding-bottom:5px;\"" %>>
	  <div style="float:left" id="SearchInputValue">会员姓名：<input name="Name" type="text" id="SearchlogName" size="30" />&nbsp;&nbsp;客户手机：<input name="mobile" type="text" id="Searchlogmobile" size="30" />
          &nbsp;&nbsp;类型：<select name="type" id="Searchlogtype" style="width:100px;">
                <option value="" selected="selected">&nbsp;</option>
                <option value="0">系统增加</option>
                <option value="2">手动增加</option>
                <option value="1">积分兑换</option>
            </select>&nbsp;&nbsp;时间：<input type="text" name="stime" id="Searchlogstime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'Searchlogetime\')}'})" size="9"/>-<input type="text" name="etime" id="Searchlogetime" readonly="readonly" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'Searchlogstime\')}'})" size="9"/>
	  </div>
	  <div style="float:left"><input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#logGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <%if (IsAdd)
      { %>
    <div class="gnANk">
        <input type="submit" name="button" id="button" onclick="CreateWindow('score/log/Add.aspx', '添加会员积分','score/log/Add.aspx?action=save',600, 200,'logAdd')" icon="icon-addNew" value="添加会员积分" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="logGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#logGrid").flexigrid
    (
    {
        url: 'score/log/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '会员姓名', name: 'name', width: 100, sortable: false, align: 'left'},
            { display: '手机号', name: 'mobile', width: 100, sortable: false, align: 'left'},
            { display: '记录时间', name: 'addtime', width: 130, sortable: false, align: 'left'},
            { display: '类型', name: 'type', width: 60, sortable: false, align: 'left',process:typeFun},
            { display: '积分', name: 'score', width: 80, sortable: false, align: 'right',process:ScoreFun},
            { display: '备注', name: 'content', width: 350,autoSize:true, sortable: false, align: 'left'},
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
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.score.log.View(StoresID, name, mobile, type, starttime, endtime)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function ScoreFun(value,id)
    {
        if(value.indexOf("-")!=-1)
        {
            return "<font color=red>"+value+"</font>";
        }else{
            return "<font color=blue>"+value+"</font>";
        }
    }
    function typeFun(value,id)
    {
        if(value=="0")
        {
            value="系统增加";
        }else if(value=="1"){
            value="积分对换";
        }else if(value=="2")
        {
            value="手动增加";
        }
        return value;
    }
    function ManagerFun(value,id,row)
    {
        var str=new Array();
        <%if(IsDel){%>
        if(row.cell[4]=="2")
        {
            str.push("<a href=\"\" onclick=\"GridDel('"+id+"','score/log/Del.aspx');return false;\" title=\"删除后会员积分相应减少\" >删除</a>");
        }
        <%}%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, <%=IsAdd?"167":"140" %>, 2);
    $("#Searchlogtype").chosen({ disable_search_threshold: 10 ,width:"100px"});
</script>
<%}
  else
  {
      Response.Write(Web.UI.score.log.View(StoresID, name, mobile, type, starttime, endtime));
  }%>