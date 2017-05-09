<%@ Page Language="C#" AutoEventWireup="true"  Inherits="customer_UserappointmentSetup_Modi" %>
<%if(!action.Equals("save")){ %>
<div id="UserappointmentSetupModi">
<input type="hidden" name="id" value="<%=msModel.id %>" />
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">
            类型：
        </th>
        <td align="left" colspan="3">
            <select name="babytype" id="UserappointmentSetupbabytype" disabled="disabled" style="width:200px;">
                <%=Web.UI.Data.Basic.BabyType(msModel.babytype) %>
            </select>
            <script type="text/javascript">$("#UserappointmentSetupbabytype").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">
            星期：
        </th>
        <td align="left" colspan="3">
            <select name="weeknum" id="UserappointmentSetupweeknum" style="width:120px;">
                <option value="1"<%=Base.Fun.fun.isSelected(msModel.weeknum,"1") %>>星期一</option>
                <option value="2"<%=Base.Fun.fun.isSelected(msModel.weeknum,"2") %>>星期二</option>
                <option value="3"<%=Base.Fun.fun.isSelected(msModel.weeknum,"3") %>>星期三</option>
                <option value="4"<%=Base.Fun.fun.isSelected(msModel.weeknum,"4") %>>星期四</option>
                <option value="5"<%=Base.Fun.fun.isSelected(msModel.weeknum,"5") %>>星期五</option>
                <option value="6"<%=Base.Fun.fun.isSelected(msModel.weeknum,"6") %>>星期六</option>
                <option value="7"<%=Base.Fun.fun.isSelected(msModel.weeknum,"7") %>>星期日</option>
            </select>
            <script type="text/javascript">$("#UserappointmentSetupweeknum").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">
            小时段：
        </th>
        <td align="left">
            <select name="hoursNum" id="UserappointmentSetuphoursNum" style="width:120px;">
                <%=Web.UI.Sys.stores.GetOption_datetimehouer(StoresID,msModel.hoursNum) %>
            </select>
            <script type="text/javascript">$("#UserappointmentSetuphoursNum").chosen({ disable_search_threshold: 10 });</script>
        </td>
        <th align="right">
            分钟段：
        </th>
        <td align="left">
            <select name="minute" id="UserappointmentSetupminute" style="width:120px;">
                <%=Web.UI.Sys.stores.GetOption_datetimeminute(msModel.minute) %>
            </select>
            <script type="text/javascript">$("#UserappointmentSetupminute").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">
            可预约数量：
        </th>
        <td align="left" colspan="3" style="height:150px">
            <br/>
            <input type="text" name="num" class="validate[required]" value="<%=msModel.num %>" id="num" size="20"/>
            <br/>
            <br/>
            <hr />
            <br/>
            1.如时间段存在，将修改时间段内预约数量。
            <br/>
            2.如时间段存在，可预约数量为0，将删除时间段预约设置。
        </td>
    </tr>
</table>
</div>
<%} %>
