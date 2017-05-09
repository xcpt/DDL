<%@ Page Language="C#" AutoEventWireup="true" Inherits="baby_weight_Add" %>
<%if(!action.Equals("save")){ %>
<div id="weightAdd">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">月龄：</th>
        <td align="left">
             <input type="text" class="validate[required,custom[onlyNumber]]" name="monthage" id="weightmonthage" size="20" />
        </td>
    </tr>
    <tr>
        <th align="right">性别：</th>
        <td align="left"><select name="sex" id="weightsex">
          <option value="0">男</option>
          <option value="1">女</option>
        </select><script type="text/javascript">$("#weightsex").chosen({ disable_search_threshold: 10, width: "100px" });</script></td>
    </tr>
    <tr>
        <th align="right">最小值：</th>
        <td align="left">
            <input type="text" class="validate[required,custom[Decimal]]" name="minnum" id="weightminnum" size="20" />厘米
        </td>
    </tr>
    
    <tr>
        <th align="right">最大值：</th>
        <td align="left">
             <input type="text" class="validate[required,custom[Decimal]]" name="maxnum" id="weightmaxnum" size="20" />厘米
        </td>
    </tr>
</table>
</div>
<%} %>