if (jQuery) (function ($) {

    $.extend($.fn, {
        fileGrid: function (o, h, cl, showfun) {
            // Defaults
            if (!o) var o = {};
            if (o.root == undefined) o.root = '/';
            if (o.script == undefined) o.script = '';
            if (o.loadMessage == undefined) o.loadMessage = 'Loading...';

            $.fn.fileGrid.info = {
                path: "",
                isLeaf: false,
                back: false,
                oPath: "",
                focusPath: ""
            };

            $.fn.fileGrid.reload = function (dir) {
                o.show(o.$this, escape(dir));
            }
            $(this).each(function () {
                o.show = showGrid; o.$this = $(this);
                function showGrid(c, t) {
                    $(c).empty();
                    AjaxFun(o.script, "dir=" + t, " ", function (data) {
                        if (data) {
                            var dd = eval(data);
                            var ddhtml = new Array();
                            ddhtml.push("<ul>");
                            if (dd.length > 2) {
                                for (var i = 1; i < dd.length - 1; i++) {
                                    ddhtml.push("<li title=\"" + dd[i][0] + "\">");
                                    ddhtml.push("<div class=\"jquery_filegrid_border\">");
                                    ddhtml.push("<div class=\"file ext_" + dd[i][1] + (("bmp,gif,png,jpg").indexOf(dd[i][1]) != -1 ? " ext_View" : "") + "\" vrel=\"" + dd[i][2] + dd[i][0] + "\" rel=\"" + dd[i][3] + "\" relname=\"" + dd[i][0] + "\" cTime=\"" + dd[i][4] + "\" wTime=\"" + dd[i][5] + "\" size=\"" + dd[i][6] + "\">" + (("bmp,gif,png,jpg").indexOf(dd[i][1]) != -1 ? dd[i][0] : "&nbsp;") + "</div>");
                                    ddhtml.push("</div>");
                                    ddhtml.push("<div class=\"jquery_filegrid_font\">");
                                    if (("bmp,gif,png,jpg").indexOf(dd[i][1]) != -1) {
                                        ddhtml.push("<table width=\"100%\" height=\"100%\"><tr><td align=\"center\" valign=\"middle\"><img class=\"scrollLoading\" data-original=\"" + dd[0][0] + dd[i][3] + "&save=no&width=80&height=80&cut=hwc\" src=\"images/pixel.gif\" style=\"background:url(images/flexigrid/load.gif) no-repeat center;\" align=\"absmiddle\" /></td></tr></table>");
                                    } else {
                                        ddhtml.push(dd[i][0]);
                                    }
                                    ddhtml.push("</div></li>");
                                }
                            }
                            ddhtml.push("</ul>");
                            $(c).html(ddhtml.join(""));
                            ddhtml = null;
                        }
                        bindGrid(c);
                        if (showfun) {
                            showfun();
                        }
                    });
                }

                function bindGrid(t) {
                    var info = $.fn.fileGrid.info;
                    $(t).find('LI').bind("dblclick", function () {
                        var dir = $(this).children().children();
                        if (dir.hasClass('directory') || dir.hasClass('back')) {
                            info.isLeaf = false;
                            showGrid(t, escape(dir.attr('rel')));

                            if (dir.hasClass('back')) {
                                info.back = true;
                            }
                            else
                                info.back = false;

                        } else {
                            info.isLeaf = true; info.back = false;
                        }

                        info.path = dir.attr('rel');
                        info.name = dir.attr('relname');
                        info.oPath = dir.attr('orel');
                        info.cTime = dir.attr('cTime');
                        info.wTime = dir.attr('wTime');
                        h(info);

                        return false;
                    }).bind("click", function () {
                        var dir = $(this).children().children();
                        if (!dir.hasClass('directory')) {
                            info.type = 1;
                        } else {
                            info.type = 0;
                        }
                        info.path = dir.attr('rel');
                        info.oPath = dir.attr('orel');
                        info.vpath = dir.attr('vrel');
                        info.name = dir.attr('relname');
                        info.cTime = dir.attr('cTime');
                        info.wTime = dir.attr('wTime');
                        info.size = dir.attr('size');
                        cl(info);
                        return false;
                    });
                }
                showGrid($(this), escape(o.root));
            });
        }
    });

})(jQuery);