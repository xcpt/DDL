/*
Copyright (c) 2003-2010, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/
CKEDITOR.editorConfig = function (config) {
    config.resize_enabled = false;
    config.language = 'zh-cn'; //中文
    config.uiColor = '#BFEE62'; //编辑器颜色
    config.font_names = '宋体;楷体_GB2312;新宋体;黑体;隶书;幼圆;微软雅黑;Arial;Comic Sans MS;Courier New;Tahoma;Times New Roman;Verdana';
    config.filebrowserBrowseUrl = 'ckfinder/ckfinder.aspx'; //上传文件时浏览服务文件夹
    config.filebrowserImageBrowseUrl = 'ckfinder/ckfinder.aspx?Type=Images'; //上传图片时浏览服务文件夹

    config.filebrowserFlashBrowseUrl = 'ckfinder/ckfinder.aspx?Type=Flash';  //上传Flash时浏览服务文件夹

    config.filebrowserUploadUrl = 'ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files'; //上传文件按钮(标签)

    config.filebrowserImageUploadUrl = 'ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images'; //上传图片按钮(标签)

    config.filebrowserFlashUploadUrl = 'ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'; //上传Flash按钮(标签)
    config.extraPlugins = 'flv,piccut,autoformat';
    config.flv_path = '/js/flvplay/';
    config.menu_groups = 'clipboard,form,tablecell,tablecellproperties,tablerow,tablecolumn,table,anchor,link,image,flash,checkbox,radio,textfield,hiddenfield,imagebutton,button,select,textarea,piccut'; //把俺们的search写到最后就行了，我也不知道前面这么多有什么用
    config.toolbar_Whole =
    [
        ['Source', '-', 'Preview', '-', 'Templates'],
        ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Print', 'SpellChecker', 'Scayt'],
        ['Undo', 'Redo', '-', 'Find', 'Replace', '-', 'SelectAll', 'RemoveFormat'],
        ['Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField'],
        '/',
        ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript'],
        ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', 'Blockquote', 'CreateDiv'],
        ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],
        ['Link', 'Unlink', 'Anchor'],
          ['Image', 'Flash', 'flv', 'Table', 'HorizontalRule', 'SpecialChar', 'PageBreak', '-', 'autoformat'],
        '/',
        ['Styles', 'Format', 'Font', 'FontSize'],
        ['TextColor', 'BGColor'],
        ['Maximize', 'ShowBlocks']
    ];
    config.toolbar_Default =
    [
        ['Source'],
        ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Print'],
        ['Undo', 'Redo', '-', 'SelectAll', 'RemoveFormat'],
        ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript'],
                '/',
        ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent'],
        ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],
        ['Link', 'Unlink', 'Anchor'],
          ['Image', 'Flash', 'flv', 'Table', 'HorizontalRule', 'SpecialChar', 'PageBreak', '-', 'autoformat'],
        '/',
        ['Styles', 'Format', 'Font', 'FontSize'],
        ['TextColor'],
        ['Maximize', 'ShowBlocks']
    ];
    config.toolbar_Basic =
    [
        ['Source'], ['Bold', 'Italic', '-', 'NumberedList', 'BulletedList', '-', 'Link', 'Unlink', '-', 'TextColor', 'Image'],['Maximize', 'ShowBlocks']
    ];
}
