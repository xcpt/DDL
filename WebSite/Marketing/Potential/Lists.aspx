<%@ Page Language="C#" AutoEventWireup="true" Inherits="Marketing_Potential_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">潜在客户管理:</div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=IsAdd?"":" style=\"padding-bottom:5px;\"" %>>
	  <div style="float:left;line-height:30px;" id="SearchInputValue">会员姓名：<input name="name" type="text" id="SearchPotentialname" size="30" />&nbsp;&nbsp;会员小名：<input name="nickname" type="text" id="SearchPotentialnickname" size="30" />&nbsp;&nbsp;所属小区：<select name="communityid" id="SearchPotentialcommunityid" style="width:200px;">
              <option value=""></option>
                <%=Web.UI.Sys.community.GetOption(StoresID,"") %>
            </select><br/>联系手机：<input name="mobile" type="text" id="SearchPotentialmobile" size="30" />&nbsp;&nbsp;婴儿类型：<select name="cycletype" id="SearchPotentialcycletype" style="width:200px;">
              <option value=""></option>
                <%=Web.UI.Data.Basic.BabyType("") %>
            </select>&nbsp;&nbsp;回访结果：<select name="ReturnresultID" id="SearchPotentialReturnresultID" style="width:200px;">
              <option value=""></option>
                <%=Web.UI.Data.Basic.ReturnresultID("") %>
            </select><br/>月龄范围：<input type="text" name="statusmonthnum" id="SearchPotentialstatusmonthnum" size="9"/>-<input type="text" name="endmonthnum" id="SearchPotentialendmonthnum" size="9"/></div>
	  <div style="float:left;padding-top:60px;"><input type="button" name="button" id="SearchButton" value="搜 索" onclick="$('#PotentialGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <%if (IsAdd)
      { %>
    <div class="gnANk">
        <input type="button" name="button" id="Submit7" onclick="GridModiy($('#PotentialGrid'), 'Marketing/Visit/Add.aspx', '添加回访记录','Marketing/Visit/Add.aspx?action=save',500, 290,'VisitAdd')" icon="icon-addNew" value="增加回访记录" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="PotentialGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#PotentialGrid").flexigrid
    (
    {
        url: 'Marketing/Potential/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
            { display: '姓名', name: 'name', width: 40, sortable: false, align: 'left'},
            { display: '小名', name: 'nickname', width: 35, sortable: false, align: 'left'},
            { display: '性别', name: 'sex', width: 25, sortable: false, align: 'left',process:SexFun},
            { display: '月龄', name: 'age', width: 25, sortable: false, align: 'left'},
            { display: '家长', name: 'mobile', width: 40, sortable: false, align: 'left'},
            { display: '手机', name: 'mobile', width: 80, sortable: false, align: 'left',process:MobileSendFun},
            { display: '所属小区', name: 'name', width: 70, sortable: false, align: 'left'},
            { display: '类型', name: 'BabyType', width: 25, sortable: false, align: 'left',process:BabyTypeFun},
            { display: '消费时间', name: 'lasttime', width: 110, sortable: false, align: 'left'},
            { display: '回访次数', name: 'num', width: 50, sortable: false, align: 'left'},
            { display: '状态', name: 'state', width: 50, sortable: false, align: 'left',process:stateFun},
            { display: '回访时间', name: 'addtime', width: 110, sortable: false, align: 'left'},
            { display: '回访员工', name: 'member', width: 50, sortable: false, align: 'left'},
            { display: '回访结果', name: 'name', width: 50, sortable: false, align: 'left',process:ReturnresultIDFun},
            { display: '回访说明', name: 'name', width: 50,autoSize:true, sortable: false, align: 'left'},
            { display: '操作管理', name: 'Q', width: 50, sortable: false, align: 'left',process:ManagerFun }
        ],
        showcheckbox:true,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.customer.User.View_Potential(StoresID, name, nickname, communityid, mobile, cycletype, ReturnresultID, statusmonthnum, endmonthnum)); %>,<%}%>
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
    function ReturnresultIDFun(value,id)
    {
        var s=<%=Web.UI.Data.Basic.ReturnresultIDToJs("ReturnresultID")%>;
        return s["ReturnresultID"+value];
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
    function ManagerFun(value,id)
    {
        var str=new Array();
        <%if(IsVisitIsAdd){%>
        str.push("<a href=\"\" onclick=\"AjaxFun('Marketing/Visit/Lists.aspx','action=view&userid="+id+"',' ','.Rnr');return false;\" >回访记录</a>");
        <%}%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, <%=IsAdd?"232":"205" %>, 2);
    $("#SearchPotentialcommunityid").chosen({ width:"175px"});
    $("#SearchPotentialcycletype").chosen({disable_search_threshold: 10 , width:"175px"});
    $("#SearchPotentialReturnresultID").chosen({ disable_search_threshold: 10 ,width:"175px"});
</script>
<%}
  else
  {
      Response.Write(Web.UI.customer.User.View_Potential(StoresID, name, nickname, communityid, mobile, cycletype, ReturnresultID, statusmonthnum, endmonthnum));
  }%>