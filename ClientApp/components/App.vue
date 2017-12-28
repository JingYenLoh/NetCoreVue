<template>
  <div id="app">
    <nav-bar/>
    <router-view/>
  </div>
</template>

<script>
import Vue from 'vue'
import NavBar from './nav-bar.vue'
import { mapActions } from 'vuex'

Vue.component('nav-bar', NavBar)

export default {
  data () {
    return {

    }
  },
  created () {
    const userId = document.getElementById('user-id').innerHTML
    this.setUserId(userId)
  },
  methods: {
    ...mapActions([
      'setUserId'
    ])
  }
}
</script>

<<style lang="scss" scoped>

</style>
