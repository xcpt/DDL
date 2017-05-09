<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_User_Lists" %>
<%if (action == "view")
  { %>
<div class="Rtop">
    <div class="RlmM">会员管理:</div>
</div>
<div class="Tgnk">
	<div class="Rtss"<%=IsAdd?"":" style=\"padding-bottom:5px;\"" %>>
	  <div style="float:left;line-height:30px;" id="SearchInputValue">会员卡号：<input name="cardNo" placeholder="输入卡号或刷卡" type="text" id="SearchCardcardNo" size="30" />&nbsp;&nbsp;会员姓名：<input name="Name" type="text" id="SearchCardName" size="30" />&nbsp;&nbsp;卡类型：<select name="cardtypeid" id="SearchCardcardtypeid">
          <option value="">&nbsp;</option>
          <%=Web.UI.customer.CardType.GetOption(StoresID,"") %>
        </select>&nbsp;&nbsp;婴儿类型：<select name="cycletype" id="SearchCardcycletype">
          <option value="">&nbsp;</option>
          <%=Web.UI.Data.Basic.BabyType("") %>
        </select><br/>妈妈手机：<input name="mobile" type="text" id="SearchCardmobile" size="30" />&nbsp;&nbsp;会员小名：<input name="nickname" type="text" id="SearchCardnickname" size="30" />&nbsp;&nbsp;卡状态：<select name="cardstatus" id="SearchCardcardstatus">
          <option value="">&nbsp;</option>
          <option value="1">正常</option>
          <option value="-1">停卡</option>
        </select>&nbsp;&nbsp;所在小区：<select name="communityid" id="SearchCardnicknamecommunityid" style="width:200px;">
                <option value=""></option>
                <%=Web.UI.Sys.community.GetOption(StoresID,"") %>
            </select><br/>剩余卡次：<input name="startnum" type="text" id="SearchCardstartnum" size="5" />-<input name="endnum" type="text" id="SearchCardendnum" size="5" />&nbsp;&nbsp;婴儿月龄：<input name="statusmonthnum" type="text" id="SearchCardstatusmonthnum" size="5" />-<input name="endmonthnum" type="text" id="SearchCardendmonthnum" size="5" />&nbsp;&nbsp;
          婴儿日龄：<input name="statusdaynum" type="text" id="SearchCardstatusdaynum" size="5" />-<input name="enddaynum" type="text" id="SearchCardenddaynum" size="5" />&nbsp;&nbsp;
          婴儿生日：<input type="text" name="stime" id="SearchCardLogstime" readonly="readonly" onClick="WdatePicker({skin:'ext',maxDate:'#F{$dp.$D(\'SearchCardLogetime\')}'})" size="9"/>-<input type="text" name="etime" id="SearchCardLogetime" readonly="readonly" onClick="WdatePicker({skin:'ext',minDate:'#F{$dp.$D(\'SearchCardLogstime\')}'})" size="9"/>
	  </div>
	  <div style="float:left;padding-top:60px;"><input type="button" name="button" id="SearchButton" value="搜 索" onclick="$('#UserGrid').flexReload(ReadInputValue('SearchInputValue'));" icon="icon-zoom" /></div>
	</div>
    <div class="gnANk">
       <%if (IsAdd)
        { %>
        <input type="button" name="button" id="button" onclick="CreateWindow('customer/User/Add.aspx', '新增会员','customer/User/Add.aspx?action=save',700, 590,'UserAdd')" icon="icon-user_add" value="新增会员" />
        <%}
        if(CardIsAdd){ %>
        <input type="button" name="button" id="Submit2" onclick="GridModiy($('#UserGrid'), 'customer/Card/Add.aspx?IsAddCard=auto','为会员建卡', 'customer/Card/Add.aspx?winlist=user&action=save', 600, 520,'CardAdd');" icon="icon-vcard_add" value="建卡" />
        <%} %>
        <%if(UserappointmentIsAdd){ %>
         <input type="button" name="button" id="Submit8" onclick="GridModiy($('#UserGrid'),'customer/Userappointment/Add.aspx', '添加预约','customer/Userappointment/Add.aspx?action=save',600, 400,'UserappointmentAdd')" icon="icon-time_add" value="预约" />
        <%} %>
        <%if(UserConsumptionIsAdd){ %>
        <input type="submit" name="button" id="Submit3" onclick="GridModiy($('#UserGrid'),'customer/UserConsumption/Add.aspx', '新增消费','customer/UserConsumption/Add.aspx?action=save',600, 480,'UserConsumptionAdd')" icon="icon-addNew" value="消费" />
        <%} %>
        <%if(IsModi){ %>
        <input type="button" name="button" id="Submit5" onclick="GridProperty($('#UserGrid'), 'customer/User/Modi_Pass.aspx');" icon="icon-reload" value="重置密码" />
        <%} %>
        <%if(scoreIsAdd){ %>
        <input type="button" name="button" id="Submit7" onclick="GridModiy($('#UserGrid'), 'score/log/Add.aspx', '添加会员积分','score/log/Add.aspx?winlist=user&action=save',600, 200,'logAdd')" icon="icon-addNew" value="增加积分" />
        <%} %>
        <%if (exchangeIsAdd)
          { %>
        <input type="button" name="button" id="Submit6" onclick="GridModiy($('#UserGrid'), 'score/exchange/Add.aspx', '积分兑换','score/exchange/Add.aspx?winlist=user&action=save',600, 190,'exchangeAdd')" icon="icon-addNew" value="积分兑换" />
        <%} %>
        <%if (albumIsAdd)
          { %>
        <input type="button" name="button" id="Button1" onclick="GridModiy($('#UserGrid'), 'baby/album/Add.aspx', '成长相册','baby/album/Add.aspx?winlist=user&action=save',600, 140,'albumAdd')" icon="icon-picture_add" value="上传照片" />
        <%} %>
        <input type="button" name="button" id="Button2" onclick="GridModiy($('#UserGrid'), 'customer/User/Lists_Chart.aspx?action=height', '身高成长曲线',null,700, 400)" icon="icon-chart_curve" value="身高曲线" />
        <input type="button" name="button" id="Button3" onclick="GridModiy($('#UserGrid'), 'customer/User/Lists_Chart.aspx?action=weight', '体重成长曲线',null,700, 400)" icon="icon-chart_curve" value="体重曲线" />
        <%if(IsPush){ %>
        <input type="button" name="button" id="Button4" value="导出Excel" onclick="AjaxFun('customer/User/Push.aspx',ReadInputValue('SearchInputValue'),'正在导出，请稍候...');" icon="icon-xls" />
        <%} %>
    </div>
</div>
<div class="RtbK">
    <table id="UserGrid" style="display: none;">
    </table>
</div>
<script type="text/javascript">
    SearchEnter("SearchButton","SearchInputValue");
    var StoresID=<%=StoresID%>;
    var gridList= $("#UserGrid").flexigrid
    (
    {
        url: 'customer/User/Lists.aspx',
        newp:<%=page %>,
        dataType: 'json',
        colModel: [
            { display: '编号', name: 'id', width: 50,hide:true, sortable: false, align: 'left' },
            { display: '照片', name: 'userFace', width: 25, sortable: false, align: 'left',process:userFaceFun},
            { display: '卡号', name: 'cardNo', width: 50, sortable: false, align: 'left'},
            { display: '注册StoresID', name: 'StoresID', width: 50,hide:true, sortable: false, align: 'left' },
            { display: '注册StoresName', name: 'StoresName', width: 50,hide:true, sortable: false, align: 'left' },
            { display: '姓名', name: 'Name', width: 60, sortable: false, align: 'left',process:StoresNameFun},
            { display: '小名', name: 'niceName', width: 30, sortable: false, align: 'left'},
            { display: '性别', name: 'sex', width: 25, sortable: false, align: 'left',process:SexFun},
            { display: '月龄', name: 'age', width: 25, sortable: false, align: 'left'},
            { display: '家长', name: 'parentName', width: 40, sortable: false, align: 'left'},
            { display: '妈妈手机', name: 'mobile', width: 80, sortable: false, align: 'left',process:MobileSendFun},
            { display: '所属小区', name: 'communityName', width: 70, sortable: false, align: 'left'},
            { display: '类型', name: 'BabyType', width: 25, sortable: false, align: 'left',process:BabyTypeFun},
            { display: '积分', name: 'scorenum', width: 25, sortable: false, align: 'left'},
            { display: '有效期', name: 'yxq', width: 35, sortable: false, align: 'right',process:yxqFun},
            { display: '测量', name: 'IsMeasure', width: 35, sortable: false, align: 'center',process:IsMeasureFun},
            { display: '拍照', name: 'IsPhoto', width: 35, sortable: false, align: 'center',process:IsMeasureFun},
            { display: '建档时间', name: 'addtime', width: 115, sortable: false, align: 'left',process:TimeFun},
            { display: '备注', name: 'content', width: 35,autoSize:true, sortable: false, align: 'left'},
            { display: '管理', name: 'Q', width: 230, sortable: false, align: 'left',process:ManagerFun }
        ],
        showcheckbox:true,
        sortname: "id",
        sortorder: "asc",
        usepager: true,
        singleSelect: false,
        useRp: false,
        rp: <%=Web.UI.Sys.SiteInfo.GetPageSize()%>,
        autoload:true,
        <%if(page=="1"){%>PageOneValue:<%Response.Write(Web.UI.customer.User.View(StoresID, cardNo, name, communityid, mobile, nickname, cycletype, statusmonthnum, endmonthnum, statusdaynum, enddaynum, statusbirthday, endbirthday, loginnum, startnum, endnum, cardtypeid, cardstatus)); %>,<%}%>
        showTableToggleBtn: false,
        showToggleBtn:false,
        width: 500,
        showOkFun:function(obj){obj.find("img.jTip").JT_init();},
        height: 200
    }
    );
    function StoresNameFun(value,id,row)
    {
        if(StoresID!=row.cell[3])
        {
            value+="<font color=red>{"+row.cell[4]+"}</font>";
        }
        return value;
    }
    function MobileSendFun(value,id)
    {
        <%if(MessageLogAdd){%>
        return "<a href=\"\" onclick=\"CreateWindow('Mobile/MessageLog/Add.aspx?mobile="+value+"', '发送消息','Mobile/MessageLog/Add.aspx?action=save',600, 400,'MessageLogAdd');return false;\" title=\"发送手机消息\">"+value+"</a>";
        <%}else{%>
        return value;
        <%}%>
    }
    function userFaceFun(value,id)
    {
        if(value.length>10)
        {
            return "<img src=images/icon/picture.png width=16 height=16 style=\"padding:5px;\" align=\"absmiddle\" alt=\"" + value + "?width=200&height=200\" class=\"jTip\" name=\"会员照片\" />"
        }
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
    function IsMeasureFun(value,id)
    {
        if(value=="1")
        {
            return "<font color=blue>需要</font>";
        }else{
            return "不需要";
        }
    }
    function cardstatusFun(value,id)
    {
        if(value=="1")
        {
            return "正常";
        }else{
            return "停卡";
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
            value=value.replace("/","-").replace("/","-");
        }
        return value;
    }
    function BabyTypeFun(value,id)
    {
        var s=<%=Web.UI.Data.Basic.BabyTypeToJs("BabyType")%>;
        return s["BabyType"+value];
    }
    function ManagerFun(value,id,row)
    {
        var str=new Array();
        str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'customer/User/Lists_View.aspx','查看会员信息', null, 700, 450);return false;\" >查看</a>");
        <%if(IsModi){%>
        str.push("<a href='#' onclick=\"GridModiy('"+id+"', 'customer/User/Modi.aspx','修改会员信息', 'customer/User/Modi.aspx?action=save', 700, 590,'UserModi');return false;\" >修改</a>");
        <%}
          if(CardIsList){%>
        if(row.cell[2].length>0)
        {
            str.push("<a href=\"\" onclick=\"AjaxFun('customer/Card/Lists.aspx', 'action=view&userid="+id+"', ' ', '.Rnr');return false;\">查卡</a>");
        }
        <%}
          if(UserappointmentIsList){%>
        str.push("<a href=\"\" onclick=\"AjaxFun('customer/Userappointment/Lists.aspx', 'action=view&userid="+id+"', ' ', '.Rnr');return false;\" title=\"预约记录\">预约</a>");
        <%}
          if(UserConsumptionIsList){%>
        str.push("<a href=\"\" onclick=\"AjaxFun('customer/UserConsumption/Lists.aspx', 'action=view&userid="+id+"', ' ', '.Rnr');return false;\" title=\"消费记录\">消费</a>");
        <%}
        if(exchangeIsList){%>
        str.push("<a href=\"\" onclick=\"AjaxFun('score/exchange/Lists.aspx', 'action=view&userid="+id+"', ' ', '.Rnr');return false;\" title=\"兑换记录\">兑换</a>");
        <%}%>
        str.push("<a href=\"\" onclick=\"AjaxFun('baby/album/Lists.aspx', 'action=view&userid="+id+"', ' ', '.Rnr');return false;\" title=\"成长相册\">相册</a>");
        return str.join(" | ");
    }
    GridFun(".Rnr", gridList, 232, 2);
    $("#SearchCardcardtypeid").chosen({ disable_search_threshold: 10 ,width:"130px"});
    $("#SearchCardcycletype").chosen({ disable_search_threshold: 10 , width:"130px"});
    $("#SearchCardcardstatus").chosen({ disable_search_threshold: 10 , width:"130px"});
    $("#SearchCardnicknamecommunityid").chosen({ width:"130px"});
</script>
<%}
  else
  {
      Response.Write(Web.UI.customer.User.View(StoresID, cardNo, name, communityid, mobile, nickname, cycletype, statusmonthnum, endmonthnum, statusdaynum, enddaynum, statusbirthday, endbirthday, loginnum, startnum, endnum, cardtypeid, cardstatus));
  }%>