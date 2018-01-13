<template>
  <div id="app">
    <nav-bar :name="fullName" />
    <router-view/>
  </div>
</template>

<script>
import Vue from 'vue'
import NavBar from './NavBar.vue'
import { mapActions } from 'vuex'

export default {
  data () {
    return {
      fullName: ''
    }
  },
  components: {
    'nav-bar': NavBar
  },
  created () {
    const userId = document.getElementById('user-id').innerHTML
    this.fullName = document.getElementById('full-name').innerHTML
    this.setUserId(userId)
  },
  methods: {
    ...mapActions([
      'setUserId'
    ])
  }
}
</script>

<style lang="scss">
// Import Bulma's core
@import "~bulma/sass/utilities/_all";

// Set your colors
$primary: #6b69d6;
$primary-invert: findColorInvert($primary);

// Setup $colors to use as bulma classes (e.g. 'is-twitter')
$colors: (
  "white" : ($white, $black),
  "black" : ($black, $white),
  "light" : ($light, $light-invert),
  "dark" : ($dark, $dark-invert),
  "primary": ($primary, $primary-invert),
  "info" : ($info, $info-invert),
  "success": ($success, $success-invert),
  "warning": ($warning, $warning-invert),
  "danger" : ($danger, $danger-invert)
);

// Links
$link: $primary;
$link-invert: $primary-invert;
$link-focus-border: $primary;

// Import Bulma and Buefy styles
@import "~bulma";
@import "~buefy/src/scss/buefy";
</style>
