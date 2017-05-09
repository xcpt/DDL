<%@ Page Language="C#" AutoEventWireup="true" Inherits="customer_User_Modi" %>
<%if(!action.Equals("save")){ %>
<div id="UserModi">
<input type="hidden" name="id" value="<%=uModel.userid%>" />
<table class="table StyleView" border="0" cellspacing="0" scellpadding="0" width="100%">
    <tr>
        <th width="100" align="right">会员姓名：</th>
        <td align="left">
            <input type="text" class="validate[required,length[1,50]]" name="name" value="<%=uModel.name %>" id="UserName" size="30" maxlength="250" />
        </td>
        <th align="right">会员小名：</th>
        <td align="left">
            <input type="text" class="validate[length[0,50]]" name="nickname" value="<%=uModel.nickname %>" id="Usernickname" size="30" maxlength="250" />
        </td>
    </tr>
    <tr>
        <th align="right">会员状态：</th>
        <td align="left" colspan="3">
            <select name="State" id="UserState"<%=(Base.Fun.fun.pnumeric(uModel.cardid)?" disabled=\"disabled\"":"") %> style="width:80px;">
                <%=Web.UI.Data.Basic.UserState(uModel.State) %>
            </select>
            <script type="text/javascript">$("#UserState").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">性别：</th>
        <td align="left">
            <select name="sex" id="UserSex" style="width:80px;">
                <option value="0"<%=Base.Fun.fun.isSelected(uModel.sex,"0") %>>男</option>
                <option value="1"<%=Base.Fun.fun.isSelected(uModel.sex,"1") %>>女</option>
            </select>
            <script type="text/javascript">$("#UserSex").chosen({ disable_search_threshold: 10 });</script>
        </td>
        <th align="right" width="100">生日：</th>
        <td align="left"><input type="text" class="validate[required,length[1,50]]" value="<%=Web.UI.Ami.DateTimeFormat(uModel.birthday, "YY04-MM-DD") %>" name="birthday" id="Userbirthday" readonly="readonly" onclick="WdatePicker({ skin: 'ext' })" size="10" /></td>
    </tr>
    <tr>
        <th align="right">家长姓名：</th>
        <td align="left">
            <input type="text" class="validate[required,length[1,50]]" value="<%=uModel.parentName %>" name="ParentName" id="UserParentName" size="20" />
        </td>
        <th align="right">家长电话：</th>
        <td align="left">
            <input type="text" class="validate[required,custom[onlyNumber]]" value="<%=uModel.mobile %>" name="mobile" id="UserMobile" size="20" />
        </td>
    </tr>
    <tr>
        <th align="right">所属小区：</th>
        <td align="left" colspan="3">
            <%if (communityidIsAdd)
              { %>
            <div style="float:right;"><input type="button" name="button" id="button" onclick="CreateWindow('Sys/community/Add.aspx', '添加小区', 'Sys/community/Add.aspx?action=save&idname=Usercommunityid', 500, 50, 'communityAdd')" icon="icon-addNew" value="添加小区" /></div>
            <%} %>
            <select name="communityid" id="Usercommunityid" class="validate[required,length[1,50]]" style="width:200px;">
                <option value="">请选择</option>
                <%=Web.UI.Sys.community.GetOption(StoresID,uModel.communityid) %>
            </select>
            <script type="text/javascript">$("#Usercommunityid").chosen();</script>
        </td>
    </tr>
    <tr>
        <th align="right">有无病史：</th>
        <td align="left">
            <select name="illness" id="Userillness" style="width:200px;">
                <%=Web.UI.Data.Basic.illness(uModel.illness) %>
            </select>
            <script type="text/javascript">$("#Userillness").chosen({ disable_search_threshold: 10 });</script>
        </td>
        <th align="right">有无过敏史：</th>
        <td align="left">
            <select name="allergy" id="Userallergy" style="width:200px;">
                <%=Web.UI.Data.Basic.allergy(uModel.allergy) %>
            </select>
            <script type="text/javascript">$("#Userallergy").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
     <tr>
        <th align="right">婴儿类型：</th>
        <td align="left">
            <select name="cycletype" id="Usercycletype" style="width:200px;">
                <%=Web.UI.Data.Basic.BabyType(uModel.cycletype) %>
            </select>
            <script type="text/javascript">$("#Usercycletype").chosen({ disable_search_threshold: 10 });</script>
        </td>
        <th align="right">客户来源：</th>
        <td align="left">
            <select name="Usersource" id="UserUsersource" style="width:200px;">
                <%=Web.UI.Data.Basic.Usersource(uModel.source) %>
            </select>
            <script type="text/javascript">$("#UserUsersource").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">是否测量：</th>
        <td align="left">
            <select name="IsMeasure" id="UserIsMeasure" style="width:100px;">
                <option value="0"<%=Base.Fun.fun.isSelected(uModel.IsMeasure,"0") %>>不需要</option>
                <option value="1"<%=Base.Fun.fun.isSelected(uModel.IsMeasure,"1") %>>需要</option>
            </select>
            <script type="text/javascript">$("#UserIsMeasure").chosen({ disable_search_threshold: 10 });</script>
        </td>
        <th align="right">是否照相：</th>
        <td align="left">
            <select name="IsPhoto" id="UserIsPhoto" style="width:100px;">
                <option value="0"<%=Base.Fun.fun.isSelected(uModel.IsPhoto,"0") %>>不需要</option>
                <option value="1"<%=Base.Fun.fun.isSelected(uModel.IsPhoto,"1") %>>需要</option>
            </select>
            <script type="text/javascript">$("#UserIsPhoto").chosen({ disable_search_threshold: 10 });</script>
        </td>
    </tr>
    <tr>
        <th align="right">备注：</th>
        <td align="left" colspan="3">
            <textarea name="content" id="Cardcontent" style="width: 568px; height: 162px;"><%=uModel.content %></textarea>
        </td>
    </tr>
</table>
</div>
<%} %>