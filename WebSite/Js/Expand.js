///数据校验正则
function GetRegxStr(num,cName)///编号，接受控件名
{
    var value="";
    switch(num)
    {
        case "1":///数字
            value="/^[0-9.-]+$/";
            break;
        case "2":///整数
            value="/^[0-9-]+$/";
            break;   
        case "3":///字母
            value="/^[a-z]+$/i";
            break;   
        case "4":///数字+字母
            value="/^[0-9a-z]+$/i";
            break;
        case "5":///Email
            value="/^[\w\-\.]+@[\w\-\.]+(\.\w+)+$/";
            break;   
        case "6"://QQ
            value="/^[0-9]{5,20}$/";
            break; 
        case "7"://超级连接
            value="/^http:\/\//";
            break; 
        case "8":///手机号码
            value="/^(13|15)[0-9]{9}$/";
            break;   
        case "9":///电话号码
            value="/^[0-9-]{6,13}$/";
            break; 
        case "10":///邮政编码
            value="/^[0-9]{6}$/";
            break; 
        default:
            break;  
    }
    document.getElementById(cName).value=value;///回写值
}
function GetRegxOptionStr(objName, value)
{
    var aList=$id(objName);
    addItem(aList, SycmsLanguage.Expand.GetRegxOptionStr.l1, "", value);
    addItem(aList, SycmsLanguage.Expand.GetRegxOptionStr.l2, "telephone", value);
    addItem(aList, SycmsLanguage.Expand.GetRegxOptionStr.l3, "mobilephone", value);
    addItem(aList, SycmsLanguage.Expand.GetRegxOptionStr.l4, "email", value);
    addItem(aList, SycmsLanguage.Expand.GetRegxOptionStr.l5, "date", value);
    addItem(aList, SycmsLanguage.Expand.GetRegxOptionStr.l6, "ip", value);
    addItem(aList, SycmsLanguage.Expand.GetRegxOptionStr.l7, "chinese", value);
    addItem(aList, SycmsLanguage.Expand.GetRegxOptionStr.l8, "url", value);
    addItem(aList, SycmsLanguage.Expand.GetRegxOptionStr.l9, "qq", value);
    addItem(aList, SycmsLanguage.Expand.GetRegxOptionStr.l10, "onlyNumber", value);
    addItem(aList, SycmsLanguage.Expand.GetRegxOptionStr.l11, "onlyLetter", value);
    addItem(aList, SycmsLanguage.Expand.GetRegxOptionStr.l12, "noSpecialCaracters", value);
    addItem(aList, SycmsLanguage.Expand.GetRegxOptionStr.l13, "path", value);
    addItem(aList, SycmsLanguage.Expand.GetRegxOptionStr.l14, "SpecialCaracters", value);
    addItem(aList, SycmsLanguage.Expand.GetRegxOptionStr.l15, "FileName", value);
    addItem(aList, SycmsLanguage.Expand.GetRegxOptionStr.l16, "picext", value);
    addItem(aList, SycmsLanguage.Expand.GetRegxOptionStr.l17, "regex", value);
}

function GetFiledOptionsStr(objName, value,novalue) {
    var aList = $id(objName);
    if (novalue.length == 0 || novalue.indexOf("text") == -1) {
        addItem(aList, SycmsLanguage.Expand.GetFiledOptionsStr.l1, "text", value);
    }
    if (novalue.length == 0 || novalue.indexOf("author") == -1) {
        addItem(aList, SycmsLanguage.Expand.GetFiledOptionsStr.l2, "author", value);
    }
    if (novalue.length == 0 || novalue.indexOf("keyword") == -1) {
        addItem(aList, SycmsLanguage.Expand.GetFiledOptionsStr.l3, "keyword", value);
    }
    if (novalue.length==0 || novalue.indexOf("url") == -1) {
        addItem(aList, SycmsLanguage.Expand.GetFiledOptionsStr.l4, "url", value);
    }
    if (novalue.length == 0 || novalue.indexOf("title") == -1) {
        addItem(aList, SycmsLanguage.Expand.GetFiledOptionsStr.l5, "title", value);
    }
    if (novalue.length == 0 || novalue.indexOf("pic") == -1) {
        addItem(aList, SycmsLanguage.Expand.GetFiledOptionsStr.l6, "pic", value);
    }
    if (novalue.length == 0 || novalue.indexOf("video") == -1) {
        addItem(aList, SycmsLanguage.Expand.GetFiledOptionsStr.l7, "video", value);
    }
    if (novalue.length == 0 || novalue.indexOf("textarea") == -1) {
        addItem(aList, SycmsLanguage.Expand.GetFiledOptionsStr.l8, "textarea", value);
    }
    if (novalue.length == 0 || novalue.indexOf("editor") == -1) {
        addItem(aList, SycmsLanguage.Expand.GetFiledOptionsStr.l9, "editor", value);
    }
    if (novalue.length == 0 || novalue.indexOf("classify") == -1) {
        addItem(aList, SycmsLanguage.Expand.GetFiledOptionsStr.l10, "classify", value);
    }
    if (novalue.length == 0 || novalue.indexOf("options") == -1) {
        addItem(aList, SycmsLanguage.Expand.GetFiledOptionsStr.l11, "options", value);
    }
    if (novalue.length == 0 || novalue.indexOf("intelligent") == -1) {
        addItem(aList, SycmsLanguage.Expand.GetFiledOptionsStr.l12, "intelligent", value);
    }
    if (novalue.length == 0 || novalue.indexOf("number") == -1) {
        addItem(aList, SycmsLanguage.Expand.GetFiledOptionsStr.l13, "number", value);
    }
    if (novalue.length == 0 || novalue.indexOf("order") == -1) {
        addItem(aList, SycmsLanguage.Expand.GetFiledOptionsStr.l14, "order", value);
    }
    if (value == "addtime" || value == "updatetime") {
        value = "datetime";
    }
    if (novalue.length == 0 || novalue.indexOf("datetime") == -1) {
        addItem(aList, SycmsLanguage.Expand.GetFiledOptionsStr.l15, "datetime", value);
    }
    if (novalue.length == 0 || novalue.indexOf("style") == -1) {
        addItem(aList, SycmsLanguage.Expand.GetFiledOptionsStr.l16, "style", value);
    }
    if (novalue.length == 0 || novalue.indexOf("template") == -1) {
        addItem(aList, SycmsLanguage.Expand.GetFiledOptionsStr.l17, "template", value);
    }
    if (novalue.length == 0 || novalue.indexOf("posid") == -1) {
        addItem(aList, SycmsLanguage.Expand.GetFiledOptionsStr.l18, "posid", value);
    }
    if (novalue.length == 0 || novalue.indexOf("isaudit") == -1) {
        addItem(aList, SycmsLanguage.Expand.GetFiledOptionsStr.l19, "isaudit", value);
    }
    if (novalue.length == 0 || novalue.indexOf("filelist") == -1) {
        addItem(aList, SycmsLanguage.Expand.GetFiledOptionsStr.l20, "filelist", value);
    }
    if (novalue.length == 0 || novalue.indexOf("openmodel") == -1) {
        addItem(aList, SycmsLanguage.Expand.GetFiledOptionsStr.l21, "openmodel", value);
    }
    if (novalue.length == 0 || novalue.indexOf("googlemap") == -1) {
        addItem(aList, SycmsLanguage.Expand.GetFiledOptionsStr.l22, "googlemap", value);
    }
    if (novalue.length == 0 || novalue.indexOf("fieldcall") == -1) {
        addItem(aList, SycmsLanguage.Expand.GetFiledOptionsStr.l31, "fieldcall", value);
    }
    if (novalue.length == 0 || novalue.indexOf("htmlnojoin") == -1) {
        addItem(aList, SycmsLanguage.Expand.GetFiledOptionsStr.l32, "htmlnojoin", value);
    }
    if (novalue.length == 0 || novalue.indexOf("custom") == -1) {
        addItem(aList, SycmsLanguage.Expand.GetFiledOptionsStr.l37, "custom", value);
    }
}
function GetFiledTypeStr(num)
{
    var reval = "";
    switch (num.toLowerCase()) {
        case "id":///单行文本
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l23;
            break;
        case "userid":
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l36;
            break;
        case "ip":///IP
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l35;
            break;
        case "text":///单行文本
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l1;
            break;
        case "adduser":///单行文本
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l24;
            break;
        case "modiuser":///单行文本
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l25;
            break;
        case "textarea":///多行文本
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l8;
            break;
        case "number":///数字
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l13;
            break;
        case "options":
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l11;
            break;
        case "hits":///数字
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l26;
            break;
        case "editor":///编辑器
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l9;
            break;
        case "addtime":///时间格式
        case "updatetime":///时间格式
        case "datetime":///时间格式
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l15;
            break;
        case "style":///颜色和字形
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l16;
            break;
        case "catid":///栏目
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l27;
            break;
        case "speid":///专题
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l28;
            break;
        case "title":///标题
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l5;
            break;
        case "pic":///图片
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l6;
            break;
        case "url"://转向链接
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l4;
            break;
        case "author":///作者
        case "comefrom":///来源
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l2;
            break;
        case "keyword":///
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l3;
            break;
        case "template":///模板
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l17;
            break;
        case "posid":///属性
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l18;
            break;
        case "isaudit"://是否通过审核
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l19;
            break;
        case "video":///视频
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l7;
            break;
        case "classify":    //分类
        case "oneclassify":    //分类
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l10;
            break;
        case "intelligent":
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l12;
            break;
        case "filelist":
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l20;
            break;
        case "order":
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l14;
            break;
        case "openmodel":
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l21;
            break;
        case "field":
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l29;
            break;
        case "artiid":
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l30;
            break;
        case "googlemap":
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l22;
            break;
        case "fieldcall":
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l31;
            break;
        case "htmlnojoin":
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l32;
            break;
        case "custom":
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l37;
            break;
        case "isdel":
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l33;
            break;
        case "status":
            reval = SycmsLanguage.Expand.GetFiledOptionsStr.l34;
            break;
    }
    return reval;
}
//显示真或者是假的图标
function ShowTrueOrFalse(obj, ObjName) {
    return "<img src=\"images/icon/" + ((obj == "1" || obj.toLowerCase() == "true") ? "true" : "false") + ((ObjName != null && ObjName != undefined) ? ObjName : "_Gray") + ".png\" width=16 height=16 hspace=3 vspace=3 />";
}
function ShowDisable(obj)
{
    var str="";
    if(obj=="1")
    {
        str = "<font color='red'>" + SycmsLanguage.Expand.ShowDisable.l1 + "</font>";
    }
    else
    {
        str = SycmsLanguage.Expand.ShowDisable.l2;
    }
    return str;
}
function SaveModelFieldOrder(action,modleID)
{
    AjaxFun("Content/Model_Field/Lists.aspx?modleID=" + modleID + "&action=" + action, ReadInputValue("flex1"), SycmsLanguage.Expand.SaveModelFieldOrder.l1, '.Rnr');
}
function SaveFastBarOrder()
{
    AjaxFun("AdminFun/Lists_Comm.aspx?action=view", ReadInputValue("flex1"), SycmsLanguage.Expand.SaveModelFieldOrder.l1, ".Rnr");
}
//给默认值添加右键网页传值功能
function GetFieldOtherStrDefaultInput(objname)
{
    setTimeout(function () { TextClick($id(objname), 1, { g: true, h: true, b: true, c: true, d: true, e: true, x: true, y: true, z: true }) }, 10);
}
//
function GetVarName(obj1, obj2, isnoMy) {
    var v = obj2 ? $(obj2).find("option:selected").text() : "";
    if (isnoMy) {
        if (v.length == 0) {
            obj1.VarMember = null;
        } else {
            obj1.VarMember = [["1", "Relation", false, "", v]];
        }
    } else {
        if (v.length == 0) {
            obj1.VarMember = [["1", "q", false, "", "输入框值"], ["1", "v", false, "", "已保存值"]];
        } else {
            v = v.replace("[", "【").replace("]", "】");
            obj1.VarMember = [["1", "q", false, "", "输入框值"], ["1", "v", false, "", "已保存值"], ["1", "Relation", false, "", v]];
        }
    }
}
//输出html
function GetFiledOtherStr(num, ObjName, parameters, modelview, fieldcall, picformat, FieldID, videoFieldList, IsVidelToFLV, Type, CustomList) {
    if (!parameters) {
        parameters = "";
    }
    var reval = new Array();
    var parameters1 = parameters.split("|");
    FirefoxDisabled("Value_FW", 1);
    FirefoxDisabled("Value_YZ1", 1);
    FirefoxDisabled("Value_YZ2", 1);
    switch (num.toLowerCase()) {
        case "text": ///单行文本
            reval.push("  <tr>");
            reval.push("    <td width=\"80\" align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l2 + "</td>");
            reval.push("    <td><input name=\"obj1\" type=\"text\" id=\"obj1\" size=\"5\" class=\"validate[custom[onlyNumber],length[1,20]]\" value=\"" + (parameters1.length > 1 ? parameters1[0] : "50") + "\" maxlength=\"20\" /></td>");
            reval.push("  </tr>");
            reval.push("  <tr>");
            reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l1 + "</td>");
            reval.push("    <td><input name=\"obj2\" type=\"text\" id=\"obj2\" size=\"30\" value=\"" + (parameters1.length > 2 ? parameters1[1] : "") + "\" /></td>");
            reval.push("  </tr>");
            reval.push("  <tr>");
            reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l7 + "</td>");
            reval.push("    <td><input type=\"radio\" name=\"obj3\" id=\"obj3\" value=\"1\" " + (parameters1.length > 3 ? (parameters1[2] == "1" ? "checked" : "") : "") + " />" + SycmsLanguage.Expand.GetFiledOtherStr.l3 + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input name=\"obj3\" type=\"radio\" id=\"obj3\" value=\"0\" " + (parameters1.length > 3 ? (parameters1[2] == "0" ? "checked" : "") : "checked") + " />" + SycmsLanguage.Expand.GetFiledOtherStr.l4 + "</td>");
            reval.push("  </tr>");
            GetFieldOtherStrDefaultInput("obj2");
            break;
        case "textarea": ///多行文本
            reval.push("  <tr>");
            reval.push("    <td width=\"80\" align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l8 + "</td>");
            reval.push("    <td><input name=\"obj1\" type=\"text\" id=\"obj1\" size=\"5\" class=\"validate[custom[onlyNumber],length[1,20]]\" value=\"" + (parameters1.length > 1 ? parameters1[0] : "5") + "\" maxlength=\"20\" /></td>");
            reval.push("  </tr>");
            reval.push("  <tr>");
            reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l9 + "</td>");
            reval.push("    <td><input name=\"obj2\" type=\"text\" id=\"obj2\" size=\"5\" class=\"validate[custom[onlyNumber],length[1,20]]\" value=\"" + (parameters1.length > 2 ? parameters1[1] : "20") + "\" maxlength=\"20\" /></td>");
            reval.push("  </tr>");
            reval.push("  <tr>");
            reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l1 + "</td>");
            reval.push("    <td><input name=\"obj3\" type=\"text\" id=\"obj3\" size=\"30\" value=\"" + (parameters1.length > 3 ? parameters1[2] : "") + "\" /></td>");
            reval.push("  </tr>");
            reval.push("  <tr>");
            reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l10 + "</td>");
            reval.push("    <td><input type=\"radio\" name=\"obj4\" id=\"obj4\" value=\"1\" " + (parameters1.length > 4 ? (parameters1[3] == "1" ? "checked" : "") : "") + " />" + SycmsLanguage.Expand.GetFiledOtherStr.l3 + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input name=\"obj4\" type=\"radio\" id=\"obj4\" value=\"0\" " + (parameters1.length > 4 ? (parameters1[3] == "0" ? "checked" : "") : "checked") + " />" + SycmsLanguage.Expand.GetFiledOtherStr.l4 + "&nbsp;&nbsp;&nbsp;&nbsp;" + SycmsLanguage.Expand.GetFiledOtherStr.l11 + "</td>");
            reval.push("  </tr>");
            FirefoxDisabled("Value_YZ1");
            FirefoxDisabled("Value_YZ2");
            GetFieldOtherStrDefaultInput("obj3");
            break;
        case "options":
            reval.push("  <tr>");
            reval.push("    <td width=\"80\" align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l12 + "</td>");
            reval.push("    <td><textarea id=\"obj1\" name=\"obj1\" htmlformat=\"" + encodeURIComponent(SycmsLanguage.Expand.GetFiledOtherStr.l13) + "\" style=\"height:240px;width:395px;\">" + (parameters1.length > 1 ? parameters1[0].split("<br />").join("\r\n") : SycmsLanguage.Expand.GetFiledOtherStr.l13) + "</textarea><br/>一行一个换行输出<br/>格式“选项名称$选项值”,后面“回车符”；<br/>分隔符“hr$hr”，“hr组名$hr”</td>");
            reval.push("  </tr>");
            reval.push("  <tr>");
            reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l14 + "</td>");
            reval.push("    <td><input name=\"obj2\" type=\"radio\" id=\"obj2\" onclick=\"FirefoxDisabled('SaveValueType',1);FirefoxDisabled('obj4_0');FirefoxDisabled('obj4_1');$('#obj4_1').attr('checked','checked');\" value=\"0\" " + (parameters1.length > 2 ? (parameters1[1] == "0" ? "checked" : "") : "checked") + " />" + SycmsLanguage.Expand.GetFiledOtherStr.l5 + "&nbsp;<input name=\"obj2\" type=\"radio\" id=\"obj2\" onclick=\"FirefoxDisabled('SaveValueType');FirefoxDisabled('obj4_0');FirefoxDisabled('obj4_1');$('#obj4_1').attr('checked','checked');$('#obj5_0').attr('checked','checked');FirefoxDisabled('Value_FW',1);\" value=\"1\" " + (parameters1.length > 2 ? (parameters1[1] == "1" ? "checked" : "") : "") + " />" + SycmsLanguage.Expand.GetFiledOtherStr.l6 + "&nbsp;<input name=\"obj2\" type=\"radio\" id=\"obj2\" onclick=\"FirefoxDisabled('SaveValueType',1);FirefoxDisabled('obj4_0',1);FirefoxDisabled('obj4_1',1);\" value=\"2\" " + (parameters1.length > 2 ? (parameters1[1] == "2" ? "checked" : "") : "") + " />" + SycmsLanguage.Expand.GetFiledOtherStr.l15 + "[<input name=\"obj4\" type=\"radio\" id=\"obj4_0\" onclick=\"$('#obj5_0').attr('checked','checked');FirefoxDisabled('SaveValueType');FirefoxDisabled('Value_FW',1);\" size=\"3\"" + (parameters1.length > 4 ? (parameters1[3] == "1" ? " checked=\"checked\"" : "") : "") + " value=\"1\" />" + SycmsLanguage.Expand.GetFiledOtherStr.l3 + "<input name=\"obj4\" type=\"radio\" id=\"obj4_1\" onclick=\"FirefoxDisabled('SaveValueType',1);\" size=\"3\"" + (parameters1.length > 4 ? (parameters1[3] == "1" ? "" : " checked=\"checked\"") : " checked=\"checked\"") + " value=\"0\" />" + SycmsLanguage.Expand.GetFiledOtherStr.l4 + "]</td>");
            reval.push("  </tr>");
            reval.push("  <tr>");
            reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l1 + "</td>");
            reval.push("    <td><input name=\"obj3\" type=\"text\" id=\"obj3\" size=\"30\" value=\"" + (parameters1.length > 3 ? parameters1[2] : "") + "\" /></td>");
            reval.push("  </tr>");
            reval.push("  <tr id=\"SaveValueType\">");
            reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l16 + "</td>");
            reval.push("    <td><input name=\"obj5\" type=\"radio\" id=\"obj5_0\" onclick=\"FirefoxDisabled('Value_FW',1);\" size=\"5\" value=\"0\" " + (parameters1.length > 5 ? (parameters1[4] != "1" ? "checked" : "") : "checked") + " />" + SycmsLanguage.Expand.GetFiledOtherStr.l17 + "&nbsp;<input name=\"obj5\" type=\"radio\" id=\"obj5_1\" size=\"5\" onclick=\"FirefoxDisabled('Value_FW');\" value=\"1\" " + (parameters1.length > 5 ? (parameters1[4] == "1" ? "checked" : "") : "") + " />" + SycmsLanguage.Expand.GetFiledOtherStr.l18 + "</td>");
            reval.push("  </tr>");
            reval.push("  <tr>");
            reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l52 + "</td>");
            reval.push("    <td><input type=\"text\" size=\"5\" value=\"" + (parameters1.length > 5 ? parameters1[5] : "") + "\" maxlength=\"5\" id=\"obj6\" name=\"obj6\"/>&nbsp;px</td>");
            reval.push("  </tr>");
            reval.push("  <tr>");
            reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l61 + "</td>");
            reval.push("    <td><select id=\"obj7\" onchange=\"GetVarName($id('obj1'),true,1)\" name=\"obj7\"><option value=\"\">" + SycmsLanguage.Expand.GetFiledOtherStr.l38 + "</option>");
            if (videoFieldList && videoFieldList.length > 0) {
                for (var j = 0; j < videoFieldList.length; j++) {
                    if ((videoFieldList[j].FieldType == "options" || videoFieldList[j].FieldType == "intelligent") && videoFieldList[j].FieldID != FieldID) {
                        reval.push("<option value=\"" + videoFieldList[j].FieldID + "\">[" + videoFieldList[j].FieldName + "]" + videoFieldList[j].Text + "</option>");
                    }
                }
            }
            reval.push("</select>" + SycmsLanguage.Expand.GetFiledOtherStr.l62 + "</td>");
            reval.push("  </tr>");
            setTimeout(function () { TextClick($id("obj1"), 1, { b: true, c: true, d: true, e: true, x: true, y: true, z: true }); }, 10);
            if (parameters1.length > 2) {
                if (parameters1[1] == "1" || (parameters1[1] == "2" && parameters1[3] == "1")) {
                    setTimeout(function () { FirefoxDisabled('SaveValueType'); }, 10);
                }
                if (parameters1[1] != "2") {
                    setTimeout(function () { FirefoxDisabled("obj4_0"); FirefoxDisabled("obj4_1"); }, 10);
                }
                if (parameters1.length > 5) {
                    if (parameters1[4] == "1") {
                        FirefoxDisabled('Value_FW');
                    }
                }
                if (parameters1.length > 6 && parameters1[6] != "") {
                    setTimeout(function () {
                        $("#obj7").val(parameters1[6]);
                        GetVarName($id('obj1'), $id("obj7"), 1);
                    }, 10);
                }
            }
            GetFieldOtherStrDefaultInput("obj3");
            break;
        case "number": ///数字
            reval.push("  <tr>");
            reval.push("    <td width=\"80\" align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l19 + "</td>");
            reval.push("    <td><input name=\"obj1\" type=\"text\" id=\"obj1\" class=\"validate[custom[onlyNumber],length[1,20]]\" value=\"" + (parameters1.length > 1 ? parameters1[0] : "0") + "\" value=\"1\" size=\"3\" maxlength=\"20\" />-<input name=\"obj2\" class=\"validate[custom[onlyNumber],length[1,20]]\" type=\"text\" value=\"" + (parameters1.length > 2 ? parameters1[1] : "0") + "\" id=\"obj2\" size=\"3\" maxlength=\"20\" /></td>");
            reval.push("  </tr>");
            reval.push("  <tr>");
            reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l20 + "</td>");
            reval.push("    <td><select name=\"obj3\" id=\"obj3\"><option value=\"0\" " + (parameters1.length > 3 ? (parameters1[2] == "0" ? "selected" : "") : "") + ">0</option><option value=\"1\" " + (parameters1.length > 3 ? (parameters1[2] == "1" ? "selected" : "") : "") + ">1</option><option value=\"2\" " + (parameters1.length > 3 ? (parameters1[2] == "2" ? "selected" : "") : "") + ">2</option><option value=\"3\" " + (parameters1.length > 3 ? (parameters1[2] == "3" ? "selected" : "") : "") + ">3</option><option value=\"4\" " + (parameters1.length > 3 ? (parameters1[2] == "4" ? "selected" : "") : "") + ">4</option><option value=\"5\" " + (parameters1.length > 3 ? (parameters1[2] == "5" ? "selected" : "") : "") + ">5</option></select></td>");
            reval.push("  </tr>");
            reval.push("  <tr>");
            reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l1 + "</td>");
            reval.push("    <td><input name=\"obj4\" type=\"text\" id=\"obj4\" size=\"30\" value=\"" + (parameters1.length > 4 ? parameters1[3] : "0") + "\" /></td>");
            reval.push("  </tr>");
            FirefoxDisabled("Value_FW");
            FirefoxDisabled("Value_YZ1");
            FirefoxDisabled("Value_YZ2");
            GetFieldOtherStrDefaultInput("obj4");
            break;
        case "editor": ///编辑器
            reval.push("  <tr>");
            reval.push("    <td width=\"80\" align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l22 + "</td>");
            reval.push("    <td><input name=\"obj1\" type=\"radio\" id=\"obj1\" value=\"1\" " + (parameters1.length > 1 ? (parameters1[0] == "1" ? "checked" : "") : "") + " />" + SycmsLanguage.Expand.GetFiledOtherStr.l23 + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input name=\"obj1\" type=\"radio\" id=\"obj1\" value=\"2\" " + (parameters1.length > 1 ? (parameters1[0] == "2" ? "checked" : "") : "") + "/>" + SycmsLanguage.Expand.GetFiledOtherStr.l24 + "&nbsp;&nbsp;&nbsp;&nbsp;<input type=\"radio\" name=\"obj1\" id=\"obj1\" value=\"3\" " + (parameters1.length > 1 ? (parameters1[0] == "3" ? "checked" : "") : "checked") + "/>" + SycmsLanguage.Expand.GetFiledOtherStr.l25 + "</td>");
            reval.push("  </tr>");
            reval.push("  <tr>");
            reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l26 + "</td>");
            reval.push("    <td>" + SycmsLanguage.Expand.GetFiledOtherStr.l27 + "<input name=\"obj2\" type=\"text\" id=\"obj2\" size=\"5\" class=\"validate[custom[onlyNumber],length[0,5]]\" value=\"" + (parameters1.length > 2 ? parameters1[1] : "") + "\" maxlength=\"5\" /> px &nbsp;&nbsp;&nbsp;&nbsp;" + SycmsLanguage.Expand.GetFiledOtherStr.l28 + "<input name=\"obj3\" type=\"text\" value=\"" + (parameters1.length > 3 ? parameters1[2] : "") + "\" id=\"obj3\" size=\"5\" class=\"validate[custom[onlyNumber],length[0,5]]\" maxlength=\"5\" /> px</td>");
            reval.push("  </tr>");
            reval.push("  <tr>");
            reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l29 + "</td>");
            reval.push("    <td><input name=\"obj4\" type=\"radio\" value=\"1\" " + (parameters1.length >= 4 ? (parameters1[3] == "1" ? "checked" : "") : "") + " id=\"obj4_0\" /><label for=\"obj4_0\">" + SycmsLanguage.Expand.GetFiledOtherStr.l30 + "</label>&nbsp;<input name=\"obj4\" type=\"radio\" value=\"0\" " + (parameters1.length >= 4 ? (parameters1[3] != "1" ? "checked" : "") : "checked") + " id=\"obj4_1\" /><label for=\"obj4_1\">" + SycmsLanguage.Expand.GetFiledOtherStr.l31 + "</label></td>");
            reval.push("  </tr>");
            reval.push("  <tr>");
            reval.push("    <td align=\"right\">" + SycmsLanguage.CutPic.l1 + "</td>");
            reval.push("    <td><select name=\"obj5\" id=\"obj5\"><option value=\"\" " + (parameters1.length >= 5 ? (parameters1[4] == "" ? "selected" : "") : "") + ">" + SycmsLanguage.CutPic.l2 + "</option><option value=\"cut\" " + (parameters1.length >= 5 ? (parameters1[4] == "cut" ? "selected" : "") : "") + ">" + SycmsLanguage.CutPic.l3 + "</option><option value=\"cen\" " + (parameters1.length >= 5 ? (parameters1[4] == "cen" ? "selected" : "") : "") + ">" + SycmsLanguage.CutPic.l4 + "</option><option value=\"hwc\" " + (parameters1.length >= 5 ? (parameters1[4] == "hwc" ? "selected" : "") : "") + ">" + SycmsLanguage.CutPic.l5 + "</option><option value=\"h\" " + (parameters1.length >= 5 ? (parameters1[4] == "h" ? "selected" : "") : "") + ">" + SycmsLanguage.CutPic.l6 + "</option><option value=\"w\" " + (parameters1.length >= 5 ? (parameters1[4] == "w" ? "selected" : "") : "") + ">" + SycmsLanguage.CutPic.l7 + "</option></select>&nbsp;&nbsp;<input type=\"checkbox\" name=\"obj10\" value=\"1\"" + (parameters1.length >= 10 ? (parameters1[9] == "1" ? " checked=\"checked\"" : "") : "") + ">" + SycmsLanguage.Expand.GetFiledOtherStr.l53 + "&nbsp;&nbsp;" + SycmsLanguage.Expand.GetFiledOtherStr.l27 + "：<input name=\"obj6\" type=\"text\" id=\"obj6\" size=\"2\" class=\"validate[custom[onlyNumber],length[0,5]]\" value=\"" + (parameters1.length >= 6 ? parameters1[5] : "") + "\" maxlength=\"5\" /> px &nbsp;&nbsp;&nbsp;&nbsp;" + SycmsLanguage.Expand.GetFiledOtherStr.l28 + "：<input name=\"obj7\" type=\"text\" value=\"" + (parameters1.length >= 7 ? parameters1[6] : "") + "\" id=\"obj7\" size=\"2\" class=\"validate[custom[onlyNumber],length[0,5]]\" maxlength=\"5\" /> px</td>");
            reval.push("  </tr>");
            reval.push("  <tr>");
            reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l1 + "</td>");
            reval.push("    <td><textarea name=\"obj8\" cols=\"35\" rows=\"4\" value=\"" + (parameters1.length >= 8 ? parameters1[7].split("<br />").join("\r\n") : "") + "\" style=\"width:230px;\" id=\"obj8\"></textarea></td>");
            reval.push("  </tr>");
            reval.push("  <tr>");
            reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l51 + "</td>");
            reval.push("    <td><input name=\"obj9\" type=\"radio\" value=\"0\" " + (parameters1.length >= 9 ? (parameters1[8] != "1" ? "checked" : "") : "checked") + " id=\"obj9_0\" /><label for=\"obj9_0\">" + SycmsLanguage.Expand.GetFiledOtherStr.l3 + "</label>&nbsp;<input name=\"obj9\" type=\"radio\" value=\"1\" " + (parameters1.length >= 9 ? (parameters1[8] == "1" ? "checked" : "") : "") + " id=\"obj9_1\" /><label for=\"obj9_1\">" + SycmsLanguage.Expand.GetFiledOtherStr.l4 + "</label></td>");
            reval.push("  </tr>");
            reval.push("  <tr>");
            reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l56 + "</td>");
            reval.push("    <td><input name=\"obj11\" type=\"radio\" value=\"1\" " + (parameters1.length >= 11 ? (parameters1[10] == "1" ? "checked" : "") : "checked") + " id=\"obj11_0\" /><label for=\"obj11_0\">" + SycmsLanguage.Expand.GetFiledOtherStr.l57 + "</label>&nbsp;<input name=\"obj11\" type=\"radio\" value=\"0\" " + (parameters1.length >= 11 ? (parameters1[10] == "0" ? "checked" : "") : "") + " id=\"obj11_1\" /><label for=\"obj11_1\">" + SycmsLanguage.Expand.GetFiledOtherStr.l58 + "</label>&nbsp;<input name=\"obj11\" type=\"radio\" value=\"2\" " + (parameters1.length >= 11 ? (parameters1[10] == "2" ? "checked" : "") : "") + " id=\"obj11_2\" /><label for=\"obj11_2\">" + SycmsLanguage.Expand.GetFiledOtherStr.l59 + "</label></td>");
            reval.push("  </tr>");
            if (videoFieldList && videoFieldList.length > 0) {
                reval.push("  <tr>");
                reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l64 + "</td>");
                reval.push("    <td>" + SycmsLanguage.Expand.GetFiledOtherStr.l65 + "<select name=\"obj12\" id=\"obj12\"><option value=\"\">" + SycmsLanguage.Expand.GetFiledOtherStr.l38 + "</option>");
                for (var j = 0; j < videoFieldList.length; j++) {
                    if (videoFieldList[j].FieldType == "pic") {
                        reval.push("<option value=\"" + videoFieldList[j].FieldID + "\">" + videoFieldList[j].Text + "</option>");
                    }
                }
                reval.push("</select>&nbsp;</td>");
                reval.push("  </tr>");
            }
            FirefoxDisabled("Value_YZ1");
            FirefoxDisabled("Value_YZ2");
            FirefoxDisabled('longRange_2');
            if (parameters1.length > 12 && parameters1[11] != "") {
                setTimeout(function () {
                    $("#obj12").val(parameters1[11]);
                }, 50);
            }
            GetFieldOtherStrDefaultInput("obj8");
            break;
        case "addtime":
        case "updatetime":
        case "datetime": ///时间格式
            reval.push("  <tr>");
            reval.push("    <td width=\"80\" align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l1 + "</td>");
            reval.push("    <td><input name=\"obj1\" type=\"radio\" id=\"obj1\" value=\"0\" " + (parameters1.length > 1 ? (parameters1[0] == "0" ? "checked" : "") : "") + "/>" + SycmsLanguage.Expand.GetFiledOtherStr.l31 + "&nbsp;&nbsp;&nbsp;&nbsp;<input name=\"obj1\" type=\"radio\" id=\"obj1\" value=\"1\" " + (parameters1.length > 1 ? (parameters1[0] == "1" ? "checked" : "") : "checked") + "/>" + SycmsLanguage.Expand.GetFiledOtherStr.l33 + "</td>");
            reval.push("  </tr>");
            reval.push("  <tr>");
            reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l34 + "</td>");
            reval.push("    <td><input name=\"obj2\" type=\"radio\" id=\"obj2\" value=\"0\" " + (parameters1.length > 1 ? (parameters1[1] != "1" ? "checked" : "") : "") + "/>" + SycmsLanguage.Expand.GetFiledOtherStr.l35 + "&nbsp;&nbsp;&nbsp;&nbsp;<input name=\"obj2\" type=\"radio\" id=\"obj2\" value=\"1\" " + (parameters1.length > 1 ? (parameters1[1] == "1" ? "checked" : "") : "checked") + "/>" + SycmsLanguage.Expand.GetFiledOtherStr.l36 + "</td>");
            reval.push("  </tr>");
            FirefoxDisabled("Value_FW");
            FirefoxDisabled("Value_YZ1");
            FirefoxDisabled("Value_YZ2");
            break;
        case "style": ///颜色和字形
            reval.push("  <tr>");
            reval.push("    <td width=\"80\" align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l37 + "</td>");
            reval.push("    <td><select name=\"obj1\" id=\"obj1\" onchange=\"SelectColor(this);\">");
            reval.push("      <option value=\"\">" + SycmsLanguage.Expand.GetFiledOtherStr.l38 + "</option>");
            reval.push("      <option value=\"#000000\" " + (parameters1.length > 1 ? (parameters1[0] == "#000000" ? "selected" : "") : "") + " style=\"background:#000000\">&nbsp;&nbsp;&nbsp;&nbsp;</option>");
            reval.push("      <option value=\"#ffffff\" " + (parameters1.length > 1 ? (parameters1[0] == "#ffffff" ? "selected" : "") : "") + " style=\"background:#ffffff\">&nbsp;&nbsp;&nbsp;&nbsp;</option>");
            reval.push("      <option value=\"#008000\" " + (parameters1.length > 1 ? (parameters1[0] == "#008000" ? "selected" : "") : "") + " style=\"background:#008000\">&nbsp;&nbsp;&nbsp;&nbsp;</option>");
            reval.push("      <option value=\"#800000\" " + (parameters1.length > 1 ? (parameters1[0] == "#800000" ? "selected" : "") : "") + " style=\"background:#800000\">&nbsp;&nbsp;&nbsp;&nbsp;</option>");
            reval.push("      <option value=\"#808080\" " + (parameters1.length > 1 ? (parameters1[0] == "#808080" ? "selected" : "") : "") + " style=\"background:#808080\">&nbsp;&nbsp;&nbsp;&nbsp;</option>");
            reval.push("      <option value=\"#ffff00\" " + (parameters1.length > 1 ? (parameters1[0] == "#ffff00" ? "selected" : "") : "") + " style=\"background:#ffff00\">&nbsp;&nbsp;&nbsp;&nbsp;</option>");
            reval.push("      <option value=\"#00ff00\" " + (parameters1.length > 1 ? (parameters1[0] == "#00ff00" ? "selected" : "") : "") + " style=\"background:#00ff00\">&nbsp;&nbsp;&nbsp;&nbsp;</option>");
            reval.push("      <option value=\"#00ffff\" " + (parameters1.length > 1 ? (parameters1[0] == "#00ffff" ? "selected" : "") : "") + " style=\"background:#00ffff\">&nbsp;&nbsp;&nbsp;&nbsp;</option>");
            reval.push("      <option value=\"#ff00ff\" " + (parameters1.length > 1 ? (parameters1[0] == "#ff00ff" ? "selected" : "") : "") + " style=\"background:#ff00ff\">&nbsp;&nbsp;&nbsp;&nbsp;</option>");
            reval.push("      <option value=\"#ff0000\" " + (parameters1.length > 1 ? (parameters1[0] == "#ff0000" ? "selected" : "") : "") + " style=\"background:#ff0000\">&nbsp;&nbsp;&nbsp;&nbsp;</option>");
            reval.push("      <option value=\"#0000ff\" " + (parameters1.length > 1 ? (parameters1[0] == "#0000ff" ? "selected" : "") : "") + " style=\"background:#0000ff\">&nbsp;&nbsp;&nbsp;&nbsp;</option>");
            reval.push("      <option value=\"#008080\" " + (parameters1.length > 1 ? (parameters1[0] == "#008080" ? "selected" : "") : "") + " style=\"background:#008080\">&nbsp;&nbsp;&nbsp;&nbsp;</option>");
            reval.push("      </select>&nbsp;&nbsp;<input name=\"obj2\" type=\"checkbox\" id=\"radio\" value=\"1\" />" + SycmsLanguage.Expand.GetFiledOtherStr.l39 + "</td>");
            reval.push("  </tr>");
            FirefoxDisabled("Value_YZ1");
            FirefoxDisabled("Value_YZ2");
            break;
        case "order":
            reval.push("  <tr>");
            reval.push("    <td width=\"80\" align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l2 + "</td>");
            reval.push("    <td><input name=\"obj1\" type=\"text\" id=\"obj1\" class=\"validate[custom[onlyNumber],length[1,20]]\" value=\"" + (parameters1.length > 1 ? parameters1[0] : "50") + "\" size=\"5\" maxlength=\"20\" /></td>");
            reval.push("  </tr>");
            reval.push("  <tr>");
            reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l1 + "</td>");
            reval.push("    <td><input name=\"obj2\" type=\"text\" id=\"obj2\" value=\"" + (parameters1.length > 2 ? parameters1[1] : "0") + "\" size=\"30\" /></td>");
            reval.push("  </tr>");
            FirefoxDisabled("Value_FW");
            FirefoxDisabled("Value_YZ1");
            FirefoxDisabled("Value_YZ2");
            GetFieldOtherStrDefaultInput("obj2");
            break;
        case "title": ///标题
        case "template": ///模板
        case "filelist": //文件列表
        case "pic": ///图片
        case "url": ///转向链接
        case "video": ///视频
        case "keyword": ///关键词
        case "comefrom": ///来源
        case "author": ///作者
            reval.push("  <tr>");
            reval.push("    <td width=\"80\" align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l2 + "</td>");
            reval.push("    <td><input name=\"obj1\" type=\"text\" id=\"obj1\" class=\"validate[custom[onlyNumber],length[1,20]]\" value=\"" + (parameters1.length > 1 ? parameters1[0] : "50") + "\" size=\"5\" maxlength=\"20\" /></td>");
            reval.push("  </tr>");
            reval.push("  <tr>");
            reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l1 + "</td>");
            reval.push("    <td><input name=\"obj2\" type=\"text\" id=\"obj2\" value=\"" + (parameters1.length > 2 ? parameters1[1] : "") + "\" size=\"30\" /></td>");
            reval.push("  </tr>");
            if (num == "video" || num == "filelist") {
                reval.push("  <tr>");
                reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l55 + "</td>");
                reval.push("    <td><input name=\"obj3\" onclick=\"FirefoxDisabled('obj4TR');FirefoxDisabled('obj891011TR');\" type=\"radio\"" + (parameters1.length > 3 ? (parameters1[2] == "File" || parameters1[2] == "" ? " checked=\"checked\"" : "") : " checked=\"checked\"") + " id=\"obj3_0\" value=\"File\" /><label for=\"obj3_0\">" + SycmsLanguage.Expand.GetFiledOtherStr.l66 + "</label><input name=\"obj3\" type=\"radio\"" + (parameters1.length > 3 ? (parameters1[2] == "Video" ? " checked=\"checked\"" : "") : "") + " id=\"obj3_1\" onclick=\"FirefoxDisabled('obj4TR');FirefoxDisabled('obj891011TR');\" value=\"Video\" /><label for=\"obj3_1\">" + SycmsLanguage.Expand.GetFiledOtherStr.l67 + "</label><input name=\"obj3\" type=\"radio\"" + (parameters1.length > 3 ? (parameters1[2] == "Pic" ? " checked=\"checked\"" : "") : "") + " id=\"obj3_2\" onclick=\"FirefoxDisabled('obj4TR');FirefoxDisabled('obj891011TR',1);\" value=\"Pic\" /><label for=\"obj3_2\">" + SycmsLanguage.Expand.GetFiledOtherStr.l83 + "</label><input name=\"obj3\" type=\"radio\"" + (parameters1.length > 3 ? (parameters1[2] == "Other" ? " checked=\"checked\"" : "") : "") + " id=\"obj3_3\" onclick=\"FirefoxDisabled('obj4TR',1);FirefoxDisabled('obj891011TR');\" value=\"Other\" /><label for=\"obj3_3\">" + SycmsLanguage.Expand.GetFiledOtherStr.l68 + "</label></td>");
                reval.push("  </tr>");
                reval.push("  <tr id=\"obj4TR\">");
                reval.push("    <td align=\"right\">&nbsp;</td>");
                reval.push("    <td><input name=\"obj4\" type=\"text\" size=\"30\" value=\"" + (parameters1.length > 4 ? parameters1[3] : "") + "\" />" + SycmsLanguage.Expand.GetFiledOtherStr.l69 + "</td>");
                reval.push("  </tr>");
                reval.push("  <tr>");
                reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l79 + "</td>");
                reval.push("    <td><input name=\"obj3\" type=\"text\" value=\"" + (parameters1.length > 5 ? parameters1[4] : "") + "\" id=\"obj3\"/>B&nbsp;为空2G</td>");
                reval.push("  </tr>");
                var isvideo = false;
                if (IsVidelToFLV && IsVidelToFLV == 1 && videoFieldList && videoFieldList.length > 0) {
                    isvideo = true;
                    reval.push("  <tr id=\"obj567TR\">");
                    reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l70 + "</td>");
                    reval.push("    <td>" + SycmsLanguage.Expand.GetFiledOtherStr.l71 + "<select name=\"obj5\" id=\"obj5\"><option value=\"\">" + SycmsLanguage.Expand.GetFiledOtherStr.l38 + "</option>");
                    for (var j = 0; j < videoFieldList.length; j++) {
                        if (videoFieldList[j].FieldType == "pic") {
                            reval.push("<option value=\"" + videoFieldList[j].FieldID + "\">" + videoFieldList[j].Text + "</option>");
                        }
                    }
                    reval.push("</select><hr/>");
                    reval.push(SycmsLanguage.Expand.GetFiledOtherStr.l72 + "<select name=\"obj6\" id=\"obj6\"><option value=\"\">" + SycmsLanguage.Expand.GetFiledOtherStr.l38 + "</option>");
                    for (var j = 0; j < videoFieldList.length; j++) {
                        if (videoFieldList[j].FieldType == "filelist") {
                            reval.push("<option value=\"" + videoFieldList[j].FieldID + "\">" + videoFieldList[j].Text + "</option>");
                        }
                    }
                    reval.push("</select><hr/>");
                    reval.push(SycmsLanguage.Expand.GetFiledOtherStr.l73 + "<select name=\"obj7\" id=\"obj7\"><option value=\"\">" + SycmsLanguage.Expand.GetFiledOtherStr.l38 + "</option>");
                    for (var j = 0; j < videoFieldList.length; j++) {
                        if (videoFieldList[j].FieldType == "text") {
                            reval.push("<option value=\"" + videoFieldList[j].FieldID + "\">" + videoFieldList[j].Text + "</option>");
                        }
                    }
                    reval.push("</select>");
                    reval.push("</td>");
                    reval.push("  </tr>");
                }
                reval.push("  <tr id=\"obj891011TR\">");
                reval.push("    <td align=\"right\">" + (isvideo ? "" : "<input type=\"hidden\" name=\"obj5\"/><input type=\"hidden\" name=\"obj6\"/><input type=\"hidden\" name=\"obj7\"/>") + SycmsLanguage.CutPic.l1 + "</td>");
                reval.push("    <td><select name=\"obj8\" id=\"obj8\"><option value=\"\" " + (parameters1.length >= 8 ? (parameters1[7] == "" ? "selected" : "") : "") + ">" + SycmsLanguage.CutPic.l9 + "</option><option value=\"user\" " + (parameters1.length >= 8 ? (parameters1[7] == "user" ? "selected" : "") : "") + ">" + SycmsLanguage.CutPic.l8 + "</option><option value=\"cut\" " + (parameters1.length >= 8 ? (parameters1[7] == "cut" ? "selected" : "") : "") + ">" + SycmsLanguage.CutPic.l3 + "</option><option value=\"cen\" " + (parameters1.length >= 8 ? (parameters1[7] == "cen" ? "selected" : "") : "") + ">" + SycmsLanguage.CutPic.l4 + "</option><option value=\"hwc\" " + (parameters1.length >= 8 ? (parameters1[7] == "hwc" ? "selected" : "") : "") + ">" + SycmsLanguage.CutPic.l5 + "</option><option value=\"h\" " + (parameters1.length >= 8 ? (parameters1[7] == "h" ? "selected" : "") : "") + ">" + SycmsLanguage.CutPic.l6 + "</option><option value=\"w\" " + (parameters1.length >= 8 ? (parameters1[7] == "w" ? "selected" : "") : "") + ">" + SycmsLanguage.CutPic.l7 + "</option></select>&nbsp;&nbsp;<input type=\"checkbox\" name=\"obj9\" id=\"obj9\" value=\"1\"" + (parameters1.length >= 9 ? (parameters1[8] == "1" ? " checked=\"checked\"" : "") : "") + "/>" + SycmsLanguage.Expand.GetFiledOtherStr.l53 + "&nbsp;&nbsp;" + SycmsLanguage.Expand.GetFiledOtherStr.l27 + "：<input name=\"obj10\" type=\"text\" id=\"obj10\" size=\"2\" class=\"validate[custom[onlyNumber],length[0,5]]\" value=\"" + (parameters1.length >= 10 ? parameters1[9] : "") + "\" maxlength=\"5\" /> px&nbsp;&nbsp;" + SycmsLanguage.Expand.GetFiledOtherStr.l28 + "：<input name=\"obj11\" type=\"text\" value=\"" + (parameters1.length >= 11 ? parameters1[10] : "") + "\" id=\"obj11\" size=\"2\" class=\"validate[custom[onlyNumber],length[0,5]]\" maxlength=\"5\" /> px</td>");
                reval.push("  </tr>");
                if (!(parameters1.length > 3 && parameters1[2] == "Pic"))
                {
                    setTimeout(function () {
                        FirefoxDisabled('obj891011TR');
                    }, 50);
                }
                if (!(parameters1.length > 3 && parameters1[2] == "Other")) {
                    setTimeout(function () {
                        FirefoxDisabled('obj4TR');
                        if (parameters1.length > 5)
                            $("#obj5").val(parameters1[4]);
                        if (parameters1.length > 6)
                            $("#obj6").val(parameters1[5]);
                        if (parameters1.length > 7)
                            $("#obj7").val(parameters1[6]);
                    }, 50);
                }
            } else if (num == "pic") {
                reval.push("  <tr>");
                reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l78 + "</td>");
                reval.push("    <td><input name=\"obj3\" type=\"checkbox\"" + (parameters1.length > 3 ? (parameters1[2] == "1" ? " checked=\"checked\"" : "") : "") + " id=\"obj3\" value=\"1\" /></td>");
                reval.push("  </tr>");
                reval.push("  <tr>");
                reval.push("    <td align=\"right\">" + SycmsLanguage.CutPic.l1 + "</td>");
                reval.push("    <td><select name=\"obj4\"><option value=\"\" " + (parameters1.length >= 4 ? (parameters1[3] == "" ? "selected" : "") : "") + ">" + SycmsLanguage.CutPic.l9 + "</option><option value=\"user\" " + (parameters1.length >= 4 ? (parameters1[3] == "user" ? "selected" : "") : "") + ">" + SycmsLanguage.CutPic.l8 + "</option><option value=\"cut\" " + (parameters1.length >= 4 ? (parameters1[3] == "cut" ? "selected" : "") : "") + ">" + SycmsLanguage.CutPic.l3 + "</option><option value=\"cen\" " + (parameters1.length >= 4 ? (parameters1[3] == "cen" ? "selected" : "") : "") + ">" + SycmsLanguage.CutPic.l4 + "</option><option value=\"hwc\" " + (parameters1.length >= 4 ? (parameters1[3] == "hwc" ? "selected" : "") : "") + ">" + SycmsLanguage.CutPic.l5 + "</option><option value=\"h\" " + (parameters1.length >= 4 ? (parameters1[3] == "h" ? "selected" : "") : "") + ">" + SycmsLanguage.CutPic.l6 + "</option><option value=\"w\" " + (parameters1.length >= 4 ? (parameters1[3] == "w" ? "selected" : "") : "") + ">" + SycmsLanguage.CutPic.l7 + "</option></select>&nbsp;&nbsp;<input type=\"checkbox\" name=\"obj5\" value=\"1\"" + (parameters1.length >= 5 ? (parameters1[4] == "1" ? " checked=\"checked\"" : "") : "") + ">" + SycmsLanguage.Expand.GetFiledOtherStr.l53 + "&nbsp;&nbsp;" + SycmsLanguage.Expand.GetFiledOtherStr.l27 + "：<input name=\"obj6\" type=\"text\" id=\"obj6\" size=\"2\" class=\"validate[custom[onlyNumber],length[0,5]]\" value=\"" + (parameters1.length >= 6 ? parameters1[5] : "") + "\" maxlength=\"5\" /> px &nbsp;&nbsp;&nbsp;&nbsp;" + SycmsLanguage.Expand.GetFiledOtherStr.l28 + "：<input name=\"obj7\" type=\"text\" value=\"" + (parameters1.length >= 7 ? parameters1[6] : "") + "\" id=\"obj7\" size=\"2\" class=\"validate[custom[onlyNumber],length[0,5]]\" maxlength=\"5\" /> px</td>");
                reval.push("  </tr>");
                if (picformat) {
                    reval.push("  <tr>");
                    reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l55 + "</td>");
                    reval.push("    <td>" + picformat + "</td>");
                    reval.push("  </tr>");
                }
            } else if (num == "keyword") {
                reval.push("  <tr>");
                reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l60 + "</td>");
                reval.push("    <td><input name=\"obj3\" type=\"checkbox\"" + (parameters1.length > 3 ? (parameters1[2] == "1" ? " checked=\"checked\"" : "") : "") + " value=\"1\" /></td>");
                reval.push("  </tr>");
                if (Type == 0) {
                    reval.push("  <tr>");
                    reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l74 + "</td>");
                    reval.push("    <td><input name=\"obj4\" type=\"checkbox\"" + (parameters1.length > 4 ? (parameters1[3] == "1" ? " checked=\"checked\"" : "") : "") + " value=\"1\" /></td>");
                    reval.push("  </tr>");
                    reval.push("  <tr>");
                    reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l76 + "</td>");
                    reval.push("    <td><input name=\"obj5\" type=\"text\" size=\"30\" value=\"" + (parameters1.length > 5 ? parameters1[4] : "") + "\" />" + SycmsLanguage.Expand.GetFiledOtherStr.l77 + "</td>");
                    reval.push("  </tr>");
                }
            } else if (num == "title" && Type == 0)
            {
                reval.push("  <tr>");
                reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l75 + "</td>");
                reval.push("    <td><input name=\"obj3\" type=\"checkbox\"" + (parameters1.length > 3 ? (parameters1[2] == "1" ? " checked=\"checked\"" : "") : "") + " value=\"1\" /></td>");
                reval.push("  </tr>");
                reval.push("  <tr>");
                reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l76 + "</td>");
                reval.push("    <td><input name=\"obj4\" type=\"text\" size=\"30\" value=\"" + (parameters1.length > 4 ? parameters1[3] : "") + "\" />" + SycmsLanguage.Expand.GetFiledOtherStr.l77 + "</td>");
                reval.push("  </tr>");
                reval.push("  <tr>");
                reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l80 + "</td>");
                reval.push("    <td><input name=\"obj5\" type=\"radio\"" + (parameters1.length > 5 ? (parameters1[4] == "1" || parameters1[4] == "2" ? "" : " checked=\"checked\"") : " checked=\"checked\"") + " value=\"0\" id=\"obj5_0\" /><label for=\"obj5_0\">" + SycmsLanguage.Expand.GetFiledOtherStr.l31 + "</label><input name=\"obj5\" type=\"radio\"" + (parameters1.length > 5 ? (parameters1[4] == "1" ? " checked=\"checked\"" : "") : "") + " value=\"1\" id=\"obj5_1\" /><label for=\"obj5_1\">" + SycmsLanguage.Expand.GetFiledOtherStr.l81 + "</label><input name=\"obj5\" type=\"radio\"" + (parameters1.length > 5 ? (parameters1[4] == "2" ? " checked=\"checked\"" : "") : "") + " value=\"2\" id=\"obj5_2\" /><label for=\"obj5_2\">" + SycmsLanguage.Expand.GetFiledOtherStr.l82 + "</label></td>");
                reval.push("  </tr>");
            }
            GetFieldOtherStrDefaultInput("obj2");
            break;
        case "isaudit":
        case "isdel":
        case "posid": ///属性
            reval.push("  <tr>");
            reval.push("    <td width=\"80\" align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l1 + "</td>");
            reval.push("    <td><input name=\"obj1\" type=\"radio\" id=\"obj1\" value=\"1\" " + (parameters1.length > 1 ? (parameters1[0] == "1" ? "checked" : "") : "") + "/>" + SycmsLanguage.Expand.GetFiledOtherStr.l3 + "&nbsp;&nbsp;&nbsp;&nbsp;<input name=\"obj1\" type=\"radio\" id=\"obj1\" value=\"0\" " + (parameters1.length > 1 ? (parameters1[0] == "0" ? "checked" : "") : "checked") + " />" + SycmsLanguage.Expand.GetFiledOtherStr.l4 + "</td>");
            reval.push("  </tr>");
            FirefoxDisabled("Value_FW");
            FirefoxDisabled("Value_YZ1");
            FirefoxDisabled("Value_YZ2");
            break;
        case "intelligent": //类别（智能）
        case "classify":    //类别
            reval.push("  <tr>");
            reval.push("    <td width=\"80\" align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l1 + "</td>");
            reval.push("    <td><input name=\"obj1\" type=\"text\" id=\"obj1\" value=\"" + (parameters1.length > 1 ? parameters1[0] : "") + "\" size=\"30\" /></td>");
            reval.push("  </tr>");
            if (num == "intelligent") {
                reval.push("  <tr>");
                reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l40 + "</td>");
                reval.push("    <td><input name=\"obj5\" type=\"radio\" id=\"obj5_0\" size=\"5\" onclick=\"FirefoxDisabled('obj6Change');\" value=\"0\" " + (parameters1.length > 5 ? (parameters1[4] != "1" ? "checked" : "") : "checked") + " />" + SycmsLanguage.Expand.GetFiledOtherStr.l41 + "&nbsp;<input name=\"obj5\" type=\"radio\" id=\"obj5_1\" onclick=\"FirefoxDisabled('obj6Change',1);\" size=\"5\" value=\"1\" " + (parameters1.length > 5 ? (parameters1[4] == "1" ? "checked" : "") : "") + " />" + SycmsLanguage.Expand.GetFiledOtherStr.l42 + "</td>");
                reval.push("  </tr>");
                reval.push("  <tr>");
                reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l43 + "</td>");
                reval.push("    <td><textarea name=\"obj3\" cols=\"35\" htmlformat=\"" + encodeURIComponent("{value: \"保存的ID\", name:\"显示的名称\"},") + "\" rows=\"4\" style=\"width:390px;height:160px;\" id=\"obj3\">" + (parameters1.length >= 3 ? parameters1[2].split("<br />").join("\r\n") : "") + "</textarea><br>" + SycmsLanguage.Expand.GetFiledOtherStr.l44 + "</td>");
                reval.push("  </tr>");
                setTimeout(function () {
                    TextClick($id("obj3"), 1, { b: true, c: true, d: true, e: true, j: true, x: true, y: true, z: true });
                    GetVarName($id("obj3"));
                }, 10);
            } else {
                reval.push("  <tr>");
                reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l52 + "</td>");
                reval.push("    <td><input type=\"hidden\" value=\"\" name=\"obj3\"><input type=\"hidden\" value=\"\" name=\"obj5\"><input type=\"text\" size=\"5\" value=\"" + (parameters1.length > 5 ? parameters1[5] : "") + "\" id=\"obj6\" name=\"obj6\"></td>");
                reval.push("  </tr>");
            }
            reval.push("  <tr>");
            reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l14 + "</td>");
            reval.push("    <td><input name=\"obj2\" type=\"radio\" id=\"obj2\" value=\"0\" " + (parameters1.length > 2 ? (parameters1[1] == "0" ? "checked" : "") : "checked") + " />" + SycmsLanguage.Expand.GetFiledOtherStr.l5 + "&nbsp;<input name=\"obj2\" type=\"radio\" id=\"obj2\" onclick=\"$('#obj4_0').attr('checked','checked');FirefoxDisabled('Value_FW',1);\" value=\"1\" " + (parameters1.length > 2 ? (parameters1[1] == "1" ? "checked" : "") : "") + " />" + SycmsLanguage.Expand.GetFiledOtherStr.l6 + "</td>");
            reval.push("  </tr>");
            reval.push("  <tr id=\"SaveValueType\">");
            reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l45 + "</td>");
            reval.push("    <td><input name=\"obj4\" type=\"radio\" id=\"obj4_0\" size=\"5\" onclick=\"FirefoxDisabled('Value_FW',1);\" value=\"0\" " + (parameters1.length > 4 ? (parameters1[3] != "1" ? "checked" : "") : "checked") + " />" + SycmsLanguage.Expand.GetFiledOtherStr.l17 + "&nbsp;<input name=\"obj4\" type=\"radio\" id=\"obj4_1\" size=\"5\" onclick=\"FirefoxDisabled('Value_FW');\" value=\"1\" " + (parameters1.length > 4 ? (parameters1[3] == "1" ? "checked" : "") : "") + " />" + SycmsLanguage.Expand.GetFiledOtherStr.l18 + "</td>");
            reval.push("  </tr>");
            if (num == "intelligent") {
                reval.push("  <tr id=\"obj6Change\">");
                reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l61 + "</td>");
                reval.push("    <td><select name=\"obj6\" onchange=\"GetVarName($id('obj3'),this)\" id=\"obj6\"><option value=\"\">" + SycmsLanguage.Expand.GetFiledOtherStr.l38 + "</option>");
                if (videoFieldList && videoFieldList.length > 0) {
                    for (var j = 0; j < videoFieldList.length; j++) {
                        if ((videoFieldList[j].FieldType == "options" || videoFieldList[j].FieldType == "text" || videoFieldList[j].FieldType == "intelligent" || videoFieldList[j].FieldType == "classify" || videoFieldList[j].FieldType == "number" || videoFieldList[j].FieldType == "fieldcall" || videoFieldList[j].FieldType == "htmlnojoin") && videoFieldList[j].FieldID != FieldID) {
                            reval.push("<option value=\"" + videoFieldList[j].FieldID + "\">[" + videoFieldList[j].FieldName + "]" + videoFieldList[j].Text + "</option>");
                        }
                    }
                }
                reval.push("</select></td>");
                reval.push("  </tr>");
                if (!(parameters1.length > 5 && parameters1[4] == "1")) {
                    setTimeout(function () { FirefoxDisabled('obj6Change'); }, 10);
                } else {
                    if (parameters1.length > 6)
                    {
                        setTimeout(function () {
                            $("#obj6").val(parameters1[5]);
                            GetVarName($id('obj3'), $id("obj6"));
                        }, 10);
                    }
                }
            }
            if (parameters1.length > 2) {
                if (parameters1.length > 4) {
                    if (parameters1[3] == "1") {
                        FirefoxDisabled('Value_FW');
                    }
                }
            }
            GetFieldOtherStrDefaultInput("obj1");
            break;
        case "openmodel":       //字段模型
            reval.push("  <tr>");
            reval.push("    <td width=\"80\" align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l46 + "</td>");
            reval.push("    <td><select name=\"obj1\" onchange=\"var OldValue=$(this).attr('OldValue');if(OldValue && OldValue!=$(this).val()){$('#obj1ViewTip').show();}else{$('#obj1ViewTip').hide()}\" id=\"obj1\">" + modelview + "</select><span id=\"obj1ViewTip\" style=\"display:none;\">&nbsp;<font color=red>注</font>:变换其它模型时，将删除原有数据。</span></td>");
            reval.push("  </tr>");
            reval.push("  <tr>");
            reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l47 + "</td>");
            reval.push("    <td><input name=\"obj2\" type=\"text\" id=\"obj2\" size=\"5\" class=\"validate[custom[onlyNumber],length[1,5]]\" value=\"" + (parameters1.length > 1 ? parameters1[1] : "") + "\" maxlength=\"5\" /></td>");
            reval.push("  </tr>");
            reval.push("  <tr>");
            reval.push("    <td align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l48 + "</td>");
            reval.push("    <td><input name=\"obj3\" type=\"radio\" id=\"obj3_0\" size=\"5\" " + (parameters1.length > 2 ? (parameters1[2] != "1" ? "checked" : "") : "checked") + " value=\"0\" />" + SycmsLanguage.Expand.GetFiledOtherStr.l49 + "<input name=\"obj3\" type=\"radio\" " + (parameters1.length > 2 ? (parameters1[2] == "1" ? "checked" : "") : "checked") + " id=\"obj3_1\" size=\"5\" value=\"1\" />" + SycmsLanguage.Expand.GetFiledOtherStr.l50 + "</td>");
            reval.push("  </tr>");
            if (parameters1[0].length > 0) {
                setTimeout(function () { $("#obj1").val(parameters1[0]).attr("OldValue", parameters1[0]); }, 10);
            }
            break;
        case "googlemap":       //地图
            reval.push("");
            FirefoxDisabled("Value_YZ1");
            FirefoxDisabled("Value_YZ2");
            break;
        case "fieldcall":       //插件调用
            reval.push("  <tr>");
            reval.push("    <td width=\"80\" align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l54 + "</td>");
            reval.push("    <td><select name=\"obj1\" class=\"validate[required]\" id=\"obj1\">" + fieldcall + "</select></td>");
            reval.push("  </tr>");
            if (parameters1[0].length > 0) {
                setTimeout(function () { $("#obj1").val(parameters1[0]); }, 10);
            }
            FirefoxDisabled("Value_YZ1");
            FirefoxDisabled("Value_YZ2");
            break;
        case "htmlnojoin":  //自定义无关联
            reval.push("  <tr>");
            reval.push("    <td width=\"80\" height=\"150\" align=\"right\">定义组件：<br/><input type=\"button\" icon=\"icon-addNew\" value=\"添加组件\" onclick=\"htmlnojoinhtmlFun()\"><textarea name=\"obj1\" id=\"obj1\" style=\"display:none;\"></textarea></td>");
            reval.push("    <td><ol id=\"htmlnojoinhtml\"><ol></td>");
            reval.push("  </tr>");
            if (parameters1.length > 0) {
                if (parameters1[0].length > 0) {
                    setTimeout(function () {
                        parameters1[0] = HTMLDeCode(parameters1[0]);
                        $("#obj1").val(parameters1[0]);
                        var objValue = eval("[" + parameters1[0] + "]");
                        for (var i1 = 0; i1 < objValue.length; i1++) {
                            htmlnojoinhtmlFunViewLi(objValue[i1].Type, null, objValue[i1].Other2);
                        }
                    }, 10);
                }
            }
            FirefoxDisabled("Value_YZ1");
            FirefoxDisabled("Value_YZ2");
            break;
        case "custom":
            reval.push("  <tr>");
            reval.push("    <td width=\"80\" align=\"right\">" + SycmsLanguage.Expand.GetFiledOtherStr.l84 + "</td>");
            reval.push("    <td><select name=\"obj1\" class=\"validate[required]\" id=\"obj1\">" + CustomList + "</select>&nbsp;&nbsp;<input type=\"checkbox\" " + ((parameters1.length > 1 && parameters1[1] == "1" ? "checked=\"checked\"" : "")) + " name=\"obj2\" id=\"obj2\" value=\"1\"/><label for=\"obj2\">" + SycmsLanguage.Expand.GetFiledOtherStr.l85 + "</label></td>");
            reval.push("  </tr>");
            if (parameters1.length > 0) {
                setTimeout(function () { $("#obj2").val(parameters1[0]); }, 10);
            }
            FirefoxDisabled("Value_YZ1");
            FirefoxDisabled("Value_YZ2");
            break;
    }
    if (reval.length > 0) {
        reval = "<table width=\"100%\" border=\"0\">" + reval.join("") + "</table>";
    }
    $(ObjName).html(reval).btnForMat();
}

function htmlnojoinhtmlFunModi(obj) {
    var objli = $(obj).parent().parent();
    var i = 0;
    var objlip = objli.prev();
    while (objlip.length > 0) {
        i++;
        objlip = objlip.prev();
    }
    i--;
    htmlnojoinhtmlFun(i);
}

function htmlnojoinhtmlFunDel(obj) {
    var objli = $(obj).parent().parent();
    var i = 0;
    var objlip = objli.prev();
    while (objlip.length>0) {
        i++;
        objlip = objlip.prev();
    }
    i--;
    objli.remove();
    var obj1Obj = $("#obj1");
    var objValue = eval("[" + obj1Obj.val() + "]");
    var str = "";
    for (var i1 = 0; i1 < objValue.length;i1++ ) {
        if (i1 != i) {
            str += "," + obj2str(objValue[i1]);
        }
    }
    obj1Obj.val(str.length > 1 ? str.substr(1) : "");
}

function obj2str(o) {//核心函数
    if (o == undefined) {
        return "";
    }
    var r = [];
    if (typeof o == "string") return "\"" + o.replace(/([\"\\])/g, "\\$1").replace(/(\n)/g, "\\n").replace(/(\r)/g, "\\r").replace(/(\t)/g, "\\t") + "\"";
    if (typeof o == "object") {
        if (!o.sort) {
            for (var i in o)
                r.push("\"" + i + "\":" + obj2str(o[i]));
            if (!!document.all && !/^\n?function\s*toString\(\)\s*\{\n?\s*\[native code\]\n?\s*\}\n?\s*$/.test(o.toString)) {
                r.push("toString:" + o.toString.toString());
            }
            r = "{" + r.join() + "}"
        } else {
            for (var i = 0; i < o.length; i++)
                r.push(obj2str(o[i]))
            r = "[" + r.join() + "]";
        }
        return r;
    }
    return o.toString().replace(/\"\:/g, '":""');
}

function htmlnojoinhtmlFunViewLi(type, obji, Other2) {
    var objStr = "<li style=\"padding:5px 0;border-bottom:solid 1px #c0c0c0;\"><span style=\"float:right;\"><a href=\"\" onclick=\"htmlnojoinhtmlFunModi(this);return false;\"><img src=\"images/icon/edit.png\" /></a> <a href=\"\" onclick=\"htmlnojoinhtmlFunDel(this);return false;\"><img src=\"images/icon/delete.png\" /></a></span>";
    if (obji != null) {
        if (type == "0") {
            $("#htmlnojoinhtml li").eq(obji).after(objStr + "<select style=\"width:150px;\"><option>下拉框</option></select>" + (Other2 ? "<img src=\"images/icon/link.png\" align=\"absmiddle\" title=\"联动\"/>" : "") + "</li>");
        } else {
            $("#htmlnojoinhtml li").eq(obji).after(objStr + "<input type=\"text\" readonly=\"readonly\" value=\"文本框\" style=\"width:150px;\"/></li>");
        }
    } else {
        if (type == "0") {
            $("#htmlnojoinhtml").append(objStr + "<select style=\"width:150px;\"><option>下拉框</option></select>" + (Other2 ? "<img src=\"images/icon/link.png\" align=\"absmiddle\" title=\"联动\"/>" : "") + "</li>");
        } else {
            $("#htmlnojoinhtml").append(objStr + "<input type=\"text\" readonly=\"readonly\" value=\"文本框\" style=\"width:150px;\"/></li>");
        }
    }
}

function htmlnojoinhtmlFun(obji) {
    var diag = new Dialog();
    var obj1Obj = $("#obj1");
    diag.Width = htmlnojoinhtmlFunHtml[1];
    diag.Height = htmlnojoinhtmlFunHtml[2];
    diag.Title = htmlnojoinhtmlFunHtml[0];
    diag.InnerHtml = ReplaceRegExpValue(htmlnojoinhtmlFunHtml[4], htmlnojoinhtmlFunHtml[2]);
    diag.OKEvent = function () {
        var str = "{";
        if ($id("T01_1").checked) {
            str += "\"Type\":\"0\",";
        } else {
            str += "\"Type\":\"1\",";
        }
        str += "\"Content\":\"" + encodeURIComponent($("#T10").val()) + "\",\"Title\":\"" + encodeURIComponent($("#T02").val()) + "\",\"Value\":\"" + ($id("T51_1").checked ? "1" : "0") + "\",\"Width\":\"" + $("#T50").val() + "\",\"Format\":\"" + $("#T20").val() + "\",\"Size\":\"" + $("#T30").val() + "-" + $("#T31").val() + "\",";
        str += "\"Other1\":\"" + encodeURIComponent($("#T80").val()) + "\",\"Other2\":\"" + encodeURIComponent($("#T70").val()) + "\",\"Other3\":\"\",\"Other4\":\"\",\"Other5\":\"\",\"Other6\":\"\",\"Other7\":\"\",\"Other8\":\"\",\"Other9\":\"\"";
        str += "}";
        if (obji != null) {
            var objValue = eval("[" + obj1Obj.val() + "]");
            var str1 = "";
            for (var i1 = 0; i1 < objValue.length; i1++) {
                if (i1 != obji) {
                    str1 += "," + obj2str(objValue[i1]);
                } else {
                    str1 += "," + str;
                }
            }
            obj1Obj.val(str1.length > 1 ? str1.substr(1) : "");
            htmlnojoinhtmlFunViewLi($id("T01_1").checked ? "0" : "1", obji, encodeURIComponent($("#T70").val()));
            $("#htmlnojoinhtml li").eq(obji).remove();
        } else {
            htmlnojoinhtmlFunViewLi($id("T01_1").checked ? "0" : "1",null, encodeURIComponent($("#T70").val()));
            if (obj1Obj.val().length == 0) {
                obj1Obj.val(str);
            } else {
                obj1Obj.val(obj1Obj.val() + "," + str);
            }
        }
        diag.close();
    };
    diag.show();
    $("#T01_1").bind("click", function () {
        $("#T10Tr").show();
        $("#T20Tr").hide();
        $("#T30Tr").hide();
        $("#T80Tr").show();
        $("#T70Tr").show();
    });
    $("#T01_2").bind("click", function () {
        $("#T10Tr").hide();
        $("#T20Tr").show();
        $("#T30Tr").show();
        $("#T80Tr").hide();
        $("#T70Tr").hide();
    });
    GetRegxOptionStr("T20");
    TextClick($id("T10"), 1, { b: true, c: true, d: true, e: true, x: true, y: true, z: true });
    var T70Html = "";
    var objValue = eval("[" + obj1Obj.val() + "]");
    for (var i = 0; i < objValue.length; i++) {
        if (objValue[i].Other1 != "") {
            if (obji == i) {
                break;
            } else if (obji != null && (i >= obji || objValue[i].Other2 == objValue[obji].Other1)) {
                break;
            }
            T70Html += "<option value=\"" + decodeURIComponent(objValue[i].Other1) + "\">" + decodeURIComponent(objValue[i].Other1) + "</option>";
        }
    }
    $("#T70").html("<option value=\"\">请选择</option>"+T70Html);
    if (obji != null) {
        if (objValue[obji].Type == "1") {
            $("#T01_2").attr("checked", "checked").trigger("click");
        } else {
            $("#T01_1").attr("checked", "checked").trigger("click");
        }
        $("#T10").val(decodeURIComponent(objValue[obji].Content))
        if (objValue[obji].Value != "1") {
            $("#T51_2").attr("checked", "checked")
        }
        $("#T02").val(decodeURIComponent(objValue[obji].Title));
        $("#T50").val(decodeURIComponent(objValue[obji].Width));
        $("#T20").val(decodeURIComponent(objValue[obji].Format));
        $("#T80").val(decodeURIComponent(objValue[obji].Other1));
        $("#T70").val(decodeURIComponent(objValue[obji].Other2));

        if (objValue[obji].Size.length > 0) {
            var sizea = objValue[obji].Size.split('-');
            $("#T30").val(sizea[0]);
            if (sizea.length > 1) {
                $("#T31").val(sizea[1]);
            }
        }
    } else {
        $("#T01_1").attr("checked", "checked");
        $("#T20Tr").hide();
        $("#T30Tr").hide();
    }
}

function ShowArtiBar(obj,num,AddName) {
    if (!AddName) {
        AddName = "";
    }
    for (var i = 0; i < num; i++) {
        try {
            document.getElementById("item" + AddName + i).style.display = "none";
            document.getElementById("itemLink" + AddName + i).className = "";
        } catch (e) { }
    }
    try {
        document.getElementById("item" + AddName + obj).style.display = "";
        document.getElementById("itemLink" + AddName + obj).className = "dq";
    } catch (e) { }
}

//字段搜索
function RemovegjSetup() {
    FirefoxDisabled("gjsetup");
    $("#LeftLike").val("");
    $("#RightLike").val("");
}
function gjsetupSelect(obj) {
    if (obj.selectedIndex >= 0) {
        var v = obj.options[obj.selectedIndex].value;
        var v1 = v.split("|");
        if (v1[3] == "1") {
            FirefoxDisabled("gjsetup", 1);
            $("#LeftLike").val("");
            $("#RightLike").val("");
            if (v1[2].length > 0) {
                v1[2] = decodeURIComponent(v1[2]);
                $id("LeftLike").value = RegExpValue(v1[2], "Left");
                $id("RightLike").value = RegExpValue(v1[2], "Right");
            }
        } else {
            RemovegjSetup();
        }
    }
}
function gjsetupSelectOk(obj) {
    var l = $id("LeftLike").value.Trim();
    var r = $id("RightLike").value.Trim();
    var v2 = "";
    if (l.length > 0) {
        v2 += "Left:" + l + ";";
    }
    if (r.length > 0) {
        v2 += "Right:" + r + ";";
    }
    if (v2.length > 0) {
        if (obj.selectedIndex >= 0) {
            var v = obj.options[obj.selectedIndex].value;
            var v1 = v.split("|");
            v1[2] = encodeURIComponent(v2);
            obj.options[obj.selectedIndex].value = v1.join("|");
            $("#gjsetupView").html("<font color=\"red\">高级设置成功。</font>");
            setTimeout(function () { $("#gjsetupView").html(""); }, 1500);
        }
    }
}