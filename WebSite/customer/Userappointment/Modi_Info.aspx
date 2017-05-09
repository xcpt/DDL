<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_Userappointment_Modi_Info" %>
<%if(!action.Equals("save")){ %>
<div id="UserappointmentModi">
<input type="hidden" name="id" value="<%=uaModel.id %>" />
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th align="right" width="80">会员姓名：</th>
        <td align="left">
            <input type="text" name="userid" id="Userappointmentuserid" size="50" />
            <script type="text/javascript">$("#Userappointmentuserid").autoSuggest("customer/user/intelligent.aspx", { asHtmlID: 'Userappointmentuserid_yq', asHtmlName: 'userid', selectedItemProp: "name", maxLength: "1", searchObjProps: "name", ReadAll: false, prePopulate: [[<%=uaModel.userid%>]], isdel: false });</script>
        </td>
    </tr>
    <tr>
        <th align="right">婴儿类型：</th>
        <td align="left">
            <select name="babytype" class="validate[required,length[1,50]]" id="Userbabytype" style="width:200px;">
                <%=Web.UI.Data.Basic.BabyType(cycletype) %>
            </select>
            <script type="text/javascript">$("#Userbabytype").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">预约日期：</th>
        <td align="left">
            <input type="text" class="validate[required]" name="datetime" id="Userappointmentdatetime" value="<%=DateTime.Parse(uaModel.datetime).ToString("yyyy-MM-dd") %>" readonly="readonly" onclick="WdatePicker({ skin: 'ext' })" size="10" />
        </td>
    </tr>
    <tr>
        <th align="right">预约时间：</th>
        <td align="left">
            <select name="datetimehouer" id="Userappointmentdatetimehouer" style="width:80px;">
                <%=Web.UI.Sys.stores.GetOption_datetimehouer(StoresID,uaModel.datetimehouer) %>
            </select>
            <select name="datetimeminute" id="Userappointmentdatetimeminute" style="width:80px;">
                <%=Web.UI.Sys.stores.GetOption_datetimeminute(uaModel.datetimeminute) %>
            </select>
            <script type="text/javascript">$("#Userappointmentdatetimehouer").chosen({ disable_search_threshold: 10 }); $("#Userappointmentdatetimeminute").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">预约泳师：</th>
        <td align="left"><select name="swimteacherid" id="Userappointmentswimteacherid" style="width:120px;">
                <%=Web.UI.Staff.swimteacher.GetOption(StoresID,uaModel.swimteacherid) %>
            </select>
            <script type="text/javascript">$("#Userappointmentswimteacherid").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">泳圈型号：</th>
        <td align="left"><select name="mamasid" id="Userappointmentmamasid" style="width:150px;">
                <%=Web.UI.Sys.mamas.GetOption(StoresID,uaModel.mamasid) %>
            </select>
            <script type="text/javascript">$("#Userappointmentmamasid").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">特别标识：</th>
        <td align="left"><select name="istop" id="Userappointistop" style="width:80px;">
                <option value="0"<%=Base.Fun.fun.isSelected("0",uaModel.istop) %>>否</option>
                <option value="1"<%=Base.Fun.fun.isSelected("1",uaModel.istop) %>>是</option>
            </select>
            <script type="text/javascript">$("#Userappointistop").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">备注：</th>
        <td align="left">
            <textarea name="content" id="Userappointcontent" style="width: 481px; height: 100px;"><%=uaModel.content %></textarea>
        </td>
    </tr>
</table>
</div>
<%} %>