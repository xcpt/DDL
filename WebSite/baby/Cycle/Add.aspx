<%@ Page Language="C#" AutoEventWireup="true" Inherits="baby_Cycle_Add" %>
<%if(!action.Equals("save")){ %>
<div id="CycleAdd">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th align="right">类型：</th>
        <td align="left"><select name="type" id="Cycletype">
          <%=Web.UI.Data.Basic.CycleType("") %>
        </select><script type="text/javascript">$("#Cycletype").chosen({ disable_search_threshold: 10, width: "100px" });</script></td>
    </tr>
    <tr>
        <th width="80" align="right">名称：</th>
        <td align="left">
            <input type="text" class="validate[required,length[1,250]]" name="title" id="Cycletitle" size="50" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th align="right">起始日龄：</th>
        <td align="left">
             <input type="text" class="validate[required,custom[onlyNumber]]" name="startday" id="Cyclestartday" size="20" />
        </td>
    </tr>
    <tr>
        <th align="right">截止日龄：</th>
        <td align="left">
             <input type="text" class="validate[required,custom[onlyNumber]]" name="endday" id="Cycleendday" size="20" />
        </td>
    </tr>
</table>
</div>
<%} %>