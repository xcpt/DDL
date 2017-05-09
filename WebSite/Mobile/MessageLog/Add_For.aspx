<%@ Page Language="C#" AutoEventWireup="true" Inherits="Mobile_MessageLog_Add_For" %>
<%if(!action.Equals("save")){ %>
<div id="MessageLogAdd">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">近期有消费：</th>
        <td align="left">
            <select name="UserConsumptionTime" id="MessageLogUserConsumptionTime" style="width:200px;">
                <option value="">请选择</option>
                <option value="7">一星期内</option>
                <option value="15">半月内</option>
                <option value="30">1个月内</option>
                <option value="60">2个月内</option>
            </select>
            <script type="text/javascript">$("#MessageLogUserConsumptionTime").chosen();</script>
        </td>
        <th width="80" align="right">剩余卡次：</th>
        <td align="left">
            <select name="CardNum" id="MessageLogCardNum" style="width:200px;">
                 <option value="">请选择</option>
                <option value="3">3次以内</option>
                <option value="5">5次以内</option>
                <option value="10">10次以内</option>
                <option value="20">20次以内</option>
            </select>
            <script type="text/javascript">$("#MessageLogCardNum").chosen();</script>
        </td>
    </tr>
    <tr>
    <th width="80" align="right">离卡过期：</th>
        <td align="left">
            <select name="CardEndTime" id="MessageLogCardEndTime" style="width:200px;">
                <option value="">请选择</option>
                <option value="7">一星期内</option>
                <option value="15">半月内</option>
                <option value="30">1个月内</option>
                <option value="60">2个月内</option>
            </select>
            <script type="text/javascript">$("#MessageLogCardEndTime").chosen();</script>
        </td>
        <th width="80" align="right">卡类型：</th>
        <td align="left">
            <select name="CardType" id="MessageLogCardType" style="width:200px;">
                <option value="">请选择</option>
                <%=Web.UI.customer.CardType.GetOption(StoresID,"") %>
            </select>
            <script type="text/javascript">$("#MessageLogCardType").chosen();</script>
        </td>
    </tr>
    <tr>
        <th align="right">卡状态：</th>
        <td align="left">
            <select name="CardState" id="MessageLogCardState" style="width:200px;">
                <option value="">请选择</option>
                <option value="1">正常</option>
                <option value="-1">停卡</option>
                <option value="2">过期</option>
            </select>
            <script type="text/javascript">$("#MessageLogCardState").chosen();</script>
        </td>
        <th align="right">月龄：</th>
        <td align="left">
            <input type="text" name="yueling1" id="yueling1" size="8" maxlength="20" />-<input type="text" name="yueling2" id="yueling2" size="8" maxlength="20" />
        </td>
    </tr>
    <tr>
        <th align="right">
            定时发送：
        </th>
        <td align="left" colspan="3"><input type="text" name="sendtime" id="MessageLogsendtime" readonly="readonly" onclick="WdatePicker({ skin: 'ext', dateFmt: 'yyyy-MM-dd HH:mm:ss', alwaysUseStartDate: true })" size="20" />为空立即发送。</td>
    </tr>
    <tr>
        <th align="right">选择模板：</th>
        <td align="left" colspan="3">
            <select name="mtid" id="MessageLogmtid" style="width:280px;">
                <option value="0">请选择</option>
                <%=Web.UI.Mobile.MessageTemplate.GetOption(StoresID,"") %>
            </select>
            <script type="text/javascript">$("#MessageLogmtid").chosen().on("change", function () {
    AjaxFun("/Mobile/MessageTemplate/Lists_Read.aspx", "id=" + $(this).val(), " ");
});</script>
        </td>
    </tr>
    <tr>
        <th align="right">发送方式：</th>
        <td align="left" colspan="3">
            <select name="sendtype" id="MessageLogsendtype" style="width:280px;">
                <option value="0">发送手机消息</option>
                <option value="1">app消息</option>
                <option value="2">手机、app消息</option>
            </select>
            <script type="text/javascript">$("#MessageLogsendtype").chosen();</script>
        </td>
    </tr>
    <tr>
        <th align="right">
            标题：
        </th>
        <td align="left" colspan="3">
            <input type="text" name="title" id="MessageLogtitle" size="50" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th align="right">短信内容：</th>
        <td align="left" colspan="3">
            <textarea name="content" class="validate[required]" id="MessageLogcontent" style="width: 491px; height: 76px;"></textarea>
            <script type="text/javascript">AltDiv('#MessageLogcontent', -8, "75(150字符)个汉字", 75);</script>
        </td>
    </tr>
</table>
</div>
<%} %>
