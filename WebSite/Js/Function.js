﻿//不区别小写
if (!String.prototype._indexOf) {
    String.prototype._indexOf = String.prototype.indexOf;
    String.prototype.indexOf = function() {
        if (typeof (arguments[arguments.length - 1]) != 'boolean')
            return this._indexOf.apply(this, arguments);
        else {
            var bi = arguments[arguments.length - 1];
            var thisObj = this;
            var idx = 0;
            if (typeof (arguments[arguments.length - 2]) == 'number') {
                idx = arguments[arguments.length - 2];
                thisObj = this.substr(idx);
            }

            var re = new RegExp(arguments[0], bi ? 'i' : '');
            var r = thisObj.match(re);
            return r == null ? -1 : r.index + idx;
        }
    }
}
//if (window.HTMLElement) {
if (!document.all) {
    HTMLElement.prototype.__defineSetter__("outerHTML", function(sHTML) {
        var r = this.ownerDocument.createRange();
        r.setStartBefore(this);
        var df = r.createContextualFragment(sHTML);
        this.parentNode.replaceChild(df, this);
        return sHTML;
    });

    HTMLElement.prototype.__defineGetter__("outerHTML", function() {
        var attr;
        var attrs = this.attributes;
        var str = "<" + this.tagName.toLowerCase();
        for (var i = 0; i < attrs.length; i++) {
            attr = attrs[i];
            if (attr.specified)
                str += " " + attr.name + '="' + attr.value + '"';
        }
        if (!this.canHaveChildren)
            return str + ">";
        return str + ">" + this.innerHTML + "</" + this.tagName.toLowerCase() + ">";
    });

    HTMLElement.prototype.__defineGetter__("canHaveChildren", function() {
        switch (this.tagName.toLowerCase()) {
            case "area":
            case "base":
            case "basefont":
            case "col":
            case "frame":
            case "hr":
            case "img":
            case "br":
            case "input":
            case "isindex":
            case "link":
            case "meta":
            case "param":
                return false;
        }
        return true;
    });
    HTMLElement.prototype.__defineGetter__("innerText",
        function () {
            var anyString = "";
            var childS = this.childNodes;

            for (var i = 0; i < childS.length; i++) {
                if (childS[i].nodeType == 1) {
                    anyString += childS[i].tagName == "BR" ? '\n' : childS[i].innerText;
                } else if (childS[i].nodeType == 3) {
                    anyString += childS[i].nodeValue;
                }
            }

            return anyString;
        }
    );
    HTMLElement.prototype.__defineSetter__("innerText",
        function (sText) {
            this.textContent = sText;
        }
    );
}

// 对Date的扩展，将 Date 转化为指定格式的String   
// 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符，   
// 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字)   
// 例子：   
// (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423   
// (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18   
Date.prototype.Format = function (fmt) { //author: meizz   
    var o = {
        "M+": this.getMonth() + 1,                 //月份   
        "d+": this.getDate(),                    //日   
        "h+": this.getHours(),                   //小时   
        "m+": this.getMinutes(),                 //分   
        "s+": this.getSeconds(),                 //秒   
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度   
        "S": this.getMilliseconds()             //毫秒   
    };
    if (/(y+)/.test(fmt))
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt))
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}

function MouseCoords(ev) {
    if (ev.pageX || ev.pageY) {
        return {
            x: ev.pageX, y: ev.pageY
        }
    }
    return {
        x: ev.clientX + (window.pageXOffset || document.documentElement.scrollLeft || document.body.scrollLeft || 0), y: ev.clientY + (window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop || 0)
    }
}
///获得当前地址内参数
function getParameter(paraStr, url) {
    var result = "";
    if (url == undefined) {
        url = location.href;
    }
    //获取URL中全部参数列表数据
    var str = "";
    if (url.indexOf("?") != -1) {
        str = url.split("?")[1];
    } else {
        str = url;
    }
    if (url.Left(1) != "&") {
        url = "&" + url;
    }
    var paraName = paraStr + "=";
    //判断要获取的参数是否存在
    if (str.indexOf("&" + paraName) != -1) {
        //如果要获取的参数到结尾是否还包含“&”
        var sindex = str.indexOf(paraName);
        if (str.substring(sindex).indexOf("&") != -1) {
            //得到要获取的参数到结尾的字符串
            var TmpStr = str.substring(str.indexOf(paraName));
            //截取从参数开始到最近的“&”出现位置间的字符
            result = TmpStr.substr(TmpStr.indexOf(paraName), TmpStr.indexOf("&") - TmpStr.indexOf(paraName));
        }
        else {
            result = str.substring(sindex);
        }
    }
    else {
        result = "";
    }
    return (result.substr(paraName.length));
}

/*** 删除首尾空格 ***/
String.prototype.Trim = function() {
    return this.replace(/(^\s*)|(\s*$)/g, "");
}

/*** 统计指定字符出现的次数 ***/
String.prototype.Occurs = function(ch) {
    return this.split(ch).length - 1;
}
/*** 返回数字 ***/
String.prototype.Digit = function() {
    return this.replace(/\D/g, "");
}
/*** 检查是否由数字组成 ***/
String.prototype.isDigit = function() {
    var s = this.Trim();
    return (s.replace(/\d/g, "").length == 0);
}

/*** 检查是否由数字字母和下划线组成 ***/
String.prototype.isAlpha = function() {
    return (this.replace(/\w/g, "").length == 0);
}
/*** 检查是否由数字字母和下划线组成 字母开头 ***/
String.prototype.isZAlpha = function() {
    var reg = /^[a-zA-Z][a-zA-Z0-9_]*$/;
    if (reg.test(this))
        return true;
    else
        return false;
}

/*** 验证是否合法的颜色 ***/
String.prototype.checkColor = function() {
    var pattern = /^#[0-9a-fA-F]{6}$/
    if (this.match(pattern) == null)
        return false;
    else
        return true;
}


/*** 检查是否为数 ***/
String.prototype.isNumber = function() {
    var s = this.Trim();
    return (s.search(/^[+-]?[0-9.]*$/) >= 0);
}

/*** 返回字节数 一个汉字二个字符 ***/
String.prototype.Lenb = function() {
    return this.replace(/[^\x00-\xff]/g, "**").length;
}

/**取汉字及字符**/
String.prototype.MidStr = function(len) {
    var strlen = 0;
    var s = "";
    var ss = 1;
    var str = this;
    for (var i = 0; i < str.length; i++) {
        if (str.charCodeAt(i) > 255)
            ss = 2;
        else
            ss = 1;
        if (strlen + ss <= len) {
            s += str.charAt(i);
            strlen += ss
        } else {
            return s;
        }
    }
    return s;
}

/*** 检查是否包含汉字 ***/
String.prototype.isInChinese = function() {
    return (this.length != this.replace(/[^\x00-\xff]/g, "**").length);
}
/*** 是否为汉字 ***/
String.prototype.existChinese = function() {
    //[\u4E00-\u9FA5]为汉字，[\uFE30-\uFFA0]为全角符号
    return /^[\x00-\xff]*$/.test(this);
}

/***是否是有效的电话号码***/
String.prototype.isPhoneCall = function() {
    var reg = /^(((\()?\d{2,4}(\))?[-(\s)*]){0,2})?(\d{7,8})$/;
    if (reg.test(this))// 电话号码格式正确   
        return true;
    else //号码格式错误
        return false;
}

/***是否是数字***/
String.prototype.isNumeric = function(flag) {
    //验证是否是数字
    if (isNaN(this)) {
        return false;
    }
    switch (flag) {
        case null:        //数字
        case "":
            return true;
        case "+":        //正数
            return /(^\+?|^\d?)\d*\.?\d+$/.test(this);
        case "-":        //负数
            return /^-\d*\.?\d+$/.test(this);
        case "i":        //整数
            return /(^-?|^\+?|\d)\d+$/.test(this);
        case "+i":        //正整数
            return /(^\d+$)|(^\+?\d+$)/.test(this);
        case "-i":        //负整数
            return /^[-]\d+$/.test(this);
        case "f":        //浮点数
            return /(^-?|^\+?|^\d?)\d*\.\d+$/.test(this);
        case "+f":        //正浮点数
            return /(^\+?|^\d?)\d*\.\d+$/.test(this);
        case "-f":        //负浮点数
            return /^[-]\d*\.\d$/.test(this);
        default:        //缺省
            return true;
    }
}

/***清除所有的HTML代码***/
String.prototype.ClearHtml = function() {
    if (this != null) {
        return this.replace(/<.+?>/gm, '');
    }
}

/***rgb颜色转成#ffffff格式***/
String.prototype.RgbToHex = function() {
    if (this.indexOf('rgb') != -1) {
        aa = this.Trim();
        aa = aa.replace("rgb(", "")
        aa = aa.replace(")", "")
        aa = aa.split(",")
        r = parseInt(aa[0]);
        g = parseInt(aa[1]);
        b = parseInt(aa[2]);
        r = r.toString(16);
        if (r.length == 1) {
            r = '0' + r;
        }
        g = g.toString(16);
        if (g.length == 1) {
            g = '0' + g;
        }
        b = b.toString(16);
        if (b.length == 1) {
            b = '0' + b;
        }
        return ("#" + r + g + b).toUpperCase();
    }
    else {
        return this;
    }
}



/***把#转换为rgb***/

String.prototype.HexToRgb = function() {
    var a = this.Trim();
    if (a.substr(0, 1) == "#") a = a.substring(1);
    if (a.length == 6) {
        a = a.toLowerCase()
        b = new Array();
        for (x = 0; x < 3; x++) {
            b[0] = a.substr(x * 2, 2)
            b[3] = "0123456789abcdef"; b[1] = b[0].substr(0, 1)
            b[2] = b[0].substr(1, 1)
            b[20 + x] = b[3].indexOf(b[1]) * 16 + b[3].indexOf(b[2])
        }
        return b[20] + "," + b[21] + "," + b[22];
    } else {
        return "";
    }
}

/***转换为uft-8***/
String.prototype.GBtoUTF8 = function() {
    var wch, x, uch = "", szRet = "", szInput = this.Trim();
    for (x = 0; x < szInput.length; x++) {
        wch = szInput.charCodeAt(x);
        if (!(wch & 0xFF80)) {
            szRet += szInput.charAt(x);
        }
        else if (!(wch & 0xF000)) {
            uch = "%" + (wch >> 6 | 0xC0).toString(16) + "%" + (wch & 0x3F | 0x80).toString(16);
            szRet += uch;
        }
        else {
            uch = "%" + (wch >> 12 | 0xE0).toString(16) + "%" + (((wch >> 6) & 0x3F) | 0x80).toString(16) + "%" + (wch & 0x3F | 0x80).toString(16);
            szRet += uch;
        }
    }
    return (szRet);
}

/***转为全角。全部都占1个汉字位置***/
String.prototype.toCase = function() {
    var tmp = "";
    for (var i = 0; i < this.length; i++) {
        if (this.charCodeAt(i) > 0 && this.charCodeAt(i) < 255) {
            tmp += String.fromCharCode(this.charCodeAt(i) + 65248);
        }
        else {
            tmp += String.fromCharCode(this.charCodeAt(i));
        }
    }
    return tmp
}
/***是否是颜色(#FFFFFF形式)***/
String.prototype.IsColor = function() {
    var temp = this;
    if (temp == "") return true;
    if (temp.length != 7) return false;
    return (temp.search(/\#[a-fA-F0-9]{6}/) != -1);
}

/***是否是有效链接***/
String.prototype.isUrl = function() {
    var url = /^http:\/\/[A-Za-z0-9]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/;
    var tmpStr = this;
    return url.test(tmpStr);
}
/***只保留汉字***/
String.prototype.Chinese = function() {
    return (this.replace(/[^\u4E00-\u9FA5]/g, ''));
}

/*** 简单的email检查 ***/
String.prototype.isEmail = function() {
    return /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/.test(this);
}

/*** 检查是否有列表中的字符字符 ***/
String.prototype.isInList = function(list) {
    var re = eval("/[" + list + "]/");
    return re.test(this);
}

/// <summary>
/// 只能是数字
/// </summary>
/// <returns>如果是数字，返回真，否则返回假</returns>
String.prototype.IsDigit = function() {
    var reg = /^\d+$/g;
    return reg.test(this);
}
/// <summary>
/// 只能是数字
/// </summary>
/// <returns>返回数字</returns>
String.prototype.Digit = function() {
    return this.replace(/[^\d]/g, '')
}

/// <summary>
/// 去除左边的空格
/// </summary>
String.prototype.LTrim = function() {
    return this.replace(/(^\s*)/g, "");
}
/// <summary>
/// 去除右边的空格
/// </summary>
String.prototype.Rtrim = function() {
    return this.replace(/(\s*$)/g, "");
}
/// <summary>
/// 得到左边的字符串
/// </summary>

String.prototype.Left = function(len) {
    if (isNaN(len) || len == null) {
        len = this.length;
    }
    else {
        if (parseInt(len) < 0 || parseInt(len) > this.length) {
            len = this.length;
        }
    }
    return this.substr(0, len);
}
/// <summary>
/// 得到中间的字符串,注意从0开始
/// </summary>
String.prototype.Mid = function(start, len) {
    return this.substr(start, len);
}
/// <summary>
/// 得到右边的字符串
/// </summary>
String.prototype.Right = function(len) {

    if (isNaN(len) || len == null) {
        len = this.length;
    }
    else {
        if (parseInt(len) < 0 || parseInt(len) > this.length) {
            len = this.length;
        }
    }

    return this.substring(this.length - len, this.length);
}

/// <summary>
///是否是正确的长日期
/// </summary>
String.prototype.isLongDate = function() {
    var r = this.replace(/(^\s*)|(\s*$)/g, "").match(/^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2}) (\d{1,2}):(\d{1,2}):(\d{1,2})$/);
    if (r == null) {
        return false;
    }
    var d = new Date(r[1], r[3] - 1, r[4], r[5], r[6], r[7]);
    return (d.getFullYear() == r[1] && (d.getMonth() + 1) == r[3] && d.getDate() == r[4] && d.getHours() == r[5] && d.getMinutes() == r[6] && d.getSeconds() == r[7]);

}

/// <summary>
///是否是正确的短日期
/// </summary>
String.prototype.isShortDate = function() {
    var r = this.replace(/(^\s*)|(\s*$)/g, "").match(/^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/);
    if (r == null) {
        return false;
    }
    var d = new Date(r[1], r[3] - 1, r[4]);
    return (d.getFullYear() == r[1] && (d.getMonth() + 1) == r[3] && d.getDate() == r[4]);
}

/// <summary>
///是否是正确的日期
/// </summary>
String.prototype.isDate = function() {
    return this.isLongDate() || this.isShortDate();
}
/// <summary>
/// 是否是正确的IP地址
/// </summary>
String.prototype.isIP = function() {
    var reSpaceCheck = /^(\d+)\.(\d+)\.(\d+)\.(\d+)$/;
    if (reSpaceCheck.test(this)) {
        this.match(reSpaceCheck);
        if (RegExp.$1 <= 255 && RegExp.$1 >= 0
                 && RegExp.$2 <= 255 && RegExp.$2 >= 0
                 && RegExp.$3 <= 255 && RegExp.$3 >= 0
                 && RegExp.$4 <= 255 && RegExp.$4 >= 0) {
            return true;
        }
        else {
            return false;
        }
    }
    else {
        return false;
    }
}
/// <summary>
/// 只能是数字和字母
/// </summary>
/// <returns>如果是数字与字母，返回真，否则返回假</returns>
String.prototype.IsAlphaDigit = function() {
    var reg = /^[a-zA-Z0-9]+$/g;
    return reg.test(this);
}

String.prototype.AlphaDigit = function() {
    return this.replace(/[\W]/g, '');
}

/// <summary>
/// 只能是数字、字母与下划线
/// </summary>
/// <returns>如果是数字、字母与下划线，返回真，否则返回假</returns>
String.prototype.IsAlpha = function() {
    var reg = /^\w+$/g;
    return reg.test(this);
}

String.prototype.HTMLEncode = function() {
    var temp = document.createElement("div");
    (temp.textContent != null) ? (temp.textContent = this) : (temp.innerText = this);
    var output = temp.innerHTML;
    temp = null;
    return output;
}

String.prototype.HTMLDecode = function() {
    var temp = document.createElement("div");
    temp.innerHTML = this;
    var output = temp.innerText || temp.textContent;
    temp = null;
    return output;
}


/// <summary>
/// 获取浏览器类型
/// </summary>
/// <returns>返回浏览器名字</returns>
function getBrowserOS() {
    if (navigator.userAgent.indexOf('MSIE') > -1) return 'MSIE';
    if (navigator.userAgent.indexOf('Firefox') > -1) return 'Firefox';
    if (navigator.userAgent.indexOf("Chrome") > 0) return 'Chrome';
    if (navigator.userAgent.indexOf("Safari") > 0) return 'Safari';
    if (navigator.userAgent.indexOf("Camino") > 0) return 'Camino';
    if (navigator.userAgent.indexOf("Gecko/") > 0) return 'Gecko';
    if (navigator.userAgent.indexOf('Opera') > -1) return 'Opera';
    return 'Other';
}

function Input_Digit() {
    this.value = this.value.Digit();
}

function Input_Chinese() {
    this.value = this.value.Chinese();
}
function Input_AlphaDigit() {
    this.value = this.value.AlphaDigit();
}

/// <summary>
/// 限制input输入的类别  lx=0只能是汉字 1 为只能输入数字  2 只能输入数字和英文
/// </summary>
/// <returns>返回浏览器名字</returns>
function getInput(objname, lx) {
    var obj = document.getElementById(objname);
    if (obj != null && obj != undefined) {
        switch (lx) {
            case 0:
                {//只能输入汉字的限制
                    AttachEvent("keyup", obj, Input_Chinese);
                    break;
                }
            case 1:
                {//为只能输入数字
                    AttachEvent("keyup", obj, Input_Digit);
                    break;
                }
            case 2:
                {//只能输入数字和英文
                    AttachEvent("keyup", obj, Input_AlphaDigit);
                    break;
                }
        }
    }
}
/// <summary>
/// 通用的绑定用户事件
/// </summary>
function AttachEvent(type, target, handler) {
    var eventHandler = handler;
    eventHander = function() {
        handler.call(target);
    }
    if (window.document.all) {
        target.attachEvent("on" + type, eventHander);
    }
    else {
        if (type == "propertychange") { type = "input"; }
        target.addEventListener(type, eventHander, false);
    }
}


//c#中的StringBuffer类
function StringBuffer() {
    this.__strings__ = new Array;
}

StringBuffer.prototype.append = function(str) {
    this.__strings__.push(str);
}

StringBuffer.prototype.toString = function() {
    return this.__strings__.join("");
}

//获得图片大小
function getPageSize() {
    var xScroll, yScroll;
    if (window.innerHeight && window.scrollMaxY) {
        xScroll = document.body.scrollWidth;
        yScroll = window.innerHeight + window.scrollMaxY;
    } else if (document.body.scrollHeight > document.body.offsetHeight) { // all but Explorer Mac
        xScroll = document.body.scrollWidth;
        yScroll = document.body.scrollHeight;
    } else { // Explorer Mac...would also work in Explorer 6 Strict, Mozilla and Safari
        xScroll = document.body.offsetWidth;
        yScroll = document.body.offsetHeight;
    }

    var windowWidth, windowHeight;
    if (self.innerHeight) {  // all except Explorer
        windowWidth = self.innerWidth;
        windowHeight = self.innerHeight;
    } else if (document.documentElement && document.documentElement.clientHeight) { // Explorer 6 Strict Mode
        windowWidth = document.documentElement.clientWidth;
        windowHeight = document.documentElement.clientHeight;
    } else if (document.body) { // other Explorers
        windowWidth = document.body.clientWidth;
        windowHeight = document.body.clientHeight;
    }

    // for small pages with total height less then height of the viewport
    if (yScroll < windowHeight) {
        pageHeight = windowHeight;
    } else {
        pageHeight = yScroll;
    }

    if (xScroll < windowWidth) {
        pageWidth = windowWidth;
    } else {
        pageWidth = xScroll;
    }

    //arrayPageSize = new Array(pageWidth,pageHeight,windowWidth,windowHeight) 
    var str = navigator.userAgent;
    if (str.indexOf('MSIE') > -1 && str.indexOf("8.") > -1) {
        if (document.documentElement && document.documentElement.scrollTop) {
            pageHeight += document.documentElement.scrollTop;
        } else if (document.body) {
            pageHeight += document.body.scrollTop;
        }
    }
    return {
        pH: pageHeight,
        pW: pageWidth,
        wH: windowHeight,
        wW: windowWidth
    };
}

//删除一个标签
function userdelobj(objname) {
    var obj = document.getElementById(objname);
    if (obj != undefined) {
        obj.parentNode.removeChild(obj);
    }
    obj = null;
}
function $id(obj) {
    return document.getElementById(obj);
}
/*input选中内容*/
function getSelectedText(inputDom) {//inputDom,你的text的DOM
    inputDom = inputDom || document.getElementById(inputDom);
    var selectedText;
    //ie利用Range，这个和非文本框的是一样的!
    if (document.selection && (document.selection.type == "Text")) {
        selectedText = document.selection.createRange().text;
    }
    //ff、chrome，用getSelection
    else if ((inputDom.selectionStart || inputDom.selectionStart == 0) && inputDom.selectionEnd) {
        var start = inputDom.selectionStart;
        var end = inputDom.selectionEnd;
        selectedText = inputDom.value.substring(start, end);
    }
    return selectedText;
}
//开始和结果位置选定
function setCursorPosition(hTxt, oStart, oEnd) {
    oInput = hTxt || document.getElementById(hTxt);
    if (oInput.createTextRange) {
        var range = oInput.createTextRange();
        range.collapse(true);
        range.moveEnd('character', oEnd);
        range.moveStart('character', oStart);
        range.select();
    } else if (oInput.setSelectionRange) {
        oInput.setSelectionRange(oStart, oEnd);
    }
    f(oInput);
    oInput.focus();
}

//取文本框当前光标位置。包括选定时间。开始结束
function f(txb) {
    var s = savePos(txb);
    txb.selectionStartPoint = s.s;
    txb.selectionEndPoint = s.e;
    txb.selectionStartPointNoBr = s.s1;
    txb.selectionEndPointNoBr = s.e1;
    s = null;
    txb.oldscrollTop = txb.scrollTop; //获得滚动条的位置
    return { s: txb.selectionStartPoint, e: txb.selectionEndPoint, s1: txb.selectionStartPointNoBr, e1: txb.selectionEndPointNoBr };
}


function ClearEnterNum(oStext) {
    var re = new RegExp("[\\n]", "g"); //过滤掉换行符,不然你的文字会有问题,会比你的文字实际长度要长一些.搞死我了.我说我得到的数字怎么总比我的实际长度要长.
    oStext = oStext.replace(re, ""); //过滤
    return oStext.length; //获得长度.也就是光标的位置
}

function savePos(textBox) {
    //如果是Firefox(1.5)的话，方法很简单
    var start = 0;
    var end = 0;
    var start1 = 0;
    var end1 = 0;
    var gogo = true;
    if (textBox.value.length > 0) {
        if (textBox.type == "textarea") {
            var stype = "";
            try {
                if (typeof (textBox.selectionStart) == "number") {
                    stype = 1;
                }
            } catch (e) {
                stype = 0;
            }
            if (stype==1 && stype!=0) {
                start1 = start = textBox.selectionStart;
                end1 = end = textBox.selectionEnd;
            } //下面是IE(6.0)的方法，麻烦得很，还要计算上'\n'
            else if (document.selection) {
                var range = document.selection.createRange();
                if (range.parentElement().id == textBox.id) {
                    // create a selection of the whole textarea
                    var range_all = document.body.createTextRange();
                    range_all.moveToElementText(textBox);
                    var oSel = range.duplicate();
                    oSel.setEndPoint("StartToStart", range_all);
                    oStext = oSel.text;
                    var SelectText = range.text;
                    start = oStext.length - SelectText.length; //开始位置
                    end = oStext.length;                 //结束位置
                    var re = new RegExp("[\\n]", "g"); //过滤掉换行符,不然你的文字会有问题,会比你的文字实际长度要长一些.搞死我了.我说我得到的数字怎么总比我的实际长度要长.
                    oStext = oStext.replace(re, ""); //过滤
                    end1 = oStext.length; //获得长度.也就是光标的位置
                    SelectText = SelectText.replace(re, "");
                    pos1 = SelectText.length;
                    start1 = end1 - pos1;        //开始位置
                    re = null;
                    oSel = null;
                    SelectText = null;
                    range_all = null;
                } else {
                    gogo = false;
                }
                range = null;
            }
        } else if (textBox.type == "text") {
            if (window.getSelection) { //IE以外
                end1 = end = textBox.selectionEnd;
                start1 = start = textBox.selectionStart;
            } else {
                var svalue = textBox.createTextRange().text;
                var nlen = svalue.length;
                var oRang = document.selection.createRange();
                var nlenselect = oRang.text.length;
                var npos = oRang.moveStart("character", 1000);
                var nstart = nlen - npos;
                var nend = nstart + nlenselect;
                oRang = null;
                npos = null;
                end1 = end = nend;
                start1 = start = nstart;
            }
        }
    }
    if (gogo) {
        textBox.selectionStartPoint = start; 	//记录位置
        textBox.selectionEndPoint = end; 	//记录位置
        textBox.selectionStartPointNoBr = start1; 	//记录位置
        textBox.selectionEndPointNoBr = end1; 	//记录位置
    } else {
        start = textBox.selectionStartPoint; 	//记录位置
        end = textBox.selectionEndPoint; 	//记录位置
        start1 = textBox.selectionStartPointNoBr; 	//记录位置
        end1 = textBox.selectionEndPointNoBr; 	//记录位置
    }
    IECollectGarbage();
    return { s: start, e: end, s1: start1, e1: end1 };
}


//兼容IE和FIREFOX的在光标处插入文本
//function InsertAtCaret(textObj, value) {
//    var v = textObj.value;
//    if (textObj.selectionEndPoint == null && textObj.selectionStartPoint == null) {
//        v += value;
//    } else {
//        v = v.slice(0, textObj.selectionStartPoint) + value + v.slice(textObj.selectionEndPoint);
//    }
//    textObj.value = v;
//    if (getBrowserOS() == "MSIE") {
//        var re = new RegExp("[\\n]", "g"); //过滤掉换行符,不然你的文字会有问题,会比你的文字实际长度要长一些.搞死我了.我说我得到的数字怎么总比我的实际长度要长.
//        value = value.replace(re, ""); //过滤
//    }
//    re = null;
//    v = null;
//    setCursorPosition(textObj, textObj.selectionStartPointNoBr, textObj.selectionStartPointNoBr + value.length);
//}


// 在光标处插入字符串 
// myField 文本框对象 
// 要插入的值
function InsertAtCaret(myField, myValue, NoSelect) {
    //IE support
    if (myField.selectionStartPoint != null && myField.selectionEndPoint != null) {
        var startPos = myField.selectionStartPoint;
        var endPos = myField.selectionEndPoint;
        var restoreTop = myField.scrollTop;
        myField.value = myField.value.substring(0, startPos) + myValue + myField.value.substring(endPos, myField.value.length);
        if (restoreTop > 0) {
            myField.scrollTop = restoreTop;
        }
        startPos = null;
        endPos = null;
        restoreTop = null;
    } else {
        myField.value += myValue;
    }
    var AddNum = 0;
    if (getBrowserOS() != "MSIE") {
        //2012.6.8,修改。不知道为什么非IE在多于一个回车时出BUG，删除所有的又少一个。所以删除所有加1
        if (myValue.indexOf("\n") != -1) {
            AddNum = 1;
        }
    }
    var re = new RegExp("[\\n]", "g"); //过滤掉换行符,不然你的文字会有问题,会比你的文字实际长度要长一些.搞死我了.我说我得到的数字怎么总比我的实际长度要长.
    myValue = myValue.replace(re, ""); //过滤
    re = null;
    var StrLength = myValue.length + AddNum;
    if (NoSelect || myValue.replace(/\t/g, "") == "") {
        setCursorPosition(myField, myField.selectionStartPointNoBr + StrLength, myField.selectionStartPointNoBr + StrLength);
    } else {
        setCursorPosition(myField, myField.selectionStartPointNoBr, myField.selectionStartPointNoBr + StrLength);
    }
}


//禁止冒泡
function stopBubble(e) {
    //如果提供了事件对象，则这是一个非IE浏览器
    if (e && e.stopPropagation)
    //因此它支持W3C的stopPropagation()方法
        e.stopPropagation();
    else
    //否则，我们需要使用IE的方式来取消事件冒泡
        window.event.cancelBubble = true;
}


function getElCoordinate(e) {
    var t = e.offsetTop;
    var l = e.offsetLeft;
    var w = e.offsetWidth;
    var h = e.offsetHeight;
    while (e = e.offsetParent) {
        t += e.offsetTop;
        l += e.offsetLeft;
    };
    return {
        top: t,
        left: l,
        width: w,
        height: h,
        bottom: t + h,
        right: l + w
    }
}
function DrawImage(ImgD, iwidth, iheight) {
    //参数(图片,允许的宽度,允许的高度)
    var image = new Image();
    image.onload = function() {
        if (this.width > 0 && this.height > 0) {
            var PaddTop = 0;
            var PaddLeft = 0;
            var height = 0; width = 0;
            if (this.width / this.height >= iwidth / iheight) {
                if (this.width > iwidth) {
                    width = iwidth;
                    height = (this.height * iwidth) / this.width;
                } else {
                    width = this.width;
                    height = this.height;
                }
            }
            else {
                if (this.height > iheight) {
                    height = iheight;
                    width = (this.width * iheight) / this.height;
                } else {
                    width = this.width;
                    height = this.height;
                }
            }
            ImgD.width = width;
            ImgD.height = height;
            PaddTop = (iheight - height) / 2;
            PaddLeft = (iwidth - width) / 2;
            ImgD.style.paddingTop = PaddTop + "px";
            ImgD.style.paddingLeft = PaddLeft + "px";
            ImgD.style.paddingBottom = PaddTop + "px";
            ImgD.style.paddingRight = PaddLeft + "px";
            PaddTop = null;
            PaddLeft = null;
            height = null;
            width = null;
        }
        ImgD.style.display = "block";
    }
    image.onerror = function() {

    }
    image.src = ImgD.src;
    image = null;
}

function userinnerhtml(objname, objvalue) {
    var obj = document.getElementById(objname);
    if (obj != undefined) {
        obj.innerHTML = objvalue;
    }
    obj = null;
}
function getCursorPos(obj) {
    if (typeof document.selection != "undefined") {
        var rngSel = document.selection.createRange();
        var rngTxt = obj.createTextRange();
        var flag = rngSel.getBookmark();
        rngTxt.collapse();
        rngTxt.moveToBookmark(flag);
        rngTxt.moveStart("character", -obj.value.length);
        var str = rngTxt.text.replace(/\r\n/g, "");
        rngSel = null;
        rngTxt = null;
        flag = null;
        return (str.length);
    } else {
        return obj.selectionStart
    }
}
function fontLengthsize(obj, objname, znum, divw) {
    if (obj != undefined) {
        var intLength = 0;
        var fData = obj.value;
        intLength = fData.Lenb() / 2;
        if (intLength > znum) {
            var wz1 = getCursorPos(obj);
            obj.value = fData.MidStr(znum * 2);
            intLength = znum;
            setCursorPosition(obj, wz1, wz1);
            wz1 = null;
        }
        userinnerhtml(objname, "录入" + intLength + "(" + intLength * 2 + ")个。");
        var obj1 = document.getElementById("altdivfontsizeload");
        if (obj1 != null) {
            obj1.style.width = ((intLength / znum) * divw) + "px";
        }
        obj1 = null;
        intLength = null;
        fData = null;
    }
}
function AltDivF() {

}
function AltDivFC() {
    AltDiv(this, 0, null);
}
function AltDivFI() {
    fontLengthsize(this, "altdivfontsize", parseInt(this.znum), parseInt(this.divw));
}
function AltDiv(obj, objlx, objtitle, znum) {
    if (typeof (obj) == "string") {
        obj = $(obj).get(0);
    }
    if (obj != undefined) {
        var objalt = document.getElementById("altdiv");
        if (objlx == 0) {
            if (objalt != undefined) {
                document.body.removeChild(objalt);
            }
        } else if (objlx < 0) {
            obj.objlx = objlx;
            obj.objtitle = objtitle;
            obj.znum = znum;
            $(obj).bind("focus", function() {
                AltDiv(this, 10 + parseInt(this.objlx), this.objtitle, this.znum);
            }).bind("blur", function() {
                AltDiv(this, 0, null);
            });
        } else {
            var objh = 20;
            objalt = document.getElementById("altdiv");
            if (objalt == undefined) {
                objalt = document.createElement("DIV");
                objalt.id = "altdiv";
                document.body.appendChild(objalt);
                objalt.style.border = "1px #828282 solid";
                objalt.style.height = (objh * objlx) + "px";
                objalt.style.zIndex = 5000000;
                objalt.style.position = "absolute";
                objalt.style.backgroundColor = "#ffffff";
                objalt.style.padding = "4px 0px 0px 4px";
                objalt.style.color = "#000000";
                objalt.style.margin = "0";
            }
            var objfw = objtitle.Lenb() / 2 * 12.5;
            var objlt = getElCoordinate(obj);
            var objw = (objlt.width - 6);
            if (objw < objfw) {
                objw = objfw + 6;
            }
            var oBuffer = new StringBuffer();
            if (objlx == 2) {
                oBuffer.append("<div style=\"LEFT: 0px; WIDTH: " + objw + "px; POSITION: absolute; TOP: 0px; HEIGHT: " + (objh * objlx) + "px;z-index:55;\"><div style=\"margin:3px 0 0 3px;\">" + objtitle + "</div><div style=\"height:1px;background:#ff0000;clear:both;position:absolute;bottom:-4px;left:0;overflow: hidden;font-size:0px;\" id=\"altdivfontsizeload\"></div><div style=\"margin:2px;position:absolute;height:20px;top:20px;right:0;font-size:12px;color:#000000;\" id=\"altdivfontsize\" name=\"altdivfontsize\"></div></div></div>");
                oBuffer.append("<iframe style=\"LEFT: 0px; WIDTH: " + objw + "px; POSITION: absolute; TOP: 0px; HEIGHT: " + (objh * objlx) + "px;z-index:5;\" src=\"about:blank\" frameBorder=\"0\" scrolling=\"no\"></iframe>");
                obj.znum = znum;
                $(obj).bind("propertychange", function() {
                    fontLengthsize(this, "altdivfontsize", parseInt(this.znum), parseInt(this.divw));
                }).bind("input", function() {
                    fontLengthsize(this, "altdivfontsize", parseInt(this.znum), parseInt(this.divw));
                })
            } else {
                oBuffer.append(objtitle);
            }
            var str = navigator.userAgent;
            objalt.innerHTML = oBuffer.toString();
            obj.divw = (objw + 4);
            fontLengthsize(obj, "altdivfontsize", znum, (objw + 4));
            objalt.style.width = objw + "px";
            if (getBrowserOS() == "MSIE") {
                var objj = obj.getBoundingClientRect();
                if (document.documentElement && document.documentElement.scrollTop) {
                    objalt.style.left = objj.left + document.documentElement.scrollLeft + "px";
                    objalt.style.top = (objj.top + document.documentElement.scrollTop - (objh * objlx) - 6) + "px";
                } else if (document.body) {
                    objalt.style.left = objj.left + document.body.scrollLeft + "px";
                    objalt.style.top = (objj.top + document.body.scrollTop - (objh * objlx) - 6) + "px";
                }
            } else {
                objalt.style.left = objlt.left + "px";
                objalt.style.top = (objlt.top - (objh * objlx) - 6) + "px";
            }
            str = null;
            objfw = null;
            objlt = null;
            objw = null;
            oBuffer = null;
            objh = null;
            objalt.style.display = "block";
        }
        objalt = null;
    }
}

//写cookies函数
function SetCookie(name, value, cookieName)//两个参数，一个是cookie的名子，一个是值
{
    var Days = 30; //此 cookie 将被保存 30 天
    var exp = new Date();    //new Date("December 31, 9998");
    exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
    document.cookie = (cookieName ? cookieName + "=" : "") + name + "=" + escape(value) + ";path=/;expires=" + exp.toGMTString();
}
//取cookies函数
function getCookie(name, cookieName)//取cookies函数
{
    name = name.toLowerCase();
    var arr = document.cookie.split(";");
    var str = "";
    var isgoto = false;
    for (var i = 0; i < arr.length; i++) {
        var arr1 = arr[i].split("=");
        if (cookieName && arr1.length > 2) {
            var objbool = arr1[0].toLowerCase().Trim() == cookieName.toLowerCase();
            if (objbool) {
                arr[i] = arr[i].replace(arr1[0] + "=", "");
                var arr2 = arr[i].split("&");
                for (var i1 = 0; i1 < arr2.length; i1++) {
                    if (arr2[i1].indexOf(name + "=") != -1) {
                        str = unescape(arr2[i1].substr((name + "=").length));
                        isgoto = true;
                        break;
                    }
                }
                if (isgoto) {
                    break;
                }
            }
        } else if (arr1.length == 2) {
            if (arr1[0].toLowerCase().Trim() == name) {
                str = unescape(arr1[1]);
                break;
            }
        }
    }
    return str;
}
//删除cookie
function delCookie(name, cookieName)
{
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    var cval = getCookie(name);
    if (cval != null) document.cookie = (cookieName ? cookieName + "=" : "") + name + "=" + cval + ";path=/;expires=" + exp.toGMTString();
}
//复制到剪贴板
function copy2Clipboard(txt) {
    if (window.clipboardData) {
        if (window.clipboardData.clearData()) {
            window.clipboardData.setData("Text", txt);
        } else {
            try {
                Dialog.error("您的浏览器禁止脚本操作剪贴板。");
            } catch (e) {
                alert("您的浏览器禁止脚本操作剪贴板。");
            }
            return false;
        }
    }
    else if (navigator.userAgent.indexOf("Opera") != -1) {
        window.location = txt;
    }
    else if (window.netscape) {
        try {
            netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
        }
        catch (e) {
            try {
                Dialog.error("您的firefox安全限制限制您进行剪贴板操作，请打开’ about:config’ 将 signed.applets.codebase_principal_support’设置为 true’之后重试，相对路径为firefox根目录 /greprefs /all.js");
            } catch (e) {
                alert("您的firefox安全限制限制您进行剪贴板操作，请打开’ about:config’ 将 signed.applets.codebase_principal_support’设置为 true’之后重试，相对路径为firefox根目录 /greprefs /all.js");
            }
            return false;
        }
        var clip = Components.classes['@mozilla.org/widget/clipboard;1'].createInstance(Components.interfaces.nsIClipboard);
        if (!clip) return;
        var trans = Components.classes['@mozilla.org/widget/transferable;1'].createInstance(Components.interfaces.nsITransferable);
        if (!trans) return;
        trans.addDataFlavor('text/unicode');
        var str = new Object();
        var len = new Object();
        var str = Components.classes["@mozilla.org/supports-string;1"].createInstance(Components.interfaces.nsISupportsString);
        var copytext = txt; str.data = copytext;
        trans.setTransferData("text/unicode", str, copytext.length * 2);
        var clipid = Components.interfaces.nsIClipboard;
        if (!clip) return false;
        clip.setData(trans, null, clipid.kGlobalClipboard);

    }
    return true;
}
//添加到收藏
function addFavorites(title, urlname) {
    var url = "";
    if (urlname == null) {
        url = parent.location.href;
    }
    else {
        url = urlname;
    }
    if (window.sidebar) {
        window.sidebar.addPanel(title, url, "");
    }
    else if (document.all) {
        window.external.AddFavorite(url, title);
    }
    else if (window.opera && window.print) {
        return true;
    }
}
//IE释放内容
function IECollectGarbage() {
    if (isIE) {
        setTimeout(CollectGarbage, 2);
    }
}
function HTMLEnCode(str) {
    var s = "";
    if (str.length == 0) return "";
    s = str.replace(/&/g, "&gt;");
    s = s.replace(/</g, "&lt;");
    s = s.replace(/>/g, "&gt;");
    s = s.replace(/ /g, "&nbsp;");
    s = s.replace(/\'/g, "&#39;");
    s = s.replace(/\"/g, "&quot;");
    s = s.replace(/\n/g, "<br>");
    return s;
}
function HTMLDeCode(str) {
    var s = "";
    if (str.length == 0) return "";
    s = str.replace(/&gt;/g, "&");
    s = s.replace(/&lt;/g, "<");
    s = s.replace(/&gt;/g, ">");
    s = s.replace(/&nbsp;/g, " ");
    s = s.replace(/&#39;/g, "\'");
    s = s.replace(/&quot;/g, "\"");
    s = s.replace(/<br>/g, "\n");
    return s;
}