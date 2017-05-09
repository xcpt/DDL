/*
* AutoSuggest
* Copyright 2009-2010 Drew Wilson
* www.drewwilson.com
* code.drewwilson.com/entry/autosuggest-jquery-plugin
*
* Version 1.4   -   Updated: Mar. 23, 2010
*
* This Plug-In will auto-complete or auto-suggest completed search queries
* for you as you type. You can add multiple selections and remove them on
* the fly. It supports keybord navigation (UP + DOWN + RETURN), as well
* as multiple AutoSuggest fields on the same page.
*
* Inspied by the Autocomplete plugin by: J歳n Zaefferer
* and the Facelist plugin by: Ian Tearle (iantearle.com)
*
* This AutoSuggest jQuery plug-in is dual licensed under the MIT and GPL licenses:
*   http://www.opensource.org/licenses/mit-license.php
*   http://www.gnu.org/licenses/gpl.html
*/

(function($) {
    $.fn.autoSuggest = function(data, options) {
        var defaults = {
            asHtmlID: false,
            asHtmlName: false,
            startText: SycmsLanguage.autoSuggest.l1,
            emptyText: SycmsLanguage.autoSuggest.l2,
            preFill: {},
            limitText: SycmsLanguage.autoSuggest.l3,
            selectedItemProp: "value", //name of object property
            selectedValuesProp: "value", //name of object property
            searchObjProps: "value", //comma separated list of object property names
            queryParam: "q",
            queryName: false,//附加传值的传值名称
            queryInputName:false,
            retrieveLimit: 6, //number for 'limit' param on ajax request
            extraParams: "",
            matchCase: false,
            minChars: 1,
            maxLength: 0,
            keyDelay: 400,
            isdel:true,
            resultsHighlight: true,
            neverSubmit: false,
            selectionLimit: false,
            showResultList: true,
            TabOpen: false,
            ReadAll: true,
            start: function() { },
            prePopulate: null,
            selectionClick: function(elem) { },
            selectionAdded: function(elem) { },
            selectionRemoved: function(elem) { elem.remove(); },
            formatList: false, //callback function
            beforeRetrieve: function(string) { return string; },
            retrieveComplete: function(data) { return data; },
            resultClick: function(data) { },
            resultsComplete: function () { },
            selectOKFunction: function () { }
        };
        var opts = $.extend(defaults, options);
        var parseObj = function(strData) {
            return (new Function("return " + strData))();
        }
        var d_type = "object";
        var d_count = 0;
        var org_data;
        var req_string = "";
        if (typeof data == "string") {
            req_string = data;
            if (opts.ReadAll) {
                $.ajax({
                    type: "GET",
                    url: req_string,
                    cache: false,
                    timeout: 600000000,
                    dataType: "html",
                    success: function(html) {
                        var data = parseObj("[" + html + "]");
                        d_count = 0;
                        org_data = opts.retrieveComplete.call(this, data);
                        for (k in org_data) if (org_data.hasOwnProperty(k)) d_count++;
                    }
                });
            }
            d_type = "string";
        } else {
            org_data = data;
            for (k in data) if (data.hasOwnProperty(k)) d_count++;
        }
        if ((d_type == "object" && d_count > 0) || d_type == "string") {
            return this.each(function(x) {
                if (!opts.asHtmlID) {
                    x = x + "" + Math.floor(Math.random() * 100); //this ensures there will be unique IDs on the page if autoSuggest() is called multiple times
                    var x_id = "as-input-" + x;
                } else {
                    x = opts.asHtmlID;
                    var x_id = "as-input-" + x;
                }
                var ReplaceDH = function (str) {
                    return str.replace(/(^,*)/g, "").replace(/(,*$)/g, "");
                }
                var valLength = function () {
                    var last = 0;
                    var val = ReplaceDH(values_input.val());
                    if (val.length > 0) {
                        last = val.split(",").length;
                    }
                    return last;
                }
                var InputChange = function () {
                    var last = valLength();
                    if (parseInt(opts.maxLength) > 0 && last >= parseInt(opts.maxLength)) {
                        input.hide();
                    } else {
                        input.show();
                    }
                    values_input.trigger("change");
                    opts.selectOKFunction(values_input.val());
                }
                opts.start.call(this);
                var input = $(this);
                var yv = input.val();
                input.attr("autocomplete", "off").addClass("as-input").attr("id", x_id).attr("name", x_id).val(opts.startText);
                var values_input = $('<input type="hidden" class="as-values" Change="OFF" _value="' + yv + '" value="" name="' + (opts.asHtmlName ? opts.asHtmlName : x) + '" id="' + x + '" />');
                input.after(values_input);
                if (opts.prePopulate && opts.prePopulate.length > 0) {
                    values_input.val(("," + opts.prePopulate.join() + ",").replace(",0,", ""));
                    InputChange();
                }
                var input_focus = false;
                //Setup basic elements and render them to the DOM
                input.wrap('<ul class="as-selections" id="as-selections-' + x + '"></ul>').wrap('<li class="as-original" id="as-original-' + x + '"></li>');
                var selections_holder = $("#as-selections-" + x);
                var org_li = $("#as-original-" + x);
                var results_holder = $('<div class="as-results" id="as-results-' + x + '"></div>').hide();
                var results_ul = $('<ul class="as-list"></ul>');
                var InputSortTable = function () {
                    selections_holder.sortable({
                        items: 'li.as-selection-item', axis: 'x', stop: function (event, ui) {
                            var idvalue = new Array();
                            selections_holder.find("li.as-selection-item").each(function () {
                                idvalue.push(decodeURIComponent($(this).attr("value")));
                            });
                            if (idvalue.length > 0) {
                                values_input.val("," + idvalue.join(",") + ",");
                                InputChange();
                            }
                        }
                    });
                }
                InputSortTable();
                var prefill_value = "";
                if (typeof opts.preFill == "string") {
                    var vals = opts.preFill.split(",");
                    for (var i = 0; i < vals.length; i++) {
                        var v_data = {};
                        v_data[opts.selectedValuesProp] = vals[i];
                        if (vals[i] != "") {
                            add_selected_item(v_data, "000" + i);
                        }
                    }
                    prefill_value = opts.preFill;
                } else {
                    prefill_value = "";
                    var prefill_count = 0;
                    for (k in opts.preFill) if (opts.preFill.hasOwnProperty(k)) prefill_count++;
                    if (prefill_count > 0) {
                        for (var i = 0; i < prefill_count; i++) {
                            var new_v = opts.preFill[i][opts.selectedValuesProp];
                            if (new_v == undefined) { new_v = ""; }
                            prefill_value = prefill_value + new_v + ",";
                            if (new_v != "") {
                                add_selected_item(opts.preFill[i], "000" + i);
                            }
                        }
                    }
                }
                if (prefill_value != "") {
                    input.val("");
                    var lastChar = prefill_value.substring(prefill_value.length - 1);
                    if (lastChar != ",") { prefill_value = prefill_value + ","; }
                    values_input.val("," + prefill_value);
                    InputChange();
                    $("li.as-selection-item", selections_holder).addClass("blur").removeClass("selected");
                }
                selections_holder.click(function() {
                    input_focus = true;
                    input.focus();
                }).mousedown(function() { input_focus = false; }).after(results_holder);

                var timeout = null;
                var prev = "";
                var totalSelections = 0;
                var tab_press = false;
                var keyfunction = function(e) {
                    e = e || getEvent();
                    // track last key pressed
                    lastKeyPressCode = e.keyCode;
                    first_focus = false;
                    switch (e.keyCode) {
                        case 38: // up
                            e.preventDefault();
                            moveSelection("up");
                            break;
                        case 40: // down
                            e.preventDefault();
                            moveSelection("down");
                            break;
                        case 8:  // delete
                            if (input.val() == "") {
                                var last = values_input.val().split(",");
                                last = last[last.length - 2];
                                selections_holder.children().not(org_li.prev()).removeClass("selected");
                                if (org_li.prev().hasClass("selected")) {
                                    values_input.val(values_input.val().replace("," + last + ",", ","));
                                    if (values_input.val() == ",") {
                                        values_input.val("");
                                    }
                                    InputChange();
                                    opts.selectionRemoved.call(this, org_li.prev());
                                } else {
                                    opts.selectionClick.call(this, org_li.prev());
                                    org_li.prev().addClass("selected");
                                }
                            }
                            if (input.val().length == 1) {
                                results_holder.hide();
                                prev = "";
                            }
                            if ($(":visible", results_holder).length > 0) {
                                if (timeout) { clearTimeout(timeout); }
                                timeout = setTimeout(function() { keyChange(); }, opts.keyDelay);
                            }
                            break;
                        case 9: case 188:  // tab or comma
                            if (opts.TabOpen) {
                                tab_press = true;
                                var i_input = input.val().replace(/(,)/g, "");
                                if (i_input != "" && values_input.val().search("," + i_input + ",") < 0 && i_input.length >= opts.minChars) {
                                    e.preventDefault();
                                    var n_data = {};
                                    n_data[opts.selectedItemProp] = i_input;
                                    n_data[opts.selectedValuesProp] = i_input;
                                    var lis = $("li", selections_holder).length;
                                    add_selected_item(n_data, "00" + (lis + 1));
                                    input.val("");
                                }
                            }
                            break;
                        case 13: // return
                            tab_press = false;
                            var active = $("li.active:first", results_holder);
                            if (active.length > 0) {
                                active.click();
                                results_holder.hide();
                            }
                            if (opts.neverSubmit || active.length > 0) {
                                e.preventDefault();
                            }
                            break;
                        default:
                            if (opts.showResultList) {
                                if (opts.selectionLimit && $("li.as-selection-item", selections_holder).length >= opts.selectionLimit) {
                                    results_ul.html('<li class="as-message">' + opts.limitText + '</li>');
                                    results_holder.show();
                                } else {
                                    if (timeout) { clearTimeout(timeout); }
                                    timeout = setTimeout(function() { keyChange(); }, opts.keyDelay);
                                }
                            }
                            break;
                    }
                };
                // Handle input field events
                input.focus(function() {
                    // && values_input.val() == ""
                    if ($(this).val() == opts.startText) {
                        $(this).val("");
                    } else if (input_focus) {
                        $("li.as-selection-item", selections_holder).removeClass("blur");
                        if ($(this).val() != "") {
                            results_ul.css("width", selections_holder.outerWidth());
                            results_holder.show();
                        }
                    }
                    input_focus = true;
                    return true;
                }).blur(function() {
                    if ($(this).val() == "" && values_input.val() == "" && prefill_value == "") {
                        $(this).val(opts.startText);
                    } else if (input_focus) {
                        $("li.as-selection-item", selections_holder).addClass("blur").removeClass("selected");
                        results_holder.hide();
                    }
                });
                AttachEvent("propertychange", input.get(0), keyfunction);
                var prePopulateFun = function () {
                    var idvalue = new Array();
                    for (var i in opts.prePopulate) {
                        for (var j in org_data) {
                            if (org_data[j].value == opts.prePopulate[i]) {
                                idvalue.push(decodeURIComponent(org_data[j].value));
                                var n_data = {};
                                n_data[opts.selectedItemProp] = org_data[j].name;
                                n_data[opts.selectedValuesProp] = org_data[j].value;
                                var lis = $("li", selections_holder).length;
                                add_selected_item(n_data, "00" + (lis + 1));
                                input.val(opts.startText);
                            }
                        }
                    }
                    if (idvalue.length > 0) {
                        values_input.val("," + idvalue.join(",") + ",");
                    } else {
                        values_input.val("");
                    }
                }
                if (opts.prePopulate && opts.prePopulate.length > 0 && opts.prePopulate[0].length>0) {
                    if (!opts.ReadAll) {
                        if (d_type == "string") {
                            selections_holder.addClass("loading");
                            $.ajax({
                                type: "GET",
                                url: req_string + (req_string.indexOf("?") == -1 ? "?" : "&") + "v=" + opts.prePopulate,
                                cache: false,
                                timeout: 600000000,
                                dataType: "html",
                                success: function(html) {
                                    var data = parseObj("[" + html + "]");
                                    d_count = 0;
                                    org_data = opts.retrieveComplete.call(this, data);
                                    for (k in org_data) if (org_data.hasOwnProperty(k)) d_count++;
                                    selections_holder.removeClass("loading");
                                    prePopulateFun();
                                }
                            });
                        }
                    }
                    prePopulateFun();
                };
                function keyChange() {
                    // ignore if the following keys are pressed: [del] [shift] [capslock]
                    if (lastKeyPressCode == 46 || (lastKeyPressCode > 8 && lastKeyPressCode < 32)) { return results_holder.hide(); }
                    var string = input.val().replace(/[\\]+|[\/]+/g, "");
                    var last = valLength();
                    if (parseInt(opts.maxLength) > 0 && last >= parseInt(opts.maxLength)) {
                        results_holder.html(results_ul.html('<li class="as-message">只能输入' + opts.maxLength + '个</li>')).hide();
                        return;
                    }
                    if (string == prev) return;
                    prev = string;
                    if (string.length >= opts.minChars) {
                        selections_holder.addClass("loading");
                        if (d_type == "string" && !opts.ReadAll) {
                            var limit = "";
                            if (opts.retrieveLimit) {
                                limit = "&limit=" + encodeURIComponent(opts.retrieveLimit);
                            }
                            if (opts.beforeRetrieve) {
                                string = opts.beforeRetrieve.call(this, string);
                            }
                            $.ajax({
                                type: "GET",
                                url: req_string + (req_string.indexOf("?") == -1 ? "?" : "&") + opts.queryParam + "=" + encodeURIComponent(string) + limit + opts.extraParams + (opts.queryName && opts.queryInputName ? ("&" + opts.queryName + "=" + ReadInputValue(null, null, null, null, opts.queryInputName).replace(opts.queryInputName+"=","")) : ""),
                                cache: false,
                                timeout: 600000000,
                                dataType: "html",
                                success: function(html) {
                                    var data = parseObj("[" + html + "]");
                                    d_count = 0;
                                    selections_holder.removeClass("loading");
                                    var new_data = opts.retrieveComplete.call(this, data);
                                    for (k in new_data) if (new_data.hasOwnProperty(k)) d_count++;
                                    processData(new_data, string);
                                }
                            });
                        } else {
                            if (opts.beforeRetrieve) {
                                string = opts.beforeRetrieve.call(this, string);
                            }
                            processData(org_data, string);
                            selections_holder.removeClass("loading");
                        }
                    } else {
                        results_holder.hide();
                    }
                }
                var num_count = 0;
                function processData(data, query) {
                    if (!opts.matchCase) { query = query.toLowerCase(); }
                    if (query == opts.startText) {
                        query = "";
                    }
                    if (query.length == 0) {
                        return "";
                    }
                    query = query.replace(new RegExp("•", "img"), "·");
                    var matchCount = 0;
                    results_holder.html(results_ul.html("")).hide();
                    for (var i = 0; i < d_count; i++) {
                        var num = i;
                        num_count++;
                        var forward = false;
                        if (opts.searchObjProps == "value") {
                            var str = data[num].value;
                        } else {
                            var str = "";
                            var names = opts.searchObjProps.split(",");
                            for (var y = 0; y < names.length; y++) {
                                var name = $.trim(names[y]);
                                str = str + data[num][name] + " ";
                            }
                        }
                        if (str) {
                            if (!opts.matchCase) { str = str.toLowerCase(); }
                            if (str.search(query) != -1 && values_input.val().search("," + data[num][opts.selectedValuesProp] + ",") == -1) {
                                forward = true;
                            }
                        }
                        if (forward) {
                            var formatted = $('<li class="as-result-item" id="as-result-item-' + num + '"></li>').click(function() {
                                var raw_data = $(this).data("data");
                                var number = raw_data.num;
                                if ($("#as-selection-" + number, selections_holder).length <= 0 && !tab_press) {
                                    var data = raw_data.attributes;
                                    input.val("").focus();
                                    prev = "";
                                    add_selected_item(data, number);
                                    opts.resultClick.call(this, raw_data);
                                    results_holder.hide();
                                }
                                tab_press = false;
                            }).mousedown(function() { input_focus = false; }).mouseover(function() {
                                $("li", results_ul).removeClass("active");
                                $(this).addClass("active");
                            }).data("data", { attributes: data[num], num: num_count });
                            var this_data = $.extend({}, data[num]);
                            if (!opts.matchCase) {
                                var regx = new RegExp("(?![^&;]+;)(?!<[^<>]*)(" + query + ")(?![^<>]*>)(?![^&;]+;)", "gi");
                            } else {
                                var regx = new RegExp("(?![^&;]+;)(?!<[^<>]*)(" + query + ")(?![^<>]*>)(?![^&;]+;)", "g");
                            }

                            if (opts.resultsHighlight) {
                                this_data[opts.selectedItemProp] = this_data[opts.selectedItemProp].replace(regx, "<em>$1</em>");
                            }
                            if (!opts.formatList) {
                                formatted = formatted.html(this_data[opts.selectedItemProp]);
                            } else {
                                formatted = opts.formatList.call(this, this_data, formatted);
                            }
                            results_ul.append(formatted);
                            delete this_data;
                            matchCount++;
                            if (opts.retrieveLimit && opts.retrieveLimit == matchCount) { break; }
                        }
                    }
                    selections_holder.removeClass("loading");
                    if (matchCount <= 0) {
                        results_ul.html('<li class="as-message">' + opts.emptyText + '</li>');
                    }
                    results_ul.css("width", selections_holder.outerWidth());
                    results_holder.show();
                    opts.resultsComplete.call(this);
                }

                function add_selected_item(data, num) {
                    var val = values_input.val();
                    if (val.search(","+data[opts.selectedValuesProp]+",") == -1) {
                        values_input.val(val + (val.length == 0 ? "," : "") + data[opts.selectedValuesProp] + ",");
                    }
                    InputChange();
                    var item = $('<li class="as-selection-item" value="'+encodeURIComponent(data[opts.selectedValuesProp])+'" id="as-selection-' + num + '"></li>').click(function() {
                        opts.selectionClick.call(this, $(this));
                        selections_holder.children().removeClass("selected");
                        $(this).addClass("selected");
                    }).mousedown(function () { input_focus = false; });
                    if (opts.isdel) {
                        var close = $('<a class="as-close">&times;</a>').click(function () {
                            values_input.val(values_input.val().replace("," + data[opts.selectedValuesProp] + ",", ","));
                            if (values_input.val() == ",") {
                                values_input.val("");
                            }
                            InputChange();
                            opts.selectionRemoved.call(this, item);
                            input_focus = true;
                            input.focus();
                            return false;
                        });
                        org_li.before(item.html(data[opts.selectedItemProp]).prepend(close));
                    } else {
                        org_li.before(item.html(data[opts.selectedItemProp]));
                    }
                    opts.selectionAdded.call(this, org_li.prev());
                    InputSortTable();
                }

                function moveSelection(direction) {
                    if ($(":visible", results_holder).length > 0) {
                        var lis = $("li", results_holder);
                        if (direction == "down") {
                            var start = lis.eq(0);
                        } else {
                            var start = lis.filter(":last");
                        }
                        var active = $("li.active:first", results_holder);
                        if (active.length > 0) {
                            if (direction == "down") {
                                start = active.next();
                            } else {
                                start = active.prev();
                            }
                        }
                        lis.removeClass("active");
                        start.addClass("active");
                    }
                }

            });
        }
    }
})(jQuery);  	