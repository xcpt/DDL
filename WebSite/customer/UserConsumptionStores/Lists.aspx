<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_UserConsumptionStores_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">跨店消费记录管理:</div>
</div>
<div class="Tgnk">
	<div class="Rtss">
	  <div style="float:left;line-height:30px;" id="SearchInputValue">会员卡号：<input name="cardNo" placeholder="输入卡号或刷卡" style="width:170px;" type="text" id="SearchUserConsumptioncardNo" size="30" />&nbsp;&nbsp;会员姓名：<input name="Name" style="width:170px;" type="text" id="SearchUserConsumptionName" size="30" />&nbsp;&nbsp;&nbsp;满 &nbsp;意 &nbsp;度：<select name="satisfactionid" id="SearchUserConsumptionsatisfactionid">
            <option value="">&nbsp;</option>
            <%=Web.UI.Data.Basic.satisfactionid("") %>
        </select>&nbsp;&nbsp;消费日期：<input type="text" name="stime" id="SearchUserConsumptionstime" value="<%=statustime %>" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'SearchUserConsumptionetime\')}'})" size="9"/>-<input type="text" name="etime" id="SearchUserConsumptionetime" value="<%=endtime %>" readonly="readonly" onClick="    WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'SearchUserConsumptionstime\')}'})" size="9"/><br/>服务泳师：<select name="swimteacherid" id="SearchUserConsumptionswimteacherid">
            <option value="">&nbsp;</option>
            <%=Web.UI.Staff.swimteacher.GetOption(StoresID,"") %>
        </select>&nbsp;&nbsp;消费商品：<select name="CommodityID" id="SearchUserConsumptionCommodityID">
          <option value="">&nbsp;</option>
          <%=Web.UI.Sys.Commodity.GetOption(StoresID,"") %>
        </select>&nbsp;&nbsp;婴儿类型：<select name="cycletype" id="SearchUserConsumptioncycletype">
          <option value="">&nbsp;</option>
          <%=Web.UI.Data.Basic.BabyType("") %>
        </select>&nbsp;&nbsp;消费门店：<select name="constoresid" id="constoresid">
          <option value="">&nbsp;</option>
          <%=Web.UI.Sys.stores.GetOutletsOption("") %>
        </select>
	  </div>
	  <div style="float:left;padding-top:35px;"><input type="button" name="button" id="SearchButton" value="搜 索" onclick="$('#UserConsumptionStoresGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <%if (IsAdd)
      { %>
    <div class="gnANk">
        <input type="submit" name="button" id="button" onclick="CreateWindow('customer/UserConsumptionStores/Add.aspx', '结算','customer/UserConsumptionStores/Add.aspx?action=save',250, 50,'UserConsumptionStoresAdd')" icon="icon-addNew" value="结算" />
    </div>
    <%} %>
</div>
<div class="RtbK">
    <table id="UserConsumptionStoresGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    var StoresID="<%=StoresID%>";
    var gridList= $("#UserConsumptionStoresGrid").flexigrid
    (
    {
        url: 'customer/UserConsumptionStores/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50, sortable: false,hide:true, align: 'left' },
            { display: '卡号', name: 'cardNo', width: 50, sortable: false, align: 'left'},
            { display: '卡类型', name: 'cardTypeName', width: 45, sortable: false, align: 'left'},
            { display: '店ID', name: 'StoresID', width: 40, sortable: false, align: 'left',hide:true},
            { display: '店名', name: 'StoresName', width: 40, sortable: false, align: 'left',hide:true},
            { display: '姓名', name: 'Name', width: 80, sortable: false, align: 'left',process:NameFun},
            { display: '小名', name: 'niceName', width: 35, sortable: false, align: 'left'},
            { display: '月龄', name: 'monthAge', width:25, sortable: false, align: 'left'},
            { display: '金额', name: 'price', width:40, sortable: false, align: 'right'},
            { display: '方式', name: 'IsCash', width: 30,hide:true, sortable: false, align: 'right'},
            { display: '消费时间', name: 'addtime', width: 110, sortable: false, align: 'left'},
            { display: '卡次', name: 'surplusnum', width: 25, sortable: false, align: 'left'},
            { display: '类型', name: 'Consumptiontype', width: 25, sortable: false, align: 'left',process:ConsumptiontypeFun},
            { display: '消费商品', name: 'CommodityName', width: 50, sortable: false, align: 'left'},
            { display: '服务泳师', name: 'swimteachername', width:　50, sortable: false, align: 'left'},
            { display: '满意度', name: 'satisfactionid', width: 35, sortable: false, align: 'left',process:satisfactionidFun},
            { display: '体重', name: 'weight', width: 25, sortable: false, align: 'left',process:weightFun},
            { display: '身高', name: 'height', width: 25, sortable: false, align: 'left',process:weightFun},
            { display: '体温', name: 'temperature', width: 25, sortable: false, align: 'left',process:weightFun},
            { display: '泳圈型号', name: 'mamasname', width: 85, sortable: false, align: 'left'},
            { display: '游泳', name: 'timenum', width: 25, sortable: false, align: 'left',process:weightFun},
            { display: '测量', name: 'IsMeasure', width: 25, sortable: false, align: 'center',process:IsMeasureFun},
            { display: '拍照', name: 'IsPhoto', width: 25, sortable: false, align: 'center',process:IsMeasureFun},
            { display: '备注', name: 'content', width: 25,autoSize:true, sortable: false, align: 'left'},
            { display: '管理', name: 'Q', width: 45, sortable: false, align: 'left',process:IsCloseFun }
        ],
        showcheckbox:false,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: 100,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.customer.User_Stores_Consumption.View(StoresID, userid, cardNo, CommodityID, swimteacherid, name, satisfactionid, constoresid, statustime, endtime)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        height: 200
    }
    );
    function IsMeasureFun(value,id)
    {
        if(value=="1")
        {
            return "<font color=blue>需要</font>";
        }else{
            return "不需要";
        }
    }
    function NameFun(value,id,row)
    {
        if(StoresID!=row.cell[3])
        {
            value+=(row.cell[4].length>0?("<font color=red>["+row.cell[4]+"]</font>"):"");
        }
        return value;
    }
    function weightFun(value,id)
    {
        if(value!="0.00" && value!="0")
        {
            return value;
        }
    }
    function ConsumptiontypeFun(value,id,row)
    {
        if(value=="0")
        {
            return "正价";
        }else if(value=="1")
        {
            return "赠送";
        }else if(value=="2")
        {
            return "金额";
        }else if(value=="3")
        {
            return IsCashFun(row.cell[8],id);
        }
    }
    function IsCashFun(value,id)
    {
        var s=<%=Web.UI.Data.Basic.IsCashToJs("IsCash")%>;
        return s["IsCash"+value];
    }
    function satisfactionidFun(value,id)
    {
        var s=<%=Web.UI.Data.Basic.satisfactionidToJs("satisfactionid")%>;
        return s["satisfactionid"+value];
    }
    function TimeFun(value,id)
    {
        return value.split(' ')[0].split('/').join('-');
    }
    function IsCloseFun(value,id)
    {
        switch(value)
        {
            case "0":
                {
                    return "未结算";
                }
            case "1":
                {
                    return "<font color=blue>已结算</font>";
                }
        }
    }
    GridFun(".Rnr", gridList, 202, 2);
    $("#SearchUserConsumptioncycletype").chosen({ disable_search_threshold: 10 ,width:"175px"});
    $("#SearchUserConsumptionswimteacherid").chosen({ disable_search_threshold: 10 ,width:"175px"});
    $("#SearchUserConsumptionsatisfactionid").chosen({ disable_search_threshold: 10 ,width:"175px"});
    $("#SearchUserConsumptionCommodityID").chosen({ width:"175px"});
</script>
<%}
  else
  {
      Response.Write(Web.UI.customer.User_Stores_Consumption.View(StoresID, userid, cardNo, CommodityID, swimteacherid, name, satisfactionid, constoresid, statustime, endtime));
  }%>