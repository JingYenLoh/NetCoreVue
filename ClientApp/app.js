import Vue from 'vue'
import Buefy from 'buefy'
import axios from 'axios'
import router from './router'
import store from './store'
import { sync } from 'vuex-router-sync'
import App from './components/App.vue'
// Styles
import 'buefy/lib/buefy.css'

Vue.use(Buefy, {
  defaultIconPack: 'fa'
})

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
