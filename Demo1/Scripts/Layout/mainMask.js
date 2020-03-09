// 顯示訊息遮罩用
var MAIN = new Vue({
    el: '#MainMask',
    data: function () {
        var data = {
            mask: {
                show: false,
                message: 'message'
            },
            message: {
                show: false,
                message: 'message'
            },
            USER_KIND: '',
            USER_KIND_LIST: []
        }
        return data;
    },
    methods: {
        showProcess: function (message) {
            if (message == undefined) {
                message = '處理中...';
            }
            var self = this;
            self.mask = {
                show: true,
                message: message
            };
        },
        // 關閉遮罩
        hideProcess: function () {
            var self = this;
            // after 1 second close
            self.mask = {
                show: false
            };
        },
        // 顯示訊息
        showMessage: function (message) {
            var self = this;
            self.message = {
                show: true,
                message: message
            };
            // after 2 second close
            setTimeout(function () {
                self.message = {
                    show: false
                };
            }, 2000);
        }
    }
});