<template>
  <div id="app" class="container is-fluid">
    <div class="container">
      <nav-bar></nav-bar>
    </div>
    <div class="container">
      <section class="section">
        <router-view></router-view>
      </section>
    </div>
  </div>
</template>

<script>
import Vue from 'vue'
import NavBar from './nav-bar.vue'

Vue.component('nav-bar', NavBar)

export default {
  data() {
    return {

    }
  }
}
</script>

<<style lang="scss" scoped>

</style>
