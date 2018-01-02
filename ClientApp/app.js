import Vue from 'vue'
import Buefy from 'buefy'
import store from './store'
import router from './router'
import { sync } from 'vuex-router-sync'
import App from './components/App.vue'

// Validation
import { alphaNumSpaces } from './helpers/validators'
import VeeValidate from 'vee-validate'

Vue.use(Buefy, {
  defaultIconPack: 'fa'
})

VeeValidate.Validator.extend('alpha_num_spaces', alphaNumSpaces)
Vue.use(VeeValidate)

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
