<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web.CS.Manager.MenuFiles.Add" %>
<%if(!action.Equals("save")){ %>
<div id="MenuFilesAdd">
<input type="hidden" value="<%=mcid %>" name="mcid" id="mcid" />
<table class="table StyleView" width="100%" style="height:240px">
  <tr>
    <th width="80" align="right">您的位置：</th>
    <td align="left"><%=mid %></td>
  </tr>
  <tr>
    <th align="right">文件名称：</th>
    <td align="left"><input name="fileName" type="text" id="fileName" class="validate[required,length[1,50]]" maxlength="50" size="30" /></td>
  </tr>
    <tr>
    <th align="right">文件地址：</th>
    <td align="left"><input name="fileUrl" type="text" id="fileUrl" class="validate[required,length[1,200]]" maxlength="200" size="40" /></td>
  </tr>
  <tr id="OrderTr">
    <th align="right">排序号：</th>
    <td align="left"><input name="orderId" type="text" id="orderId" class="validate[required,onlyNumber,length[1,5]]" value="0" maxlength="5" size="5" /></td>

  </tr>
  <tr id="ishowTr">
    <th align="right">导航显示：</th>
    <td align="left"> <input type="radio" name="ishow"  id="ishow_1" value="1" /><label for="ishow_1">在左边显示此导航</label>
					<input type="radio" name="ishow" id="ishow_2" value="0" checked="checked" /><label for="ishow_2">不在左边显示导航</label></td>
  </tr>
    <%if (!IsOperate)
    {
        Response.Write("<script type=\"text/javascript\">FirefoxDisabled(\"OrderTr\");FirefoxDisabled(\"ishowTr\");</script>");
    } %>
</table>
</div>
<%} %>
