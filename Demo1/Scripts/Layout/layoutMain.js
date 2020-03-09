// 修改密碼按鈕
function doModifyPassword(url) {
    MAIN.showProcess();
    location.href = url;
}

// 登出按鈕
function doLoginOut(url) {
    MAIN.showProcess('登出中');
    location.href = url;
}

// 隱藏標頭
function doMainTop() {
    if ($('#UserInfo').is(':visible')) {
        $('#UserInfo').hide(100);
        if ($("#MainBody").hasClass("main-body-max")) {
            $("#MainBody").removeClass("main-body-max");
        }
        if (!$("#MainBody").hasClass("main-body-min")) {
            $("#MainBody").addClass("main-body-min");
        }
    } else {
        $('#UserInfo').show(100);
        if ($("#MainBody").hasClass("main-body-min")) {
            $("#MainBody").removeClass("main-body-min");
        }
        if (!$("#MainBody").hasClass("main-body-max")) {
            $("#MainBody").addClass("main-body-max");
        }
    }
}

// 隱藏選單
function doMainMenu() {
    if ($('#MainMenu').is(':visible')) {
        $('#MainMenu').hide(100);
        if ($("#MainContent").hasClass("main-content-max")) {
            $("#MainContent").removeClass("main-content-max");
        }
        if (!$("#MainContent").hasClass("main-content-min")) {
            $("#MainContent").addClass("main-content-min");
        }
    } else {
        $('#MainMenu').show(100);
        if ($("#MainContent").hasClass("main-content-min")) {
            $("#MainContent").removeClass("main-content-min");
        }
        if (!$("#MainContent").hasClass("main-content-max")) {
            $("#MainContent").addClass("main-content-max");
        }
    }
}

function doMainBar(hidden) {
    if (hidden) {
        $('#MainTopBar').hide();
        $('#MainMenuBar').hide();
    } else {
        $('#MainTopBar').show();
        $('#MainMenuBar').show();
    }
}

// 列印畫面
function doPrintPage() {
    // 隱藏TOP
    var isMainTop = false;
    if ($('#UserInfo').is(':visible')) {
        doMainTop();
        isMainTop = true;
    }
    // 隱藏選單
    var isMainMenu = false;
    if ($('#MainMenu').is(':visible')) {
        doMainMenu();
        isMainMenu = true;
    }
    doMainBar(true);
    // 設定高度自動
    $("#MainContent").css("height", "auto");
    // wait 0.5s
    setTimeout(
        function () {
            //if (navigator.appName == 'Microsoft Internet Explorer' || !!(navigator.userAgent.match(/Trident/) || navigator.userAgent.match(/rv 11/)) || (typeof $.browser !== "undefined" && $.browser.msie == 1)) {
            //    webControl.execwb(7, 1);
            //} else {
            window.print();
            //}
            // 復原狀態
            if (isMainTop) {
                doMainTop();
            }
            if (isMainMenu) {
                doMainMenu();
            }
            doMainBar(false);
            // 取消高度設定
            $("#MainContent").css("height", "");
    }, 500);
}