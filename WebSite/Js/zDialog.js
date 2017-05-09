var IMAGESPATH = 'images/dialog/'; //图片路径配置
var isIE = navigator.userAgent.indexOf('MSIE') != -1;
var isIE6 = navigator.userAgent.indexOf('MSIE 6.0') != -1;
var isIE8 = !!window.XDomainRequest && !!document.documentMode;

//缓存窗口的大小信息
var doc = window.document;
var Dialog_cw = doc.compatMode == "BackCompat" ? doc.body.clientWidth : doc.documentElement.clientWidth;
var Dialog_ch = doc.compatMode == "BackCompat" ? doc.body.clientHeight : doc.documentElement.clientHeight;
var Dialog_sl = Math.max(doc.documentElement.scrollLeft, doc.body.scrollLeft);
var Dialog_st = Math.max(doc.documentElement.scrollTop, doc.body.scrollTop); //考虑滚动的情况
var Dialog_sw = Math.max(doc.documentElement.scrollWidth, doc.body.scrollWidth);
var Dialog_sh = Math.max(doc.documentElement.scrollHeight, doc.body.scrollHeight); //考虑滚动的情况
var Dialog_w = Math.max(Dialog_sw, Dialog_cw); //取scrollWidth和clientWidth中的最大值
var Dialog_h = Math.max(Dialog_sh, Dialog_ch); //IE下在页面内容很少时存在scrollHeight<clientHeight的情况


if(isIE)
	try{ document.execCommand('BackgroundImageCache',false,true); }catch(e){}

var $id = function (id) {
    return typeof id == "string" ? document.getElementById(id) : id;
};
//if (!$) var $ = $id;

Array.prototype.remove = function (s, dust) { //如果dust为ture，则返回被删除的元素
    if (dust) {
        var dustArr = [];
        for (var i = 0; i < this.length; i++) {
            if (s == this[i]) {
                dustArr.push(this.splice(i, 1)[0]);
            }
        }
        return dustArr;
    }
    for (var i = 0; i < this.length; i++) {
        if (s == this[i]) {
            this.splice(i, 1);
        }
    }
    return this;
}

var $topWindow = function () {
    var parentWin = window;
    while (parentWin != parentWin.parent) {
        if (parentWin.parent.document.getElementsByTagName("FRAMESET").length > 0) break;
        parentWin = parentWin.parent;
    }
    return parentWin;
};
var $bodyDimensions = function (win) {
    if (win) {
        var doc = win.document;
        var cw = doc.compatMode == "BackCompat" ? doc.body.clientWidth : doc.documentElement.clientWidth;
        var ch = doc.compatMode == "BackCompat" ? doc.body.clientHeight : doc.documentElement.clientHeight;
        var sl = Math.max(doc.documentElement.scrollLeft, doc.body.scrollLeft);
        var st = Math.max(doc.documentElement.scrollTop, doc.body.scrollTop); //考虑滚动的情况
        var sw = Math.max(doc.documentElement.scrollWidth, doc.body.scrollWidth);
        var sh = Math.max(doc.documentElement.scrollHeight, doc.body.scrollHeight); //考虑滚动的情况
        var w = Math.max(sw, cw); //取scrollWidth和clientWidth中的最大值
        var h = Math.max(sh, ch); //IE下在页面内容很少时存在scrollHeight<clientHeight的情况
        return {
            "clientWidth": cw,
            "clientHeight": ch,
            "scrollLeft": sl,
            "scrollTop": st,
            "scrollWidth": sw,
            "scrollHeight": sh,
            "width": w,
            "height": h
        }
    } else {
        return {
            "clientWidth": Dialog_cw,
            "clientHeight": Dialog_ch,
            "scrollLeft": Dialog_sl,
            "scrollTop": Dialog_st,
            "scrollWidth": Dialog_sw,
            "scrollHeight": Dialog_sh,
            "width": Dialog_w,
            "height": Dialog_h
        }
    }
};

var fadeEffect = function(element, start, end, speed, callback){//透明度渐变：start:开始透明度 0-100；end:结束透明度 0-100；speed:速度1-100
	if(!element.effect)
		element.effect = {fade:0, move:0, size:0};
	clearInterval(element.effect.fade);
	var speed=speed||20;
	element.effect.fade = setInterval(function(){
		start = start < end ? Math.min(start + speed, end) : Math.max(start - speed, end);
		element.style.opacity =  start / 100;
		element.style.filter = "alpha(opacity=" + start + ")";
		if(start == end){
			clearInterval(element.effect.fade);
			if(callback)
				callback.call(element);
		}
	}, 20);
};

/*************************弹出框类实现****************************/
var topWin = $topWindow();
var topDoc = topWin.document;
var Dialog = function () {
    /****以下属性以大写开始，可以在调用show()方法前设置值****/
    this.ID = null;
    this.Width = null;
    this.Height = null;
    this.URL = null;
    this.URLOkFunction = null;
    this.OnLoad = null;
    this.InnerHtml = ""
    this.Icon = "icon_dialog.gif"
    this.InvokeElementId = ""
    this.Top = "50%";
    this.Left = "50%";
    this.Title = "";
    this.OKEvent = null; //点击确定后调用的方法
    this.CancelEvent = null; //点击取消及关闭后调用的方法
    this.ShowButtonRow = false;
    this.MessageIcon = "window.gif";
    this.MessageTitle = "";
    this.Message = "";
    this.ShowMessageRow = false;
    this.Modal = true;      //遮罩层
    this.ModalParent = null;      //遮罩层
    this.Drag = true;
    this.AutoClose = null;
    this.ShowCloseButton = true;
    this.ShowCancelButton = true;
    this.Animator = true;
    /****以下属性以小写开始，不要自行改变****/
    this.dialogDiv = null;
    this.bgDiv = null;
    this.parentWindow = null;
    this.innerFrame = null;
    this.innerFrameLoad = null;
    this.innerWin = null;
    this.innerDoc = null;
    this.zindex = 100;
    this.cancelButton = null;
    this.okButton = null;
    this.otherButton = new Array();

    if (arguments.length > 0 && typeof (arguments[0]) == "string") { //兼容旧写法
        this.ID = arguments[0];
    } else if (arguments.length > 0 && typeof (arguments[0]) == "object") {
        Dialog.setOptions(this, arguments[0])
    }
    if (!this.ID)
        this.ID = topWin.Dialog._Array.length + "";

};
Dialog._Array = [];
Dialog.bgDiv = null;
Dialog.setOptions = function (obj, optionsObj) {
    if (!optionsObj) return;
    for (var optionName in optionsObj) {
        obj[optionName] = optionsObj[optionName];
    }
};
Dialog.attachBehaviors = function () {
    $(window).bind("keydown", function (event) {
        Dialog.onKeyDown(event);
    });
    $(window).bind("resize", function (event) {
        Dialog.resetPosition(event);
    });
};
Dialog.prototype.attachBehaviors = function () {
    if (this.Drag && topWin.Drag) topWin.Drag.init(topWin.$id("_Draghandle_" + this.ID), topWin.$id("_DialogDiv_" + this.ID)); //注册拖拽方法
    if (!isIE && this.URL) { //非ie浏览器下在拖拽时用一个层遮住iframe，以免光标移入iframe失去拖拽响应
        var self = this;
        topWin.$id("_DialogDiv_" + this.ID).onDragStart = function () {
            topWin.$id("_Covering_" + self.ID).style.display = ""
        }
        topWin.$id("_DialogDiv_" + this.ID).onDragEnd = function () {
            topWin.$id("_Covering_" + self.ID).style.display = "none"
        }
    }
};
Dialog.prototype.displacePath = function () {
    if (this.URL.substr(0, 7) == "http://" || this.URL.substr(0, 1) == "/" || this.URL.substr(0, 11) == "javascript:" || this.URL.substr(0, 11) == "about:blank") {
        return this.URL;
    } else {
        var thisPath = this.URL;
        var locationPath = window.location.href;
        locationPath = locationPath.substring(0, locationPath.lastIndexOf('/'));
        while (thisPath.indexOf('../') >= 0) {
            thisPath = thisPath.substring(3);
            locationPath = locationPath.substring(0, locationPath.lastIndexOf('/'));
        }
        return locationPath + '/' + thisPath;
    }
};
Dialog.prototype.setPosition = function() {
    var bd = $bodyDimensions(topWin);
    var thisTop = this.Top,
        thisLeft = this.Left,
		thisdialogDiv = this.getDialogDiv();
    if (typeof this.Top == "string" && this.Top.substring(this.Top.length - 1, this.Top.length) == "%") {
        var percentT = this.Top.substring(0, this.Top.length - 1) * 0.01;
        thisTop = bd.clientHeight * percentT - thisdialogDiv.scrollHeight * percentT + bd.scrollTop;
    }
    if (typeof this.Left == "string" && this.Left.substring(this.Left.length - 1, this.Left.length) == "%") {
        var percentL = this.Left.substring(0, this.Left.length - 1) * 0.01;
        thisLeft = bd.clientWidth * percentL - thisdialogDiv.scrollWidth * percentL + bd.scrollLeft;
    }
    thisdialogDiv.style.top = Math.round(thisTop) + "px";
    thisdialogDiv.style.left = Math.round(thisLeft) + "px";
};
Dialog.setBgDivSize = function () {
    var bd = $bodyDimensions(topWin);
	if(Dialog.bgDiv){
	    if(Dialog.bgDiv.ModalParent!=null)
	    {
	        var S = getElCoordinate(Dialog.bgDiv.ModalParent);
            Dialog.bgDiv.style.width = S.width+"px";
            Dialog.bgDiv.style.height = S.height + "px";
            Dialog.bgDiv.style.top=S.top + "px";
            Dialog.bgDiv.style.left=S.left+ "px";
			if(isIE6){
				Dialog.bgDiv.childNodes[0].style.display = "none";//让div重渲染,修正IE6下尺寸bug
				Dialog.bgDiv.childNodes[0].style.display = "";
			}

        } else {
            Dialog.bgDiv.style.top = "0px";
            Dialog.bgDiv.style.left = "0px";
			if(isIE6){
			    Dialog.bgDiv.style.width = "100%";
				Dialog.bgDiv.style.height = bd.clientHeight + "px";
				Dialog.bgDiv.style.top=bd.scrollTop + "px";
				Dialog.bgDiv.childNodes[0].style.display = "none";//让div重渲染,修正IE6下尺寸bug
				Dialog.bgDiv.childNodes[0].style.display = "";
			}else{
			    Dialog.bgDiv.style.width = "100%";
				Dialog.bgDiv.style.height = bd.scrollHeight + "px";
			}
		}
	}
};
Dialog.resetPosition = function () {
    Dialog.setBgDivSize();
    for (var i = 0, len = topWin.Dialog._Array.length; i < len; i++) {
        topWin.Dialog._Array[i].setPosition();
    }
};
Dialog.prototype.create = function () {
    var bd = $bodyDimensions(topWin);
    if (typeof (this.OKEvent) == "function") this.ShowButtonRow = true;
    if (this.Width == 0 || !this.Width) {
        this.Width = "500";
    }
    if (this.Height == 0 || !this.Height) {
        this.Height = "500";
    }
    if (!this.Width) this.Width = Math.round(bd.clientWidth * 4 / 10);
    if (!this.Height) this.Height = Math.round(this.Width / 2);
    if (this.MessageTitle || this.Message) this.ShowMessageRow = true;
    var DialogDivWidth = this.Width + 13 + 13;
    var DialogDivHeight = this.Height + 33 + 13 + (this.ShowButtonRow ? 40 : 0) + (this.ShowMessageRow ? 50 : 0);

    if (DialogDivWidth > bd.clientWidth) this.Width = Math.round(bd.clientWidth - 26);
    if (DialogDivHeight > bd.clientHeight) this.Height = Math.round(bd.clientHeight - 46 - (this.ShowButtonRow ? 40 : 0) - (this.ShowMessageRow ? 50 : 0));

    var html = '\
  <table id="_DialogTable_' + this.ID + '" width="' + (this.Width + 26) + '" cellspacing="0" cellpadding="0" border="0" style="font-size:12px; line-height:1.4;">\
  ' + (function (obj) {
      if (obj.Title.length > 0 || obj.AutoClose != null) {
          return '<tr onselectstart="return false;" id="_Draghandle_' + obj.ID + '" style="-moz-user-select: none; ' + (obj.Drag ? "cursor: move;" : "") + '">\
      <td width="13" height="33" style="background-image: url(' + IMAGESPATH + 'dialog_lt.png) !important;background: url(' + IMAGESPATH + 'dialog_lt.gif) no-repeat 0 0;"><div style="width: 13px;"></div></td>\
      <td height="33" style="background-image:url(' + IMAGESPATH + 'dialog_ct.png) !important;background: url(' + IMAGESPATH + 'dialog_ct.gif) repeat-x top;"><div style="padding: 9px 0 0 4px; float: left; font-weight: bold; color:#fff;">' + (obj.Icon.length > 0 ? '<img align="absmiddle" src="' + IMAGESPATH + obj.Icon + '"/>' : "") + '<span id="_Title_' + obj.ID + '">' + obj.Title + '</span></div>\
        <div onclick="Dialog.getInstance(\'' + obj.ID + '\').cancelButton.onclick.apply(Dialog.getInstance(\'' + obj.ID + '\').cancelButton,[]);" onmouseout="this.style.backgroundImage=\'url(' + IMAGESPATH + 'dialog_closebtn.gif)\'" onmouseover="this.style.backgroundImage=\'url(' + IMAGESPATH + 'dialog_closebtn_over.gif)\'" style="margin: 4px 0 0; position: relative; cursor: pointer; float: right; height: 17px; width: 28px; background-image: url(' + IMAGESPATH + 'dialog_closebtn.gif);' + (obj.ShowCloseButton ? "" : "display:none;") + '"></div></td>\
      <td width="13" height="33" style="background-image: url(' + IMAGESPATH + 'dialog_rt.png) !important;background: url(' + IMAGESPATH + 'dialog_rt.gif) no-repeat right 0;"><div style="width: 13px;"><a id="_forTab_' + obj.ID + '" href="#;"></a></div></td>\
    </tr>';
      } else {
          return '<tr onselectstart="return false;" style="-moz-user-select: none; ">\
      <td width="13" height="13" style="background-image: url(' + IMAGESPATH + 'dialog_lb1.png) !important;background: url(' + IMAGESPATH + 'dialog_lb1.gif) no-repeat 0 bottom;"></td>\
      <td style="background-image: url(' + IMAGESPATH + 'dialog_cb1.png) !important;background: url(' + IMAGESPATH + 'dialog_cb1.gif) repeat-x bottom;"></td>\
      <td width="13" height="13" style="background-image: url(' + IMAGESPATH + 'dialog_rb1.png) !important;background: url(' + IMAGESPATH + 'dialog_rb1.gif) no-repeat right bottom;"><a onfocus=\'$id("_forTab_' + obj.ID + '").focus();\' href="#;"></a></td>\
    </tr>';
      }
  })(this) + '\
    <tr valign="top">\
      <td width="13" style="background-image: url(' + IMAGESPATH + 'dialog_mlm.png) !important;background: url(' + IMAGESPATH + 'dialog_mlm.gif) repeat-y left;"></td>\
      <td align="center"><table width="100%" cellspacing="0" cellpadding="0" border="0" bgcolor="#ffffff">\
          <tr id="_MessageRow_' + this.ID + '" style="' + (this.ShowMessageRow ? "" : "display:none") + '">\
            <td valign="top" height="50"><table width="100%" cellspacing="0" cellpadding="0" border="0" style="background:#eaece9 url(' + IMAGESPATH + 'dialog_bg.jpg) no-repeat scroll right top;" id="_MessageTable_' + this.ID + '">\
                <tr>\
                  <td width="50" height="50" align="center"><img width="32" height="32" src="' + IMAGESPATH + this.MessageIcon + '" id="_MessageIcon_' + this.ID + '"/></td>\
                  <td align="left" style="line-height: 16px;"><div id="_MessageTitle_' + this.ID + '" style="font-weight:bold">' + this.MessageTitle + '</div>\
                    <div id="_Message_' + this.ID + '" class=\"DialogContent\">' + this.Message + '</div></td>\
                </tr>\
              </table></td>\
          </tr>\
          <tr>\
            <td valign="top" align="center"><div id="_Container_' + this.ID + '" style="position: relative; width: ' + this.Width + 'px; height: ' + this.Height + 'px;overflow:hidden">\
                <div style="position: absolute; height: 100%; width: 100%; display: none; background-color:#fff; opacity: 0.5;" id="_Covering_' + this.ID + '">&nbsp;</div>\
	' + (function (obj) {
	    if (obj.InnerHtml) {
	        return obj.InnerHtml;
	    } else if (obj.URL) {
	        var str = '';
	        if (obj.URL.substr(0, 11) != "javascript:" && obj.URL.substr(0, 11) != "about:blank") {
	            if (obj.URL.indexOf("?") == -1) {
	                obj.URL += "?time=" + Math.random();
	            } else {
	                obj.URL += "&time=" + Math.random();
	            }
	        }
	        str += '<div style="width:' + obj.Width + 'px;height:' + obj.Height + 'px;overflow:hidden;position:relative;display:table-cell;text-align:center;vertical-align:middle;" id="_IframeView_' + obj.ID + '"><p style="position:static;+position:absolute;top:50%"><img src="' + IMAGESPATH + 'loading.gif" style="position:static;+position:relative;top:-50%;left:-50%;"><br>正在调入，请稍候...</p></div>';
	        if (isIE) {
	            str += '<iframe width="100%" height="100%" frameborder="0" style="border:none 0;display:none;" onreadystatechange="Dialog.getInstance(\'' + obj.ID + '\').IframeLoad();"';
	        } else {
	            str += '<iframe width="100%" height="100%" frameborder="0" style="border:none 0;" ';
	        }
	        str += ' id="_DialogFrame_' + obj.ID + '" src="' + obj.displacePath() + '"></iframe>';
	        return str;
	    } else {
	        return "";
	    }
	})(this) + '\
              </div></td>\
          </tr>\
          <tr id="_ButtonRow_' + this.ID + '" style="' + (this.ShowButtonRow ? "" : "display:none") + '">\
            <td height="36"><div id="_DialogButtons_' + this.ID + '" style="border-top: 1px solid #DADEE5; padding: 8px 20px; text-align: right; background-color:#f6f6f6;">\
                <input type="button" value="确 定" style="cursor:pointer;background-image:url(' + IMAGESPATH + 'dialog_b_out.png);width:69px;height:21px;border:0px;" id="_ButtonOK_' + this.ID + '"/>\
                ' + (function (obj) {
                    if (obj.ShowCancelButton) {
                        return '<input type="button" value="取 消" style="cursor:pointer;background-image:url(' + IMAGESPATH + 'dialog_b_out.png);width:69px;height:21px;border:0px;" onclick="Dialog.getInstance(\'' + obj.ID + '\').close();" id="_ButtonCancel_' + obj.ID + '"/>';
                    } else { return ""; }
                })(this) + '\
              </div></td>\
          </tr>\
        </table></td>\
      <td width="13" style="background-image: url(' + IMAGESPATH + 'dialog_mrm.png) !important;background: url(' + IMAGESPATH + 'dialog_mrm.gif) repeat-y right;"></td>\
    </tr>\
    <tr onselectstart="return false;" style="-moz-user-select: none; ">\
      <td width="13" height="13" style="background-image: url(' + IMAGESPATH + 'dialog_lb.png) !important;background: url(' + IMAGESPATH + 'dialog_lb.gif) no-repeat 0 bottom;"></td>\
      <td style="background-image: url(' + IMAGESPATH + 'dialog_cb.png) !important;background: url(' + IMAGESPATH + 'dialog_cb.gif) repeat-x bottom;"></td>\
      <td width="13" height="13" style="background-image: url(' + IMAGESPATH + 'dialog_rb.png) !important;background: url(' + IMAGESPATH + 'dialog_rb.gif) no-repeat right bottom;"><a onfocus=\'$id("_forTab_' + this.ID + '").focus();\' href="#;"></a></td>\
    </tr>\
  </table>\
</div>\
'
    var div = topWin.$id("_DialogDiv_" + this.ID);
    if (!div) {
        div = topDoc.createElement("div");
        div.id = "_DialogDiv_" + this.ID;
        topDoc.getElementsByTagName("BODY")[0].appendChild(div);
    }
    div.style.position = "absolute";
    div.style.left = "-9999px";
    div.style.top = "-9999px";
    div.innerHTML = html;
    if (this.InvokeElementId) {
        var element = $id(this.InvokeElementId);
        element.style.position = "";
        element.style.display = "";
        if (isIE) {
            var fragment = topDoc.createElement("div");
            fragment.innerHTML = element.outerHTML;
            element.outerHTML = "";
            topWin.$id("_Covering_" + this.ID).parentNode.appendChild(fragment)
        } else {
            topWin.$id("_Covering_" + this.ID).parentNode.appendChild(element)
        }
    }
    this.parentWindow = window;
    this.okButton = topWin.$id("_ButtonOK_" + this.ID);
    this.cancelButton = topWin.$id("_ButtonCancel_" + this.ID);
    if (this.URL) {
        this.okButton.disabled = "disabled";
        if (topWin.$id("_DialogFrame_" + this.ID)) {
            this.innerFrame = topWin.$id("_DialogFrame_" + this.ID);
            if (!isIE) {
                var ID = this.ID;
                this.innerFrame.addEventListener("load", function () {
                    Dialog.getInstance(ID).IframeLoad();
                }, false);
            }
        };
        if (topWin.$id("_IframeView_" + this.ID)) {
            this.innerFrameLoad = topWin.$id("_IframeView_" + this.ID);
        }
        var self = this;
        var selfI = 0;
        innerFrameOnload = function () {
            selfI++;
            try {
                self.innerWin = self.innerFrame.contentWindow;
                self.innerWin.parentDialog = self;
                self.innerDoc = self.innerWin.document;
                if (!self.Title && self.innerDoc && self.innerDoc.title) {
                    if (self.innerDoc.title) topWin.$id("_Title_" + self.ID).innerHTML = self.innerDoc.title;
                };
            } catch (e) {
                if (console && console.log) console.log("可能存在访问限制，不能获取到iframe中的对象。")
            }
            if (typeof (self.OnLoad) == "function" && selfI <= 30) self.OnLoad();
        };
        if (this.innerFrame.attachEvent) {
            this.innerFrame.attachEvent("onload", innerFrameOnload);
        } else {
            this.innerFrame.onload = innerFrameOnload;
        };
    };
    topWin.$id("_DialogDiv_" + this.ID).dialogId = this.ID;
    topWin.$id("_DialogDiv_" + this.ID).dialogInstance = this;
    this.attachBehaviors();
    div = null;
};
Dialog.prototype.setSize = function (w, h) {
    if (w && +w > 20) {
        this.Width = +w;
        topWin.$id("_DialogTable_" + this.ID).width = this.Width + 26;
        topWin.$id("_Container_" + this.ID).style.width = this.Width + "px";
    }
    if (h && +h > 10) {
        this.Height = +h;
        topWin.$id("_Container_" + this.ID).style.height = this.Height + "px";
    }
    this.setPosition();
};
Dialog.prototype.IframeLoad = function () {
    divL = topWin.$id("_IframeView_" + this.ID);
    IframeL = topWin.$id("_DialogFrame_" + this.ID);
    if (isIE) {
        var state = IframeL.readyState;
        if (state == "complete" || state == "interactive") {
            divL.style.display = "none";
            IframeL.style.display = "";
            topWin.$id("_ButtonOK_" + this.ID).disabled = "";
            if (this.URLOkFunction) {
                this.URLOkFunction();
            }
        }
    } else {
        divL.style.display = "none";
        IframeL.style.display = "";
        topWin.$id("_ButtonOK_" + this.ID).disabled = "";
        if (this.URLOkFunction) {
            this.URLOkFunction();
        }
    }
}
Dialog.prototype.show = function () {
    this.create();
    var bgdiv = Dialog.getBgdiv(),
		thisdialogDiv = this.getDialogDiv();
    this.zindex = thisdialogDiv.style.zIndex = parseInt(Dialog.bgDiv.style.zIndex) + 1;
    if (topWin.Dialog._Array.length > 0) {
        this.zindex = thisdialogDiv.style.zIndex = parseInt(topWin.Dialog._Array[topWin.Dialog._Array.length - 1].zindex) + 2;
    } else {
        var topWinBody = topDoc.getElementsByTagName(topDoc.compatMode == "BackCompat" ? "BODY" : "HTML")[0];
        topWinBody.styleOverflow = topWinBody.style.overflow;
        topWinBody.style.overflow = "hidden";
        bgdiv.style.display = "none";
    }
    topWin.Dialog._Array.push(this);
    if (this.Modal) {
        bgdiv.ModalParent = this.ModalParent;
        bgdiv.style.zIndex = parseInt(topWin.Dialog._Array[topWin.Dialog._Array.length - 1].zindex) - 1;
        Dialog.setBgDivSize();
        if (bgdiv.style.display == "none") {
            if (this.Animator) {
                var bgMask = topWin.$id("_DialogBGMask");
                bgMask.style.opacity = 0;
                bgMask.style.filter = "alpha(opacity=0)";
                bgdiv.style.display = "";
                fadeEffect(bgMask, 0, 40, isIE6 ? 20 : 10);
                bgMask = null;
            } else {
                bgdiv.style.display = "";
            }
        }
    }
    this.setPosition();
    if (this.CancelEvent) {
        this.cancelButton.onclick = this.CancelEvent;
        if (this.ShowButtonRow) this.cancelButton.focus();
    }
    if (this.OKEvent) {
        this.okButton.onclick = this.OKEvent;
        if (this.ShowButtonRow) this.okButton.focus();
    }
    var OKButton = this.okButton;
    if (this.InnerHtml.length > 0) {
        if (this.InnerHtml.indexOf("<iframe") != -1) {
            var JianNum = 0;
            var IframeList = $("#_Container_" + this.ID).find("iframe").each(function () {
                var obj = $(this);
                if (obj.attr("bsrc")) {
                    obj.attr("src", obj.attr("bsrc"));
                    obj.attr("bsrc", "");
                } else {
                    JianNum++;
                }
            });
            var IframeI = 0;
            if ((IframeList.length - JianNum) > 0) {
                $(OKButton).attr("disabled", "disabled");
                IframeList.bind("load", function () {
                    if ($(this).attr("bsrc") == "") {
                        IframeI++;
                        if (IframeI == (IframeList.length - JianNum)) {
                            setTimeout(function () { $(OKButton).removeAttr("disabled") }, 500);
                        }
                    }
                })
            }
        }
    }
    if (this.AutoClose && this.AutoClose > 0) {
        this.autoClose();
    }
    this.opened = true;
    // $(topWin.$id("_ButtonRow_" + this.ID)).btnForMat();
    $(topWin.$id("_Message_" + this.ID)).btnForMat();       //格式化提示信息
    $(topWin.$id("_Container_" + this.ID)).btnForMat().inputForMat(); //格式化显示的信息
    if (HelpView) {
        $(topWin.$id("_Container_" + this.ID)).find(".jTip").JT_init();
    }
    bgdiv = null;
};
Dialog.prototype.close = function () {
    var thisdialogDiv = this.getDialogDiv();
    var isTopDialog = null;
    if (this == topWin.Dialog._Array[topWin.Dialog._Array.length - 1]) {
        isTopDialog = topWin.Dialog._Array.pop();
    } else {
        topWin.Dialog._Array.remove(this);
    }
    if (this.InvokeElementId) {
        var innerElement = topWin.$id(this.InvokeElementId);
        innerElement.style.display = "none";
        if (isIE) {
            //ie下不能跨窗口拷贝元素，只能跨窗口拷贝html代码
            var fragment = document.createElement("div");
            fragment.innerHTML = innerElement.outerHTML;
            innerElement.outerHTML = "";
            document.getElementsByTagName("BODY")[0].appendChild(fragment)
        } else {
            document.getElementsByTagName("BODY")[0].appendChild(innerElement)
        }
    }
    var $Obj = $(thisdialogDiv);
    var InputID = $Obj.find("input[id$='___Config']");
    if (InputID.length > 0) {
        InputID.each(function () {
            var CkName = this.id;
            CkName = CkName.replace("___Config", "");
            var instance1 = CKEDITOR.instances[CkName];
            if (instance1) {
                CKEDITOR.remove(instance1);
            }
            $("div.cke_editor_" + CkName + "_dialog").remove();
        });
    }
    $Obj.find("textarea").unbind().remove();
    $Obj.find("select").unbind().remove();
    $Obj.find("iframe").unbind().remove();
    if (topWin.Dialog._Array.length > 0) {
        if (this.Modal && isTopDialog) Dialog.bgDiv.style.zIndex = parseInt(topWin.Dialog._Array[topWin.Dialog._Array.length - 1].zindex) - 1;
    } else {
        Dialog.bgDiv.style.zIndex = "100";
        Dialog.bgDiv.style.display = "none";
        var topWinBody = topDoc.getElementsByTagName(topDoc.compatMode == "BackCompat" ? "BODY" : "HTML")[0];
        if (topWinBody.styleOverflow != undefined) topWinBody.style.overflow = topWinBody.styleOverflow;
    }
    if (isIE) {
        /*****释放引用，以便浏览器回收内存**/
        if (thisdialogDiv) {
            thisdialogDiv.dialogInstance = null;
        }
        if (this.innerFrame) this.innerFrame.detachEvent("onload", innerFrameOnload);
        this.innerFrame = null;
        this.parentWindow = null;
        this.bgDiv = null;
        if (this.CancelEvent) { this.cancelButton.onclick = null; };
        if (this.OKEvent) { this.okButton.onclick = null; };
        try {
            topWin.$id("_DialogDiv_" + this.ID).onDragStart = null;
        } catch (e)
		{ }
        try {
            topWin.$id("_DialogDiv_" + this.ID).onDragEnd = null;
        } catch (e)
		{ }
        try {
            topWin.$id("_Draghandle_" + this.ID).onmousedown = null;
        } catch (e)
		{ }
        try {
            topWin.$id("_Draghandle_" + this.ID).root = null;
        } catch (e)
		{ }
        /**end释放引用**/
        if (thisdialogDiv) {
            thisdialogDiv.outerHTML = "";
        }
        IECollectGarbage();
    } else {
        var RycDiv = topWin.$id("_RycDiv");
        if (!RycDiv) {
            RycDiv = topDoc.createElement("div");
            RycDiv.id = "_RycDiv";
        }
        RycDiv.appendChild(thisdialogDiv);
        RycDiv.innerHTML = "";
        RycDiv = null;
    }
    $(".JT").remove();
    $("#altdiv").remove();
    $("#userblogcolor").remove();
    thisdialogDiv = null;
    $Obj.remove();
    this.closed = true;
};
Dialog.prototype.autoClose = function () {
    if (this.closed) {
        clearTimeout(this._closeTimeoutId);
        return;
    }
    this.AutoClose -= 1;
    var _TitleID = topWin.$id("_Title_" + this.ID);
    if (_TitleID) {
        _TitleID.innerHTML = this.AutoClose + " 秒后自动关闭";
    }
    if (this.AutoClose <= 0) {
        this.close();
    } else {
        var self = this;
        this._closeTimeoutId = setTimeout(function () {
            self.autoClose();
        },
        1000);
    }
};
Dialog.getInstance = function (id) {
    var dialogDiv = topWin.$id("_DialogDiv_" + id);
    if (dialogDiv)   //alert("没有取到对应ID的弹出框页面对象");
    {
        dialogDiv.dialogInstance.ID = id;
        return dialogDiv.dialogInstance;
    } else {
        dialogDiv = null;
    }
};
Dialog.prototype.addButton = function (id, txt, func) {
    topWin.$id("_ButtonRow_" + this.ID).style.display = "";
    var OKButton = this.okButton;
    this.ShowButtonRow = true;
    var button = topDoc.createElement("input");
    button.id = "_Button_" + this.ID + "_" + id;
    button.type = "button";
    button.style.cssText = "cursor:pointer;margin-right:5px;background-image:url(" + IMAGESPATH + "dialog_b_out.png);width:69px;height:21px;border:0px;";
    button.value = txt;
    button.onclick = function () {
        if ($(OKButton).attr("disabled") != "disabled") {
            func();
        }
    };
    this.otherButton.push(button);
    var input0 = topWin.$id("_DialogButtons_" + this.ID).getElementsByTagName("INPUT")[0];
    input0.parentNode.insertBefore(button, input0);
    return button;
};
Dialog.prototype.removeButton = function (btn) {
    var input0 = topWin.$id("_DialogButtons_" + this.ID).getElementsByTagName("INPUT")[0];
    input0.parentNode.removeChild(btn);
};
Dialog.getBgdiv = function () {
    if (Dialog.bgDiv) return Dialog.bgDiv;
    var bgdiv = topWin.$id("_DialogBGDiv");
    if (!bgdiv) {
        bgdiv = topDoc.createElement("div");
        bgdiv.id = "_DialogBGDiv";
        bgdiv.style.cssText = "position:absolute;left:0px;top:0px;width:100%;height:100%;z-index:100";
        var bgIframeBox = '<div style="position:relative;width:100%;height:100%;">';
		var bgIframeMask = '<div id="_DialogBGMask" style="position:absolute;background-color:#333;opacity:0.4;filter:alpha(opacity=40);width:100%;height:100%;"></div>';
		var bgIframe = isIE6?'<iframe src="about:blank" style="filter:alpha(opacity=0);" width="100%" height="100%"></iframe>':'';
		bgdiv.innerHTML=bgIframeBox+bgIframeMask+bgIframe+'</div>';
        topDoc.getElementsByTagName("BODY")[0].appendChild(bgdiv);
        if (isIE6) {
            var bgIframeDoc = bgdiv.getElementsByTagName("IFRAME")[0].contentWindow.document;
            bgIframeDoc.open();
            bgIframeDoc.write("<body style='background-color:#333' oncontextmenu='return false;'></body>");
            bgIframeDoc.close();
			bgIframeDoc=null;
        }
    }
    Dialog.bgDiv = bgdiv;
	bgdiv=null;
    return Dialog.bgDiv;
};
Dialog.prototype.getDialogDiv = function () {
	var dialogDiv=topWin.$id("_DialogDiv_" + this.ID)
	//if(!dialogDiv)alert("获取弹出层页面对象出错！");
	try{
		return dialogDiv;
	}catch(e){
		dialogDiv = null;
	}
};
Dialog.onKeyDown = function (event) {
    if (event.shiftKey && event.keyCode == 9) { //shift键
        if (topWin.Dialog._Array.length > 0) {
            stopEvent(event);
            return false;
        }
    } else if (event.ctrlKey && (event.keyCode == 83 || event.keyCode == 115)) {
        event.preventDefault();
        Dialog.save();
        return false;
    } else if (event.keyCode == 27) { //ESC键
        Dialog.close();
    }
};
Dialog.save = function (id) {
    if (topWin.Dialog._Array.length > 0) {
        var diag = topWin.Dialog._Array[topWin.Dialog._Array.length - 1];
        if (diag.AutoClose == null && diag.Title.length > 0) {
            diag.okButton.onclick.apply(diag.okButton, []);
        }
    }
};
Dialog.close = function (id) {
    if (topWin.Dialog._Array.length > 0) {
        var diag = topWin.Dialog._Array[topWin.Dialog._Array.length - 1];
        if (diag.AutoClose == null && diag.Title.length > 0) {
            diag.cancelButton.onclick.apply(diag.cancelButton, []);
        }
    }
};
Dialog.alert = function (msg, func, w, h, icon, title) {
    var w = w || 300,
        h = h || 110;
    var diag = new Dialog({
        Width: w,
        Height: h
    });
    diag.ShowButtonRow = true;
    diag.Title = title || "系统提示";
    diag.Icon = "";
    icon = icon || "icon_alert.png";
    diag.OKEvent = function () {
        if (func) func();
        diag.close();
    };
    diag.InnerHtml = '<table height="100%" border="0" align="center" width="100%" cellpadding="10" cellspacing="0">\
		<tr><td align="right" width="60"><img id="Icon_' + diag.ID + '" src="' + IMAGESPATH + icon + '" width="34" height="34" align="absmiddle"></td>\
			<td align="left" id="Message_' + diag.ID + '" class="DialogContent" style="font-size:9pt">' + msg + '</td></tr>\
	</table>';
    diag.show();
    diag.okButton.parentNode.style.textAlign = "center";
    diag.cancelButton.style.display = "none";
    diag.okButton.value = "确 定";
    diag.okButton.focus();
};
Dialog.error = function (msg, func, w, h) {
    var w = w || 300,
        h = h || 110;
    var diag = new Dialog({
        Width: w,
        Height: h
    });
    diag.ShowButtonRow = true;
    diag.Title = "错误提示";
    diag.OKEvent = function () {
        if (func) func();
        diag.close();
    };
    diag.InnerHtml = '<table height="100%" border="0" align="center" width="100%" cellpadding="10" cellspacing="0">\
		<tr><td align="right" width="60"><img id="Icon_' + diag.ID + '" src="' + IMAGESPATH + 'icon_error.png" width="32" height="32" align="absmiddle"></td>\
			<td align="left" id="Message_' + diag.ID + '" class="DialogContent" style="font-size:9pt">' + msg + '</td></tr>\
	</table>';
    diag.show();
    diag.okButton.parentNode.style.textAlign = "center";
    diag.cancelButton.style.display = "none";
    diag.okButton.value = "确 定";
    diag.okButton.focus();
};
Dialog.confirm = function(msg, funcOK, funcCal, w, h, OKtext, CalText, OtherButttion, OtherFun) {
    var w = w || 300,
        h = h || 110;
    var diag = new Dialog({
        Width: w,
        Height: h
    });
    diag.ShowButtonRow = true;
    diag.Title = "信息确认";
    diag.CancelEvent = function() {
        if (funcCal) {
            funcCal();
        }
        diag.close();
    };
    diag.OKEvent = function() {
        if (funcOK) {
            funcOK();
        }
        diag.close();
    };
    diag.InnerHtml = '<table height="100%" border="0" align="center" width="100%" cellpadding="10" cellspacing="0">\
		<tr><td align="right" width="60"><img id="Icon_' + diag.ID + '" src="' + IMAGESPATH + 'icon_query.png" width="32" height="32" align="absmiddle"></td>\
			<td align="left" id="Message_' + diag.ID + '" class="DialogContent" style="font-size:9pt">' + msg + '</td></tr>\
	</table>';
    diag.show();
    diag.okButton.parentNode.style.textAlign = "center";
    if (OKtext) {
        diag.okButton.value = OKtext;
    }
    if (CalText) {
        diag.cancelButton.value = CalText;
    }
    if (OtherButttion && OtherFun) {
        diag.addButton("next", OtherButttion, function() { OtherFun(diag); });
    }
    diag.okButton.focus();
};
Dialog.open = function (arg) {
    var diag = new Dialog(arg);
    diag.show();
    return diag;
};
if (isIE) {
    window.attachEvent("onload", Dialog.attachBehaviors);
} else {
    window.addEventListener("load", Dialog.attachBehaviors, false);
}