Vue.component('vue-confirm', {
    //template: '#vue-confirm',
    template:
'<div class="confirm-mask" v-show="confirm.show">' +
	'<div class="confirm-wrapper">' +
		'<div class="confirm-container">' +
			'<div class="confirm-message" v-show="confirm.message != undefined">' +
                '{{confirm.message}}' +
			'</div>' +
			'<div class="confirm-footer">' +
				'<button class="page-btn" v-show="confirm.ok != undefined" v-on:click="ok">{{confirm.ok}}</button>' +
                '&nbsp;&nbsp;&nbsp;&nbsp;' +
				'<button class="page-btn" v-show="confirm.cancel != undefined" v-on:click="cancel">{{confirm.cancel}}</button>' +
			'</div>' +
		'</div>' +
	'</div>' +
'</div>'
    ,
    props: ['confirm'],
    created: function () {
        var self = this;
    },
    methods: {
        ok: function () {
            var self = this;
            self.$emit('confirmclose', { even: self.confirm.even });
        },
        cancel: function () {
            var self = this;
            self.$emit('confirmclose', '');
        }
    }
});