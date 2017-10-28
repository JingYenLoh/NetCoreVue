<template>
  <div id="app">
    <nav-bar></nav-bar>

    <router-view></router-view>
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
