<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_Card_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">会员卡管理:<%=Web.UI.customer.User.GetBanner(StoresID,userid,"customer/Card/Lists.aspx") %></div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=(IsAdd && !Base.Fun.fun.pnumeric(userid))?"":" style=\"padding-bottom:40px;\"" %>>
	  <div style="float:left;line-height:30px;" id="SearchInputValue">会员卡号：<input name="cardNo" placeholder="输入卡号或刷卡" type="text" id="SearchCardcardNo" size="30" />&nbsp;&nbsp;会员姓名：<input name="Name" type="text" id="SearchCardName" size="30" />&nbsp;&nbsp;妈妈手机：<input name="mobile" type="text" id="mobile" size="30" />&nbsp;&nbsp;婴儿类型：<select name="cycletype" id="SearchCardcycletype">
          <option value="">&nbsp;</option>
          <%=Web.UI.Data.Basic.BabyType("") %>
        </select><br/>起始卡次：<input name="startnum" type="text" id="SearchCardstartnum" size="30" />&nbsp;&nbsp;截止卡次：<input name="endnum" type="text" id="SearchCardendnum" size="30" />&nbsp;&nbsp;卡类型：<select name="cardtypeid" id="SearchCardcardtypeid">
          <option value="">&nbsp;</option>
          <%=Web.UI.customer.CardType.GetOption(StoresID,"") %>
        </select>&nbsp;&nbsp;卡状态：<select name="cardstatus" id="SearchCardcardstatus">
          <option value="">&nbsp;</option>
          <option value="1">正常</option>
          <option value="-1">停卡</option>
        </select>
	  </div>
	  <div style="float:left;padding-top:35px;"><input type="button" name="button" id="SearchButton" value="搜 索" onclick="$('#CardGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <%if ((IsAdd && !Base.Fun.fun.pnumeric(userid)) && IsPush)
    { %>
    <div class="gnANk">
        <%if (IsAdd && !Base.Fun.fun.pnumeric(userid))
          { %>
        <input type="submit" name="button" id="button" onclick="CreateWindow('customer/Card/Add.aspx', '新增会员卡','customer/Card/Add.aspx?action=save',600,480,'CardAdd')" icon="icon-vcard_add" value="新增会员卡" />
        <%} %>
        <%if(IsPush){ %>
        <input type="button" name="button" id="Button4" value="导出Excel" onclick="AjaxFun('customer/Card/Push.aspx',ReadInputValue('SearchInputValue'),'正在导出，请稍候...');" icon="icon-xls" />
        <%} %>
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="CardGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    var StoresID="<%=StoresID%>";
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#CardGrid").flexigrid
    (
    {
        url: 'customer/Card/Lists.aspx?userid=<%=userid%>',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50,hide:true, sortable: false, align: 'left' },
            { display: '卡号', name: 'cardNo', width: 50, sortable: false, align: 'left'},
            { display: '卡类型', name: 'cardtypeName', width: 40, sortable: false, align: 'left'},
            { display: '店ID', name: 'StoresID', width: 50, sortable: false, align: 'left',hide:true},
            { display: '店名称', name: 'StoresName', width: 50, sortable: false, align: 'left',hide:true},
            { display: '会员', name: 'Name', width: 90, sortable: false, align: 'left',process:NameFun},
            { display: '月龄', name: 'Age', width: 25, sortable: false, align: 'left'},
            { display: '类型', name: 'BabyType', width: 25, sortable: false, align: 'left',process:BabyTypeFun},
            { display: '正价', name: 'positivenum', width: 100,hide:true, sortable: false, align: 'left'},
            { display: '总[正价/赠送]', name: 'negativenum', width: 70, sortable: false, align: 'left',process:negativenumFun},
            { display: '余正价', name: 'surpluspositivenum', width: 100,hide:true, sortable: false, align: 'left'},
            { display: '剩[正价/赠送]', name: 'surplusnegativenum', width: 100, sortable: false, align: 'left',process:surplusnegativenumFun},
            { display: '其它余正价', name: 'surpluspositivenum', width: 100,hide:true, sortable: false, align: 'left'},
            { display: '其它余赠送', name: 'surpluspositivenum', width: 100,hide:true, sortable: false, align: 'left'},
            { display: '金额', name: 'price', width: 50, sortable: false, align: 'right'},
            { display: '生效时间', name: 'starttime', width: 60, sortable: false, align: 'left',process:TimeFun},
            { display: '失效时间', name: 'endtime', width: 60, sortable: false, align: 'left',process:TimeFun},
            { display: '有效期', name: 'yxq', width: 40, sortable: false, align: 'right',process:yxqFun},
            { display: '状态', name: 'cardstatus', width: 35, sortable: false, align: 'center',process:cardstatusFun},
            { display: '停卡至', name: 'stoptime', width: 60,hide:true, sortable: false, align: 'left',process:TimeFun},
            { display: '备注', name: 'content', width: 50,autoSize:true, sortable: false, align: 'left'},
            { display: '管理', name: 'Q', width: 130, sortable: false, align: 'left',process:ManagerFun }
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.customer.Card.View(StoresID, cardNo, userid, name, cardtypeid, cycletype, startnum, endnum, cardstatus, Mobile)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function NameFun(value,id,row)
    {
        if(row.cell[3]!=StoresID)
        {
            value+="<font color=red>{"+row.cell[4]+"}</font>";
        }
        return value;
    }
    function cardstatusFun(value,id)
    {
        if(value=="1")
        {
            return "正常";
        }else{
            return "<font color=red>停卡</font>";
        }
    }
    function yxqFun(value,id)
    {
        if(value.indexOf("-")!=-1)
        {
            return "<font color=red>"+value+"</font>";
        }
        return value;
    }
    function TimeFun(value,id)
    {
        if(value.length>0)
        {
            value=value.split(' ')[0].replace("/","-").replace("/","-");
        }
        return value;
    }
    function surplusnegativenumFun(value,id,row)
    {
        var op=parseInt(row.cell[12]);
        if(isNaN(op))
        {
            op=0;
        }
        var on=parseInt(row.cell[13]);
        if(isNaN(on))
        {
            on=0;
        }
        return (parseInt(row.cell[10])+parseInt(value))+ "["+row.cell[10]+"/"+value+"]"+((op+on)>0?"<font color=red>{"+op+"/"+on+"}</font>":"");
    }
    function negativenumFun(value,id,row)
    {
        return (parseInt(row.cell[8])+parseInt(value))+"["+row.cell[8]+"/"+value+"]";
    }
    function BabyTypeFun(value,id)
    {
        var s=<%=Web.UI.Data.Basic.BabyTypeToJs("BabyType")%>;
        return s["BabyType"+value];
    }
    function ManagerFun(userid,id,row)
    {
        var str=new Array();
        <%if(IsModi){%>
        if(row.cell[18]==-1)
        {
            str.push("<a href='#' onclick=\"AjaxFun('customer/Card/Modi_Open.aspx', 'id="+id+"', '正在重开卡', '');return false;\" >重开卡</a>");
        }else{
            str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'customer/Card/Modi_Change.aspx','卡项变更', 'customer/Card/Modi_Change.aspx?action=save', 600, 280,'CardModi');return false;\" >变更</a>");
            str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'customer/Card/Modi_Cardrenewal.aspx','续卡', 'customer/Card/Modi_Cardrenewal.aspx?action=save', 500, 350,'CardModi');return false;\" >续卡</a>");
            str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'customer/Card/Modi_Stop.aspx','停卡', 'customer/Card/Modi_Stop.aspx?action=save', 300, 95,'CardModi');return false;\" >停卡</a>");
            str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'customer/Card/Modi_Replace.aspx','换卡', 'customer/Card/Modi_Replace.aspx?action=save', 400, 140,'CardModi');return false;\" >换卡</a>");
        }
        <%}%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, <%=(IsAdd && !Base.Fun.fun.pnumeric(userid))?"202":"169" %>, 2);
    $("#SearchCardcardtypeid").chosen({ disable_search_threshold: 10 ,width:"130px"});
    $("#SearchCardcycletype").chosen({ disable_search_threshold: 10 , width:"80px"});
    $("#SearchCardcardstatus").chosen({ disable_search_threshold: 10 , width:"70px"});
</script>
<%}
  else
  {
      Response.Write(Web.UI.customer.Card.View(StoresID, cardNo, userid, name, cardtypeid, cycletype, startnum, endnum, cardstatus, Mobile));
  }%>