<template>
  <nav class="navbar is-primary" role="navigation" aria-label="main navigation">
    <div class="container">
      <div class="navbar-brand">

        <router-link class="navbar-item" to="/">
          <img src="https://vuejs.org/images/logo.png" alt="Vue is the best" width="28" height="28" />
        </router-link>

        <span
          class="navbar navbar-burger is-primary"
          :class="{ 'is-active': isActive }"
          @click='isActive = !isActive'
        >
          <span></span>
          <span></span>
          <span></span>
        </span>
      </div>

      <div class="navbar-menu" :class="{ 'is-active': isActive }">
        <div class="navbar-start">

          <div class="navbar-item has-dropdown is-hoverable">
            <a class="navbar-link">Session</a>
            <div class="navbar-dropdown">
              <router-link class="navbar-item" :to="'/Sessions/Index'" exact-active-class="is-active">
                Manage Session
              </router-link>
              <router-link class="navbar-item" :to="'/Sessions/Create'" exact-active-class="is-active">
                Create Session
              </router-link>
            </div>
          </div>

          <div class="navbar-item has-dropdown is-hoverable">
            <a class="navbar-link">Customer</a>
            <div class="navbar-dropdown">
              <router-link class="navbar-item" :to="'/Customers/Index'" exact-active-class="is-active">
                Manage Customers
              </router-link>
              <router-link class="navbar-item" :to="'/Customers/Create'" exact-active-class="is-active">
                Create Customer
              </router-link>
            </div>
          </div>

          <router-link class="navbar-item" :to="'/Users/Index'">
            Manage User
          </router-link>

        </div>

        <div class="navbar-end">
          <div class="navbar-item">
            <button class="button is-primary"
                    @click="signOut">
              <b-icon pack="fa"
                      icon="sign-out"></b-icon>
              <span>Sign out</span>
            </button>
          </div>
        </div>

      </div>
    </div>
  </nav>
</template>

<script>
import axios from 'axios'

export default {
  data () {
    return {
      isActive: false
    }
  },
  methods: {
    async signOut () {
      try {
        const loadingComponent = this.$loading.open()

        const token = document.getElementById('anti-forgery').firstChild.getAttribute('value')

        const instance = axios.create({
          headers: { 'RequestVerificationToken': token }
        })

        const response = await instance.post('/Account/Logout')

        if (response.status === 200) {
          window.location = '/Account/Login'
        }
      } catch (err) {
        console.error(err)
      } finally {
        loadingComponent.close()
      }
    }
  }
}
</script>

<<style lang="scss" scoped>

</style>
