Vue.directive('autotab', {
    bind: function (el, binding) {
        el.setAttribute("autotab", "autotab");
        // element bind add autotab even function
        // add onkeyup
        var fn = function (e, pass) {
            // if datepicker trigger even, then e not even object(e.target == undefined), e is element.
            if ((e.target == undefined && e.value.length == e.maxLength)
                || (e.target != undefined && e.target.value.length == e.target.maxLength)
                || pass) {
                var tags = document.querySelectorAll("[autotab='autotab']");
                var find = false;
                for (i = 0; i < tags.length; i++) {
                    if (tags[i] == undefined || tags[i].offsetParent == null) {
                        continue;
                    }
                    if (find) {
                        if (!tags[i].disabled && tags[i].style.display == '') {
                            tags[i].focus();
                            break;
                        }
                    }
                    if (tags[i] == el) {
                        find = true;
                    }
                }
            }
        }
        el.onkeyup = fn;
        /* addEventListener
        el.addEventListener('keyup',
            function (e) {
                if (e.target.value.length == e.target.maxLength) {
                    var tags = document.querySelectorAll("[autotab='autotab']");
                    var find = false;
                    for (i = 0; i < tags.length; i++) {
                        if (tags[i] == undefined || tags[i].offsetParent == null) {
                            continue;
                        }
                        if (find) {
                            if (!tags[i].disabled && tags[i].style.display == '') {
                                tags[i].focus();
                                break;
                            }
                        }
                        if (tags[i] == el) {
                            find = true;
                        }
                    }
                }
            }
        );
        */
    }
});