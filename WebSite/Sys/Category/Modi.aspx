<%@ Page Language="C#" AutoEventWireup="true" Inherits="Sys_Category_Modi" %>
<div style="padding:5px" id="WeiXin_MenuModi">
<table class="table StyleView" width="100%">
  <tr>
    <th align="right" width="80">栏目名称：</th>
    <td align="left"><input type="text" name="classname" id="classname" value="<%=cModel.classname %>" size="50" class="validate[required,length[1,20]]" /></td>
  </tr>
  <tr>
        <th align="right">配图：</th>
        <td align="left">
            <div style="float:right"><input type="button" value="上传配图" onclick="UploadFile('categorypic', 'PIC');" icon="icon-picture_add" /></div>
            <input type="text" class="jTip" value="<%=cModel.pic %>" style="width:270px;" name="pic" id="categorypic" size="50" maxlength="250" />
        </td>
  </tr>
 <%if (!Base.Fun.fun.pnumeric(cModel.parentid))
   { %>
  <tr>
        <th align="right">首页：</th>
        <td align="left">
            <input type="radio" name="isnavi"<%=Base.Fun.fun.isChecked("0",cModel.isnavi) %> id="isnavi_0" value="0" /><label for="isnavi_0">不显示</label>
            <input type="radio" name="isnavi"<%=Base.Fun.fun.isChecked("1",cModel.isnavi) %> id="isnavi_1" value="1" /><label for="isnavi_1">显示</label>
        </td>
  </tr>
<%}else{ %>
   <tr>
        <th align="right">适用范围：</th>
        <td align="left">
            <input type="text" name="sday" id="sday" size="8" value="<%=cModel.sday %>" class="validate[required,length[1,20]]" />-<input type="text" name="eday" id="eday" size="8" value="<%=cModel.eday %>" class="validate[required,length[1,20]]" />天
        </td>
  </tr>
<%} %>
    <tr>
        <th align="right">简单说明：</th>
        <td align="left">
            <textarea id="content" name="content" style="width: 377px; height: 61px;"><%=cModel.content%></textarea>
        </td>
    </tr>
</table>
</div>
</div>