<template>
  <table class="table">
    <thead>
      <tr>
        <th>CourseId</th>
        <th>CourseAbbreviation</th>
        <th>CourseName</th>
        <th>CreatedAt</th>
        <th>UpdatedAt</th>
        <th>DeletedAt</th>
        <th>CreatedById</th>
        <th>UpdatedById</th>
        <th>DeletedById</th>
        <th>CreatedBy</th>
        <th>UpdatedBy</th>
        <th>DeletedBy</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="course in courses" :key="course.CourseId">
        <th>{{ course.CourseId }}</th>
        <th>{{ course.CourseAbbreviation }}</th>
        <th>{{ course.CourseName }}</th>
        <th>{{ course.CreatedAt }}</th>
        <th>{{ course.UpdatedAt }}</th>
        <th>{{ course.DeletedAt }}</th>
        <th>{{ course.CreatedById }}</th>
        <th>{{ course.UpdatedById }}</th>
        <th>{{ course.DeletedById }}</th>
        <th>{{ course.CreatedBy }}</th>
        <th>{{ course.UpdatedBy }}</th>
        <th>{{ course.DeletedBy }}</th>
      </tr>
    </tbody>
  </table>
</template>

<<script>
import axios from 'axios'

export default {
  data () {
    return {
      courses: []
    }
  },
  async created () {
    try {
      let response = await axios.get('/api/Courses')
      this.courses = response.data
    } catch (err) {
      console.error(err)
    }
  }  
}
</script>

<style lang="scss" scoped>

</style>
