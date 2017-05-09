<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_CardType_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">卡类型管理:</div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=IsAdd?"":" style=\"padding-bottom:5px;\"" %>>
	  <div style="float:left" id="SearchInputValue">类型名称：<input name="title" type="text" id="CardTypetitle" size="30" />
          &nbsp;&nbsp;计费类型：<select name="paidmode" id="SearchCardTypepaidmode">
            <option value="">&nbsp;</option>
            <option value="0">按次</option>
            <option value="1">按金额</option>
        </select>&nbsp;&nbsp;业务类型：<select name="businessid" id="SearchCardTypebusinessid">
            <option value="">&nbsp;</option>
            <%=Web.UI.customer.Cardbusinessid.GetOption(StoresID,"") %>
        </select>
	  </div>
	  <div style="float:left"><input type="button" name="button" id="SearchButton" value="搜 索" onclick="$('#CardTypeGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <%if (IsAdd)
      { %>
    <div class="gnANk">
        <input type="submit" name="button" id="button" onclick="CreateWindow('customer/CardType/Add.aspx', '添加卡类型','customer/CardType/Add.aspx?action=save',600, 380,'CardTypeAdd')" icon="icon-addNew" value="添加卡类型" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="CardTypeGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#CardTypeGrid").flexigrid
(
{
    url: 'customer/CardType/Lists.aspx',
    newp:<%=page %>,
    dataType: 'json',
    colModel: [
        { display: '编号', name: 'id', width: 50, sortable: false, align: 'left' },
        { display: '类型名称', name: 'Title', width: 200,autoSize:true, sortable: false, align: 'left'},
        { display: '业务类型', name: 'ywtitle', width: 200, sortable: false, align: 'left'},
        { display: '有效时长', name: 'effectivetime', width: 80, sortable: false, align: 'left'},
        { display: '消费类型', name: 'paidmode', width: 80, sortable: false, align: 'left',process:paidmodeFun},
        { display: '正价次数', name: 'positivenum', width: 80, sortable: false, align: 'right'},
        { display: '赠送次数', name: 'negativenum', width: 80, sortable: false, align: 'right'},
        { display: '金额', name: 'price', width: 80, sortable: false, align: 'right'},
        { display: '折扣', name: 'discount', width: 80, sortable: false, align: 'right'},
        { display: '开卡送积分', name: 'opencardexchange', width: 80, sortable: false, align: 'right'},
        { display: '管理', name: 'Q', width: 60, sortable: false, align: 'left',process:ManagerFun }
    ],
    showcheckbox:false,
    sortname: "id",
    sortorder: "asc",
    usepager: true,
    singleSelect: false,
    useRp: false,
    rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
    autoload:true,
    <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.customer.CardType.View(StoresID, title, paidmode, businessid)); %>,<%}%>
    showTableToggleBtn: false,
    showToggleBtn:false,
    width: 500,
    height: 200
}
    );
    function paidmodeFun(value,id)
    {
        if(value=="0")
        {
            return "按次";
        }else{
            return "按金额";
        }
    }
    function ManagerFun(value,id,row)
    {
        var str=new Array();
        <%if(IsModi){%>
        str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'customer/CardType/Modi.aspx','修改卡类型', 'customer/CardType/Modi.aspx?action=save', 600, 380,'CardTypeModi');return false;\" >修改</a>");
        <%}
        if(IsDel){%>
        str.push("<a href=\"\" onclick=\"GridDel('"+id+"','customer/CardType/Del.aspx');return false;\" >删除</a>");
        <%}%>
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, <%=IsAdd?"167":"140" %>, 2);
    $("#SearchCardTypepaidmode").chosen({ disable_search_threshold: 10 ,width:"80px"});
    $("#SearchCardTypebusinessid").chosen({ disable_search_threshold: 10 ,width:"130px"});
</script>
<%}
  else
  {
      Response.Write(Web.UI.customer.CardType.View(StoresID, title, paidmode, businessid));
  }%>