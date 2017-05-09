<%@ Page Language="C#" AutoEventWireup="true" Inherits="Sys_Stores_Lists_View" %>
<div>
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">
            门店名称：
        </th>
        <td align="left"><%=sModel.title %></td>
    </tr>
    <tr>
        <th align="right">
            门店类型：
        </th>
        <td align="left"><%=sModel.Isoutlets.Equals("1")?"直营"+(sModel.IsCross.Equals("1")?"[跨店]":""):"加盟" %></td>
    </tr>
    <tr>
        <th width="80" align="right">
            开店时间：
        </th>
        <td align="left"><%=sModel.opentime %></td>
    </tr>
    <tr>
        <th width="80" align="right">
            地址位置：
        </th>
        <td align="left">
            省：<%=sModel.Province %>&nbsp;
            市：<%=sModel.City %>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            详细地址：
        </th>
        <td align="left"><%=sModel.address %></td>
    </tr>
    <tr>
        <th width="80" align="right">
            上班时间：
        </th>
        <td align="left">
			早：<%=sModel.Worktime %>&nbsp;
            晚：<%=sModel.Closingtime %>
        </td>
    </tr>
    <tr>
        <th width="80" align="right">
            门店电话：
        </th>
        <td align="left"><%=sModel.tel %></td>
    </tr>
</table>
</div>