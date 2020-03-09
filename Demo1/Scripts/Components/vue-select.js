Vue.component('vue-select', {
    //template: '#vue-select', 
    template:
'<div class="wrapper">' +
    '<input v-if="autotab === undefined"           ref="input" type="text" v-bind:style="{ \'width\': getInputWidth() }" v-control="value" v-model="inputValue" v-on:focus="focusInput" v-on:focusout="focusOutInput" />' +
    '<input v-if="autotab !== undefined" v-autotab ref="input" type="text" v-bind:style="{ \'width\': getInputWidth() }" v-control="value" v-model="inputValue" v-on:focus="focusInput" v-on:focusout="focusOutInput" />' +
    '<span class="vue-select-btn" v-control="value" v-on:click="clickSpan"><span class="vue-select-btn-icon"></span></span>' +
    '<select ref="select" class="vue-select-select" v-show="show" v-bind:size="size" v-model="selectValue" v-on:click="clickSelect()" v-on:focusout="focusOutSelect" >' +
        '<option v-for="(data, index) in filterOptions" v-bind:value="data.value">' +
            '{{ data.text }}' +
        '</option>' +
    '</select>' +
'</div>'
    ,
    props: ['autotab', 'value', 'option', 'width', 'eventdata'],
    data: function () {
        var data = {
            show: false,
            filterOptions: [],
            size: '2',
            selectValue: '',
            inputValue: ''
        };
        return data;
    },
    mounted: function () {
        var self = this;
        for (var i in self.option) {
            if (self.value.value == self.option[i].value) {
                self.inputValue = self.option[i].text;
                break;
            }
        }
    },
    methods: {
        // [focus] 輸入框
        focusInput: function () {
            var self = this;
            // 觸發時重置狀態
            if (!self.value.disabled) {
                self.doFilterOptions();
                self.show = true;
                self.selectValue = undefined;
            }
        },
        // [click] 下拉
        clickSpan: function () {
            var self = this;
            // 觸發時重置狀態
            if (!self.value.disabled) {
                self.doFilterOptions();
                self.show = true;
                self.selectValue = undefined;
                self.$nextTick(function () {
                    self.$refs.select.focus();
                });
            }
        },
        // [focusout] 輸入框
        focusOutInput: function () {
            var self = this;
            self.$refs.select.focus();
        },
        // [focusout] 選單
        focusOutSelect: function () {
            var self = this;

            var findValueText = '';
            if (self.selectValue != undefined) {
                findValueText = self.selectValue;
            } else {
                findValueText = self.inputValue.toUpperCase();
            }

            var find = false;
            var newValue = '';
            var newText = '';
            for (var i in self.option) {
                if (self.option[i].value == findValueText || self.option[i].text == findValueText) {
                    newValue = self.option[i].value;
                    newText = self.option[i].text;
                    find = true;
                    break;
                }
            }

            if (!find) {
                self.value.value = '';
                self.inputValue = '';
                self.value.message = '';
            } else {
                if (self.value.value != newValue) {
                    self.value.value = newValue;
                    self.value.message = '';
                    // 改變才觸發 event
                    if (self.eventdata != undefined) {
                        this.$emit('vueselectchange', self.eventdata);
                    }
                }
                self.inputValue = newText;
            }
            self.show = false;
        },
        // [click] 選項
        clickSelect: function () {
            var self = this;
            self.$refs.select.blur();
            // for autotab keyup even
            if (self.autotab != undefined && self.$refs.input.onkeyup != null) {
                // 更新後觸發 
                self.$nextTick(function () {
                    self.$refs.input.onkeyup(self.$refs.input, true);
                });
            }
        },
        doFilterOptions: function (filterText) {
            var self = this;
            self.filterOptions = [];
            var add = false;
            for (var i in self.option) {
                if (filterText == undefined) {
                    add = true;
                } else {
                    if (self.option[i].text.indexOf(filterText) > -1 || self.option[i].value.indexOf(filterText) > -1) {
                        add = true;
                    } else {
                        add = false;
                    }
                }
                if (!add) {
                    continue;
                }
                if (self.filterOptions.length > 100) {
                    break;
                }
                self.filterOptions.push({
                    value: self.option[i].value,
                    text: self.option[i].text
                });
            }
            if (self.filterOptions.length == 1) {
                self.size = '2';
                self.filterOptions.splice(0, 0, { text: '', value: '' });
            }

            if (self.filterOptions.length < 20) {
                self.size = self.filterOptions.length.toString();
            } else {
                self.size = '20';
            }
            
        },
        getInputWidth: function () {
            var self = this;
            var rtnWidth = '100';
            if (self.width != undefined && self.width != '') {
                rtnWidth = self.width;
            }
            return rtnWidth + 'px';
        }
    },
    watch: {
        'inputValue': function (newVal, oldVal) {
            var self = this;
            // 焦點時觸發
            if (self.show) {
                self.doFilterOptions(newVal.toUpperCase());
            }
        },
        'value.value': function (newVal, oldVal) {
            var self = this;
            // 非焦點時觸發
            if (!self.show) {
                var optionText = '';
                for (var i in self.option) {
                    if (newVal == self.option[i].value) {
                        optionText = self.option[i].text;
                        break;
                    }
                }
                self.inputValue = optionText;
            }
        },
        'option': function (newVal, oldVal) {
            var self = this;
            // 非焦點時觸發
            if (!self.show && self.value != undefined && self.option != undefined) {
                var optionText = '';
                for (var i in self.option) {
                    if (self.value.value == self.option[i].value) {
                        optionText = self.option[i].text;
                        break;
                    }
                }
                self.inputValue = optionText;
            }
            if (self.option != undefined) {
                self.doFilterOptions();
            }
        }
    }
});