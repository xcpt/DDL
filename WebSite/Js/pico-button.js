(function ($) {
    var btnimagespath = "images/icon/";
    $.fn.btn = function () {
        var btn = this.data("_self");
        if (btn) {
            return btn;
        };
        this.init = function () {
            var obj = $(this);
            var randomnum = (Math.random() + "").replace(".", "");
            var id = obj.attr('id') || "gen" + randomnum;
            var icon = obj.attr('icon') || '';
            var iclass = obj.attr('class') || '';
            var ititle = obj.attr('title') || '';
            var ivalue = obj.attr('value') || '';
            var menu = obj.attr("menu") || "";
            if (icon) {
                if (menu) {
                    var icon1 = icon;
                    icon = "background-image: url(" + btnimagespath + menu + ".png) !important;padding-right:18px;background-repeat:no-repeat;background-position:right;";
                    menu = " style=\"background-image: url(" + btnimagespath + icon1.substr(5) + ".png);background-repeat:no-repeat;background-position:left;\"";
                } else {
                    icon = "background-image: url(" + btnimagespath + icon.substr(5) + ".png) !important;";
                    menu = "";
                }
            } else {
                if (menu) {
                    icon = "background-image: url(" + btnimagespath + menu + ".png) !important;padding-right:18px;padding-left:2px;background-repeat:no-repeat;background-position:right;";
                } else {
                    icon = "padding-left:2px;";
                }
                menu = "";
            }
            var bntStr = [
				'<table id="', id, '" class="z-btn" cellSpacing=0 cellPadding=0 border=0 style="border:0px;"><tbody><tr>',
					'<td style="border:0px;" class="z-btn-left"><i>&nbsp;</i></td>',
					'<td style="border:0px;" class="z-btn-center"><p unselectable="on"', menu, '>',
						'<input type="button" id="icon_', id, '" class="z-button z-btn-text ', iclass, '" style="cursor:pointer;', icon, '" iconok="OK" title="', ititle, '" value="', ivalue, '"/></p></td>',
					'<td style="border:0px;" class="z-btn-right"><i>&nbsp;</i></td>',
				'</tr></tbody></table>'
			];
            var bnt = $(bntStr.join(''));
            bnt = bnt.btn();
            bnt._click = obj.attr("onclick");
            bnt.disable();
            if (obj.attr("disabled"))
                bnt.disable();
            else bnt.enable();
            obj.replaceWith(bnt);
            bnt.data("_self", bnt);
            return bnt;
        };
        this.enable = function () {
            this.removeClass("z-btn-dsb");
            var obj = this;
            if (typeof (obj._click) == "function") {
                this.click(this._click);
            } else {
                this.unbind().bind("click", function () {
                    eval(obj._click);
                });
            }
            this.hover(
				  function () {
				      $(this).addClass("z-btn-over");
				  },
				  function () {
				      $(this).removeClass("z-btn-over");
				  }
				)
        };
        this.disable = function () {
            this.addClass("z-btn-dsb");
            this.unbind("hover");
            this.unbind("click");
        };
        return this;
    };

    $.fn.btnForMat = function () {
        var ObjButton = $(this);
        ObjButton.find("input[type='button'][iconok!='OK']").each(function () {
            $(this).btn().init();

        });
        ObjButton.find("input[type='reset'][iconok!='OK']").each(function () {
            $(this).btn().init().click(function () {
                var form = $(this).parents("form")[0];
                if (form)
                    form.reset();
            });
        });
        ObjButton.find("input[type='submit'][iconok!='OK']").each(function () {
            $(this).btn().init().click(function () {
                var form = $(this).parents("form")[0];
                if (form)
                    form.submit();
            });
        });
        return this;
    };

    $.fn.inputForMat = function () {
        var ObjInput = $(this);
        ObjInput.find("input[type='text'][class!=text]").each(function () {
            $(this).addClass("text");
        });
        return this;
    }

})(jQuery);