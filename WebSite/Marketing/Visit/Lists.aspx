<%@ Page Language="C#" AutoEventWireup="true" Inherits="Marketing_Visit_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">回访记录管理:</div>
</div>
<div class="Tgnk">
	<div class="Rtss" style="padding-bottom:40px;">
	  <div style="float:left;line-height:30px;" id="SearchInputValue">会员姓名：<input name="name" type="text" id="SearchVisitname" size="30" />&nbsp;&nbsp;回访员工：<select name="memberid" id="SearchVisitmemberid" style="width:200px;">
             <option value="">请选择</option>
                <%=Web.UI.Staff.member.GetOption(StoresID,"") %>
            </select>&nbsp;&nbsp;回访结果：<select name="ReturnresultID" id="SearchVisitReturnresultID" style="width:200px;">
              <option value="">请选择</option>
                <%=Web.UI.Data.Basic.ReturnresultID("") %>
            </select><br/>是否放弃：<select name="IsGiveup" id="SearchVisitIsGiveup" style="width:200px;">
                <option value="">请选择</option>
                <%=Web.UI.Data.Basic.IsGiveup("") %>
            </select>&nbsp;&nbsp;回访日期：<input type="text" name="stime" id="Searchexpiredstime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'Searchexpiredetime\')}'})" size="9"/>-<input type="text" name="etime" id="Searchexpiredetime" readonly="readonly" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'Searchexpiredstime\')}'})" size="9"/></div>
	  <div style="float:left;padding-top:35px;"><input type="button" name="button" id="SearchButton" value="搜 索" onclick="$('#VisitGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
        <%if (IsAdd && Base.Fun.fun.pnumeric(userid))
      { %>
    <div class="gnANk">
        <input type="button" name="button" id="Submit7" onclick="GridModiy('<%=userid%>', 'Marketing/Visit/Add.aspx', '添加回访记录','Marketing/Visit/Add.aspx?action=save',500, 290,'VisitAdd')" icon="icon-addNew" value="增加回访记录" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="VisitGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#VisitGrid").flexigrid
    (
    {
        url: 'Marketing/Visit/Lists.aspx?userid=<%=userid%>',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '会员姓名', name: 'name', width: 50, sortable: false, align: 'left'},
            { display: '家长手机', name: 'mobile', width: 80, sortable: false, align: 'left',process:MobileSendFun},
            { display: '性别', name: 'sex', width: 25, sortable: false, align: 'left',process:SexFun},
            { display: '月龄', name: 'age', width: 25, sortable: false, align: 'left'},
            { display: '所属小区', name: 'name', width: 100, sortable: false, align: 'left'},
            { display: '婴儿类型', name: 'BabyType', width: 50, sortable: false, align: 'left',process:BabyTypeFun},
            { display: '回访时间', name: 'addtime', width: 130, sortable: false, align: 'left'},
            { display: '回访员工', name: 'member', width: 50, sortable: false, align: 'left'},
            { display: '回访次数', name: 'num', width: 50, sortable: false, align: 'left'},
            { display: '回访结果', name: 'ReturnresultID', width: 50, sortable: false, align: 'left',process:ReturnresultIDFun},
            { display: '状态', name: 'state', width: 50, sortable: false, align: 'left',process:stateFun},
            { display: '回访说明', name: 'name', width: 100,autoSize:true, sortable: false, align: 'left'},
            { display: '操作', name: 'Q', width: 30, sortable: false, align: 'left',process:ManagerFun }
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.Marketing.Visit.View(StoresID, userid, name, ReturnresultID, IsGiveup, memberid, starttime, endtime)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function MobileSendFun(value,id)
    {
        <%if(MessageLogAdd){%>
        return "<a href=\"\" onclick=\"CreateWindow('Mobile/MessageLog/Add.aspx?mobile="+value+"', '发送消息','Mobile/MessageLog/Add.aspx?action=save',600, 400,'MessageLogAdd');return false;\" title=\"发送手机消息\">"+value+"</a>";
        <%}else{%>
        return value;
        <%}%>
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
    function stateFun(value,id)
    {
        var s=<%=Web.UI.Data.Basic.IsGiveupToJs("IsGiveup")%>;
        return s["IsGiveup"+value];
    }
    function BabyTypeFun(value,id)
    {
        var s=<%=Web.UI.Data.Basic.BabyTypeToJs("BabyType")%>;
        return s["BabyType"+value];
    }
    function ReturnresultIDFun(value,id)
    {
        var s=<%=Web.UI.Data.Basic.ReturnresultIDToJs("ReturnresultID")%>;
        return s["ReturnresultID"+value];
    }
    function ManagerFun(value,id)
    {
        var str=new Array();
        str.push("<a href=\"\" onclick=\"GridDel('"+id+"','Marketing/Visit/Del.aspx');return false;\" >删除</a>");
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList,<%=IsAdd&& Base.Fun.fun.pnumeric(userid)?"205":"170" %>, 2);
    $("#SearchVisitmemberid").chosen({ width:"175px"});
    $("#SearchVisitReturnresultID").chosen({disable_search_threshold: 10 , width:"175px"});
    $("#SearchVisitIsGiveup").chosen({ disable_search_threshold: 10 ,width:"175px"});
</script>
<%}
  else
  {
      Response.Write(Web.UI.Marketing.Visit.View(StoresID, userid, name, ReturnresultID, IsGiveup, memberid, starttime, endtime));
  }%>