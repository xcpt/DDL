// jQuery File Tree Plugin
//
// Version 1.01
//
// Cory S.N. LaViska
// A Beautiful Site (http://abeautifulsite.net/)
// 24 March 2008
//
// Visit http://abeautifulsite.net/notebook.php?article=58 for more information
//
// Usage: $('.fileTreeDemo').fileTree( options, callback )
//
// Options:  root           - root folder to display; default = /
//           script         - location of the serverside AJAX file to use; default = jqueryFileTree.php
//           folderEvent    - event to trigger expand/collapse; default = click
//           expandSpeed    - default = 500 (ms); use -1 for no animation
//           collapseSpeed  - default = 500 (ms); use -1 for no animation
//           expandEasing   - easing function to use on expand (optional)
//           collapseEasing - easing function to use on collapse (optional)
//           multiFolder    - whether or not to limit the browser to one subfolder at a time
//           loadMessage    - Message to display while initial tree loads (can be HTML)
//
// History:
//
// 1.01 - updated to work with foreign characters in directory/file names (12 April 2008)
// 1.00 - released (24 March 2008)
//
// TERMS OF USE
// 
// jQuery File Tree is licensed under a Creative Commons License and is copyrighted (C)2008 by Cory S.N. LaViska.
// For details, visit http://creativecommons.org/licenses/by/3.0/us/
//
if (jQuery) (function ($) {

    $.extend($.fn, {
        fileTree: function (o, h) {
            // Defaults
            if (!o) var o = {};
            if (o.root == undefined) o.root = '/';
            if (o.script == undefined) o.script = '';
            if (o.folderEvent == undefined) o.folderEvent = 'click';
            if (o.expandSpeed == undefined) o.expandSpeed = 1;
            if (o.collapseSpeed == undefined) o.collapseSpeed = 1;
            if (o.expandEasing == undefined) o.expandEasing = null;
            if (o.collapseEasing == undefined) o.collapseEasing = null;
            if (o.multiFolder == undefined) o.multiFolder = true;
            if (o.loadMessage == undefined) o.loadMessage = 'Loading...';

            $.fn.fileTree.info = {
                path: "",
                name: "",
                isLeaf: false,
                collapse: false
            };

            $.fn.fileTree.reload = function (dir, isback) {
                if (dir.length > 0) {
                    dir = dir.substr(1);
                }
                var obj = o.$this.find("a[rel='" + unescape(dir) + "']");
                if (!isback) {
                    if (!obj.parent().hasClass("expanded")) {
                        obj.parent().removeClass("collapsed").addClass('expanded');
                        obj.siblings().empty();
                        o.show(obj.parent(), escape(dir));
                    }
                    else {
                        obj.siblings().empty();
                        o.show(obj.parent(), escape(dir));
                    }
                }
                else {
                    if (obj.parent().hasClass("expanded")) {
                        obj.parent().removeClass("expanded").addClass('collapsed');
                    }

                    obj.siblings().empty();
                }
            }

            $(this).each(function () {
                o.show = showTree; o.$this = $(this);

                function showTree(c, t) {
                    $(c).addClass('wait');
                    $(".jqueryFileTree.start").remove();
                    var objWin = LoadWarting("", "");
                    $.post(o.script, { dir: t }, function (data) {
                        objWin.close();
                        $(c).find('.start').html('');
                        if (data) {
                            $(c).removeClass('wait').append(data);
                        }
                        if (o.root == t) $(c).find('UL:hidden').show(); else $(c).find('UL:hidden').slideDown({ duration: o.expandSpeed, easing: o.expandEasing });
                        bindTree(c);
                    });
                }

                function bindTree(t) {
                    var info = $.fn.fileTree.info;
                    $(t).find('LI A').bind(o.folderEvent, function () {
                        if ($(this).parent().hasClass('directory')) {

                            if ($(this).parent().hasClass('collapsed')) {
                                // Expand
                                if (!o.multiFolder) {
                                    $(this).parent().parent().find('UL').slideUp({ duration: o.collapseSpeed, easing: o.collapseEasing });
                                    $(this).parent().parent().find('LI.directory').removeClass('expanded').addClass('collapsed');
                                }
                                $(this).parent().find('UL').remove(); // cleanup
                                info.isLeaf = false; info.collapse = false;
                                showTree($(this).parent(), escape($(this).attr('rel').match(/.*\//)));
                                $(this).parent().removeClass('collapsed').addClass('expanded');
                            } else {
                                // Collapse
                                info.collapse = true;
                                $(this).parent().find('UL').slideUp({ duration: o.collapseSpeed, easing: o.collapseEasing });
                                $(this).parent().removeClass('expanded').addClass('collapsed');
                            }
                        } else {
                            info.isLeaf = true;
                        }

                        info.path = $(this).attr('rel');
                        info.name = $(this).attr('relname');
                        info.cTime = $(this).attr('cTime');
                        info.wTime = $(this).attr('wTime');
                        h(info);
                        return false;
                    });
                    // Prevent A from triggering the # on non-click events
                    if (o.folderEvent.toLowerCase != 'click') $(t).find('LI A').bind('click', function () { return false; });
                }
                // Loading message
                $(this).html('<ul class="jqueryFileTree start"><li class="wait">' + o.loadMessage + '<li></ul>');
                // Get the initial file list
                showTree($(this), escape(o.root));
            });
        }
    });

})(jQuery);