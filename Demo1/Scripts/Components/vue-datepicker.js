Vue.component('vue-datepicker', {
    //template: '#vue-datepicker', 
    template:
'<div class="wrapper" tabindex="-1" v-on:focus="focusDatepicker" v-on:focusout="focusoutDatepicker">' +
    '<input v-if="autotab === undefined" ref="input" type="text" maxlength="7" style="width: 80px;" v-control="value" v-model.lazy="value.value" validation="CDATE" v-on:focus="focusText" v-on:focusout="focusoutText"/>' +
    '<input v-if="autotab !== undefined" ref="input" type="text" maxlength="7" style="width: 80px;" v-autotab v-control="value" v-model.lazy="value.value" validation="CDATE" v-on:focus="focusText" v-on:focusout="focusoutText"/>' +
    '<div ref="calendar" class="datepicker-calendar" v-show="show">' +
        '<div class="datepicker-head">' +
            '<div class="datepicker-before" v-on:click="gobefore"></div>' +
            '<div class="datepicker-text-2"><span>民國</span></div>' +
            '<div class="datepicker-year">{{year}}</div>' +
            '<div class="datepicker-select" v-on:click="showyear"></div>' +
            '<div class="datepicker-text-1"><span>年</span></div>' +
            '<div class="datepicker-month">{{month}}</div>' +
            '<div class="datepicker-select" v-on:click="showmonth"></div>' +
            '<div class="datepicker-text-1"><span>月</span></div>' +
            '<div class="datepicker-after" v-on:click="goafter"></div>' +
        '</div>' +
        '<div class="datepicker-body">' +
            '<table v-if="type === 1">' +
                '<tr v-for="(years, index) in yearList">' +
                    '<td class="datepicker-year-td" v-for="(year, index) in years" v-on:click="clickyear(year.value)">' +
                    '{{year.text}}' +
                    '</td>' +
                '</tr>' +
            '</table>' +
            '<table v-if="type === 2">' +
                '<tr v-for="(months, index) in monthList">' +
                    '<td class="datepicker-month-td" v-for="(month, index) in months" v-on:click="clickmonth(month.value)">' +
                    '{{month.text}}' +
                    '</td>' +
                '</tr>' +
            '</table>' +
            '<table v-if="type === 3">' +
                '<tr>' +
                    '<th class="datepicker-day-th" v-for="(week, index) in weekList">' +
                    '{{week.text}}' +
                    '</th>' +
                '</tr>' +
                '<tr v-for="(days, index) in dayList">' +
                    '<td v-bind:class="getDayCss(day)" v-for="(day, index) in days" v-on:click="clickday(day.value)">' +
                    '{{day.text}}' +
                    '</td>' +
                '</tr>' +
            '</table>' +
        '</div>' +
        '<div class="datepicker-footer">' +
            '<div class="datepicker-footer-close" v-on:click="close">關閉</div>' +
        '</div>' +
    '</div>' +
'</div>'
    ,
    /*
        sdate: 起值檢核
        edate: 訖值檢核
    */
    props: ['autotab', 'value', 'sdate', 'edate'],
    data: function () {
        var monthList = [
            [
                { text: '一月', value: '1' },
                { text: '二月', value: '2' },
                { text: '三月', value: '3' }
            ],
            [
                { text: '四月', value: '4' },
                { text: '五月', value: '5' },
                { text: '六月', value: '6' },
            ],
            [
                { text: '七月', value: '7' },
                { text: '八月', value: '8' },
                { text: '九月', value: '9' },
            ],
            [
                { text: '十月', value: '10' },
                { text: '十一月', value: '11' },
                { text: '十二月', value: '12' }
            ]
        ];
        var weekList = [
            { text: '日' },
            { text: '一' },
            { text: '二' },
            { text: '三' },
            { text: '四' },
            { text: '五' },
            { text: '六' },
        ];
        var data = {
            type: 3,
            show: false,
            yearList: [],
            monthList: monthList,
            weekList: weekList,
            dayList: [],
            year: '',
            month: '',
            day: '',
            nowDate: '',
            msg: ''
        };
        return data;
    },
    created: function () {
        var self = this;
    },
    methods: {
        // 操作焦點
        focusDatepicker: function () {
            var self = this;
            if (!self.value.disabled) {
                self.show = true;
            }
        },
        // 離開操作焦點
        focusoutDatepicker: function () {
            var self = this;
            self.show = false;
        },
        // 操作焦點
        focusText: function (e) {
            var self = this;
            if (!self.value.disabled) {
                self.show = true;
                self.init();
            }
        },
        // 離開操作焦點
        focusoutText: function (e) {
            var self = this;
            self.show = false;
        },
        // 初始化
        init: function () {
            var self = this;
            // 初始化日曆
            if (!self.checkdate(self.value.value)) {
                var d = new Date();
                self.year = parseInt(d.getFullYear()) - 1911;
                self.month = parseInt(d.getMonth()) + 1;
                self.day = parseInt(d.getDate());
                self.nowDate = self.getDateString(self.year, self.month, self.day);
                if (self.value.value != '') {
                    self.value.message = '日期格式錯誤';
                }
            }
            self.getYearList();
            self.getDayList();
            self.showday();
            self.offset();
        },
        offset: function () {
            var self = this;
            // 控制顯示位置(顯示後控制位置)
            self.$nextTick(function () {
                // 取得元素實際位置
                var obj = self.$refs.input;
                var elementTop, elementLeft;
                elementTop = elementLeft = 0;
                if (obj.offsetParent) {
                    do {
                        elementTop += obj.offsetTop;
                        elementLeft += obj.offsetLeft;
                    } while (obj = obj.offsetParent);
                }
                // 元素相對位置
                var inputClientRect = self.$refs.input.getBoundingClientRect();
                //var calendarClientRect = self.$refs.calendar.getBoundingClientRect();
                // 輸入框元件大小
                var inputOffsetHeight = self.$refs.input.offsetHeight;
                var inputOffsetWidth = self.$refs.input.offsetWidth;
                // 日期元件大小
                var calendarOffsetHeight = self.$refs.calendar.offsetHeight;
                var calendarOffsetWidth = self.$refs.calendar.offsetWidth;
                
                // 垂直位置
                if (inputClientRect.bottom < (screen.height / 2)) {
                    self.$refs.calendar.style.top = (elementTop + inputOffsetHeight + 2) + 'px';
                } else {
                    self.$refs.calendar.style.top = (elementTop - calendarOffsetHeight) + 'px';
                }
                // 水平位置
                if ((elementLeft + calendarOffsetWidth) < (screen.width - 10)) {
                    self.$refs.calendar.style.left = (elementLeft - 2) + 'px';
                } else {
                    self.$refs.calendar.style.left = (elementLeft + inputOffsetWidth - calendarOffsetWidth) + 'px';
                }
            });
            
        },
        // 顯示日期樣式
        getDayCss: function (day) {
            var self = this;
            // day css
            if (day.value == '') { // 無日期值
                return 'datepicker-day-td-disable';
            } else if (day.value == self.nowDate) { // 等於今天日期
                return 'datepicker-now-day-td';
            } else if (day.value == self.value.value) { // 等於目前所選日期
                return 'datepicker-val-day-td';
            } else { // 其他
                return 'datepicker-day-td';
            }
        },
        // 取得年選項
        getYearList: function () {
            var self = this;
            var year = self.year;
            var yearList = [];
            var years = [];
            for (var i = parseInt(year) - 7; i < parseInt(year) + 8; i++) {
                if (i > 0) {
                    years.push({ text: (i + ''), value: i + '' });
                } else {
                    years.push({ text: ' ', value: '' });
                }
                if (years.length == 3) {
                    yearList.push(years);
                    years = [];
                }
            }
            self.yearList = yearList;
        },
        // 取得日期選項
        getDayList: function () {
            var self = this;
            var year = self.year, month = self.month;
            var dayList = [];
            var days = [];
            var lastDay = parseInt(new Date(year + 1911, month, 0).getDate());
            for (var i = 1; i <= lastDay; ++i) {
                if (i == 1) {
                    // set sapce
                    var week = new Date(year + 1911, month - 1, 1).getDay();
                    // week >> 日一二三四五六 : 0123456
                    for (var j = 0; j < week; ++j) {
                        days.push({ text: ' ', value: '' });
                    }
                }
                var dateString = self.getDateString(year, month, i);
                days.push({ text: i + '', value: dateString });
                if (days.length == 7) {
                    dayList.push(days);
                    days = [];
                }
            }
            // set space
            if (days.length > 0) {
                for (var i = days.length; i < 7; ++i) {
                    days.push({ text: ' ', value: '' });
                }
                dayList.push(days);
            }
            self.dayList = dayList;
           // self.offset();
        },
        // 取得日期字串
        getDateString: function (year, month, day) {
            var dateString = year.toString() + '';
            for (var i = year.toString().length; i < 3 ; ++i) {
                dateString = '0' + dateString;
            }
            dateString += (parseInt(month) < 10 ? ('0' + month) : ('' + month))
            dateString += (parseInt(day) < 10 ? ('0' + day) : ('' + day));
            return dateString;
        },
        // 顯示選擇年
        showyear: function () {
            var self = this;
            self.type = 1;
            //self.offset();
        },
        // 顯示選擇月
        showmonth: function () {
            var self = this;
            self.type = 2;
            //self.offset();
        },
        // 顯示選擇日
        showday: function () {
            var self = this;
            self.type = 3;
            //self.offset();
        },
        // 前一頁
        gobefore: function () {
            var self = this;
            if (self.type == 1) {
                if (parseInt(self.year) - 15 > 0) {
                    self.year = parseInt(self.year) - 15;
                    self.getYearList();
                }
            } else if (self.type == 2) {
                if (parseInt(self.year) - 1 > 0) {
                    self.year = parseInt(self.year) - 1;
                    self.getYearList();
                }
            } else if (self.type == 3) {
                self.month = parseInt(self.month) - 1;
                if (self.month < 1) {
                    self.year = parseInt(self.year) - 1;
                    self.month = 12;
                }
            }
            self.getDayList();
        },
        // 後一頁
        goafter: function () {
            var self = this;
            if (self.type == 1) {
                self.year = parseInt(self.year) + 15;
                self.getYearList();
            } else if (self.type == 2) {
                self.year = parseInt(self.year) + 1;
                self.getYearList();
            } else if (self.type == 3) {
                self.month = parseInt(self.month) + 1;
                if (self.month > 12) {
                    self.year = parseInt(self.year) + 1;
                    self.month = 1;
                }
            }
            self.getDayList();
        },
        // 選擇年
        clickyear: function (year) {
            var self = this;
            if (year != '') {
                self.showmonth();
                self.year = parseInt(year);
                self.getYearList();
                self.getDayList();
            }
        },
        // 選擇月
        clickmonth: function (month) {
            var self = this;
            if (month != '') {
                self.showday();
                self.month = parseInt(month);
                self.getDayList();
            }
        },
        // 選擇日
        clickday: function (day) {
            var self = this;
            if (day != '') {
                //day = self.checkInterval(day);
                self.value.value = day;
                self.show = false;
                // for autotab keyup even
                if (self.autotab != undefined && self.$refs.input.onkeyup != null) {
                    // 更新後觸發 
                    self.$nextTick(function () {
                        self.$refs.input.onkeyup(self.$refs.input);
                    });
                }
            }
        },
        // 關閉
        close: function () {
            var self = this;
            self.show = false;
        },
        // 檢核日期格式
        checkdate: function (dateStr) {
            var self = this;
            if (dateStr != undefined && dateStr.length == 7 && parseInt(dateStr) > 0) {
                // check date is true
                var myYear = parseInt(dateStr.substring(0, 3));
                var myMonth = parseInt(dateStr.substring(3, 5));
                var myDay = parseInt(dateStr.substring(5, 7));
                var myDate = new Date(myYear + 1911, myMonth - 1, myDay);
                var check = true;
                if ((myDate.getFullYear() - 1911 != myYear)
                    || (myDate.getMonth() + 1 != myMonth)
                    || (myDate.getDate() != myDay)) {
                    check = false;
                }
                if (check && myYear > 0 && myMonth > 0 && myDay > 0) {
                    self.year = myYear;
                    self.month = myMonth;
                    self.day = myDay;
                    return true;
                }
                return false;
            }
            return false;
        },
        // 驗證起訖區間
        checkInterval: function (day) {
            /*
            var self = this;
            var msg = ''
            if (self.sdate != undefined && self.sdate != '') {
                if (day < self.sdate) {
                    msg = '訖值不可小於起值';
                }
            }
            if (self.edate != undefined && self.edate != '') {
                if (day > self.edate) {
                    msg = '起值不可大於訖值';
                }
            }
            */
            return day;
        }
    }
});