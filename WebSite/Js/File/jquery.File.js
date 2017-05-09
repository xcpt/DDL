///读取地址
function SyCmsFileManage(Url, Listid, ListType, IsStyle, UploadPath, cookies, SelectOk, IsNum, IsAdd, IsModi, IsDel, FileExt, FileSize, syscutpic) {
    $('#SyCms_fileTree').children().remove();
    $('#SyCms_fileGrid').children().remove();
    $('#SyCms_fileTree').fileTree({ root: '', script: Url + '&IsType=0' }, function (file) {
        SyCmsFileList(Url, escape(file.path), SelectOk, IsNum, IsAdd, IsModi, IsDel);
        SyCmsFilePathView(file.path);
        SycmsFileInfo(file, 0);
    });
    SyCmsFileList(Url, "", SelectOk, IsNum, IsAdd, IsModi, IsDel);
    if (IsAdd == "1") {
        $("#folder_add").unbind().bind("click", function () {
            SycmsFileAddDir(Url, SelectOk, IsNum, IsAdd, IsModi, IsDel);
        });
        $("#file_upload").unbind().bind("click", function () {
            SycmsFileFileUpload(Url, null, Listid, ListType, IsStyle, UploadPath, cookies, SelectOk, IsNum, IsAdd, IsModi, IsDel, "上传文件", FileExt, FileSize, syscutpic);
        });
    }
    if (IsDel == "1") {
        $("#SyCms_fileTree").delegate("span.deldir", "click", function (e) {
            var obj = $(this);
            var Path = obj.attr("rel");
            var DirName = obj.attr("relname");
            Dialog.confirm("确定删除[" + Path + "]目录下的[" + DirName + "]目录吗？", function () {
                AjaxFun(Url, "action=del&Dir=" + Path + "&DirName=" + DirName, "正在提交删除", function () {
                    var yPath = $("#FullPathView").html();
                    $("#FullPathView").html("/" + Path);
                    if (Path == "") {
                        setTimeout(function () { SyCmsFileManage(Url); }, (ErrViewTime - 1) * 1000);
                    } else {
                        setTimeout(function () {
                            $("#SyCms_fileTree").fileTree.reload("/" + Path, false);
                            if (yPath == "/" + Path + DirName + "/") {
                                SyCmsFileList(Url, Path, SelectOk, IsNum, IsAdd, IsModi, IsDel);
                            }
                        }, (ErrViewTime - 1) * 1000);
                    }
                });
            });
        });
    }
}
///
///IsType0为随机文件名，1为原文件名
function SycmsFileFileUpload(Url, OkFunction, Listid, ListType, IsStyle, UploadPath, cookies, SelectOk, IsNum, IsAdd, IsModi, IsDel, Title, FileExt, FileSize, syscutpic) {
    var Path = $("#FullPathView").html();
    if (Path == "/") {
        Path = "";
    }
    var ScOkFunction_1 = function (Sc, index, count)
    {
        if (OkFunction) {
            OkFunction(Sc);
        } else if (Url) {
            if (index >= count) {
                SyCmsFileList(Url, Path, SelectOk, IsNum, IsAdd, IsModi, IsDel);
            }
        }
    }
    var ScOkFunction = function (Sc, CreateWindowdiag) {
        var ScCount = Sc.length;
        if (ScCount > 0) {
            var ScIndex = 0;
            var ScOkFunction_2 = function (Sc, ScIndex, ScCount) {
                var SysCutPic = "";
                if (ScIndex < ScCount) {
                    SysCutPic = "";
                    if (Sc[ScIndex][0].indexOf("(") != -1 && Sc[ScIndex][0].indexOf(")") != -1) {
                        var data1 = Sc[ScIndex][0].split(")");
                        SysCutPic = data1[0].substr(1);
                        Sc[ScIndex][0] = data1[1];
                    }
                    if (SysCutPic.length > 0) {
                        CutPicFun(function (html) {
                            ScIndex++;
                            ScOkFunction_1(Sc, ScIndex, ScCount);
                            ScOkFunction_2(Sc, ScIndex, ScCount);
                        }, Sc[ScIndex][0], null, 1, SysCutPic);
                    } else {
                        ScIndex++;
                        ScOkFunction_1(Sc, ScIndex, ScCount);
                        ScOkFunction_2(Sc, ScIndex, ScCount);
                    }
                }
            }
            ScOkFunction_2(Sc, ScIndex, ScCount);
        }
        setTimeout(function () { CreateWindowdiag.close(); }, 100);
    }

    SyCmsFileUploadWin(Title, { 'UploadPath': (UploadPath ? UploadPath : ""), 'Path': Path, 'Listid': Listid, "IsStyle": (IsStyle ? IsStyle : "0"), 'IsType': '0', 'ListType': (ListType ? ListType : "0"), "cookies": encodeURIComponent(cookies), "syscutpic": (syscutpic ? syscutpic : "") }, Path, ScOkFunction, null, FileExt ? "*." + FileExt.split("|").join(";*.") : "", FileSize, syscutpic);
}
//多文件上传窗口
function SyCmsFileUploadWin(Title, scriptData, Path, ScOkFunction, ScFunction, fileTypeExts, fileSize, syscutpic) {
    var Sc = new Array();
    fileSize = fileSize ? parseInt(fileSize) / 1024 : 0;
    CreateWindow(null, (Title ? Title : "上传文件") + (fileSize > 0 ? "<font color=red>[" + fileSize + "KB]</font>" : ""), function () { }, 400, 350, null, null, null, null, null, function (CreateWindowdiag) {
        $('#uploadify').uploadify({
            'swf': 'JS/File/uploadify/uploadify.swf',
            'expressInstall': 'JS/File/uploadify/expressInstall.swf',
            'uploader': 'AdminFun/File/UploadHandler.ashx',
            'method': 'post',
            'queueID': "fileQueue",
            'queueSizeLimit': '1000',
            'formData': scriptData,
            'width': 120,
            'height': 30,
            'cancelImage': 'images/uploadify/cancel.png',
            'buttonImage': 'images/uploadify/select.png',
            'fileSizeLimit': fileSize,
            'auto': false,
            'onFallback': function () {
                LoadWarting("插件未安装", "您未安装FLASH控件，无法上传！请安装FLASH控件后再试。", "error", 5);
            },
            'overrideEvents': ['onSelectError', 'onDialogClose', 'onQueueComplete '],
            'onSelectError': function (file, errorCode, errorMsg) {
                switch (errorCode) {
                    case -100:
                        {
                            LoadWarting("文件数错误", "最多同时只能传1000个。", "error", 5);
                            break;
                        }
                }
            },
            onDialogClose: function (swfuploadifyQueue) {
                if (swfuploadifyQueue.queueLength > 0) {
                    $(CreateWindowdiag.okButton).show();
                    $(CreateWindowdiag.otherButton[0]).show();
                }
            },
            'removeTimeout': 0.01,
            'fileTypeDesc': '支持所有格式',
            'fileTypeExts': fileTypeExts ? fileTypeExts : '*.7z;*.aiff;*.asf;*.avi;*.bmp;*.csv;*.doc;*.docx;*.fla;*.flv;*.gif;*.gz;*.gzip;*.jpeg;*.jpg;*.mid;*.mov;*.mp3;*.mp4;*.mpc;*.mpeg;*.mpg;*.ods;*.odt;*.pdf;*.png;*.ppt;*.pxd;*.qt;*.ram;*.rar;*.rm;*.rmi;*.rmvb;*.rtf;*.sdc;*.sitd;*.swf;*.sxc;*.sxw;*.tar;*.tgz;*.tif;*.tiff;*.txt;*.vsd;*.wav;*.wma;*.wmv;*.xls;*.xml;*.zip;*.js;*.css',
            'multi': true,
            'onQueueComplete': function () { if (ScOkFunction) { ScOkFunction(Sc, CreateWindowdiag); } else { CreateWindowdiag.close(); } },
            'onUploadSuccess': function (file, data, response) { if (data != "0") { if (ScFunction) { ScFunction(data, file.name) } else { Sc.push([data, file.name]); } } }
        });
        CreateWindowdiag.okButton.value = "开始上传";
        CreateWindowdiag.okButton.onclick = function () {
            $('#uploadify').uploadify("upload", "*");
        }
        $(CreateWindowdiag.okButton).hide();

        CreateWindowdiag.addButton("otheruploadfile", SycmsLanguage.Admin.UploadFile.l3, function () {
            scriptData.IsType = "1";
            $("#uploadify").uploadify("settings", "formData", scriptData);
            $('#uploadify').uploadify("upload", "*");
        });
        $(CreateWindowdiag.otherButton[0]).hide();

        CreateWindowdiag.cancelButton.value = "取消上传";
        CreateWindowdiag.cancelButton.onclick = function () {
            $('#uploadify').uploadify("stop");
            $('#uploadify').uploadify("cancel");
            if (ScOkFunction) {
                ScOkFunction(Sc, CreateWindowdiag);
            } else {
                CreateWindowdiag.close();
            }
        }
    }, null, null, "<div id=\"fileQueue\"></div>" +
    "<input type=\"hidden\" name=\"uploadifyUploader\" id=\"uploadifyUploader\" /><input type=\"file\" name=\"uploadify\" id=\"uploadify\" />");
}

function SycmsFileAddDir(Url, SelectOk, IsNum, IsAdd, IsModi, IsDel) {
    var Path = $("#FullPathView").html();
    if (Path == "/") {
        Path = "";
    }
    CreateWindow(null, "建立目录", Url + "&Dir=" + Path, 300, 50, "File_AddDir", null, null, null, null, null, function (html, Windowdiag) {
        Windowdiag.close();
        if (Path == "") {
            setTimeout(function () { SyCmsFileManage(Url); }, (ErrViewTime-1) * 1000);
        } else {
            setTimeout(function () {
                $("#SyCms_fileTree").fileTree.reload(Path, false);
                SyCmsFileList(Url, Path, SelectOk, IsNum, IsAdd, IsModi, IsDel);
            }, (ErrViewTime - 1) * 1000);
        }
    }, null, "<table class=\"table StyleView\" id=\"File_AddDir\" height=\"50\" width=\"100%\">" +
    "<tr>" +
    "<th width=\"80\" align=\"right\">目录名称：</th>" +
    "<td align=\"left\"><input type=\"text\" value=\"\" class=\"validate[required,custom[noSpecialCaracters],length[1,50]] text\" id=\"DirName\" name=\"DirName\"></td>" +
    "</tr>" +
    "</table>");
}

///文件列表
function SyCmsFileList(Url, Dir, SelectOk, IsNum, IsAdd, IsModi, IsDel) {
    $('#SyCms_fileGrid').fileGrid({ root: Dir, script: Url + "&IsType=1" }, function (file) {
        if (!file.isLeaf) {
            if (file.back) {
                $("#SyCms_fileTree").fileTree.reload(file.oPath, file.back);
                SyCmsFilePathView(file.oPath);
            }
            else {
                $("#SyCms_fileTree").fileTree.reload(file.path, file.back);
                SyCmsFilePathView(file.path);
            }
        }
        else {
            CutPicFun(function () {
                SyCmsFileList(Url, $("#FullPathView").html(), SelectOk, IsNum, IsAdd, IsModi, IsDel);
            }, file.path);
        }
    }, function (file) {
        SycmsFileInfo(file, file.type);
    }, function () {
        $("img.scrollLoading").lazyload({ effect: "fadeIn", container: $("#SyCms_fileGridView") });
        var menu = { alias: "cmroot_File", width: 100, items: [
            { text: "编辑", icon: "images/icon/page_edit.png", alias: "contextmenu-edit", action: contextMenuItem_click, disable: IsModi == "1" ? false : true },
            { type: "splitLine" },
            { text: "查看", icon: "images/icon/eye.png", alias: "contextmenu-eye", action: contextMenuItem_click },
            { text: "下载", icon: "images/icon/disk_download.png", alias: "contextmenu-down", action: contextMenuItem_click },
            { type: "splitLine" },
            { text: "删除", icon: "images/icon/false.png", alias: "contextmenu-del", action: contextMenuItem_click, disable: IsModi == "1" ? false : true }
           ]
        };
        function contextMenuItem_click(target) {
            var FileDiv = $(target).find("div.file");
            var cmd = this.data.alias;
            var Url = FileDiv.attr("rel");
            if (cmd == "contextmenu-eye") {
                window.open(Url);
            } else if (cmd == "contextmenu-edit") {
                CreateWindow('AdminFun/File/Modi.aspx?FileName=' + encodeURIComponent(Url), '修改文件内容【' + Url + '】', 'AdminFun/File/Modi.aspx?action=save&FileName=' + encodeURIComponent(Url), "600", "400", "FileContentModi");
            }
            else if (cmd == "contextmenu-down") {
                $("#DownFileWin").attr("src", "AdminFun/File/Lists_Url.aspx?Url=" + encodeURIComponent(Url));
            }
            else if (cmd == "contextmenu-del") {
                AjaxFun("AdminFun/File/Del.aspx", "Url=" + encodeURIComponent(Url), " ", function (html) {
                    if (html.indexOf("ok") != -1) {
                        $(target).remove();
                        $("#ImageListManage #CssPicSelectUrl").val("");
                    } else {
                        Dialog.confirm("错误：文件还在使用，是否强制删除？", function () {
                            AjaxFun("AdminFun/File/Del.aspx", "Action=del&Url=" + encodeURIComponent(Url), " ", function (html) {
                                if (html.indexOf("ok") != -1) {
                                    $(target).remove();
                                    $("#ImageListManage #CssPicSelectUrl").val("");
                                }
                            });
                        });
                    }
                })
            }
        }
        $("#SyCms_fileGrid li").contextmenu(menu);

        if (SelectOk == "1") {
            new RegionSelect({
                region: '#SyCms_fileGrid li',
                selectedClass: 'jquery_filegrid_border_foucs',
                isNum: IsNum,
                parentObj: "#SyCms_fileGrid",
                scrollObj: "#SyCms_fileGridView",
                returnFunction: function (varArr) {
                    var d = [];
                    var u = "";
                    for (var i = 0; i < varArr.length; i++) {
                        u = $(varArr[i]).find(".file").attr("vrel");
                        if (!(u.Left(1) == "[" || u.Left(1) == "{")) {
                            u = $(varArr[i]).find(".file").attr("rel");
                        }
                        d.push(u);
                    }
                    $("#ImageListManage #CssPicSelectUrl").val(d.join(","));
                }
            }).select();
        }
    });
}

//显示详细信息并显示
function SycmsFileInfo(file, type) {
    var FileExt = new Array();
    FileExt[0] = ".jpg,.bmp,.gif,.png,.jpeg";
    FileExt[1] = ".wmv,.avi,.dat,.asf";   //微软
    FileExt[2] = ".rm,.rmvb,.ram";        //real
    FileExt[3] = ".mov";                  //苹果格式
    FileExt[4] = ".mpg,.mpeg,.3gp,mp4,.m4v,.dvix,.dv,.dat,.mkv,.vob,.ram,.qt,.divx,.cpk,.fli,.flc,.mod";                      //其它格式用微软放吧
    FileExt[5] = ".flv";
    FileExt[6] = ".swf";

    var ExtStr = file.path.split(".");
    var Ext = ExtStr[ExtStr.length - 1];
    $("#FilePlayView").children().remove();
    $("#FileInfoView").html("<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"padding:5px;\">" +
"<tbody>" +
    "<tr>" +
        "<td rowspan=\"3\" style=\"padding:5px;width:50px;\">&nbsp;</td>" +
        "<td style=\"padding:5px;\">" + file.name + "</td>" +
        "<td style=\"padding:5px;\">修改时间：" + file.wTime + "</td>" +
    "</tr>" +
    "<tr>" +
        "<td style=\"padding:5px;\">&nbsp;</td>" +
        "<td style=\"padding:5px;\">" + (type == 0 ? "&nbsp;" : "大小：" + file.size) + "<span style=\"padding-left:10px;\" id=\"FileInfo_PicWH\"></span></td>" +
    "</tr>" +
    "<tr>" +
        "<td style=\"padding:5px;\">" + (type == 0 ? "文件夹" : "文件") + "</td>" +
        "<td style=\"padding:5px;\">创建时间：" + file.cTime + "</td>" +
    "</tr>" +
"</tbody>" +
"</table>");
    if (FileExt[0].indexOf("." + Ext.toLowerCase()) != -1) {
        $("#FilePlayView").find("img").remove()
        $("#FilePlayView").append("<img src=\"\">").find("img").LoadImage(true, 5000, 5000, "images/dialog/loading.gif", file.path, $("#FileInfo_PicWH"));
        //    }else if(FileExt[1].indexOf("."+Ext)!=-1 || FileExt[4].indexOf("."+Ext)!=-1)
        //    {
        //        $("#FilePlayView").find("embed").remove();
        //        $("#FilePlayView").append("<embed height=\"250\" width=\"250\" src=\""+file.path+"\" type=\"application/x-mplayer2\" play=\"false\" loop=\"true\" menu=\"true\"></embed>");
        //    }else if(FileExt[2].indexOf("."+Ext)!=-1)
        //    {
        //        $("#FilePlayView").find("embed").remove();
        //        $("#FilePlayView").append("<embed height=\"250\" width=\"250\" src=\""+file.path+"\" type=\"audio/x-pn-realaudio-plugin\" play=\"false\" loop=\"true\" menu=\"true\"></embed>");
        //    }else if(FileExt[3].indexOf("."+Ext)!=-1)
        //    {
        //        $("#FilePlayView").find("embed").remove();
        //        $("#FilePlayView").append("<embed height=\"250\" width=\"250\" src=\""+file.path+"\" type=\"video/quicktime\" play=\"false\" loop=\"true\" menu=\"true\"></embed>");
        //    }
        //    else if(FileExt[6].indexOf("."+Ext)!=-1)
        //    {
        //        $("#FilePlayView").find("embed").remove();
        //        $("#FilePlayView").append("<embed height=\"250\" width=\"250\" src=\""+file.path+"\" type=\"application/x-shockwave-flash\" play=\"false\" loop=\"true\" menu=\"true\"></embed>");
    }
}
///显示文件路径
function SyCmsFilePathView(PathUrl) {
    if (PathUrl.Left(1) != "/") {
        PathUrl = "/" + PathUrl;
    }
    $("#FullPathView").html(PathUrl);
}

//显示 文件选择窗口
function DirImgWin(Obj, ListID, Action, syscutpic) {
    CreateWindow('AdminFun/File/Lists.aspx?' + (Obj ? "selectok=1&" : "selectok=0&") + 'Listid=' + ListID + (Action ? "&" + Action : "") + (syscutpic ? "&syscutpic=" + syscutpic : ""), '选择文件', function (ObjWin) {
        var FileUrl = $("#ImageListManage #CssPicSelectUrl").val();
        ObjWin.close();
        if (Obj) {
            if (FileUrl.length > 0) {
                var v = FileUrl.split('.');
                var InsertFileUrl = function (FileUrl) {
                    if (typeof (Obj) == "function") {
                        Obj(FileUrl);
                    } else {
                        if (Obj.type == "textarea") {
                            InsertAtCaret(Obj, FileUrl);
                        } else {
                            Obj.value = FileUrl;
                        }
                    }
                }
                if (syscutpic && syscutpic.length > 0 && ("|jpg|gif|bmp|png|jpeg|".indexOf("|" + v[v.length - 1].toLowerCase() + "|") != -1)) {
                    AjaxFun("AdminFun/ReadFileUrl.aspx", "action=cut&syscutpic=" + encodeURIComponent(syscutpic) + "&FileUrl=" + encodeURIComponent(FileUrl), " ", function (html) {
                        var SysCutPic = "";
                        if (html.indexOf("(") != -1 && html.indexOf(")") != -1) {
                            var data1 = html.split(")");
                            SysCutPic = data1[0].substr(1);
                            html = data1[1];
                        }
                        if (SysCutPic.length > 0) {
                            CutPicFun(function (html) {
                                InsertFileUrl(html);
                            }, html, null, 2, SysCutPic);
                        } else {
                            InsertFileUrl(html);
                        }
                    });
                } else {
                    InsertFileUrl(FileUrl);
                }
            }
        }
    }, "100", "100", null, null, null, null, null, function (CreateWindowdiag) {
        if (!Obj) {
            CreateWindowdiag.okButton.value = "关  闭";
            CreateWindowdiag.cancelButton.style.display = "none";
        }
    });
}