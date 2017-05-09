<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_Userappointment_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">用户预约管理:<%=Web.UI.customer.User.GetBanner(StoresID,userid,"customer/Userappointment/Lists.aspx") %></div>
</div>
<div class="Tgnk">
	<div class="Rtss">
	  <div style="float:left;line-height:30px;" id="SearchInputValue">会员卡号：<input name="cardNo" placeholder="输入卡号或刷卡" style="width:170px;" type="text" id="SearchUserappointmentcardNo" size="30" />&nbsp;&nbsp;会员姓名：<input name="Name" style="width:170px;" type="text" id="SearchUserappointmentName" size="30" />&nbsp;&nbsp;预约日期：<input type="text" name="stime" id="SearchUserappointmentstime" readonly="readonly"  value="<%=statustime %>" onClick="WdatePicker({skin:'ext'})" size="9"/>-<input type="text" name="etime" id="SearchUserappointmentetime" readonly="readonly" value="<%=endtime %>" onClick="WdatePicker({skin:'ext'})" size="9"/><br/>
          妈妈手机：<input name="Mobile" style="width:170px;" type="text" id="Mobile" size="30" />&nbsp;&nbsp;预约泳师：<select name="swimteacherid" id="SearchUserappointmentswimteacherid">
            <option value="">&nbsp;</option>
            <%=Web.UI.Staff.swimteacher.GetOption(StoresID,"") %>
        </select>&nbsp;&nbsp;预约状态：<select name="status" id="SearchUserappointmentstatus">
          <option value="">&nbsp;</option>
          <option value="0">预约中</option>
          <option value="1">已完成</option>
          <option value="2">已取消</option>
        </select>&nbsp;&nbsp;婴儿类型：<select name="cycletype" id="SearchUserappointmentcycletype">
          <option value="">&nbsp;</option>
          <%=Web.UI.Data.Basic.BabyType(cycletype) %>
        </select>
	  </div>
	  <div style="float:left;padding-top:35px;"><input type="button" name="button" id="SearchButton" value="搜 索" onclick="$('#UserappointmentGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <div class="gnANk">
        <%if (IsAdd)
      { %>
        <input type="submit" name="button" id="button" onclick="CreateWindow('customer/Userappointment/Add.aspx?id=<%=userid%>', '添加预约','customer/Userappointment/Add.aspx?action=save',600, 445,'UserappointmentAdd')" icon="icon-addNew" value="添加预约" />
        <%} %>
        <%=str.ToString() %>
    </div>
</div>
<div class="RtbK">
    <table id="UserappointmentGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    var StoresID="<%=StoresID%>";
    SearchEnter("SearchButton","SearchInputValue");
    var gridList= $("#UserappointmentGrid").flexigrid
(
{
    url: 'customer/Userappointment/Lists.aspx',
    newp:<%=page %>,
    dataType: 'json',
    colModel: [
        { display: '编号', name: 'id', width: 50, sortable: false, align: 'left',hide:true },
        { display: '照片', name: 'userFace', width: 25,hide:true, sortable: false, align: 'left',process:userFaceFun},
        { display: '卡号', name: 'cardNo', width: 50, sortable: false, align: 'left',process:cardNoFun},
        { display: '标识', name: 'IsTop', width: 100,hide:true, sortable: false, align: 'left'},
        { display: '店ID', name: 'StoresID', width: 100, sortable: false, align: 'left',hide:true},
        { display: '店名', name: 'StoresName', width: 100, sortable: false, align: 'left',hide:true},
        { display: '姓名', name: 'Name', width: 100, sortable: false, align: 'left',process:NameFun},
        { display: '小名', name: 'niceName', width: 40, sortable: false, align: 'left'},
        { display: '卡类型', name: 'cardTypeName', width: 45, sortable: false, align: 'left'},
        { display: '婴儿类型', name: 'cycletype', width: 50, sortable: false, align: 'left',process:BabyTypeFun},
        { display: '月龄', name: 'age', width: 25, sortable: false, align: 'left'},
        { display: '预约日期', name: 'datetimetime', width: 60,hide:true, sortable: false, align: 'left'},
        { display: '预约日期', name: 'datetime', width: 60,hide:true, sortable: false, align: 'left',process:TimeFun},
        { display: '预约时间', name: 'datetimehouer', width: 50,hide:true, sortable: false, align: 'left'},
        { display: '预约时间', name: 'datetimeminute', width: 50, sortable: false, align: 'left',process:datetimeminuteTimeFun},
        { display: '消费时间', name: 'updatetime', width:　50, sortable: false, align: 'left',process:updatetimeFun},
        { display: '预约状态', name: 'status', width: 50,hide:true, sortable: false, align: 'left',process:statusFun},
        { display: '预约泳师', name: 'swimteachername', width: 50, sortable: false, align: 'left'},
        { display: '泳圈型号', name: 'mamasname', width: 85, sortable: false, align: 'left'},
        { display: '操作时间', name: 'addtime', width: 110, sortable: false, align: 'left'},
        { display: '预约方式', name: 'source', width: 50, sortable: false, align: 'left',process:sourceFun},
        { display: '备注', name: 'content', width: 100,autoSize:true, sortable: false, align: 'left'},
        { display: '管理', name: 'Q', width: 90, sortable: false, align: 'left',process:ManagerFun }
    ],
    showcheckbox:false,
    sortname: "id",
    sortorder: "asc",
    usepager: true,
    singleSelect: false,
    useRp: false,
    rp: 100,
    autoload:true,
    <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.customer.Userappointment.View(StoresID, userid, cardNo, name, cycletype, swimteacherid, status, statustime, endtime, datetimehouer, datetimeminute, Mobile)); %>,<%}%>
    showTableToggleBtn: false,
    showToggleBtn:false,
    showOkFun:function(obj){obj.find("a.jTip").JT_init();},
    width: 500,
    height: 200
}
    );
    function statusFun(value,id)
    {
        if(value=="0")
        {
            return "<font color=blue>预约中</font>";
        }else if(value=="1")
        {
            return "已完成";
        }else if(value=="2")
        {
            return "<font color=red>已取消</font>";
        }
    }
    function userFaceFun(value,id)
    {
        if(value.length>10)
        {
            return "<img src=images/icon/picture.png width=16 height=16 style=\"padding:5px;\" align=\"absmiddle\" alt=\"" + value + "?width=200&height=200\" class=\"jTip\" name=\"会员照片\" />"
        }
    }
    function NameFun(value,id,row)
    {
        if(row.cell[1].length>10)
        {
            value="<a href=\"\" onclick=\"return false;\" title=\"" + row.cell[1] + "?width=200&height=200\" class=\"jTip\">"+value+"</a>";
        }
        if(StoresID!=row.cell[4])
        {
            value+="<font color=red>["+row.cell[5]+"]</font>";
        }
        return value;
    }
    function cardNoFun(value,id,row)
    {
        if(row.cell[3]=="1")
        {
            return "<span style=\"width:78px;height:22px;background-color:red;display:block;color:#fff;\">&nbsp;"+value+"</span>"
        }else{
            return value;
        }
    }
    function BabyTypeFun(value,id)
    {
        var s=<%=Web.UI.Data.Basic.BabyTypeToJs("BabyType")%>;
        return s["BabyType"+value];
    }
    function sourceFun(value,id)
    {
        var s=<%=Web.UI.Data.Basic.UserappointmentToJs("Userappointment")%>;
        return s["Userappointment"+value];
    }
    function TimeFun(value,id,row)
    {
        if(row.cell[16]=="0")
        {
            if(row.cell[11]=="0")
            {
                return "<font color=blue>"+value.split(' ')[0].split('/').join('-')+"</font>";
            }else if(row.cell[11].indexOf("-")!=-1){
                return value.split(' ')[0].split('/').join('-');
            }else{
                return "<font color=red>过期"+ row.cell[9]+"天</font>";
            }
        }else{
            return value.split(' ')[0].split('/').join('-');
        }
    }
    function datetimeminuteTimeFun(value,id,row)
    {
        return ("0"+row.cell[13]).Right(2)+":"+("0"+value).Right(2);
    }
    function updatetimeFun(value,id)
    {
        if(value.length>0)
        {
            return value.split(' ')[1];
        }else{
            return "&nbsp;";
        }
    }
    function ManagerFun(value,id,row)
    {
        var str=new Array();
        if(row.cell[16]=="0")
        {
            <%if(IsModi){%>
            str.push("<a href=\"\" onclick=\"CreateWindow('customer/Userappointment/Modi_Info.aspx?id="+id+"', '修改预约','customer/Userappointment/Modi_Info.aspx?action=save',600, 445,'UserappointmentModi');return false;\">修改</a>");
            <%}
            if(UserConsumptionIsAdd){%>
            str.push("<a href=\"\" onclick=\"CreateWindow('customer/UserConsumption/Add.aspx?appointmentid="+id+"', '结算预约','customer/UserConsumption/Add.aspx?action=save',600, 480,'UserConsumptionAdd');return false;\" >结算</a>");
            <%}%>
            str.push("<a href=\"\" onclick=\"GridDel('"+id+"','customer/Userappointment/Del.aspx',null,null,'确定取消当前预约吗？','正在取消...');return false;\" >取消</a>");
        }else if(row.cell[16]=="2")
        {
            <%if(IsDel){%>
            str.push("<a href=\"\" onclick=\"GridDel('"+id+"','customer/Userappointment/Del.aspx');return false;\" >删除</a>");
            <%}%>
        }else{
            <%if(IsDel){%>
            str.push("<a href=\"\" onclick=\"GridDel('"+id+"','customer/Userappointment/Del.aspx');return false;\" >删除</a>");
            <%}%>
            setTimeout(function(){
                $("#row"+id+" td").css({"background-color":"#b6f4ff"});
            },10);
        }
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, 202, 2);
    $("#SearchUserappointmentcycletype").chosen({ disable_search_threshold: 10 ,width:"70px"});
    $("#SearchUserappointmentswimteacherid").chosen({ disable_search_threshold: 10 ,width:"90px"});
    $("#SearchUserappointmentstatus").chosen({ disable_search_threshold: 10 ,width:"80px"});
</script>
<%}
  else
  {
      Response.Write(Web.UI.customer.Userappointment.View(StoresID, userid, cardNo, name, cycletype, swimteacherid, status, statustime, endtime, datetimehouer, datetimeminute, Mobile));
  }%>