CKEDITOR.plugins.add('piccut',
{
    init: function (editor) {
        var pluginName = 'piccut';
        editor.addCommand(pluginName, new CKEDITOR.command(editor,
        {
            exec: function (editor) {
                var imgObj = editor.getSelection().getStartElement();
                if (imgObj) {
                    var textSrc = imgObj.getAttribute("src");
                    var alt = imgObj.getAttribute("alt");
                    if (textSrc) {
                        if (textSrc.indexOf("://") != -1) {
                            textSrcArr = textSrc.split("/");
                            textSrc = "";
                            for (var i = 3; i < textSrcArr.length; i++) {
                                textSrc += "/" + textSrcArr[i];
                            }
                        }
                        parent.parent.CutPicFun(function (html) {
                            if (html) {
                                if (html.toLocaleLowerCase() == textSrc.toLocaleLowerCase()) {
                                    editor.insertHtml("<img src=\"" + html + "?imgLoad=" + Math.random() + "imgLoad\"" + (alt ? " alt=\"" + alt + "\"" : "") + " />");
                                } else {
                                    editor.insertHtml("<img src=\"" + html + "\"" + (alt ? " alt=\"" + alt + "\"" : "") + " />");
                                }
                            }
                        }, textSrc, "&IsEditor=1");
                    }
                }
            }
        })
   );
        if (editor.addMenuItems) {
            editor.addMenuItems(
       {
           insertCode:
           {
               label: '剪切图片',
               command: 'piccut',
               group: 'piccut'
           }
       });
        }
        if (editor.contextMenu) {
            editor.contextMenu.addListener(function (element, selection) {
                if (element && element.getName() == 'img') {
                    var d = selection.getStartElement();
                    var doc = selection.getStartElement().getAttribute("src");
                    if (doc && doc.indexOf("/ckeditor/images/") == -1 && doc.indexOf("/ckeditor/plugins/") == -1) {
                        return { insertCode: CKEDITOR.TRISTATE_ON };
                    }
                }
            });
        }
    }
});