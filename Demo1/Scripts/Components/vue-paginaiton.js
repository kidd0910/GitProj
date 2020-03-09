Vue.component('vue-paginaiton', {
    //template: '#vue-paginaiton',
    template:
'<div>' +
    '<span v-for="pageNo in paginaiton.pages" v-on:click="gotoPage(pageNo)">' +
        '<label class="pageNo-nosel" v-if="paginaiton.pageNo != pageNo">' +
            '{{ pageNo }}' +
        '</label>' +
        '<label class="pageNo-sel" v-else>' +
            '{{ "[" + pageNo + "]" }}' +
        '</label>&nbsp;' +
    '</span>' +
    '<span>' +
    '【每頁&nbsp;<input type="text" maxlength="3" style="width: 30px; text-align: center" name="pageSize" :value="paginaiton.pageSize" v-on:change="onchange" />' +
    '&nbsp;<button class="page-btn" v-on:click="gotoPage()">筆</button>，' +
    '第&nbsp;<input type="text" maxlength="3" style="width: 30px; text-align: center;" name="pageNo" :value="paginaiton.pageNo" v-on:change="onchange" />' +
    '&nbsp;<button class="page-btn" v-on:click="gotoPage()">頁</button>，' +
    '共 {{paginaiton.totalPage}} 頁 {{paginaiton.totalCount}} 筆】' +
    '</span>' +
'</div>'
    ,
    props: ['paginaiton'],
    methods: {
        gotoPage: function (pageNo) {
            var self = this;
            // console.log(self.value.pageNo)
            // 是否有傳入指定頁數
            if (pageNo != undefined) {
                if (pageNo == '<') {
                    self.paginaiton.pageNo = parseInt(self.paginaiton.pageNo) - 1;
                } else if (pageNo == '>') {
                    self.paginaiton.pageNo = parseInt(self.paginaiton.pageNo) + 1;
                } else if (pageNo == '<<') {
                    self.paginaiton.pageNo = (Math.floor((parseInt(self.paginaiton.pageNo) - 10) / 10) * 10 + 1);
                } else if (pageNo == '>>') {
                    self.paginaiton.pageNo = (Math.floor((parseInt(self.paginaiton.pageNo) + 10) / 10) * 10 + 1);
                } else {
                    self.paginaiton.pageNo = pageNo;
                }
            }
            // 指定頁數為0，自動變更為1
            self.paginaiton.pageNo =
                parseInt(self.paginaiton.pageNo) == 0
                    ? 1 : self.paginaiton.pageNo;
            // 指定頁數大於總頁數，自動變更為總頁數
            self.paginaiton.pageNo =
                parseInt(self.paginaiton.pageNo) > parseInt(self.paginaiton.totalPage)
                    ? self.paginaiton.totalPage : self.paginaiton.pageNo;
            // 指定筆數為0，自動變更為1
            self.paginaiton.pageSize =
                parseInt(self.paginaiton.pageSize) == 0
                    ? 1 : self.paginaiton.pageSize;
            // call on even
            this.$emit('requery', { paginaiton: self.paginaiton });
        },
        onchange: function (e) {
            /*
            console.log(e.target.type);
            console.log(e.target.name);
            console.log(e.target.value);
            console.log(e.target.checked);
            */
            var self = this;
            self.paginaiton[e.target.name] = e.target.value;
        }
    }
});