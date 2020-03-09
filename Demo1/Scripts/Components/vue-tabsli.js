Vue.component('vue-tabsli', {
    //template: '#vue-tabsli',
    template:
'<li v-bind:class="tabs === tabid ? \'tabs-ui\' : \'tabs-ui-n\'" v-on:click="showTabs(tabid)">{{tabnm}}</li>'
    ,
    props: ['tabs', 'tabid', 'tabnm'],
    created: function () {
        var self = this;
        //console.log(self.datas);
    },
    methods: {
        showTabs: function () {
            var self = this;
            self.$emit('showtabs', self.tabid);
        }
    }
});