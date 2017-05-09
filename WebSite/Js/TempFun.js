//对XML进行写入时非数字的时候需要的用encodeURIComponent  读取时用decodeURIComponent

//日期方式
var DateList = new Array(new Array("日期", "Date", "1"),new Array("年", "Year", "1"), new Array("月", "Month", "1"), new Array("日", "Day", "1"), new Array("小时", "Hour", "1"), new Array("分钟", "Minute", "1"), new Array("秒", "Second", "1"), new Array("当前", "Now", "0"));
//排序方式
var WordSort = new Array(new Array("降序", "Desc"), new Array("升序", "Asc"));
//日期格式显示
var DateQuickList = new Array(new Array("2011-01-31", "YY04-MM-DD"), new Array("11-01-31", "YY02-MM-DD"), new Array("01-31", "MM-DD"), new Array("2011.01.31", "YY04.MM.DD"), new Array("11.01.31", "YY02.MM.DD"), new Array("01.31", "MM.DD"), new Array("2011年01月31日", "YY04年MM月DD日"), new Array("11年01月31日", "YY02年MM月DD日"), new Array("Jan 31 11", "MEJ DD YY02"), new Array("January 31 11", "MEA DD YY04"), new Array("01月31日", "MM月DD日"), new Array("2011-01-31 1:31", "YY04-MM-DD HH:MI"), new Array("11-01-31 1:31", "YY02.MM.DD HH:MI"), new Array("2011年01月31日1点31分", "YY04年MM月DD日HH点MI分"), new Array("11年01月31日1点31分", "YY02年MM月DD日HH点MI分"), new Array("GMT时间", "GMT时间"));

var DateFormatList = new Array(new Array("几天前，几小时前格式", "format"), new Array("相差秒", "SS"), new Array("相差分", "MI"), new Array("相差时", "HH"), new Array("相差天", "DD"));

//表单
var FormList = new Array();
//分页
var PageList = new Array();
//会员功能
var UserList = true;
//系统存在记录信息
var System_DataList = new Array(new Array("category", "sycms", 1), new Array("special", "sycms", 1), new Array("sycms_", "sycms", 0));
//或者
var AndOrList = new Array(new Array("", "请选择"));
///表达所对应的字段类型及替换
//1为数值  //2为字符串  //3为日期  //4为ntext字段,//5为小数点 //6为真假，这种字段不能使用等于。
var LabelJudge = new Array(new Array("等于绑定模板的当前 $$", "1", "SYS", 1), new Array("等于", "1,2,3,4,5,6", "=", 0), new Array("大于", "1,3,5", ">", 0), new Array("大于等于", "1,3,5", ">=", 0), new Array("小于", "1,3,5", "<", 0), new Array("小于等于", "1,3,5", "<=", 0), new Array("不等于", "1,2,3,4,5,6", "<>", 0), new Array("接收网页传值", "1,2,3,4,5,6", "GET", 0), new Array("不包含", "1,2,4", "NOTLIKE", 0), new Array("包含", "1,2,4", "LIKE", 0), new Array("左包含", "2,4", "LLIKE", 0), new Array("右包含", "2,4", "RLIKE", 0));

//Seo默认值
var SeoFunctionValue = "<sycms type=\"Seo\" name=\"C\" view=\"0,1,2\" at=\"::C.ClassId:GET\" rec=\"C,1;\" val=\"PageTitle,PageKeyWord,PageDescription;\" sys=\"true\" html=\"true\"> </sycms>";
//Navi默认值
var NaviFunctionValue = "<sycms type=\"Navigate\" name=\"C\" way=\"0\" word=\"Title:C.ClassName;Url:C.ClassUrl;\" at=\"::C.ClassId:GET\">%20%3E%3E%20</sycms>";
//SQL函数

var RegexpList = [["(\d+)", "匹配非负整数（正整数+0）"], ["([0-9]*[1-9][0-9]*)", "匹配正整数"], ["((-\d+)|(0+))", "匹配非正整数（负整数+0）"], ["(-[0-9]*[1-9][0-9]*)", "匹配负整数"], ["(-?\d+)", "匹配整数"], ["(\d+(\.\d+)?)", "匹配非负浮点数（正浮点数+ 0）"], ["(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))", "匹配正浮点数"], ["((-\d+(\.\d+)?)|(0+(\.0+)?))", "匹配非正浮点数（负浮点数+0）"], ["(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))", "匹配负浮点数"], ["((-?\d+)(\.\d+)?)", "匹配浮点数"], ["([A-Za-z]+)", "匹配由26个英文字母组成的字符串"], ["([A-Z]+)", "匹配由26个英文字母的大写组成的字符串"], ["([a-z]+)", "匹配由26个英文字母的小写组成的字符串"], ["([A-Za-z0-9]+)", "匹配由数字和26个英文字母组成的字符串"], ["(\w+)", "匹配由数字、26个英文字母或者下划线组成的字符串"], ["([\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+)", "匹配email地址"], ["((\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?)", "匹配url"], ["([\u4e00-\u9fa5])", "中文汉字"], ["(([^\/]*?)(?:\.\w+))", "文件名"]];

var SqlFunList = new Array(new Array("平均数", "avg", 1), new Array("最大数", "max", 1), new Array("最小数", "min", 1), new Array("求和", "sum", 1), new Array("求个数", "count", 1), new Array("重复", "distinct", 0));

var StringFunctionList = new Array(new Array("Pinyin", "转拼音"), new Array("Traditional", "转繁体"), new Array("Simplified", "转简体"));

var isIE = navigator.userAgent.indexOf('MSIE') != -1;
var strOFF = "┆";


//变量类型，变量名，是否区块变量，模型名字，变量中文名称
//0为区块变量，1为普通变量，2为模型变量
//[0/1/2,变量名,false,模型名称,变量中文名称]

//移除右键菜单，右上角的生成菜单不移除。
function RemoveMenu()
{
    $(".popUpMenu[id!='Category_Create']").remove();
}

///是否关闭分页
function PageDisable(objid) {
    var obj = $("#" + objid + "T1");
    if (obj && obj.length == 1) {
        var T1 = obj.val();
        var T2 = false;
        if (T1.length > 0) {
            var tv_name = "";
            for (var j1 = 0; j1 < WordList[T1].length; j1++) {
                if (WordList[T1][j1][8] == "1") {
                    tv_name = WordList[T1][j1][1];
                    break;
                }
            }
            if (tv_name.length > 0) {
                tv_name = MdbList[T1][1] + "." + tv_name + ":";
                var objoption = $("#" + objid + "T4>option");
                for (var j1 = 0; j1 < objoption.length; j1++) {
                    if (objoption.eq(j1).attr("value").indexOf(tv_name) != -1 && objoption.eq(j1).attr("value").indexOf(":=:") != -1) {
                        T2 = true;
                        break;
                    }
                }
            }
        }
        if (T2) {
            FirefoxDisabled(objid + "LoadPage");
            $("#" + objid + "LoadPage").attr("close", "true");
            $("#" + objid + "T13_1").removeAttr("checked").trigger('click');
        } else {
            $("#" + objid + "LoadPage").removeAttr("close");
            if ($("#" + objid + "T7_0_1").is(":checked")) {
                FirefoxDisabled(objid + "LoadPage", 1);
                FirefoxDisabled(objid + "T13_PageView");
            }
        }
    }
}


//提取字符串中的标签
function CmsLabelList(str) {
    //使用新方法，使标签显示的顺序一致
    var re = str.split("<sycms ");
    var mArr = new Array();
    var icount = re.length;
    var re1 = "";
    for (var i = 1; i < icount; i++) {
        re1 = re[i].split(">");
        if (re1[0].Right(1) == "/") {
            mArr.push("<sycms " + re1[0] + ">");
        } else {
            re1 = re[i].split("</sycms>");
            mArr.push("<sycms " + re1[0] + "</sycms>");
        }
    }
    re1 = null;
    return mArr;

    //原方法
    //var re = new RegExp("<sycms[^>]+/>", "img");
    //var mArr = str.match(re);
    //if (!(mArr instanceof Array)) mArr = [];
    //str = str.replace(re, "");
    //re = new RegExp("<sycms[^>]+>([\\s\\S]*?)</sycms>", "img");
    //var mArr1 = str.match(re);
    //if (!(mArr1 instanceof Array)) mArr1 = [];
    //return mArr.concat(mArr1);
}
//判断是否有关系
function CmsWordLabelGL(YWordClass, AddWordClass) {
    if (YWordClass) {
        if (("," + YWordClass).indexOf("," + AddWordClass + ",") == -1) {
            var AddWordClassStr1 = "";
            var AddWordClassStr2 = "";
            var AddSqlLink1 = "";
            var AddSqlLink2 = "";
            for (var i = 0; i < MdbList.length; i++) {
                if (AddWordClass == MdbList[i][1]) {
                    AddWordClassStr1 = MdbList[i][2];
                    AddSqlLink1 = MdbList[i][5];
                } else if (("," + YWordClass).indexOf("," + MdbList[i][1] + ",") != -1) {
                    AddWordClassStr2 += MdbList[i][2] + ",";
                    AddSqlLink2 += MdbList[i][5] + ",";
                }
            }
            var returnBo = false;
            if (AddWordClassStr1 || AddWordClassStr2) {
                for (var i = 0; i < MdbList.length; i++) {
                    if (AddWordClassStr1 && ("," + YWordClass).indexOf("," + MdbList[i][1] + ",") != -1) {
                        for (var j = 0; j < MdbConn[i].length; j++) {
                            if (AddWordClassStr1 == MdbConn[i][j][0] && AddSqlLink1 == MdbConn[i][j][3]) {
                                returnBo = true;
                                break;
                            }
                        }
                    } else if (AddWordClassStr2 && AddWordClass == MdbList[i][1]) {
                        for (var j = 0; j < MdbConn[i].length; j++) {
                            if (("," + AddWordClassStr2).indexOf("," + MdbConn[i][j][0] + ",") != -1 && ("," + AddSqlLink2).indexOf("," + MdbConn[i][j][3] + ",") != -1) {
                                returnBo = true;
                                break;
                            }
                        }
                    }
                    if (returnBo) {
                        break;
                    }
                }
            }
            if (!returnBo) {
                AddWordClass = "";
            }
        }
    }
    return AddWordClass;
}
//判断用户菜单是否显示
function CmsLabelViewUser(YqListid)
{
    var bo = false;
    if (YqListid) {
        bo = UserList;
    }
    return bo;
}
//判断当前插入的信息与右键能够插入的信息是否相符。
function CmsLabelVarListInspection(type, obj, YqListid) {
    if (obj) {
        var T = obj.T;
        if (T) {
            switch (type) {
                case "plus":
                case "Plus": //插件
                    {
                        return (T.a ? true : false);
                    }
                case "Form":
                    {
                        return (T.a ? true : false);
                    }
                case "List":
                    {
                        return (T.e ? true : false);
                    }
                case "Navigate":
                    {
                        return (T.f ? true : false);
                    }
                case "Get":
                    {
                        return (T.g ? true : false);
                    }
                case "Sys":
                    {
                        return (T.h ? true : false);
                    }
                case "Cookie":
                    {
                        return (T.i ? true : false);
                    }
                case "Var":
                    {
                        return (T.j ? true : false);
                    }
                case "VarValue":
                    {
                        return (T.k ? true : false);
                    }
                case "BasicTem":
                    {
                        return (T.l ? true : false);
                    }
                case "Template":
                    {
                        return (T.m ? true : false);
                    }
                case "PageList":
                    {
                        return (T.o ? true : false);
                    }
                case "TemSys":
                case "Nav":
                case "Seo":
                    {
                        return (T.p ? true : false);
                    }
                case "Factor_If":
                    {
                        return (T.b ? true : false);
                    }
                case "Factor_For":
                    {
                        return (T.c ? true : false);
                    }
                case "Factor_OR":
                    {
                        return (T.d ? true : false);
                    }
                case "Word":
                    {
                        if ($(obj).attr("IsList") != "0") {   //非常规标签语句
                            return true;
                        } else {
                            return false;
                        }
                    }
                case "Count":
                    {
                        return (T.q ? true : false);
                    }
                case "Sys_GoToUrl":
                    {
                        return (T.hh ? true : false);
                    }
                case "User_Login":
                    {//用户的要判断是否在用户模板下
                        return CmsLabelViewUser(YqListid);
                    }
            }
        }
    } else {
        return true;
    }
}

//返回时间的变量
function CmsLabelVarList(obj, SyCmsView) {
    var str = obj.value;
    var $obj = $(obj);
    var vArr=new Array();
    var mArr = CmsLabelList(str);
    var xml = new XML();
    var Sycmsviewdiv = null;
    if (SyCmsView) {
        Sycmsviewdiv = $(SyCmsView);
        Sycmsviewdiv.empty();
    }
    var name = "";
    var YqListid = $obj.attr("ListID");
    if (!YqListid || isNaN(parseInt(YqListid))) {
        YqListid = $("#YQ_listID").val();
    }
    var WordClass = $obj.attr("WordClass");
    var LabelListClass = $obj.attr("LabelListClass");
    if (!WordClass) {
        WordClass = "";
    }
    if (LabelListClass) {
        WordClass = LabelListClass + ",";
    }
    var ForWordClass = "";
    var NWordClass = "";
    obj.Save = true;
    var DivHtmlArray = new Array();
    $(mArr).each(function (Index) {
        var C = this;
        xml.SetXML("<?xml version='1.0' encoding='utf-8'?><xml>" + C + "</xml>");
        var type = decodeURIComponent(xml.getAttrib("xml/sycms", "type"));
        if (Sycmsviewdiv) {
            var LabelTrueFalse = CmsLabelVarListInspection(type, obj, YqListid);
            ForWordClass = "";
            name = ReturnSyCmaName(type, xml, function (WordName) { ForWordClass = WordName; });
            if (type == "Word") {
                ForWordClass = CmsWordLabelGL(WordClass, ForWordClass);
                if (ForWordClass && ("," + NWordClass).indexOf("," + ForWordClass + ",") == -1) {
                    NWordClass += ForWordClass + ",";
                }
            }
            var SaveFlaseTrue = (!ForWordClass && type == "Word") || !LabelTrueFalse;
            if (obj.Save && SaveFlaseTrue) {
                obj.Save = false;
            }
            //if (("," + WordClass).indexOf("," + WordName + ",") == -1) { WordClass += WordName + ","; $(obj).attr("WordClass", WordClass); } 
            DivHtmlArray.push("<div class=\"SycmsLabelCss\" style=\"-moz-user-select: none;" + (SaveFlaseTrue ? "color:red;" : "") + "\" onselectstart=\"return false;\" start=\"-1\" name=\"" + encodeURIComponent(type) + "\" id=\"" + SyCmsToID(C) + "\">" + (SaveFlaseTrue ? "<img src=\"Images/icon/exclamation.png\" alt=\"不可用\" style=\"float:right;\" />" : (type == "Template" ? "<img src=\"Images/icon/eye.png\" onclick=\"LoadTemEye('" + decodeURIComponent(xml.getAttrib("xml/sycms", "id")) + "','" + YqListid + "');\" style=\"float:right;\" />" : "")) + "<div style=\"display:none;\">" + encodeURIComponent(C) + "</div>" + (Index + 1) + "：" + name + "</div>");
        }
        if (type == "VarValue") {
            name = decodeURIComponent(xml.getAttrib("xml/sycms", "name"));
            mdbname = decodeURIComponent(xml.getAttrib("xml/sycms", "mdbname"));
            if (mdbname) {
                //变量类型，变量名，是否区块变量，模型名字，变量中文名称
                vArr.push([2, name, false, mdbname]);
            } else {
                var nameArray = name.split(",");
                for (var j = 0; j < nameArray.length; j++) {
                    if (nameArray[j].length > 0) {
                        vArr.push([1, nameArray[j], false]);
                    }
                }
            }
        }
    });
    if (Sycmsviewdiv) {
        Sycmsviewdiv.append(DivHtmlArray.join(""));
    }
    DivHtmlArray = null;
    $obj.attr("WordClass", NWordClass);
    xml.Dispose();
    xml = null;
    if (Sycmsviewdiv) {
        Sycmsviewdiv.find(".SycmsLabelCss").bind("click", { foo: obj }, function (event) {
            var c = $(this);
            var v = decodeURIComponent(c.find("div").html());
            var start = 0;
            var type = decodeURIComponent(c.attr("name"));
            var divstart = c.attr("start");
            if (this.className.indexOf("SycmsLabelCssHover") == -1 || !(divstart && divstart != "-1")) {
                var vindex = 0;
                var objlist = Sycmsviewdiv.find("div[id='" + this.id + "']");
                if (objlist.length > 1) {
                    objlist.each(function (Index) {
                        if (c.html() == $(this).html()) {
                            vindex = Index;
                        }
                    });
                }
                Sycmsviewdiv.find("div").removeClass("SycmsLabelCssHover");
                c.addClass("SycmsLabelCssHover");
                start = event.data.foo.value.indexOf(v);
                if (vindex != 0) {
                    var start1 = -1;
                    for (var i = 0; i < vindex; i++) {
                        start1 = event.data.foo.value.indexOf(v, start + 1);
                        if (start1 == -1) {
                            break;
                        } else {
                            start = start1;
                        }
                    }
                }
                if (isIE) {
                    if (navigator.userAgent.indexOf('MSIE 7') != -1 || navigator.userAgent.indexOf('MSIE 6') != -1) {
                        var str1 = event.data.foo.value.substr(0, start);
                        start = ClearEnterNum(str1);
                    }
                }
                c.attr("start", start);
            } else {
                start = parseFloat(divstart);
            }
            event.data.foo.blur();
            setCursorPosition(event.data.foo, start, start + v.length);
            event.data.foo.selectStr = v;
            c.attr("clickok", "1");
            return false;
        }).bind("dblclick", { foo: obj }, function (event) {
            var c = $(this);
            if (c.attr("clickok") != "1") {
                c.trigger("click");
            }
            c.removeAttr("clickok");
            var type = decodeURIComponent(c.attr("name"));
            var v = decodeURIComponent(c.find("div").html());
            event.data.foo.focus();
            varSelectText = getSelectedText(event.data.foo);
            if (varSelectText == v) {
                if (type.toLowerCase() == "template") {
                    MenuReadFun_Modi(event.data.foo, v);
                } else {
                    LabelFun(v, event.data.foo, type);
                }
            }
        });
    }
    return { Label: mArr, Tem: vArr };
}

//条件显示里规格成标语
function AtFunction(str) {
    var rstr = str;
    var mArr = CmsLabelList(str);
    var xml = new XML();
    for (var i = 0; i < mArr.length; i++) {
        xml.SetXML("<?xml version='1.0' encoding='utf-8'?><xml>" + mArr[i] + "</xml>");
        var type = decodeURIComponent(xml.getAttrib("xml/sycms", "type"));
        rstr = rstr.replace(mArr[i], ReturnSyCmaName(type, xml));
    }
    xml.Dispose();
    xml = null;
    return rstr;
}
//获取标签信息
function ReturnSyCmaName(type,xml,WordFun) {
    var name = "";
    var rstr = "";
    type = type.toLowerCase();
    switch (type) {
        case "seo":
            {
                name = decodeURIComponent(xml.getAttrib("xml/sycms", "name"));
                for (var i = 0; i < MdbList.length; i++) {
                    if (MdbList[i][1] == name) {
                        name = MdbList[i][0];
                        break;
                    }
                }
                rstr = "[Seo]" + name;
                break;
            }
        case "temsys":
            {
                rstr = "[系统区块]";
            }
        case "nav":
            {
                rstr = "[导航菜单]";
                break;
            }
        case "navigate":
            {
                name = decodeURIComponent(xml.getAttrib("xml/sycms", "name"));
                for (var i = 0; i < MdbList.length; i++) {
                    if (MdbList[i][1] == name) {
                        name = MdbList[i][0];
                        break;
                    }
                }
                rstr = "[面包屑]" + name;
                break;
            }
        case "list":
            {
                name = decodeURIComponent(xml.getAttrib("xml/sycms", "name"));
                var help = decodeURIComponent(xml.getAttrib("xml/sycms", "help"));
                if (help.length > 0) {
                    rstr = "[标签]" + help;
                } else {
                    for (var i = 0; i < MdbList.length; i++) {
                        if (MdbList[i][1] == name) {
                            name = MdbList[i][0];
                            break;
                        }
                    }
                    rstr = "[标签]未命名(" + name + ")";
                }
                break;
            }
        case "template":
            {
                style = decodeURIComponent(xml.getAttrib("xml/sycms", "style"));
                name = decodeURIComponent(xml.getChild("xml/sycms"));
                switch (style) {
                    case "Nav":
                        {
                            rstr = "[菜单]" + name;
                            break;
                        }
                    case "Sys":
                        {
                            rstr = "[系统区块]" + name;
                        }
                    default:
                        {
                            rstr = "[" + SycmsLanguage.Module.WinCreateChild.l1 + "]" + name;
                            break;
                        }
                }
                break;
            }
        case "basictem":
            {
                name = decodeURIComponent(xml.getAttrib("xml/sycms", "id"));
                rstr = "[基础样式]" + name;
                break;
            }
        case "factor_if":
            {
                var help = decodeURIComponent(xml.getAttrib("xml/sycms", "help"));
                if (help.length > 0) {
                    rstr = "[条件]IF：" + help;
                } else {
                    rstr = "[条件]IF";
                }
                break;
            }
        case "factor_for":
            {
                var help = decodeURIComponent(xml.getAttrib("xml/sycms", "help"));
                if (help.length > 0) {
                    rstr = "[条件]FOR：" + help;
                } else {
                    rstr = "[条件]FOR";
                }
                break;
            }
        case "factor_or":
            {
                var help = decodeURIComponent(xml.getAttrib("xml/sycms", "help"));
                if (help.length > 0) {
                    rstr = "[条件]OR：" + help;
                } else {
                    rstr = "[条件]OR";
                }
                break;
            }
        case "var":
            {
                name = decodeURIComponent(xml.getAttrib("xml/sycms", "name"));
                var strName = name.split(".");
                if (strName.length == 3) {
                    var tv6 = null;
                    var tv6_name = "";
                    name = strName[1] + "." + strName[2];
                    if (name.length > 0) {
                        var Name1 = name.split(".");
                        for (var j1 = 0; j1 < MdbList.length; j1++) {
                            if (MdbList[j1][1] == Name1[0]) {
                                tv6 = j1;
                                tv6_name = "{" + MdbList[j1][0] + "}";
                                break;
                            }
                        }
                        if (tv6 != null) {
                            for (var j1 = 0; j1 < WordList[tv6].length; j1++) {
                                if (WordList[tv6][j1][1] == Name1[1]) {
                                    tv6_name += WordList[tv6][j1][0]
                                    break;
                                }
                            }
                        }
                    }
                    if (tv6_name != null) {
                        rstr = "[变量]" + tv6_name;
                    }
                } else {
                    rstr = "[变量]" + name;
                }
                break;
            }
        case "varvalue":
            {
                name = decodeURIComponent(xml.getAttrib("xml/sycms", "name"));
                rstr = "[定义变量]" + name;
                break;
            }
        case "plus":
            {
                name = decodeURIComponent(xml.getAttrib("xml/sycms", "name"));
                rstr = "[插件]" + name;
                break;
            }
        case "form":
            {
                name = decodeURIComponent(xml.getAttrib("xml/sycms", "name"));
                rstr = "[表单]" + name;
                break;
            }
        case "word":
            {
                var tv6 = null;
                var tv6_name = "";
                name = decodeURIComponent(xml.getAttrib("xml/sycms", "name"));
                if (name.length > 0) {
                    var Name1 = name.split(".");
                    for (var j1 = 0; j1 < MdbList.length; j1++) {
                        if (MdbList[j1][1] == Name1[0]) {
                            tv6 = j1;
                            tv6_name = "[" + MdbList[j1][0] + "]";
                            break;
                        }
                    }
                    if (tv6 != null) {
                        for (var j1 = 0; j1 < WordList[tv6].length; j1++) {
                            if (WordList[tv6][j1][1] == Name1[1]) {
                                tv6_name += WordList[tv6][j1][0];
                                if (WordFun) {
                                    (WordFun)(MdbList[tv6][1]);
                                }
                                break;
                            }
                        }
                    }
                }
                if (tv6_name != null) {
                    rstr = tv6_name;
                }
                break;
            }
        case "get":
            {
                var tv6 = null;
                var tv6_name = "";
                name = decodeURIComponent(xml.getAttrib("xml/sycms", "name"));
                if (name.length > 0) {
                    var Name1 = name.split(".");
                    if (name.indexOf(".") != -1) {
                        for (var j1 = 0; j1 < MdbList.length; j1++) {
                            if (MdbList[j1][1] == Name1[0]) {
                                tv6 = j1;
                                tv6_name = "[" + MdbList[j1][0] + "]";
                                break;
                            }
                        }
                        if (tv6 != null) {
                            for (var j1 = 0; j1 < WordList[tv6].length; j1++) {
                                if (WordList[tv6][j1][1] == Name1[1]) {
                                    tv6_name += WordList[tv6][j1][0]
                                    break;
                                }
                            }
                        }
                        if (tv6_name.length > 0) {
                            tv6_name = "[传值]" + tv6_name;
                        }
                    } else {
                        tv6_name = "[传值]" + name;
                    }
                }
                if (tv6_name != null) {
                    rstr = tv6_name;
                }
                break;
            }
        case "sys":
            {
                var tv6 = null;
                var tv6_name = "";
                name = decodeURIComponent(xml.getAttrib("xml/sycms", "name"));
                var tv7 = null;
                if (name.length > 0) {
                    for (var j1 = 0; j1 < SysList.length; j1++) {
                        if (name == SysList[j1][1]) {
                            name = SysList[j1][0];
                            tv7 = SysList[j1][5];
                            break;
                        }
                    }
                    if (tv7) {
                        var style = decodeURIComponent(xml.getAttrib("xml/sycms", "style"));
                        if (style) {
                            var tv7arr = tv7.split(",");
                            for (var j1 = 0; j1 < tv7arr.length; j1++) {
                                var tv7arr1 = tv7arr[j1].split(":");
                                if (tv7arr1[0] && tv7arr1[1]) {
                                    name = name.replace(tv7arr1[0], RegExpValue(style, tv7arr1[1]));
                                }
                            }
                        }
                    }
                    tv6_name = "[系统]" + name;
                }
                if (tv6_name != null) {
                    rstr = tv6_name;
                }
                break;
            }
        case "cookie":
            {
                name = decodeURIComponent(xml.getAttrib("xml/sycms", "name"));
                rstr = "[缓存]" + name;
                break;
            }
        case "pagelist":
            {
                name = decodeURIComponent(xml.getAttrib("xml/sycms", "name"));
                switch (name.toLowerCase()) {
                    case "pagestring":
                        {
                            rstr = "分页位置";
                            break;
                        }
                    case "index":
                        {
                            rstr = "顺序号";
                            break;
                        }
                    case "pagestartrecord":
                        {
                            rstr = "分页开始记录";
                            break;
                        }
                    case "pageendrecord":
                        {
                            rstr = "分页结束记录";
                            break;
                        }
                    case "pageindex":
                        {
                            rstr = "分页顺序号";
                            break;
                        }
                    case "maxpage":
                        {
                            rstr = "最大分页数";
                            break;
                        }
                    case "maxcount":
                        {
                            rstr = "总记录数";
                            break;
                        }
                    case "page":
                        {
                            rstr = "当前页码";
                            break;
                        }
                }
                break;
            }
        case "count":
            {
                rstr = "[标签]表达式";
                break;
            }
        case "user_login":
            {
                rstr = "[会员]登录判断";
                break;
            }
        case "sys_gotourl":
            {
                rstr = "[系统]页面跳转";
                break;
            }
    }
    return rstr;
}

//去除重要 数组
function formatX(arr) {
    for (var i = 0; i < arr.length; i++) {
        for (var j = i + 1; j < arr.length; j++) {
            if (arr[j][1] == arr[i][1]) { arr.splice(j, 1);if (i >= j) {i--; } j--; }
        }
    }
    return arr;
}


//标签函数显示
//第一个参数为XML字符串 第二个为文本的IE，type 为类型 保存使用 Tobj为函数时用STobj传Tobj原来值
function LabelFun(string, Tobj, Type, ShowFun, OtherSave, STobj, TwoType) {
    var objid = "";
    var htmlformat = "";
    var SelecrValue = "";
    if (typeof (Tobj) == "function") {
        objid = GetObjID();
    } else {
        htmlformat = $(Tobj).attr("htmlformat");
        if (htmlformat == undefined || htmlformat.lenght == 0) {
            SelecrValue = getSelectedText(Tobj);
            if (SelecrValue == string) {
                SelecrValue = "";
            }
        } else {
            htmlformat = decodeURIComponent(htmlformat);
        }
        if ($("#" + Tobj.id).length >= 1) {
            objid = Tobj.id;
        } else {
            return "";
        }
    }
    var InputList = null;
	var e=getEvent();
	try{
		e.cancelBubble=true;
	}catch(ex){}
	if (string.length <= 0) {
	    var sType = Type.toLowerCase();
	    if (sType == "word" || sType == "pagelist" || sType == "basictem" || sType == "var" || sType == "sys" || sType == "get" || sType == "sys_gotourl" || sType == "user_login") {
	        string = "<sycms type=\"" + Type + "\" />";
	    } else {
	        string = "<sycms type=\"" + Type + "\"" + (TwoType ? " style=\"" + TwoType + "\"" : "") + ">\r\n\t</sycms>";
	    }
	}
	//取上级  变量信息
	var MemberList = new Array();
	InputList = $("#" + objid + "MemberList input");
	if (InputList.length > 0) {
	    for (i = 0; i < InputList.length; i = i + 3) {
	        if (InputList.eq(i).val().length > 0 && InputList.eq(i + 1).val().length > 0) {
	            MemberList.push([0,InputList.eq(i).val(),InputList.eq(i + 1).val().isDigit()]);
	        }
	    }
	}
	if (STobj && STobj.MemberList) {     //为了模板全局变量
	    MemberList = MemberList.concat(STobj.MemberList);
	}
	if (Tobj && Tobj.MemberList) {
	    MemberList = MemberList.concat(Tobj.MemberList);
	}
	if (MemberList) {
	    MemberList = formatX(MemberList);
	}
	InputList = null;
	var xml = new XML();
	xml.SetXML("<?xml version='1.0' encoding='utf-8'?><xml>" + string + "</xml>");
	var TypeHtml;          //显示代码
	if (Type == "Template") {
	    TwoType = decodeURIComponent(xml.getAttrib("xml/sycms", "style"));
	    if (TwoType) {
	        TypeHtml = eval("Label" + Type + TwoType + "Html");
	    } else {
	        TypeHtml = eval("Label" + Type + "Html");
	    }
	} else {
	    TypeHtml = eval("Label" + Type + "Html");
	}
	if (TypeHtml.length > 0) {
	    var H = parseInt(TypeHtml[2]);
	    if (H + 90 > Wh) {
	        H = Wh - 90;
	    }
	    var diag = new Dialog();
	    diag.Width = TypeHtml[1];
	    diag.Height = H;
	    diag.Title = TypeHtml[0];
	    diag.InnerHtml = ReplaceRegExpValue(TypeHtml[4].replace(/\$\$/g, objid).replace(/\$SyCmsLabel\$/g, encodeURIComponent(string)), H);
	    diag.OKEvent = function() {
	        var ReturnValue = ShowCallBack_Label(string, objid);
	        if (ReturnValue.length > 0) {
	            if (typeof (Tobj) == "function") {
	                (Tobj)(objid, ReturnValue, diag);
	            } else {
	                if (Tobj.type == "text") {
	                    ReturnValue = ReturnValue.replace(/\r\n/g, "");
	                    ReturnValue = ReturnValue.replace(/\n/g, "");
	                    ReturnValue = ReturnValue.replace(/\t/g, "");
	                }
	                //if (Tobj.zh == "1") {
	                //    ReturnValue = AtFunction(ReturnValue);
	                //}
	                InsertAtCaret(Tobj, ReturnValue);
	                diag.close();
	            }
	        }
	        ReturnValue = null;
	        RemoveMenu();
	        //document.write(ReturnValue);
	    };          //点击确定后调用的方法
	    diag.CancelEvent = function () {
	        diag.close();
	        diag = null;
	        RemoveMenu();
	    };
	    diag.show();
	    H = null;
	    TypeHtml = null;
	    if (OtherSave && typeof (OtherSave) == "function") {       //另存其它的
	        diag.addButton("next", "另存为", function() {
	            var ReturnValue = ShowCallBack_Label(string, objid);
	            if (ReturnValue.length > 0) {
	                if(Tobj.type=="text")
	                {
	                    ReturnValue=ReturnValue.replace(/\r\n/g,"");
                        ReturnValue=ReturnValue.replace(/\n/g,"");
                        ReturnValue=ReturnValue.replace(/\t/g,"");
	                }
	                (OtherSave)(objid, ReturnValue, diag);
	            }
	            RemoveMenu();
	            ReturnValue = null;
	        });
	    }
	    //判断是否需要滚动条
//	    if (TypeHtml[3] == "1") {
//	        $("#"+objid+"LabelList").jscroll({
//	            W: "15px"
//                        , BgUrl: "url(images/s_bg.gif)"
//                        , Bg: "right 0 repeat-y"
//                        , Bar: { Bd: { Out: "#a3c3d5", Hover: "#b7d5e6" }
//                            , Bg: { Out: "-45px 0 repeat-y", Hover: "-58px 0 repeat-y", Focus: "-71px 0 repeat-y" }
//                        }
//                        , Btn: { btn: true
//                            , uBg: { Out: "0 0", Hover: "-15px 0", Focus: "-30px 0" }
//                            , dBg: { Out: "0 -15px", Hover: "-15px -15px", Focus: "-30px -15px" }
//                        }
//                        , Fn: function() { }
//	        });
//	    }
	
	    var listID = $("#YQ_listID").val();
	
	    switch (Type.toLowerCase()) {
	        case "list":            //列表
	            {
	                //绑定上面显示的标签TAB
                    //常规显示
	                LabelTabFun(objid + "Table");
                    //条件
	                LabelTabFun(objid + "AT");
                    //排序
	                LabelTabFun(objid + "order");
	                //输出结果
	                LabelTabFun(objid + "Write");

	                $id(objid + "SubmitStyleWrite").MemberList = MemberList;
	                $id(objid + "SubmitStyleWrite").WordSelectObj = objid + "T1";
	                $id(objid + "SelectStyleModi").MemberList = MemberList;
	                $id(objid + "SelectStyleModi").WordSelectObj = objid + "T1";
	                //给控件绑定事件
	                TextClick($id(objid + "T21"), true, { b: true, c: true, d: true, e: true, g: true, h: true, i: true, j: true, o: true, z: true }, MemberList, Tobj, "#" + objid + "T21Viewtab", 1);
	                TextClick($id(objid + "T22"), true, { b: true, c: true, d: true, e: true, g: true, h: true, i: true, j: true, o: true, z: true }, MemberList, Tobj, "#" + objid + "T22Viewtab", 1);

	                $id(objid + "T11_2").onchange = function () {
	                    var str = this.options[this.selectedIndex].value;
	                    if (str.length > 0) {
	                        InsertAtCaret($id(objid + "T11_1"), "<sycms type=\"Word\" name=\"" + str + "\" />");
	                    }
	                    str = null;
	                }
                    //绑定模型
	                AddMdbList(["#" + objid + "T1"]);

	                //	                $id(objid + "T4Sub1").onclick = function ()//置顶
	                //	                {
	                //	                    moveToTop($id(objid + "T4"));
	                //	                    ATfun(objid, null, 1);
	                //	                }
	                $id(objid + "T4Sub2").onclick = function ()//向上移动
	                {
	                    moveUp($id(objid + "T4"));
	                    ATfun(objid, null, 1);
	                }
	                $id(objid + "T4Sub3").onclick = function ()//向下移动
	                {
	                    moveDown($id(objid + "T4"));
	                    ATfun(objid, null, 1);
	                }
	                //	                $id(objid + "T4Sub4").onclick = function ()//置底
	                //	                {
	                //	                    moveToBottom($id(objid + "T4"));
	                //	                    ATfun(objid, null, 1);
	                //	                }
	                $id(objid + "Sub9_1").onclick = function () //向上
	                {
	                    moveUp($id(objid + "T9"));
	                }
	                $id(objid + "Sub9_2").onclick = function ()//向下
	                {
	                    moveDown($id(objid + "T9"));
	                }

	                //关闭效果显示

	                // FirefoxDisabled(objid + "T4Sub1");
	                FirefoxDisabled(objid + "T4Sub2");
	                FirefoxDisabled(objid + "T4Sub3");
	                //FirefoxDisabled(objid + "T4Sub4");
	                FirefoxDisabled(objid + "T4Sub5");

	                FirefoxDisabled(objid + "T4_Sub2");
	                FirefoxDisabled(objid + "T4_Sub3");



	                //只可以填写数字
	                $id(objid + "T3_1").onkeyup = $id(objid + "T3_1").onafterpaste = function () {
	                    this.value = this.value.Digit();
	                }

	                $id(objid + "T3_2").onkeyup = $id(objid + "T3_2").onafterpaste = function () {
	                    this.value = this.value.Digit();
	                }

	                //绑定时间
	                DateListSelect($id(objid + "T4_5"));

	                //绑定
	                $("#" + objid + "T4_4").attr("LabelListClass", $(Tobj).attr("LabelListClass"));
	                TextClick($id(objid + "T4_4"), true, { b: 1, c: 1, d: 1, e: 1, g: 1, h: 1, j: 1, i: 1, o: 1, z: 1 }, MemberList, Tobj);

	                //只可以填写数字
	                $id(objid + "T6").onkeyup = $id(objid + "T6").onafterpaste = function () {
	                    this.value = this.value.Digit();
	                }
	                $id(objid + "T7_1").onkeyup = $id(objid + "T7_1").onafterpaste = function () {
	                    this.value = this.value.Digit();
	                }
	                $id(objid + "T7_2").onkeyup = $id(objid + "T7_2").onafterpaste = function () {
	                    this.value = this.value.Digit();
	                }
	                //排序字段
	                SortSelect($id(objid + "T9_3"));

	                //绑定日期格式
	                DateQuickListSelect($id(objid + "T10_1"));

	                //绑定内容分页
	                PageListSelect($id(objid + "T13_2"));
	                addItem($id(objid + "T23_1"), "请选择内容中的分页样式", "");
	                PageListSelect($id(objid + "T23_1"));

	                //绑定变量
	                //$id(objid + "T3_1").zh = "1";
	                TextClick($id(objid + "T3_1"), true, { j: 1, z: 1 }, MemberList, Tobj);        //图片宽高
	                //$id(objid + "T3_2").zh = "1";
	                TextClick($id(objid + "T3_2"), true, { j: 1, z: 1 }, MemberList, Tobj);
	                //$id(objid + "T6").zh = "1";
	                TextClick($id(objid + "T6"), true, { j: 1, z: 1 }, MemberList, Tobj);         //标题字数
	                //$id(objid + "T7_1").zh = "1";
	                TextClick($id(objid + "T7_1"), true, { j: 1, z: 1 }, MemberList, Tobj);
	                //$id(objid + "T7_2").zh = "1";
	                TextClick($id(objid + "T7_2"), true, { j: 1, z: 1 }, MemberList, Tobj);
	                //$id(objid + "T12_2").zh = "1";
	                TextClick($id(objid + "T12_2"), true, { j: 1, z: 1 }, MemberList, Tobj);
	                //$id(objid + "T12_3").zh = "1";
	                TextClick($id(objid + "T12_3"), true, { j: 1, z: 1 }, MemberList, Tobj);
	                //$id(objid + "T13_3").zh = "1";
	                TextClick($id(objid + "T13_3"), true, { j: 1, z: 1 }, MemberList, Tobj);
	                //$id(objid + "T13_14").zh = "1";
	                TextClick($id(objid + "T13_14"), true, { j: 1, z: 1 }, MemberList, Tobj);
	                //$id(objid + "T13_5").zh = "1";
	                TextClick($id(objid + "T13_5"), true, { j: 1, z: 1 }, MemberList, Tobj);

	                //下面是有值的时候进行的判断修改

	                var Name = decodeURIComponent(xml.getAttrib("xml/sycms", "name"));      //Name值
	               
	                var T1Help = decodeURIComponent(xml.getAttrib("xml/sycms", "help"));
	                if (T1Help.length > 0) {
	                    $id(objid + "T1Help").value = T1Help;
	                }

	                var tv2 = "";
	                var obj = $id(objid + "T1");
	                $("#" + objid + "T11_1").attr("LabelListClass", Name);
	                for (var i = 0; i < MdbList.length; i++) {
	                    if (Name == MdbList[i][1]) {
	                        tv2 = i;
	                        break;
	                    }
	                }
	                if ((tv2 + "").length > 0) {
	                    $(obj).val(tv2);
	                    Label_Sell_Mdb(obj, objid);
	                }

	                //条件decodeURIComponent(       不使用 
	                BindAtView(objid, xml, "");
	                //排序
	                BindOrderView(objid, xml, "order");
	                //图片

	                var Pic = decodeURIComponent(xml.getAttrib("xml/sycms", "pic"));
	                if (Pic.length > 0) {
	                    var PicW = RegExpValue(Pic, "Width");
	                    var PicH = RegExpValue(Pic, "Height");
	                    var Cut = RegExpValue(Pic, "Cut");
	                    var Logo = RegExpValue(Pic, "Logo");
	                    if (PicW || PicW == "0") {
	                        $id(objid + "T3_1").value = AtFunction(PicW);
	                    }
	                    if (PicH || PicH == "0") {
	                        $id(objid + "T3_2").value = AtFunction(PicH);
	                    }
	                    $("#" + objid + "T3_3").val(Cut);
	                    if (Logo != "1") {
	                        $id(objid + "T3_4").checked = false;
	                    }
	                    PicW = null;
	                    PicH = null;
	                    Cut = null;
	                }
	                Pic = null;

	                //标题字数
	                var TitleNum = xml.getAttrib("xml/sycms", "title");
	                if (TitleNum.length > 0) {
	                    var Num = RegExpValue(TitleNum, "Num");
	                    var Added = RegExpValue(TitleNum, "Added");
	                    var Cut = RegExpValue(TitleNum, "Cut");
	                    if (Num || Num == "0") {
	                        $id(objid + "T6").value = AtFunction(Num);
	                    }
	                    $id(objid + "T6_2").value = Added;
	                    if (Cut.length > 0) {
	                        $id(objid + "T6_2_1").value = Cut;
	                        $id("icon_" + objid + "T6_2_1Button").value = "设置规则【有】";
	                    }
	                    Num = null;
	                    Added = null;
	                }
	                TitleNum = null;
                    //调用数量
	                BindReadNumView(objid, xml);

	                //日期格式
	                var Date = decodeURIComponent(xml.getAttrib("xml/sycms", "date"));
	                if (Date.length > 0) {
	                    $id(objid + "T10").value = Date;
	                }
	                Date = null;
	                if (!listID) {
	                    if (htmlformat) {
	                        $("#" + objid + "Writetabs").find("a").eq(0).hide();
	                    } else {
	                        $id(objid + "SubmitStyleWrite").isList = false;
	                        $("#" + objid + "SelectSpStyleModi").hide();
	                    }
	                } else {
	                    $id(objid + "SubmitStyleWrite").isList = true;
	                }
	                //引用样式
	                var StyleId = decodeURIComponent(xml.getAttrib("xml/sycms", "style"));
	                var StylemoduleId = decodeURIComponent(xml.getAttrib("xml/sycms", "stylemoduleid"));
	                if (StyleId.length > 0 || StylemoduleId.length > 0) {
	                    if (StyleId.length > 0) {
	                        $id(objid + "T11").value = "Sp:" + StyleId;
	                        parent.AjaxFun("Tem/Spread/Lists_Name.aspx", "spid=" + StyleId, "正在调入扩展样式模块信息...", function (html) {
	                            if (html.length > 0) {
	                                $("#" + objid + "T11View").html("扩展样式模块：" + html);
	                                $("#" + objid + "SelectStyleModi").btn().enable();
	                                $("#" + objid + "SelectSpStyleModi").btn().enable();
	                            }
	                        }, null, null, function () {
	                            diag.close();
	                            diag = null;
	                        });
	                    } else {
	                        $id(objid + "T11").value = "Style:" + StylemoduleId;
	                        parent.AjaxFun("Tem/StyleModule/Lists_Name.aspx", "id=" + StylemoduleId, "正在调入样式模块信息...", function (html) {
	                            if (html.length > 0) {
	                                $("#" + objid + "T11View").html("样式模块：" + html);
	                                $("#" + objid + "SelectStyleModi").btn().enable();
	                                $("#" + objid + "SelectSpStyleModi").btn().disable();
	                            }
	                        }, null, null, function () {
	                            diag.close();
	                            diag = null;
	                        });
	                    }
	                    //下面显示样式名称等相关Ajax调用。
	                } else {
	                    $id(objid + "T11").value = "0";
	                    var StyleValue = decodeURIComponent(xml.getChild("xml/sycms"));
	                    if (StyleValue == "\n\t") {
	                        StyleValue = "";
	                    }
	                    if (StyleValue == "") {
	                        if (htmlformat) {
	                            StyleValue = htmlformat;
	                        } else if(SelecrValue){
	                            StyleValue = SelecrValue;
	                        }
	                    }
	                    $("#" + objid + "T11_1").val(StyleValue)
	                    $("#" + objid + "Writetabs a").eq(1).click();
	                    //记住这个地方  默认样式要为0
	                }
	                StyleId = null;
	                //简单代码
	                TextClick($id(objid + "T11_1"), true, { a: 1, b: 1, c: 1, d: 1, e: 1, f: 1, g: 1, h: 1, hh: 1, i: 1, j: 1, k: 1, l: 1, o: 1, q: 1, x: 1, y: 1, z: 1 }, MemberList, Tobj, "#" + objid + "T1View1", 1);
	                //内容显示
	                var Content = xml.getAttrib("xml/sycms", "content");
	                if (Content.length > 0) {
	                    var ContentC = RegExpValue(Content, "Content");
	                    var ContentS = RegExpValue(Content, "Summary");
	                    var ContentCut = RegExpValue(Content, "ContentCut");
	                    var SummaryCut = RegExpValue(Content, "SummaryCut");
	                    var Added = RegExpValue(Content, "Added");
	                    if (ContentC || ContentC == "0") {
	                        $id(objid + "T12_1").checked = true;
	                        $id(objid + "T12_2").value = AtFunction(ContentC);
	                    }
	                    if (ContentCut.length > 0) {
	                        $id(objid + "T12_2_1").value = ContentCut;
	                        $id("icon_" + objid + "T12_2_1Button").value = "设置规则【有】";
	                    }
	                    if (ContentS || ContentS == "0") {
	                        $id(objid + "T12_1").checked = true;
	                        $id(objid + "T12_3").value = AtFunction(ContentS);
	                    }
	                    if (SummaryCut.length > 0) {
	                        $id(objid + "T12_3_1").value = SummaryCut;
	                        $id("icon_" + objid + "T12_3_1Button").value = "设置规则【有】";
	                    }
	                    $id(objid + "T12_4").value = Added;
	                    ContentC = null;
	                    ContentS = null;
	                    Added = null;
	                }
	                if (!$id(objid + "T12_1").checked) {
	                    FirefoxDisabled(objid + "T12_1ViewContent");
	                }
	                Content = null;
	                //内容分页
	                var ContentPage = decodeURIComponent(xml.getAttrib("xml/sycms", "contentpage"));
	                obj = $id(objid + "T23_1");
	                for (var j = 0; j < obj.options.length; j++) {
	                    if (obj.options[j].value == ContentPage) {
	                        obj.selectedIndex = j;
	                        break;
	                    }
	                }
	                ContentPage = "";
	                //行隔显示

	                var Interval = decodeURIComponent(xml.getAttrib("xml/sycms", "interval"));
	                if (Interval.length > 0) {
	                    var LineSpace = RegExpValue(Interval, "LineSpace");
	                    var LineNum = RegExpValue(Interval, "LineNum");
	                    $id(objid + "T13_4").value = LineSpace;
	                    if (LineNum || LineNum == "0") {
	                        $id(objid + "T13_5").value = AtFunction(LineNum);
	                    }
	                    LineSpace = null;
	                    LineNum = null;
	                }
	                Interval = null;
	                //分页显示
	                BindPageView(objid, xml);
	                break;
	            }
	        case "word":            //字段
	            {
	                //绑定日期格式
	                DateQuickListSelect($id(objid + "T10_1"));
	                DateFormatListSelect($id(objid + "T3_2"));
	                $id(objid + "T2_1").onkeyup = $id(objid + "T2_1").onafterpaste = function () {
	                    this.value = this.value.Digit();
	                }
	                StringfunctionListSelect($id(objid + "T2_3"));
	                //字段名称
	                var tv6 = null;
	                var tv7 = null;
	                var tv6_name = "";
	                var Name = decodeURIComponent(xml.getAttrib("xml/sycms", "name"));
	                var Stype = xml.getAttrib("xml/sycms", "style");

	                $id(objid + "T200_1").value = xml.getAttrib("xml/sycms", "special");
	                if ($id(objid + "T200_1").value.length > 0) {
	                    $id("icon_" + objid + "T200_1Button").value = "特殊取值【有】";
	                }
	                var Name1;
	                if (Name.length > 0) {
	                    Name1 = Name.split(".");
	                    for (var j1 = 0; j1 < MdbList.length; j1++) {
	                        if (MdbList[j1][1] == Name1[0]) {
	                            tv6 = j1;
	                            tv6_name = MdbList[j1][0];
	                            break;
	                        }
	                    }
	                }
	                if (tv6 != null) {
	                    for (var j1 = 0; j1 < WordList[tv6].length; j1++) {
	                        if (WordList[tv6][j1][1] == Name1[1]) {
	                            tv6_name += " >> " + WordList[tv6][j1][0];
	                            tv7 = WordList[tv6][j1][7];
	                            tv6 = WordList[tv6][j1][2];
	                            break;
	                        }
	                    }
	                }
	                if (tv7 && tv7 == "4") {
	                    FirefoxDisabled(objid + "PicView", 1);     //图片
	                } else {
	                    FirefoxDisabled(objid + "PicView");     //图片
	                }

	                var Fun = RegExpValue(Stype, "Fun");
	                var ii = 0;
	                //tv6为字段类型
	                $("#" + objid + "T15").hide();
	                if (tv6 != null) {
	                    $id(objid + "View1").innerHTML = tv6_name;
	                    if (tv6 == "1" || tv6 == "5") {
	                        FirefoxDisabled(objid + "View1_1");
	                        FirefoxDisabled(objid + "View1_2");
	                        FirefoxDisabled(objid + "View1_3", 1);
	                        FirefoxDisabled(objid + "View1_4", 1);
	                        //绑定SQL函数
	                        addItem($id(objid + "T15"), "选择运算方法", "");
	                        for (var i = 0; i < SqlFunList.length; i++) {
	                            addItem($id(objid + "T15"), SqlFunList[i][0], SqlFunList[i][1]);
	                            ii++;
	                            if (Fun == SqlFunList[i][1]) {
	                                $id(objid + "T15").selectedIndex = ii;
	                            }
	                        }
	                        $("#" + objid + "T15").show();
	                    } else if (tv6 == "2" || tv6 == "4") {
	                        FirefoxDisabled(objid + "View1_1", 1);
	                        FirefoxDisabled(objid + "View1_2");
	                        FirefoxDisabled(objid + "View1_3");
	                        FirefoxDisabled(objid + "View1_4", 1);
	                        if (tv6 == "2") {
	                            //绑定SQL函数
	                            addItem($id(objid + "T15"), "选择运算方法", "");
	                            ii = 0;
	                            for (var i = 0; i < SqlFunList.length; i++) {
	                                if (SqlFunList[i][2] == 0) {
	                                    ii++;
	                                    addItem($id(objid + "T15"), SqlFunList[i][0], SqlFunList[i][1]);
	                                    if (Fun == SqlFunList[i][1]) {
	                                        $id(objid + "T15").selectedIndex = ii;
	                                    }
	                                }
	                            }
	                            $("#" + objid + "T15").show();
	                        }
	                    } else if (tv6 == "3") {
	                        FirefoxDisabled(objid + "View1_1");
	                        FirefoxDisabled(objid + "View1_2", 1);
	                        FirefoxDisabled(objid + "View1_3");
	                        FirefoxDisabled(objid + "View1_4");
	                    } else {
	                        FirefoxDisabled(objid + "View1_1");
	                        FirefoxDisabled(objid + "View1_2");
	                        FirefoxDisabled(objid + "View1_3");
	                        FirefoxDisabled(objid + "View1_4", 1);
	                    }
	                }

	                //样式
	                var Wtype = RegExpValue(Stype, "Type");
	                var StyleViewObj = $("#" + objid + "StyleView").get(0);
	                StyleFunMV([[objid + "T1", 2]], new Array(Wtype), StyleViewObj);

	                var Format = decodeURIComponent(RegExpValue(Stype, "Format"));
	                var Time = decodeURIComponent(RegExpValue(Stype, "Time"));
	                var JsFat = decodeURIComponent(RegExpValue(Stype, "JsFat"));
	                var UrlFat = decodeURIComponent(RegExpValue(Stype, "UrlFat"));
	                var HtmlFat = decodeURIComponent(RegExpValue(Stype, "HtmlFat"));
	                var SqlFat = decodeURIComponent(RegExpValue(Stype, "SqlFat"));
	                if (Format.length > 0 || Time.length > 0) {
	                    if (Wtype == "1") { //字符串
	                        var Size = decodeURIComponent(RegExpValue(Stype, "Added"));
	                        var Fill = decodeURIComponent(RegExpValue(Stype, "Fill"));
	                        var Cut = decodeURIComponent(RegExpValue(Stype, "Cut"));
	                        var Clear = decodeURIComponent(RegExpValue(Stype, "Clear"));
	                        if (Cut.length > 0) {
	                            $id(objid + "T2_1_1").value = Cut;
	                            $id("icon_" + objid + "T2_1_1Button").value = "设置规则【有】";
	                        }
	                        if (Clear.length > 0) {
	                            $id(objid + "T2_4").checked = true;
	                        }
	                        StyleFunMV([[objid + "T2_1", 1], [objid + "T2_2", 1], [objid + "T2_3", 4]], new Array(Format, Size, Fill), StyleViewObj);
	                        Size = null;
	                    } else if (Wtype == "2") {//日期
	                        if (Time.length > 0) {
	                            StyleFunMV([[objid + "T3_2", 4]], new Array(Time), StyleViewObj);
	                        } else {
	                            StyleFunMV([[objid + "T3_1", 1]], new Array(Format), StyleViewObj);
	                        }
	                    } else if (Wtype == "3")//数字
	                    {
	                        StyleFunMV([[objid + "T4_1", 2]], new Array(Format), StyleViewObj);
	                    } else {  //标准时正则
	                        var Size = decodeURIComponent(RegExpValue(Stype, "Added"));
	                        var Fill = decodeURIComponent(RegExpValue(Stype, "Fill"));
	                        $id(objid + "T0_1").value = Format;
	                        $id(objid + "T0_2").value = Size;
	                        $id(objid + "T0_3").value = Fill;
	                        Size = decodeURIComponent(RegExpValue(Stype, "PicWidth"));
	                        Fill = decodeURIComponent(RegExpValue(Stype, "PicHeight"));
	                        Format = decodeURIComponent(RegExpValue(Stype, "PicCut"));
	                        var Logo = decodeURIComponent(RegExpValue(Stype, "PicLogo"));
	                        $id(objid + "T0_4").value = Size;
	                        $id(objid + "T0_5").value = Fill;
	                        $("#" + objid + "T0_6").val(Format);
	                        if (Logo != "1") {
	                            $id(objid + "T0_7").checked = false;
	                        }
	                        Size = null;
	                        Fill = null;
	                    }
	                } else {
	                    var Size = decodeURIComponent(RegExpValue(Stype, "PicWidth"));
	                    var Fill = decodeURIComponent(RegExpValue(Stype, "PicHeight"));
	                    Format = decodeURIComponent(RegExpValue(Stype, "PicCut"));
	                    var Logo = decodeURIComponent(RegExpValue(Stype, "PicLogo"));
	                    $id(objid + "T0_4").value = Size;
	                    $id(objid + "T0_5").value = Fill;
	                    $("#" + objid + "T0_6").val(Format);
	                    if (Logo != "1") {
	                        $id(objid + "T0_7").checked = false;
	                    }
	                    Size = null;
	                    Fill = null;
	                }
	                Wtype = null;
	                if (JsFat == "1") {
	                    $id(objid + "T16").checked = true;
	                }
	                if (UrlFat == "1") {
	                    $id(objid + "T16_1").checked = true;
	                }
	                if (HtmlFat == "1") {
	                    $id(objid + "T16_2").checked = true;
	                }
	                if (SqlFat == "1") {
	                    $id(objid + "T16_3").checked = true;
	                }
	                Format = null;
	                JsFat = null;
	                Name1 = null;
	                tv6 = null;
	                tv6_name = null;
	                name = null;
	                ii = null;
	                Fun = null;
	                var Pic = xml.getAttrib("xml/sycms", "fontpic")
	                if (Pic.length > 0) {
	                    $id(objid + "T36").checked = true;
	                    StyleFunMV([[objid + "T17", 2]], new Array(decodeURIComponent(RegExpValue(Pic, "Type"))), StyleViewObj);
	                    //字体
	                    $id(objid + "T18").value = decodeURIComponent(RegExpValue(Pic, "Font"));
	                    //大小
	                    $id(objid + "T19").value = decodeURIComponent(RegExpValue(Pic, "Size"));
	                    //颜色
	                    $id(objid + "T20").value = decodeURIComponent(RegExpValue(Pic, "Color"));
	                    $id(objid + "T20-view").style.backgroundColor = $id(objid + "T20").value;
	                    //宽度
	                    $id(objid + "T21").value = decodeURIComponent(RegExpValue(Pic, "Width"));
	                    //高度
	                    $id(objid + "T22").value = decodeURIComponent(RegExpValue(Pic, "Height"));
	                    //上
	                    $id(objid + "T23").value = decodeURIComponent(RegExpValue(Pic, "Top"));
	                    //左
	                    $id(objid + "T24").value = decodeURIComponent(RegExpValue(Pic, "Left"));
	                    //颜色
	                    $id(objid + "T25").value = decodeURIComponent(RegExpValue(Pic, "PColor"));
	                    $id(objid + "T25-view").style.backgroundColor = $id(objid + "T25").value;
	                    //图片
	                    $id(objid + "T26").value = decodeURIComponent(RegExpValue(Pic, "Pic"));
	                    //透明
	                    $id(objid + "T27").value = decodeURIComponent(RegExpValue(Pic, "Alpha"));

	                    var vt29 = decodeURIComponent(RegExpValue(Pic, "Style"));
	                    if (vt29.length > 0) {
	                        StyleFunMV([[objid + "T29", 3]], new Array(vt29), StyleViewObj);
	                    }

	                    //阴影
	                    if (RegExpValue(Pic, "Shadow") == "true") {
	                        $id(objid + "T28").checked = true;
	                    } else {
	                        $id(objid + "T28").checked = false;
	                    }
	                }
	                StyleViewObj = null;
	                jQuery("#" + objid + "T27").slider({ from: 0, to: 255, step: 1, smooth: true, round: 0, dimension: "&nbsp;", skin: "round" });
	                break;
	            }
	        case "seo":            //导航
	            {
	                //给控件绑定事件
	                var obj = $id(objid + "T1");
	                addItem(obj, "请选择", "");
	                for (var i = 0; i < MdbList.length; i++) {
	                    if (MdbConn[i]) {
	                        if (MdbConn[i].length > 0) {
	                            addItem(obj, MdbList[i][0], i);
	                        }
	                    }
	                }
	                FirefoxDisabled($("#" + objid + "T33"));
	                var ObjView = $("#" + objid + "ObjView");
	                var ObjFieldView = $("#" + objid + "ObjFieldView");

	                $("#" + objid + "T22_0,#" + objid + "T22_1,#" + objid + "T22_2").unbind().bind("click", function () {
	                    var FieldSetList = ObjFieldView.find("fieldset");
	                    var bo = true;
	                    for (i1 = 0; i1 < FieldSetList.length; i1++) {
	                        var SelectList = FieldSetList.eq(i1).find("select");
	                        var i = 0;
	                        for (var j = 0; j < SelectList.length; j++) {
	                            if ($id(objid + "T22_" + j).checked) {
	                                i++;
	                                FirefoxDisabled(SelectList.eq(j), 1);
	                            } else {
	                                FirefoxDisabled(SelectList.eq(j));
	                            }
	                        }
	                        if (i <= 1) {
	                            FirefoxDisabled($("#" + objid + "T33"), 1);
	                            if (i == 0) {
	                                FirefoxDisabled(SelectList.eq(this.id.replace(objid + "T22_", "")), 1);
	                                bo = false;
	                            }
	                        } else {
	                            $id(objid + "T33").checked = true;
	                            FirefoxDisabled($("#" + objid + "T33"));
	                        }
	                    }
	                    return bo;
	                });
	                StringfunctionListSelect($id(objid + "T44"));
	                var Name = decodeURIComponent(xml.getAttrib("xml/sycms", "name"));      //Name值
	                if (!Name) {
	                    if (SeoFunctionValue) {
	                        xml.SetXML("<?xml version='1.0' encoding='utf-8'?><xml>" + SeoFunctionValue + "</xml>");
	                        Name = decodeURIComponent(xml.getAttrib("xml/sycms", "name"));
	                    }
	                }
	                if (Name) {
	                    var tv2 = -1;

	                    for (var i = 0; i < MdbList.length; i++) {
	                        if (Name == MdbList[i][1]) {
	                            tv2 = i;
	                            break;
	                        }
	                    }
	                    if (tv2 != -1) {
	                        for (var i = 0; i < obj.options.length; i++) {
	                            if (obj.options[i].value.length > 0) {
	                                if (tv2 == obj.options[i].value) {
	                                    obj.selectedIndex = i;
	                                    Label_Sell_Mdb_Seo(obj, objid);
	                                    break;
	                                }
	                            }
	                        }
	                        var view = decodeURIComponent(xml.getAttrib("xml/sycms", "view"));
	                        var viewArr = view.split(",");
	                        var ishtml = decodeURIComponent(xml.getAttrib("xml/sycms", "html"));
	                        if (ishtml == "true") {
	                            $id(objid + "T33").checked = true;
	                        } else {
	                            $id(objid + "T33").checked = false;
	                        }
	                        var issys = decodeURIComponent(xml.getAttrib("xml/sycms", "sys"));
	                        if (issys == "true") {
	                            $id(objid + "T11").checked = true;
	                        }
	                        var at = decodeURIComponent(xml.getAttrib("xml/sycms", "at"));
	                        $id(objid + "T0").value = at.split(":")[2];
	                        var Rec = decodeURIComponent(xml.getAttrib("xml/sycms", "rec"));
	                        var Val = decodeURIComponent(xml.getAttrib("xml/sycms", "val"));
	                        if (Rec) {
	                            var RecArr = Rec.split(";");
	                            var ValArr = Val.split(";");
	                            for (var i = 0; i < RecArr.length; i++) {
	                                if (RecArr[i].length > 0) {
	                                    var obj1 = ObjView.find("select").eq(i).get(0);
	                                    for (var j = 0; i < obj1.options.length; j++) {
	                                        if (obj1.options[j].value.length > 0) {
	                                            if (RecArr[i] == obj1.options[j].value) {
	                                                obj1.selectedIndex = j;
	                                                Label_Sell_Mdb_SeoSe(obj1, objid);
	                                                break;
	                                            }
	                                        }
	                                    }
	                                }
	                            }
	                            for (var i = 0; i < ValArr.length; i++) {
	                                if (ValArr[i].length > 0) {
	                                    var obj1 = ObjFieldView.find("fieldset").eq(i).find("select");
	                                    var ValArrN = ValArr[i].split(",");
	                                    for (var j = 0; j < viewArr.length && j < ValArrN.length; j++) {
	                                        obj1.eq(viewArr[j]).val(ValArrN[j]);
	                                    }
	                                }
	                            }
	                        }
	                        if (view) {
	                            $id(objid + "T22_0").checked = false;
	                            $id(objid + "T22_1").checked = false;
	                            $id(objid + "T22_2").checked = false;
	                            for (var i = 0; i < viewArr.length; i++) {
	                                $id(objid + "T22_" + viewArr[i]).checked = true;
	                            }
	                            if (viewArr.length == 1) {
	                                FirefoxDisabled($("#" + objid + "T33"), 1);
	                            }
	                            var FieldSetList = ObjFieldView.find("fieldset");
	                            var bo = true;
	                            for (i1 = 0; i1 < FieldSetList.length; i1++) {
	                                var SelectList = FieldSetList.eq(i1).find("select");
	                                for (var j = 0; j < SelectList.length; j++) {
	                                    if (!$id(objid + "T22_" + j).checked) {
	                                        FirefoxDisabled(SelectList.eq(j));
	                                    }
	                                }
	                            }
	                        }
	                        var Style = decodeURIComponent(xml.getAttrib("xml/sycms", "style"));      //其它属性值
	                        if (Style) {
	                            var fill = RegExpValue(Style, "Fill");
	                            $("#" + objid + "T44").val(fill);
	                        }
	                    }
	                }
	                break;
	            }
	        case "navigate":            //导航
	            {
	                //给控件绑定事件
	                addItem($id(objid + "T1"), "请选择", "");
	                for (var i = 0; i < MdbList.length; i++) {
	                    if (MdbConn[i]) {
	                        for (var j = 0; j < MdbConn[i].length; j++) {
	                            if (MdbConn[i][j][0] == MdbList[i][2]) {
	                                addItem($id(objid + "T1"), MdbList[i][0], i);
	                            }
	                        }
	                    }
	                }

	                //	                $id(objid + "T4Sub1").onclick = function ()//置顶
	                //	                {
	                //	                    moveToTop($id(objid + "T4"));
	                //	                    ATfun(objid, null, 1);
	                //	                }
	                $id(objid + "T4Sub2").onclick = function ()//向上移动
	                {
	                    moveUp($id(objid + "T4"));
	                    ATfun(objid, null, 1);
	                }
	                $id(objid + "T4Sub3").onclick = function ()//向下移动
	                {
	                    moveDown($id(objid + "T4"));
	                    ATfun(objid, null, 1);
	                }
	                //	                $id(objid + "T4Sub4").onclick = function ()//置底
	                //	                {
	                //	                    moveToBottom($id(objid + "T4"));
	                //	                    ATfun(objid, null, 1);
	                //	                }

	                //关闭效果显示

	                //FirefoxDisabled(objid + "T4Sub1");
	                FirefoxDisabled(objid + "T4Sub2");
	                FirefoxDisabled(objid + "T4Sub3");
	                // FirefoxDisabled(objid + "T4Sub4");
	                FirefoxDisabled(objid + "T4Sub5");

	                FirefoxDisabled(objid + "T4_Sub2");
	                FirefoxDisabled(objid + "T4_Sub3");


	                //	                $id(objid + "T6Sub1").onclick = function ()//置顶
	                //	                {
	                //	                    moveToTop($id(objid + "T6"));
	                //	                    ATfun(objid, null, 1);
	                //	                }
	                $id(objid + "T6Sub2").onclick = function ()//向上移动
	                {
	                    moveUp($id(objid + "T6"));
	                    ATfun(objid, null, 1);
	                }
	                $id(objid + "T6Sub3").onclick = function ()//向下移动
	                {
	                    moveDown($id(objid + "T6"));
	                    ATfun(objid, null, 1);
	                }
	                //	                $id(objid + "T6Sub4").onclick = function ()//置底
	                //	                {
	                //	                    moveToBottom($id(objid + "T6"));
	                //	                    ATfun(objid, null, 1);
	                //	                }

	                //关闭效果显示

	                FirefoxDisabled(objid + "T6Sub1");
	                FirefoxDisabled(objid + "T6Sub2");
	                FirefoxDisabled(objid + "T6Sub3");
	                FirefoxDisabled(objid + "T6Sub4");
	                FirefoxDisabled(objid + "T6Sub5");

	                FirefoxDisabled(objid + "T6_Sub2");
	                FirefoxDisabled(objid + "T6_Sub3");

	                StringfunctionListSelect($id(objid + "T666_3"));

	                //绑定库名
	                var Name = decodeURIComponent(xml.getAttrib("xml/sycms", "name"));      //Name值

	                if (!Name) {
	                    if (NaviFunctionValue) {
	                        xml.SetXML("<?xml version='1.0' encoding='utf-8'?><xml>" + NaviFunctionValue + "</xml>");
	                        Name = decodeURIComponent(xml.getAttrib("xml/sycms", "name"));
	                    }
	                }
	                if (Name) {
	                    var tv2 = -1;
	                    var obj = $id(objid + "T1");

	                    for (var i = 0; i < MdbList.length; i++) {
	                        if (Name == MdbList[i][1]) {
	                            tv2 = i;
	                            break;
	                        }
	                    }
	                    if (tv2 != -1) {
	                        for (var i = 0; i < obj.options.length; i++) {
	                            if (obj.options[i].value.length > 0) {
	                                if (tv2 == obj.options[i].value) {
	                                    obj.selectedIndex = i;
	                                    Label_Sell_Mdb(obj, objid);
	                                    break;
	                                }
	                            }
	                        }
	                    }

	                    obj = null;


	                    //绑定时间
	                    DateListSelect($id(objid + "T4_5"));

	                    //Way显示方式
	                    var Way = decodeURIComponent(xml.getAttrib("xml/sycms", "way"));

	                    StyleFunMV([[objid + "T3", 2]], new Array(Way), $("#" + objid + "StyleView").get(0));
	                    Way = null;
	                    var word = decodeURIComponent(xml.getAttrib("xml/sycms", "word"));
	                    if (word.length > 0) {
	                        var word_1 = RegExpValue(word, "Title");
	                        var word_2 = RegExpValue(word, "Url");
	                        var fill = RegExpValue(word, "Fill");
	                        $("#" + objid + "T66_1").val(word_1);
	                        $("#" + objid + "T66_2").val(word_2);
	                        $("#" + objid + "T666_3").val(fill);
	                        word_1 = null;
	                        word_2 = null;
	                        fill = null;
	                    }
	                    word = null;

	                    //条件decodeURIComponent
	                    var At = xml.getAttrib("xml/sycms", "at");
	                    var AtArray = At.split(";");
	                    if (AtArray.length <= 2 && AtArray[0].Right(4)==":GET") {
	                        if (tv2 != -1) {
	                            var zjmess = WordListZJ(tv2);
	                            var AtStr = AtArray[0].split(":");
	                            if (Name + "." + zjmess.Name == AtStr[2] && AtStr[3] == "GET") {
	                                $("#" + objid + "T4_100Span").html(zjmess.Title + "[" + zjmess.Name + "]接收" + zjmess.Name + "的后台传值（绑定的栏目或内容）或者是网站传值（看区块设置）。");
	                                $("#" + objid + "T4_100").val(AtStr[2]);
	                            }
	                        }
	                    } else {
	                        $("#" + objid + "OldAT").show();
	                        $("#" + objid + "NewAT").hide();
	                        CreateAtInput(objid, At, "4");
	                    }
	                    At = null;
	                    Name = null;
	                    tv2 = null;
	                    At = xml.getAttrib("xml/sycms", "recat");
	                    CreateAtInput(objid, At, "6");
	                    At = null;
	                    //分隔符
	                    var Style = decodeURIComponent(xml.getChild("xml/sycms"));
	                    $id(objid + "T5").value = Style;
	                    Style = null;

	                    At = xml.getAttrib("xml/sycms", "current");
	                    $id(objid + "T55").value = At;
	                }
	                //绑定
	                TextClick($id(objid + "T4_4"), true, { b: 1, c: 1, d: 1, e: 1, g: 1, h: 1, j: 1, i: 1, o: 1, z: 1 }, MemberList, Tobj);
	                //绑定
	                TextClick($id(objid + "T6_4"), true, { b: 1, c: 1, d: 1, e: 1, g: 1, h: 1, j: 1, i: 1, o: 1, z: 1 }, MemberList, Tobj);
	                break;

	            }
	        case "factor_or":           //条件 或
	            {
	                var T1Help = decodeURIComponent(xml.getAttrib("xml/sycms", "help"));
	                if (T1Help.length > 0) {
	                    $id(objid + "T1Help").value = T1Help;
	                }
	                var s1 = "";
	                var icount = xml.getNodeslength("xml/sycms/item");
	                for (var i = 0; i < icount; i++) {
	                    s1 += decodeURIComponent(xml.getChild("xml/sycms/item", i + 1)) + ((i + 1) == icount ? "" : "||");
	                }
	                $id(objid + "T1").value = s1;
	                TextClick($id(objid + "T1"), 1, { a: 1, b: 1, c: 1, d: 1, e: 1, f: 1, g: 1, h: 1, i: 1, j: 1, l: 1, o: 1, q: 1, x: 1, y: 1, z: 1 }, MemberList, Tobj);
	                $("#" + objid + "T1").attr("IsList", $(Tobj).attr("IsList")).attr("LabelListClass", $(Tobj).attr("LabelListClass"));
	                s1 = null;
	                icount = null;
	                break;
	            }
	        case "factor_for":      //根据条件循环
	            {
	                var T1Help = decodeURIComponent(xml.getAttrib("xml/sycms", "help"));
	                if (T1Help.length > 0) {
	                    $id(objid + "T1Help").value = T1Help;
	                }
                    //选项切换
	                LabelTabFun(objid);

	                var For = xml.getAttrib("xml/sycms", "for");
	                var AT = decodeURIComponent(xml.getAttrib("xml/sycms", "at"));          //循环条件
	                if (AT.length > 0) {
	                    switch (For) {
	                        case "num":
	                            {
	                                //Form:;To:;Add:;
	                                var Form = decodeURIComponent(RegExpValue(AT, "From"));
	                                var To = decodeURIComponent(RegExpValue(AT, "To"));
	                                var Add = decodeURIComponent(RegExpValue(AT, "Add"));
	                                $id(objid + "T01_0").value = Form;
	                                $id(objid + "T01_1").value = To;
	                                $id(objid + "T01_2").value = Add;
	                                var s1 = decodeURIComponent(xml.getChild("xml/sycms"));
	                                $id(objid + "T02").value = s1;
	                                break;
	                            }
	                        case "string":
	                            {
                                    //String:;Split:;
	                                var String = decodeURIComponent(RegExpValue(AT, "String"));
	                                var Split = decodeURIComponent(RegExpValue(AT, "Split"));
	                                var Orderby = decodeURIComponent(RegExpValue(AT, "Orderby"));
	                                var Num = decodeURIComponent(RegExpValue(AT, "Num"));
	                                var Start = decodeURIComponent(RegExpValue(AT, "Start"));
	                                var Index = decodeURIComponent(RegExpValue(AT, "Index"));
	                                var Repeat = decodeURIComponent(RegExpValue(AT, "Repeat"));
	                                $id(objid + "T11_0").value = String;	                               
	                                $id(objid + "T11_1").value = Split;
	                                $id(objid + "T11_3").value = Num;
	                                $id(objid + "T11_4").value = Start;
	                                if (Orderby == "desc")
	                                {
	                                    $id(objid + "T11_2").checked = true;
	                                }
	                                if (Index == "true")
	                                {
	                                    $id(objid + "T11_5").checked = true;
	                                }
	                                if (Repeat == "true")
	                                {
	                                    $id(objid + "T11_6").checked = true;
	                                }
	                                var s1 = decodeURIComponent(xml.getChild("xml/sycms"));
	                                $id(objid + "T12").value = s1;
	                                $("#" + objid + "tabs a").eq(1).trigger("click");
	                                break;
	                            }
	                        default:
	                            {
	                                if (AT.length > 0 && AT.isDigit()) {
	                                    $id(objid + "T1").value = AT;
	                                }
	                                AT = null;
	                                var s1 = "";
	                                var icount = xml.getNodeslength("xml/sycms/item"); //循环实体
	                                for (var i = 0; i < icount; i++) {
	                                    s1 += decodeURIComponent(xml.getChild("xml/sycms/item", i + 1)) + ((i + 1) == icount ? "" : "||");
	                                }
	                                $id(objid + "T2").value = s1;
	                                s1 = null;
	                                icount = null;
	                                $("#" + objid + "tabs a").eq(2).trigger("click");
	                                break;
	                            }
	                    }
	                }
	                var IsList = $(Tobj).attr("IsList");
	                var LabelListClass = $(Tobj).attr("LabelListClass");
	                $("#" + objid + "T01_0").attr("IsList", IsList).attr("LabelListClass", LabelListClass);
	                TextClick($id(objid + "T01_0"), true, { b: 1, c: 1, d: 1, e: 1, g: 1, h: 1, i: 1, j: 1, l: 1, o: 1, q: 1, x: 1, y: 1, z: 1 }, MemberList, Tobj);
	                $("#" + objid + "T01_1").attr("IsList", IsList).attr("LabelListClass", LabelListClass);
	                TextClick($id(objid + "T01_1"), true, { b: 1, c: 1, d: 1, e: 1, g: 1, h: 1, i: 1, j: 1, l: 1, o: 1, q: 1, x: 1, y: 1, z: 1 }, MemberList, Tobj);
	                $("#" + objid + "T01_2").attr("IsList", IsList).attr("LabelListClass", LabelListClass);
	                TextClick($id(objid + "T01_2"), true, { b: 1, c: 1, d: 1, e: 1, g: 1, h: 1, i: 1, j: 1, l: 1, o: 1, q: 1, x: 1, y: 1, z: 1 }, MemberList, Tobj);
	                $("#" + objid + "T11_0").attr("IsList", IsList).attr("LabelListClass", LabelListClass);
	                TextClick($id(objid + "T11_0"), true, { b: 1, c: 1, d: 1, e: 1, g: 1, h: 1, i: 1, j: 1, l: 1, o: 1, q: 1, x: 1, y: 1, z: 1 }, MemberList, Tobj);
	                $("#" + objid + "T11_1").attr("IsList", IsList).attr("LabelListClass", LabelListClass);
	                TextClick($id(objid + "T11_1"), true, { b: 1, c: 1, d: 1, e: 1, g: 1, h: 1, i: 1, j: 1, l: 1, o: 1, q: 1, x: 1, y: 1, z: 1 }, MemberList, Tobj);
	                $("#" + objid + "T11_3").attr("IsList", IsList).attr("LabelListClass", LabelListClass);
	                TextClick($id(objid + "T11_3"), true, { b: 1, c: 1, d: 1, e: 1, g: 1, h: 1, i: 1, j: 1, l: 1, o: 1, q: 1, x: 1, y: 1, z: 1 }, MemberList, Tobj);
	                $("#" + objid + "T11_4").attr("IsList", IsList).attr("LabelListClass", LabelListClass);
	                TextClick($id(objid + "T11_4"), true, { b: 1, c: 1, d: 1, e: 1, g: 1, h: 1, i: 1, j: 1, l: 1, o: 1, q: 1, x: 1, y: 1, z: 1 }, MemberList, Tobj);
	                $("#" + objid + "T2").attr("IsList", IsList).attr("LabelListClass", LabelListClass);
	                TextClick($id(objid + "T2"), 1, { a: 1, b: 1, c: 1, d: 1, e: 1, f: 1, g: 1, h: 1, i: 1, j: 1, l: 1, o: 1, q: 1, x: 1, y: 1, z: 1 }, MemberList, Tobj, "#" + objid + "T2Viewtab", 1);

	                var yMemberList = MemberList.slice(0);
	                yMemberList.push([5, "Value", false]);
	                $("#" + objid + "T02").attr("IsList", IsList).attr("LabelListClass", LabelListClass);
	                TextClick($id(objid + "T02"), 1, { a: 1, b: 1, c: 1, d: 1, e: 1, f: 1, g: 1, h: 1, i: 1, j: 1, l: 1, o: 1, q: 1, x: 1, y: 1, z: 1, u: 1 }, yMemberList, Tobj, "#" + objid + "T02Viewtab", 1);
	                $("#" + objid + "T12").attr("IsList", IsList).attr("LabelListClass", LabelListClass);
	                TextClick($id(objid + "T12"), 1, { a: 1, b: 1, c: 1, d: 1, e: 1, f: 1, g: 1, h: 1, i: 1, j: 1, l: 1, o: 1, q: 1, x: 1, y: 1, z: 1, u: 1 }, yMemberList, Tobj, "#" + objid + "T12Viewtab", 1);
	                break;
	            }
	        case "factor_if":   //条件 如果
	            {
	                var T1Help = decodeURIComponent(xml.getAttrib("xml/sycms", "help"));
	                if (T1Help.length > 0) {
	                    $id(objid + "T1Help").value = T1Help;
	                }
	                var AT = decodeURIComponent(xml.getAttrib("xml/sycms", "at"));          //循环条
	                var IsList = $(Tobj).attr("IsList");
	                var LabelListClass = $(Tobj).attr("LabelListClass");
	                var icount = xml.getNodeslength("xml/sycms/item"); //循环实体
	                if (icount > 0) {
	                    for (var i = 0; i < icount; i++) {
	                        Factor_IfAdd(objid + "ValueView", null, objid, MemberList, Tobj, [decodeURIComponent(xml.getAttrib("xml/sycms/item", "value", i + 1)), decodeURIComponent(xml.getAttrib("xml/sycms/item", "for", i + 1)), (AT.length > 0 ? AT : decodeURIComponent(xml.getAttrib("xml/sycms/item", "at", i + 1))), decodeURIComponent(xml.getChild("xml/sycms/item", i + 1))]);
	                    }
	                    AddDiv = null;
	                } else {
	                    Factor_IfAdd(objid + "ValueView", null, objid, MemberList, Tobj);
	                }
	                icount = null;
	                var s3 = decodeURIComponent(xml.getChild("xml/sycms/default")); //默认
	                if (s3.length > 0) {
	                    $id(objid + "T40").value = s3;
	                }
	                s3 = null;
	                TextClick($id(objid + "T40"), 1, { a: 1, b: 1, c: 1, d: 1, e: 1, f: 1, g: 1, h: 1, hh: 1, i: 1, j: 1, l: 1, o: 1, q: 1, x: 1, y: 1, z: 1 }, MemberList, Tobj, "#" + objid + "T40View1", 1);
	                $("#" + objid + "T40").attr("IsList", IsList).attr("LabelListClass", LabelListClass);
	                break;
	            }
	        case "template":
	            {
                    //切换
	                LabelTabFun(objid);
	                switch (TwoType)
	                {
	                    case "Nav":
	                        {
	                            var obj = $id(objid + "T11");
	                            addItem(obj, "请选择", "");
	                            for (var i = 0; i < MdbList.length; i++) {
	                                if (MdbConn[i]) {
	                                    if (MdbConn[i].length > 0 && (MdbList[i][1] == "S" || MdbList[i][1] == "C")) {
	                                        addItem(obj, MdbList[i][0], i);
	                                    }
	                                }
	                            }
	                            $("#" + objid + "T17").bind("change", function () {
	                                if (this.value.length > 0) {
	                                    $("#" + objid + "T8Iframe").attr("src", "/Template/nav/" + this.value + "/index.html");
	                                    parent.AjaxFun("Tem/Tem/Lists_Nav.aspx", "Path=" + this.value, "正在调入导航菜单样式...", function (html) {
	                                        $("#" + objid + "T3").val(html);
	                                    });
	                                } else {
	                                    $("#" + objid + "T8Iframe").attr("src", "js/blank.html");
	                                    $("#" + objid + "T3").val("");
	                                }
	                            });
	                            var id = decodeURIComponent(xml.getAttrib("xml/sycms", "id"));         //对应的ID选项值
	                            if (id.length > 0 && id.isDigit()) {
	                                $("#TemId").val(id);
	                                parent.AjaxFun("Tem/Tem/Modi.aspx", "read=nav&id=" + id + "&objid=" + objid, "正在调入数据，请稍候......", function (html, diag) {
	                                    var LabelCon = decodeURIComponent(html);
	                                    $id(objid + "T1").Save = true;
	                                    var s1 = "";
	                                    if (LabelCon.length > 0) {
	                                        var Navxml = new XML();
	                                        Navxml.SetXML("<?xml version='1.0' encoding='utf-8'?><xml>" + LabelCon + "</xml>");

	                                        var Name = decodeURIComponent(Navxml.getAttrib("xml/sycms", "name"));      //Name值
	                                        var link = decodeURIComponent(Navxml.getAttrib("xml/sycms", "link"));
	                                        var view = decodeURIComponent(Navxml.getAttrib("xml/sycms", "view"));
	                                        var At = decodeURIComponent(Navxml.getAttrib("xml/sycms", "at"));
	                                        var Depth = decodeURIComponent(Navxml.getAttrib("xml/sycms", "depth"));
	                                        var current = decodeURIComponent(Navxml.getAttrib("xml/sycms", "current"));
	                                        s1 = decodeURIComponent(Navxml.getAttrib("xml/sycms", "style"));      //其它属性值
	                                        var blank = decodeURIComponent(Navxml.getAttrib("xml/sycms", "blank"));
	                                        var ParentID = decodeURIComponent(Navxml.getChild("xml/sycms"));
	                                        if (Name.length > 0) {
	                                            var tv2 = -1;
	                                            for (var i = 0; i < MdbList.length; i++) {
	                                                if (Name == MdbList[i][1]) {
	                                                    tv2 = i;
	                                                    break;
	                                                }
	                                            }
	                                            if (tv2 != -1) {
	                                                $(obj).val(tv2);
	                                                Label_Sell_Mdb(obj, objid, 2);
	                                                $("#" + objid + "T66_2").val(link);
	                                                $("#" + objid + "T66_1").val(view);
	                                                $("#" + objid + "T12").val(ParentID);
	                                                CreateAtInput(objid, At, "4");
	                                                $("#" + objid + "T13").val(Depth);

	                                                if (current == "True") {
	                                                    $id(objid + "T15_0").checked = true;
	                                                } else {
	                                                    $id(objid + "T15_1").checked = true;
	                                                }
	                                            }
	                                            $("#" + objid + "T14").val(blank);
	                                        }
	                                        Navxml = null;
	                                    }
	                                    if (s1.length > 0) {
	                                        setTimeout(function () { $("#" + objid + "T17").val(s1); }, 20);
	                                        $("#" + objid + "T8Iframe").attr("src", "/Template/nav/" + s1 + "/index.html");
	                                    }
	                                }, null, diag, function (diag) {
	                                    diag.close();
	                                });
	                            } else {
	                                parent.AjaxFun("Tem/Tem/Lists_Nav.aspx", null, "正在调入导航菜单样式...", function (html) {
	                                    if (html.length > 0) {
	                                        $("#" + objid + "T17").html(html);
	                                    }
	                                }, null, null, function () {
	                                    diag.close();
	                                    diag = null;
	                                });
	                            }
	                            break;
	                        }
	                    case "Sys":
	                        {
                                //绑定模型
	                            AddMdbList(["#" + objid + "T11"]);
	                            //排序字段
	                            SortSelect($id(objid + "T9_3"));
                                //排序tab
	                            LabelTabFun(objid + "order");
                                //条件tab
	                            LabelTabFun(objid + "AT");
	                            //排序字段
	                            SortSelect($id(objid + "T9_3"));
                                //标题链接
	                            TextClick($id(objid + "T12"), true, { b: 1, c: 1, d: 1, e: 1, g: 1, h: 1, j: 1, i: 1 }, MemberList, Tobj, "#" + objid + "T12Viewtab", 1);

	                            var BindTemStyleFun = function () {
	                                $("input[name='SystemTemList']").bind("change", function () {
	                                    var s1 = this.value.split(',');
	                                    var style = $("input[name='SystemStyleList']:checked").val();
	                                    style = style ? style : "";
	                                    parent.AjaxFun("Tem/Tem/Lists_System.aspx", "action=read&TagName=" + encodeURIComponent(s1[0]) + "&ClassName=" + style.split(',')[0], "调入样式写入CSS...", function (html) {
	                                        $("#" + objid + "T3").val(html);
	                                    });
	                                    if (s1[1] == "0") {
	                                        FirefoxDisabled(objid + "T12_Title");
	                                    } else {
	                                        FirefoxDisabled(objid + "T12_Title", 1);
	                                    }
	                                });
	                                $("input[name='SystemStyleList']").bind("change", function () {
	                                    var s1 = this.value.split(',');
	                                    var tem = $("input[name='SystemTemList']:checked").val();
	                                    tem = tem ? tem : "";
	                                    parent.AjaxFun("Tem/Tem/Lists_System.aspx", "action=read&TagName=" + encodeURIComponent(tem.split(',')[0]) + "&ClassName=" + s1[0], "调入样式写入CSS...", function (html) {
	                                        $("#" + objid + "T3").val(html);
	                                    });
	                                    //link:1;title:1;pic:1;summary:1;
	                                    var s2 = RegExpValue(s1[1], "link");
	                                    if (s2 != "1") {
	                                        FirefoxDisabled(objid + "Link");
	                                    } else {
	                                        FirefoxDisabled(objid + "Link", 1);
	                                    }
	                                    s2 = RegExpValue(s1[1], "title");
	                                    if (s2 != "1") {
	                                        FirefoxDisabled(objid + "Title");
	                                    } else {
	                                        FirefoxDisabled(objid + "Title", 1);
	                                    }
	                                    s2 = RegExpValue(s1[1], "pic");
	                                    if (s2 != "1") {
	                                        FirefoxDisabled(objid + "Pic");
	                                    } else {
	                                        FirefoxDisabled(objid + "Pic", 1);
	                                    }
	                                    s2 = RegExpValue(s1[1], "Summary");
	                                    if (s2 != "1") {
	                                        FirefoxDisabled(objid + "Summary");
	                                    } else {
	                                        FirefoxDisabled(objid + "Summary", 1);
	                                    }
	                                });
	                            }

	                            var id = decodeURIComponent(xml.getAttrib("xml/sycms", "id"));         //对应的ID选项值
	                            if (id.length > 0 && id.isDigit()) {
	                                $("#TemId").val(id);
	                                parent.AjaxFun("Tem/Tem/Modi.aspx", "read=nav&id=" + id + "&objid=" + objid, "正在调入数据，请稍候......", function (html, diag) {
	                                    var LabelCon = decodeURIComponent(html);
	                                    $id(objid + "T1").Save = true;
	                                    if (LabelCon.length > 0) {
	                                        var Navxml = new XML();
	                                        Navxml.SetXML("<?xml version='1.0' encoding='utf-8'?><xml>" + LabelCon + "</xml>");
	                                        var Name = decodeURIComponent(Navxml.getAttrib("xml/sycms", "name"));      //Name值
	                                        var Tem = decodeURIComponent(Navxml.getAttrib("xml/sycms", "tem"));
	                                        var style = decodeURIComponent(Navxml.getAttrib("xml/sycms", "style"));
	                                        if (Name.length > 0) {
	                                            var tv2 = -1;
	                                            for (var i = 0; i < MdbList.length; i++) {
	                                                if (Name == MdbList[i][1]) {
	                                                    tv2 = i;
	                                                    break;
	                                                }
	                                            }
	                                            if (tv2 != -1) {
	                                                var obj = $id(objid + "T11");
	                                                $(obj).val(tv2);
	                                                Label_Sell_Mdb(obj, objid,2);
	                                                //条件显示
	                                                BindAtView(objid, Navxml, "AT");
	                                                //排序
	                                                BindOrderView(objid, Navxml, "order");
	                                                //数量显示
	                                                BindReadNumView(objid, Navxml);
	                                                //分页显示
	                                                BindPageView(objid, Navxml);

	                                                var icount = Navxml.getNodeslength("xml/sycms/item"); //循环实体
	                                                if (icount > 0) {
	                                                    for (var i = 0; i < icount; i++) {
	                                                        switch (Navxml.getAttrib("xml/sycms/item", "type", i + 1)) {
	                                                            case "title":
	                                                                {
	                                                                    $("#" + objid + "T66_1").val(Navxml.getAttrib("xml/sycms/item", "word", i + 1));
	                                                                    $("#" + objid + "T66_11").val(decodeURIComponent(Navxml.getChild("xml/sycms/item", i + 1)));
	                                                                    break;
	                                                                }
	                                                            case "link":
	                                                                {
	                                                                    $("#" + objid + "T66_2").val(Navxml.getAttrib("xml/sycms/item", "word", i + 1));
	                                                                    $("#" + objid + "T66_22").val(decodeURIComponent(Navxml.getChild("xml/sycms/item", i + 1)));
	                                                                    break;
	                                                                }
	                                                            case "pic":
	                                                                {
	                                                                    $("#" + objid + "T66_3").val(Navxml.getAttrib("xml/sycms/item", "word", i + 1));
	                                                                    $("#" + objid + "T66_33").val(decodeURIComponent(Navxml.getChild("xml/sycms/item", i + 1)));
	                                                                    break;
	                                                                }
	                                                            case "summary":
	                                                                {
	                                                                    $("#" + objid + "T66_4").val(Navxml.getAttrib("xml/sycms/item", "word", i + 1));
	                                                                    $("#" + objid + "T66_44").val(decodeURIComponent(Navxml.getChild("xml/sycms/item", i + 1)));
	                                                                    break
	                                                                }
	                                                            default:
	                                                                {
	                                                                    $("#" + objid + "T12").val(decodeURIComponent(Navxml.getChild("xml/sycms/item", i + 1)));
	                                                                    break;
	                                                                }
	                                                        }
	                                                    }
	                                                }
	                                                parent.AjaxFun("Tem/Tem/Lists_System.aspx", "objid=" + objid + "&TagName=" + encodeURIComponent(Tem.split(',')[0]) + "&ClassName=" + encodeURIComponent(style.split(',')[0]), "正在调入样式信息...", function () {
	                                                    setTimeout(function () {
	                                                        BindTemStyleFun();
	                                                        s1 = $("input[name='SystemTemList']:checked").val();
	                                                        s1 = s1 ? s1 : "";
	                                                        s1 = s1.split(',');
	                                                        if (s1[1] == "0") {
	                                                            FirefoxDisabled(objid + "T12_Title");
	                                                        } else {
	                                                            FirefoxDisabled(objid + "T12_Title", 1);
	                                                        }
	                                                        s1 = $("input[name='SystemStyleList']:checked").val();
	                                                        s1 = s1 ? s1 : "";
	                                                        s1 = s1.split(',');
	                                                        var s2 = RegExpValue(s1[1], "link");
	                                                        if (s2 != "1") {
	                                                            FirefoxDisabled(objid + "Link");
	                                                        } else {
	                                                            FirefoxDisabled(objid + "Link", 1);
	                                                        }
	                                                        s2 = RegExpValue(s1[1], "title");
	                                                        if (s2 != "1") {
	                                                            FirefoxDisabled(objid + "Title");
	                                                        } else {
	                                                            FirefoxDisabled(objid + "Title", 1);
	                                                        }
	                                                        s2 = RegExpValue(s1[1], "pic");
	                                                        if (s2 != "1") {
	                                                            FirefoxDisabled(objid + "Pic");
	                                                        } else {
	                                                            FirefoxDisabled(objid + "Pic", 1);
	                                                        }
	                                                        s2 = RegExpValue(s1[1], "Summary");
	                                                        if (s2 != "1") {
	                                                            FirefoxDisabled(objid + "Summary");
	                                                        } else {
	                                                            FirefoxDisabled(objid + "Summary", 1);
	                                                        }
	                                                    }, 20);
	                                                }, null, null, function () {
	                                                    diag.close();
	                                                    diag = null;
	                                                });
	                                            }
	                                        }
	                                    } else {
	                                        diag.close();
	                                        diag = null;
	                                    }
	                                }, null, diag, function (diag) {
	                                    diag.close();
	                                });
	                            } else {
	                                $("#" + objid + "T7_0_0").attr("checked", "checked").trigger('change');
	                                parent.AjaxFun("Tem/Tem/Lists_System.aspx", "objid=" + objid, "正在调入样式信息...", function ()
	                                {
	                                    setTimeout(function () { BindTemStyleFun(); }, 20);
	                                }, null, null, function () {
	                                    diag.close();
	                                    diag = null;
	                                });
	                            }
	                            break;
	                        }
	                    default:
	                        {
	                            var Style = decodeURIComponent(xml.getAttrib("xml/sycms", "parameter"));          //循环条
	                            if (Style.length > 0) {
	                                var St = Style.split(";");
	                                for (var i = 0; i < St.length; i++) {
	                                    if (St[i].length > 0) {
	                                        var st1 = St[i].split(":");
	                                        AddMember(objid + "T1MemberList", st1[0], st1[1]);
	                                    }
	                                }
	                                St = null;
	                            }
	                            Style = null;
	                            var id = decodeURIComponent(xml.getAttrib("xml/sycms", "id"));         //对应的ID选项值
	                            if (id.length > 0 && id.isDigit()) {
	                                $("#TemId").val(id);
	                                parent.AjaxFun("Tem/Tem/Modi.aspx", "id=" + id + "&objid=" + objid, "正在调入数据，请稍候......", function (html, diag) {
	                                    setTimeout(function () { TextClick($id(objid + "T1"), true, { a: 1, b: 1, c: 1, d: 1, e: 1, f: 1, g: 1, h: 1, hh: 1, i: 1, j: 1, k: 1, o: 1, p: 1, q: 1, x: 1, y: 1, z: 1 }, MemberList, Tobj, "#" + objid + "T1View1", 1); }, 7);
	                                }, null, diag, function (diag) {
	                                    diag.close();
	                                }, null, null, null, null, null, true);
	                            } else {
	                                $("#" + objid + "T0UserView").hide();
	                                TextClick($id(objid + "T1"), true, { a: 1, b: 1, c: 1, d: 1, e: 1, f: 1, g: 1, h: 1, hh: 1, i: 1, j: 1, k: 1, o: 1, p: 1, q: 1, x: 1, y: 1, z: 1 }, MemberList, Tobj, "#" + objid + "T1View1", 1);
	                            }
	                            id = null;
	                            break;
	                        }
	                }
	                break;
	            }
	        case "get":
	            {
	                var Name = decodeURIComponent(xml.getAttrib("xml/sycms", "name"));          //循环条
	                var Value = decodeURIComponent(xml.getAttrib("xml/sycms", "value"));          //循环条
	                var confirm = decodeURIComponent(xml.getAttrib("xml/sycms", "confirm"));          //验证
	                var Style = decodeURIComponent(xml.getAttrib("xml/sycms", "style"));
	                StringfunctionListSelect($id(objid + "T20_1"));
	                if (Style.length > 0) {
	                    var JsFat = RegExpValue(Style, "JsFat");
	                    var UrlFat = RegExpValue(Style, "UrlFat");
	                    var HtmlFat = RegExpValue(Style, "HtmlFat");
	                    var SqlFat = RegExpValue(Style, "SqlFat");
	                    var Trans = RegExpValue(Style, "Trans");
	                    if (Trans) {
	                        $("#" + objid + "T20_1").val(Trans);
	                    }
	                    if (JsFat == "1") {
	                        $id(objid + "T16").checked = true;
	                    }
	                    if (UrlFat == "1") {
	                        $id(objid + "T16_1").checked = true;
	                    }
	                    if (HtmlFat == "1") {
	                        $id(objid + "T16_2").checked = true;
	                    }
	                    if (SqlFat == "1") {
	                        $id(objid + "T16_3").checked = true;
	                    }
	                    var Format = decodeURIComponent(RegExpValue(Style, "Format"));
	                    var Added = decodeURIComponent(RegExpValue(Style, "Added"));
	                    var Fill = decodeURIComponent(RegExpValue(Style, "Fill"));
	                    $id(objid + "T17_1").value = Format;
	                    $id(objid + "T17_2").value = Added;
	                    $id(objid + "T17_3").value = Fill;
	                }
	                $id(objid + "T3").value = Name;
	                $id(objid + "T4").value = Value;
	                if (Name.indexOf(".") == -1) {
	                    Name = "";
	                }
	                if (confirm.length > 0) {
	                    $("#" + objid + "T3_1").val(confirm);
	                }
	                Name = null;
	                break;
	            }
	        case "sys":
	            {
	                //绑定日期格式
	                DateQuickListSelect($id(objid + "T0_3_1"));
	                var Name = decodeURIComponent(xml.getAttrib("xml/sycms", "name"));          //循环条
	                for (var i = 0; i < SysList.length; i++) {
	                    if (SysList[i]) {
	                        addItem($id(objid + "T1"), SysList[i][0], i);
	                        if (Name == SysList[i][1]) {
	                            $id(objid + "T1").selectedIndex = i;
	                            SysHtmlFun($id(objid + "T1"), objid, xml);
	                        }
	                    }
	                }
	                Name = null;
	                var genre = decodeURIComponent(xml.getAttrib("xml/sycms", "genre"));          //类型
	                if (genre == "1") {
	                    $id(objid + "T2_1").checked = true;
	                }
	                genre = null;
	                break;
	            }
	        case "basictem":
	            {
	                var id = decodeURIComponent(xml.getAttrib("xml/sycms", "id"));
	                parent.AjaxFun("Tem/StyleModule/Lists_ViewOption.aspx", "action=" + objid + "&id=" + id, "正在调入数据，请稍候......", function(html, diag) {
	                    $("#" + objid + "ObjView").html(html);
	                }, null, diag);
	                id = null;
	                break;
	            }
	        case "pagelist":
	            {
	                var name = decodeURIComponent(xml.getAttrib("xml/sycms", "name"));
	                PageListMessage($("#" + objid + "TT001"));
	                $("#" + objid + "TT001").val(name);
	                break;
	            }
	        case "cookie":
	            {
	                var Name = decodeURIComponent(xml.getAttrib("xml/sycms", "name"));          //循环条
	                $("#" + objid + "T0").val(Name);
	                Name = null;
	                var genre = decodeURIComponent(xml.getAttrib("xml/sycms", "genre"));          //类型
	                var range = decodeURIComponent(xml.getAttrib("xml/sycms", "range"));          //取值范围
	                var arr = decodeURIComponent(xml.getAttrib("xml/sycms", "array"));          //取值范围
	                if (range == "1") {
	                    $id(objid + "T3_1").checked = true;
	                    FirefoxDisabled(objid + "StyleViewTr", 1);
	                    FirefoxDisabled(objid + "ArrayViewTr");
	                } else {
	                    FirefoxDisabled(objid + "StyleViewTr");
	                    FirefoxDisabled(objid + "ArrayViewTr", 1);
	                }
	                if (genre == "1") {
	                    $id(objid + "T2_1").checked = true;
	                }
	                if (arr.isDigit()) {
	                    $id(objid + "T4").value = arr;
	                }
	                genre = null;
	                range = null;
	                break;
	            }
	        case "varvalue":
	            {
	                //绑定上面显示的标签TAB
	                LabelTabFun(objid + "Table");
	                var str = "";
	                str += "<option value=\"\">请选择</option>";
	                $(MdbList).each(function (i) {
	                    str += "<option value=\"" + i + "\">" + this[0] + "</option>";
	                });
	                $("#" + objid + "T1").html(str);
	                str = null;

	                //绑定库名
	                var Name = decodeURIComponent(xml.getAttrib("xml/sycms", "mdbname"));      //Name值
	                if (Name) {
	                    if (xml.getAttrib("xml/sycms", "replace") == "True") {
	                        $id(objid + "T0_0").checked = true;
	                    }
	                    if (xml.getAttrib("xml/sycms", "add") == "True") {
	                        $id(objid + "T0_1").checked = true;
	                    }
	                    $("#" + objid + "Tabletabs a:eq(1)").trigger("click");
	                    var tv2 = -1;
	                    var obj = $id(objid + "T1");
	                    for (var i = 0; i < MdbList.length; i++) {
	                        if (Name == MdbList[i][1]) {
	                            tv2 = i;
	                            break;
	                        }
	                    }
	                    if (tv2 != -1) {
	                        for (var i = 0; i < obj.options.length; i++) {
	                            if (obj.options[i].value.length > 0) {
	                                if (tv2 == obj.options[i].value) {
	                                    obj.selectedIndex = i;
	                                    Label_Sell_Mdb(obj, objid, 1);
	                                    break;
	                                }
	                            }
	                        }
	                    }
	                    obj = null;

	                    //条件decodeURIComponent
	                    var At = xml.getAttrib("xml/sycms", "at");
	                    var AtArray = At.split(";");
	                    if (AtArray.length <= 2 && (AtArray[0].Right(4) == ":GET" ||  AtArray[0].Right(4) == ":SYS")) {
	                        if (tv2 != -1) {
	                            var zjmess = WordListZJ(tv2);
	                            var AtStr = AtArray[0].split(":");
	                            if (Name + "." + zjmess.Name == AtStr[2] && AtStr[3] == "GET") {
	                                $("#" + objid + "T4_100Span").html(zjmess.Title + "[" + zjmess.Name + "]接收" + zjmess.Name + "的后台传值（绑定的栏目或内容）或者是网站传值（看区块设置）。");
	                                $("#" + objid + "T4_100").val(AtStr[2]);
	                            }
	                        }
	                    } else {
	                        $("#" + objid + "OldAT").show();
	                        $("#" + objid + "NewAT").hide();
	                        CreateAtInput(objid, At, "4");
	                        $("#" + objid + "T4_100Check").attr("checked", "checked");
	                    }
	                    At = null;
	                }

	                $id(objid + "T0").value = decodeURIComponent(xml.getAttrib("xml/sycms", "name"));
	                $id(objid + "T001").value = decodeURIComponent(xml.getChild("xml/sycms")).Trim();
	                TextClick($id(objid + "T001"), true, { a: 1, b: 1, c: 1, d: 1, e: 1, f: 1, g: 1, h: 1, i: 1, j: 1, o: 1, q: 1, x: 1, y: 1, z: 1 }, MemberList, Tobj, "#" + objid + "T001View_1", 1);
	                $("#" + objid + "T001").attr("IsList", LabelListClass ? "1" : "0").attr("LabelListClass", LabelListClass);
	                TextClick($id(objid + "T4_4"), true, { b: 1, c: 1, d: 1, e: 1, g: 1, h: 1, j: 1, i: 1, o: 1, z: 1 }, MemberList, Tobj);
	                $("#" + objid + "T001").attr("IsList", LabelListClass ? "1" : "0").attr("LabelListClass", LabelListClass);
	                break;
	            }
	        case "var":
	            {
	                var VarList = Tobj.MemberList;
	                if (VarList != null && VarList != undefined && VarList && (VarList instanceof Array) && VarList.length > 0) {
	                    var str = new Array();
	                    for (var i = 0; i < VarList.length; i++) {
	                        if (VarList[i][0] == "2") {
	                            str.push("<optgroup label=\"[模型变量]" + decodeURIComponent(VarList[i][1]) + "\">");
	                            for (var j = 0; j < MdbList.length; j++) {
	                                if (MdbList[j][1] == VarList[i][3]) {
	                                    for (var j1 = 0; j1 < WordList[j].length; j1++) {
	                                        str.push("<option value=\"" + decodeURIComponent(VarList[i][1]) + "." + MdbList[j][1] + "." + WordList[j][j1][1] + "\">[" + MdbList[j][0] + "]" + WordList[j][j1][0] + "</option>");
	                                    }
	                                    break;
	                                }
	                            }
	                            str.push("</optgroup>");
	                        } else {
	                            str.push("<option value=\"" + decodeURIComponent(VarList[i][1]) + "\">[" + (VarList[i][4] ? VarList[i][4] : ((VarList[i][0] == "5") ? "循环变量" : ((VarList[i][0] == "1") ? "普通变量" : SycmsLanguage.Module.WinCreateChild.l1 + "变量"))) + "]" + VarList[i][1] + "</option>");
	                        }
	                    }
	                    $("#" + objid + "T0").append(str.join(""));
	                }
	                var name = decodeURIComponent(xml.getAttrib("xml/sycms", "name"));
	                var format = decodeURIComponent(xml.getAttrib("xml/sycms", "format"));
	                $("#" + objid + "T0").val(name);
	                $("#" + objid + "T1").val(format);
	                $("#" + objid + "T0Button").btn().disable();
	                if (format.length > 0) {
	                    $("#" + objid + "T0Button").btn().enable();
	                } else {
	                    if (name.split('.').length == 3) {
	                        $("#" + objid + "T0Button").btn().enable();
	                    }
	                }
	                $("#" + objid + "T0").bind("change", function () {
	                    $("#" + objid + "T1").val("");
	                    if (this.value.split('.').length == 3) {
	                        $("#" + objid + "T0Button").btn().enable();
	                    } else {
	                        $("#" + objid + "T0Button").btn().disable();
	                    }
	                });
	                var Style = decodeURIComponent(xml.getAttrib("xml/sycms", "style"));
	                if (Style.length > 0) {
	                    var JsFat = RegExpValue(Style, "JsFat");
	                    var UrlFat = RegExpValue(Style, "UrlFat");
	                    var HtmlFat = RegExpValue(Style, "HtmlFat");
	                    var SqlFat = RegExpValue(Style, "SqlFat");
	                    if (JsFat == "1") {
	                        $id(objid + "T16").checked = true;
	                    }
	                    if (UrlFat == "1") {
	                        $id(objid + "T16_1").checked = true;
	                    }
	                    if (HtmlFat == "1") {
	                        $id(objid + "T16_2").checked = true;
	                    }
	                    if (SqlFat == "1") {
	                        $id(objid + "T16_3").checked = true;
	                    }
	                }
	                break;
	            }
	        case "count":           //表达式计算
	            {
	                var CountValue = decodeURIComponent(xml.getChild("xml/sycms"));
	                if (CountValue == "\n\t")
	                {
	                    CountValue = "";
	                }
	                var Style = decodeURIComponent(xml.getAttrib("xml/sycms", "style"));
	                if (Style.length > 0) {
	                    var Num = RegExpValue(Style, "Num");
	                    var Max = RegExpValue(Style, "Max");
	                    $("#" + objid + "T2").val(Num);
	                    if (Max == "1")
	                    {
	                        $id(objid + "T3").checked = true;
	                    }
	                }

	                $id(objid + "T1").value = CountValue;
	                TextClick($id(objid + "T1"), 1, { b: 1, c: 1, d: 1, e: 1, f: 1, g: 1, h: 1, i: 1, j: 1, l: 1, o: 1, x: 1, y: 1, z: 1 }, MemberList, Tobj);
	                $("#" + objid + "T1").attr("IsList", $(Tobj).attr("IsList")).attr("LabelListClass", $(Tobj).attr("LabelListClass"));
	                CountValue = null;
	                break;
	            }
	        case "user_login":
	            {
	                var returnvalue = decodeURIComponent(xml.getAttrib("xml/sycms", "return"));
	                if (returnvalue == "js")
	                {
	                    $("#" + objid + "T1_0").attr("checked", "checked");
	                    FirefoxDisabled($("#" + objid + "UserWeb"));
	                } else if (returnvalue == "web") {
	                    $("#" + objid + "T1_1").attr("checked", "checked");
	                }   
	                $("#" + objid + "T2").val(decodeURIComponent(xml.getAttrib("xml/sycms", "message")));
	                break;
	            }
	        case "sys_gotourl":
	            {
	                $("#" + objid + "T1").val(decodeURIComponent(xml.getAttrib("xml/sycms", "url")));
	                break;
	            }
	    }
	}
	if (ShowFun) {
	    if (typeof (ShowFun) == "function") {
	        (ShowFun)(objid,diag);
	    }
	}
	xml.Dispose();
	xml = null;
	IECollectGarbage();
}
//绑定数量显示
function BindReadNumView(objid, xml) {
    $("#" + objid + "T7_0_0").attr("checked", "checked").trigger('change');
    //调用数量开始位置
    var Scope = decodeURIComponent(xml.getAttrib("xml/sycms", "scope"));
    if (Scope.length > 0) {
        if ((ScopeE == "" || ScopeE == "0") && (ScopeS == "" || ScopeS == "0")) {
            $("#" + objid + "T7_0_1").attr("checked", "checked").trigger('change');
        } else {
            var ScopeE = RegExpValue(Scope, "End");
            var ScopeS = RegExpValue(Scope, "Start");
            if (ScopeE || ScopeE == "0") {
                $id(objid + "T7_1").value = AtFunction(ScopeE);
            }
            if (ScopeS || ScopeS == "0") {
                $id(objid + "T7_2").value = AtFunction(ScopeS);
            }
        }
        ScopeE = null;
        ScopeS = null;
    } else {
        $("#" + objid + "T7_0_1").attr("checked", "checked").trigger('change');
    }
    Scope = null;
}
//绑定分页显示
function BindPageView(objid, xml)
{
    var Page = decodeURIComponent(xml.getAttrib("xml/sycms", "page"));
    if (Page.length > 0) {
        var Style = RegExpValue(Page, "Style");
        var PageSize = RegExpValue(Page, "Size");
        var Max = RegExpValue(Page, "Max");
        obj = $id(objid + "T13_2");
        for (var j = 0; j < obj.options.length; j++) {
            if (obj.options[j].value == Style) {
                obj.selectedIndex = j;
                break;
            }
        }
        var Pagerecordname = RegExpValue(Page, "RecordName");
        if (Pagerecordname.length > 0) {
            $id(objid + "T13_7").value = Pagerecordname;
        }
        if (PageSize || PageSize == "0") {
            $id(objid + "T13_3").value = PageSize
            $id(objid + "T13_14").value = Max;
            $id(objid + "T13_1").checked = true;
            FirefoxDisabled(objid + "LoadNum");
            //$("#" + objid + "T7_0_1").attr("checked", "checked").trigger("change");
            FirefoxDisabled(objid + "LoadPageType");
        }
        Style = null;
        PageSize = null;
    }
    Page = null;
    //添加分页 主键判断
    PageDisable(objid);
    if (!$id(objid + "T13_1").checked) {
        FirefoxDisabled(objid + "T13_PageView");
    } else {
        FirefoxDisabled(objid + "T13_PageView", 1);
    }
}

//带高级条件的条件回写
function BindAtView(objid, xml, StartName)
{
    var GetWhere = decodeURIComponent(xml.getAttrib("xml/sycms", "getwhere"));      //Name值
    StartName = StartName ? StartName : "";
    if (GetWhere.length > 0) {
        LabelTabActiveFun(objid + StartName, 1);
        $id(objid + "T21").value = GetWhere;
    } else {
        var At = xml.getAttrib("xml/sycms", "at");
        CreateAtInput(objid, At, "4");
        At = null;
    }
}
//带高级条件的条件回写
function BindOrderView(objid, xml, StartName)
{
    var GetOrder = decodeURIComponent(xml.getAttrib("xml/sycms", "getorder"));      //Name值
    StartName = StartName ? StartName : "";
    if (GetOrder.length > 0) {
        LabelTabActiveFun(objid + StartName, 1);
        $id(objid + "T22").value = GetOrder;
    } else {
        //排序
        var Order = decodeURIComponent(xml.getAttrib("xml/sycms", "order"));
        if (Order.length > 0) {
            var tv3 = Order.split(";");
            var tv5 = null;
            var tv6 = null;
            var tv6_name = null;
            var tv7 = null;
            obj = $id(objid + "T9");
            for (var j = 0; j < tv3.length; j++) {
                tv4 = null;
                tv4 = tv3[j].Left(tv3[j].indexOf("."));
                tv5 = tv3[j].Left(tv3[j].indexOf(":"));
                tv5 = tv5.Right(tv5.length - tv4.length - 1);
                if (tv5.length > 0) {
                    if (tv5 == "newid()") {
                        tv7 = tv3[j].replace("newid()", "随机取记录");
                        for (var j2 = 0; j2 < WordSort.length; j2++) {
                            tv7 = tv7.replace(":" + WordSort[j2][1], ":" + WordSort[j2][0]);
                        }
                        addItem(obj, tv7, tv3[j]);
                    } else {
                        for (var j1 = 0; j1 < MdbList.length; j1++) {
                            if (MdbList[j1][1] == tv4) {
                                tv6 = j1;
                                tv6_name = MdbList[j1][0];
                                break;
                            }
                        }
                        if (tv6 != null) {
                            for (var j1 = 0; j1 < WordList[tv6].length; j1++) {
                                if (WordList[tv6][j1][1] == tv5) {
                                    tv7 = tv3[j].replace(tv4 + "." + tv5, "[" + tv6_name + "]" + WordList[tv6][j1][0]);
                                    for (var j2 = 0; j2 < WordSort.length; j2++) {
                                        tv7 = tv7.replace(":" + WordSort[j2][1], ":" + WordSort[j2][0]);
                                    }
                                    addItem(obj, tv7, tv3[j]);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            tv3 = null;
            tv4 = null;
            tv5 = null;
            tv6 = null;
            tv6_name = null;
            tv7 = null;
            tv8 = null;
        }
        Order = null;
    }
}

//绑定模型显示
function AddMdbList(objArr)
{
    var str = new Array();
    str.push("<option value=\"\">请选择</option>");
    $(MdbList).each(function (i) {
        str.push("<option value=\"" + i + "\">" + this[0] + "</option>");
    });
    for (var i = 0; i < objArr.length; i++)
    {
        $(objArr[i]).html(str.join(""));
    }
    str = null;
}
//PageListMessage分页信息
function PageListMessage(objid) {
    objid.append("<option value=\"Index\">顺序号</option><option value=\"MaxCount\">总记录数</option><option value=\"PageString\">分页位置</option><option value=\"PageStartRecord\">分页开始记录</option><option value=\"PageEndRecord\">分页结束记录</option><option value=\"PageIndex\">分页顺序号</option><option value=\"MaxPage\">最大分页数</option><option value=\"Page\">当前页数</option>");
}
//变量选择参数
function VarFormatFun(objid, SelectName, InputName) {
    var val = $("#" + objid + SelectName).val();
    if (val.length > 0) {
        var value1 = val.split(".");
        if (value1.length == 3) {
            val = value1[1] + "." + value1[2];
        }
        var text = "<sycms type=\"Word\" name=\"" + val + "\" />";
        var text1 = $("#" + objid + InputName).val();
        if (text1.length == 0) {
            text1 = text;
        }
        LabelFun(text1, function (Nobjid, ReturnValue, diag) { if (ReturnValue.length > text.length) { $("#" + objid + InputName).val(ReturnValue); }; diag.close(); }, "Word");
    }
}
///
function SysHtmlFun(obj,objid,xml) {
    Name_i = obj.selectedIndex;
    $("." + objid + "View").hide();
    if (Name_i >= 0) {
        if (SysList[Name_i][2] == 1) {
            FirefoxDisabled(objid + "T2_0View");
            $id(objid + "T2_0").checked = true;
        } else {
            FirefoxDisabled(objid + "T2_0View",1);
        }
        var style = "";
        if (xml) {
            style = xml.getAttrib("xml/sycms", "style");
        }
        if (SysList[Name_i][3] && SysList[Name_i][4]) {
            var v1 = SysList[Name_i][3].split(",");
            var v2 = SysList[Name_i][4].split(",");
            for (var i = 0; i < v1.length; i++) {
                $("#" + objid + v2[i] + "View").show();
                var v3 = "";
                if (style) {
                    v3 = RegExpValue(style, v1[i]);
                }
                if (v3) {
                    var v3obj = $("input[name='" + objid + v2[i] + "']");
                    if (v3obj.length > 0) {
                        switch (v3obj.get(0).type) {
                            case "radio":
                            case "checkbox":
                                {
                                    v3obj.each(function () {
                                        if (this.value == v3) {
                                            this.checked = true;
                                        }
                                    });
                                    break;
                                }
                            default:
                                {
                                    v3obj.val(v3);
                                    break;
                                }
                        }
                    } else {
                        v3obj = $("select[name='" + objid + v2[i] + "']");
                        if (v3obj.length > 0) {
                            v3obj.val(v3);
                        }
                    }
                }
            }
        }
    }
}
//查询主键
function WordListZJ(tvi) {
    var str = "";
    var strTitle="";
    for (var i = 0; i < WordList[tvi].length; i++) {
        if (WordList[tvi][i][8] == 1) {
            str = WordList[tvi][i][1];
            strTitle = WordList[tvi][i][0];
        }
    }
    return { Name: str, Title: strTitle };
}

///提取像width:80;height:80;  width的值
function RegExpValue(Str, Rstring) {
    var s = "";
    if (Str && Str.length > 0) {
        var re = new RegExp(Rstring + ":(.*?);", "gi");
        var mArr = Str.match(re);
        if (!(mArr instanceof Array)) return "";
        s = mArr[0];
        s = s.Right(s.length - (Rstring.length + 1));
        s = s.Left(s.length - 1);
        re = null;
        mArr = null;
    }
    return s;
}
//生成At input显示
function CreateAtInput(objid,At,ObjName) {
    if (At.length > 0) {
        var tv3 = At.split(";");
        var tv6 = null;
        obj = $id(objid + "T" + ObjName);
        //如果为4的时候进行编码。转为新的格式
        var tv9 = "";
        var tv10 = "AND::";
        if (tv3[0].split(":").length < 4) {
            for (var j = 0; j < tv3.length; j++) {
                if (tv3[j]) {
                    if ("(" == tv3[j]) {
                        if (j == 0) {
                            tv9 = ":(:";
                        } else {
                            tv9 = "AND:(:";
                        }
                        tv10 = "OR::";
                        tv3[j] = "";
                    } else {
                        if (")" == tv3[j]) {
                            tv10 = "AND::";
                            tv3[j - 1] += ":)";
                            tv3[j] = "";
                        } else {
                            if (tv9.length > 0) {
                                tv3[j] = tv9 + tv3[j];
                                tv9 = "";
                            } else {
                                tv3[j] = (j != 0 ? tv10 : "::") + tv3[j];
                            }
                        }
                    }
                }
            }
        }
        for (var j = 0; j < tv3.length; j++) {
            tv4 = null;
            if (tv3[j])
            {
                tv6 = AtString(tv3[j]);    
                if (tv6 != null) {
                    $(obj).append("<option value=\"" + tv3[j] + "\">" + tv6 + "</option>");
                }
            }
        }
    }
}
///条件里并且或者关系
function AtAndOrfun(objid, ObjName,objthisValue) {
    if (!ObjName) {
        ObjName = "4";
    }
    var s1Obj = $("#" + objid + "T" + ObjName);
    var s1Index = s1Obj.get(0).selectedIndex;
    if (s1Index != 0) {
        var option = s1Obj.find("option");
        var s2 = option.eq(s1Index).attr("value").split(":");
        s2[0] = objthisValue;
        var s3 = s2.join(":");
        var tv6 = AtString(s3);
        option.eq(s1Index).attr("value", s3).html(tv6);
    }
}
///条件里的括号
function AtLikeFun(objid, ObjName, obj, objValue) {
    if (!ObjName) {
        ObjName = "4";
    }
    var s1Obj = $("#" + objid + "T" + ObjName);
    var s1Index = s1Obj.get(0).selectedIndex;
    var option = s1Obj.find("option");
    var s2 = option.eq(s1Index).attr("value").split(":");
    if (obj.checked) { //选中
        if (objValue == "(") {
            s2[1] = objValue;
        } else {
            s2.push(objValue);
        }
    } else {
        if (objValue == "(") {
            s2[1] = "";
        } else {
            if (s2[s2.length - 1] == ")") {
                s2.splice(s2.length - 1, 1);
            }
        }
    }
    var s3 = s2.join(":");
    var tv6 = AtString(s3);
    option.eq(s1Index).attr("value", s3).html(tv6);
}

//输出中文显示
function AtString(tv3) {
    var tv8 = tv3.split(":"); //分开三个。  检索最后一个。
    var tv7 = tv3;
    var str = "";
    var tv6 = null;
    var tv6_name = "";
    if (tv8.length >= 5) {
        tv8[4] = AtFunction(decodeURIComponent(tv8[4]));
        for (var j2 = 0; j2 < DateList.length; j2++) {
            tv8[4] = tv8[4].replace("[" + DateList[j2][1] + "]", "[" + DateList[j2][0] + "]");
        }
    }
    //替换成相应的汉字显示

    var tv4 = tv8[2].Left(tv8[2].indexOf("."));
    var tv5 = tv8[2];
    tv5 = tv5.Right(tv5.length - tv4.length - 1);
    for (var j1 = 0; j1 < MdbList.length; j1++) {
        if (MdbList[j1][1] == tv4) {
            tv6 = j1;
            tv6_name = MdbList[j1][0];
            break;
        }
    }
    if (tv6 != null) {
        for (var j1 = 0; j1 < WordList[tv6].length; j1++) {
            if (WordList[tv6][j1][1] == tv5) {
                tv8[2] = "[" + tv6_name + "]" + WordList[tv6][j1][0]
                break;
            }
        }
        for (var j2 = 0; j2 < LabelJudge.length; j2++) {
            if (tv8[3] == LabelJudge[j2][2]) {
                if (LabelJudge[j2][3] == 1) {
                    tv8[3] = LabelJudge[j2][0].replace("$$", tv8[2]);
                } else {
                    tv8[3] = LabelJudge[j2][0];
                }
                break;
            }
        }
        str = ReplaceAtView(tv8);
    }
    return str;
}
//计算
function ReplaceAtView(tv8) {
    if (tv8[0] == "OR") {
        tv8[0] = "或者";
    } else if (tv8[0] == "AND") {
        tv8[0] = "并且";
    } else {
        tv8[0] = "&nbsp;&nbsp;&nbsp;&nbsp;";
    }
    if (tv8[1] == "(") {
        tv8[1] = "&nbsp;(&nbsp;";
    } else {
        tv8[1] = "&nbsp;&nbsp;&nbsp;";
    }
    var tv9 = "";
    if (tv8[tv8.length - 1] == ")") {
        tv9 = "&nbsp;)";
        tv8.splice(tv8.length - 1, 1);
    }
    var str = tv8.join(":");
    if (tv9) {
        var strLen = HTMLDeCode(str).Lenb();
        var stringLen = 72- strLen;
        if (stringLen > 0) {
            for (var i = 0; i < stringLen; i++) {
                str += "&nbsp;";
            }
        }
        str += tv9;
    }
    return str;
}

function ReplaceRegExpValue(Str, Rstring) {
    if (Str && Str.length > 0) {
        var re = new RegExp("\\$:\\d+:\\$", "gi");
        var mArr = Str.match(re);
        var S = "";
        if (mArr instanceof Array) {
            for (var i = 0; i < mArr.length; i++) {
                S = mArr[i].replace("$:","").replace(":$","");
                Str = Str.replace(mArr[i],Rstring-parseInt(S));
            }
        }
        re = null;
        mArr = null;
    }
    return Str;
}

///提取像width="80"  width的值
function RegExpBasic(Str, Rstring) {
    var re = new RegExp(Rstring + "\"(.*?)\"", "gi");
    var mArr = Str.match(re);
    if (!(mArr instanceof Array)) return "";
    var s = mArr[0];
    s = s.Right(s.length - (Rstring.length + 1));
    s = s.Left(s.length - 1);
    re = null;
    mArr = null;
    return s;
}


//条件设置 的添加
function AddValue1(objid, ObjName, Modiy) {
    var T4 = $id(objid + 'T' + ObjName);
    var a1 = $id(objid + 'T' + ObjName + '_2');
    var a2 = $id(objid + 'T' + ObjName + '_3');
    var a3 = $id(objid + 'T' + ObjName + '_4');
    var a4 = $id(objid + 'T' + ObjName + '_5');
    var a5 = $id(objid + 'T' + ObjName + '_6');
    var aValue = "";
    var aValueStr = "";
    var s1Index = T4.selectedIndex;
    if (a1.options.length > 0) {
        if (a1.selectedIndex != -1) {
            var a11 = a1.options[a1.selectedIndex].value.split(strOFF)[0];
            var a11t = a1.options[a1.selectedIndex].text;
            var a22 = a2.options[a2.selectedIndex].value;
            var a22t = a2.options[a2.selectedIndex].text;
            if (a22 == "GET" || a22 == "SYS") {
                if (a3.value.length > 0) {
                    aValueStr = a11t + ":" + a22t + ":" + AtFunction(a3.value);
                    aValue = a11 + ":" + a22 + ":" + encodeURIComponent(a3.value);
                } else {
                    aValueStr = a11t + ":" + a22t;
                    aValue = a11 + ":" + a22
                }
            }
            else if (a22 == "VAR") {
                aValueStr = a11t + ":" + a22t + ":" + a5.options[a5.selectedIndex].text.replace("变量：", "");
                aValue = a11 + ":" + a22 + ":" + a5.options[a5.selectedIndex].value;
            } else {
                if (a4.style.display.length == 0) {
                    var a4t = a4.options[a4.selectedIndex].text;
                    var a4v = a4.options[a4.selectedIndex].value.split("|");
                    if (a4v[1] == "1") {
                        if (a3.value.length > 0) {
                            aValueStr = a11t + ":" + a22t + ":[" + a4t + "]" + AtFunction(a3.value);
                            aValue = a11 + ":" + a22 + ":[" + a4v[0] + "]" + encodeURIComponent(a3.value);
                        }
                    } else {
                        aValueStr = a11t + ":" + a22t + ":[" + a4t + "]";
                        aValue = a11 + ":" + a22 + ":[" + a4v[0] + "]";
                    }
                    a4t = null;
                    a4v = null;
                } else {
                    if (a3.value.length > 0) {
                        aValueStr = a11t + ":" + a22t + ":" + AtFunction(a3.value);
                        aValue = a11 + ":" + a22 + ":" + encodeURIComponent(a3.value);
                    }
                }
            }
            a22 = null;
            a22t = null;
            a11 = null;
            a11t = null;
        }
    }
    if (aValue) {
        if (Modiy) {
            var T4Value = $(T4).find("option").eq(s1Index).attr("value").split(":");
            if (T4Value[0] == "AND") {
                aValue = "AND:" + T4Value[1] + ":" + aValue;
                aValueStr = "并且:&nbsp;" + (T4Value[1] ? T4Value[1] : "&nbsp;") + "&nbsp;:" + aValueStr;
            } else if (T4Value[0] == "OR") {
                aValue = "OR:" + T4Value[1] + ":" + aValue;
                aValueStr = "或者:&nbsp;" + (T4Value[1] ? T4Value[1] : "&nbsp;") + "&nbsp;:" + aValueStr;
            } else {
                aValue = ":" + T4Value[1] + ":" + aValue;
                aValueStr = "&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;" + (T4Value[1] ? T4Value[1] : "&nbsp;") + "&nbsp;:" + aValueStr;
            }
            $(T4).find("option").eq(s1Index).attr("value", aValue).html(aValueStr);
            $(Modiy).hide();
            T4.selectedIndex = -1;
            a1.selectedIndex = 0;
            LabelJudgeChange(a1, objid, ObjName);
        } else {
            if (T4.options.length < 1) {
                aValue = "::" + aValue;
                aValueStr = "&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;:" + aValueStr;
            } else {
                aValue = "AND::" + aValue;
                aValueStr = "并且:&nbsp;&nbsp;&nbsp;:" + aValueStr;
            }
            $(T4).append("<option value=\"" + aValue + "\">" + aValueStr + "</option>");
            T4.selectedIndex = T4.options.length - 1;
            $("#" + objid + "T" + ObjName + "_View").show();
        }
        ATfun(objid, null, 1);
        PageDisable(objid);
    }
    IECollectGarbage();
}
///删除选择项
function AtDel(objid, ObjName) {
    if (!ObjName) {
        ObjName = "4";
    }
    var a = $id(objid + 'T' + ObjName);
    var a1 = $id(objid + 'T' + ObjName + '_2');
    //FirefoxDisabled(objid + "T" + ObjName + "Sub1");
    FirefoxDisabled(objid + "T" + ObjName + "Sub2");
    FirefoxDisabled(objid + "T" + ObjName + "Sub3");
    //FirefoxDisabled(objid + "T" + ObjName + "Sub4");
    FirefoxDisabled(objid + "T" + ObjName + "Sub5");
    FirefoxDisabled(objid + "T" + ObjName + "_Sub2");
    FirefoxDisabled(objid + "T" + ObjName + "_Sub3");
    if (a.selectedIndex == 0 && a.options.length > 1) {
        var option = $(a).find("option");
        var s31 = option.eq(1).attr("value").split(":");
        s31[0] = "";
        s3 = s31.join(":");
        tv6 = AtString(s3);
        option.eq(1).attr("value", s3).html(tv6);
    }
    DelSelectValue(a);
    a1.selectedIndex = 0;
    LabelJudgeChange(a1, objid);
    $id(objid + "T" + ObjName + "_3").style.display = "none";
    $id(objid + "T" + ObjName + "_4").style.display = "none";
    $id(objid + "T" + ObjName + "_5").style.display = "none";
    $id(objid + "T" + ObjName + "_View").style.display = "none";
    PageDisable(objid);
}

//排序的添加
function AddValue2(T9,a1, a2) {
    if (a1.options.length > 0 && a2.options.length > 0) {
        if (a1.selectedIndex != -1 && a1.options[a1.selectedIndex].value.length>0) {
            var a11 = a1.options[a1.selectedIndex].value.split(strOFF)[0];
            var a11t = a1.options[a1.selectedIndex].text;
            var a22 = a2.options[a2.selectedIndex].value;
            var a22t = a2.options[a2.selectedIndex].text;
            addItem(T9, a11t + ":" + a22t, a11 + ":" + a22);
            a11 = null;
            a11t = null;
            a22 = null;
            a22t = null;
        }
    }
}

///修改值
//t为数组
function StyleFunMV(t, s,objAll) {
    var objs = objAll.getElementsByTagName("input");
    var str = "";
    for (var i = 0; i < t.length; i++) {
        str = "";
        if (i < s.length) {
            str = s[i];
        }
        switch (t[i][1]) {
            case 1:
                {
                    $id(t[i][0]).value = str;
                    break;
                }
            case 2:
                {
                    for (var ii = 0; ii < objs.length; ii++) {
                        if ((objs[ii].type == "radio") && (objs[ii].name == t[i][0])) {
                            if (objs[ii].value == str) {
                                objs[ii].checked = true;
                                break;
                            }
                        }
                    }
                    break;
                }
            case 3:
                {
                    for (var ii = 0; ii < objs.length; ii++) {
                        if ((objs[ii].type == "checkbox") && (objs[ii].name == t[i][0])) {
                            if (("," + str + ",").indexOf("," + objs[ii].value + ",") != -1) {
                                objs[ii].checked = true;
                            }
                        }
                    }
                    break;
                }
            case 4:
                {
                    for (var ii = 0; ii < $id(t[i][0]).options.length; ii++) {
                        if ($id(t[i][0]).options[ii].value == str) {
                            $id(t[i][0]).selectedIndex = ii;
                            break;
                        }
                    }
                    break;
                }
        }
    }
    str = null;
    objs = null;
}

//检查条件括号是否正常
function ShowCallBack_At(o) {
    var str = "";
    var str2 = 0;
    if (o.options.length > 0) {
        for (var i = 0; i < o.options.length; i++) {
            if (o.options[i].value) {
                var str1 = o.options[i].value.split(":");
                if (str1[1] == "(") {
                    str2++;
                }
                if (str1[str1.length - 1] == ")") {
                    str2--;
                    if (str2 < 0) {
                        break;
                    }
                }
                str += o.options[i].value + ";";
            }
        }
    }
    if (str2 != 0) {
        return "ERROR";
    } else {
        return str;
    }
}
///判断是否存在红色标签
function ShowCallBack_LabelSave(obj) {
    if (!obj.Save) {
        Dialog.error("请检查，是否存在显示为红色的标签信息。");
        return true;
    } else {
        return false;
    }
 }

//确定函数
function ShowCallBack_Label(String, objid,onshowerror) {
    var xml = new XML();
    xml.SetXML("<?xml version='1.0' encoding='utf-8'?><xml>" + String + "</xml>");

    var Type = decodeURIComponent(xml.getAttrib("xml/sycms", "type"));
    var str = "";
    var s = "";
    var s1 = "";
    var s2 = "";
    var o = null;
    if (Type.length > 0) {
        switch (Type.toLowerCase()) {
            case "list": //列表
                {
                    xml.delAttrib("xml/sycms", "getwhere");

                    str = InputV($id(objid + "T1"));
                    if (str.length > 0) {
                        xml.setAttrib("xml/sycms", "name", encodeURIComponent(MdbList[parseInt(str)][1]));

                        var T1Help = $id(objid + "T1Help").value;
                        if (T1Help.length > 0) {
                            xml.setAttrib("xml/sycms", "help", T1Help.split("\"").join(""));
                        } else {
                            xml.delAttrib("xml/sycms", "help");
                        }

                        if ($("#" + objid + "ATtab2").is(":hidden"))     //隐藏
                        {
                            //条件
                            o = $id(objid + "T4");
                            s1 = ShowCallBack_At(o);
                            if (s1.length > 0) {
                                if (s1 == "ERROR") {
                                    if (!onshowerror) {
                                        Dialog.error("错误：请检查【条件设置】里的（）是否成双成对。");
                                    }
                                    return "";
                                } else {
                                    xml.setAttrib("xml/sycms", "at", s1);
                                }
                            } else {
                                xml.delAttrib("xml/sycms", "at");
                            }
                        } else {
                            xml.delAttrib("xml/sycms", "at");
                            var str1 = $id(objid + "T21").value;
                            if (str1.length > 0) {
                                if (ShowCallBack_LabelSave($id(objid + "T21"))) {
                                    return "";
                                }
                                xml.setAttrib("xml/sycms", "getwhere", encodeURIComponent(str1));
                            }
                        }
                        if ($("#" + objid + "ordertab2").is(":hidden"))     //隐藏
                        {
                            xml.delAttrib("xml/sycms", "getorder");
                            //排序
                            o = $id(objid + "T9");
                            s1 = "";
                            if (o.options.length > 0) {
                                for (var i = 0; i < o.options.length; i++) {
                                    if (o.options[i].value.length > 0) {
                                        s1 += o.options[i].value + ";";
                                    }
                                }
                            }
                            if (s1.length > 0) {
                                xml.setAttrib("xml/sycms", "order", s1);
                            } else {
                                xml.delAttrib("xml/sycms", "order");
                            }
                        } else {
                            xml.delAttrib("xml/sycms", "order");
                            var str1 = $id(objid + "T22").value;
                            if (str1.length > 0) {
                                if (ShowCallBack_LabelSave($id(objid + "T22"))) {
                                    return "";
                                }
                                xml.setAttrib("xml/sycms", "getorder", encodeURIComponent(str1));
                            }
                        }
                    } else {
                        return "";
                    }
                    //图片
                    s1 = InputV($id(objid + "T3_1"));
                    s2 = InputV($id(objid + "T3_2"));
                    if ((s1.isDigit() || (s1.Left(4) == "[变量]")) && (s2.isDigit() || (s2.Left(4) == "[变量]"))) {
                        if (!((s1 == "0" && s2 == "0" || s1 == "" && s2 == ""))) {
                            s = "Width:" + encodeURIComponent(ReplaceMemberText(s1)) + ";Height:" + encodeURIComponent(ReplaceMemberText(s2)) + ";";
                            var Cut = $("#" + objid + "T3_3").val();
                            if (Cut.length > 0) {
                                s += "Cut:" + Cut + ";";
                            }
                            if ($id(objid + "T3_4").checked) {
                                s += "Logo:1;";
                            }
                            xml.setAttrib("xml/sycms", "pic", s);
                            Cut = null;
                        } else {
                            xml.delAttrib("xml/sycms", "pic");
                        }
                    } else {
                        xml.delAttrib("xml/sycms", "pic");
                    }
                    //标题数量
                    s1 = InputV($id(objid + "T6"));
                    if (s1.length == 0) {
                        s1 = "";
                    }
                    if (s1.isDigit() || (s1.Left(4) == "[变量]")) {
                        var s3 = InputV($id(objid + "T6_2_1"));
                        if (s3.length > 0) {
                            s3 = "Cut:" + s3 + ";";
                        }
                        s2 = InputV($id(objid + "T6_2"));
                        if (s2.length > 0) {
                            s1 = (s1.length > 0 ? ("Num:" + encodeURIComponent(ReplaceMemberText(s1)) + ";") : "") + "Added:" + encodeURIComponent(s2) + ";" + s3;
                        } else {
                            s1 = (s1.length > 0 ? ("Num:" + encodeURIComponent(ReplaceMemberText(s1)) + ";") : "") + s3;
                        }
                        if (s1.length > 0) {
                            xml.setAttrib("xml/sycms", "title", s1);
                        } else {
                            xml.delAttrib("xml/sycms", "title");
                        }
                    } else {
                        xml.delAttrib("xml/sycms", "title");
                    }
                    //显示范围
                    if ($("#" + objid + "T7_0_0").is(":checked")) {
                        s1 = InputV($id(objid + "T7_1"));
                        s2 = InputV($id(objid + "T7_2"));
                        if (s1.length == 0) {
                            s1 = "";
                        }
                        if (s2.length == 0) {
                            s2 = "";
                        }
                        if (s1.isDigit() || s2.isDigit() || s1.Left(4) == "[变量]" || s2.Left(4) == "[变量]") {
                            if (s1.length > 0) {
                                s1 = "End:" + encodeURIComponent(ReplaceMemberText(s1)) + ";";
                            }
                            if (s2.length > 0) {
                                s2 = "Start:" + encodeURIComponent(ReplaceMemberText(s2)) + ";";
                            }
                            if (s1.length > 0 || s2.length > 0) {
                                xml.setAttrib("xml/sycms", "scope", s1 + s2);
                            } else {
                                xml.delAttrib("xml/sycms", "scope");
                            }
                        } else {
                            xml.delAttrib("xml/sycms", "scope");
                        }
                    } else {
                        xml.delAttrib("xml/sycms", "scope");
                    }
                    //日期
                    s1 = InputV($id(objid + "T10"));
                    if (s1.length > 0) {
                        xml.setAttrib("xml/sycms", "date", s1);
                    } else {
                        xml.delAttrib("xml/sycms", "date");
                    }
                    //样式
                    if ($id(objid + "Writetab2").style.display == "none")     //隐藏
                    {
                        s1 = InputV($id(objid + "T11"));
                        if (s1.length > 0) {
                            if (s1 == "0") {
                                if (!onshowerror) {
                                    Dialog.alert("错误：请填写输入或者选择样式。");
                                }
                                return "";
                            } else {
                                xml.setNodeValue("xml/sycms", " ");
                                if (s1.indexOf("Style:") != -1) {
                                    xml.delAttrib("xml/sycms", "style");
                                    xml.setAttrib("xml/sycms", "stylemoduleid", s1.replace("Style:", ""));
                                } else {
                                    xml.delAttrib("xml/sycms", "stylemoduleid");
                                    xml.setAttrib("xml/sycms", "style", s1.replace("Sp:", ""));
                                }
                            }
                        } else {
                            return "";
                        }
                    } else {
                        xml.delAttrib("xml/sycms", "style");
                        xml.delAttrib("xml/sycms", "stylemoduleid");
                        s2 = InputV($id(objid + "T11_1"));
                        if (s2.length > 0) {
                            if (ShowCallBack_LabelSave($id(objid + "T11_1"))) {
                                return "";
                            }
                            xml.setNodeValue("xml/sycms", encodeURIComponent(s2));
                        } else {
                            $id(objid + "T11_1").focus();
                            if (!onshowerror) {
                                Dialog.alert("错误：请填写输入或者选择样式。");
                            }
                            return "";
                        }
                    }
                    //内容
                    if (InputV($id(objid + "T12_1"))) {
                        s1 = InputV($id(objid + "T12_2"));
                        s2 = InputV($id(objid + "T12_3"));
                        if ((s1.isDigit() && s1 != "0" || (s1.Left(4) == "[变量]")) || (s2.isDigit() && s2 != "0" || (s2.Left(4) == "[变量]"))) {
                            var s3 = InputV($id(objid + "T12_4"));
                            var s3_1 = InputV($id(objid + "T12_2_1"));
                            var s3_2 = InputV($id(objid + "T12_3_1"));
                            var s3_3 = "";
                            if (s3_1.length > 0) {
                                s3_3 += "ContentCut:" + s3_1 + ";";
                            }
                            if (s3_2.length > 0) {
                                s3_3 += "SummaryCut:" + s3_2 + ";";
                            }
                            if (s3.length > 0) {
                                xml.setAttrib("xml/sycms", "content", "Content:" + encodeURIComponent(ReplaceMemberText(s1)) + ";Summary:" + encodeURIComponent(ReplaceMemberText(s2)) + ";Added:" + encodeURIComponent(s3) + ";" + s3_3);
                            } else {
                                xml.setAttrib("xml/sycms", "content", "Content:" + encodeURIComponent(ReplaceMemberText(s1)) + ";Summary:" + encodeURIComponent(ReplaceMemberText(s2)) + ";" + s3_3);
                            }
                        } else {
                            xml.delAttrib("xml/sycms", "content");
                        }
                    } else {
                        xml.delAttrib("xml/sycms", "content");
                    }
                    //内容样分页样式
                    s1 = InputV($id(objid + "T23_1"));
                    if (s1.length > 0) {
                        xml.setAttrib("xml/sycms", "contentpage", s1);
                    } else {
                        xml.delAttrib("xml/sycms", "contentpage");
                    }
                    //行间隔
                    if (InputV($id(objid + "T13_4"))) {
                        xml.setAttrib("xml/sycms", "interval", "LineSpace:" + encodeURIComponent(InputV($id(objid + "T13_4"))) + ";LineNum:" + encodeURIComponent(ReplaceMemberText(InputV($id(objid + "T13_5")))) + ";");
                    } else {
                        xml.delAttrib("xml/sycms", "interval");
                    }
                    //分页
                    if (InputV($id(objid + "T13_1"))) {
                        s1 = "Style:" + InputV($id(objid + "T13_2")) + ";Size:" + encodeURIComponent(ReplaceMemberText(InputV($id(objid + "T13_3")))) + ";";
                        s2 = InputV($id(objid + "T13_14"));
                        if (s2.length > 0 && s2 != "0") {
                            s1 += "Max:" + encodeURIComponent(s2) + ";";
                        }
                        s2 = InputV($id(objid + "T13_7"));
                        if (s2.length > 0) {
                            s1 += "RecordName:" + encodeURIComponent(s2) + ";";
                        }

                        xml.setAttrib("xml/sycms", "page", s1);
                        xml.delAttrib("xml/sycms", "scope");
                        xml.delAttrib("xml/sycms", "contentpage");
                    } else {
                        xml.delAttrib("xml/sycms", "page");
                    }
                    break;
                }
            case "word":            //字段
                {
                    var Style = InputValue([[objid + "T1", 2, 1]], $("#" + objid + "StyleView").get(0));
                    var str = "";

                    //标准型的时候。不进行判断  直接删除
                    if (Style == "1") {      //字符
                        str = "Type:1;";
                        var s1 = InputV($id(objid + "T2_1"));
                        var s2 = InputV($id(objid + "T2_2"));
                        var s3 = InputV($id(objid + "T2_3"));
                        var s4 = InputV($id(objid + "T2_1_1"));
                        if (s1.length > 0 && s1.isDigit()) {
                            str += "Format:" + encodeURIComponent(s1) + ";";
                            if (s4.length > 0) {
                                str += "Cut:" + s4 + ";";
                            }
                        }
                        if (s2.length > 0) {
                            str += "Added:" + encodeURIComponent(s2) + ";";
                        }
                        if (s3.length > 0) {
                            str += "Fill:" + encodeURIComponent(s3) + ";";
                        }
                        if ($id(objid + "T2_4").checked)
                        {
                            str += "Clear:Enter;";
                        }
                        s1 = null;
                        s2 = null;
                    } else if (Style == "2") {      //日期
                        str = "Type:2;";
                        var s2 = InputV($id(objid + "T3_2"));
                        if (s2 == "") {
                            var s1 = InputV($id(objid + "T3_1"));
                            if (s1.length > 0) {
                                str += "Format:" + encodeURIComponent(s1) + ";";
                            }
                        } else {
                            str += "Time:" + encodeURIComponent(s2) + ";";
                        }
                        s1 = null;
                    } else if (Style == "3") {      //数字
                        str = "Type:3;";
                        var s1 = InputValue([[objid + "T4_1", 2, 1]], $("#" + objid + "StyleView").get(0));
                        if (s1.isDigit()) {
                            str += "Format:" + encodeURIComponent(s1) + ";";
                        }
                        s1 = null;
                    } else {       //标准
                        var s1 = InputV($id(objid + "T0_1"));
                        if (s1.length > 0) {
                            str += "Format:" + encodeURIComponent(s1) + ";";
                        }
                        s1 = InputV($id(objid + "T0_2"));
                        if (s1.length > 0) {
                            str += "Added:" + encodeURIComponent(s1) + ";";
                        }
                        s1 = InputV($id(objid + "T0_3"));
                        if (s1.length > 0) {
                            str += "Fill:" + encodeURIComponent(s1) + ";";
                        }
                        s1 = InputV($id(objid + "T0_4"));
                        s2 = InputV($id(objid + "T0_5"));
                        if (s1.length > 0 && s2.length > 0) {
                            s3 = InputV($id(objid + "T0_6"));
                            if (s3.length > 0) {
                                s3 = "PicCut:" + s3 + ";";
                            }
                            str += "PicWidth:" + encodeURIComponent(s1) + ";PicHeight:" + encodeURIComponent(s2) + ";" + s3;
                            if ($id(objid + "T0_7").checked) {
                                str += "PicLogo:1;";
                            }
                        }
                        s1 = null;
                    }
                    if ($id(objid + "T16").checked) {
                        str += "JsFat:1;";
                    }
                    if ($id(objid + "T16_1").checked) {
                        str += "UrlFat:1;";
                    }
                    if ($id(objid + "T16_2").checked) {
                        str += "HtmlFat:1;";
                    }
                    if ($id(objid + "T16_3").checked) {
                        str += "SqlFat:1;";
                    }
                    xml.delAttrib("xml/sycms", "fontpic");
                    if ($id(objid + "T36").checked) {
                        var vstr = "";
                        var vT17 = InputValue([[objid + "T17", 2, 1]], $("#" + objid + "StyleView").get(0)); //类型
                        vstr += "Type:" + encodeURIComponent(vT17) + ";";
                        var vT18 = InputV($id(objid + "T18")); //字体
                        if (vT18.length == 0) {
                            Dialog.alert("错误：字体必须输入。");
                            return "";
                        }
                        vstr += "Font:" + encodeURIComponent(vT18) + ";";
                        var vT19 = InputV($id(objid + "T19")); //大小
                        if (vT19.length == 0 || !vT19.isDigit()) {
                            Dialog.alert("错误：字体大小必须输入，并且是数字。");
                            return "";
                        }
                        vstr += "Size:" + encodeURIComponent(vT19) + ";";
                        var vT20 = InputV($id(objid + "T20")); //颜色
                        if (!vT20.checkColor()) {
                            Dialog.alert("错误：字体颜色错误。");
                            return "";
                        }
                        vstr += "Color:" + encodeURIComponent(vT20) + ";";
                        var vT21 = InputV($id(objid + "T21")); //宽度
                        if (!vT21.isDigit()) {
                            vT21 = "0";
                        }
                        vstr += "Width:" + encodeURIComponent(vT21) + ";";
                        var vT22 = InputV($id(objid + "T22")); //高度
                        if (!vT22.isDigit()) {
                            vT22 = "0";
                        }
                        vstr += "Height:" + encodeURIComponent(vT22) + ";";
                        var vT23 = InputV($id(objid + "T23")); //上
                        if (!vT23.isDigit()) {
                            vT23 = "0";
                        }
                        vstr += "Top:" + encodeURIComponent(vT23) + ";";
                        var vT24 = InputV($id(objid + "T24")); //左
                        if (!vT24.isDigit()) {
                            vT24 = "0";
                        }
                        var vT27 = InputV($id(objid + "T27")); //透明
                        if (!vT27.isDigit()) {
                            if (parseInt(vT27) > 255 || parseInt(vT27) < 0) {
                                vT27 = "255";
                            }
                        } else {
                            vT27 = "255";
                        }
                        vstr += "Alpha:" + vT27 + ";";                      //阴影
                        if ($id(objid + "T28").checked) {
                            vstr += "Shadow:true;";
                        }

                        vstr += "Left:" + encodeURIComponent(vT24) + ";";
                        var vT25 = InputV($id(objid + "T25")); //颜色
                        var vT26 = InputV($id(objid + "T26")); //图片
                        if (vT26.length == 0) {
                            if (!vT25.checkColor()) {
                                if (!vT17 == "png") {
                                    Dialog.alert("错误：底纹颜色或图片必填写一个。");
                                }
                                return "";
                            }
                            vstr += "PColor:" + encodeURIComponent(vT25) + ";";
                        } else {
                            vstr += "Pic:" + encodeURIComponent(vT26) + ";";
                        }
                        var vt29 = InputValue([[objid + "T29", 3, 1]], $("#" + objid + "StyleView").get(0));
                        if (vt29.length > 0) {
                            vstr += "Style:" + vt29.Left(vt29.length - 1).replace("|", ",").replace("|", ",").replace("|", ",").replace("|", ",").replace("|", ",") + ";";
                        }
                        xml.setAttrib("xml/sycms", "fontpic", vstr);
                    }

                    var s1 = InputV($id(objid + "T15"));        //绑定由SQL所生成的函数。       依方便进行多次调用。包括重复记录的选择
                    if (s1.length > 0) {
                        str += "Fun:" + encodeURIComponent(s1) + ";";
                    }
                    if (str.length > 0) {
                        xml.setAttrib("xml/sycms", "style", str);
                    } else {
                        xml.delAttrib("xml/sycms", "style");        //无时。标准型。直接删除。
                    }
                    str = InputV($id(objid + "T200_1"));
                    if (str.length > 0) {
                        xml.setAttrib("xml/sycms", "special", str);
                    } else {
                        xml.delAttrib("xml/sycms", "special");        //无时。标准型。直接删除。
                    }
                    s1 = null;
                    str = null;
                    Style = null;
                    break;
                }
            case "seo":
                {
                    str = InputV($id(objid + "T1"));
                    if (str.length > 0) {
                        //数据拼写名称
                        xml.setAttrib("xml/sycms", "name", MdbList[parseInt(str)][1]);
                        var ObjView = $("#" + objid + "ObjView");
                        var Select = ObjView.find("select");
                        var SelectStr = "";
                        for (var i = 0; i < Select.length; i++) {
                            if (Select.eq(i).val()) {
                                SelectStr += Select.eq(i).val() + ";";
                            }
                        }
                        if (SelectStr) {

                            var viewField = new Array();
                            if ($id(objid + "T22_0").checked) {
                                viewField.push("0");
                            }
                            if ($id(objid + "T22_1").checked) {
                                viewField.push("1");
                            }
                            if ($id(objid + "T22_2").checked) {
                                viewField.push("2");
                            }
                            if (viewField.length > 0) {
                                xml.setAttrib("xml/sycms", "view", viewField.join(","));
                                s1 = "::" + $id(objid + "T0").value + ":GET;";
                                xml.setAttrib("xml/sycms", "at", s1);
                                xml.setAttrib("xml/sycms", "rec", SelectStr);
                                var ObjFieldView = $("#" + objid + "ObjFieldView");
                                var FieldList = ObjFieldView.find("fieldset");
                                SelectStr = "";
                                for (var i = 0; i < FieldList.length; i++) {
                                    var FieldListS = FieldList.eq(i).find("select");
                                    var FieldListValue = new Array();
                                    for (var j = 0; j < viewField.length; j++) {
                                        FieldListValue.push(FieldListS.eq(viewField[j]).val());
                                    }
                                    SelectStr += FieldListValue.join(",") + ";";
                                }
                                xml.setAttrib("xml/sycms", "val", SelectStr);
                                if ($id(objid + "T11").checked) {
                                    xml.setAttrib("xml/sycms", "sys", "true");
                                } else {
                                    xml.delAttrib("xml/sycms", "sys");
                                }

                                if ($id(objid + "T33").checked) {
                                    xml.setAttrib("xml/sycms", "html", "true");
                                } else {
                                    xml.delAttrib("xml/sycms", "html");
                                }
                                xml.setNodeValue("xml/sycms", " ");
                                var fill = $("#" + objid + "T44").val();
                                if (fill) {
                                    xml.setAttrib("xml/sycms", "style", "Fill:" + fill + ";");
                                } else {
                                    xml.delAttrib("xml/sycms", "style");
                                }
                            }
                        } else {
                            return "";
                        }
                    } else {
                        return "";
                    }
                    break;
                }
            case "navigate":            //导航
                {
                    str = InputV($id(objid + "T1"));
                    if (str.length > 0) {
                        //数据拼写名称
                        xml.setAttrib("xml/sycms", "name", MdbList[parseInt(str)][1]);
                        //显示方式
                        var Way = InputValue([[objid + "T3", 2, 1]], $("#" + objid + "StyleView").get(0));
                        xml.setAttrib("xml/sycms", "way", Way);
                        Way = null;
                        var Wstr1 = InputV($id(objid + "T66_1"));
                        var Wstr2 = InputV($id(objid + "T66_2"));
                        var Wstr3 = InputV($id(objid + "T666_3"));
                        if (Wstr1 == Wstr2) {
                            Dialog.alert("错误：标题和地址不能相同。");
                            return "";
                        }
                        if (Wstr2.length > 0) {
                            xml.setAttrib("xml/sycms", "word", "Title:" + Wstr1 + ";Url:" + Wstr2 + ";" + (Wstr3 ? "Fill:" + Wstr3 + ";" : ""));
                        } else {
                            xml.setAttrib("xml/sycms", "word", "Title:" + Wstr1 + ";" + (Wstr3 ? "Fill:" + Wstr3 + ";" : ""));
                        }
                        Wstr1 = null;
                        Wstr2 = null;
                        //条件
                        if ($id(objid + "T4_100Check").checked) {
                            var o = $id(objid + "T4");
                            s1 = ShowCallBack_At(o);
                            if (s1.length > 0) {
                                if (s1 == "ERROR") {
                                    Dialog.error("错误：请检查【查询条件】里的（）是否成双成对。");
                                    return "";
                                } else {
                                    xml.setAttrib("xml/sycms", "at", s1);
                                }
                            } else {
                                xml.delAttrib("xml/sycms", "at");
                            }
                            o = null;
                        } else {
                            s1 = "::" + $id(objid + "T4_100").value + ":GET;";
                            xml.setAttrib("xml/sycms", "at", s1);
                        }
                        //递归条件
                        o = $id(objid + "T6");
                        s1 = ShowCallBack_At(o);
                        if (s1.length > 0) {
                            if (s1 == "ERROR") {
                                Dialog.error("错误：请检查【否定条件】里的（）是否成双成对。");
                                return "";
                            } else {
                                xml.setAttrib("xml/sycms", "recat", s1);
                            }
                        } else {
                            xml.delAttrib("xml/sycms", "recat");
                        }
                        o = null;
                        //分隔符
                        s1 = InputV($id(objid + "T5"));
                        xml.setNodeValue("xml/sycms", encodeURIComponent(s1));
                        s1 = null;
                        s1 = InputV($id(objid + "T55"));
                        if (s1) {
                            xml.setAttrib("xml/sycms", "current", decodeURIComponent(s1));
                        } else {
                            xml.delAttrib("xml/sycms", "current");
                        }
                        s1 = null;
                    } else {
                        return "";
                    }
                    break;
                }
            case "factor_or":       //条件 或
                {
                    var T1Help = $id(objid + "T1Help").value;
                    if (T1Help.length > 0) {
                        xml.setAttrib("xml/sycms", "help", T1Help.split("\"").join(""));
                    } else {
                        xml.delAttrib("xml/sycms", "help");
                    }
                    s1 = InputV($id(objid + "T1"));
                    if (s1.length > 0) {
                        if (s1.indexOf("||") != -1 && s1.replace("|/g", "").length > 0) {
                            while (xml.getNode("xml/sycms/item")) {
                                xml.delNode("xml/sycms/item");
                            }
                            var s2 = s1.split("||");
                            for (var i = 0; i < s2.length; i++) {
                                if (s2[i].length > 0) {
                                    xml.InsertBeforeChild("xml/sycms", "item", encodeURIComponent(s2[i]));
                                }
                            }
                            s2 = null;
                        } else {
                            return "";
                        }
                    } else {
                        return "";
                    }
                    break;
                }
            case "factor_for":      //条件 循环
                {
                    var T1Help = $id(objid + "T1Help").value;
                    if (T1Help.length > 0) {
                        xml.setAttrib("xml/sycms", "help", T1Help.split("\"").join(""));
                    } else {
                        xml.delAttrib("xml/sycms", "help");
                    }
                    var objvalue = $("#" + objid + "tabs a.dq").html();
                    while (xml.getNode("xml/sycms/item")) {
                        xml.delNode("xml/sycms/item");
                    }
                    xml.setNodeValue("xml/sycms", " ");
                    switch (objvalue)
                    {
                        case "数字循环":
                            {
                                var s0 = InputV($id(objid + "T01_0")).Trim();
                                var s1 = InputV($id(objid + "T01_1")).Trim();
                                var s2 = InputV($id(objid + "T01_2")).Trim();
                                xml.setAttrib("xml/sycms", "for", "num");
                                if (s0.length > 0 && s1.length > 0 && s2.length > 0)
                                {
                                    xml.setAttrib("xml/sycms", "at", "From:" + encodeURIComponent(s0) + ";To:" + encodeURIComponent(s1) + ";Add:" + encodeURIComponent(s2) + ";");
                                } else {
                                    return "";
                                }
                                s1 = InputV($id(objid + "T02"));
                                if (s1.length > 0) {
                                    xml.setNodeValue("xml/sycms", encodeURIComponent(s1));
                                } else {
                                    return "";
                                }
                                break;
                            }
                        case "拆分循环":
                            {
                                var s0 = InputV($id(objid + "T11_0"));
                                var s1 = InputV($id(objid + "T11_1"));
                                var s2 = $id(objid + "T11_2").checked ? "desc" : "asc";
                                var s3 = InputV($id(objid + "T11_3"));
                                var s4 = InputV($id(objid + "T11_4"));
                                var s5 = $id(objid + "T11_5").checked ? "true" : "false";
                                var s6 = $id(objid + "T11_6").checked ? "true" : "false";
                                xml.setAttrib("xml/sycms", "for", "string");
                                if (s0.length > 0 && s1.length > 0) {
                                    xml.setAttrib("xml/sycms", "at", "String:" + encodeURIComponent(s0) + ";Split:" + encodeURIComponent(s1) + ";Orderby:" + s2 + ";Index:" + s5 + ";Num:" + encodeURIComponent(s3) + ";Start:" + encodeURIComponent(s4) + ";Repeat:" + s6 + ";");
                                } else {
                                    return "";
                                }
                                s1 = InputV($id(objid + "T12"));
                                if (s1.length > 0) {
                                    xml.setNodeValue("xml/sycms", encodeURIComponent(s1));
                                } else {
                                    return "";
                                }
                                break;
                            }
                        default:
                            {
                                xml.delAttrib("xml/sycms", "for");
                                var s0 = InputV($id(objid + "T1"));
                                if (s0.isDigit() && s0.length > 0) {
                                    xml.setAttrib("xml/sycms", "at", s0);
                                } else {
                                    return "";
                                }
                                s0 = null;
                                s1 = InputV($id(objid + "T2"));
                                if (s1.length > 0) {
                                    if (s1.indexOf("||") != -1 && s1.replace("|/g", "").length > 0) {
                                        while (xml.getNode("xml/sycms/item")) {
                                            xml.delNode("xml/sycms/item");
                                        }
                                        var s2 = s1.split("||");
                                        for (var i = 0; i < s2.length; i++) {
                                            if (s2[i].length > 0) {
                                                xml.InsertBeforeChild("xml/sycms", "item", encodeURIComponent(s2[i]));
                                            }
                                        }
                                        s2 = null;
                                    } else {
                                        return "";
                                    }
                                } else {
                                    return "";
                                }
                                break;
                            }
                    }
                    break;
                }
            case "factor_if":       //条件 表达式
                {
                    var T1Help = $id(objid + "T1Help").value;
                    if (T1Help.length > 0) {
                        xml.setAttrib("xml/sycms", "help", T1Help.split("\"").join(""));
                    } else {
                        xml.delAttrib("xml/sycms", "help");
                    }
                    var s2 = InputV($id(objid + "T40"));
                    xml.delAttrib("xml/sycms", "at");
                    var DivObj = $("#" + objid + "ValueView").children("div");
                    if (DivObj.length > 0) {
                        var icount = 0;
                        while (xml.getNode("xml/sycms/item")) {
                            xml.delNode("xml/sycms/item");
                        }
                        for (var i = 0; i < DivObj.length; i++) {
                            var input = DivObj.eq(i).find("input[name='" + objid + "T2']");
                            var textarea = DivObj.eq(i).find("textarea[name='" + objid + "T3']");
                            var select = DivObj.eq(i).find("select[name='" + objid + "T4']");
                            var atinput = DivObj.eq(i).find("input[name='" + objid + "T5']");
                            if (input.length == 1 && textarea.length == 1) {
                                if (input.val().length > 0 && textarea.val().length > 0) {
                                    if (ShowCallBack_LabelSave(textarea.get(0))) {
                                        return "";
                                    }
                                    xml.InsertBeforeChild("xml/sycms", "item", encodeURIComponent(textarea.val()), [{ name: "value", value: encodeURIComponent(input.val()) }, { name: "for", value: encodeURIComponent(select.val()) }, { name: "at", value: encodeURIComponent(atinput.val()) }]);
                                    icount++;
                                }
                            }
                        }
                        xml.delNode("xml/sycms/default");
                        if (s2.length > 0) {
                            if (ShowCallBack_LabelSave($id(objid + "T40"))) {
                                return "";
                            }
                            xml.InsertBeforeChild("xml/sycms", "default", encodeURIComponent(s2));
                        } else if (icount <= 0) {
                            icount = null;
                            s0 = null;
                            s2 = null;
                            return "";
                        }
                        icount = null;
                    } else if (s2.length <= 0) {
                        s0 = null;
                        s2 = null;
                        return "";
                    }
                    s0 = null;
                    s2 = null;
                    break;
                }
            case "template":                //模板
                {
                    var style = decodeURIComponent(xml.getAttrib("xml/sycms", "style"));
                    switch (style) {
                        case "Nav":
                            {
                                str = InputV($id(objid + "T11"));
                                if (str.length > 0) {
                                    var link = InputV($id(objid + "T66_2"));
                                    var view = InputV($id(objid + "T66_1"));
                                    if (link.length > 0 && view.length > 0) {
                                        var Navxml = new XML();
                                        Navxml.SetXML("<?xml version='1.0' encoding='utf-8'?><xml><sycms type=\"Nav\">\t\r\n</sycms></xml>");
                                        Navxml.setAttrib("xml/sycms", "name", MdbList[parseInt(str)][1]);
                                        Navxml.setAttrib("xml/sycms", "link", encodeURIComponent(link));
                                        Navxml.setAttrib("xml/sycms", "view", encodeURIComponent(view));
                                        Navxml.setNodeValue("xml/sycms", encodeURIComponent(InputV($id(objid + "T12"))));
                                        Navxml.setAttrib("xml/sycms", "depth", encodeURIComponent(InputV($id(objid + "T13"))));
                                        var o = $id(objid + "T4");
                                        s1 = ShowCallBack_At(o);
                                        if (s1.length > 0) {
                                            Navxml.setAttrib("xml/sycms", "at", s1);
                                        } else {
                                            Navxml.delAttrib("xml/sycms", "at");
                                        }
                                        s1 = InputV($id(objid + "T14"));
                                        if (s1.length > 0)
                                        {
                                            Navxml.setAttrib("xml/sycms", "blank", s1);
                                        } else {
                                            Navxml.delAttrib("xml/sycms", "blank");
                                        }
                                        if ($id(objid + "T15_0").checked) {
                                            Navxml.setAttrib("xml/sycms", "current", "True");
                                        } else {
                                            Navxml.setAttrib("xml/sycms", "current", "False");
                                        }
                                        var style = InputV($id(objid + "T17"));
                                        if (style) {
                                            Navxml.setAttrib("xml/sycms", "style", encodeURIComponent(style));
                                        } else {
                                            Navxml.delAttrib("xml/sycms", "style");
                                        }
                                        $("#" + objid + "T1").val(Navxml.GetString("xml/sycms"));
                                        s1 = null;
                                        Navxml = null;
                                    } else {
                                        return "";
                                    }
                                } else {
                                    return "";
                                }
                                break;
                            }
                        case "Sys":
                            {
                                str = InputV($id(objid + "T11"));
                                if (str.length > 0) {
                                    var style = $("input[name='SystemStyleList']:checked").val();
                                    style = style ? style : "";
                                    var tem = $("input[name='SystemTemList']:checked").val();
                                    tem = tem ? tem : "";
                                    if (style.length > 0 && tem.length > 0) {
                                        var Sysxml = new XML();
                                        Sysxml.SetXML("<?xml version='1.0' encoding='utf-8'?><xml><sycms type=\"TemSys\">\t\r\n</sycms></xml>");
                                        Sysxml.setAttrib("xml/sycms", "name", encodeURIComponent(MdbList[parseInt(str)][1]));
                                        Sysxml.setAttrib("xml/sycms", "style", encodeURIComponent(style));
                                        Sysxml.setAttrib("xml/sycms", "tem", encodeURIComponent(tem));
                                        if ($("#" + objid + "ATtab2").is(":hidden"))     //隐藏
                                        {
                                            Sysxml.delAttrib("xml/sycms", "getwhere");
                                            //条件
                                            o = $id(objid + "T4");
                                            s1 = ShowCallBack_At(o);
                                            if (s1.length > 0) {
                                                if (s1 == "ERROR") {
                                                    if (!onshowerror) {
                                                        Dialog.error("错误：请检查【条件设置】里的（）是否成双成对。");
                                                    }
                                                    return "";
                                                } else {
                                                    Sysxml.setAttrib("xml/sycms", "at", s1);
                                                }
                                            } else {
                                                Sysxml.delAttrib("xml/sycms", "at");
                                            }
                                        } else {
                                            Sysxml.delAttrib("xml/sycms", "at");
                                            var str1 = $id(objid + "T21").value;
                                            if (str1.length > 0) {
                                                if (ShowCallBack_LabelSave($id(objid + "T21"))) {
                                                    return "";
                                                }
                                                Sysxml.setAttrib("xml/sycms", "getwhere", encodeURIComponent(str1));
                                            }
                                        }
                                        if ($("#" + objid + "ordertab2").is(":hidden"))     //隐藏
                                        {
                                            Sysxml.delAttrib("xml/sycms", "getorder");
                                            //排序
                                            o = $id(objid + "T9");
                                            s1 = "";
                                            if (o.options.length > 0) {
                                                for (var i = 0; i < o.options.length; i++) {
                                                    if (o.options[i].value.length > 0) {
                                                        s1 += o.options[i].value + ";";
                                                    }
                                                }
                                            }
                                            if (s1.length > 0) {
                                                Sysxml.setAttrib("xml/sycms", "order", s1);
                                            } else {
                                                Sysxml.delAttrib("xml/sycms", "order");
                                            }
                                        } else {
                                            Sysxml.delAttrib("xml/sycms", "order");
                                            var str1 = $id(objid + "T22").value;
                                            if (str1.length > 0) {
                                                if (ShowCallBack_LabelSave($id(objid + "T22"))) {
                                                    return "";
                                                }
                                                Sysxml.setAttrib("xml/sycms", "getorder", encodeURIComponent(str1));
                                            }
                                        }
                                        //显示范围
                                        if ($("#" + objid + "T7_0_0").is(":checked")) {
                                            s1 = InputV($id(objid + "T7_1"));
                                            s2 = InputV($id(objid + "T7_2"));
                                            if (s1.length == 0) {
                                                s1 = "";
                                            }
                                            if (s2.length == 0) {
                                                s2 = "";
                                            }
                                            if (s1.isDigit() || s2.isDigit() || s1.Left(4) == "[变量]" || s2.Left(4) == "[变量]") {
                                                if (s1.length > 0) {
                                                    s1 = "End:" + encodeURIComponent(ReplaceMemberText(s1)) + ";";
                                                }
                                                if (s2.length > 0) {
                                                    s2 = "Start:" + encodeURIComponent(ReplaceMemberText(s2)) + ";";
                                                }
                                                if (s1.length > 0 || s2.length > 0) {
                                                    Sysxml.setAttrib("xml/sycms", "scope", s1 + s2);
                                                } else {
                                                    Sysxml.delAttrib("xml/sycms", "scope");
                                                }
                                            } else {
                                                Sysxml.delAttrib("xml/sycms", "scope");
                                            }
                                        } else {
                                            Sysxml.delAttrib("xml/sycms", "scope");
                                        }
                                        if (InputV($id(objid + "T13_1"))) {
                                            s1 = "Style:" + InputV($id(objid + "T13_2")) + ";Size:" + encodeURIComponent(ReplaceMemberText(InputV($id(objid + "T13_3")))) + ";";
                                            s2 = InputV($id(objid + "T13_14"));
                                            if (s2.length > 0 && s2 != "0") {
                                                s1 += "Max:" + encodeURIComponent(s2) + ";";
                                            }
                                            s2 = InputV($id(objid + "T13_7"));
                                            if (s2.length > 0) {
                                                s1 += "RecordName:" + encodeURIComponent(s2) + ";";
                                            }
                                            Sysxml.setAttrib("xml/sycms", "page", s1);
                                            Sysxml.delAttrib("xml/sycms", "scope");
                                        } else {
                                            Sysxml.delAttrib("xml/sycms", "page");
                                        }

                                        s1 = InputV($id(objid + "T12"));
                                        if (s1.length > 0) {
                                            Sysxml.InsertBeforeChild("xml/sycms", "item", encodeURIComponent(s1));
                                        }
                                        s1 = style.split(',');
                                        //link:1;title:1;pic:1;summary:1;
                                        var s2 = RegExpValue(s1[1], "link");
                                        if (s2 == "1") {
                                            s3 = InputV($id(objid + "T66_2"));
                                            s4 = InputV($id(objid + "T66_22"));
                                            Sysxml.InsertBeforeChild("xml/sycms", "item", encodeURIComponent(s4), [{ name: "type", value: "link" }, { name: "word", value: s3 }]);
                                        }
                                        s2 = RegExpValue(s1[1], "title");
                                        if (s2 == "1") {
                                            s3 = InputV($id(objid + "T66_1"));
                                            s4 = InputV($id(objid + "T66_11"));
                                            Sysxml.InsertBeforeChild("xml/sycms", "item", encodeURIComponent(s4), [{ name: "type", value: "title" }, { name: "word", value: s3 }]);
                                        }
                                        s2 = RegExpValue(s1[1], "pic");
                                        if (s2 == "1") {
                                            s3 = InputV($id(objid + "T66_3"));
                                            s4 = InputV($id(objid + "T66_33"));
                                            Sysxml.InsertBeforeChild("xml/sycms", "item", encodeURIComponent(s4), [{ name: "type", value: "pic" }, { name: "word", value: s3 }]);
                                        }
                                        s2 = RegExpValue(s1[1], "Summary");
                                        if (s2 == "1") {
                                            s3 = InputV($id(objid + "T66_4"));
                                            s4 = InputV($id(objid + "T66_44"));
                                            Sysxml.InsertBeforeChild("xml/sycms", "item", encodeURIComponent(s4), [{ name: "type", value: "summary" }, { name: "word", value: s3 }]);
                                        }
                                        $("#" + objid + "T1").val(Sysxml.GetString("xml/sycms"));
                                    } else {
                                        return "";
                                    }
                                    Sysxml = null;
                                } else {
                                    return "";
                                }
                                break;
                            }
                    }
                    //有ajax保存功能
                    var InputList = $("#" + objid + "T1MemberList input");
                    var str = ""; //记录变量值
                    if (InputList.length > 0) {
                        for (i = 0; i < InputList.length; i = i + 3) {
                            if (InputList.eq(i).val().length > 0 && InputList.eq(i + 1).val().length > 0) {
                                str += InputList.eq(i).val() + ":" + encodeURIComponent(InputList.eq(i + 1).val()) + ";";
                            }
                        }
                    }
                    InputList = null;
                    var Name = $("#" + objid + "T0").val();
                    if (Name.length > 0) {
                        xml.setNodeValue("xml/sycms", Name);
                    }
                    Name = null;
                    if (str.length > 0) {
                        xml.setAttrib("xml/sycms", "parameter", str);
                    } else {
                        xml.delAttrib("xml/sycms", "parameter");
                    }
                    str = null;
                    break;
                }
            case "get":     //传值
                {
                    var s0 = InputV($id(objid + "T3"));
                    if (s0.length > 0) {
                        xml.setAttrib("xml/sycms", "name", encodeURIComponent(s0));
                        var s1 = InputV($id(objid + "T4"));
                        if (s1.length > 0) {
                            xml.setAttrib("xml/sycms", "value", encodeURIComponent(s1));
                        } else {
                            xml.delAttrib("xml/sycms", "value");
                        }
                        s1 = "";
                        s1 = InputV($id(objid + "T3_1"));
                        if (s1.length > 0) {
                            xml.setAttrib("xml/sycms", "confirm", encodeURIComponent(s1));
                        } else {
                            xml.delAttrib("xml/sycms", "confirm");
                        }
                        s0 = null;
                        s1 = null;
                        str = "";
                        s1 = InputV($id(objid + "T17_1"));
                        if (s1.length > 0) {
                            str += "Format:" + encodeURIComponent(s1) + ";";
                        }
                        s1 = InputV($id(objid + "T17_2"));
                        if (s1.length > 0) {
                            str += "Added:" + encodeURIComponent(s1) + ";";
                        }
                        s1 = InputV($id(objid + "T17_3"));
                        if (s1.length > 0) {
                            str += "Fill:" + encodeURIComponent(s1) + ";";
                        }
                        s1 = InputV($id(objid + "T20_1"));
                        if (s1.length > 0) {
                            str += "Trans:" + encodeURIComponent(s1) + ";";
                        }
                        if ($id(objid + "T16").checked) {
                            str += "JsFat:1;";
                        }
                        if ($id(objid + "T16_1").checked) {
                            str += "UrlFat:1;";
                        }
                        if ($id(objid + "T16_2").checked) {
                            str += "HtmlFat:1;";
                        }
                        if ($id(objid + "T16_3").checked) {
                            str += "SqlFat:1;";
                        }
                        if (str.length > 0) {
                            xml.setAttrib("xml/sycms", "style", str);
                        } else {
                            xml.delAttrib("xml/sycms", "style");
                        }
                        str = null;
                    } else {
                        s0 = null;
                        return "";
                    }
                    break;
                }
            case "sys":     //传值
                {
                    var s0 = InputV($id(objid + "T1"));
                    if (s0.length > 0) {
                        xml.setAttrib("xml/sycms", "name", encodeURIComponent(SysList[s0][1]));
                        var genre = InputValue([[objid + "T2", 2, 1]], $("#" + objid + "StyleView").get(0));
                        xml.setAttrib("xml/sycms", "genre", encodeURIComponent(genre));

                        var style = "";
                        if (SysList[Name_i][3] && SysList[Name_i][4]) {
                            var v1 = SysList[Name_i][3].split(",");
                            var v2 = SysList[Name_i][4].split(",");
                            for (var i = 0; i < v1.length; i++) {
                                var v3 = "";
                                var v3obj = $("input[name='" + objid + v2[i] + "']");
                                if (v3obj.length > 0) {
                                    switch (v3obj.get(0).type) {
                                        case "radio":
                                        case "checkbox":
                                            {
                                                v3 = $("input[name='" + objid + v2[i] + "']:checked").val();
                                                break;
                                            }
                                        default:
                                            {
                                                v3 = v3obj.val();
                                                break;
                                            }
                                    }
                                } else {
                                    v3obj = $("select[name='" + objid + v2[i] + "']");
                                    if (v3obj.length > 0) {
                                        v3 = v3obj.val();
                                    }
                                }
                                if (v3) {
                                    style += v1[i] + ":" + v3 + ";";
                                }
                            }
                        }
                        if (style) {
                            xml.setAttrib("xml/sycms", "style", style);
                        } else {
                            xml.delAttrib("xml/sycms", "style");
                        }
                        s0 = null;
                    } else {
                        s0 = null;
                        return "";
                    }
                    break;
                }
            case "basictem":
                {
                    var s0 = InputV($id(objid + "T0_1"));
                    if (s0.length > 0) {
                        xml.setAttrib("xml/sycms", "id", encodeURIComponent(s0));
                        s0 = null;
                    } else {
                        s0 = null;
                        return "";
                    }
                    break;
                }
            case "pagelist":
                {
                    var s0 = $("#" + objid + "TT001").val();
                    xml.setAttrib("xml/sycms", "name", encodeURIComponent(s0));
                    break;
                }
            case "cookie":     //传值
                {
                    var s0 = InputV($id(objid + "T0"));
                    if (s0.length > 0) {
                        xml.setAttrib("xml/sycms", "name", encodeURIComponent(s0));
                        var range = InputValue([[objid + "T3", 2, 1]], $("#" + objid + "StyleView").get(0));
                        xml.setAttrib("xml/sycms", "range", encodeURIComponent(range));
                        if (range == "1") {
                            var genre = InputValue([[objid + "T2", 2, 1]], $("#" + objid + "StyleView").get(0));
                            xml.setAttrib("xml/sycms", "genre", encodeURIComponent(genre));
                            genre = null;
                        } else {
                            xml.delAttrib("xml/sycms", "genre");
                        }
                        s1 = $id(objid + "T4").value
                        if (s1.length>0 && s1.isDigit()) {
                            xml.setAttrib("xml/sycms", "array", encodeURIComponent(s1));
                        } else {
                            xml.delAttrib("xml/sycms", "array");
                        }
                        range = null;
                        s0 = null;
                    } else {
                        s0 = null;
                        return "";
                    }
                    break;
                }
            case "varvalue":
                {
                    var s0 = InputV($id(objid + "T0"));
                    if (s0.length > 0) {
                        xml.setAttrib("xml/sycms", "name", encodeURIComponent(s0.split(".").join("").split("|||").join()));
                        s1 = InputV($id(objid + "T0_0"));
                        if (s1 && s1.length > 0) {
                            xml.setAttrib("xml/sycms", "replace", s1);
                        } else {
                            xml.delAttrib("xml/sycms", "replace");
                        }
                        if ($("#" + objid + "Tabletab2").is(":visible"))     //隐藏
                        {
                            str = InputV($id(objid + "T1"));
                            if (str.length > 0) {
                                //数据拼写名称
                                xml.setAttrib("xml/sycms", "mdbname", MdbList[parseInt(str)][1]);
                                //条件
                                if ($id(objid + "T4_100Check").checked) {
                                    var o = $id(objid + "T4");
                                    s1 = ShowCallBack_At(o);
                                    if (s1.length > 0) {
                                        if (s1 == "ERROR") {
                                            Dialog.error("错误：请检查【查询条件】里的（）是否成双成对。");
                                            return "";
                                        } else {
                                            xml.setAttrib("xml/sycms", "at", s1);
                                        }
                                    } else {
                                        xml.delAttrib("xml/sycms", "at");
                                    }
                                    o = null;
                                } else {
                                    s1 = "::" + $id(objid + "T4_100").value + ":GET;";
                                    xml.setAttrib("xml/sycms", "at", s1);
                                }
                                xml.setNodeValue("xml/sycms", encodeURIComponent(" "));
                            } else {
                                return "";
                            }
                        } else {
                            var s1 = InputV($id(objid + "T001"));
                            if (s1.length > 0) {
                                if (ShowCallBack_LabelSave($id(objid + "T001"))) {
                                    return "";
                                }
                                xml.setNodeValue("xml/sycms", encodeURIComponent(s1));
                            } else {
                                xml.setNodeValue("xml/sycms", encodeURIComponent(" "));
                            }
                            xml.delAttrib("xml/sycms", "at");
                            xml.delAttrib("xml/sycms", "mdbname");
                            s0 = null;
                            s1 = null;
                        }
                    } else {
                        return "";
                    }
                    break;
                }
            case "var":
                {
                    var s1 = InputV($id(objid + "T0"));
                    if (s1.length > 0) {
                        xml.setAttrib("xml/sycms", "name", encodeURIComponent(s1));
                        var format = InputV($id(objid + "T1"));
                        if (format.length > 0) {
                            xml.setAttrib("xml/sycms", "format", encodeURIComponent(format));
                        } else {
                            xml.delAttrib("xml/sycms", "format");
                        }
                        str = "";
                        if ($id(objid + "T16").checked) {
                            str += "JsFat:1;";
                        }
                        if ($id(objid + "T16_1").checked) {
                            str += "UrlFat:1;";
                        }
                        if ($id(objid + "T16_2").checked) {
                            str += "HtmlFat:1;";
                        }
                        if ($id(objid + "T16_3").checked) {
                            str += "SqlFat:1;";
                        }
                        if (str.length > 0) {
                            xml.setAttrib("xml/sycms", "style", str);
                        } else {
                            xml.delAttrib("xml/sycms", "style");
                        }
                    } else {
                        return "";
                    }
                    s1 = null;
                    break;
                }
            case "count":       //表达式计算
                {
                    s1 = InputV($id(objid + "T1"));
                    s2 = InputV($id(objid + "T2"));
                    if (s1.length > 0) {
                        var s4 = "";
                        if (s2.length > 0) {
                            s4 += "Num:" + s2 + ";";
                        }
                        if ($id(objid + "T3").checked) {
                            s4 += "Max:1;";
                        }
                        if (s4.length > 0) {
                            xml.setAttrib("xml/sycms", "style", s4);
                        } else {
                            xml.delAttrib("xml/sycms", "style");
                        }
                        xml.setNodeValue("xml/sycms", encodeURIComponent(s1));
                    } else {
                        return "";
                    }
                    break;
                }
            case "user_login":
                {
                    if ($id(objid + "T1_0").checked) {
                        xml.setAttrib("xml/sycms", "return", "js");
                        xml.delAttrib("xml/sycms", "message");
                        xml.delAttrib("xml/sycms", "url");
                    } else {
                        xml.setAttrib("xml/sycms", "return", "web");
                        s1 = InputV($id(objid + "T2"));
                        s2 = InputV($id(objid + "T3"));
                        if (s1.length == 0 && s2.length == 0) {
                            return "";
                        } else {
                            if (s1.length > 0) {
                                xml.setAttrib("xml/sycms", "message", encodeURIComponent(s1));
                            } else {
                                xml.delAttrib("xml/sycms", "message");
                            }
                            if (s2.length > 0) {
                                xml.setAttrib("xml/sycms", "url", encodeURIComponent(s2));
                            } else {
                                xml.delAttrib("xml/sycms", "url");
                            }
                        }
                        s1 = null;
                        s2 = null;
                    }
                    break;
                }
            case "sys_gotourl":
                {
                    s1 = InputV($id(objid + "T1"));
                    if (s1.length > 0) {
                        xml.setAttrib("xml/sycms", "url", encodeURIComponent(s1));
                    } else {
                        return "";
                    }
                    break;
                }
        }
    } else {
        return "";
    }
    str = null;
    s = null;
    s1 = null;
    s2 = null;
    o = null;
    str = xml.GetString("xml/sycms");
    xml.Dispose();
    xml = null;
    IECollectGarbage();
    return str;
}

//读取控件值（单个）
function InputV(obj) {
    var str = "";
    switch (obj.type) {
        case "select-one":
            {
                if (obj.selectedIndex >= 0) {
                    str = obj.options[obj.selectedIndex].value;
                }
                break;
            }
        case "checkbox":
            {
                str = obj.checked;
                break;
            }
        default:
            {
                str = obj.value;
                break;
            }
    }
    return str;
}
//读取控件值(多个)
function InputValue(t, objAll) {
    var str = "";
    var s = "";
    var objs = objAll.getElementsByTagName("input")
    for (var i = 0; i < t.length; i++) {
        s = "";
        switch (t[i][1]) {
            case 1: //文本框
                {
                    s += $id(t[i][0]).value;
                    break;
                }
            case 2: //单选
                {
                    for (var ii = 0; ii < objs.length; ii++) {
                        if ((objs[ii].type == "radio") && (objs[ii].name == t[i][0])) {
                            if (objs[ii].checked) {
                                s += objs[ii].value;
                                break;
                            }
                        }
                    }
                    break;
                }
            case 3: //复选
                {
                    for (var ii = 0; ii < objs.length; ii++) {
                        if ((objs[ii].type == "checkbox") && (objs[ii].name == t[i][0])) {
                            if (objs[ii].checked) {
                                s += objs[ii].value + "|";
                            }
                        }
                    }
                    break;
                }
            case 4: //下拉
                {
                    if ($id(t[i][0]).selectedIndex >= 0 && $id(t[i][0]).selectedIndex < $id(t[i][0]).options.length) {
                        s += $id(t[i][0]).options[$id(t[i][0]).selectedIndex].value;
                    }
                }
        }
        if (t[i][2] == 1 && s.length == 0) {
            str = "";
            break;
        }
        str += s + strOFF;
    }
    str = str.substr(0, str.length - 1);
    objs = null;
    s = null;
    return str;
}
//Seo使得下拉函数
function Label_Sell_Mdb_Seo(obj, objid) {
    var o3 = obj.options[obj.selectedIndex].value;
    var ObjView = $("#" + objid + "ObjView");
    var ObjFieldView = $("#" + objid + "ObjFieldView");
    ObjView.find("*").remove();
    ObjFieldView.find("*").remove();
    if (o3.length > 0) {
        var zjmess = WordListZJ(o3);
        $("#" + objid + "T0").val(MdbList[o3][1] + "." + zjmess.Name);
        Label_Sell_Mdb_SeoValue(o3, objid, ObjView, ObjFieldView);
    }
}
function Label_Sell_Mdb_SeoValue(o3, objid, ObjView, ObjFieldView, strBo) {
    var SelectList = ObjFieldView.find("fieldset");
    var ReturnValSet = "|";
    SelectList.each(function () {
        var val = $(this).attr("name");
        if (val != null && val != undefined && val.length > 0) {
            ReturnValSet += val.split(',')[0] + "|";
        }
        val = null;
    });
    if (ReturnValSet.indexOf("|" + MdbList[o3][1] + "|") == -1) {
        var strW = "";
        for (var i = 0; i < WordList[o3].length; i++) {
            if (WordList[o3][i][3] == 1) {
                strW += "<option value=\"" + WordList[o3][i][1] + "\">" + WordList[o3][i][0] + "</option>";
            }
        }
        var str = "<fieldset name=\"" + MdbList[o3][1] + "\" style=\"clear:both;\"><legend>" + MdbList[o3][0] + "</legend>Title：<select" + ($id(objid + "T22_0").checked ? "" : " disabled=\"disabled\"") + " style=\"width:100px;\">" + strW + "</select>&nbsp;&nbsp;KeyWords：<select" + ($id(objid + "T22_1").checked ? "" : " disabled=\"disabled\"") + " style=\"width:100px;\">" + strW + "</select>&nbsp;&nbsp;Description：<select" + ($id(objid + "T22_2").checked ? "" : " disabled=\"disabled\"") + " style=\"width:100px;\">" + strW + "</select>";
        str += "</fieldset>";
        ObjFieldView.append(str);
    }

    if (!strBo && MdbConn[o3].length > 0) {
        SelectList = ObjView.find("select");
        var ReturnVal = "|";
        SelectList.each(function () {
            var val = $(this).val();
            if (val != null && val != undefined && val.length > 0) {
                ReturnVal += val.split(',')[0] + "|";
            }
            val = null;
        });
        var strbo = false;
        var str = "<fieldset style=\"float:left;width:225px;\"><legend>-->> " + (SelectList.length + 1) + "、</legend><select onchange=\"Label_Sell_Mdb_SeoSe(this, '" + objid + "')\" name=\"" + objid + "SelectCon\" style=\"width:220px;\"><option value=\"\">请选择</option>";
        for (var i = 0; i < MdbConn[o3].length; i++) {
            for (var j = 0; j < MdbList.length; j++) {
                if (ReturnVal.indexOf("|" + MdbList[j][1] + "|") == -1 && MdbConn[o3][i][0] == MdbList[j][2] && MdbConn[o3][i][3] == MdbList[j][5]) {
                    strbo = true;
                    if (Label_Sell_Mdb_SeoDG(j)) {  //自身的向上级目录循环
                        str += "<option value=\"" + MdbList[j][1] + ",1\">" + MdbList[j][0] + "[" + MdbList[j][2] + "](递归父级)</option>";
                    }
                    str += "<option value=\"" + MdbList[j][1] + "\">" + MdbList[j][0] + "[" + MdbList[j][2] + "]</option>";
                    break;
                }
            }
        }
        str += "</select></fieldset>";
        if (strbo) {
            ObjView.append(str);
        }
    }
}
//内部下拉框选择的时候添加
function Label_Sell_Mdb_SeoSe(obj, objid) {
    var v = obj.options[obj.selectedIndex].value;
    var v1 = v.split(',');
    v = v1[0];
    var strBo = "";
    if (v1[1] == "1") {
        strBo = "1";
    }
    var o3 = -1;
    for (var i = 0; i < MdbList.length; i++) {
        if (MdbList[i][1] == v) {
            o3 = i;
            break;
        }
    }
    var thisParent = $(obj).parent();
    var NextObj = thisParent.next();
    while (NextObj.length > 0) {
        NextObj.remove();
        NextObj = thisParent.next();
    }
    var ObjView = $("#" + objid + "ObjView");
    var ObjFieldView = $("#" + objid + "ObjFieldView");
    var SelectList = ObjView.find("select");
    var FieldSetList = ObjFieldView.find("fieldset");
    for (var j = SelectList.length; j < FieldSetList.length; j++) {
        FieldSetList.eq(j).remove();
    }
    if (o3 != -1) {
        Label_Sell_Mdb_SeoValue(o3, objid, ObjView, ObjFieldView, strBo);
    }
}

///判断自己是否循环自己
function Label_Sell_Mdb_SeoDG(MdbI) {
    var bo = false;
    for (var i = 0; i < MdbConn[MdbI].length; i++) {
        if (MdbConn[MdbI][i][0] == MdbList[MdbI][2] && MdbConn[MdbI][i][3] == MdbList[MdbI][5]) {
            bo = true;
            break;
        }
    }
    return bo;
}
//常规新闻里第一个SELECT控件的事件
//obj为控件自己 objid为上函数中
function Label_Sell_Mdb(obj, objid, NaviType, NoJoin) {
    var o1 = $id(objid + "T4_2"); //条件设置
    var o1_6 = $id(objid + "T6_2");
    var o2 = $id(objid + "T9_2"); //排序设置
    var o2_7 = $id(objid + "T9_7"); //排序设置
    var o6 = $id(objid + "T4_7");
    var o6_6 = $id(objid + "T6_7");
    var o66_1 = $id(objid + "T66_1");
    var o66_2 = $id(objid + "T66_2");
    var o66_3 = $id(objid + "T66_3");
    var o66_4 = $id(objid + "T66_4");
    var oT11_2 = $id(objid + "T11_2");
    var oT11_1 = $id(objid + "T11_1");
    if (o1) {
        DelValue(o1);
    }
    if (o1_6 && o1_6.type == "select-one") {
        DelValue(o1_6);
    }
    if (o2) {
        DelValue(o2);
        addItem(o2, "请选择", "");
        addItem(o2, "随机取记录", "newid()");
    }
    if (o2_7 && o2_7.type == "select-one") {
        DelValue(o2_7);
        addItem(o2_7, "请选择", "");
        addItem(o2_7, "随机取记录", "newid()");
    }
    if (o66_1) {
        DelValue(o66_1);
    }
    if (o66_2) {
        DelValue(o66_2);
        if (NaviType != 2) {
            addItem(o66_2, "请选择", "");
        }
    }
    if (o66_3) {
        DelValue(o66_3);
    }
    if (o66_4) {
        DelValue(o66_4);
    }
    if (oT11_2) {
        DelValue(oT11_2);
        addItem(oT11_2, "请选择","");
    }
    if (o6) {
        DelValue(o6);
        addItem(o6, "可选字段", "");
    }
    if (o6_6 && o6_6.type == "select-one") {
        DelValue(o6_6);
        addItem(o6_6, "可选字段", "");
    }
    var o3 = "";
    if (typeof (obj) == "string") {
        o3 = obj;
    } else {
        o3 = obj.options[obj.selectedIndex].value;
    }
    if (o3.length > 0) {
        var w = WordList[o3];
        for (var i = 0; i < AndOrList.length; i++) {
            addItem(o1, AndOrList[i][1], AndOrList[i][0]);
            if (o1_6 && o1_6.type == "select-one") {
                addItem(o1_6, AndOrList[i][1], AndOrList[i][0]);
            }
        }
        var o4 = MdbList[o3][0];
        var o4_4 = MdbList[o3][1];
        if (NaviType==1) {
            var CheckObj_0 = $id(objid + "T4_100");
            if (CheckObj_0) {
                var zjmess = WordListZJ(o3);
                $("#" + objid + "T4_100Span").html(zjmess.Title + "[" + zjmess.Name + "]接收" + zjmess.Name + "的后台传值（绑定的栏目或内容）或者是网站传值（看区块设置）。");
                $("#" + objid + "T4_100").val(o4_4 + "." + zjmess.Name);
            }
        }

        if (oT11_1) {
            $(oT11_1).attr("LabelListClass", o4_4);
        }
        for (var i = 0,wi;wi=w[i++];) {
            if (wi[4] == 1) {
                addItem(o1, "[" + o4 + "]" + wi[0], o4_4 + "." + wi[1] + strOFF + wi[2]);
                if (o1_6 && o1_6.type == "select-one") {
                    addItem(o1_6, "[" + o4 + "]" + wi[0], o4_4 + "." + wi[1] + strOFF + wi[2]);
                }
            }
            //字段
            if (wi[3] == 1) {
                if (oT11_2) {
                    addItem(oT11_2, "[" + o4 + "]" + wi[0], o4_4 + "." + wi[1]);
                }
                if (o6) {
                    addItem(o6, "[" + o4 + "]" + wi[0], o4_4 + "." + wi[1]);
                }
                if (o6_6 && o6_6.type == "select-one") {
                    addItem(o6_6, "[" + o4 + "]" + wi[0], o4_4 + "." + wi[1]);
                }
                if (o66_1) {
                    addItem(o66_1, "[" + o4 + "]" + wi[0], o4_4 + "." + wi[1]);
                }
                if (o66_2) {
                    addItem(o66_2, "[" + o4 + "]" + wi[0], o4_4 + "." + wi[1]);
                }
                if (o66_3) {
                    addItem(o66_3, "[" + o4 + "]" + wi[0], o4_4 + "." + wi[1]);
                }
                if (o66_4) {
                    addItem(o66_4, "[" + o4 + "]" + wi[0], o4_4 + "." + wi[1]);
                }
            }
            if (wi[5] == 1) {
                if (o2) {
                    addItem(o2, "[" + o4 + "]" + wi[0], o4_4 + "." + wi[1] + strOFF + wi[2]);
                }
                if (o2_7 && o2_7.type == "select-one") {
                    addItem(o2_7, "[" + o4 + "]" + wi[0], o4_4 + "." + wi[1]);
                }
            }
        }
        

        var o5 = null;
        if (!NoJoin) {
            if (MdbConn[o3] != undefined) {
                for (var i = 0; i < MdbConn[o3].length; i++) {
                    for (var j = 0; j < MdbList.length; j++) {
                        if (MdbList[j][2] == MdbConn[o3][i][0] && MdbList[o3][2] != MdbConn[o3][i][0] && MdbList[j][5] == MdbConn[o3][i][3]) {
                            for (var j1 = 0; j1 < WordList[j].length; j1++) {
                                if (WordList[j][j1][4] == 1) {
                                    addItem(o1, "[" + MdbList[j][0] + "]" + WordList[j][j1][0], MdbList[j][1] + "." + WordList[j][j1][1] + strOFF + WordList[j][j1][2]);
                                    if (o1_6 && o1_6.type == "select-one") {
                                        addItem(o1_6, "[" + MdbList[j][0] + "]" + WordList[j][j1][0], MdbList[j][1] + "." + WordList[j][j1][1] + strOFF + WordList[j][j1][2]);
                                    }
                                }

                                if (WordList[j][j1][3] == 1) {
                                    if (oT11_2) {
                                        addItem(oT11_2, "[" + MdbList[j][0] + "]" + WordList[j][j1][0], MdbList[j][1] + "." + WordList[j][j1][1]);
                                    }
                                    if (o6) {
                                        addItem(o6, "[" + MdbList[j][0] + "]" + WordList[j][j1][0], MdbList[j][1] + "." + WordList[j][j1][1]);
                                    }
                                    if (o6_6 && o6_6.type == "select-one") {
                                        addItem(o6_6, "[" + MdbList[j][0] + "]" + WordList[j][j1][0], MdbList[j][1] + "." + WordList[j][j1][1]);
                                    }
                                }

                                if (WordList[j][j1][5] == 1) {
                                    if (o2) {
                                        addItem(o2, "[" + MdbList[j][0] + "]" + WordList[j][j1][0], MdbList[j][1] + "." + WordList[j][j1][1] + strOFF + WordList[j][j1][2]);
                                    }
                                    if (o2_7 && o2_7.type == "select-one") {
                                        addItem(o2_7, "[" + MdbList[j][0] + "]" + WordList[j][j1][0], MdbList[j][1] + "." + WordList[j][j1][1]);
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }
        o4 = null;
        o5 = null;
        o4_4 = null;
        w = null;
    }
    $id(objid + "T4_3").style.display = "none";
    $id(objid + "T4_4").style.display = "none";
    $id(objid + "T4_5").style.display = "none";
    try {
        $id(objid + "T6_3").style.display = "none";
        $id(objid + "T6_4").style.display = "none";
        $id(objid + "T6_5").style.display = "none";
    } catch (e) { }
    o1 = null;
    o1_6 = null;
    o2 = null;
    o6 = null;
    o6_6 = null;
    o66_1 = null;
    o66_2 = null;
    o66_3 = null;
    o66_4 = null;
    oT11_2 = null;
    PageDisable(objid);
    IECollectGarbage();
}
//排序下拉
function SortSelect(obj) {
    var str = "";
    $(WordSort).each(function(i) {
        str += "<option value=\"" + this[1] + "\">" + this[0] + "</option>";
    });
    $(obj).html(str);
    str = null;
}

//日期
function DateListSelect(obj) {
    var str = "";
    $(DateList).each(function(i) {
        str += "<option value=\"" + this[1] + "|" + this[2] + "\">" + this[0] + "</option>";
    });
    $(obj).html(str);
    str = null;
}


//日期显示格式快捷方式
function DateQuickListSelect(obj) {
    var str = Array();
    str.push("<option value=\"\">日期快捷方式选择</option>");
    $(DateQuickList).each(function (i) {
        str.push("<option value=\"" + this[1] + "\">" + this[0] + "</option>");
    });
    $(obj).html(str.join());
    str = null;
}
//日期显示格式快捷方式
function DateFormatListSelect(obj) {
    var str = Array();
    str.push("<option value=\"\">日期快捷方式选择</option>");
    $(DateFormatList).each(function (i) {
        str.push("<option value=\"" + this[1] + "\">" + this[0] + "</option>");
    });
    $(obj).html(str.join());
    str = null;
}
//判断是否系统表信息
function System_DataListFun(Name,SqlLink) {
    Name=Name.toLowerCase();
    SqlLink = SqlLink.toLowerCase();
    var str = false;
    for (var i = 0; i < System_DataList.length; i++) {
        if (SqlLink == System_DataList[i][1]) {
            if (System_DataList[i][2] == 1) {
                if (System_DataList[i][0] == Name) {
                    str = true;
                }
            } else if (Name.length > System_DataList[i][0].length && Name.Left(System_DataList[i][0].length) == System_DataList[i][0]) {
                str = true;
            }
        }
    }
    return str;
}
//字段添加条件时
function LabelJudgeChange(obj, objid, ObjName) {
    if (!ObjName) {
        ObjName = "4";
    }
    var v = obj.options[obj.selectedIndex].value;
    var vt = obj.options[obj.selectedIndex].text;
    var obj_T4 = $id(objid + "T" + ObjName + "_3");
    var t4_3v = "";
    if (obj_T4.selectedIndex != -1) {
        t4_3v = obj_T4.options[obj_T4.selectedIndex].value;
    }
    $id(objid + "T" + ObjName + "_5").style.display = "none";
    if (obj_T4.length > 0)
        DelValue(obj_T4);
    var v_1 = v.split(strOFF);

    var zj = false;
    if (v_1[0]) {
        var v_2 = v_1[0].split(".");
        var v_3 = -1;
        for (var i = 0; i < MdbList.length; i++) {
            if (MdbList[i][1] == v_2[0] && System_DataListFun(MdbList[i][2], MdbList[i][5])) {
                v_3 = i;
                break;
            }
        }
        if (v_3 > -1) {
            for (var i = 0; i < WordList[v_3].length; i++) {
                if (WordList[v_3][i][8] == 1) {
                    if (WordList[v_3][i][1] == v_2[1]) {
                        zj = true;
                    }
                    break;
                }
            }
            if (!zj) {
                for (var i = 0; i < MdbConn[v_3].length; i++) {
                    if (MdbConn[v_3][i][0] != MdbList[v_3][2] && MdbConn[v_3][i][3] == MdbList[v_3][5] && MdbConn[v_3][i][1]==v_2[1]) {
                        //有关联不是自己。并且得
                        var nj = -1;
                        for (var j = 0; j < MdbList.length; j++) {
                            if (MdbList[j][2] == MdbConn[v_3][i][0] && MdbConn[v_3][i][3] == MdbList[j][5] && System_DataListFun(MdbList[j][2], MdbList[j][5])) {
                                nj = j;
                                break;
                            }
                        }
                        if (nj != -1) {
                            for (var j = 0; j < WordList.length; j++) {
                                if (WordList[nj][j][8] == 1) {
                                    if (WordList[nj][j][1] == MdbConn[v_3][i][2]) {
                                        zj = true;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    for (var i = 0; i < LabelJudge.length; i++) {
        if (LabelJudge[i][1].indexOf(v_1[1]) != -1) {//判断是否合格类型
            if (LabelJudge[i][3] == 1) {
                if (zj) {
                    addItem(obj_T4, LabelJudge[i][0].replace("$$", vt), LabelJudge[i][2]);
                }
            } else {
                addItem(obj_T4, LabelJudge[i][0], LabelJudge[i][2]);
            }
        }
    }
    $id(objid + "T" + ObjName + "_4").value = "";
    $id(objid + "T" + ObjName + "_4").style.display = "";
    if (v_1[1] == "1" || v_1[1] == "6") {
        $id(objid + "T" + ObjName + "_4").onkeyup = $id(objid + "T" + ObjName + "_4").onafterpaste = function () {
            //this.value = this.value.Digit();
        }
    } else {
        $id(objid + "T" + ObjName + "_4").onkeyup = $id(objid + "T" + ObjName + "_4").onafterpaste = function () { }
    }
    if (v_1[1] == "3") {
        $id(objid + "T" + ObjName + "_5").style.display = "";
    }
    if ($id(objid + "T" + ObjName + "_3").style.display == "none") {
        $id(objid + "T" + ObjName + "_3").style.display = "";
    }
    if ($id(objid + "T" + ObjName + "_4").style.display == "none") {
        $id(objid + "T" + ObjName + "_4").style.display = "";
    }
    if (zj) {
        $id(objid + "T" + ObjName + "_4").style.display = "none";
    }
    v_1 = null;
    v = null;
    obj_T4 = null;
    t4_3v = null;
}

//条件修改
function ATfun(objid, ObjName,Write) {
    if (!ObjName) {
        ObjName = "4";
    }
    var s1Obj=$("#" + objid + "T" + ObjName);
    var s1 = s1Obj.val();
    if (s1) {
        var s1Index = s1Obj.get(0).selectedIndex;
        var s1Length = s1Obj.get(0).options.length;
        if (s1Index != 0) {
            //FirefoxDisabled(objid + "T" + ObjName + "Sub1", 1);
            FirefoxDisabled(objid + "T" + ObjName + "Sub2", 1);
            FirefoxDisabled(objid + "T" + ObjName + "_Sub1_0", 1);
            FirefoxDisabled(objid + "T" + ObjName + "_Sub1_1", 1);
        } else {
            //FirefoxDisabled(objid + "T" + ObjName + "Sub1");
            FirefoxDisabled(objid + "T" + ObjName + "Sub2");
            FirefoxDisabled(objid + "T" + ObjName + "_Sub1_0");
            FirefoxDisabled(objid + "T" + ObjName + "_Sub1_1");
        }
        FirefoxDisabled(objid + "T" + ObjName + "Sub5", 1);
        FirefoxDisabled(objid + "T" + ObjName + "_Sub2", 1);
        FirefoxDisabled(objid + "T" + ObjName + "_Sub3", 1);
        if ((s1Index + 1) < s1Length) {
            //FirefoxDisabled(objid + "T" + ObjName + "Sub4", 1);
            FirefoxDisabled(objid + "T" + ObjName + "Sub3", 1);
        } else {
            //FirefoxDisabled(objid + "T" + ObjName + "Sub4");
            FirefoxDisabled(objid + "T" + ObjName + "Sub3");
        }
        var s2 = s1.split(":");
        if (!Write) {
            var T4_2 = $id(objid + "T" + ObjName + "_2");
            var T4_2v = null;
            ///字段的列表项
            for (var i = 0; i < T4_2.options.length; i++) {
                if (T4_2.options[i].value.Left(s2[2].length + 1) == (s2[2] + strOFF)) {
                    T4_2.selectedIndex = i;
                    T4_2v = i;
                    break;
                }
            }
            if (s2[1] == "(") {
                $("#" + objid + "T" + ObjName + "_Sub2").attr("checked", "checked");
            } else {
                $("#" + objid + "T" + ObjName + "_Sub2").removeAttr("checked");
            }
            if (s2[s2.length - 1] == ")") {
                $("#" + objid + "T" + ObjName + "_Sub3").attr("checked", "checked");
            } else {
                $("#" + objid + "T" + ObjName + "_Sub3").removeAttr("checked");
            }
            if (T4_2v) {
                LabelJudgeChange(T4_2, objid, ObjName);
                if (s2[3]) {
                    $("#" + objid + "T" + ObjName + "_3").val(s2[3]);
                }
                if (s2[4] && s2[4] != ")") {
                    var T4_5 = $id(objid + "T" + ObjName + "_5");
                    for (var i = 0; i < T4_5.options.length; i++) {
                        var s3 = T4_5.options[i].value.split("|");
                        if (s2[4].indexOf("[" + s3[0] + "]") != -1) {
                            T4_5.selectedIndex = i;
                            s2[4] = s2[4].replace("[" + s3[0] + "]", "");
                        }
                    }
                    $id(objid + "T" + ObjName + "_4").value = decodeURIComponent(s2[4]);
                }
                $("#" + objid + "T" + ObjName + "_View").show();
            }
        } else {
            if (s1Index == 0) {  //换到了第一的位置
                s2[0] = "";
                s3 = s2.join(":");
                tv6 = AtString(s3);
                var option = s1Obj.find("option");
                if (tv6 != null) {
                    option.eq(0).attr("value", s3).html(tv6);
                }
                if (s1Length > 1) {
                    s3 = "AND" + option.eq(1).attr("value");
                    tv6 = AtString(s3);
                    option.eq(1).attr("value", s3).html(tv6);
                }
            } else {
                s2[0] = "AND";
                s3 = s2.join(":");
                tv6 = AtString(s3);
                var option = s1Obj.find("option");
                if (tv6 != null) {
                    option.eq(s1Index).attr("value", s3).html(tv6);
                }
                var s31 = option.eq(0).attr("value").split(":");
                s31[0] = "";
                s3 = s31.join(":");
                tv6 = AtString(s3);
                option.eq(0).attr("value", s3).html(tv6);
            }
        }
        if (s2[0] == "OR") {
            $("#" + objid + "T" + ObjName + "_Sub1_1").attr("checked", "checked");
        } else if (s2[0] == "AND") {
            $("#" + objid + "T" + ObjName + "_Sub1_0").attr("checked", "checked");
        } else {
            $("#" + objid + "T" + ObjName + "_Sub1_1").removeAttr("checked");
            $("#" + objid + "T" + ObjName + "_Sub1_0").removeAttr("checked");
        }
        LabelJudgeChange1($("#" + objid + "T" + ObjName + "_3").get(0), objid);
    } else {
        //FirefoxDisabled(objid + "T" + ObjName + "Sub1");
        FirefoxDisabled(objid + "T" + ObjName + "Sub2");
        FirefoxDisabled(objid + "T" + ObjName + "Sub3");
        //FirefoxDisabled(objid + "T" + ObjName + "Sub4");
        FirefoxDisabled(objid + "T" + ObjName + "Sub5");
        FirefoxDisabled(objid + "T" + ObjName + "_Sub2");
        FirefoxDisabled(objid + "T" + ObjName + "_Sub3");
    }
}

//字段添加的第二个下拉框
function LabelJudgeChange1(obj, objid, ObjName) {
    if (!ObjName) {
        ObjName = "4";
    }
    var v = obj.options[obj.selectedIndex].value;
    var obj_T2 = $id(objid + "T" + ObjName + "_2");
    var t4_2v = obj_T2.options[obj_T2.selectedIndex].value;
    if (t4_2v != "(" && t4_2v != ")") {
        var v_1 = t4_2v.split(strOFF);
        if (v != "VAR" && v != "SYS") {
//            if (v == "GET") {
//                $id(objid + "T" + ObjName + "_7").style.display = "none";
//            } else {
//                $id(objid + "T" + ObjName + "_7").style.display = "";
//            }
            //$id(objid + "T" + ObjName + "_6").style.display = "none";
            $id(objid + "T" + ObjName + "_4").style.display = "";
            //if ((v_1[1] == "1" || v_1[1] == "6") && v != "GET" && v != "LIKE" && v != "NOTLIKE") {
                //$id(objid + "T" + ObjName + "_4").onkeyup = $id(objid + "T" + ObjName + "_4").onafterpaste = function() {
                    //this.value = this.value.Digit();
                //}
            //} else {
                if (v_1[1] == "3") {
                    $id(objid + "T" + ObjName + "_5").style.display = "";
                }
                //$id(objid + "T" + ObjName + "_4").onkeyup = $id(objid + "T" + ObjName + "_4").onafterpaste = function() { }
            //}
        } else {
            $id(objid + "T" + ObjName + "_4").style.display = "none";
//            $id(objid + "T" + ObjName + "_7").style.display = "none";
            //$id(objid + "T" + ObjName + "_6").style.display = "";
        }
        v_1 = null;
    }
    v = null;
    obj_T2 = null;
    t4_2v = null;
}

//字段添加的第四个下拉框
function LabelJudgeChange2(obj, objid, ObjName) {
    if (!ObjName) {
        ObjName = "4";
    }
    var v = obj.options[obj.selectedIndex].value;
    var v_1 = v.split(strOFF);
    if (v_1[1] == "0") {
        $id(objid + "T" + ObjName + "_4").style.display = "none";
    } else {
        $id(objid + "T" + ObjName + "_4").style.display = "";
    }
    v = null;
    v_1 = null;
}

//分页下拉框
function PageListSelect(obj) {
    for (var i = 0; i < PageList.length; i++) {
        addItem(obj, PageList[i][1], PageList[i][0]);
    }
}

//转换字段串功能
function StringfunctionListSelect(obj) {
    addItem(obj, "请选择", "");
    for (var i = 0; i < StringFunctionList.length; i++) {
        addItem(obj, StringFunctionList[i][1], StringFunctionList[i][0]);
    }
}


//特殊函数
//IF语句   中添加
function Factor_IfAdd(objName, CreateWz, objid, MemberList, Tobj, Value) {
    var ObjValue = Math.floor(Math.random() * 100000 + 1);
    var strObjHtml = "<div id=\"" + objid + "Value_" + ObjValue + "\" style=\"padding-bottom:5px;\">";
    strObjHtml+="<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"StyleView\" width=\"100%\"><tr><th colspan=\"2\">";
    strObjHtml+="<span style=\"float:right;\"><input type=\"button\" id=\"" + objid + "T2_Button_" + ObjValue + "\" value=\"添加\" icon=\"icon-add\" />" + ($("#" + objid + "ValueView>div").length > 0 ? "<input type=\"button\" value=\"删除\" onclick=\"$('#" + objid + "Value_" + ObjValue + "').remove();\" icon=\"icon-delete\" />" : "") + "</span>";
    strObjHtml+="如果：<input type=\"Text\" name=\"" + objid + "T2\" jTipTitle=\"规则\" class=\"jTip\" alt=\"Help/Lists.aspx?action=temhtml-ifspace\" id=\"" + objid + "T2_" + ObjValue + "\" size=\"10\" style=\"width:190px;\"/>";
    strObjHtml+="&nbsp;<select name=\"" + objid + "T4\" id=\"" + objid + "T4_" + ObjValue + "\"><option value=\"=\">等于</option><option value=\"<>\">不等于</option><option value=\"like\">包含</option><option value=\"flike\">反包含</option><optgroup label=\"数字数值运算\"><option value=\">\">大于</option><option value=\"<\">小于</option><option value=\">=\">大于等于</option><option value=\"<=\">小于等于</option><option value=\"%\">余数为零</option></optgroup></select>";
    strObjHtml += "&nbsp;<input type=\"Text\" name=\"" + objid + "T5\" jTipTitle=\"规则\" class=\"jTip\" alt=\"Help/Lists.aspx?action=temhtml-ifspace\" id=\"" + objid + "T5_" + ObjValue + "\" size=\"10\" style=\"width:190px;\"/></th><td rowspan=\"2\">";
    strObjHtml+="<div id=\"" + objid + "T3View" + ObjValue + "\" style=\"width:170px;height:110px;float:right;text-align:left;padding-left:3px;margin-left:3px;overflow-y:auto;overflow-x:hidden\"></div></tr>"
    strObjHtml += "<tr><th align=right width=\"40\">则：</th><td><div class=\"TextAreaSyCms\" style=\"width:630px;height:100px;\"><div id=\"" + objid + "T3_" + ObjValue + "_Line\" class=\"TextAreaSyCmsLine TextAreaSyCmsFont\"></div><" + InterVeersionDiv + " id=\"" + objid + "T3_" + ObjValue + "_Bg\" style=\"width:595px;\" class=\"TextAreaSyCmsPackage TextAreaSyCmsFont\"></" + InterVeersionDiv + "><textarea rows=\"4\" wrap=\"off\" class=\"TextArea TextAreaSyCmsFont\" name=\"" + objid + "T3\" id=\"" + objid + "T3_" + ObjValue + "\" style=\"width:595px;height:100px;\" cols=\"44\"></textarea></div></div></td></tr></table>";
    if (CreateWz) {
        $("#" + objName).after(strObjHtml).find(".jTip").JT_init();
    } else {
        $("#" + objName).append(strObjHtml).find(".jTip").JT_init();
    }
    $("#" + objid + "Value_" + ObjValue).btnForMat();
    if (Value) {
        $("#" + objid + "T2_" + ObjValue).val(Value[0]);
        $("#" + objid + "T4_" + ObjValue).val(Value[1]);
        $("#" + objid + "T5_" + ObjValue).val(Value[2]);
        $("#" + objid + "T3_" + ObjValue).val(Value[3]);
    }
    $("#" + objid + "T2_Button_" + ObjValue).unbind().bind("click", function () {
        Factor_IfAdd(objid + 'Value_' + ObjValue, 1, objid, MemberList, Tobj);
    });
    var IsList = $(Tobj).attr("IsList");
    var LabelListClass = $(Tobj).attr("LabelListClass");
    $("#" + objid + "T3_" + ObjValue).attr("IsList", IsList).attr("LabelListClass", LabelListClass);
    TextClick($id(objid + "T3_" + ObjValue), true, { b: 1, c: 1, d: 1, e: 1, f: 1, g: 1, h: 1, hh: 1, i: 1, j: 1, l: 1, o: 1, q: 1, x: 1, y: 1, z: 1 }, MemberList, Tobj, "#" + objid + "T3View" + ObjValue, 1);
    $("#" + objid + "T2_" + ObjValue).attr("IsList", IsList).attr("LabelListClass", LabelListClass);
    TextClick($id(objid + "T2_" + ObjValue), true, { b: 1, c: 1, d: 1, e: 1, g: 1, h: 1, i: 1, j: 1, l: 1, o: 1, q: 1, x: 1, y: 1, z: 1 }, MemberList, Tobj);
    $("#" + objid + "T5_" + ObjValue).attr("IsList", IsList).attr("LabelListClass", LabelListClass);
    TextClick($id(objid + "T5_" + ObjValue), true, { b: 1, c: 1, d: 1, e: 1, g: 1, h: 1, i: 1, j: 1, l: 1, o: 1, q: 1, x: 1, y: 1, z: 1 }, MemberList, Tobj);
}

//IF语名   中删除
function Factor_IfDel(objName, objid) {
    var DivObj = $("#" + objName).children("div");
    if (DivObj.length > 2) {
        DivObj.eq(DivObj.length - 1).remove();
    }
    DivObj = null;
}



//添加字段下拉
function WordSelectOption(obj1, obj2, Wi, Wz) {
    var We = MdbList.length;
    Wi = Wi || "";
    var Wii = "";
    var Wjj = "";
    if (Wi.length > 0) {
        var W = Wi.split(".");
        Wii = W[0];
        Wjj = W[1];
        W = null;
    }
    addItem(obj1, "请选择", "");
    var Si = 0;
    for (var i = 0; i < We; i++) {
        addItem(obj1, "        " + MdbList[i][0], i);
        if (MdbList[i][1] == Wii) {
            obj1.selectedIndex = i + 1;
            Si = i;
            break;
        }
    }
    WordSelectChange(Si, obj2, Wjj, Wz);
}
//第二个选择
function WordSelectChange(Si, obj2, Wjj, Wz) {
    DelValue(obj2);
    var Sii = 0;
    addItem(obj2, "请选择", "");
    if ((Si+"").length>0) {
        for (var j = 0; j < WordList[Si].length; j++) {
            if (WordList[Si][j][Wz] == 1) {
                Sii++;
                addItem(obj2, "        " + WordList[Si][j][0], MdbList[Si][1] + "." + WordList[Si][j][1]);
                if (Wjj == WordList[Si][j][1]) {
                    obj2.selectedIndex = Sii;
                }
            }
        }
    }
    Sii = null;
}

//绑定字段下拉
function WordSelectFunApp(tobj,obj1,obj2,Str,Wz,Fun) {
    WordSelectOption(obj1, obj2, Str, Wz);
    Wz = Wz || 3;
    Fun = Fun == undefined ? 1 : Fun;
    obj1.onchange = function() {
        var str = this.options[this.selectedIndex].value;
        WordSelectChange(str, obj2, "", Wz);
        str = null;
    }
    if (Fun==1) {
        obj2.onchange = function() {
            var str = this.options[this.selectedIndex].value;
            if (str.length > 0) {
                InsertAtCaret(tobj, "<sycms type=\"Word\" name=\"" + str + "\" />");
            }
            str = null;
        }
    }
}
//添加变量
function AddMember(objname,value1,value2) {
    $("#" + objname).append("<div style=\"text-align:left;\"><div style=\"float:left;padding:3px;\">变量名：<input type=\"Text\" maxlength=\"10\" value=\"" + (value1 || "") + "\" size=\"2\" style=\"width:80px;\">；变量值：<input type=\"Text\" size=\"2\" maxlength=\"100\" value=\"" + (value2 || "") + "\" style=\"width:300px;\"></div><div style=\"float:left;\"><input type=\"button\" name=\"$$Submit0_2\" icon=\"icon-delete\" onclick=\"$(this.parentNode.parentNode).remove();\" value=\"删除\"></div></div>").btnForMat();
}

//使用变量
function AddMemberText(Obj, Value) {
    if (Value.length > 0) {
        Obj.value = "<sycms type=\"Var\" name=\"" + Value + "\" />";
    } else {
        Obj.value = "";
    }
}

//把汉字变量替换回去
function ReplaceMemberText(Value) {
    if (Value.Left(4) == "[变量]") {
        Value = "<sycms type=\"Var\" name=\"" + Value.replace("[变量]", "") + "\" />";
    }
    return Value;
}

//条件里面添加字段
function AddWordText(obj,value) {
    if (value.length > 0) {
        if (value.indexOf(".") != -1) {
            obj.value = "<sycms type=\"Word\" name=\"" + value + "\" />";
        } else {
            obj.value = "<sycms type=\"Var\" name=\"" + value + "\" />";
        }
    } else {
        obj.value = "";
    }
}

//截取字段串方式函数
function InterceptionHtmlFun(ObjName) {
    var TypeHtml;          //显示代码
    var objid = GetObjID();
    TypeHtml = InterceptionHtml;
    var H = parseInt(TypeHtml[2]);
    if (H + 90 > Wh) {
        H = Wh - 90;
    }
    var diag = new Dialog();
    diag.Width = TypeHtml[1];
    diag.Height = H;
    diag.Title = TypeHtml[0];
    diag.InnerHtml = ReplaceRegExpValue(TypeHtml[4].replace(/\$\$/g, objid), H);
    diag.OKEvent = function () {
        var str = "";
        if ($id(objid + "T100_1").checked) {
            str += "En:1;";
        } else {
            var str1 = "";
            var obj = $("input[name=" + objid + "T100_3]");
            obj.each(function () {
                if (this.checked) {
                    str1 += this.value + ",";
                }
            });
            if (str1.length > 0) {
                str += "Html:" + str1.substr(0, str1.length - 1) + ";";
            }
        }
        $id(ObjName).value = encodeURIComponent(str);
        if (str.length > 0) {
            $id("icon_" + ObjName + "Button").value = "设置规则【有】";
        } else {
            $id("icon_" + ObjName + "Button").value = "设置规则";
        }
        diag.close();
        RemoveMenu();
    };
    diag.CancelEvent = function () {
        diag.close();
        RemoveMenu();
    };                          //点击确定后调用的方法
    diag.show();
    var ObjValue = unescape($id(ObjName).value);
    if (ObjValue.length > 0) {
        var En = RegExpValue(ObjValue, "En");
        if (En == "1") {
            $id(objid + "T100_1").checked = true;
            FirefoxDisabled(objid + 'T1000_1'); FirefoxDisabled(objid + 'T1000_2'); FirefoxDisabled(objid + 'T1000_3'); FirefoxDisabled(objid + 'T1000_4');
        } else {
            var Html = RegExpValue(ObjValue, "Html");
            if (Html.length > 0) {
                var obj = $("input[name=" + objid + "T100_3]");
                obj.each(function () {
                    if (("," + Html + ",").indexOf("," + this.value + ",") != -1) {
                        this.checked = true;
                    }
                });
            }
        }
    }
}

//特殊取值方式函数
function SpecialValueHtmlFun(ObjName) {
    var TypeHtml;          //显示代码
    var objid = GetObjID();
    TypeHtml = SpecialValueHtml;
    var H = parseInt(TypeHtml[2]);
    if (H + 90 > Wh) {
        H = Wh - 90;
    }
    var diag = new Dialog();
    diag.Width = TypeHtml[1];
    diag.Height = H;
    diag.Title = TypeHtml[0];
    diag.InnerHtml = ReplaceRegExpValue(TypeHtml[4].replace(/\$\$/g, objid), H);
    diag.OKEvent = function () {
        var str = "";

        if ($("#" + objid + "tab1").is(":visible")) {     //正则可见
            var s1 = $("#" + objid + "T1").val();
            var s2 = $("#" + objid + "T2").val();
            if (s1.length > 0 && s2.length > 0) {
                str += "Type:regexp;Text:" + encodeURIComponent(s1) + ";View:" + encodeURIComponent(s2) + ";";
                if ($id(objid + "T3").checked) {
                    str += "One:true;";
                }
                s2 = $("#" + objid + "T4").val();
                if (s2.length > 0) {
                    str += "Space:" + encodeURIComponent(s2) + ";";
                }
            }
        } else {
            var s1 = $("#" + objid + "T01").val();
            var s2 = $("#" + objid + "T02").val();
            if (s1.length > 0 && s2.length > 0) {
                str += "Type:xml;Text:" + encodeURIComponent(s1) + ";View:" + encodeURIComponent(s2) + ";";
                if ($id(objid + "T03").checked) {
                    str += "One:true;";
                }
                s2 = $("#" + objid + "T04").val();
                if (s2.length > 0) {
                    str += "Space:" + encodeURIComponent(s2) + ";";
                }
                s2 = $("#" + objid + "T05").val();
                if (s2.length > 0) {
                    str += "Property:" + encodeURIComponent(s2) + ";";
                }
            }
        }
        $id(ObjName).value = str;
        if (str.length > 0) {
            $id("icon_" + ObjName + "Button").value = "特殊取值【有】";
        } else {
            $id("icon_" + ObjName + "Button").value = "特殊取值";
        }
        diag.close();
        RemoveMenu();
    };
    diag.CancelEvent = function() {
        diag.close();
        RemoveMenu();
    };                          //点击确定后调用的方法
    diag.show();

    var strOption = "";
    for (var i = 0; i < RegexpList.length; i++) {
        strOption += "<option value=\"" + RegexpList[i][0] + "\">" + RegexpList[i][1] + "</option>";
    }
    $("#" + objid + "T1Select").append(strOption).bind("change", function () {
        InsertAtCaret($id(objid + "T1"), this.value);
    });
    LabelTabFun(objid);
    FirefoxDisabled(objid + 'T3View');
    FirefoxDisabled(objid + 'T03View');
    $($id(objid + "T3")).bind("click", function () {
        if (this.checked) {
            FirefoxDisabled(objid + 'T3View');
        } else {
            FirefoxDisabled(objid + 'T3View',1);
        }
    });
    $($id(objid + "T03")).bind("click", function () {
        if (this.checked) {
            FirefoxDisabled(objid + 'T03View');
        } else {
            FirefoxDisabled(objid + 'T03View', 1);
        }
    });
    var ObjValue = $id(ObjName).value;
    if (ObjValue.length > 0) {
        var Type = RegExpValue(ObjValue, "Type");
        if (Type == "regexp") {
            $("#" + objid + "tabs a").eq(0).trigger("click");
            $("#" + objid + "T1").val(decodeURIComponent(RegExpValue(ObjValue, "Text")));
            $("#" + objid + "T2").val(decodeURIComponent(RegExpValue(ObjValue, "View")));
            if (RegExpValue(ObjValue, "One") == "true") {
                $id(objid + "T3").checked = true;
            } else {
                $id(objid + "T3").checked = false;
                FirefoxDisabled(objid + "T3View", 1);
            }
            $("#" + objid + "T4").val(decodeURIComponent(RegExpValue(ObjValue, "Space")));
        } else {
            $("#" + objid + "tabs a").eq(1).trigger("click");
            $("#" + objid + "T01").val(decodeURIComponent(RegExpValue(ObjValue, "Text")));
            $("#" + objid + "T02").val(decodeURIComponent(RegExpValue(ObjValue, "View")));
            if (RegExpValue(ObjValue, "One") == "true") {
                $id(objid + "T03").checked = true;
            } else {
                $id(objid + "T03").checked = false;
                FirefoxDisabled(objid + "T03View", 1);
            }
            $("#" + objid + "T04").val(decodeURIComponent(RegExpValue(ObjValue, "Space")));
            $("#" + objid + "T05").val(decodeURIComponent(RegExpValue(ObjValue, "Property")));
        }
    }
}
//

//循环内部显示ReturnId  返回ID，扩展ID，执行完成函数（0修改1另存,MdbID,样式ID,名称），变量列表，回调显示，字段选择,MdbId
function ItemViewFun(ReturnId, Spid, SaveFunction, MemberList, SpView, WordSelectObj, MdbId, IsNoOtherSave, ParentObjID) {
    var objid = GetObjID();
    var listID = $("#YQ_listID").val();
    if (!MdbId) {
        MdbId = $("#YQ_MdbId").val();
    }
    var ReadID = "";
    if (typeof (ReturnId) != "string") {
        ReadID = ReturnId.id;
    } else {
        ReadID = ReturnId;
    }
    var TypeHtml;          //显示代码
    TypeHtml = eval("LabelItemHtml");
    var H = parseInt(TypeHtml[2]);
    if (H + 90 > Wh) {
        H = Wh - 90;
    }
    var diag = new Dialog();
    diag.Width = TypeHtml[1];
    diag.Height = H;
    diag.Title = TypeHtml[0];
    diag.InnerHtml = ReplaceRegExpValue(TypeHtml[4].replace(/\$\$/g, objid),H);
    diag.OKEvent = function () {
        var title = $("#" + objid + "Title").val();
        if (title.length == 0) {
            Dialog.error("错误，名称必须填写。", function () { $("#" + objid + "Title").focus() });
        } else {
            var Mdbid = $("#" + objid + "T11_0").val();
            var IsTem = $id(objid + "T11_1").checked ? "1" : "0";
            var t2content = $("#" + objid + "T11_2").val();
            var t3content = $("#" + objid + "T11_3").val();
            var t4content = $("#" + objid + "T11_4").val();
            var t5content = $("#" + objid + "T11_5").val();
            var t6content = $("#" + objid + "T11_6").val();
            var t7content = $("#" + objid + "T11_7").val();
            var c1content = $("#" + objid + "T14").val();
            if (t2content.length == 0) {
                Dialog.error("错误，正常循环显示数据必须填写。", function () { $("#" + objid + "T11_2").focus() });
            } else {
                if (!ShowCallBack_LabelSave($id(objid + "T11_2"))) {
                    if (!ShowCallBack_LabelSave($id(objid + "T11_3"))) {
                        if (!ShowCallBack_LabelSave($id(objid + "T11_4"))) {
                            if (!ShowCallBack_LabelSave($id(objid + "T11_5"))) {
                                if (!ShowCallBack_LabelSave($id(objid + "T11_6"))) {
                                    if (!ShowCallBack_LabelSave($id(objid + "T11_7"))) {
                                        AjaxFun("Tem/StyleModule/add.aspx", "action=" + typeof (ReturnId) + "&listID=" + listID + (SpView ? "&SpView=" + SpView : "") + "&IsTem=" + IsTem + "&Mdbid=" + Mdbid + "&id=" + ReturnId + "&spid=" + Spid + "&title=" + encodeURIComponent(title) + "&itemhtml=" + encodeURIComponent(t2content) + "&alter=" + encodeURIComponent(t3content) + "&Footer=" + encodeURIComponent(t7content) + "&Header=" + encodeURIComponent(t6content) + "&Separ=" + encodeURIComponent(t5content) + "&NoItem=" + encodeURIComponent(t4content) + "&css1=" + encodeURIComponent(c1content), "正在保存样式模板。", function (html, diag) {
                                            if (html.length > 0) {
                                                var ReturnValue = html;
                                                try {
                                                    ReturnValue = eval(html);
                                                } catch (e) { }
                                                if (typeof (ReturnValue) == "object") {
                                                    if (ReturnValue.length >= 5) {
                                                        if (typeof (SaveFunction) == "function")
                                                        {
                                                            SaveFunction(0, ReturnValue[2], ReturnValue[3], ReturnValue[4], ParentObjID);
                                                        }
                                                    }
                                                }
                                                ReturnValue = null;
                                            }
                                            diag.close();
                                            diag = null;
                                        }, null, diag);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        title = null;
    };
    diag.CancelEvent = function() {
        diag.close();
        RemoveMenu();
    };                          //点击确定后调用的方法
    diag.show();
    H = null;
    TypeHtml = null;
    var opstr = "";
    for (var i = 0; i < MdbList.length; i++) {
        if (MdbList[i][4] == "1") {
            opstr += "<option value=\"" + MdbList[i][3] + "\"" + (MdbId == MdbList[i][3] ? "selected" : "") + ">" + MdbList[i][0] + "</option>";
        }
    }
    $("#" + objid + "T11_0").html(opstr);
    opstr = null;
    if (listID) {
        $("#" + objid + "T14").attr("ListID", listID);
        TextClickCss($("#" + objid + "T14").get(0));
    }
    if (!IsNoOtherSave && (((listID && Spid) || !Spid) && ReadID != "0" && ReadID.isDigit())) {
        diag.addButton("next", "另存为", function () {
            var title = $("#" + objid + "Title").val();
            if (title.length == 0) {
                Dialog.error("错误，名称必须填写。", function () { $("#" + objid + "Title").focus() });
            } else {
                var Mdbid = $("#" + objid + "T11_0").val();
                var IsTem = $id(objid + "T11_1").checked ? "1" : "0";
                var t2content = $("#" + objid + "T11_2").val();
                var t3content = $("#" + objid + "T11_3").val();
                var t4content = $("#" + objid + "T11_4").val();
                var t5content = $("#" + objid + "T11_5").val();
                var t6content = $("#" + objid + "T11_6").val();
                var t7content = $("#" + objid + "T11_7").val();
                var c1content = $("#" + objid + "T14").val();
                if (t2content.length == 0) {
                    Dialog.error("错误，正常循环显示数据必须填写。", function () { $("#" + objid + "T11_2").focus() });
                } else {
                    if (!ShowCallBack_LabelSave($id(objid + "T11_2"))) {
                        if (!ShowCallBack_LabelSave($id(objid + "T11_3"))) {
                            if (!ShowCallBack_LabelSave($id(objid + "T11_4"))) {
                                if (!ShowCallBack_LabelSave($id(objid + "T11_5"))) {
                                    if (!ShowCallBack_LabelSave($id(objid + "T11_6"))) {
                                        if (!ShowCallBack_LabelSave($id(objid + "T11_7"))) {
                                            AjaxFun("Tem/StyleModule/add.aspx", "action=" + typeof (ReturnId) + "&yid=" + ReturnId + "&ySpid=" + Spid + (SpView ? "&SpView=" + SpView : "") + "&IsTem=" + IsTem + "&Mdbid=" + Mdbid + "&listID=" + listID + "&title=" + encodeURIComponent(title) + "&itemhtml=" + encodeURIComponent(t2content) + "&alter=" + encodeURIComponent(t3content) + "&Footer=" + encodeURIComponent(t7content) + "&Header=" + encodeURIComponent(t6content) + "&Separ=" + encodeURIComponent(t5content) + "&NoItem=" + encodeURIComponent(t4content) + "&css1=" + encodeURIComponent(c1content), "正在保存样式模板。", function (html, diag) {
                                                if (html.length > 0) {
                                                    var ReturnValue = html;
                                                    try {
                                                        ReturnValue = eval(html);
                                                    } catch (e) { }
                                                    if (typeof (ReturnValue) == "object") {
                                                        if (ReturnValue.length >= 4) {
                                                            if (typeof (SaveFunction) == "function") {
                                                                SaveFunction(1, ReturnValue[2], ReturnValue[3], ReturnValue[4], ParentObjID);
                                                            }
                                                        }
                                                    }
                                                    ReturnValue = null;
                                                }
                                                diag.close();
                                                diag = null;
                                            }, null, diag);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            title = null;
        });
    }
    LabelTabFun(objid + "Table");
    LabelTabFun(objid);

    if (WordSelectObj) {
        //选择的字符  把标签里选择的下拉框的值传递给样式添加
        var SelectValue = $("#" + WordSelectObj).val();
        if (SelectValue.length > 0) {
            SelectValue = MdbList[parseInt(SelectValue)][1];
            $("#" + objid + "T11_2").attr("LabelListClass", SelectValue);
            $("#" + objid + "T11_3").attr("LabelListClass", SelectValue);
            $("#" + objid + "T11_4").attr("LabelListClass", SelectValue);
            $("#" + objid + "T11_5").attr("LabelListClass", SelectValue);
            $("#" + objid + "T11_6").attr("LabelListClass", SelectValue);
            $("#" + objid + "T11_7").attr("LabelListClass", SelectValue);
        }
    }

    //绑定字段
    WordSelectFunApp($id(objid + "T11_2"), $id(objid + "T12_1"), $id(objid + "T13_1"));
    WordSelectFunApp($id(objid + "T11_3"), $id(objid + "T12_2"), $id(objid + "T13_2"));
    WordSelectFunApp($id(objid + "T11_4"), $id(objid + "T12_3"), $id(objid + "T13_3"));
    WordSelectFunApp($id(objid + "T11_5"), $id(objid + "T12_4"), $id(objid + "T13_4"));
    WordSelectFunApp($id(objid + "T11_6"), $id(objid + "T12_5"), $id(objid + "T13_5"));
    WordSelectFunApp($id(objid + "T11_7"), $id(objid + "T12_6"), $id(objid + "T13_6"));
    var ddfun = function () {
        setTimeout(function () {
            TextClick($id(objid + "T11_2"), true, { a: 1, b: 1, c: 1, d: 1, e: 1, f: 1, g: 1, h: 1, i: 1, j: 1, k: 1, l: 1, o: 1, q: 1, x: 1, y: 1, z: 1 }, MemberList, null, "#" + objid + "T1Viewtab1_1", 1);
            TextClick($id(objid + "T11_3"), true, { a: 1, b: 1, c: 1, d: 1, e: 1, f: 1, g: 1, h: 1, i: 1, j: 1, k: 1, l: 1, o: 1, q: 1, x: 1, y: 1, z: 1 }, MemberList, null, "#" + objid + "T1Viewtab2_1", 1);
            TextClick($id(objid + "T11_4"), true, { a: 1, b: 1, c: 1, d: 1, e: 1, f: 1, g: 1, h: 1, i: 1, j: 1, k: 1, l: 1, o: 1, q: 1, x: 1, y: 1, z: 1 }, MemberList, null, "#" + objid + "T1Viewtab3_1", 1);
            TextClick($id(objid + "T11_5"), true, { a: 1, b: 1, c: 1, d: 1, e: 1, f: 1, g: 1, h: 1, i: 1, j: 1, k: 1, l: 1, o: 1, q: 1, x: 1, y: 1, z: 1 }, MemberList, null, "#" + objid + "T1Viewtab4_1", 1);
            TextClick($id(objid + "T11_6"), true, { a: 1, b: 1, c: 1, d: 1, e: 1, f: 1, g: 1, h: 1, i: 1, j: 1, k: 1, l: 1, o: 1, q: 1, x: 1, y: 1, z: 1 }, MemberList, null, "#" + objid + "T1Viewtab5_1", 1);
            TextClick($id(objid + "T11_7"), true, { a: 1, b: 1, c: 1, d: 1, e: 1, f: 1, g: 1, h: 1, i: 1, j: 1, k: 1, l: 1, o: 1, q: 1, x: 1, y: 1, z: 1 }, MemberList, null, "#" + objid + "T1Viewtab6_1", 1);
        }, 7);
    }
    if (ReadID && ReadID.length > 0 && ReadID.isDigit() && ReadID != "0") {
        if (listID) {
            AjaxFun("Tem/StyleModule/Modi.aspx", "action=" + objid + "&id=" + ReadID + "&Spid=" + Spid, "正在调入样式模块。", ddfun, null, diag, function () {
                diag.close();
                diag = null;
            });
        } else {
            AjaxFun("Tem/StyleModule/Modi.aspx", "action=" + objid + "&id=" + ReadID + (Spid ? "&spid=" + Spid : ""), "正在调入样式模块。", ddfun, null, diag, function () {
                diag.close();
                diag = null;
            });
        }
    } else {
        ddfun();
        $("#" + objid + "T0LabelLog").hide();
    }
    $("#" + objid + "LabelItemLog").bind("click", function () {
        if (ReadID && ReadID.length > 0 && ReadID.isDigit() && ReadID != "0") {
            if (listID) {
                OpenLabelItemLog(ReadID + "&Spid=" + Spid);
            } else {
                OpenLabelItemLog(ReadID + (Spid ? "&spid=" + Spid : ""));
            }
        }
    });
    TextClickCss($id(objid + "T14"));
    IECollectGarbage();
}

//添加扩展样式
function AddListSpread(Type, PostReturnFun, ParentObjID) {
    var listID = $("#YQ_listID").val();
    if (listID) {
        CreateWindow('Tem/Spread/Add.aspx?id=' + listID, '添加扩展样式模块', 'Tem/Spread/Add.aspx?action=save&Type=' + Type, 800, 500, 'TemAdd', null, null, null, null, null, function (html, DigWin)
        {
            if (PostReturnFun && typeof (PostReturnFun) == "function")
            {
                PostReturnFun(Type, html, ParentObjID);
            }
            DigWin.close();
        });
    }
    listID = null;
}
//选择样式 之后可以修改扩展样式
function ModiyItemSelectSpFun(objid)
{
    var parentWin = $(window.parent.document);
    var T11Obj = parentWin.find("#" + objid + "T11");
    var Spid = T11Obj.val();
    if (Spid.indexOf("Sp:") != -1) {
        Spid = Spid.replace("Sp:", "");
        parent.GridModiy(Spid, 'Tem/Spread/Modi.aspx', '修改扩展样式模块', 'Tem/Spread/Modi.aspx?action=save', 800, 500, 'SpreadViewModi', {
            Name: '另存为', Url: 'Tem/Spread/Add.aspx?action=save&waction=win', PostReturnFunction: function (html)
            {
                if (html.length > 0) {
                    var iwz = html.indexOf("]");
                    if (iwz != -1) {
                        html = html.substr(iwz + 1);
                        if (html.isDigit()) {
                            parent.AjaxFun("Tem/Spread/Lists_Name.aspx", "spid=" + html, null, function (html) {
                                if (html.length > 0) {
                                    $("#" + objid + "T11View").html("扩展样式模块：" + html);
                                    $("#" + objid + "SelectStyleModi").btn().enable();
                                    $("#" + objid + "SelectSpStyleModi").btn().enable();
                                }
                            });
                        }
                    }
                }
            }
        }, null, null, null, null, function (html, diagWin)
        {
            parent.AjaxFun("Tem/Spread/Lists_Name.aspx", "spid=" + Spid, null, function (html) {
                if (html.length > 0) {
                    $("#" + objid + "T11View").html("扩展样式模块：" + html);
                    $("#" + objid + "SelectStyleModi").btn().enable();
                    $("#" + objid + "SelectSpStyleModi").btn().enable();
                }
            });
            diagWin.close();
        });
    }
}
//选择样式 之后可以修改样式
function ModiyItemSelectFun(objid, obj) {
    var parentWin = $(window.parent.document);
    var T11Obj = parentWin.find("#" + objid + "T11");
    var Spid = T11Obj.val();
    if (Spid.indexOf("Style:") != -1) {
        Spid = Spid.replace("Style:", "");
        parent.ItemViewFun(Spid, null, function (Type, MdbID, StyleID, Title, ParentObjID) {
            parent.AjaxFun("Tem/StyleModule/Lists_Name.aspx", "id=" + StyleID, null, function (html) {
                if (html.length > 0) {
                    T11Obj.val("Style:" + StyleID);
                    $("#" + objid + "T11View").html("样式模块：" + html);
                    $("#" + objid + "SelectStyleModi").btn().enable();
                    $("#" + objid + "SelectSpStyleModi").btn().disable();
                }
            });
        }, obj.MemberList, 1, objid + "T1");
    } else {
        Spid = Spid.replace("Sp:", "");
        parent.ItemViewFun(Spid, Spid, function ()
        {
            parent.AjaxFun("Tem/Spread/Lists_Name.aspx", "spid=" + Spid, null, function (html) {
                if (html.length > 0) {
                    $("#" + objid + "T11View").html("扩展样式模块：" + html);
                    $("#" + objid + "SelectStyleModi").btn().enable();
                    $("#" + objid + "SelectSpStyleModi").btn().enable();
                }
            });
        }, obj.MemberList, 1, objid + "T1", null, 1);
    }
    return "";
}


function LoadWarting(Title, Content) {
    var diag1 = new Dialog();
    //diag1.AutoClose = 5;
    diag1.ShowCloseButton = false;
    diag1.Title = Title;
    diag1.Width = 250;
    diag1.Height = 60;
    diag1.Drag = false;
    diag1.InnerHtml = '<table height="100%" border="0" align="center" cellpadding="10" cellspacing="0">\
		<tr><td align="right"><img src="' + IMAGESPATH + 'icon_warning.gif" width="34" height="34" align="absmiddle"></td>\
			<td align="left" style="font-size:9pt">' + Content + '</td></tr>\
	</table>';
    diag1.show();
    return diag1;
}


///FirefoxDisabled
function FirefoxDisabled(objName, Type) {
    var obj;
    if (typeof (objName) != "object") {
        obj = $("#" + objName);
    } else {
        obj = objName;
    }
    if (Type) {
        obj.removeAttr("disabled").removeClass("disabled");
        obj.find("*").removeAttr("disabled").removeClass("disabled");
    } else {
        obj.attr("disabled", "disabled").addClass("disabled");
        obj.find("*").attr("disabled", "disabled").addClass("disabled");
    }
}



function CssFunction(str, obj) {
    var YqListid = $(obj).attr("ListID");
    if (!YqListid || isNaN(parseInt(YqListid))) {
        YqListid = $("#YQ_listID").val();
    }
    if (YqListid == null || YqListid == undefined) {
        YqListid = "0";
    }
    CreateWindow("js/CssHtml.html", "可视化调整样式", function (dowin) {
        var csscon = createcss();
        csscon = csscon.split("[$tempath$]").join("[$TemPath$]");
        csscon = "{" + csscon + "}";
        InsertAtCaret(obj, csscon);
        dowin.close();
    }, 700, 350, "", null, null, null, null, function () { readcss(str); }, null, function (html) {
        html = html.replace("$YqListid$", YqListid);
        return html.replace("$YqListid$", YqListid);
    });
}
///右键可用字段
function LabelFieldFunHtmlFun(obj) {
    var LabelClassName = $(obj).attr("LabelListClass");
    var objid = GetObjID();
    var diag = new Dialog();
    diag.Width = LabelFieldFunHtml[1];
    diag.Height = LabelFieldFunHtml[2];
    diag.Title = LabelFieldFunHtml[0];
    diag.InnerHtml = ReplaceRegExpValue(LabelFieldFunHtml[4].replace(/\$\$/g, objid), LabelFieldFunHtml[2]);
    diag.OKEvent = function () {
        var T01Value = $("#" + objid + "TT001").val();
        if (T01Value) {
            InsertAtCaret(obj, "<sycms type=\"Word\" name=\"" + T01Value + "\" />");
            diag.close();
            RemoveMenu();
        }
    };
    diag.CancelEvent = function () {
        diag.close();
        RemoveMenu();
    };                          //点击确定后调用的方法
    diag.show();
    var T01 = $("#" + objid + "TT001");
    var o3 = -1;
    for (var i = 0; i < MdbList.length; i++) {
        if (MdbList[i][1] == LabelClassName) {
            o3 = i;
            break;
        }
    }
    var strOption = new Array();
    strOption.push("<option value=\"\">请选择</option>");
    if (o3 != -1) {
        strOption.push("<optgroup label=\"" + MdbList[i][0] + "\">");
        var w = WordList[o3];
        for (var i = 0, wi; wi = w[i++]; ) {
            //字段
            if (wi[3] == 1) {
                strOption.push("<option value=\"" + LabelClassName + "." + wi[1] + "\">" + wi[0] + "</option>");
            }
        }
        strOption.push("</optgroup>");
        if (MdbConn[o3].length > 0) {
            for (var i = 0; i < MdbConn[o3].length; i++) {
                for (var j = 0; j < MdbList.length; j++) {
                    if (MdbList[j][2] == MdbConn[o3][i][0] && MdbList[o3][2] != MdbConn[o3][i][0] && MdbList[j][5] == MdbConn[o3][i][3]) {
                        strOption.push("<optgroup label=\"" + MdbList[j][0] + "[关联]\">");
                        for (var j1 = 0; j1 < WordList[j].length; j1++) {
                            if (WordList[j][j1][3] == 1) {
                                strOption.push("<option value=\"" + MdbList[j][1] + "." + WordList[j][j1][1] + "\">" + WordList[j][j1][0] + "</option>");
                            }
                        }
                        strOption.push("<optgroup>");
                        break;
                    }
                }
            }
        }
    }
    T01.append(strOption.join(""));
}

function LoadNum_PageFun(obj, type,objid) {
    if (obj.checked) {
        switch (type) {
            case 0:
                {
                    FirefoxDisabled(objid + "LoadNumView", 1);
                    FirefoxDisabled(objid + "LoadPage");
                    break;
                }
            case 1:
                {
                    FirefoxDisabled(objid + "LoadNumView");
                    if ($("#" + objid + "LoadPage").attr("close") != "true") {
                        FirefoxDisabled(objid + "LoadPage", 1);
                        FirefoxDisabled(objid + "T13_PageView");
                    }
                    break;
                }
        }
    }
}
//常用标签
function CommonlyUsedLabelFun(obj,ListObj, NavigateObj, SeoObj, IfObj, ForObj, ORObj) {
    var objid = GetObjID();
    var diag = new Dialog();
    diag.Width = CommonlyUsedLabelFunHtml[1];
    diag.Height = CommonlyUsedLabelFunHtml[2];
    diag.Title = CommonlyUsedLabelFunHtml[0];
    diag.InnerHtml = ReplaceRegExpValue(CommonlyUsedLabelFunHtml[4].replace(/\$\$/g, objid), CommonlyUsedLabelFunHtml[2]);
    diag.show();
    diag.okButton.style.display = "none";
    var objViewDiv = $("#" + objid + "StyleViewDiv");
    AjaxFun("Tem/Label/Lists_View.aspx", "ListObj=" + (ListObj ? "1" : "0") + "&NavigateObj=" + (NavigateObj ? "1" : "0") + "&SeoObj=" + (SeoObj ? "1" : "0") + "&IfObj=" + (IfObj ? "1" : "0") + "&ForObj=" + (ForObj ? "1" : "0") + "&ORObj=" + (ORObj ? "1" : "0"), "正在调入常用标签，请稍候......", function (html) {
        objViewDiv.html(html);
        objViewDiv.find("a").bind("click", function () {
            CommonlyUsedLabelFunLoad(obj, this);
            diag.close();
            return false;
        });
    });
}
function CommonlyUsedLabelFunLoad(obj, objthis) {
    var obja = $(objthis);
    var id = obja.attr("href").split("#")[1];
    AjaxFun("Tem/Label/Lists_Load.aspx", "id=" + id, "正在读取信息，请稍候......", function (html) {
        if (html.length > 0) {
            if (objthis.type == "0") {
                InsertAtCaret(obj, html);
            } else {
                var xml = new XML();
                xml.SetXML("<?xml version='1.0' encoding='utf-8'?><xml>" + html + "</xml>");
                var type = decodeURIComponent(xml.getAttrib("xml/sycms", "type"));
                xml.Dispose();
                xml = null;
                LabelFun(html, obj, type);
            }
        }
    });
}
//新的选择样式模块
function SelectStyleModule(obj, objid)
{
    var isList = obj.isList;
    var StyleModuleWin = null;
    AjaxFun("Tem/StyleModule/Lists_Label.aspx", "objid="+encodeURIComponent(objid), "正在调入，请稍候......", function (html) {
        StyleModuleWin = new Dialog();
        StyleModuleWin.Title = "选择样式输出";
        StyleModuleWin.InnerHtml = "<div style=\"text-align:left;\">" + html + "</div>";
        StyleModuleWin.Width = 800;
        StyleModuleWin.Drag = false;
        StyleModuleWin.Height = 400;
        StyleModuleWin.Message = "<ol><li>样式模块为最底层的HTML代码信息。</li><li>扩展样式模块为引用样式模块到当前模板时，附加CSS而成的样式模块。</li></ol>";
        StyleModuleWin.OKEvent = function () {
            var ObjValue = "";
            var ObjName = "";
            if ($("#" + objid + "Labeltabs1").is(":visible")) {
                var objvalue = $("#TemStyleModelId" + objid).val();
                if (objvalue)
                {
                    ObjValue = "Style:" + objvalue;
                    ObjName = "样式模块：" + $("#TemStyleModelId" + objid + " option:selected").text();;
                }
            } else {
                var objvalue = $("#" + objid + "Labeltabs2 #SpId" + objid).val();
                if (objvalue)
                {
                    ObjValue = "Sp:" + objvalue;
                    ObjName = "扩展样式模块：" + $("#" + objid + "Labeltabs2 #SpId" + objid + " option:selected").text();;
                }
            }
            if (ObjValue && ObjValue.length > 0) {
                ///一会修饰
                $("#" + objid + "T11").val(ObjValue);
                $("#" + objid + "T11View").html(ObjName);
                if (ObjValue.indexOf("Style:")!=-1)
                {
                    $("#" + objid + "SelectStyleModi").btn().enable();
                    $("#" + objid + "SelectSpStyleModi").btn().disable();
                }
                if (ObjValue.indexOf("Sp:")!=-1) {
                    $("#" + objid + "SelectStyleModi").btn().enable();
                    $("#" + objid + "SelectSpStyleModi").btn().enable();
                }
                StyleModuleWin.close();
            }
        };
        StyleModuleWin.show();
        if (!isList)
        {
            $("#" + objid + "Labeltabs a:not(:first)").remove();
        }
        $id("TemStyleModelId" + objid).MemberList = obj.MemberList;
        $id("TemStyleModelId" + objid).WordSelectObj = obj.WordSelectObj;
        $id("SelectStyleModuleAddButton" + objid).MemberList = obj.MemberList;
        $id("SelectStyleModuleAddButton" + objid).WordSelectObj = obj.WordSelectObj;
        LabelTabFun(objid + "Label");
    });
}
///添加另存样式回调函数
function AddStyleModleSave(Type, MdbID, StyleID, Title, ParentObjID) {
    $("#TemMdbListSelect" + ParentObjID).val(MdbID);
    LoadChange(MdbID, "Tem/StyleModule/Lists_Option.aspx", function (html) {
        $("#TemStyleModelId" + ParentObjID).empty().append(html).val(StyleID).trigger("change");
    });
}
///选择扩展样式时。添加返回
function SelectAddSpreadPostFun(Type, html, ParentObjID)
{
    if (!ParentObjID)
    {
        ParentObjID = "";
    }
    if (Type == "SelectAdd")
    {
        if (html.length > 0) {
            var ObjValue = null;
            try {
                ObjValue = eval(html);
            } catch (e)
            {
                ObjValue = null;
            }
            if (ObjValue != null)
            {
                if (ObjValue.length >= 6)
                {
                    var objP = $("#ListViewTem" + ParentObjID);
                    var GroundId = objP.find("#GroundId" + ParentObjID);
                    var ListId = objP.find("#ListId" + ParentObjID);
                    var SpId = objP.find("#SpId" + ParentObjID);
                    var SpIdFunction = function ()
                    {
                        if (SpId.val() != ObjValue[4])
                        {
                            SpId.val(ObjValue[4]);
                            SpId.trigger("change");
                        }
                    }
                    var ListIdFunction = function ()
                    {
                        if (ListId.val() != ObjValue[3]) {
                            ListId.val(ObjValue[3])
                            LoadChange(ObjValue[3], 'Tem/Spread/Lists_Option.aspx', function (html) {
                                $('.ListViewTem #SpId' + ParentObjID).empty().append(html);
                                SpIdFunction();
                            })
                        } else {
                            SpIdFunction();
                        }
                    }
                    if (GroundId.val() != ObjValue[2]) {
                        GroundId.val(ObjValue[2]);
                        LoadChange(ObjValue[2], 'Tem/List/Lists_Option.aspx?ListType=1', function (html) {
                            $('.ListViewTem #ListId' + ParentObjID).empty().append(html);
                            ListIdFunction();
                        })
                    } else {
                        GroundId.val(ObjValue[2]);
                        ListIdFunction();
                    }
                }
            }
        }
    }
}
//获得随机标识ID前缀或后缀
function GetObjID()
{
    return "YQ" + parseInt(Math.random() * 1000);
}
//Tab切换
function LabelTabFun(objStart)
{
    $("." + objStart + "tab_content").hide(); //Hide all content
    $("#" + objStart + "tabs a:first").addClass("dq").show(); //Activate first tab
    $("." + objStart + "tab_content:first").show(); //Show first tab content
    //On Click Event
    $("#" + objStart + "tabs a").click(function () {
        $("#" + objStart + "tabs a").removeClass("dq"); //Remove any "active" class
        $(this).addClass("dq"); //Add "active" class to selected tab
        $("." + objStart + "tab_content").hide(); //Hide all tab content
        var activeTab = $(this).attr("href"); //Find the rel attribute value to identify the active tab + content
        activeTab = activeTab.substr(activeTab.indexOf("#"));
        $(activeTab).show(); //Fade in the active content
        $(this).blur();
        activeTab = null;
        return false;
    });
}
//激活
function LabelTabActiveFun(objStart, Index) {
    var objA = $("#" + objStart + "tabs a");
    var objC = $("." + objStart + "tab_content");
    objA.removeClass("dq");
    objC.hide();
    objA.eq(Index).addClass("dq").show();
    objC.eq(Index).show();
}




//特殊取值方式函数
function FormAtHtmlFun(at, MdbID, PostUrl) {
    var TypeHtml;          //显示代码
    var objid = GetObjID();
    TypeHtml = FormATHtml;
    var H = parseInt(TypeHtml[2]);
    if (H + 90 > Wh) {
        H = Wh - 90;
    }
    var diag = new Dialog();
    diag.Width = TypeHtml[1];
    diag.Height = H;
    diag.Title = TypeHtml[0];
    diag.InnerHtml = ReplaceRegExpValue(TypeHtml[4].replace(/\$\$/g, objid), H);
    diag.OKEvent = function () {
        var isOK = true;
        var xml = new XML();
        xml.SetXML("<?xml version='1.0' encoding='utf-8'?><xml><sycms type=\"List\" name=\"条件\" /></xml>");
        if ($("#" + objid + "ATtab2").is(":hidden"))     //隐藏
        {
            //条件
            o = $id(objid + "T4");
            s1 = ShowCallBack_At(o);
            if (s1.length > 0) {
                if (s1 == "ERROR") {
                    Dialog.error("错误：请检查【条件设置】里的（）是否成双成对。");
                    isOK = false;
                } else {
                    xml.setAttrib("xml/sycms", "at", s1);
                }
            }
        } else {
            var str1 = $id(objid + "T21").value;
            if (str1.length > 0) {
                if (ShowCallBack_LabelSave($id(objid + "T21"))) {
                    isOK = false;
                }
                xml.setAttrib("xml/sycms", "getwhere", encodeURIComponent(str1));
            }
        }
        if (isOK) {
            diag.close();
            AjaxFun(PostUrl,"xml=" + encodeURIComponent(xml.GetString("xml/sycms")), '正在提交数据，请稍候...')
        }
        xml = null;
    };
    diag.CancelEvent = function () {
        diag.close();
        RemoveMenu();
    };                          //点击确定后调用的方法
    diag.show();
    LabelTabFun(objid + "AT");
    var tv2 = "";
    for (var i = 0; i < MdbList.length; i++) {
        if (MdbID == MdbList[i][3]) {
            tv2 = i;
            break;
        }
    }
    if (tv2) {
        Label_Sell_Mdb("" + tv2, objid, null, true);
    }
    TextClick($id(objid + "T21"), true, { b: true, c: true, d: true, e: true, g: true, h: true, i: true, j: true, o: true, z: true }, null, null, "#" + objid + "T21Viewtab", 1);
    TextClick($id(objid + "T4_4"), true, { b: 1, c: 1, d: 1, e: 1, g: 1, h: 1, j: 1, i: 1, o: 1, z: 1 });
    if (at.length > 0)
    {
        var xml = new XML();
        xml.SetXML("<?xml version='1.0' encoding='utf-8'?><xml>" + at + "</xml>");
        BindAtView(objid, xml, "");
        xml = null;
    }
}