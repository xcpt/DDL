<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web.CS.Manager.MenuClass.Modi" %>
<%if(!action.Equals("save")){ %>
<div id="MenuClassModi">
<input type="hidden" value="<%=id %>" name="id" id="id" />
<input type="hidden" value="<%=pid %>" name="pid" id="pid" />
<table class="table StyleView"  width="100%" style="height:200px;">
  <tr><th align="right" width="80">类别名称：</th>
    <td align="left"><input name="name" type="text" id="name" value="<%=name %>" class="validate[required,length[1,50]]" maxlength="50" size="30" /></td>
  </tr>
  <tr id="directoryNameTr">
    <th align="right">对应目录：</th>
    <td align="left"><input name="directoryName" type="text" id="directoryName" value="<%=directoryName %>" class="validate[length[0,50]]" maxlength="50" size="40" /></td>

  </tr>
  <tr align="right" id="OrderTr">
    <th align="right">排序号：</th>
    <td align="left"><input name="orderId" type="text" id="orderId" class="validate[required,onlyNumber,length[1,5]]" value="<%=orderId %>" maxlength="5" size="5" /></td>

  </tr>
  <tr id="ishowTr">
    <th align="right">导航显示：</th>
    <td align="left"><input type="radio" name="ishow"  id="ishow_1" value="1" <%=Base.Fun.fun.isChecked("1",ishow) %>/><label for="ishow_1">在左边显示此导航</label>
		<input type="radio" name="ishow" id="ishow_2" value="0" <%=Base.Fun.fun.isChecked("0",ishow) %>/><label for="ishow_2">不在左边显示导航</label></td>
  </tr>
    <%if (!IsOperate)
    {
        Response.Write("<script type=\"text/javascript\">FirefoxDisabled(\"OrderTr\");</script>");
    }
    if (issys == "1")
    {
        Response.Write("<script type=\"text/javascript\">FirefoxDisabled(\"directoryNameTr\");</script>");
    }
    if (pid == "2" || id == "2")
    {
        Response.Write("<script type=\"text/javascript\">FirefoxDisabled(\"ishowTr\");</script>");
    }%>
</table>
</div>
<%} %>