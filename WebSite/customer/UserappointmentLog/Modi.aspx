<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_UserappointmentLog_Modi" %>
<%if(!action.Equals("save")){ %>
<div id="UserappointmentLogModi">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="100" align="right">
            类型：
        </th>
        <td align="left" colspan="3">
            <select name="babytype" id="UserappointmentSetupbabytype" disabled="disabled" style="width:200px;">
                <%=Web.UI.Data.Basic.BabyType(babytype) %>
            </select>
            <script type="text/javascript">$("#UserappointmentSetupbabytype").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">日期：</th>
        <td align="left"><%=datetime %></td>
        <th align="right" width="100" >星期：</th>
        <td align="left" colspan="3">
            <select name="weeknum" id="UserappointmentSetupweeknum" disabled="disabled" style="width:120px;">
                <option value="1"<%=Base.Fun.fun.isSelected(weeknum,"1") %>>星期一</option>
                <option value="2"<%=Base.Fun.fun.isSelected(weeknum,"2") %>>星期二</option>
                <option value="3"<%=Base.Fun.fun.isSelected(weeknum,"3") %>>星期三</option>
                <option value="4"<%=Base.Fun.fun.isSelected(weeknum,"4") %>>星期四</option>
                <option value="5"<%=Base.Fun.fun.isSelected(weeknum,"5") %>>星期五</option>
                <option value="6"<%=Base.Fun.fun.isSelected(weeknum,"6") %>>星期六</option>
                <option value="7"<%=Base.Fun.fun.isSelected(weeknum,"7") %>>星期日</option>
            </select>
            <script type="text/javascript">$("#UserappointmentSetupweeknum").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">小时段：</th>
        <td align="left">
            <select name="hoursNum" disabled="disabled" id="UserappointmentSetuphoursNum" style="width:120px;">
                <%=Web.UI.Sys.stores.GetOption_datetimehouer(StoresID,hoursNum) %>
            </select>
            <script type="text/javascript">$("#UserappointmentSetuphoursNum").chosen({ disable_search_threshold: 10 });</script>
        </td>
        <th align="right">分钟段：</th>
        <td align="left">
            <select name="minute" disabled="disabled" id="UserappointmentSetupminute" style="width:120px;">
                <%=Web.UI.Sys.stores.GetOption_datetimeminute(minute) %>
            </select>
            <script type="text/javascript">$("#UserappointmentSetupminute").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">原始配置数量：</th>
        <td align="left"><%=allnum %></td>
        <th align="right">已预约数量：</th>
        <td align="left">App：<%=appnum %>；PC：<%=pcnum %>；</td>
    </tr>
    <tr>
        <th align="right">剩余数量：</th>
        <td align="left" colspan="3"><input type="text" name="num" class="validate[required]" value="<%=usernum %>" id="num" size="20"/></td>
    </tr>
</table>
</div>
<%} %>
