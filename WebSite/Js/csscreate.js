//1为输入框对比(后面加大于1时为合并项),3为复选 0为直接取值,如果后面有东西的时候替换
//2 特殊后面跟1为位置替换(后面跟个数),后面跟2为数字替换

//样式值
var yq_style=new Array(new Array(new Array("font-family","0"),new Array("font-size","1"),new Array("font-weight","1"),new Array("font-style","0"),new Array("font-variant","0"),new Array("line-height","1"),new Array("text-transform","0"),new Array("text-decoration","3"),new Array("color","0"))
,new Array(new Array("background-color","0"),new Array("background-image","0url(?)"),new Array("background-repeat","0"),new Array("background-attachment","0"),new Array("background-position","12"))
,new Array(new Array("word-spacing","1"),new Array("letter-spacing","1"),new Array("vertical-align","1"),new Array("text-align","0"),new Array("text-indent","1"),new Array("white-space","0"),new Array("display","0"))
,new Array(new Array("width","1"),new Array("height","1"),new Array("float","0"),new Array("clear","0"),new Array("padding-top","1"),new Array("padding-right","1"),new Array("padding-bottom","1"),new Array("padding-left","1"),new Array("margin-top","1"),new Array("margin-right","1"),new Array("margin-bottom","1"),new Array("margin-left","1"))
,new Array(new Array("border-top-style","0"),new Array("border-right-style","0"),new Array("border-bottom-style","0"),new Array("border-left-style","0"),new Array("border-top-width","1"),new Array("border-right-width","1"),new Array("border-bottom-width","1"),new Array("border-left-width","1"),new Array("border-top-color","0"),new Array("border-right-color","0"),new Array("border-bottom-color","0"),new Array("border-left-color","0"))
,new Array(new Array("list-style-type","0"),new Array("list-style-image","0url(?)"),new Array("list-style-position","0"))
,new Array(new Array("position","0"),new Array("visibility","0"),new Array("z-index","1"),new Array("overflow","0"),new Array("top","1"),new Array("right","1"),new Array("bottom","1"),new Array("left","1"),new Array("clip","214rect(?1,?2,?3,?4)"))
,new Array(new Array("direction","0"),new Array("border-collapse","0"),new Array("zoom","0"),new Array("word-wrap","0"),new Array("min-height","1"),new Array("cursor","0"),new Array("filter","22"))
, new Array(new Array("scrollbar-3dlight-color", "0"), new Array("scrollbar-arrow-color", "0"), new Array("scrollbar-base-color", "0"), new Array("scrollbar-darkshadow-color", "0"), new Array("scrollbar-face-color", "0"), new Array("scrollbar-highlight-color", "0"), new Array("scrollbar-shadow-color", "0")));


//1为连加
//2为隔行连加判断
//以下为合并一些CSS样式。达到最小体积
var IntegrationStyleList=new Array(new Array("font-$1",new Array("style","variant","weight","size","family"),1),
new Array("margin-$1",new Array("top","right","bottom","left"),2),
new Array("padding-$1",new Array("top","right","bottom","left"),2),
new Array("background-$1",new Array("color","image","repeat","position"),1),
new Array("border-top-$1",new Array("width","style","color"),1),
new Array("border-right-$1",new Array("width","style","color"),1),
new Array("border-bottom-$1",new Array("width","style","color"),1),
new Array("border-left-$1",new Array("width","style","color"),1),
new Array("border-$1",new Array("top","right","bottom","left"),1),
new Array("list-style-$1",new Array("type","image","position"),1),
new Array("border-$1",new Array("top-width","right-width","bottom-width","left-width"),2),
new Array("border-$1",new Array("top-style","right-style","bottom-style","left-style"),2),
new Array("border-$1", new Array("top-color", "right-color", "bottom-color", "left-color"), 2))


//兼容问题所必须。1为直接添加
var WithdrawCss = new Array(new Array("margin", "float", "display:inline;", 1))


//可取消的列表
var CanCancel = new Array(new Array("border", "none"))


//取得样式
function readcss(str) {
    var objs = $(".yq_style");
    objs.find("#padding").attr("checked", "");
    objs.find("#margin").attr("checked", "");
    objs.find("#border-style").attr("checked", "");
    objs.find("#border-width").attr("checked", "");
    objs.find("#border-color").attr("checked", "");
    str = str.toLowerCase().replace("{", "").replace("}", "").Trim();
    if (str.Right(1) != ";") {
        str += ";";
    }
    var regx1 = new RegExp("\\s{2,}", "g");
    str = str.replace(regx1, " ");

    var selectindex = -1;
    var zstr = "";
    if (str.indexOf("margin") != -1) {
        var objtext2 = readstr(str, "margin").Trim();
        if (objtext2.Left(1) != "-") {
            var objtext3 = objtext2.split(" ");
            var regx = new RegExp("margin(.+?);", "g");
            if (objtext3.length == 1) {
                zstr = "margin-top:" + objtext3[0] + ";margin-right:" + objtext3[0] + ";margin-bottom:" + objtext3[0] + ";margin-left:" + objtext3[0] + ";";
            } else if (objtext3.length == 2) {
                zstr = "margin-top:" + objtext3[0] + ";margin-right:" + objtext3[1] + ";margin-bottom:" + objtext3[0] + ";margin-left:" + objtext3[1] + ";";
            } else if (objtext3.length == 3) {
                zstr = "margin-top:" + objtext3[0] + ";margin-right:" + objtext3[1] + ";margin-bottom:" + objtext3[2] + ";margin-left:" + objtext3[1] + ";";
            } else if (objtext3.length == 4) {
                zstr = "margin-top:" + objtext3[0] + ";margin-right:" + objtext3[1] + ";margin-bottom:" + objtext3[2] + ";margin-left:" + objtext3[3] + ";";
            }
            str = str.replace(regx, zstr);
        }
    }
    zstr = "";
    if (str.indexOf("padding") != -1) {
        var objtext2 = readstr(str, "padding").Trim();
        if (objtext2.Left(1) != "-") {
            var objtext3 = objtext2.split(" ");
            var regx = new RegExp("padding(.+?);", "g");
            if (objtext3.length == 1) {
                zstr = "padding-top:" + objtext3[0] + ";padding-right:" + objtext3[0] + ";padding-bottom:" + objtext3[0] + ";padding-left:" + objtext3[0] + ";";
                checkedall('padding', true);
            } else if (objtext3.length == 2) {
                zstr = "padding-top:" + objtext3[0] + ";padding-right:" + objtext3[1] + ";padding-bottom:" + objtext3[0] + ";padding-left:" + objtext3[1] + ";";
            } else if (objtext3.length == 3) {
                zstr = "padding-top:" + objtext3[0] + ";padding-right:" + objtext3[1] + ";padding-bottom:" + objtext3[2] + ";padding-left:" + objtext3[1] + ";";
            } else if (objtext3.length == 4) {
                zstr = "padding-top:" + objtext3[0] + ";padding-right:" + objtext3[1] + ";padding-bottom:" + objtext3[2] + ";padding-left:" + objtext3[3] + ";";
            }
            str = str.replace(regx, zstr);
        }
    }
    zstr = "";
    if (str.indexOf("border") != -1) {
        var objtext2 = readstr(str, "border").Trim();
        if (objtext2.Left(1) != "-") {
            var objtext3 = objtext2.split(" ");
            var regx = new RegExp("border(.+?);", "g");
            if (objtext3.length == 1) {
                zstr = "border-top-style:" + objtext3[0] + ";border-right-style:" + objtext3[0] + ";border-bottom-style:" + objtext3[0] + ";border-left-style:" + objtext3[0] + ";";
            } else if (objtext3.length == 2) {
                zstr = "border-top-style:" + objtext3[0] + ";border-right-style:" + objtext3[0] + ";border-bottom-style:" + objtext3[0] + ";border-left-style:" + objtext3[0] + ";";
                zstr += "border-top-width:" + objtext3[1] + ";border-right-width:" + objtext3[1] + ";border-bottom-width:" + objtext3[1] + ";border-left-width:" + objtext3[1] + ";";
            } else if (objtext3.length == 3) {
                zstr = "border-top-style:" + objtext3[0] + ";border-right-style:" + objtext3[0] + ";border-bottom-style:" + objtext3[0] + ";border-left-style:" + objtext3[0] + ";";
                zstr += "border-top-width:" + objtext3[1] + ";border-right-width:" + objtext3[1] + ";border-bottom-width:" + objtext3[1] + ";border-left-width:" + objtext3[1] + ";";
                zstr += "border-top-color:" + objtext3[2] + ";border-right-color:" + objtext3[2] + ";border-bottom-color:" + objtext3[2] + ";border-left-color:" + objtext3[2] + ";";
            }
            str = str.replace(regx, zstr);
        }
    }
    zstr = "";
    if (str.indexOf("list-style") != -1) {
        var objtext2 = readstr(str, "list-style").Trim();
        if (objtext2.Left(1) != "-") {
            var objtext3 = objtext2.split(" ");
            var regx = new RegExp("list-style(.+?);", "g");
            if (objtext3.length == 1) {
                zstr = "list-style-type:" + objtext3[0];
            } else if (objtext3.length == 2) {
                zstr = "list-style-type:" + objtext3[0] + ";list-style-position:" + objtext3[1] + ";";
            } else if (objtext3.length == 3) {
                zstr = "list-style-type:" + objtext3[0] + ";list-style-position:" + objtext3[1] + ";list-style-image:url(" + objtext3[2] + ");";
            }
            str = str.replace(regx, zstr);
        }
    }
    zstr = "";
    if (str.indexOf("background") != -1) {
        var objtext2 = readstr(str, "background").Trim();
        if (objtext2.Left(1) != "-") {
            var objtext3 = objtext2.split(" ");
            var regx = new RegExp("background(.+?);", "g");
            if (objtext3.length >= 1) {
                if (objtext3[0].Left(4) == "url(") {
                    zstr = "background-image:" + objtext3[0] + ";";
                } else if (objtext3[0].Left(1) == "#" || objtext3[0].Left(3) == "reg") {
                    zstr = "background-color:" + objtext3[0] + ";";
                }
                if (objtext3.length >= 2) {
                    if (objtext3[1].length > 0) {
                        zstr += "background-repeat:" + objtext3[1] + ";";
                    }
                    if (objtext3.length >= 3) {
                        zstr += "background-attachment:" + objtext3[2] + ";";
                    }
                    if (objtext3.length >= 4) {
                        zstr += "background-position:" + objtext3[3] + ";";
                    }
                }
            }
            str = str.replace(regx, zstr);
        }
    }
    zstr = "";
    if (str.indexOf("font") != -1) {
        var objtext2 = readstr(str, "font").Trim();
        if (objtext2.Left(1) != "-") {
            var objtext3 = objtext2.split(" ");
            var regx = new RegExp("font(.+?);", "g");
            if (objtext3.length >= 1) {
                for (var i = 0; i < objtext3.length && i < 3; i++) {
                    if ("|normal|bold|bolder|lighter|".indexOf("|" + objtext3[i] + "|") != -1 || objtext3[i].isNumber()) {
                        zstr += "font-weight:" + objtext3[i] + ";";
                        objtext3.splice(i, 1);
                        break;
                    }
                }
                for (var i = 0; i < objtext3.length && i < 3; i++) {
                    if ("|normal|italic|oblique|".indexOf("|" + objtext3[i] + "|") != -1) {
                        zstr += "font-style:" + objtext3[i] + ";";
                        objtext3.splice(i, 1);
                        break;
                    }
                }
                for (var i = 0; i < objtext3.length && i < 3; i++) {
                    if ("|normal|small-caps|".indexOf("|" + objtext3[i] + "|") != -1) {
                        zstr += "font-variant:" + objtext3[i] + ";";
                        objtext3.splice(i, 1);
                        break;
                    }
                }
                if (objtext3.length >= 1) {
                    zstr += "font-size:" + objtext3[0] + ";";
                    objtext3.splice(0, 1);
                }
                if (objtext3.length >= 1) {
                    if (objtext3[0].Left(1).isNumber()) {
                        zstr += "line-height:" + objtext3[0] + ";";
                        objtext3.splice(0, 1);
                    }
                }
                if (objtext3.length >= 1) {
                    zstr += "font-family:" + objtext3[0] + ";";
                    objtext3.splice(0, 1);
                }
            }
            str = str.replace(regx, zstr);
        }
    }
    var vstr = ";" + str + " ";
    for (i = 0; i < yq_style.length; i++) {
        for (j = 0; j < yq_style[i].length; j++) {
            if (yq_style[i][j].length >= 2) {
                var objname = yq_style[i][j][0].toLowerCase();
                var objtext1 = yq_style[i][j][1];
                if (str.indexOf(objname) != -1) {
                    if (str.substr(str.indexOf(objname) - 1, 1) != "-") {
                        var regx = new RegExp(";" + objname + "(.+?);", "g");
                        vstr = vstr.replace(regx, ";");
                        var objtext2 = readstr(str, objname).Trim();
                        if (objtext2.length > 0 && selectindex == -1) {
                            selectindex = i;
                        }
                        switch (objtext1.Left(1)) {
                            case "0":
                                objs.find("#" + objname).val(objtext2.replace("url(", "").replace(")", ""));
                                break;
                            case "1":
                                if (objtext1.length <= 1) {
                                    var objtext4 = RemoveNum(objtext2); //单位等
                                    var objtext3 = objtext2.substr(0, objtext2.length - objtext4.length); //数字
                                    if (objtext3.length <= 0) {
                                        objtext3 = objtext2;
                                        objtext4 = "";
                                    }
                                    var obj = objs.find("#" + objname).get(0);
                                    var obj1 = objs.find("#" + objname + "-y").get(0);
                                    var obj2 = objs.find("#" + objname + "-dw").get(0);
                                    if (inpnull(obj) && inpnull(obj1)) {
                                        obj.disabled = false;
                                        obj1.disabled = false;
                                        if (obj1.type == "select-one" && obj.type == "text") {
                                            objtext5 = selected(obj1, objtext3);
                                            if (objtext5.length > 0) {
                                                obj.value = objtext5;
                                            }
                                            if (inpnull(obj2) && objtext4.length > 0) {
                                                obj2.disabled = false;
                                                selected(obj2, objtext4);
                                            }
                                        }
                                    }
                                } else {
                                    var objtext = objtext1.substr(1, objtext1.length);
                                    if (objtext.isNumeric()) {
                                        var svalue = "";
                                        objtext21 = objtext2.split(" ");
                                        for (q = 1; q <= parseInt(objtext); q++) {
                                            var obj = $id(objname + "(" + q + ")");
                                            var obj1 = $id(objname + "(" + q + ")" + "-y");
                                            var obj2 = $id(objname + "(" + q + ")" + "-dw");
                                            if (inpnull(obj) && inpnull(obj1)) {
                                                if (obj1.type == "select-one" && obj.type == "text") {
                                                    for (qq = 0; qq < objtext21.length; qq++) {
                                                        objtext5 = selected(obj1, objtext21[qq]);
                                                        if (objtext5.length > 0) {
                                                            obj.value = objtext5;
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                break;
                            case "2":

                                var objtext = objtext1.substr(1, objtext1.length);
                                switch (objtext.substr(0, 1)) {
                                    case "1":
                                        var objtext1 = objtext.substr(1, 1);
                                        var objtext = objtext.substr(2, objtext.length);
                                        if (objtext1.isNumeric()) {
                                            var svalue1 = ""
                                            for (q = 1; q <= parseInt(objtext1); q++) {
                                                svalue1 = svalue1 + "?" + q + ",";
                                            }
                                            if (svalue1.length > 0) {
                                                svalue1 = svalue1.substr(0, svalue1.length - 1);
                                            }
                                            var objtext11 = objtext.split(svalue1);
                                            if (objtext11 != null) {
                                                for (q = 0; q <= objtext11.length; q++) {
                                                    objtext2 = objtext2.replace(objtext11[q], "");
                                                }
                                            }

                                            var objtext11 = objtext2.split(",");
                                            if (objtext11 != null) {
                                                if (objtext11.length == parseInt(objtext1)) {
                                                    for (q = 1; q <= parseInt(objtext1); q++) {
                                                        var objtext4 = RemoveNum(objtext11[q - 1]); //单位等
                                                        var objtext3 = objtext11[q - 1].substr(0, objtext11[q - 1].length - objtext4.length); //数字
                                                        if (objtext3.length <= 0) {
                                                            objtext3 = objtext11[q - 1];
                                                            objtext4 = "";
                                                        }
                                                        var obj = objs.find("#" + objname + "-" + q).get(0);
                                                        var obj1 = objs.find("#" + objname + "-" + q + "-y").get(0);
                                                        var obj2 = objs.find("#" + objname + "-" + q + "-dw").get(0);
                                                        if (inpnull(obj) && inpnull(obj1)) {
                                                            if (obj1.type == "select-one" && obj.type == "text") {
                                                                objtext5 = selected(obj1, objtext3);
                                                                if (objtext5.length > 0) {
                                                                    obj.value = objtext5;
                                                                }
                                                                if (inpnull(obj2) && objtext4.length > 0) {
                                                                    obj2.disabled = false;
                                                                    selected(obj2, objtext4);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "2":
                                        var obj = objs.find("#" + objname).get(0);
                                        var obj1 = objs.find("#" + objname + "-y").get(0);
                                        if (inpnull(obj) && inpnull(obj1)) {
                                            if (obj1.type == "select-one" && obj.type == "text") {
                                                objtext5 = selected(obj1, objtext2);
                                                if (objtext5.length > 0) {
                                                    obj.value = objtext2;
                                                }
                                            }
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "3":

                                var svalue = objs.find("input[name=" + objname + "]");
                                for (var ii = 0; ii < svalue.length; ii++) {
                                    if (objtext2.indexOf(svalue.eq(ii).val().toLowerCase()) != -1) {
                                        svalue.eq(ii).attr("checked", "true");
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
    if (vstr.length > 0) {
        var regx = new RegExp("[ ]", "g");
        vstr = vstr.replace(regx, "");
        if (vstr != ";") {
            var obj = objs.find("#other_code").get(0);
            if (inpnull(obj)) {
                obj.value = vstr;
                if (selectindex == -1) { selectindex = 10; }
            }
        }
    }
    if (selectindex != -1) {
        var obj = objs.find("#yq_list_style").get(0);
        if (inpnull(obj)) {
            obj.selectedIndex = selectindex;
            try {
                select(obj.options[selectindex].value, obj);
            } catch (e) { }
        }
    }
    if (objs.find("#padding").attr("checked") == "checked") {
        checkedall('padding', true);
    }
    if (objs.find("#margin").attr("checked") == "checked") {
        checkedall('margin', true);
    }
    if (objs.find("#border-style").attr("checked") == "checked") {
        checkedall('border', true, "-style");
    }
    if (objs.find("#border-width").attr("checked") == "checked") {
        checkedall('border', true, "-width");
    }
    if (objs.find("#border-color").attr("checked") == "checked") {
        checkedall('border', true, "-color");
    }
    obj = null;
    objs = null;
}
//设置下拉框的VALUE值。返回TEXT值
function selected(obj,objvalue)
{
	for(yq_i=0;yq_i<obj.options.length;yq_i++) {
	    if (obj.options[yq_i].value == "yq" && objvalue.isNumeric())
		{
			obj.selectedIndex=yq_i;
			return objvalue;
		}else{
			if((objvalue==obj.options[yq_i].value.replace("&quot;","\"").replace("&quot;","\"") && obj.options[yq_i].value.indexOf("?")==-1) || (replacenum(objvalue,obj.options[yq_i].value).indexOf("?")==-1 && obj.options[yq_i].value.indexOf("?")!=-1))
			{
				obj.selectedIndex=yq_i;
				return obj.options[yq_i].text;
			}
		}
	}
	return "";
}
//取CSS样式值
function readstr(str,str1)
{
	if(str.indexOf(str1)!=-1)
	{
		var str2=str.split(str1);
		if(str2.length>=2)
		{
			if(str2[0].substr(str2[0].length-1,1)!="-")
			{
				var str2=str2[1].split(";");
				var str3 = str2[0].Trim();
				if(str3.substr(0,1)==":")
				{
					str3=str3.substr(1,str3.length);
				}
				return str3;
			}
			return "";
		}
	}
}


//去除数字保留数字之外的
function RemoveNum(str)
{
	var strNew = "";
	str = str.Trim();
	var num="0123456789";
	for (yq_i = 0; yq_i < str.length; yq_i++)
	{
		if(num.indexOf(str.substr(yq_i,1))==-1)
		{
			strNew=strNew+str.substr(yq_i,1);
		}
	}
	return strNew;
}
//对比
function IntegrationArray(str1, str2, str3) {
    var str4 = "";
    var str5 = str1.indexOf(str2);
    if (str5 != -1) {
        str5 = str5 + str2.length;
        var str7 = str1.substring(str5);
        var str6 = str7.indexOf(str3);
        if (str6 != -1) {
            str4 = str1.substring(str5, str5 + str6);
        } else {
            str4 = str1.substring(str5);
        }
    }
    return str4;
}
//单样式合并
function IntegrationStyle(str) {
    str = str.toLowerCase();
    for (var i = 0; i < IntegrationStyleList.length; i++) {
        var style1 = IntegrationStyleList[i][0];
        var style2 = style1.split("-$1")[0];
        var style33 = IntegrationStyleList[i][1];
        var style3 = new Array();
        var style4 = IntegrationStyleList[i][2];
        var WCstr = null;
        if (str.indexOf(style2 + "-") != -1) {
            WCstr = null;
            for (var j = 0; j < WithdrawCss.length; j++) {
                if (style2 == WithdrawCss[j][0]) {
                    WCstr = WithdrawCss[j];
                }
            }
            var jl1 = -1;
            var jl2 = -1;
            for (var j = 0; j < style33.length; j++) {
                vstr = IntegrationArray(str, style1.replace("$1", style33[j]) + ":", ";");
                if ((vstr.length <= 0 || j == style33.length - 1) && jl2 == -1 && jl1 != -1) {
                    jl2 = j;
                } else {
                    if (jl1 == -1 && vstr.length > 0) {
                        jl1 = j;
                    }
                }
                if (vstr == "0px") { vstr = "0"; }
                style3[j] = vstr;
            }
            vstr = "";
            if (style4 == "1" && (jl2 - jl1 >= 2)) {
                for (var j = jl1; j <= jl2; j++) {
                    var regx = new RegExp(style1.replace("$1", style33[j]) + ":(.+?);", "gi");
                    str = str.replace(regx, "");
                    vstr = vstr + style3[j] + " ";
                }
                vstr = vstr.Trim();
            } else {
                if (style4 == "2" && jl2 != -1 && jl1 != -1) {
                    var jlz = -1;
                    for (var j = 0; j < style33.length; j++) {
                        var regx = new RegExp(style1.replace("$1", style33[j]) + ":(.+?);", "gi");
                        str = str.replace(regx, "");
                        if (style3[j].length <= 0) {
                            style3[j] = "0";
                        }
                        vstr = vstr + style3[j] + " ";
                    }
                    vstr = vstr.Trim();
                    vstr = vstr.replace(/\s+/g, " ");
                    if (style3[0] == style3[1] && style3[1] == style3[2] && style3[2] == style3[3]) {
                        vstr = style3[0];
                    } else {
                        if (style3[1] == style3[3] && style3[0] == style3[2]) {
                            vstr = style3[0] + " " + style3[1];
                        } else {
                            if (style3[1] == style3[3] && style3[0] != style3[2]) {
                                vstr = style3[0] + " " + style3[1] + " " + style3[2];
                            }
                        }
                    }
                }
            }
            if (vstr.length > 0) {
                vstr = style1.replace("-$1", "") + ":" + vstr + ";";
                if (inpnull(WCstr)) {
                    if (WCstr[3] == 1) {
                        if (str.indexOf(WCstr[1]) != -1 && str.indexOf(WCstr[2]) == -1) {
                            str = str + WCstr[2];
                        }
                    }
                }
                str = str + vstr;
            }
        }
    }
    var regx = new RegExp("(:)( )?", "gi");
    str = str.replace(regx, "$1");
    var regx = new RegExp("(;)( )?", "gi");
    str = str.replace(regx, "$1");
    return str;
}

//生成样式
function createcss() {
    var cssvalue = new Array();
    var objs = $(".yq_style");
    $(yq_style).each(function() {
        cssvalue.push(createcss1(objs, this));
    });
   
    return IntegrationStyle(cssvalue.join(""));
}
//生成样式第二步
function createcss1(objs, value) {
    var returnvalue = "";
    for (j = 0; j < value.length; j++) {
        if (value[j].length >= 2) {
            var bjvalue = value[j][1];
            var objname = value[j][0];
            switch (bjvalue.Left(1)) {
                case "0":
                    var obj = objs.find("#" + objname);
                    var objtext = "?";
                    if (bjvalue.length > 1) {
                        objtext = bjvalue.substr(1, bjvalue.length);
                    }
                    if (obj.length > 0) {
                        var svalue = obj.val();
                        if (svalue.length > 0) {
                            svalue = objtext.replace("?", svalue);
                            returnvalue = returnvalue + objname + ":" + svalue + ";";
                        }
                    }
                    break;
                case "1":
                    if (bjvalue.length <= 1) {
                        var obj = objs.find("#" + objname);
                        if (obj.val().length > 0) {
                            var obj1 = objs.find("#" + objname + "-y");
                            var obj2 = objs.find("#" + objname + "-dw");
                            if (obj1.get(0).type == "select-one" && obj.get(0).type == "text") {
                                var svalue = selectok(obj1, obj.val(), obj2);
                                if (svalue.length > 0) {
                                    returnvalue = returnvalue + objname + ":" + svalue + ";";
                                }
                            }
                        }
                    } else {
                        var objtext = bjvalue.substr(1, bjvalue.length);
                        if (objtext.isNumeric()) {
                            var svalue = "";
                            for (q = 1; q <= parseInt(objtext); q++) {
                                var obj = $($id(objname + "(" + q + ")"));
                                if (obj.val().length > 0) {
                                    var obj1 = $($id(objname + "(" + q + ")" + "-y"));
                                    var obj2 = $($id(objname + "(" + q + ")" + "-dw"));
                                    if (obj1.get(0).type == "select-one" && obj.get(0).type == "text") {
                                        svalue = svalue + selectok(obj1, obj.val(), obj2) + " ";
                                    }
                                }
                            }
                            svalue = svalue.Trim();
                            if (svalue.length > 0) {
                                returnvalue = returnvalue + objname + ":" + svalue + ";";
                            }
                        }
                    }
                    break;
                case "2":
                    var objtext = bjvalue.substr(1, bjvalue.length);
                    switch (objtext.substr(0, 1)) {
                        case "1":
                            var objtext1 = objtext.substr(1, 1);
                            var objtext = objtext.substr(2, objtext.length);
                            if (objtext1.isNumeric()) {
                                var svalue = "";
                                var svalue1 = ""
                                for (q = 1; q <= parseInt(objtext1); q++) {
                                    svalue = "";
                                    var obj = objs.find("#" + objname + "-" + q);
                                    if (obj.val().length > 0) {
                                        var obj1 = objs.find("#" + objname + "-" + q + "-y");
                                        var obj2 = objs.find("#" + objname + "-" + q + "-dw");
                                        if (obj1.get(0).type == "select-one" && obj.get(0).type == "text") {
                                            svalue = selectok(obj1, obj.val(), obj2);
                                            svalue1 = svalue1 + svalue;
                                        }
                                    }
                                    if (svalue.length <= 0 && svalue1.length > 0) {
                                        svalue = "auto";
                                    }
                                    objtext = objtext.replace("?" + q, svalue);
                                }
                                if (objtext.length > 10) {
                                    returnvalue = returnvalue + objname + ":" + objtext + ";";
                                }
                            }
                            break;
                        case "2":
                            var obj = objs.find("#" + objname);
                            if (obj.val().length > 0) {
                                var obj1 = objs.find("#" + objname + "-y");
                                if (obj1.get(0).type == "select-one" && obj.get(0).type == "text") {
                                    var svalue = selectok(obj1, obj.val());
                                    if (svalue.length > 0) {
                                        returnvalue = returnvalue + objname + ":" + svalue + ";";
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case "3":
                    var objslist = objs.find("input[name=" + objname + "][checked='true']");
                    var svalue = ""
                    for (var ii = 0; ii < objslist.length; ii++) {
                        svalue = svalue + objslist.eq(ii).val() + " ";
                    }
                    svalue = svalue.Trim();
                    if (svalue.length > 0) {
                        returnvalue = returnvalue + objname + ":" + svalue + ";"
                    }
                    break;
                default:
                    break;
            }
        }
    }
    objs = null;
    obj = null;
    obj1 = null;
    obj2 = null;
    return returnvalue;
}
//移除
function replacenum(jljl,jl)
{
	jl=jl.replace(/[ ]/g,"").toLowerCase();
	var jl1=jl.split("?");
	jljl=jljl.replace(/[ ]/g,"").toLowerCase();
	if(jl1!=null)
	{
		for(r=0;r<jl1.length;r++)
		{
			jljl=jljl.replace(jl1[r],"");
		}
	}
	return jljl
}

//下拉框选择
function selectok(obj,objvalue,obj1)
{
    if (objvalue.isNumeric()) {
        return objvalue + obj1.val();
    } else {
        var v = obj.val();
        var t = obj.find("option:selected").text();
        if (v != "yq") {
            if ((objvalue == t && v.indexOf("?") == -1) || (replacenum(objvalue, v).indexOf("?") == -1 && v.indexOf("?") != -1)) {
                if (objvalue == t && v.indexOf("?") == -1) {
                    return v;
                } else {
                    return objvalue;
                }
            }
        }
    }
    return "";
}

function select(i,obj1)
{
	for(i1=0;i1<obj1.options.length;i1++)
	{
		var obj=document.getElementById("yq_selectid_"+obj1.options[i1].value);
		if(inpnull(obj))
		{
			obj.style.display="none";
		}
	}
	var obj=document.getElementById("yq_selectid_"+i);
	var obj2=document.getElementById("csslistview");
	if(inpnull(obj))
	{
		obj2.innerHTML="&nbsp;"+obj1.options[obj1.selectedIndex].text
		obj.style.display="block";
	}
	obj=null;
	obj1=null;
}
function replacetext(objname,objthis,objlx)
{
	if(objthis.selectedIndex>=0 && objthis.selectedIndex<=objthis.options.length)
	{
		if(objlx!=null)
		{
			var ivalue=objthis.options[objthis.selectedIndex].value;
		}else{
			var ivalue=objthis.options[objthis.selectedIndex].text;
		}
		var obj=document.getElementById(objname);
		if(inpnull(obj))
		{
			obj.value=ivalue;
			dwdisabled(objname);
		}
	}
	obj=null;
}
function change(objname)
{
	var obj=document.getElementById(objname);
	if(inpnull(obj))
	{
		obj.selectedIndex=-1;
	}
	obj=null;
}

function dwdisabled(objname)
{
	var obj=document.getElementById(objname);
	var obj1=document.getElementById(objname+"-dw");
	if(inpnull(obj) && inpnull(obj1))
	{
	    if (obj.value == "(值)" || obj.value.isNumeric())
		{
			obj1.disabled=false;
		}else{
			obj1.disabled=true;
		}
	}
	obj=null;
	obj1=null;
}

function changecolor(objname)
{
	var obj=document.getElementById(objname);
	var obj1=document.getElementById(objname+"-view");
	if(inpnull(obj) && inpnull(obj1))
	{
		try{
			obj1.style.backgroundColor=(obj.value);
		}catch(e){}
	}
}

function selectinput(objname,objlx,objchecked)
{
	var objs=document.getElementsByTagName("input") 
	for(var ii=0;ii<objs.length;ii++) 
	{
	    if(objs[ii].id==objname)
	    {
			if(objlx==0)
			{
				if(objchecked)
				{
					if(objs[ii].value=="none" && objs[ii].checked)
					{
						objs[ii].checked=false;
					}
				}
			}else{
				if(objchecked)
				{
					if(objs[ii].value!="none")
					{
						objs[ii].checked=false;
					}
				}
			}
		}
	}
}
function checkedall(objname,objchecked,objvalue)
{
	if(objvalue==null)
	{
		objvalue="";
	}
	if(!objchecked)
	{
		var obj=document.getElementById(objname+"-right"+objvalue);
		if(inpnull(obj)){obj.disabled=false;}
		var obj=document.getElementById(objname+"-right"+objvalue+"-y");
		if(inpnull(obj)){obj.disabled=false;}
		var obj=document.getElementById(objname+"-right"+objvalue+"-img");
		if(inpnull(obj)){obj.disabled=false;}
		var obj=document.getElementById(objname+"-bottom"+objvalue);
		if(inpnull(obj)){obj.disabled=false;}
		var obj=document.getElementById(objname+"-bottom"+objvalue+"-y");
		if(inpnull(obj)){obj.disabled=false;}
		var obj=document.getElementById(objname+"-bottom"+objvalue+"-img");
		if(inpnull(obj)){obj.disabled=false;}
		var obj=document.getElementById(objname+"-left"+objvalue);
		if(inpnull(obj)){obj.disabled=false;}
		var obj=document.getElementById(objname+"-left"+objvalue+"-y");
		if(inpnull(obj)){obj.disabled=false;}
		var obj=document.getElementById(objname+"-left"+objvalue+"-img");
		if(inpnull(obj)){obj.disabled=false;}
	}else{
		var obj=document.getElementById(objname+"-right"+objvalue);
		if(inpnull(obj)){obj.disabled=true;}
		var obj=document.getElementById(objname+"-right"+objvalue+"-dw");
		if(inpnull(obj)){obj.disabled=true;}
		var obj=document.getElementById(objname+"-right"+objvalue+"-y");
		if(inpnull(obj)){obj.disabled=true;}
		var obj=document.getElementById(objname+"-right"+objvalue+"-img");
		if(inpnull(obj)){obj.disabled=true;}
		var obj=document.getElementById(objname+"-bottom"+objvalue);
		if(inpnull(obj)){obj.disabled=true;}
		var obj=document.getElementById(objname+"-bottom"+objvalue+"-dw");
		if(inpnull(obj)){obj.disabled=true;}
		var obj=document.getElementById(objname+"-bottom"+objvalue+"-y");
		if(inpnull(obj)){obj.disabled=true;}
		var obj=document.getElementById(objname+"-bottom"+objvalue+"-img");
		if(inpnull(obj)){obj.disabled=true;}
		var obj=document.getElementById(objname+"-left"+objvalue);
		if(inpnull(obj)){obj.disabled=true;}
		var obj=document.getElementById(objname+"-left"+objvalue+"-dw");
		if(inpnull(obj)){obj.disabled=true;}
		var obj=document.getElementById(objname+"-left"+objvalue+"-y");
		if(inpnull(obj)){obj.disabled=true;}
		var obj=document.getElementById(objname+"-left"+objvalue+"-img");
		if(inpnull(obj)){obj.disabled=true;}
		replaceall(objname,objvalue);
	}
	obj=null;
}
function replaceall(objname,objvalue)
{
	if(objvalue==null)
	{
		objvalue="";
	}
	var obj=document.getElementById(objname+objvalue);
	var obj1=document.getElementById(objname+"-top"+objvalue);
	var obj2=document.getElementById(objname+"-top"+objvalue+"-dw");
	var obj3=document.getElementById(objname+"-top"+objvalue+"-y");
	var obj4 = document.getElementById(objname + "-top" + objvalue + "-view");
		if(inpnull(obj) && inpnull(obj1))
		{
			if(obj.checked){
				if(inpnull(obj2) && inpnull(obj3))
				{
					var objvalue2=obj2.selectedIndex;
					var objvalue3=obj3.selectedIndex;				
				}else{
					var objvalue2=-1;
					var objvalue3=-1;				
				}
				if(inpnull(obj4))
				{
					var objvalue4=obj4.style.backgroundColor;
				}else{
					var objvalue4=""
				}
				var objvalue1=obj1.value;

				var obj=document.getElementById(objname+"-right"+objvalue);
				if(inpnull(obj)){obj.value=objvalue1;}
				var obj=document.getElementById(objname+"-right"+objvalue+"-dw");
				if(inpnull(obj)){obj.selectedIndex=objvalue2;}
				var obj=document.getElementById(objname+"-right"+objvalue+"-y");
				if(inpnull(obj)){obj.selectedIndex=objvalue3;}
				var obj = document.getElementById(objname + "-right" + objvalue + "-view");
				if (inpnull(obj)) { obj.style.backgroundColor = objvalue4; }
				var obj=document.getElementById(objname+"-bottom"+objvalue);
				if(inpnull(obj)){obj.value=objvalue1;}
				var obj=document.getElementById(objname+"-bottom"+objvalue+"-dw");
				if(inpnull(obj)){obj.selectedIndex=objvalue2;}
				var obj=document.getElementById(objname+"-bottom"+objvalue+"-y");
				if(inpnull(obj)){obj.selectedIndex=objvalue3;}
				var obj = document.getElementById(objname + "-bottom" + objvalue + "-view");
				if (inpnull(obj)) { obj.style.backgroundColor = objvalue4; }
				var obj=document.getElementById(objname+"-left"+objvalue);
				if(inpnull(obj)){obj.value=objvalue1;}
				var obj=document.getElementById(objname+"-left"+objvalue+"-dw");
				if(inpnull(obj)){obj.selectedIndex=objvalue2;}
				var obj=document.getElementById(objname+"-left"+objvalue+"-y");
				if(inpnull(obj)){obj.selectedIndex=objvalue3;}
				var obj = document.getElementById(objname + "-left" + objvalue + "-view");
				if (inpnull(obj)) { obj.style.backgroundColor = objvalue4; }
			}
		}
	obj1=null;
	obj2=null;
	obj3=null;
}



//判断是否为空
function inpnull(obj)
{
	if(obj!=null && obj!=undefined && obj!="")
	{
		return true;
	}else{
		return false;;
	}
}