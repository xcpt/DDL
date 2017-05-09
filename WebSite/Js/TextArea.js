var isIE = navigator.userAgent.indexOf('MSIE') != -1;
var isIE9 = navigator.userAgent.indexOf('MSIE 9') != -1;
var InterVersion = getBrowserOS();
var LabelArray = null;
///样式添加
function TextClickCss(obj) {
    obj.Menu = true;
    obj.T = "";
    obj.MenuTrue = "";
    obj.selectOStr = "";
    obj.selectStr = ""; 	//判断是否有选择的东西。
    obj.selectTrue = 1; 	//判断是否能够插入东西。
    obj.Tvalue = ""; 		//保存修改前内容。
    obj.UserKey = 0;
    $(obj).unbind().bind("contextmenu", function(e) {
        this.UserKey = 0; this.selectStr = ""; this.Tvalue = this.value; fText(this, 1, e);
    }).bind("dragenter", function(e) {
        return false; stopBubble(e || getEvent());
    }).bind("keydown", function(e) {
        this.UserKey = 1; e = e || getEvent();
        if (e.keyCode == 9) {
            InsertAtCaret(this, '\t');
            return false;
        }
    }).bind("click", function(e) {
        this.UserKey = 0; this.selectStr = ""; this.Tvalue = this.value; fText(this, 1, e);
    }).bind("keyup", function(e) {
        this.UserKey = 1; e = e || getEvent();
        var code = e.keyCode;
        if (e.ctrlKey && isIE) {
            if (code == 90) {
                document.execCommand('Undo');
                this.focus();
                return false;
            } else if (code == 89) {
                document.execCommand('Redo');
                this.focus();
                return false;
            }
        }
        fText(this, 1, e);
    }).bind("blur", function () {
        f(this);
    });
    IECollectGarbage();
}
//空格tab转换
function TabSpace(w) {
    if (w.indexOf("\t") != -1 && w.indexOf(" ") != -1) {
        var wlength = w.split(" ").length - 1;
        var jl = wlength / 8;
        var jlInt = Math.round(jl);
        if (jl != jlInt) {
            if (jl > jlInt) {
                jlInt++;
            }
            w = w.replace("\t", ""); //删除一个
            for (var i = 0; i < jlInt * 8 - wlength; i++) {
                w = " " + w;
            }
        }
        return w;
    } else {
        return w;
    }
}
//处理函数，把文本框显示的转换为网页显示
function SyCmsHTMLEnCode(str) {
    if (str.length == 0) return "";
    str = str.replace(/&/g, "&amp;");
    str = str.replace(/</g, "&lt;");
    str = str.replace(/>/g, "&gt;");
    if (InterVersion != "Firefox") {
        str = str.replace(/[ \t]{1,}/g, function (w, t) {
            return TabSpace(w);
        });
        str = str.replace(/[ ]{2,}/g, function (w, t) {
            return w.split(" ").join("&nbsp;");
        });
        str = str.replace(/\r\n/g, "<br/>");
        str = str.replace(/\r/g, "<br/>");
        str = str.replace(/\n/g, "<br/>");
        str = str.replace(/\t/g, "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
        if (InterVersion == "MSIE") {
            var myRegExp = new RegExp("<br/>([ ]?)<br/>", "g");
            str = str.replace(myRegExp, "<br/>&nbsp;<br/>");
            str = str.replace(myRegExp, "<br/>&nbsp;<br/>");
            myRegExp = new RegExp("<br/> ", "g");
            str = str.replace(myRegExp, "<br/>&nbsp;");
        }
    }
    return str;
}

//查询标签语句。因为已经转换了特殊类型。所以此需要转换回去。结合上面使用。
function SyCmsViewSpan(str) {
    str = str.split("||SVSycms||").join("<");
    str = str.split("||EVSycms||").join(">");
    return str;
}
//调用各函数，把textarea显示出来。
function TextClickViewDiv(Str, LabelArray) {
    var str = Str.value;

    if (!LabelArray || !(LabelArray instanceof Array)) {
        LabelArray = CmsLabelList(str);
    }
    var mArr1 = new Array();
    var ID = "";
    for (var i = 0; i < LabelArray.length; i++) {
        ID = SyCmsToID(LabelArray[i]);
        if (("," + mArr1.join(",") + ",").indexOf("," + ID + ",") == -1) {
            mArr1.push(ID);
            str = str.split(LabelArray[i]).join("||SVSycms||span class=\"viewsycms\" id=\"" + ID + "\"||EVSycms||" + LabelArray[i] + "||SVSycms||/span||EVSycms||");
        }
    }
    mArr1 = null;
    str = SyCmsViewSpan(SyCmsHTMLEnCode(str));
    Str.PackageBg.html(str);
}
//显示行数
function TextClickViewLine(Str) {
    var icount = 0;
    icount = Str.value.split("\n").length;
    icount += 100;
    if (icount > Str.MaxCount) {
        var str = new Array();
        for (var i = Str.MaxCount; i <= icount; i++) {
            str.push(i);
        }
        Str.MaxCount = icount + 1;
        Str.PackageLine.append(str.join("<br/>") + "<br/>");
        str = null;
    }
}
///获取空间tab数量(textarea,位置)
function TextXXTab(objvalue, start) {
    var s1 = start;
    var tabs = "";
    if (s1) {
        var v = objvalue;
        for (var i = start - 1; i >= 0; i--) {
            s1 = i;
            if (v.substr(i, 1) == "\n") {
                s1++;
                break;
            }
        }
        var text = v.substr(s1, start - s1);
        var tabstr = "";
        for (var i = 0; i < text.length; i++) {
            tabstr = text.substr(i, 1);
            if (tabstr == " " || tabstr == "\t") {
                tabs += tabstr;
            } else {
                break;
            }
        }
    }
    return tabs;
}
///根据给定的格式字符串替换复制进来的格式信息
function TextSpaceTabReplace(objselectStr, jlxx) {
    jlxxLength = jlxx.length;
    objselectStr = objselectStr.split("\r").join("");
    var objselectStrArr = objselectStr.split("\n");
    for (var i = 0; i < objselectStrArr.length; i++) {
        var Spec = TextXXTab(objselectStrArr[i], objselectStrArr[i].length);
        if (Spec.length > 0) {
            var Spec1 = TabSpace(Spec).replace(/\t/g, "        ");
            var Spec1Length = Spec1.length;
            if (Spec1Length < jlxxLength) {
                objselectStrArr[i] = objselectStrArr[i].replace(Spec, "");
            } else {
                Spec1 = Spec1.substr(jlxxLength).split("        ").join("\t");
                objselectStrArr[i] = objselectStrArr[i].replace(Spec, Spec1);
            }
        }
    }
    objselectStr = objselectStrArr.join("\r\n");
    return objselectStr;
}

//给textarea绑定事件。
//给textarea绑定事件。
function TextClick(obj, Menu, T, MemberList, sobj, SyCmsView, OpenLine) {
    if ($(obj).attr("IsLabel") == "1") {
        LabelArray = obj;
    }
    //记录最原始的信息
    obj.oldValue = obj.value;
    obj.MemberList = null;
    obj.VarList = null;
    obj.MenuTrue = "1";
    obj.MaxCount = 1;
    obj.selectOStr = "";    //选定的其它东西
    obj.selectStr = ""; 	//判断是否有选择的东西。
    obj.selectTrue = 1; 	//判断是否能够插入东西。
    obj.Tvalue = ""; 		//保存修改前内容。
    obj.UserKey = 0;
    obj.SyCmsView = SyCmsView;
    obj.yMemberList = MemberList;
    obj.sobj = sobj;
    obj.Menu = Menu;
    obj.Save = true;
    obj.T = T;
    obj.ctrlz = false;
    var $obj = $(obj);
    if (OpenLine) {
        var PackageBg = $("#" + obj.id + "_Bg");
        if (PackageBg.length > 0) {
            obj.PackageBg = PackageBg;
            var PackageLine = $("#" + obj.id + "_Line");
            obj.PackageLine = PackageLine;
            obj.Package = PackageLine.parent();
//            if (InterVersion == "MSIE") {
                $(obj).attr("wrap", "soft");
                PackageBg.attr("wrap", "soft");
//            }else{
//                if (InterVersion == "Firefox") {
//                    $(obj).attr("wrap", "soft");
 //               } else {
 //                   $(obj).attr("wrap", "off").css({ "word-wrap": "normal", "white-space": "pre" });
//                    PackageBg.css({ "width": "70000" });
//                }
            //}
        } else {
            $obj.addClass("TextArea TextAreaSyCmsFont").wrap("<div id=\"" + obj.id + "_Package\" class=\"TextAreaSyCms\"></div>");
            var Package = $("#" + obj.id + "_Package");
            obj.Package = Package;
            Package.prepend("<div id=\"" + obj.id + "_Line\" class=\"TextAreaSyCmsLine TextAreaSyCmsFont\"></div>");
            Package.prepend("<pre id=\"" + obj.id + "_Bg\" class=\"TextAreaSyCmsPackage TextAreaSyCmsFont\"></pre>");
            PackageBg = $("#" + obj.id + "_Bg");
            obj.PackageBg = PackageBg;
            var PackageLine = $("#" + obj.id + "_Line");
            obj.PackageLine = PackageLine;
            Package.width($obj.width() + 35);
            Package.height($obj.height());
            //if (InterVersion == "MSIE") {
            $obj.attr("wrap", "soft");
                PackageBg.attr("wrap", "soft");
                PackageBg.width($obj.width());
            //}else{
            //    if (InterVersion == "Firefox") {
            //        $(obj).attr("wrap", "soft");
            //        PackageBg.css({ "width": $(obj).width() });
            //    } else {
            //        $(obj).attr("wrap", "off").css({ "word-wrap": "normal", "white-space": "pre" });
            //        PackageBg.css({ "width": "70000" });
            //    }
            //}
        }
    }
    $obj.bind("scroll", function () {
        if (this.PackageBg) {
            var h = this.scrollTop;
            var w = this.scrollLeft;
            this.PackageBg.css({ top: 0 - h, left: 35 - w });
            this.PackageLine.css({ top: 0 - h });
        }
    }).bind("mousedown", function (e) {
        this.focus();
    }).bind("contextmenu", function (e) {
        this.UserKey = 0; this.selectStr = ""; this.Tvalue = this.value; fText(this, "", e);
    }).bind("dragenter", function (e) {
        return false; stopBubble(e || getEvent());
    }).bind("keydown", function (e) {
        this.UserKey = 1;
        if (this.type == "textarea") {
            e = e || getEvent();
            if (e.keyCode == 9) {
                InsertAtCaret(this, '\t');
                if (this.PackageBg) {
                    setTimeout(function () { TextClickViewDiv(obj); }, 1);
                }
                return false;
            } else if (e.keyCode == 13) {
                var s = f(obj); 		//获得光标位置。
                var s1 = s.s;
                var v = this.value;
                for (var i = s.s - 1; i >= 0; i--) {
                    s1 = i;
                    if (v.substr(i, 1) == "\n") {
                        s1++;
                        break;
                    }
                }
                var text = v.substr(s1, s.s - s1);
                var tabs = "";
                for (var i = 0; text.match(/^[\t]+/g) && i < text.match(/^[\t]+/g)[0].length; i++) tabs += '\t';
                if (tabs == "") {
                    return true;
                } else {
                    InsertAtCaret(this, ((InterVersion == "MSIE" || InterVersion == "Opera") ? "\r\n" : "\n") + tabs, true);
                    if (this.PackageBg) {
                        setTimeout(function () { TextClickViewDiv(obj); }, 1);
                    }
                    return false;
                }
            }
        }
    }).bind("click", function (e) {
        this.UserKey = 0; this.selectStr = ""; this.Tvalue = this.value; fText(this, "", e);
    }).bind("keyup", function (e) {
        this.UserKey = 1; e = e || getEvent();
        var code = e.keyCode;
        var yS = this.selectionStartPointNoBr;
        var yE = this.selectionEndPointNoBr;
        if (e.ctrlKey) {
            if (isIE) {
                if (code == 90) {
                    this.ctrlz = true;
                    document.execCommand("Undo");
                    $(this).trigger("focus");
                    return false;
                } else if (code == 89) {
                    //this.Tvalue = this.value;
                    document.execCommand("Redo");
                    this.ctrlz = true;
                    $(this).trigger("focus");
                    return false;
                }
            }
            if (code == 86 || code == 88 || code == 90) {//剪切
                this.UserKey = 0;
                //this.Tvalue = this.value;
            }
        }
        var ftextreturnvalue = fText(this, "", e);
        this.Tvalue = this.value;
        //        if (ftextreturnvalue) {
        //            if (this.selectStr.length > 0 && this.selectStr.indexOf("<sycms ") != -1 && this.selectStr.indexOf("type=") != -1) {       //判断有没有标签
        //                if (yS != this.selectionStartPointNoBr || yE != this.selectionEndPointNoBr) {
        //                    VarFunction(this);
        //                }
        //            } else if (this.selectStr.length == 0) {
        //                var value = this.value;
        //                var Tvalue = this.Tvalue;
        //                if (!value) {
        //                    VarFunction(this);
        //                } else if (value.indexOf("<sycms ") != -1 && value.indexOf("type=") != -1) {       //判断有没有标签
        //                    VarFunction(this);
        //                } else if (Tvalue.indexOf("<sycms ") != -1 && Tvalue.indexOf("type=") != -1) {
        //                    VarFunction(this);
        //                }
        //            }
        //        }
    }).bind("focus", function () {
        var value = this.value;
        if ((value && value != this.Tvalue) || this.ctrlz) {
            if (value.indexOf("<sycms ") != -1 && value.indexOf("type=") != -1) {       //判断有没有标签
                VarFunction(this);
            }
            this.ctrlz = false;
        }
        this.Tvalue = value;
    }).bind("dblclick", function () {
        SyCmsLabelFunDblClick(this);
        return false;
    });
    //    }).bind("blur", function () {
    //f(this);
    if (SyCmsView) {
        if (obj.value.length > 0) {
            fText(obj, "");
        }
        obj.Tvalue = obj.value;
    }
    IECollectGarbage();
    var VarFunction = function (obj) {
        setTimeout(function () {
            obj.VarList = null;
            obj.MemberList = null;
            var objLabelTem = CmsLabelVarList(obj, obj.SyCmsView);
            obj.VarList = objLabelTem.Tem;
            VarSyCmsFunction(obj.yMemberList, obj, obj.sobj);
            if (obj.PackageBg) {
                TextClickViewDiv(obj, objLabelTem.Label);
                TextClickViewLine(obj);
            }
        }, 1);
    }
    if (obj.PackageBg) {
        TextClickViewLine(obj);
    }
    if (obj.value.length > 10) {
        try {
            setCursorPosition(obj, 0, 0);
        } catch (e) { }
    }
}
//缓存事件双击
function SyCmsLabelFunDblClick(obj) {
    var str = obj.selectStr;
    if (str) {
        if (str.Left(6) == "<sycms" && str.Right(1) == ">") {
            var xml = new XML();
            xml.SetXML("<?xml version='1.0' encoding='utf-8'?><xml>" + str + "</xml>");
            var Type = unescape(xml.getAttrib("xml/sycms", "type"));
            var Ytype = Type;
            switch (Type) {
                case "Plus":
                    {
                        Menu_PlusFun(obj, str);
                        break;
                    }
                case "Form":
                    {
                        if (FormList.length > 0) {
                            Menu_FormFun(obj, str);
                        }
                        break;
                    }
                case "Template":
                    {
                        MenuReadFun_Modi(obj, str);
                        break;
                    }
                default:
                    {
                        LabelFun(str, obj, Ytype);
                        break;
                    }
            }
        }
    }
}
//回写 样式模块
function ChangeTextFunAdd(styleID)
{
    if (LabelArray)
    {
        LabelArray.Package.addClass("TextAreaSyCmsChange StyleModelAddCss");
    }
}
//判断是否修改了
function ChangeTextFun(obj)
{
    if (obj.oldValue == obj.value) {
        if (!obj.Package.hasClass("StyleModelAddCss")) {
            obj.Package.removeClass("TextAreaSyCmsChange");
        }
    } else {
        obj.Package.addClass("TextAreaSyCmsChange");
    }
}
//对象 菜单 是否有菜单 对象类型空为标签有值为CSS
function fText(obj, SelectType, e) {
    if (obj.Package) {
        setTimeout(function () { ChangeTextFun(obj); }, 10);
    }
    var Menu = obj.Menu;
    var T = obj.T;
    var MemberList = obj.yMemberList;
    var sobj = obj.sobj;
    var SyCmsView = obj.SyCmsView;
    var $SyCmsView = $(SyCmsView);
    var PackageBg = obj.PackageBg;
    if (obj.type == "textarea" || obj.type == "text") {
        e = e || getEvent();
        var a = "";
        if (e) {
            a = e.keyCode; 	//获得单击按键。
        }
        if (obj.UserKey == 1 && (a < 33 || a > 40) && a != 8 && a != 46) {          //判断是否单击什么的
            return false;
        }
        var SE = new Array();
        if (SelectType) {
            SE.push("{");
            SE.push("}");
        } else {
            SE.push("<");
            SE.push(">");
        }
        var s = f(obj); 		//获得光标位置。
        //var s = savePos(obj); 		//获得光标位置。
        var Dv = obj.value; 	//保存控件当前值。
        var Tv = obj.Tvalue; 	//保存控件操作之前值。
        obj.selectOStr = Dv.substr(s.s, s.e - s.s);
        var Del = false;
        if (obj.MenuTrue == "1") {
            var selectStr = obj.selectStr; //获得选定文本

            var s1 = Dv.Left(s.s); 	//获得光标位置前面的字符串。
            var s2 = Dv.substr(s.s); //获得光标位置后面的字符串。
            var s1_1 = s1.split(SE[0]); 	//把前面字符串依<分隔
            var s2_1 = s2.split(SE[1]); 	//把后面的字符串依>分隔
            if (selectStr.length == 0) {
                if (a == 8)  //向前删除
                {
                    if (Tv.substr(s.s, 1) == SE[1]) {
                        s1 = Tv.Left(s.s - 1); 	//获得光标位置前面的字符串。
                        s2 = Tv.substr(s.s - 1); //获得光标位置后面的字符串。
                        s1_1 = s1.split(SE[0]); 	//把前面字符串依<分隔
                        s2_1 = s2.split(SE[1]); 	//把后面的字符串依>分隔
                        selectStr = AddWordValue(obj, s.s1 - 1, s1_1, s2_1, SE);
                        var selectStrLnegth = selectStr.length;
                        if (selectStrLnegth > 0) {
                            if (obj.selectionStartPoint != null && obj.selectionEndPoint != null) {
                                obj.Tvalue = obj.value = Tv.Left(obj.selectionStartPoint) + Tv.substr(obj.selectionStartPoint + selectStrLnegth);
                                setCursorPosition(obj, obj.selectionStartPointNoBr, obj.selectionStartPointNoBr);       //标记位置
                                Del = true;
                            }
                        }
                        selectStr = "";
                    }
                } else if (a == 46) { //向后删除
                    if (Tv.substr(s.s, 1) == SE[0]) {
                        s1 = Tv.Left(s.s + 1); 	//获得光标位置前面的字符串。
                        s2 = Tv.substr(s.s + 1); //获得光标位置后面的字符串。
                        s1_1 = s1.split(SE[0]); 	//把前面字符串依<分隔
                        s2_1 = s2.split(SE[1]); 	//把后面的字符串依>分隔
                        selectStr = AddWordValue(obj, s.s1 + 1, s1_1, s2_1, SE);
                        var selectStrLnegth = selectStr.length;
                        if (selectStrLnegth > 0) {
                            if (obj.selectionStartPoint != null && obj.selectionEndPoint != null) {
                                obj.Tvalue = obj.value = Tv.Left(obj.selectionStartPoint) + Tv.substr(obj.selectionStartPoint + selectStrLnegth);
                                setCursorPosition(obj, obj.selectionStartPointNoBr, obj.selectionStartPointNoBr);       //标记位置
                                Del = true;
                            }
                        }
                        selectStr = "";
                    }
                }
            } else {
                if (a == 8 || a == 46)  //向前删除
                {
                    obj.Tvalue = obj.value;
                    selectStr = "";
                    obj.selectStr = "";
                    Del = true;
                }
            }

            if (!Del) {             //无删除操作（特别是没选定的删除操作）
                if (s1_1.length > 1 && s2_1.length > 1) {
                    selectStr = AddWordValue(obj, s.s1, s1_1, s2_1, SE);
                    obj.selectStr = selectStr;
                }
                if (selectStr.length == 0 && s.s != s.e && s.s != (s.e - 1)) {        //没有的时候。再使用结束位置查找。
                    s1 = Dv.Left(s.e - 1); 	//获得光标位置前面的字符串。
                    s2 = Dv.substr(s.e - 1); //获得光标位置后面的字符串。
                    s1_1 = s1.split(SE[0]); 	//把前面字符串依<分隔
                    s2_1 = s2.split(SE[1]); 	//把后面的字符串依>分隔
                    if (s1_1.length > 1 && s2_1.length > 1) {
                        selectStr = AddWordValue(obj, s.e1 - 1, s1_1, s2_1, SE);
                        obj.selectStr = selectStr;
                    }
                }
            }
        }
        a = null;
        s = null;
        selectStr = null;
        Del = null;
        s1 = null;
        s2 = null;
        s1_1 = null;
        s2_1 = null;
        if (((Dv || Tv) && Dv != Tv)) {
            var Tv_1=Tv.indexOf("<sycms ");
            var Tv_2 = Tv.indexOf("type=");
            var Dv_1 = Dv.indexOf("<sycms ");
            var Dv_2 = Dv.indexOf("type=");
            
            if ((Dv_1 != -1 && Dv_2 != -1) || (Dv_1 == -1 && Dv_2 == -1 && Tv_1 != -1 && Tv_2 != -1)) {       //判断有没有标签
                setTimeout(function () {
                    obj.VarList = null;
                    obj.MemberList = null;
                    var objLabelTem = CmsLabelVarList(obj, obj.SyCmsView);
                    obj.VarList = objLabelTem.Tem;
                    if (obj.PackageBg) {
                        TextClickViewDiv(obj, objLabelTem.Label);
                        TextClickViewLine(obj);
                    }
                }, 1);
            } else if (obj.PackageBg) {
                setTimeout(function () { TextClickViewLine(obj); }, 1);
            }
        }
        $SyCmsView.find("div").removeClass("SycmsLabelCssHover");
        if (PackageBg) {
            PackageBg.find("span").removeClass("viewsycmsred");
        }
        if (obj.selectStr.length > 0) {
            setTimeout(function () {
                var objSelectID = SyCmsToID(obj.selectStr);
                var SyObj = $SyCmsView.find("div[id='" + objSelectID + "']");
                var Vindex = 0;
                var v = obj.value.Left(obj.selectionStartPoint);
                var v1 = v.split(obj.selectStr);
                Vindex = v1.length - 1;
                var top1 = $SyCmsView.offset().top;
                var height1 = $SyCmsView.height();
                var stop1 = $SyCmsView.scrollTop();
                if (SyObj.length > 0) {
                    SyObj.eq(Vindex).addClass("SycmsLabelCssHover");
                    $SyCmsView.scrollTop(0);
                    var top = SyObj.eq(Vindex).offset().top;
                    var height = SyObj.eq(Vindex).height();
                    $SyCmsView.scrollTop(top - top1 - height);
                }
                v1 = null;
                v = null;
                Vindex = null;
            }, 1);
        }
        Dv = null;
        Tv = null;
        VarSyCmsFunction(MemberList, obj, sobj);
        if (Menu) {
            TextMenu(obj, T, SelectType, MemberList);
        }
        if (obj.selectStr.length > 0) {
            obj.selectOStr = obj.selectStr;
        }
    }
    IECollectGarbage();
    return true;
}

function SyCmsToID(Url) {
    Url = $.md5(Url.replace(/[\$| |\"|\>|\=|\/|(|)|\<|\%]/g, "").replace(/sycms/g,"").replace(/type/g,"").replace(/order/g,"").replace(/title/g,"").replace(/date/g,"").replace(/scope/g,"").replace(/[\$| |\"|\%|'|(|)|\.]/g, ""));
    return Url;
}

function VarSyCmsFunction(MemberList, obj, sobj) {
    if (MemberList) {
        if (obj.VarList) {
            obj.MemberList = obj.VarList.concat(MemberList);
        } else {
            obj.MemberList = MemberList;
        }
    } else {
        if (obj.VarList) {
            obj.MemberList = obj.VarList;
        }
    }
    if (sobj) {
        if (sobj.VarList) {
            obj.MemberList = obj.MemberList.concat(sobj.VarList);
        }
    }
    if (obj.VarMember) {
        if (typeof (obj.MemberList) == "Array") {
            obj.MemberList = obj.MemberList.concat(obj.VarMember);
        } else {
            obj.MemberList = obj.VarMember;
        }
    }
    if (obj.MemberList) {
        obj.MemberList = formatX(obj.MemberList);
    }
}

///有开始和结尾的双标签
function SycmsLabelName2(Type) {
    return (Type == "list" || Type == "seo" || Type == "plus" || Type == "factor_if" || Type == "factor_for" || Type == "factor_or" || Type=="nav" || Type == "navigate" || Type == "template" || Type == "cookie" || Type == "varvalue" || Type=="count");
}
///单标签
function SycmsLabelName1(Type) {
    return (Type == "word" || Type == "pagelist" || Type == "form" || Type == "basictem" || Type == "var" || Type == "sys" || Type == "get" || Type == "user_login" || Type == "user_gourl" || Type == "sys_gotourl");
}
//选择
function AddWordValue(obj, s, s1_1, s2_1, SE) {
    var Ss1 = SE[0] + s1_1[s1_1.length - 1];
    var Se1 = s2_1[0] + SE[1];
    var str = Ss1 + Se1;
    var Select = false;
    if (SE[0] == "<") {
        var Type = RegExpBasic(str, "Type=").toLowerCase();
        if (Type.length > 0) {
            var Str_1 = str.split(SE[0]);
            var Str_2 = str.split(SE[1]);
            var Ss1_1 = Ss1.split(SE[0]);
            var Ss1_2 = Ss1.split(SE[1]);
            //&& Ss1_1.length != Ss1_2.length
            if (Ss1.Left(2) != SE[0] + "/" && (Ss1.Right(1) != SE[1] || Se1.replace("\r", "").replace("\n","").replace("\t", "").Left(5)==SE[0] + "item" || (Ss1.Right(1) == SE[1] && Se1.Right((SE[0] + "/sycms" + SE[1]).length) == SE[0] + "/sycms" + SE[1])) && Str_1.length == Str_2.length) {
                if (SycmsLabelName2(Type)) {   //有</SYCms>结尾的
                    var sadd = "";
                    for (var i = 0; i < s2_1.length; i++) {
                        sadd += s2_1[i] + SE[1];
                        if (s2_1[i].Right(7) == SE[0] + "/sycms") {
                            break;
                        }
                    }
                    if (sadd.length > 0) {
                        Se1 = sadd;
                        str = Ss1 + Se1;
                        Select = true;
                    }
                    if (str.Left(7) != SE[0] + "sycms ") {
                        if (str.indexOf(SE[0] + "sycms ") == -1 || Se1.Left(1) == SE[0]) {
                            Select = false;
                        } else {
                            str.substr(str.indexOf(SE[0] + "sycms "));
                        }
                    }
                    sadd = null;
                } else if (SycmsLabelName1(Type)) {       //没有结尾的时候
                    if (str.Trim().Right(2) == ("/" + SE[1])) {
                        Select = true;
                    }
                }
            }
        }

        if (str == SE[0] + "/sycms" + SE[1] || str.Left(5) == SE[0] + "item" || str.Left(6) == SE[0] + "/item" || str.Left(8) == SE[0] + "default" || str.Left(9) == SE[0] + "/default") {        //如果找到的是结尾的时候。或者是内部循环对象
            var sadd = "";
            var oldStr = str;
            for (var i = s1_1.length - 2; i >= 0; i--) {
                var Type = RegExpBasic(s1_1[i], "Type=").toLowerCase();
                sadd = SE[0] + s1_1[i] + sadd;
                if (SycmsLabelName2(Type)) {
                    break;
                }
            }
            if (sadd.length > 0) {
                Ss1 = sadd + Ss1;
                str = sadd + str;
                if (oldStr == SE[0] + "/sycms" + SE[1]) {
                    Select = true;
                } else {
                    var Type = RegExpBasic(str, "Type=").toLowerCase();
                    if (Type.length > 0) {
                        if (SycmsLabelName2(Type)) {   //有</SYCms>结尾的
                            var sadd = "";
                            for (var i = 0; i < s2_1.length; i++) {
                                sadd += s2_1[i] + SE[1];
                                if (s2_1[i].Right(7) == SE[0] + "/sycms") {
                                    break;
                                }
                            }
                            if (sadd.length > 0) {
                                Se1 = sadd;
                                str = Ss1 + Se1;
                                Select = true;
                            }
                            sadd = null;
                        } else if (SycmsLabelName1(Type)) {       //没有结尾的时候
                            if (str.Trim().Right(2) == ("/" + SE[1])) {
                                Select = true;
                            }
                        }
                    }
                    Type = null;
                }
            }
            sadd = null;
            oldStr = null;
        }
        if (!(str.Left(6) == SE[0] + "sycms" && str.Right(1) == SE[1] && str.indexOf(" type=") == str.lastIndexOf(" type="))) {
            Select = false;
        }
    } else {
        if (str.Left(1) == SE[0] && str.Right(1) == SE[1]) {
            var s1 = str.replace("{$Path$}", "").split(SE[0]);
            var s2 = str.replace("{$Path$}", "").split(SE[1]);
            if (s1.length == s2.length && s1.length == 2) {
                Select = true;
            }
        } else {
            var sadd = "";
            var oldStr = str;
            for (var i = s1_1.length - 2; i >= 0; i--) {
                sadd = SE[0] + s1_1[i] + sadd;
                if (sadd.Left(1) == "{" && sadd.Right(1) == "}") {
                    break;
                }
            }
            if (sadd.length > 0) {
                Ss1 = sadd + Ss1;
                str = sadd + str;
                if (str.Left(1) == "{" && str.Right(1) == "}") {
                    var sadd = "";
                    for (var i = 0; i < s2_1.length; i++) {
                        sadd += s2_1[i] + SE[1];
                        if (s2_1[i].Right(1) == SE[1]) {
                            break;
                        }
                    }
                    if (sadd.length > 0) {
                        Se1 = sadd;
                        str = Ss1 + Se1;
                        Select = true;
                    }
                    sadd = null;
                }
            }
            sadd = null;
            oldStr = null;
        }
    }
    if (Select) {
        setCursorPosition(obj, s - (Ss1.length - StrIndex(Ss1, "\n")), s + (Se1.length - StrIndex(Se1, "\n")));
    } else {
        str = "";
    }
    Ss1 = null;
    Se1 = null;
    Type = null;
    Select = null;
    Str_1 = null;
    Str_2 = null;
    Ss1_1 = null;
    Ss1_2 = null;
    IECollectGarbage();
    return str;
}

//多事件查找}
function fTextSub1(si1, s1_1, s1) {
    var bz = 0;
    for (var i = s1_1.length - 1; i > 0; i--) {
        bz += (s1_1[i].length + 1);
        if (s1_1[i].indexOf("}") == -1) {
            si1 = s1.length - bz;
            break;
        } else if (s1_1[i].split("}").length > 2) {
            break;
        }
    }
    return si1;
}
//多事件查找{
function fTextSub2(si2, s2_1) {
    var bz = 0;
    for (var i = 0; i < s2_1.length - 1; i++) {
        bz += (s2_1[i].length + 1);
        if (s2_1[i].indexOf("{") == -1) {
            si2 += bz;
            break;
        } else if (s2_1[i].split("{").length > 2) {
            break;
        }
    }
    return si2;
}
//删除回车换行IE678 不包括IE9
function StrIndex(str, Sstr) {
    if (document.all && !isIE9) {
        var s = str.split(Sstr);
        return s.length - 1;
    } else {
        return 0;
    }
}