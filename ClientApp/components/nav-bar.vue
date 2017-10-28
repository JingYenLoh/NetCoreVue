<template>
  <nav class="navbar is-transparent" role="navigation" aria-label="main navigation">
    <div class="navbar-brand">

      <router-link class="navbar-item" to="/">
            <img src="https://vuejs.org/images/logo.png" alt="Vue is the best" width="28" height="28" />
      </router-link>

      <span
            class="navbar navbar-burger"
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
  }
}
</script>

<<style lang="scss" scoped>

</style>
