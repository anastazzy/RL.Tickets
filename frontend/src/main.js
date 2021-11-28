import Vue from 'vue'
import App from './App.vue'
import axios from "axios";
import bootstrap from "bootstrap-vue";
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

Vue.config.productionTip = false
Vue.prototype.axios = axios
axios.defaults.baseURL = '/api'
Vue.use(bootstrap)

new Vue({
  render: h => h(App),
}).$mount('#app')
