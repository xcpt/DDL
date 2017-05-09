//模型相关

//表单的
function FormAddModel(type) {
    CreateWindow('System/UniversalFrom/Add.aspx?Type=' + type, SycmsLanguage.Model.l3, 'System/UniversalFrom/Add.aspx?action=save&Type=' + type, 800, 550, 'ModelAdd');
}
function FormModiModel(idObject, type) {
    GridModiy(idObject, 'System/UniversalFrom/Modi.aspx', SycmsLanguage.Model.l4, 'System/UniversalFrom/Modi.aspx?action=save', 800, 550, 'ModelModi');
}


//添加模型
function AddModel(type) {
    CreateWindow('Content/Model/Add.aspx?Type=' + type, SycmsLanguage.Model.l1, 'Content/Model/Add.aspx?action=save&Type=' + type, 500, 210, 'ModelAdd', null, null, null, null, function (objwin) {
        var obj = $('#ModelAdd #ModelAdvanced');
        if (obj) {
            obj.unbind().bind("click", function () {
                var tobj = $(this);
                var iobj = tobj.find('input');
                var dobj = $('#ModelAdd #ModelAdvanced_Div');
                var url = iobj.css('background-image');
                if (url.indexOf("remove_blue") != -1) {
                    url = url.replace("remove_blue", "add_blue");
                    objwin.setSize(500, (type == "0" ? 455 : 360));
                    dobj.show();
                } else {
                    url = url.replace("add_blue", "remove_blue");
                    objwin.setSize(500, 210);
                    dobj.hide();
                }
                iobj.css("background-image", url);
            });
        }
    });
}

function ModiModel(idObject, type) {
    GridModiy(idObject, 'Content/Model/Modi.aspx', SycmsLanguage.Model.l2, 'Content/Model/Modi.aspx?action=save', 500, 210, 'ModelModi', null, null, null, null, function (objwin) {
        var obj = $('#ModelModi #ModelModivanced');
        if (obj) {
            obj.unbind().bind("click", function () {
                var tobj = $(this);
                var iobj = tobj.find('input');
                var dobj = $('#ModelModi #ModelModivanced_Div');
                var url = iobj.css('background-image');
                if (url.indexOf("remove_blue") != -1) {
                    url = url.replace("remove_blue", "add_blue");
                    objwin.setSize(500, (type == "0" ? 455 : 360));
                    dobj.show();
                } else {
                    url = url.replace("add_blue", "remove_blue");
                    objwin.setSize(500, 210);
                    dobj.hide();
                }
                iobj.css("background-image", url);
            });
        }
    });
}

//导入模板组
function ImportTem(FileUrl)
{
    CreateWindow("Tem/Class/Operate_Import.aspx?action=two&TemFile=" + encodeURIComponent(FileUrl), "导入模板信息", "Tem/Class/Operate_Import.aspx?action=three", 600, 500, "TemImport");
}
//上传压缩包升级
function WebInstall(FileUrl)
{
    AjaxFun("System/Update/WebInstall.aspx", "action=zip&FileUrl=" + encodeURIComponent(FileUrl), "正在解压文件，升级系统，请稍候...");
}