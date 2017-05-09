<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web.CS.Manager.MenuClass.Add" %>
<%if(!action.Equals("save")){ %>
<div id="MenuClassAdd">
<table class="table StyleView"  width="100%" style="height:240px">
  <tr>
    <th align="right" width="80">所属类别：</th>
    <td align="left"><input name="pid" type="text" id="pid" value="<%=pid %>" maxlength="50" style="display:none;"/><%=strPid %></td>
  </tr>
  <tr>
    <th align="right">类别名称：</th>
    <td align="left"><input name="name" type="text" id="name" class="validate[required,length[1,50]]" maxlength="50" size="30"/></td>
  </tr>
  <tr>
    <th align="right">对应目录：</th>
    <td align="left"><input name="directoryName" type="text" id="directoryName" class="validate[length[0,50]]" maxlength="50" size="40" /></td>

  </tr>
  <tr id="OrderTr">
    <th align="right">排序号：</th>
    <td align="left"><input name="orderId" type="text" class="validate[required,onlyNumber,length[1,5]]" id="orderId" value="0" maxlength="5" size="5" /></td>
  </tr>
  <tr id="ishowTr">
    <th align="right">导航显示：</th>
    <td align="left"><input type="radio" name="ishow"  id="ishow_1" value="1" /><label for="ishow_1">在左边显示此导航</label><input type="radio" name="ishow" id="ishow_2" value="0" checked /><label for="ishow_2">不在左边显示导航</label></td>
  </tr>
    <%if (!IsOperate)
    {
        Response.Write("<script type=\"text/javascript\">FirefoxDisabled(\"OrderTr\");FirefoxDisabled(\"ishowTr\");</script>");
    } %>
</table>
<%} %>