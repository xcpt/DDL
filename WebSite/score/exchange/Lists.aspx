<%@ Page Language="C#" AutoEventWireup="true" Inherits="score_exchange_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">积分对换:<%=Web.UI.customer.User.GetBanner(StoresID,userid,"score/exchange/Lists.aspx") %></div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=IsAdd?"":" style=\"padding-bottom:5px;\"" %>>
	  <div style="float:left" id="SearchInputValue">会员姓名：<input name="Name" type="text" id="SearchexchangeName" size="30" />&nbsp;&nbsp;兑换内容：<input name="title" type="text" id="Searchexchangetitle" size="30" />
          &nbsp;&nbsp;时间：<input type="text" name="stime" id="Searchexchangestime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'Searchexchangeetime\')}'})" size="9"/>-<input type="text" name="etime" id="Searchexchangeetime" readonly="readonly" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'Searchexchangestime\')}'})" size="9"/>
	  </div>
	  <div style="float:left"><input type="submit" name="button" id="SearchButton" value="搜 索" onclick="$('#exchangeGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <%if (IsAdd)
      { %>
    <div class="gnANk">
        <input type="submit" name="button" id="button" onclick="CreateWindow('score/exchange/Add.aspx?userid=<%=userid%>', '添加积分兑换','score/exchange/Add.aspx?action=save',600, 190,'exchangeAdd')" icon="icon-addNew" value="添加积分兑换" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="exchangeGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#exchangeGrid").flexigrid
    (
    {
        url: 'score/exchange/Lists.aspx?userid=<%=userid%>',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '会员姓名', name: 'name', width: 100, sortable: false, align: 'left'},
            { display: '会员小名', name: 'smallname', width: 100, sortable: false, align: 'left'},
            { display: '性别', name: 'sex', width: 35, sortable: false, align: 'left',process:SexFun},
            { display: '月龄', name: 'age', width: 35, sortable: false, align: 'left'},
            { display: '所属小区', name: 'xq', width: 120, sortable: false, align: 'left'},
            { display: '婴儿类型', name: 'yelx', width: 70, sortable: false, align: 'left',process:BabyTypeFun},
            { display: '兑换时间', name: 'yelx', width: 90, sortable: false, align: 'left',process:TimeFun},
            { display: '消耗积分', name: 'score', width: 60, sortable: false, align: 'left'},
            { display: '兑换内容', name: 'content',autoSize:true, width: 60, sortable: false, align: 'left'},
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
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.score.exchange.View(StoresID, userid, name, title, starttime, endtime)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function BabyTypeFun(value,id)
    {
        var s=<%=Web.UI.Data.Basic.BabyTypeToJs("BabyType")%>;
        return s["BabyType"+value];
    }
    function TimeFun(value,id)
    {
        return value.split(' ')[0].split('/').join('-');
    }
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
    function ManagerFun(value,id)
    {
        var str=new Array();
        <%if(IsDel){%>
        str.push("<a href=\"\" onclick=\"GridDel('"+id+"','score/exchange/Del.aspx');return false;\" title=\"积分将返回\">删除</a>");
        <%}%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, <%=IsAdd?"167":"140" %>, 2);
</script>
<%}
  else
  {
      Response.Write(Web.UI.score.exchange.View(StoresID, userid, name, title, starttime, endtime));
  }%>