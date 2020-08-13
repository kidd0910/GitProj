/* 
    button控制欄位狀態、操作權限
    model:
        operate:    操作種類
        uesd:       是否可用
        disabled:   停用狀態
        display:    隱藏狀態
*/
Vue.directive('operate',
    function (el, binding) {
        // 有model才做設定
        if (binding.value != undefined) {
            // model尚未初始化
            if (binding.value.used != undefined) {
                if (binding.value.used) {
                    // 停用狀態
                    el.disabled = binding.value.disabled;
                    // 顯示狀態
                    if (binding.value.display) {
                        el.style.display = 'none';
                    } else {
                        el.style.display = '';
                    }
                } else {
                    el.disabled = true;
                    el.style.display = 'none';
                }
            }
        }
    }
);