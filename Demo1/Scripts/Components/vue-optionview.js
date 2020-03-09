Vue.component('vue-optionview', {
    //template: '#vue-optionview',
    template:
'<div class="optionview-mask" v-show="optionview.show">' +
	'<div class="optionview-wrapper">' +
		'<div class="optionview-container">' +
            '<div class="page-div">' +
                '<div class="query-div div-radius">' +
                    '<table class="table-control" border="0" align="center" cellpadding="0" cellspacing="0">' +
                        '<tr>' +
                            '<td class="table-control-button">' +
                                '<button class="page-btn" v-operate="button.BTN_ADD" v-on:click="doQuery()">查詢</button>' +
                                '<button class="page-btn" v-operate="button.BTN_ADD" v-on:click="doClose()">關閉</button>' +
                            '</td>' +
                        '</tr>' +
                    '</table>' +
                    '<table class="table-form" border="0" align="center" cellpadding="0" cellspacing="0" v-if="form !== undefined">' +
                        '<tr>' +
                            '<td align="right" width="10%">代碼：</td>' +
                            '<td align="left" width="40%">' +
                                '<input type="text" v-model.lazy="form.value" />' +
                            '</td>' +
                            '<td align="right" width="10%">名稱：</td>' +
                            '<td align="left" width="40%">' +
                                '<input type="text" v-model.lazy="form.text" />' +
                            '</td>' +
                        '</tr>' +
                    '</table>' +
                '</div>' +
                '<div class="grid-table-no div-radius" v-if="gridData.length === 0">' +
                    '查無符合資料' +
                '</div>' +
                '<div class="grid-table-div div-radius" v-if="gridData.length > 0">' +
                    '<table class="grid-table" border="1" cellpadding="0" cellspacing="0">' +
                        '<tr>' +
                            '<th style="width: 60px;">帶回</th>' +
                            '<th style="min-width: 50px;">代碼</th>' +
                            '<th style="min-width: 50px;">名稱</th>' +
                        '</tr>' +
                        '<tr v-for="(data, index) in gridData">' +
                            '<td><label class="label-link-enabled" v-on:click="doBackData(index)">帶回</label></td>' +
                            '<td>{{data.value}}</td>' +
                            '<td>{{data.text}}</td>' +
                        '</tr>' +
                    '</table>' +
                '</div>' +
            '</div>' +
		'</div>' +
	'</div>' +
'</div>'
    ,
    props: ['optionview'],
    data: function () {
        var data = {
            button: {},
            form: {
                value: '',
                text: ''
            },
            selCheck: false,
            gridData: []
        };
        // button 操作權限設定
        data.button = {
            BTN_QRY: { operate: '' },
            BTN_BACKDATA: { operate: '' },
            BTN_CLOSE: { operate: '' }
        };
        data.button = BaseUtil.CreateButtonModel(data.button);
        return data;
    },
    created: function () {
        var self = this;
    },
    methods: {
        doQuery: function () {
            var self = this;

            // 無[url]則預設呼叫[Option]，無[action]則預設[GetADMT021]
            if (self.optionview.url == undefined || self.optionview.url == '') {
                if (self.optionview.action == undefined || self.optionview.action == '') {
                    self.optionview.url = 'Option/GetADMT021';
                } else {
                    self.optionview.url = 'Option/' + self.optionview.action;
                }
            }

            var requestOption = {
                url: self.optionview.url,
                data: {
                    model: {
                        key: self.optionview.key,
                        value: self.form.value,
                        text: self.form.text
                    }
                },
                success: function (data) {
                    self.gridData = data;
                }
            };
            BaseUtil.Ajax(requestOption);
        },
        doBackData: function (index) {
            var self = this;
            var postData = {
                value: self.gridData[index].value,
                text: self.gridData[index].text
            };
            self.$emit('optionviewclose', { even: self.optionview.even, data: postData });
        },
        doClose: function () {
            var self = this;
            self.$emit('optionviewclose');
        }
    },
    watch: {
        'optionview.show': function (val, oldVal) {
            //console.log('watch optionview.show : [' + val + '] -> [' + oldVal + ']');
            var self = this;
            if (val) {
                self.form.value = '';
                self.form.text = '';
                self.doQuery();
            }
        }
    }
});