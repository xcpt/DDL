<%@ Page Language="C#" AutoEventWireup="true" Inherits="Sys_Activities_Add" %>
<%if(!action.Equals("save")){ %>
<div id="ActivitiesAdd">
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">名称：</th>
        <td align="left">
            <input type="text" class="validate[required,length[1,250]]" name="title" id="Newstitle" size="50" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th align="right">标签：</th>
        <td align="left">
            <input type="text" class="validate[required]" name="tag" id="Newstag" size="50" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th align="right">区域：</th>
        <td align="left">
            <select id="NewsProvince" name="Province" multiple style="width:500px;"><option value="北京">北京</option><option value="上海">上海</option><option value="天津">天津</option><option value="重庆">重庆</option><option value="河北">河北</option><option value="山西">山西</option><option value="内蒙古">内蒙古</option><option value="辽宁">辽宁</option><option value="吉林">吉林</option><option value="黑龙江">黑龙江</option><option value="江苏">江苏</option><option value="浙江">浙江</option><option value="安徽">安徽</option><option value="福建">福建</option><option value="江西">江西</option><option value="山东">山东</option><option value="河南">河南</option><option value="湖北">湖北</option><option value="湖南">湖南</option><option value="广东">广东</option><option value="广西">广西</option><option value="海南">海南</option><option value="四川">四川</option><option value="贵州">贵州</option><option value="云南">云南</option><option value="西藏">西藏</option><option value="陕西">陕西</option><option value="甘肃">甘肃</option><option value="宁夏">宁夏</option><option value="青海">青海</option><option value="新疆">新疆</option><option value="香港">香港</option><option value="澳门">澳门</option><option value="台湾">台湾</option></select>
            <script type="text/javascript">$("#NewsProvince").chosen({ max_selected_options: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">门店：</th>
        <td align="left">
            <select id="Newsstoresid" name="storesid" style="width:300px;">
                <option value="">全部</option>
                <%=Web.UI.Sys.stores.GetOption("") %>
            </select>
            <script type="text/javascript">$("#Newsstoresid").chosen();</script>
        </td>
    </tr>
    <tr>
        <th align="right">配图：</th>
        <td align="left">
            <div style="float:right"><input type="button" value="上传配图" onclick="UploadFile('Newspic', 'PIC');" icon="icon-picture_add" /></div>
            <input type="text" class="validate[required] jTip" name="pic" id="Newspic" size="50" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th align="right">内容：</th>
        <td align="left">
            <input type="hidden" name="content___Config" id="content___Config" value="1" />
            <textarea id="content" name="content" style="display:none;"></textarea>
            <script type="text/javascript">
                CkeditorView("content", { skin: 'v2', toolbar: 'Default', height: '210' });
            </script></td>
    </tr>
</table>
</div>
<%} %>
