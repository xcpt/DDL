$.fn.enable_changed_form = function () {
    $(":text, :password, textarea", this).each(function () {
        if ($(this).attr("Change") != "OFF") {
            $(this).attr('_value', $(this).val());
        }
    });
    $(':checkbox, :radio', this).each(function() {
        var _v = this.checked ? 'on' : 'off';
        $(this).attr('_value', _v);
    });
    $("select[Change!='OFF']", this).each(function () {
        if (this.selectedIndex!="undefined" && this.selectedIndex != -1) {
            $(this).attr('_value', this.selectedIndex);
        }
    });
    return this;
}
$.fn.is_form_changed = function () {
    var changed = false;
    $(":text, :password, textarea", this).each(function () {
        if ($(this).attr("Change") != "OFF") {
            var _v = $(this).attr('_value');
            if (typeof (_v) != 'undefined' && _v != $(this).val()) changed = true;
        }
    });
    if (!changed) {
        $(':checkbox, :radio', this).each(function () {
            var _v = this.checked ? 'on' : 'off';
            if (typeof (_v1) != 'undefined' && _v != _v1) changed = true;
        });
        if (!changed) {
            $("select[Change!='OFF']", this).each(function () {
                var _v = $(this).attr('_value');
                if (typeof (_v) != 'undefined' && _v != this.selectedIndex) changed = true;
            });
        }
    }
    return changed;
};