// ajax 儲存序列
var AjaxQueue = new Object();
AjaxQueue.xhrQueue = [];
AjaxQueue.waitAjaxEndFnQueue = [];
// listener ajax send
$(document).ajaxSend(function (event, jqxhr, settings) {
    //console.log("ajaxSend:" + settings.url);
    AjaxQueue.xhrQueue.push(jqxhr);
    //console.log('ajaxSend:' + AjaxQueue.xhrQueue.length);
    MAIN.showProcess();
});
// listener ajax complete
$(document).ajaxComplete(function (event, jqxhr, settings) {
    //console.log("ajaxComplete:" + settings.url);
    var i;
    if ((i = $.inArray(jqxhr, AjaxQueue.xhrQueue)) > -1) {
        AjaxQueue.xhrQueue.splice(i, 1);
    }
    //console.log('ajaxComplete:' + AjaxQueue.xhrQueue.length);
    if (AjaxQueue.xhrQueue.length == 0) {
        MAIN.hideProcess();
        // call fn from queue
        if (AjaxQueue.waitAjaxEndFnQueue.length > 0) {
            //console.log('waitAjaxEndFnQueue');
            AjaxQueue.waitAjaxEndFnQueue[0]();
            AjaxQueue.waitAjaxEndFnQueue.splice(0, 1);
        }
    }
});
// 關閉所有AJAX請求(目前無作用，若未回傳還是會卡住)
//BaseUtil.AjaxAbort = function () {
//console.log("abortStart");
//console.log(AjaxQueue.xhrQueue.length);
//while (AjaxQueue.xhrQueue.length) {
//    AjaxQueue.xhrQueue[0].abort();
//}
//console.log(AjaxQueue.xhrQueue.length);
//console.log("abortEnd");
//}
// 公用 function
var BaseUtil = new Object();
// Download
BaseUtil.Download = function (option) {
    var requestOption = $.extend(
        {},
        {
            controller: 'Home',
            action: 'BaseDownload',
            url: '',
            data: {}
        },
        option || {}
    );

    if (requestOption.url == undefined || requestOption.url == '') {
        requestOption.url = BASE_ROOT_URL + requestOption.controller + '/' + requestOption.action;
    }

    if (requestOption.url == undefined || requestOption.url == '') {
        alert('url is undefined');
        return;
    }

    var inputs = '';
    $.each(requestOption.data, function (key, value) {
        inputs += '<input type="hidden" name="' + key + '" value="' + value + '" />';
    });
    jQuery('<form action="' + requestOption.url + '" method="post">' + inputs + '</form>')
        .appendTo('body').submit().remove();
}
// Ajax
BaseUtil.Ajax = function (option) {
    if (option.url == undefined || option.url == '') {
        alert('url is undefined');
        return;
    } else {
        option.url = BASE_ROOT_URL + option.url;
    }
    var requestOption = $.extend(
        {},
        {
            url: '',
            cache: false,
            type: 'POST',
            data: {},
            success: function (data) {
                //if (data.success) {
                //    alert("ajax finish!");
                //}
            },
            error: function (xhr, ajaxOptions, thrownError) {
                MAIN.hideProcess();
                if (xhr.responseText != undefined) {
                    console.log(xhr.responseText);
                    alert('系統發生錯誤。');
                    //var width = 350;//screen.width * 0.5;
                    //var height = 120;//screen.height * 0.5;
                    //var LeftPosition = (screen.width) ? (screen.width - width) / 2 : 0;
                    //var TopPosition = (screen.height) ? (screen.height - height) / 2 : 0;
                    //var errMsgWin = window.open('', 'error',
                    //    'height=' + height + ',width=' + width + ',left=' + LeftPosition + ',top=' + TopPosition + ',resizable=yes,toolbar=no');
                    //errMsgWin.document.writeln('<br><h1 style="text-align: center; vertical-align: middle; color: red;">系統發生錯誤。</h1>');
                    //errMsgWin.document.close();
                    //errMsgWin.focus();
                    //errMsgWin.moveTo(LeftPosition, TopPosition);
                    //errMsgWin.document.body.scrollTop = '10000000';
                    //errMsgWin.document.title = 'Error';
                }
            }
        },
        option || {}
    );
    // AJAX同步會使UI鎖死，只使用非同步
    requestOption.async = true;
    var fn = function () {
        $.ajax(requestOption)
            .done(function (res) { /*console.log('done');*/ })
            .fail(function (res) { /*console.log('fail');*/ });
    }
    // 使用同步
    BaseUtil.WaitAjaxEnd(fn);
    //if (!option.async) {
        // 使用同步
    //    BaseUtil.WaitAjaxEnd(fn);
    //} else {
        // 使用非同步
    //    fn();
    //}
}
// OpenWindow
BaseUtil.OpenWindow = function (option) {
    if (option.url == undefined || option.url == '') {
        alert('url is undefined');
        return;
    } else {
        option.url = BASE_ROOT_URL + option.url;
    }
    var requestOption = $.extend(
        {},
        {
            winName: '',
            width: '',
            height: '',
            url: '',
            data: {}
        },
        option || {}
    );
    var createInputTag = function (basekey, obj) {
        var inputTag = '';
        if (Array.isArray(obj)) {
            $.each(obj, function (index, value) {
                inputTag += createInputTag(basekey + "[" + index + "]", value);
            });
        } else if (typeof obj == 'object') {
            $.each(obj, function (key, value) {
                inputTag += createInputTag((basekey == '' ? '' : (basekey + ".")) + key, value);
            });
        } else {
            inputTag += '<input type="hidden" name="' + basekey + '" value="' + obj + '" />';
        }
        return inputTag;
    };

    var inputTags = createInputTag('', requestOption.data);

    requestOption.winName = requestOption.winName == '' ? 'newWindows' : requestOption.winName;

    var width = requestOption.width == '' ? screen.width * 0.75 : requestOption.width;
    var height = requestOption.height == '' ? screen.height * 0.75 : requestOption.height;
    var LeftPosition = (screen.width) ? (screen.width - width) / 2 : 0;
    var TopPosition = (screen.height) ? (screen.height - height) / 2 : 0;

    var win = window.open('about:blank', requestOption.winName,
        'height=' + height + ',width=' + width + ',left=' + LeftPosition + ',top=' + TopPosition + ',directories=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes');

    win.focus();

    jQuery('<form target="' + requestOption.winName + '" action="' + requestOption.url + '" method="post">' + inputTags + '</form>')
        .appendTo('body').submit().remove();
}
// OpenTPA
BaseUtil.OpenTPA = function (data) {
    var option = {};
    option.url = data.URL;
    option.data = { value: data.VALUE };

    if (option.url == undefined || option.url == '') {
        alert('url is undefined');
        return;
    }
    var requestOption = $.extend(
        {},
        {
            winName: '',
            width: '',
            height: '',
            url: '',
            data: {}
        },
        option || {}
    );
    var inputs = '';
    $.each(requestOption.data, function (key, value) {
        inputs += '<input type="hidden" name="' + key + '" value="' + value + '" />';
    });

    requestOption.winName = requestOption.winName == '' ? 'newWindows' : requestOption.winName;

    var width = requestOption.width == '' ? screen.width * 0.75 : requestOption.width;
    var height = requestOption.height == '' ? screen.height * 0.75 : requestOption.height;
    var LeftPosition = (screen.width) ? (screen.width - width) / 2 : 0;
    var TopPosition = (screen.height) ? (screen.height - height) / 2 : 0;

    var win = window.open('about:blank', requestOption.winName,
        'height=' + height + ',width=' + width + ',left=' + LeftPosition + ',top=' + TopPosition + ',directories=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes');

    win.focus();

    jQuery('<form target="' + requestOption.winName + '" action="' + requestOption.url + '" method="post">' + inputs + '</form>')
        .appendTo('body').submit().remove();
}
// HrefPage
BaseUtil.HrefPage = function (url, data) {
    if (url == undefined || url == '') {
        alert('url is undefined');
        return;
    } else {
        url = BASE_ROOT_URL + url;
    }

    var inputs = '';
    $.each(data, function (key, value) {
        inputs += '<input type="hidden" name="' + key + '" value="' + value + '" />';
    });

    jQuery('<form action="' + url + '" method="post">' + inputs + '</form>')
        .appendTo('body').submit().remove();
}
// OpenNewPage
BaseUtil.OpenNewPage = function (url, data) {
    if (url == undefined || url == '') {
        alert('url is undefined');
        return;
    } else {
        url = BASE_ROOT_URL + url;
    }

    var inputs = '';
    $.each(data, function (key, value) {
        inputs += '<input type="hidden" name="' + key + '" value="' + value + '" />';
    });

    jQuery('<form target="_blank" action="' + url + '" method="post">' + inputs + '</form>')
        .appendTo('body').submit().remove();
}
// WaitAjaxEnd (若為無AJAX fn，只能有一個且須放在最後一個)
BaseUtil.WaitAjaxEnd = function (fn) {
    if (AjaxQueue.xhrQueue.length == 0) {
        //console.log('waitAjaxEndFnQueue fn');
        fn();
    } else {
        //console.log('waitAjaxEndFnQueue add');
        AjaxQueue.waitAjaxEndFnQueue.push(fn);
    }
}
// guid
BaseUtil.Guid = function () {
    function s4() {
        return Math.floor((1 + Math.random()) * 0x10000).toString(16).substring(1);
    }
    return s4() + s4() + s4() + s4() + s4() + s4() + s4() + s4();
}
// 連結頁
BaseUtil.DoHref = function (url) {
    if (event.ctrlKey) {
        //console.log("The CTRL key was pressed!");
        window.open(url, '_blank');
    } else {
        //console.log("The CTRL key was NOT pressed!");
        //MAIN.showProcess();
        window.location.href = url;
    }
}

// 連結頁(瀏覽器新分頁)
BaseUtil.DoHrefNewPage = function (url) {
    window.open(url, '_blank');
}

// 查詢結果凍結表頭
// (head as ref node)
// (body as ref node)
// (scrollbar as ref node)
BaseUtil.GridFixedHead = function (head, body, scrollbar) {
    if (head == undefined || body == undefined || scrollbar == undefined) {
        return;
    }
    var headRows = head.childNodes[0].childNodes[0].childNodes;
    var bodyRows = body.childNodes[0].childNodes[0].childNodes;
    var last;
    for (var i in bodyRows) {
        if ('TD' == bodyRows[i].tagName) {
            last = i;
            headRows[i].style.width = (bodyRows[i].offsetWidth - 3) + 'px';
        }
    }
    // IE scrollbar 無顯示時 offsetWidth <> scrollWidth
    if (scrollbar.offsetWidth - scrollbar.scrollWidth > 15) {
        headRows[last].style.width = (headRows[last].offsetWidth + 11) + 'px';
    }
}

// CreateButtonModel 產生按鈕Model
// (variable as ['A','B',....])
// operate:    操作種類
// uesd:       是否可用
// disabled:   停用狀態
// display:    隱藏狀態
BaseUtil.CreateButtonModel = function (buttons) {
    var model = {};
    for (var key in buttons) {
        var control = {
            operate: buttons[key].operate,
            used: true,
            disabled: false,
            display: false
        };
        model[key] = control;
    }
    return model;
}

// CreatePanelModel 產生區塊Model
// (variable as ['A','B',....])
// userKind:   操作種類
// uesd:       是否可用
// display:    隱藏狀態
BaseUtil.CreatePanelModel = function (panels) {
    var model = {};
    for (var key in panels) {
        var control = {
            userKind: panels[key].userKind,
            used: true,
            display: false
        };
        model[key] = control;
    }
    return model;
}

// CreateFormModel 產生欄位控制項
// (variable as ['A','B',....])
// value:      資料內容
// required:   不可空白
// disabled:   停用狀態
// display:    顯示狀態
// message:    驗證訊息
BaseUtil.CreateFormModel = function (form, variable) {
    for (var key in variable) {
        var control = {
            value: '',
            required: false,
            disabled: false,
            display: false,
            message: ''
        };
        Vue.set(form, variable[key], control);
    }
}

// 清除資料、訊息
// (form as formData)
// (passKeys as ['A','B'...])
BaseUtil.ClearForm = function (form, passKeys) {
    for (var key in form) {
        var pass = false;
        if (passKeys != undefined) {
            if (passKeys.indexOf(key) > -1) {
                pass = true;
            }
        }
        if (!pass) {
            var control = form[key];
            if (Array.isArray(control.value)) {
;               control.value = [];
            } else if (typeof (control.value) === "boolean") {
                control.value = false;
            } else {
                control.value = '';
            }
            control.message = '';
        }
    }
}
// 驗證至少一個條件
// (form as formData)
BaseUtil.ValidationLeastOne = function (form) {
    var result = false;
    for (var key in form) {
        var control = form[key];
        if (Array.isArray(control.value)) {
            if (control.value.length > 0) {
                result = true;
                break;
            }
        } else {
            if (control.value != '' && control.value != undefined) {
                result = true;
                break;
            }
        }
        if (control.message != '' && control.message != undefined) {
            result = false;
            break;
        }
    }
    return result;
}
// 驗證資料是否空白
// (form as formData)
BaseUtil.Validation = function (form) {
    var result = true;
    for (var key in form) {
        var control = form[key];
        if (control.required && control.message == '') {
            if (Array.isArray(control.value)) {
                if (control.value.length == 0) {
                    control.message = '不可空白';
                } else {
                    control.message = '';
                }
            } else {
                if (control.value == '' || control.value == undefined) {
                    control.message = '不可空白';
                } else {
                    control.message = '';
                }
            }
        }
        if (control.message != '' && control.message != undefined) {
            result = false;
        }
    }
    return result;
}
// 驗證資料是否空白
// (grid as gridData)
BaseUtil.ValidationGrid = function (grid) {
    var result = true;
    for (var i in grid) {
        for (var key in grid[i]) {
            var control = grid[i][key];
            if (control.required && control.message == '') {
                if (Array.isArray(control.value)) {
                    if (control.value.length == 0) {
                        control.message = '不可空白';
                    } else {
                        control.message = '';
                    }
                } else {
                    if (control.value == '' || control.value == undefined) {
                        control.message = '不可空白';
                    } else {
                        control.message = '';
                    }
                }
            }
            if (control.message != '' && control.message != undefined) {
                result = false;
            }
        }
    }
    return result;
}

// 產生POSTDATA (無法多層轉換)
// (form as formData) or (grid as gridData)
BaseUtil.GetPostData = function (data) {
    var postDataResult;
    if (Array.isArray(data)) {
        postDataResult = [];
        for (var i in data) {
            var postData = {}
            for (var key in data[i]) {
                // undefined 轉完空白 (因篩選式下拉)
                if (data[i][key].value == undefined) {
                    postData[key] = '';
                } else {
                    postData[key] = data[i][key].value;
                }
            }
            postDataResult.push(postData);
        }
    } else {
        postDataResult = {};
        for (var key in data) {
            // undefined 轉完空白 (因篩選式下拉)
            if (data[key].value == undefined) {
                postDataResult[key] = '';
            } else {
                postDataResult[key] = data[key].value;
            }
        }
    }
    return postDataResult;
}

// 取得分頁資訊JSON
// (paginaiton as paginaitonData)
BaseUtil.GetPaginaiton = function (paginaiton) {
    return JSON.parse(JSON.stringify(paginaiton));
}

// 產生列表欄位控制項
// (gridDatas as gridDatas)
// (gridDatas as datas)
BaseUtil.CreateGridDatas = function (gridDatas, datas) {
    for (var i in datas) {
        var gridData = {};
        for (var key in datas[i]) {
            gridData[key] = {
                //value: datas[i][key],
                // 結構化 (model)
                value: BaseUtil.GetValue(datas[i][key]),
                required: false,
                disabled: false,
                display: false,
                message: ''
            };
        }
        //gridDatas.splice(i, 1, gridData);
        gridDatas.push(gridData);
    }
}

// 加入列表欄位控制項
// (datas as datas)
// (name as name)
// (defaultValue as defaultValue)
BaseUtil.AddGridDatas = function (datas, name, defaultValue) {
    for (var i in datas) {
        var control = {
            value: defaultValue,
            required: false,
            disabled: false,
            display: false,
            message: ''
        };
        Vue.set(datas[i], name, control);
    }
}

BaseUtil.CreateMergeGridRow = function (gridDatas, count) {
    var gridDatasCount = gridDatas.length;
    if (gridDatasCount == 0)
        return;
    var i;
    var c;
    for (i = gridDatasCount; i > 0; --i) {
        for (c = 0; c < count; ++c) {
            gridDatas.splice(i, 0, {});
        }
        
    }
}

BaseUtil.AddGridRow = function (gridDatas, variable, count) {
    var index = gridDatas.length - 1;
    for (i = 0; i < count; i++) {
        var gridData = {};
        for (var key in variable) {
            gridData[variable[key]] = {
                value: "",
                required: false,
                disabled: false,
                display: false,
                message: ''
            };
        }
        //gridDatas.splice(index, 1, gridData);
        gridDatas.push(gridData);
    }
}

BaseUtil.GetValue = function (value) {
    if (value != undefined) {
        if (Array.isArray(value)) {
            // array
            var datas = [];
            for (var i in value) {
                datas[i] = BaseUtil.GetValue(value[i]);
            }
            return datas;
        } else {
            if (typeof value == 'object') {
                // json
                var data = {};
                for (var key in value) {
                    data[key] = {
                        value: BaseUtil.GetValue(value[key]),
                        required: false,
                        disabled: false,
                        display: false,
                        message: ''
                    };
                }
                return data;
            } else {
                // string
                return value;
            }
        }
    } else {
        return '';
    }
}

// 寫入form對應名稱的值
// (form as form)
// (data as data)
BaseUtil.SetFormValue = function (form, data) {
    for (var key in data) {
        if (form[key] != undefined) {
            form[key].value = BaseUtil.GetValue(data[key]);
        } else {
            var control = {
                value: BaseUtil.GetValue(data[key]),
                required: false,
                disabled: false,
                display: false,
                message: ''
            };
            Vue.set(form, key, control);
        }
    }
}

// 取得節點底下的file element
// (refNode as $refs)
// (fromData as fromData)
BaseUtil.CheckFileInput = function (fileListNode, fromData) {
    var result = [];
    if (Array.isArray(fileListNode)) {
        for (var i in fileListNode) {
            var node = fileListNode[i];
            // 取得節點底下的file node
            if (node.type == 'file') {
                fromData.append(node.name, node.files[0]);
                // 未選擇檔案
                if (node.files[0] == undefined) {
                    result.push(false);
                } else {
                    result.push(true);
                }
            }
        }
    } else {
        var node = fileListNode;
        // 取得節點底下的file node
        if (node.type == 'file') {
            fromData.append(node.name, node.files[0]);
            // 未選擇檔案
            if (node.files[0] == undefined) {
                result = false;
            } else {
                result = true;
            }
        }
    }
    return result;
}

// 卷軸至頂
BaseUtil.ScrollTop = function () {
    // IE 無法使用
    //document.scrollingElement.scrollTop = 0;
    // IE, Chrome (確認可用)
    document.documentElement.scrollTop = 0;
}