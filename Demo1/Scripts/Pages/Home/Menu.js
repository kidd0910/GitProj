var MENU = new Vue({
    el: '#MENU',
    data: function () {
        var data = {
            init: false,
            actions: {},
            menus: {}
        };
        data.actions = {
            Menu: 'Home/Menu',
        };
        return data;
    },
    created: function () {
        var self = this;
        var requestOption = {
            url: self.actions.Menu,
            data: {},
            success: function (datas) {
                self.init = true;
                self.menus = datas;
                self.$nextTick(function () {
                    self.addEven();
                });
            }
        };
        BaseUtil.Ajax(requestOption);
    },
    methods: {
        //印Log for Debug
        log(item) {
            //console.log(item)
        },
        addEven: function () {
            $(".menu-node-1 > span").click(function () {
                if ($(this).hasClass("current")) {
                    $(this).removeClass("current").next().hide();
                } else {
                    $(this).addClass("current")
                        .next().show("fast")
                        .parent().siblings().children("span").removeClass("current")
                        .next().hide(500);
                }
            });
            $(".menu-node-2 > span").click(function () {
                if ($(this).hasClass("current")) {
                    $(this).removeClass("current").next().hide();
                } else {
                    $(this).addClass("current")
                        .next().show("fast")
                        .parent().siblings().children("span").removeClass("current")
                        .next().hide(500);
                }
            });
            if (BASE_NENU_URL != undefined && BASE_NENU_URL != '') {
                $(".menu-node-3 > span[url='" + BASE_NENU_URL + "']")
                    .removeClass("menu-npoint")
                    .addClass("menu-point")
                    .parent().parent().show().parent()
                    .children("span").addClass("current").parent()
                    .parent().show().parent()
                    .children("span").addClass("current");
            }
        },
        goUrlPage: function (url) {
            BaseUtil.DoHref(BASE_ROOT_URL + url);
        }
    }
});