<template>
  <nav class="navbar is-transparent" role="navigation" aria-label="main navigation">
    <div class="navbar-brand">

      <router-link class="navbar-item" to="/">
        <img src="https://sentry.io/_assets/logos/vue-wordmark-3eed5d97e4588a2d4f77f7f331635f8fb238d06c7e8044b1720216058a022e2d.svg" alt="Vue is the best" width="112" height="28" />
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
