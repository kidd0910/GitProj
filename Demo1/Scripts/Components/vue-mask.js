Vue.component('vue-mask', {
    //template: '#vue-mask',
    template:
'<div class="mask-mask" v-show="mask.show">' +
	'<div class="mask-wrapper">' +
		'<div class="mask-container">' +
			'{{mask.message}}' +
		'</div>' +
	'</div>' +
'</div>'
    ,
    props: ['mask'],
    created: function () {
        var self = this;
        //console.log(self.datas);
    },
    methods: {
    }
});