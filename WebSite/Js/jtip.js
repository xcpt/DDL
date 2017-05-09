/*
* JTip
* By Cody Lindley (http://www.codylindley.com)
* Under an Attribution, Share Alike License
* JTip is built on top of the very light weight jquery library.
*/

//on page load (as soon as its ready) call JT_init
$.fn.JT_init = function (sw, sh) {
    sw = sw ? sw : ((typeof (Ww) != "undefined") ? Ww : $(window).width());
    sh = sh ? sh : ((typeof (Wh) != "undefined") ? Wh : $(window).height());
    this.hover(function () { $('#JT').remove(); var obj = $(this); if (obj.attr("title")) { obj.attr("title1", decodeURIComponent(obj.attr("title"))); obj.removeAttr("title"); } var url = obj.attr("title1") ? obj.attr("title1") : obj.attr("alt"); if (this.type == "text" && this.value.length > 0 && (this.value.indexOf(".jpg") != -1 || this.value.indexOf(".bmp") != -1 || this.value.indexOf(".gif") != -1 || this.value.indexOf(".png") != -1)) { url = this.value + "?width=200&height=200"; }; if (url && url.Trim()) { JT_show(url, this, obj.attr("jTipTitle") ? obj.attr("jTipTitle") : this.name); } }, function () { $('#JT').remove(); });

    function JT_show(url, linkId, title) {
        if (url) {
            if (title == false) title = "&nbsp;";
            var linkIdSize = getElementSize(linkId);
            var hasArea = sw - linkIdSize.Left;
            var clickElementy = linkIdSize.Top - 3; //set y position
            var queryString = url.replace(/^[^\?]+\??/, '');
            var params = parseQuery(queryString);
            if (params['width'] === undefined) { params['width'] = 250 };
            if (params['height'] === undefined) { params['height'] = 50 };
            if (params['link'] !== undefined && linkId.id) {
                $('#' + linkId).bind('click', function () { window.location = params['link'] });
                $('#' + linkId).css('cursor', 'pointer');
            }
            var JT_copy1 = null, JT_copy = null, JT = null;
            if (linkIdSize.Left + linkIdSize.Width + ((params['width'] * 1) + 75) < sw) {
                if (linkIdSize.Top + linkIdSize.Height + 60 > sh) {
                    $("body").append("<div id='JT' class='JT' style='width:" + params['width'] * 1 + "px'><div id='JT_copy1' class='JT_copy'><div class='JT_loader'></div></div><div id='JT_arrow_left' class='JT_arrow_left'><div id='JT_close_left' class='JT_close_left'>" + title + "</div></div><div id='JT_copy' class='JT_copy' style='display:none;'></div></div>"); //right side
                    clickElementy -= 38;
                } else {
                    $("body").append("<div id='JT' class='JT' style='width:" + params['width'] * 1 + "px'><div id='JT_copy1' class='JT_copy' style='display:none;'></div><div id='JT_arrow_left' class='JT_arrow_left'><div id='JT_close_left' class='JT_close_left'>" + title + "</div></div><div id='JT_copy' class='JT_copy'><div class='JT_loader'></div></div></div>"); //right side
                }
                var clickElementx = linkIdSize.Left + linkIdSize.Width; //set x position
            } else {
                if (linkIdSize.Top + linkIdSize.Height + 60 > sh) {
                    $("body").append("<div id='JT' class='JT JT_Right' style='width:" + params['width'] * 1 + "px'><div id='JT_copy1' class='JT_copy'><div class='JT_loader'></div></div><div id='JT_arrow_right' class='JT_arrow_right'><div id='JT_close_right' class='JT_close_right'>" + title + "</div></div><div id='JT_copy' class='JT_copy' style='display:none;'></div></div>"); //left side
                    clickElementy -= 38;
                } else {
                    $("body").append("<div id='JT' class='JT JT_Right' style='width:" + params['width'] * 1 + "px'><div id='JT_copy1' class='JT_copy' style='display:none;'></div><div id='JT_arrow_right' class='JT_arrow_right'><div id='JT_close_right' class='JT_close_right'>" + title + "</div></div><div id='JT_copy' class='JT_copy'><div class='JT_loader'></div></div></div>"); //left side
                }
                var clickElementx = linkIdSize.Left - ((params['width'] * 1)); //set x position
            }
            JT_copy = $("#JT_copy");
            JT_copy1 = $("#JT_copy1");
            JT = $("#JT");

            JT.css({ left: clickElementx + "px", top: clickElementy + "px" });
            JT.show();
            url = url.toLowerCase();
            if (url.indexOf(".jpg") != -1 || url.indexOf(".jpeg") != -1 || url.indexOf(".bmp") != -1 || url.indexOf(".gif") != -1 || url.indexOf(".png") != -1) {
                imgReady(url.split("?")[0], function (width, height) {
                }, function (width, height, fileSize) {
                    var imgsize = ImgWidthHeight(width, height, params['width'], params['height']);
                    var w = parseInt(imgsize.width);
                    var h = parseInt(imgsize.height);
                    JT.css('width', (w + 36) + "px");
                    clickElementy = MoveLocation(w, h + 40, linkIdSize, params, clickElementx, clickElementy);
                    if (clickElementy > 0) {
                        JT.css({ top: clickElementy + "px" });
                        JT_copy.remove();
                        JT_copy1.html("<img src='" + url.split("?")[0] + "' width='" + w + "' height='" + h + "' /><div class='ImgMess' style='display:none;'>" + url.split("?")[0].replace(/\/upLoadfile\/images\//i, "").replace(/\/upLoadfile\//i, "") + "<br>" + SycmsLanguage.jtip.l2 + ":" + width + "px&nbsp;&nbsp;" + SycmsLanguage.jtip.l3 + ":" + height + "px;</div>").show();
                    } else {
                        JT_copy.html("<img src='" + url.split("?")[0] + "' width='" + w + "' height='" + h + "' /><div class='ImgMess' style='display:none;'>" + url.split("?")[0].replace(/\/upLoadfile\/images\//i, "").replace(/\/upLoadfile\//i, "") + "<br>" + SycmsLanguage.jtip.l2 + ":" + width + "px&nbsp;&nbsp;" + SycmsLanguage.jtip.l3 + ":" + height + "px;</div>");
                        JT_copy1.remove();
                    }
                }, function () {
                    JT_copy.html(SycmsLanguage.jtip.l1);
                });
            } else if (url.indexOf(".aspx") != -1) {
                JT_copy1.load(url, null, function () {
                    clickElementy = MoveLocation(JT_copy1.width(), JT_copy1.height(), linkIdSize, params, clickElementx, clickElementy);
                    if (clickElementy > 0) {
                        JT.css({ top: clickElementy + "px" });
                        JT_copy.remove();
                        JT_copy1.show();
                    } else {
                        JT_copy.html(JT_copy1.html());
                        JT_copy1.remove();
                    }
                });
            } else {
                JT_copy.html(url.split('?')[0]);
                JT_copy1.remove();
            }
        }
    }
    function MoveLocation(width, height, linkIdSize, params, clickElementx, clickElementy) {
        var w = width + 50;
        var h = height + 25;
        if (clickElementx + w > sw) {
            clickElementx = linkIdSize.Left - ((params['width'] * 1));
        } else {
            clickElementx = 0;
        }
        if (clickElementy + h > sh) {
            clickElementy = linkIdSize.Top - h + 7;
        } else {
            clickElementy = 0;
        }
        if (clickElementx > 0) {
            $('#JT').css({ left: clickElementx + "px" });
        }
        return clickElementy;
    }
    function ImgWidthHeight(width, height, FitWidth, FitHeight) {
        var ImgDwidth = width;
        var ImgDheight = height;
        if (width / height >= FitWidth / FitHeight) {
            if (width > FitWidth) {
                ImgDwidth = FitWidth;
                ImgDheight = (height * FitWidth) / width;
            } else {
                ImgDwidth = width;
                ImgDheight = height;
            }
        } else {
            if (height > FitHeight) {
                ImgDheight = FitHeight;
                ImgDwidth = (width * FitHeight) / height;
            } else {
                ImgDwidth = width;
                ImgDheight = height;
            }
        }
        return { width: ImgDwidth, height: ImgDheight };
    }

    function getElementSize(o) {
        var yo = o;
        var oWidth = o.offsetWidth;
        var oHeight = o.offsetHeight;
        var oLeft = o.offsetLeft;         // Get left position from the parent object
        var oTop = o.offsetTop;         // Get top position from the parent object
        var oLeft1 = 0;         // Get left position from the parent object
        var oTop1 = 0;         // Get top position from the parent object
        while (o.offsetParent != null) {   // Parse the parent hierarchy up to the document element
            oParent = o.offsetParent;    // Get parent object reference
            oLeft += oParent.offsetLeft; // Add parent left position
            oTop += oParent.offsetTop; // Add parent top position
            o = oParent;
        }
        o = yo;
        while (o.parentNode != null) {   // Parse the parent hierarchy up to the document element
            oParent = o.parentNode;    // Get parent object reference
            oLeft1 += (oParent.scrollLeft ? oParent.scrollLeft : 0); // Add parent left position
            oTop1 += (oParent.scrollTop ? oParent.scrollTop : 0); // Add parent top position
            o = oParent;
        }
        oLeft -= oLeft1;
        oTop -= oTop1;
        if (oLeft < 0) {
            oLeft = 0;
        }
        if (oTop < 0) {
            oTop = 0;
        }
        return { Width: oWidth, Height: oHeight, Left: oLeft, Top: oTop };
    }

    function parseQuery(query) {
        var Params = new Object();
        if (!query) return Params; // return empty object
        var Pairs = query.split(/[;&]/);
        for (var i = 0; i < Pairs.length; i++) {
            var KeyVal = Pairs[i].split('=');
            if (!KeyVal || KeyVal.length != 2) continue;
            var key = unescape(KeyVal[0]);
            var val = unescape(KeyVal[1]);
            val = val.replace(/\+/g, ' ');
            Params[key] = val;
        }
        return Params;
    }
}
