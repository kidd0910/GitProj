Vue.component('vue-message', {
    //template: '#vue-message',
    template:
'<div class="message-wrapper" v-show="message.show">' +
	'<div class="message-container">' +
		'{{message.message}}' +
	'</div>' +
'</div>'
    ,
    props: ['message'],
    created: function () {
        var self = this;
        //console.log(self.datas);
    },
    methods: {
    }
});