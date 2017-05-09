<%@ Page Language="C#" AutoEventWireup="true" Inherits="Mobile_MessageLog_Add" %>
<%if(!action.Equals("save")){ %>
<div id="MessageLogAdd">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">手机号码或APP码：</th>
        <td align="left">
            <textarea name="mobile" class="validate[required]" id="MessageLogmobile" style="width: 478px; height: 85px;"><%=mobile %></textarea><br/>一行一个
        </td>
    </tr>
    <tr>
        <th align="right">
            定时发送：
        </th>
        <td align="left"><input type="text" name="sendtime" id="MessageLogsendtime" readonly="readonly" onclick="WdatePicker({ skin: 'ext', dateFmt:'yyyy-MM-dd HH:mm:ss',alwaysUseStartDate:true })" size="20" />为空立即发送。</td>
    </tr>
    <tr>
        <th align="right">选择模板：</th>
        <td align="left">
            <select name="mtid" id="MessageLogmtid" style="width:280px;">
                <option value="0">请选择</option>
                <%=Web.UI.Mobile.MessageTemplate.GetOption(StoresID,"") %>
            </select>
            <script type="text/javascript">$("#MessageLogmtid").chosen().on("change", function ()
{
    AjaxFun("/Mobile/MessageTemplate/Lists_Read.aspx", "id="+$(this).val(), " ");
});</script>
        </td>
    </tr>
    <tr>
        <th align="right">发送方式：</th>
        <td align="left">
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
        <td align="left">
            <input type="text" name="title" id="MessageLogtitle" size="50" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th align="right">短信内容：</th>
        <td align="left">
            <textarea name="content" class="validate[required]" id="MessageLogcontent" style="width: 491px; height: 76px;"></textarea>
            <script type="text/javascript">AltDiv('#MessageLogcontent', -8, "75(150字符)个汉字", 75);</script>
        </td>
    </tr>
</table>
</div>
<%} %>
