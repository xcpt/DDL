<%@ Page Language="C#" AutoEventWireup="true" Inherits="Marketing_Visit_Add" %>
<%if(!action.Equals("save")){ %>
<div id="VisitAdd">
<input type="hidden" name="id" value="<%=userid %>" />
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">
            回该时间：
        </th>
        <td align="left">
            <input type="text" class="validate[required,length[1,250]]" name="addtime" value="<%=DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") %>" onclick="WdatePicker({ skin: 'ext', dateFmt: 'yyyy-MM-dd HH:mm:ss', alwaysUseStartDate: true })" id="VisitAddtime" size="30" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th align="right">
            回访员工：
        </th>
        <td align="left">
            <select name="memberid" id="Visitmemberid" style="width:280px;">
                <option value="0">请选择</option>
                <%=Web.UI.Staff.member.GetOption(StoresID,"") %>
            </select>
            <script type="text/javascript">$("#Visitmemberid").chosen();</script>
        </td>
    </tr>
    <tr>
        <th align="right">
            回访结果：
        </th>
        <td align="left">
            <select name="ReturnresultID" id="VisitReturnresultID" style="width:280px;">
                <%=Web.UI.Data.Basic.ReturnresultID("") %>
            </select>
            <script type="text/javascript">$("#VisitReturnresultID").chosen();</script>
        </td>
    </tr>
    <tr>
        <th align="right">
            是否放弃：
        </th>
        <td align="left">
            <select name="IsGiveup" id="VisitIsGiveup" style="width:280px;">
                <%=Web.UI.Data.Basic.IsGiveup("") %>
            </select>
            <script type="text/javascript">$("#VisitIsGiveup").chosen();</script>
        </td>
    </tr>
    <tr>
        <th align="right">
            备注：
        </th>
        <td align="left">
            <textarea name="Content" id="VisitContent" style="width: 365px; height: 85px;"></textarea>
        </td>
    </tr>
</table>
</div>
<%} %>
