<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_User_Lists_LoadView" %>
<div id="UserAdd" style="height:450px;overflow-x:hidden;overflow-y:auto;">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr><th colspan="4">会员基本信息</th></tr>
    <tr>
        <th width="80" align="right">会员姓名：</th>
        <td align="left"><%=uModel.name %><%=(StoresID.Equals(uModel.storesid)?"":"["+Web.UI.Sys.stores.GetStoresName(uModel.storesid)+"]") %></td>
        <th align="right" width="80">会员小名：</th>
        <td align="left"><%=uModel.nickname %></td>
    </tr>
    <tr>
        <th align="right">性别：</th>
        <td align="left"><%=(uModel.sex.Equals("0")?"男":"女") %></td>
        <th align="right">生日：</th>
        <td align="left"><%=Web.UI.Ami.DateTimeFormat(uModel.birthday,"YY04-MM-DD") %></td>
    </tr>
    <tr>
        <th align="right">家长姓名：</th>
        <td align="left"><%=uModel.parentName %></td>
        <th align="right">联系电话：</th>
        <td align="left"><%=uModel.tel %></td>
    </tr>
    <tr>
        <th align="right">妈妈手机：</th>
        <td align="left"><%=uModel.mobile %></td>
        <th align="right">所在小区：</th>
        <td align="left"><%=Web.UI.Sys.community.GetName(StoresID, uModel.communityid) %></td>
    </tr>
    <tr><th colspan="4">会员卡信息</th></tr>
    <tr>
        <th width="80" align="right">正价次数：</th>
        <td align="left"><%=uModel.cModel.surpluspositivenum %><%=(Base.Fun.fun.pnumeric(np)?"["+np+"]":"") %>次/<%=uModel.cModel.positivenum %>次</td>
        <th align="right">赠送次数：</th>
        <td align="left"><%=uModel.cModel.surplusnegativenum %><%=(Base.Fun.fun.pnumeric(nn)?"["+nn+"]":"") %>次/<%=uModel.cModel.negativenum %>次</td>
    </tr>
    <tr>
        <th width="80" align="right">生效日期：</th>
        <td align="left"><%=Web.UI.Ami.DateTimeFormat(uModel.cModel.starttime,"YY04年MM月DD日") %></td>
        <th align="right">失效日期：</th>
        <td align="left"><%=Web.UI.Ami.DateTimeFormat(uModel.cModel.endtime,"YY04年MM月DD日") %></td>
    </tr>
    <tr>
        <td align="left" colspan="4">
        <%if(UserappointmentIsAdd){ %>
         <input type="button" name="button" id="Submit8" onclick="GridModiy('<%=uModel.userid%>', 'customer/Userappointment/Add.aspx', '添加预约', 'customer/Userappointment/Add.aspx?action=save', 600, 400, 'UserappointmentAdd')" icon="icon-time_add" value="预约" />
        <%} %>
        <%if(UserConsumptionIsAdd){ %>
        <input type="submit" name="button" id="Submit3" onclick="GridModiy('<%=uModel.userid%>', 'customer/UserConsumption/Add.aspx', '新增消费', 'customer/UserConsumption/Add.aspx?action=save', 600, 480, 'UserConsumptionAdd')" icon="icon-addNew" value="消费" />
        <%} %>
        <%if (exchangeIsAdd)
          { %>
        <input type="button" name="button" id="Submit6" onclick="GridModiy('<%=uModel.userid%>', 'score/exchange/Add.aspx', '积分兑换','score/exchange/Add.aspx?winlist=user&action=save',600, 190,'exchangeAdd')" icon="icon-addNew" value="积分兑换" />
        <%} %>
        <input type="button" name="button" id="Button2" onclick="GridModiy('<%=uModel.userid%>', 'customer/User/Lists_Chart.aspx?action=height', '身高成长曲线',null,700, 400)" icon="icon-chart_curve" value="身高曲线" />
        <input type="button" name="button" id="Button3" onclick="GridModiy('<%=uModel.userid%>', 'customer/User/Lists_Chart.aspx?action=weight', '体重成长曲线',null,700, 400)" icon="icon-chart_curve" value="体重曲线" />
        </td>
    </tr>
    <tr>
        <td align="left" colspan="4">
            <a href="" onclick="AjaxFun('customer/Card/Lists.aspx', 'action=view&userid=<%=uModel.userid %>', ' ', '.Rnr');return false;">查卡</a>
            <%if(UserappointmentIsList){ %>
            &nbsp;|&nbsp;<a href="" onclick="AjaxFun('customer/Userappointment/Lists.aspx', 'action=view&userid=<%=uModel.userid %>', ' ', '.Rnr');return false;" title="预约记录">预约记录</a>
            <%}if(UserConsumptionIsList){%>
            &nbsp;|&nbsp;<a href="" onclick="AjaxFun('customer/UserConsumption/Lists.aspx', 'action=view&userid=<%=uModel.userid %>', ' ', '.Rnr');return false;" title="消费记录">消费记录</a>
            <%} %>
        </td>
    </tr>
</table>
</div>