var EXPL100_PAGE1 = new Vue({
    el: '#BULLITIN',
    data: function () {
        // 產生 data 結構
        // view: 畫面狀態
        // init: 初始化狀態
        // actions: url
        // button: 按鈕model
        // panel: 區塊model
        // options: 選項
        // formview: 顯示/隱藏 查詢條件
        // form: 查詢畫面對應model
        // grid: 查詢結果對應model
        // confirm: 提示確認/取消視窗
        var data = {
            view: false,
            init: false,
            controller: 'Home',
            actions: {},
            button: {},
            panel: {},
            options: {},
            formview: true,
            form: {},
            grid: {},
            confirm: { show: false }
        };
        // url
        data.actions = {
            Page: data.controller + '/Bullitin',
            //QueryGrid: data.controller + '/QueryGrid',
            //Delete: data.controller + '/Delete',
            //Export: data.controller + '/Export',
            //Print: data.controller + '/Print'
        };
        // button 操作權限設定
        data.button = {
            BTN_BACK: { operate: '' },
            BTN_QRY: { operate: '' },
            BTN_EXPORT: { operate: '' },
            BTN_PRINT: { operate: '' },
            BTN_ADD: { operate: 'E' },
            BTN_DEL: { operate: 'E' },
            BTN_CLEAR: { operate: '' }
        };
        // 按鈕 model
        // operate:    操作種類
        // uesd:       是否可用
        // disabled:   停用狀態
        // display:    隱藏狀態
        data.button = BaseUtil.CreateButtonModel(data.button);
        // 區塊操作控制
        data.panel = {
            COL_PANEL: { userKind: '' }
        };
        // 區塊 model
        // userKind:   身分別
        // uesd:       是否可用
        // display:    隱藏狀態
        data.panel = BaseUtil.CreatePanelModel(data.panel);
        // 取得所有選項model
        data.options = {
            COL_D: []
        };
        // grid model
        // head: 表頭控制項 (全選/取消全選)
        // datas: 資料對應
        // watch: 動態監聽
        // status: 欄位狀態 (disabled:true/false, display:true/false)
        // paginaiton: 分頁model (pages:操作頁碼, pageNo:目前頁碼, pageSize:每頁大小, totalCount:總筆數)
        data.grid = {
            head: {
                selCheck: false
            },
            datas: undefined,
            paginaiton: {
                pages: [], pageNo: '', pageSize: '', totalCount: ''
            }
        };
        // confirm sample
        //confirm: {
        //    show: false,            // 顯示
        //    message: 'message',     // 訊息
        //    even: 'even',           // 確認後觸發事件
        //    ok: 'ok',               // 確認按鈕文字
        //    cancel: 'cancel',       // 取消按鈕文字
        //    autoClose: false        // 自動關閉
        //}
        return data;
    },
    methods: {
        // 初始化
        doInit: function () {
            var self = this;
            if (!self.init) {
                // 產生欄位控制項
                // 產生選項
                // 自訂義 (model不由後端取得)
                // >> data.form = BaseUtil.CreateFormModel(['A','B'...]);
                // 系統定義 (model由後端取得)
                var requestOption = {
                    url: self.actions.Page,
                    data: {},
                    success: function (datas) {
                        // 產生欄位控制項
                        // 產生欄位 model
                        // value:      資料內容
                        // required:   必填欄位
                        // disabled:   停用狀態
                        // display:    隱藏狀態
                        // message:    驗證訊息
                        // 加入其他欄位 >> datas.formColumns.push('XXX', ...);
                        //datas.formColumns.push('COL_E', 'COL_F', 'COL_G', 'COL_H', 'COL_I', 'COL_J');
                        BaseUtil.CreateFormModel(self.form, datas.formColumns);
                        //self.form.COL_A.display = false;
                        //self.form.COL_B.display = false;
                        //self.form.COL_C.display = false;
                        //self.form.COL_D.display = false;
                        /*
                        self.form.COL_A.required = true;
                        self.form.COL_B.required = true;
                        self.form.COL_C.required = true;
                        self.form.COL_D.required = true;
                        self.form.COL_E.required = true;
                        self.form.COL_F.required = true;
                        self.form.COL_G.required = true;
                        self.form.COL_H.required = true;
                        self.form.COL_I.required = true;
                        self.form.COL_J.required = true;
                        */
                        // 指定型態，預設字串
                        //self.form.COL_G.value = true;
                        //self.form.COL_H.value = [];
                        //self.form.COL_I.value = [];
                        self.form.MESSAGE.value = "From JS Bullitin message";
                        // 產生選項
                        //self.options.COL_D = datas.COL_D;
                        // 按鈕權限
                        // AuthUtil.GetButtonUsed(self.controller, self.button);
                        // 初始化完成
                        self.init = true;
                    }
                };
                BaseUtil.Ajax(requestOption);
            }
        },
        // 查詢
        doQuery: function (type) {
            var self = this;
            // 驗證必填
            if (!BaseUtil.Validation(self.form)) {
                alert('必填欄位未輸入');
                return;
            }

            // 分頁觸發
            if (type != 'reQuery') {
                self.grid.paginaiton.pageNo = 1;
            }
            // get postdata
            var postData = BaseUtil.GetPostData(self.form);
            // set 分頁資訊
            postData['paginaiton'] = BaseUtil.GetPaginaiton(self.grid.paginaiton);

            BaseUtil.OpenWindow({
                url: 'EXPL100'
            });

            var requestOption = {
                url: self.actions.QueryGrid,
                data: { model: postData },
                success: function (data) {
                    // 清除表頭控制項
                    self.doResetGridHead();
                    // 置入資料、分頁資訊、清除欄位狀態
                    self.grid.datas = [];
                    BaseUtil.CreateGridDatas(self.grid.datas, data.gridDatas);
                    self.grid.paginaiton = data.paginaiton;
                    // 加入其他控制元件
                    BaseUtil.AddGridDatas(self.grid.datas, 'selCheck', false);
                    BaseUtil.AddGridDatas(self.grid.datas, 'editLabel', '編');

                    // 表頭凍結，須執行GridFixedHead
                    if (self.grid.datas.length > 0) {
                        self.$nextTick(function () {
                            BaseUtil.GridFixedHead(self.$refs.gridhead, self.$refs.gridbody, self.$refs.gridscrollbar);
                        });
                    }
                }
            };
            BaseUtil.Ajax(requestOption);
        },
        // 新增
        doAdd: function () {
            var self = this;
            // 切頁參數view
            EXPL100_PAGE2.doAdd();
            self.view = false;
            EXPL100_PAGE2.view = true;
        },
        // 編輯
        doEdit: function (index) {
            var self = this;
            var postData = {
                PKNO: self.grid.datas[index].PKNO.value
            }
            // 切頁參數view
            EXPL100_PAGE2.doEdit(postData);
            self.view = false;
            EXPL100_PAGE2.view = true;
        },
        // 刪除確認
        doCheckDelete: function () {
            var self = this;
            var pknos = [];
            var isCheck = false;
            for (var i in self.grid.datas) {
                if (self.grid.datas[i].selCheck.value) {
                    isCheck = true;
                    break;
                }
            }
            if (!isCheck) {
                // 提示訊息
                alert('未勾選資料');
            } else {
                // 提示確認訊息
                self.confirm = {
                    show: true,
                    message: '確定刪除資料?',
                    even: 'delete',
                    ok: '確認',
                    cancel: '取消'
                };
            }
        },
        // 刪除
        doDelete: function (check) {
            var self = this;
            var pknos = [];
            for (var i in self.grid.datas) {
                if (self.grid.datas[i].selCheck.value) {
                    pknos.push(self.grid.datas[i].PKNO.value);
                    // 檢核股別
                    // AuthUtil.CheckDeptNo('DEPT_NO');
                }
            }

            var requestOption = {
                url: self.actions.Delete,
                data: { model: pknos },
                success: function (data) {
                    // 顯示訊息
                    alert('刪除完成');
                    self.reQuery();
                }
            };
            BaseUtil.Ajax(requestOption);
        },
        // 分頁查詢
        reQuery: function (emitData) {
            var self = this;
            if (emitData != undefined) {
                self.grid.paginaiton = emitData.paginaiton;
            }
            // 有查詢過才執行(處理回上一頁觸發自動查詢)
            if (self.grid.datas != undefined) {
                self.doQuery('reQuery');
            }
        },
        // 匯出
        doExport: function () {
            var self = this;
            // get postdata
            var postData = BaseUtil.GetPostData(self.form);
            var requestOption = {
                url: self.actions.Export,
                data: { model: postData },
                success: function (datas) {
                    // 顯示訊息
                    if (datas.message != '') {
                        alert(datas.message);
                    } else {
                        // 無錯誤訊息才觸發下載
                        // 指定controller則action預設[BaseDownload]由底層action執行
                        // 指定url則由該action執行
                        //$.DoDownload({
                        //     controller: self.controller,
                        //url: self.Download,
                        //    data: datas
                        //});
                        BaseUtil.Download({
                            controller: self.controller,
                            //url: self.Download,
                            data: datas
                        });
                    }
                }
            };
            BaseUtil.Ajax(requestOption);
        },
        // 列印
        doPrint: function () {
            var self = this;
            // get postdata
            var postData = BaseUtil.GetPostData(self.form);
            // 開啟報表視窗
            BaseUtil.OpenWindow({
                url: self.actions.Print,
                data: postData
            });
        },
        // 清除
        doClear: function () {
            var self = this;
            // 清除資料、驗證訊息
            BaseUtil.ClearForm(self.form);
        },
        // 回前頁
        doBack: function () {
            var self = this;
            // 切頁參數view
            self.view = false;
            EXPL100_PAGE0.view = true;
        },
        // 顯示/隱藏 查詢條件
        doViewTableForm: function () {
            var self = this;
            if (self.formview) {
                self.formview = false;
            } else {
                self.formview = true;
            }
        },
        // 清除表頭控制值
        doResetGridHead: function () {
            var self = this;
            self.grid.head.selCheck = false;
        },
        vueSelectChange: function (eventData) {
            var self = this;
            console.log(eventData);
        },
        // 訊息關閉執行
        confirmClose: function (emitData) {
            var self = this;
            // 關閉提示視窗
            self.confirm.show = false;
            if (emitData != undefined) {
                if (emitData.even == 'delete') {
                    // 執行刪除
                    self.doDelete();
                }
            }
        }
    },
    watch: {
        'grid.head.selCheck': function (val, oldVal) { // 全選/取消全選時觸發
            var self = this;
            for (var i in self.grid.datas) {
                // 狀態必須是可勾選
                if (!self.grid.datas[i].selCheck.disabled && !self.grid.datas[i].selCheck.display) {
                    self.grid.datas[i].selCheck.value = val;
                }
            }
        }
    }
});