<template>
  <nav class="navbar is-transparent" role="navigation" aria-label="main navigation">
    <div class="navbar-brand">

      <router-link class="navbar-item" to="/">
        <img src="https://sentry.io/_assets/logos/vue-wordmark-3eed5d97e4588a2d4f77f7f331635f8fb238d06c7e8044b1720216058a022e2d.svg" alt="Vue is the best" width="112" height="28" />
      </router-link>

      <span
        :class="{ 'navbar': true, 'navbar-burger': true, 'is-active': isActive }"
        @click='toggle'
      >
        <span></span>
        <span></span>
        <span></span>
      </span>

    </div>

    <div :class="{ 'navbar-menu': true, 'is-active': isActive }">
      <div class="navbar-start">

        <div class="navbar-item has-dropdown is-hoverable">
          <a class="navbar-link">Session</a>
          <div class="navbar-dropdown">
            <router-link class="navbar-item" :to="'/Sessions/Index'">
              Manage Session
            </router-link>
            <router-link class="navbar-item" :to="'/Sessions/Create'">
              Create Session
            </router-link>
          </div>
        </div>

        <div class="navbar-item has-dropdown is-hoverable">
          <a class="navbar-link">Customer</a>
          <div class="navbar-dropdown">
            <router-link class="navbar-item" :to="'/Customers/Index'">
              Manage Customers
            </router-link>
            <router-link class="navbar-item" :to="'/Customers/Create'">
              Create Customer
            </router-link>
          </div>
        </div>

      </div>

    </div>

  </nav>
</template>

<script>
import { routes } from '../routes'

export default {
  data () {
    return {
      routes,
      isActive: false
    }
  },
  methods: {
    toggle () {
      this.isActive = !this.isActive
    }
  }
}
</script>

<<style lang="scss" scoped>

</style>
