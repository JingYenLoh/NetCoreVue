<template>
  <nav class="navbar is-transparent" role="navigation" aria-label="main navigation">
    <div class="navbar-brand">
      <router-link class="navbar-item" to="/">
        <img src="http://bulma.io/images/bulma-logo.png" alt="Bulma: a modern CSS framework based on Flexbox" width="112" height="28">
      </router-link>

      <router-link v-for="route in routes" :key="route.path" :to="route.path" class="navbar-item">
        <span class="icon">
          <i :class="route.style"></i>
        </span>
        {{ route.display }}
      </router-link>

      <button class="button navbar-burger">
        <span></span>
        <span></span>
        <span></span>
      </button>
    </div>
  </nav>
</template>

<script>
import { routes } from '../routes'

export default {
  data() {
    return {
      routes
    }
  }
}
</script>

<<style lang="scss" scoped>

</style>
