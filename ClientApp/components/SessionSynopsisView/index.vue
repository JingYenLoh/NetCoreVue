<template>
  <router-view>
  </router-view>
</template>

<script>
import Vue from 'vue'
import CreateSessionSynopsis from './CreateSessionSynopsis'
import SessionSynopsisPage from './SessionSynopsisPage'

Vue.component('session-synopsis-index', SessionSynopsisPage)
Vue.component('create-session-synopsis', CreateSessionSynopsis)

export default {
  data() {
    return {

    }
  }
}
</script>

<style lang="scss" scoped>

</style>
