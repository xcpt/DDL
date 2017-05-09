<%@ Page Language="C#" AutoEventWireup="true" Inherits="baby_height_Modi" %>
<%if(!action.Equals("save")){ %>
<div id="heightModi">
<input type
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">月龄：</th>
        <td align="left">
             <input type="text" class="validate[required,custom[onlyNumber]]" value="<%=hModel.monthage %>" name="monthage" id="heightmonthage" size="20" />
        </td>
    </tr>
    <tr>
        <th align="right">性别：</th>
        <td align="left"><select name="sex" id="heightsex">
          <option value="0"<%=Base.Fun.fun.isSelected(hModel.sex,"0") %>>男</option>
          <option value="1"<%=Base.Fun.fun.isSelected(hModel.sex,"1") %>>女</option>
        </select><script type="text/javascript">$("#heightsex").chosen({ disable_search_threshold: 10, width: "100px" });</script></td>
    </tr>
    <tr>
        <th align="right">最小值：</th>
        <td align="left">
            <input type="text" class="validate[required,custom[Decimal]]" value="<%=hModel.minnum %>" name="minnum" id="heightminnum" size="20"/>厘米
        </td>
    </tr>
    
    <tr>
        <th align="right">最大值：</th>
        <td align="left">
             <input type="text" class="validate[required,custom[Decimal]]" value="<%=hModel.maxnum %>" name="maxnum" id="heightmaxnum" size="20" />厘米
        </td>
    </tr>
</table>
</div>
<%} %>