<template>
  <table class="table">
    <thead>
      <tr>
        <th>Id</th>
        <th>Session Name</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="session in sessions" :key="session.SessionSynopsisId">
        <td>{{ session.SessionSynopsisId }}</td>
        <td>{{ session.SessionSynopsisName }}</td>
      </tr>
    </tbody>
  </table>
</template>

<<script>
export default {
  data () {
    return {
      sessions: []
    }
  },
  async created () {
    try {
      let response = await this.$http.get('/api/SessionSynopsis')
      this.sessions = response.data
    } catch (err) {
      console.error(err)
    }
  }  
}
</script>

<style lang="scss" scoped>

</style>
