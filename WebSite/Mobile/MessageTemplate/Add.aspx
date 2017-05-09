<%@ Page Language="C#" AutoEventWireup="true" Inherits="Mobile_MessageTemplate_Add" %>
<%if(!action.Equals("save")){ %>
<div id="MessageTemplateAdd">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">
            标题：
        </th>
        <td align="left">
            <input type="text" class="validate[required]" name="title" id="MessageTemplateTitle" size="50" />
        </td>
    </tr>
    <tr>
        <th align="right">短信内容：</th>
        <td align="left">
            <textarea name="content" class="validate[required]" id="MessageTemplatecontent" style="width: 365px; height: 85px;"></textarea>
            <script type="text/javascript">AltDiv('#MessageTemplatecontent', -8, "75(150字符)个汉字", 75);</script>
        </td>
    </tr>
</table>
</div>
<%} %>
