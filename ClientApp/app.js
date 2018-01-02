import Vue from 'vue'
import Buefy from 'buefy'
import axios from 'axios'
import VeeValidate from 'vee-validate'
import router from './router'
import store from './store'
import { sync } from 'vuex-router-sync'
import App from './components/App.vue'

Vue.use(Buefy, {
  defaultIconPack: 'fa'
})

Vue.use(VeeValidate)

Vue.prototype.$http = axios

sync(store, router)

const app = new Vue({
  store,
  router,
  ...App
})

app.$mount('#app')

export default {
  app,
  router,
  store
}
