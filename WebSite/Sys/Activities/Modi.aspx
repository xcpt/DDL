<%@ Page Language="C#" AutoEventWireup="true" Inherits="Sys_Activities_Modi" %>
<%if(!action.Equals("save")){ %>
<div id="ActivitiesModi">
<input type="hidden" name="id" value="<%=nModel.id %>" />
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="80" align="right">名称：</th>
        <td align="left">
            <input type="text" class="validate[required,length[1,250]]" name="title" id="Newstitle" value="<%=nModel.title %>" size="50" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th align="right">标签：</th>
        <td align="left">
            <input type="text" class="validate[required]" name="tag" id="Newstag" value="<%=nModel.tag %>" size="50" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th align="right">区域：</th>
        <td align="left">
            <select id="NewsProvince" name="Province" multiple style="width:500px;">
                <option value="北京"<%=(","+nModel.Province+",").Contains(",北京,")?" selected=\"selected\"":"" %>>北京</option>
                <option value="上海"<%=(","+nModel.Province+",").Contains(",上海,")?" selected=\"selected\"":"" %>>上海</option>
                <option value="天津"<%=(","+nModel.Province+",").Contains(",天津,")?" selected=\"selected\"":"" %>>天津</option>
                <option value="重庆"<%=(","+nModel.Province+",").Contains(",重庆,")?" selected=\"selected\"":"" %>>重庆</option>
                <option value="河北"<%=(","+nModel.Province+",").Contains(",河北,")?" selected=\"selected\"":"" %>>河北</option>
                <option value="山西"<%=(","+nModel.Province+",").Contains(",山西,")?" selected=\"selected\"":"" %>>山西</option>
                <option value="内蒙古"<%=(","+nModel.Province+",").Contains(",内蒙古,")?" selected=\"selected\"":"" %>>内蒙古</option>
                <option value="辽宁"<%=(","+nModel.Province+",").Contains(",辽宁,")?" selected=\"selected\"":"" %>>辽宁</option>
                <option value="吉林"<%=(","+nModel.Province+",").Contains(",吉林,")?" selected=\"selected\"":"" %>>吉林</option>
                <option value="黑龙江"<%=(","+nModel.Province+",").Contains(",黑龙江,")?" selected=\"selected\"":"" %>>黑龙江</option>
                <option value="江苏"<%=(","+nModel.Province+",").Contains(",江苏,")?" selected=\"selected\"":"" %>>江苏</option>
                <option value="浙江"<%=(","+nModel.Province+",").Contains(",浙江,")?" selected=\"selected\"":"" %>>浙江</option>
                <option value="安徽"<%=(","+nModel.Province+",").Contains(",安徽,")?" selected=\"selected\"":"" %>>安徽</option>
                <option value="福建"<%=(","+nModel.Province+",").Contains(",福建,")?" selected=\"selected\"":"" %>>福建</option>
                <option value="江西"<%=(","+nModel.Province+",").Contains(",江西,")?" selected=\"selected\"":"" %>>江西</option>
                <option value="山东"<%=(","+nModel.Province+",").Contains(",山东,")?" selected=\"selected\"":"" %>>山东</option>
                <option value="河南"<%=(","+nModel.Province+",").Contains(",河南,")?" selected=\"selected\"":"" %>>河南</option>
                <option value="湖北"<%=(","+nModel.Province+",").Contains(",湖北,")?" selected=\"selected\"":"" %>>湖北</option>
                <option value="湖南"<%=(","+nModel.Province+",").Contains(",湖南,")?" selected=\"selected\"":"" %>>湖南</option>
                <option value="广东"<%=(","+nModel.Province+",").Contains(",广东,")?" selected=\"selected\"":"" %>>广东</option>
                <option value="广西"<%=(","+nModel.Province+",").Contains(",广西,")?" selected=\"selected\"":"" %>>广西</option>
                <option value="海南"<%=(","+nModel.Province+",").Contains(",海南,")?" selected=\"selected\"":"" %>>海南</option>
                <option value="四川"<%=(","+nModel.Province+",").Contains(",四川,")?" selected=\"selected\"":"" %>>四川</option>
                <option value="贵州"<%=(","+nModel.Province+",").Contains(",贵州,")?" selected=\"selected\"":"" %>>贵州</option>
                <option value="云南"<%=(","+nModel.Province+",").Contains(",云南,")?" selected=\"selected\"":"" %>>云南</option>
                <option value="西藏"<%=(","+nModel.Province+",").Contains(",西藏,")?" selected=\"selected\"":"" %>>西藏</option>
                <option value="陕西"<%=(","+nModel.Province+",").Contains(",陕西,")?" selected=\"selected\"":"" %>>陕西</option>
                <option value="甘肃"<%=(","+nModel.Province+",").Contains(",甘肃,")?" selected=\"selected\"":"" %>>甘肃</option>
                <option value="宁夏"<%=(","+nModel.Province+",").Contains(",宁夏,")?" selected=\"selected\"":"" %>>宁夏</option>
                <option value="青海"<%=(","+nModel.Province+",").Contains(",青海,")?" selected=\"selected\"":"" %>>青海</option>
                <option value="新疆"<%=(","+nModel.Province+",").Contains(",新疆,")?" selected=\"selected\"":"" %>>新疆</option>
                <option value="香港"<%=(","+nModel.Province+",").Contains(",香港,")?" selected=\"selected\"":"" %>>香港</option>
                <option value="澳门"<%=(","+nModel.Province+",").Contains(",澳门,")?" selected=\"selected\"":"" %>>澳门</option>
                <option value="台湾"<%=(","+nModel.Province+",").Contains(",台湾,")?" selected=\"selected\"":"" %>>台湾</option></select>
            <script type="text/javascript">$("#NewsProvince").chosen({ max_selected_options: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">门店：</th>
        <td align="left">
            <select id="Newsstoresid" name="storesid" style="width:300px;">
                <option value="">全部</option>
                <%=Web.UI.Sys.stores.GetOption(nModel.storesid) %>
            </select>
            <script type="text/javascript">$("#Newsstoresid").chosen();</script>
        </td>
    </tr>
    <tr>
        <th align="right">配图：</th>
        <td align="left">
            <div style="float:right"><input type="button" value="上传配图" onclick="UploadFile('Newspic', 'PIC');" icon="icon-picture_add" /></div>
            <input type="text" class="validate[required] jTip" value="<%=nModel.pic %>" name="pic" id="Newspic" size="50" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th align="right">内容：</th>
        <td align="left">
            <input type="hidden" name="content___Config" id="content___Config" value="1" />
            <textarea id="content" name="content" style="display:none;"><%=nModel.content %></textarea>
            <script type="text/javascript">
                CkeditorView("content", { skin: 'v2', toolbar: 'Default', height: '210' });
            </script></td>
    </tr>
</table>
</div>
<%} %>
