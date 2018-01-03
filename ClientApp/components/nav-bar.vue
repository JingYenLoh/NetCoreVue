<template>
  <nav class="navbar is-primary"
       role="navigation"
       aria-label="main navigation">
    <div class="container">
      <div class="navbar-brand">

        <router-link class="navbar-item"
                     to="/">
          <img src="https://vuejs.org/images/logo.png"
               alt="Vue is the best"
               width="28"
               height="28" />
        </router-link>

        <span class="navbar navbar-burger is-primary"
              :class="{ 'is-active': isActive }"
              @click='isActive = !isActive'>
          <span></span>
          <span></span>
          <span></span>
        </span>
      </div>

      <div class="navbar-menu"
           :class="{ 'is-active': isActive }">
        <div class="navbar-start">

          <div class="navbar-item has-dropdown is-hoverable">
            <a class="navbar-link">Session</a>
            <div class="navbar-dropdown">
              <router-link class="navbar-item"
                           :to="'/Sessions/Index'">
                Manage Session
              </router-link>
              <router-link class="navbar-item"
                           :to="'/Sessions/Create'">
                Create Session
              </router-link>
            </div>
          </div>

          <div class="navbar-item has-dropdown is-hoverable">
            <a class="navbar-link">Customer</a>
            <div class="navbar-dropdown">
              <router-link class="navbar-item"
                           :to="'/Customers/Index'">
                Manage Customers
              </router-link>
              <router-link class="navbar-item"
                           :to="'/Customers/Create'">
                Create Customer
              </router-link>
            </div>
          </div>

          <router-link class="navbar-item"
                       :to="'/Users/Index'">
            Manage User
          </router-link>

        </div>

        <div class="navbar-end">
          <div class="navbar-item">
            <span>{{ name }}</span>
          </div>
          <div class="navbar-item">
            <button class="button is-primary"
                    @click="signOut">
              <b-icon pack="fa"
                      icon="sign-out" />
              <span>Sign out</span>
            </button>
          </div>
        </div>

      </div>
    </div>
  </nav>
</template>

<script>
import { create } from 'axios'

export default {
  data () {
    return {
      isActive: false
    }
  },
  props: {
    name: String
  },
  methods: {
    async signOut () {
      try {
        const loadingComponent = this.$loading.open()

        const token = document.getElementById('anti-forgery')
          .firstChild
          .getAttribute('value')

        const instance = create({
          headers: { 'RequestVerificationToken': token }
        })

        const { status } = await instance.post('/Account/Logout')

        if (status === 200) {
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
