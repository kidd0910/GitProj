var LOGIN = new Vue({
    el: '#LOGIN',
    data: function () {
        // 產生 data 結構
        var data = {
            view: false,
            init: false,
            controller: 'LOGIN',
            actions: {},
            button: {},
            options: {},
            formview: true,
            form: {},
            grid: {},
            confirm: { show: false },
            message: 'This is demo page'
        };
        // url
        data.actions = {
            QueryGrid: data.controller + '/QueryGrid',
            Export: data.controller + '/Export',
            Print: data.controller + '/Print'
        };
        // button 操作權限設定
        //data.button = {
        //    BTN_QRY: { operate: '' },
        //    BTN_EXPORT: { operate: '' },
        //    BTN_PRINT: { operate: '' },
        //    BTN_CLEAR: { operate: '' }
        //};
        // 按鈕 model
        //data.button = BaseUtil.CreateButtonModel(data.button);
        // grid model
        data.grid = {
            datas: '',
            paginaiton: {
                pages: [], pageNo: '', pageSize: '', totalCount: ''
            }
        };
        return data;
    },
    methods: {
        doInit: function () {
            var self = this;
            //form.message.info = 'aaaaaa';
            //if (!self.init) {
            //    BaseUtil.CreateFormModel(self.form, ['SEND_ORG_ID', 'SEND_ORG_NAME']);
            //    AuthUtil.GetButtonUsed(self.controller, self.button);
            //    self.init = true;
            //}
        
        },
        goUrlPage: function (url) {
            BaseUtil.DoHref(BASE_ROOT_URL + url);
        },
        doLogin: function () {
            var url = "Home/Bulltin";//"EXP";
            BaseUtil.DoHref(BASE_ROOT_URL + url);
        }
        //doQuery: function (type) {
        //    var self = this;
        //    // 驗證必填
        //    if (!BaseUtil.Validation(self.form)) {
        //        return;
        //    }
        //    // 分頁觸發
        //    if (type != 'reQuery') {
        //        self.grid.paginaiton.pageNo = 1;
        //    }
        //    // get postdata
        //    var postData = BaseUtil.GetPostData(self.form);
        //    // set 分頁資訊
        //    postData['paginaiton'] = BaseUtil.GetPaginaiton(self.grid.paginaiton);

        //    var requestOption = {
        //        url: self.actions.QueryGrid,
        //        data: { model: postData },
        //        success: function (data) {
        //            // 置入資料、分頁資訊、清除欄位狀態
        //            self.grid.datas = [];
        //            BaseUtil.CreateGridDatas(self.grid.datas, data.gridDatas);
        //            self.grid.paginaiton = data.paginaiton;

        //            BaseUtil.AddGridDatas(self.grid.datas, 'detailLabel', '支票抬頭');
        //        }
        //    };
        //    BaseUtil.Ajax(requestOption);
        //},
        //reQuery: function (emitData) {
        //    var self = this;
        //    if (emitData != undefined) {
        //        self.grid.paginaiton = emitData.paginaiton;
        //    }
        //    self.doQuery('reQuery');
        //},
        //doExport: function () {
        //    var self = this;
        //    // get postdata
        //    var postData = BaseUtil.GetPostData(self.form);
        //    var requestOption = {
        //        url: self.actions.Export,
        //        data: { model: postData },
        //        success: function (datas) {
        //            // 顯示訊息
        //            if (datas.message != '') {
        //                alert(datas.message);
        //            } else {
        //                // 無錯誤訊息才觸發下載
        //                // 指定controller則action預設[BaseDownload]由底層action執行
        //                // 指定url則由該action執行
        //                //$.DoDownload({
        //                //     controller: self.controller,
        //                //url: self.Download,
        //                //    data: datas
        //                //});
        //                BaseUtil.Download({
        //                    controller: self.controller,
        //                    //url: self.Download,
        //                    data: datas
        //                });
        //            }
        //        }
        //    };
        //    BaseUtil.Ajax(requestOption);
        //},
        //doPrint: function () {
        //    var self = this;
        //    // get postdata
        //    var postData = BaseUtil.GetPostData(self.form);
        //    // 開啟報表視窗
        //    BaseUtil.OpenWindow({
        //        url: self.actions.Print,
        //        data: postData
        //    });
        //},
        //doDetail: function (index) {
        //    var self = this;
        //    var postData = {
        //        SEND_ORG_ID: self.grid.datas[index].SEND_ORG_ID.value,
        //        SEND_ORG_NAME: self.grid.datas[index].SEND_ORG_NAME.value
        //    }
        //    // 切頁參數view
        //    TPKA0101F_PAGE2.doDetail(postData);
        //    self.view = false;
        //    TPKA0101F_PAGE2.view = true;
        //},
        //doClear: function () {
        //    var self = this;
        //    // 清除資料、驗證訊息
        //    BaseUtil.ClearForm(self.form);
        //},
        //doViewTableForm: function () {
        //    var self = this;
        //    if (self.formview) {
        //        self.formview = false;
        //    } else {
        //        self.formview = true;
        //    }
        //},
        //confirmClose: function (emitData) {
        //    var self = this;
        //    // 關閉提示視窗
        //    self.confirm.show = false;
        //    if (emitData != undefined) {
        //        if (emitData.even == 'even') {
        //        }
        //    }
        //}
    }
});