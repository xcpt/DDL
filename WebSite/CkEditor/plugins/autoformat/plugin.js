//ckeditor 自动排版插件
CKEDITOR.plugins.add("autoformat",
 	    {
 	        init: function (editor) {
 	            editor.addCommand('autoformat', {
 	                exec: function (e) {
 	                    FormatText(e);
 	                },
 	                canUndo: false
 	            });
 	            editor.ui.addButton('autoformat', {
 	                label: '自动排版【会清除一些样式格式，包含链接】',
 	                command: 'autoformat',
 	                icon: this.path + 'images/autoformat.gif'
 	            });
 	        }
 	    }
);

if (!document.all) {
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
//格式化
function FormatText(editor) {
    var myeditor = editor;
    if (myeditor.mode == "wysiwyg") {
        var tempimg = new Array();
        var temptable = new Array();
        var tempobject = new Array();

        var isPart = false; //暂时无法实现局部格式化
        if (!isPart) {
            var tmpDiv = document.createElement("DIV");
            var editorhtml = myeditor.getData();
            editorhtml = editorhtml.replace(/<div style="page-break-after: always;?">\s*<span style="display: none;?">&nbsp;<\/span>\s*<\/div>/gi, '<p>[page]</p>');
            tmpDiv.innerHTML = editorhtml.replace(/&nbsp;/gi, '').replace(/<div/gi, '<p').replace(/<\/div/gi, '</p');
            if (window.navigator.userAgent.toLowerCase().indexOf("msie") > 0) {
                tmpDiv.innerHTML = tmpDiv.innerHTML.replace(/<\/p>/gi, '<br /><\/p>')
            }
            var tables = tmpDiv.getElementsByTagName("TABLE");
            if (tables != null && tables.length > 0) {
                for (var j = 0; j < tables.length; j++) {
                    temptable[temptable.length] = tables[j].outerHTML;
                }
                var formattableCount = 0;
                for (var j = 0; j < tables.length;) {
                    tables[j].outerHTML = "#FormatTableID_" + formattableCount + "#";
                    formattableCount++;
                }
            }

            var objects = tmpDiv.getElementsByTagName("OBJECT");
            if (objects != null && objects.length > 0) {
                for (var j = 0; j < objects.length; j++) {
                    tempobject[tempobject.length] = objects[j].outerHTML;
                }
                var formatobjectCount = 0;
                for (var j = 0; j < objects.length;) {
                    objects[j].outerHTML = "#FormatObjectID_" + formatobjectCount + "#";
                    formatobjectCount++;
                }
            }

            var imgs = tmpDiv.getElementsByTagName("IMG");
            if (imgs != null && imgs.length > 0) {
                for (var j = 0; j < imgs.length; j++) {
                    var t = document.createElement("IMG");
                    t.alt = imgs[j].alt;
                    t.src = imgs[j].src;
                    t.width = imgs[j].width;
                    t.height = imgs[j].height;
                    t.align = imgs[j].align;
                    tempimg[tempimg.length] = t;
                }
                var formatImgCount = 0;
                for (var j = 0; j < imgs.length;) {
                    imgs[j].outerHTML = "#FormatImgID_" + formatImgCount + "#";
                    formatImgCount++;
                }
            }

            var strongarray = new Array();
            var strongcount = 0;
            var bs = tmpDiv.getElementsByTagName('b');
            if (bs != null && bs.length > 0) {
                for (var i = 0; i < bs.length; i++) {
                    strongarray[strongcount] = bs[i].innerText.Trim();
                    bs[i].innerHTML = "#FormatStrongID_" + strongcount + "#";
                    strongcount++;
                }
            }
            var strongs = tmpDiv.getElementsByTagName('strong');
            if (strongs != null && strongs.length > 0) {
                for (var i = 0; i < strongs.length; i++) {
                    strongarray[strongcount] = strongs[i].innerText.Trim();
                    strongs[i].innerHTML = "#FormatStrongID_" + strongcount + "#";
                    strongcount++;
                }
            }
            var html = processFormatText(tmpDiv.innerText);
            html = html.replace(/<p style="text-indent: 2em;">\[page\]<\/p>/gi, '<div style="page-break-after: always;"><span style="display: none;">&nbsp;</span></div>');
            if (temptable != null && temptable.length > 0) {
                for (var j = 0; j < temptable.length; j++) {
                    var tablehtml = temptable[j];
                    html = html.replace("#FormatTableID_" + j + "#", tablehtml);
                }
            }

            if (tempobject != null && tempobject.length > 0) {
                for (var j = 0; j < tempobject.length; j++) {
                    var objecthtml = "<p align=\"center\">" + tempobject[j] + "</p>";
                    html = html.replace("#FormatObjectID_" + j + "#", objecthtml);
                }
            }

            if (tempimg != null && tempimg.length > 0) {
                for (var j = 0; j < tempimg.length; j++) {
                    var imgheight = "";
                    var imgwidth = "";
                    if (tempimg[j].height != 0)
                        imaheight = " height=\"" + tempimg[j].height + "\"";
                    if (tempimg[j].width != 0)
                        imgwidth = " width=\"" + tempimg[j].width + "\"";
                    var imgalign = "";
                    if (tempimg[j].align != "")
                        imgalign = " align=\"" + tempimg[j].align + "\"";
                    var imghtml = "<p align=\"center\"><img src=\"" + tempimg[j].src + "\" alt=\"" + tempimg[j].alt + "\"" + imgwidth + " " + imgheight + " align=\"" + tempimg[j].align + "\" border=\"0\"></p>";
                    html = html.replace("#FormatImgID_" + j + "#", imghtml);
                }
            }

            for (var i = 0; i < strongcount; i++) {
                html = html.replace("#FormatStrongID_" + i + "#", "<p><strong>" + strongarray[i] + "</strong></p>");
            }
            while (html.indexOf("</p></p>") != -1) html = html.replace("</p></p>", "</p>");
            while (html.indexOf('<p><p align="center">') != -1) html = html.replace('<p><p align="center">', '<p align="center">');
            myeditor.setData(html);
        }
    }
}

function processFormatText(textContext) {
    var text = DBC2SBC(textContext);
    var prefix = "";
    var tmps = text.split("\n");
    var html = "";
    for (var i = 0; i < tmps.length; i++) {
        var tmp = tmps[i].Trim();
        if (tmp.length > 0) {
            var reg = /#Format[A-Za-z]+_\d+#/gi;
            var f = reg.exec(tmp);
            if (f != null) {
                tmp = tmp.replace(/#Format[A-Za-z]+_\d+#/gi, '');
                html += f;
                if (tmp != "")
                    html += "<p align=\"center\">" + tmp + "</p>\n"
            } else {
                html += "<p style=\"text-indent: 2em;\">" + tmp + "</p>\n";
            }
        }
    }
    return html;
};

function DBC2SBC(str) {
    var result = '';
    for (var i = 0; i < str.length; i++) {
        var code = str.charCodeAt(i);
        // “65281”是“！”，“65373”是“｝”，“65292”是“，”。不转换"，"

        if (code >= 65281 && code < 65373 && code != 65292 && code != 65306) {
            //  “65248”是转换码距
            result += String.fromCharCode(str.charCodeAt(i) - 65248);
        } else {
            result += str.charAt(i);
        }
    }
    return result;
};