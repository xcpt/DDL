$.fn.jclock = function (options) {
    $jclock = this;
    $jclock.timerID = null;
    $jclock.running = false;
    $jclock.el = null;
    $jclock.startClock = function () {
        $jclock.stopClock();
        $jclock.displayTime();
    }
    $jclock.stopClock = function () {
        if ($jclock.running) {
            clearTimeout(timerID);
        }
        $jclock.running = false;
    }
    $jclock.displayTime = function (el) {
        var date = $jclock.getDate();
        var week = $jclock.getWeek();
        var time = $jclock.getTime();
        $jclock.el.html(date + week + time);
        timerID = setTimeout(function () { $jclock.displayTime() }, 1000);
    }
    $jclock.getDate = function () {
        if ($jclock.defaults.withDate == true) {
            var now = new Date();
            var year, month, date;

            if ($jclock.defaults.utc == true) {
                year = now.getUTCFullYear();
                month = now.getUTCMonth() + 1;
                date = now.getUTCDate();
            } else {
                year = now.getFullYear();
                month = now.getMonth() + 1;
                date = now.getDate();
            }

            month = ((month < 10) ? "0" : "") + month;
            date = ((date < 10) ? "0" : "") + date;

            var dateNow = year + SycmsLanguage.Clock.jclock.l1 + month + SycmsLanguage.Clock.jclock.l2 + date + SycmsLanguage.Clock.jclock.l3;
        } else {
            var dateNow = "";
        }
        return dateNow;
    }
    $jclock.getWeek = function () {
        if ($jclock.defaults.withWeek == true) {
            var now = new Date();
            var week;

            if ($jclock.defaults.utc == true) {
                week = now.getUTCDay();
            } else {
                week = now.getDay();
            }

            $.each(SycmsLanguage.Clock.jclock.l4, function (i, n) {
                if (i == week) { week = n; return; }
            });

            var weekNow = SycmsLanguage.Clock.jclock.l5 + week + " ";
        } else {
            var weekNow = "";
        }
        return weekNow;
    }
    $jclock.getTime = function () {
        var now = new Date();
        var hours, minutes, seconds;

        if ($jclock.defaults.utc == true) {
            hours = now.getUTCHours();
            minutes = now.getUTCMinutes();
            seconds = now.getUTCSeconds();
        } else {
            hours = now.getHours();
            minutes = now.getMinutes();
            seconds = now.getSeconds();
        }

        if ($jclock.defaults.timeNotation == '12h') {
            hours = ((hours > 12) ? hours - 12 : hours);
        } else {
            hours = ((hours < 10) ? "0" : "") + hours;
        }

        minutes = ((minutes < 10) ? "0" : "") + minutes;
        seconds = ((seconds < 10) ? "0" : "") + seconds;

        var timeNow = hours + ":" + minutes + ":" + seconds;
        if (($jclock.defaults.timeNotation == '12h') && ($jclock.defaults.am_pm == true)) {
            timeNow += (hours >= 12) ? " P.M." : " A.M."
        }

        return timeNow;
    };

    // plugin defaults
    $jclock.defaults = {
        withDate: false,
        withWeek: false,
        timeNotation: '24h',
        am_pm: false,
        utc: false
    };

    return this.each(function () {
        $jclock.el = $(this);
        $jclock.defaults = $.extend({}, $jclock.defaults, options);
        $jclock.startClock();
    });
};