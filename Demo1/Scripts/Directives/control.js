/* 
    input、select、textarea控制欄位狀態、驗證、格式化、顯示訊息
    model:
        value       -> 值
        disabled    -> 停用狀態
        display     -> 顯示狀態
        required    -> 必填
        message     -> 訊息
*/
Vue.directive('control', {
    bind: function (el, binding) {
        // 預設寬度 (input text 限定)
        if (el.type == 'text' && el.maxLength > -1 && el.maxLength < 300 && el.style.width == '') {
            if (el.attributes.validation == undefined) {
                el.style.width = el.maxLength * 20 + 'px';
            } else {
                el.style.width = el.maxLength * 14 + 'px';
            }
        }
        if (binding.value == undefined) {
            return;
        }
        // 停用狀態
        el.disabled = binding.value.disabled;
        // 顯示狀態
        if (binding.value.display) {
            el.style.display = 'none';
        } else {
            el.style.display = '';
        }
    },
    update: function (el, binding) {
        //console.log('update');
        if (binding.value == undefined) {
            return;
        }
        // 停用狀態
        if (el.disabled != binding.value.disabled) {
            el.disabled = binding.value.disabled;
        }
        // 顯示狀態
        if (binding.value.display && el.style.display != 'none') {
            el.style.display = 'none';
        } else if (!binding.value.display && el.style.display != '') {
            el.style.display = '';
        }
        // 驗證訊息 (input text 限定)
        if (el.type == 'text') {
            // 資料自動格式化與驗證格式
            var thisValue = binding.value.value;
            var message = undefined;
            // 禁止陣列值 (防呆用)
            if (Array.isArray(thisValue)) {
                return;
            }
            // 驗證格式
            if (el.attributes.validation != undefined && el.attributes.validation.value != '') {
                if (thisValue != '') {
                    var validation = el.attributes.validation.value;
                    switch (validation) {
                        case 'NUM':
                            message = CheckInput.CheckNum(thisValue);
                            break;
                        case 'ENG':
                            message = CheckInput.CheckEng(thisValue);
                            break;
                        case 'ENGINT':
                            message = CheckInput.CheckEngInt(thisValue);
                            break;
                        case 'CDATE':
                            message = CheckInput.CheckCDate(thisValue);
                            break;
                        case 'YYYMM':
                            message = CheckInput.CheckYYYMM(thisValue);
                            break;
                        case 'HHMM':
                            message = CheckInput.CheckHHMM(thisValue);
                            break;
                        case 'HHMMSS':
                            message = CheckInput.CheckHHMMSS(thisValue);
                            break;
                        case 'IDNBAN':
                            message = CheckInput.CheckIDNBAN(thisValue);
                            break;
                        case 'IDN':
                            message = CheckInput.CheckIDN(thisValue);
                            break;
                        case 'BAN':
                            message = CheckInput.CheckBAN(thisValue);
                            break;
                        case 'EMAIL':
                            message = CheckInput.CheckEmail(thisValue);
                            break;
                        case 'AMT':
                            message = CheckInput.CheckAmt(thisValue);
                            break;
                        case 'EXECNO':
                            message = CheckInput.CheckExecNo(thisValue);
                            break;
                        default:
                            message = '';
                            break;
                    }
                    if (message != undefined) {
                        binding.value.message = message;
                    }
                } else {
                    if (thisValue == '') {
                        if (!binding.value.required) {
                            binding.value.message = '';
                        }
                    }
                }
            } else {
                if (binding.value.required && binding.value.message == '不可空白') {
                    if (thisValue != '') {
                        binding.value.message = '';
                    }
                }
            }
            // 驗證無誤才進行格式化
            if (thisValue != '' && message == '' && el.attributes.formate != undefined) {
                //console.log('do fill');
                var formate = el.attributes.formate.value;
                // 格式化補0
                switch (formate) {
                    case 'FILL':
                        var fillValue = binding.value.value;
                        // maxLength is 2147483647, -1 is not setting
                        if (fillValue != '' && fillValue.length < parseInt(el.maxLength) && parseInt(el.maxLength) != 2147483647 && parseInt(el.maxLength) != -1) {
                            while (fillValue.length < parseInt(el.maxLength)) {
                                fillValue = '0' + fillValue;
                            }
                            binding.value.value = fillValue;
                        }
                        break;
                    case 'EXECNO':
                        var execnoValue = binding.value.value;
                        if (execnoValue != undefined && execnoValue != '' && execnoValue.indexOf("-") > -1) {
                            var splitArray = execnoValue.split("-");
                            if (splitArray.length = 3) {
                                var execnoValue = CommonUtil.PadZeroLeft(splitArray[0], 3) + CommonUtil.PadZeroLeft(splitArray[1], 2) + CommonUtil.PadZeroLeft(splitArray[2], 8);
                                binding.value.value = execnoValue;
                            }
                        }
                        break;
                }
            }
        } else {
            // 消除不可空白訊息
            if (binding.value.value != '' && binding.value.value != undefined) {
                binding.value.message = '';
            }
        }
    }
});