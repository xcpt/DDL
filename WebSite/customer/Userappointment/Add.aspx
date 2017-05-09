<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_Userappointment_Add" %>
<%if(!action.Equals("save")){ %>
<div id="UserappointmentAdd">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th align="right" width="80">会员姓名：</th>
        <td align="left">
            <input type="text" name="id" id="Userappointmentuserid" size="50" />
            <script type="text/javascript">$("#Userappointmentuserid").autoSuggest("customer/user/intelligent.aspx", {
asHtmlID: 'Userappointmentuserid_yq', asHtmlName: 'id', selectedItemProp: "name", maxLength: "1", searchObjProps: "name", ReadAll: false, prePopulate: [[<%=userid%>]], selectOKFunction: function (v) {
    AjaxFun("customer/user/intelligent_babytype.aspx", "userid=" + v,"", function (hv)
    {
        $("#Userbabytype").val(hv).trigger("chosen:updated");
    });
    AjaxFun("customer/user/intelligent_mamas.aspx", "userid=" + v, "", function (hv) {
        $("#Userappointmentmamasid").val(hv).trigger("chosen:updated");
    });
}
});</script>
        </td>
    </tr>
    <tr>
        <th align="right">婴儿类型：</th>
        <td align="left">
            <select name="babytype" class="validate[required,length[1,50]]" id="Userbabytype" style="width:100px;">
                <%=Web.UI.Data.Basic.BabyType("") %>
            </select>
            <script type="text/javascript">$("#Userbabytype").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">预约日期：</th>
        <td align="left">
            <input type="text" class="validate[required]" name="datetime" id="Userappointmentdatetime" value="<%=DateTime.Now.ToString("yyyy-MM-dd") %>" readonly="readonly" onclick="WdatePicker({ skin: 'ext' })" size="10" />
        </td>
    </tr>
    <tr>
        <th align="right">预约时间：</th>
        <td align="left">
            <select name="datetimehouer" id="Userappointmentdatetimehouer" style="width:80px;">
                <%=Web.UI.Sys.stores.GetOption_datetimehouer(StoresID,"") %>
            </select>
            <select name="datetimeminute" id="Userappointmentdatetimeminute" style="width:80px;">
                <%=Web.UI.Sys.stores.GetOption_datetimeminute("") %>
            </select>
            <script type="text/javascript">$("#Userappointmentdatetimehouer").chosen({ disable_search_threshold: 10 });$("#Userappointmentdatetimeminute").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">预约泳师：</th>
        <td align="left"><select name="swimteacherid" id="Userappointmentswimteacherid" style="width:250px;">
                <%=Web.UI.Staff.swimteacher.GetOption(StoresID,"") %>
            </select>
            <script type="text/javascript">$("#Userappointmentswimteacherid").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">泳圈型号：</th>
        <td align="left"><select name="mamasid" id="Userappointmentmamasid" style="width:150px;">
                <%=Web.UI.Sys.mamas.GetOption(StoresID,Web.UI.customer.UserConsumption.ReadUser_mamasid(userid)) %>
            </select>
            <script type="text/javascript">$("#Userappointmentmamasid").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">特别标识：</th>
        <td align="left"><select name="istop" id="Userappointistop" style="width:80px;">
                <option value="0" selected="selected">否</option>
                <option value="1">是</option>
            </select>
            <script type="text/javascript">$("#Userappointistop").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">备注：</th>
        <td align="left">
            <textarea name="content" id="Userappointcontent" style="width: 481px; height: 100px;"></textarea>
        </td>
    </tr>
</table>
</div>
<%} %>