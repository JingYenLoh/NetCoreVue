<template>
  <section class="hero is-medium">
    <!-- Hero head: will stick at the top -->
    <div class="hero-head"></div>

    <!-- Hero content: will be in the middle -->
    <div class="hero-body">
      <div class="container">
        <h1 class="title">Log in</h1>
        <h2 class="subtitle">Use a local account to log in.</h2>
        <b-field label="Staff Id">
          <b-input></b-input>
        </b-field>
        <b-field label="Password">
          <b-input type="password" maxlength="30"></b-input>
        </b-field>
      </div>
    </div>

    <!-- Hero footer: will stick at the bottom -->
    <div class="hero-foot">
      &copy; {{ year }} - {{ appName }}
    </div>
  </section>
</template>

<script>
export default {
  data() {
    return {
      year: new Date().getFullYear(),
      appName: 'NetCoreVue'
    }
  }
}
</script>

<style lang="scss" scoped>

</style>
