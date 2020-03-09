// 常用公用函式
var CommonUtil = new Object();

// 取得民國日期 (1001010)
CommonUtil.GetNowCDate = function () {
    var date = new Date();
    return CommonUtil.PadZeroLeft(date.getFullYear() - 1911, 3) + CommonUtil.PadZeroLeft(date.getMonth() + 1, 2) + CommonUtil.PadZeroLeft(date.getDate(), 2);
}

// 民國日期(1010101) > 日期物件
CommonUtil.ToDate = function (cDate) {
    var year = parseInt(cDate.substring(0, 3));
    var month = parseInt(cDate.substring(3, 5));
    var day = parseInt(cDate.substring(5, 7));
    return new Date(year + 1911, month - 1, day);
}

// 日期物件 > 民國日期
CommonUtil.ToCDate = function (wDate) {
    return CommonUtil.PadZeroLeft(wDate.getFullYear() - 1911, 3) + CommonUtil.PadZeroLeft(wDate.getMonth() + 1, 2) + CommonUtil.PadZeroLeft(wDate.getDate(), 2);
}

// 民國日期取相差天數
CommonUtil.GetCDateDiffDays = function (startCDate, endCDate) {
    var dateS = CommonUtil.ToDate(startCDate);
    var dateE = CommonUtil.ToDate(endCDate);
    var ticks = dateE.getTime() - dateS.getTime();
    var days = Math.floor(ticks / (24 * 3600 * 1000));
    return days;
}

// 取得該年總天數(民國)
CommonUtil.GetCYearDays = function (year) {
    return CommonUtil.GetCDateDiffDays(year + '0101', year + '1231') + 1;
}

// 民國日期增加天數
CommonUtil.GetCDateAddDays = function (cDate, days) {
    var date = CommonUtil.ToDate(cDate);
    date.setDate(date.getDate() + days);
    return CommonUtil.ToCDate(date);;
}

// 左補0
CommonUtil.PadZeroLeft = function (str, len) {
    str = '' + str;
    return str.length >= len ? str : new Array(len - str.length + 1).join("0") + str;
}

// 右補0
CommonUtil.PadZeroRight = function (str, len) {
    str = '' + str;
    return str.length >= len ? str : str + new Array(len - str.length + 1).join("0");
}

// 取金錢值 (移除每三位逗號)
CommonUtil.GetMoneyValue = function (value) {
    value = value.replace(/,/g, "");
    return isNaN(value) ? 0 : value
}

// 取金錢格式自串 (增加每三位逗號)
CommonUtil.GetMoneyCurrency = function (value) {
    value = value.toString();
    value = isNaN(value) ? 0 : value
    var pattern = /(-?\d+)(\d{3})/;
    while (pattern.test(value)) {
        value = value.replace(pattern, "$1,$2");
    }
    return value;
}