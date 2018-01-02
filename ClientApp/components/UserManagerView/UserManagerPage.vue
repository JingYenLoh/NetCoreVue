<template>
  <section class="section">
    <div class="container">
      <h1 class="title is-spaced">Users</h1>

      <b-table :data="users"
               striped
               paginated
               :per-page="perPage"
               default-sort-direction="asc"
               :selected.sync="selected"
               default-sort="userName">
        <template slot-scope="props">

          <!-- Id -->
          <b-table-column field="id"
                          label="Id">
            {{ props.row.id }}
          </b-table-column>

          <!-- Username -->
          <b-table-column field="userName"
                          label="Username"
                          sortable>
            {{ props.row.userName }}
          </b-table-column>

          <!-- Full Name -->
          <b-table-column field="fullName"
                          label="Full Name"
                          sortable>
            {{ props.row.fullName }}
          </b-table-column>

          <!-- Email -->
          <b-table-column field="email"
                          label="Email"
                          sortable>
            {{ props.row.email }}
          </b-table-column>

          <!-- EmailConfirmation -->
          <b-table-column field="emailConfirmed"
                          label="Verified">
            <span v-if="props.row.emailConfirmed"
                  class="tag is-success">
              True
            </span>
            <span v-else
                  class="tag is-danger">False</span>
          </b-table-column>

          <!-- Role -->
          <b-table-column field="roleName"
                          label="Role"
                          sortable>
            {{ props.row.roleName }}
          </b-table-column>

          <b-table-column label="Edit">
            <router-link class="button is-warning"
                         :to="{ name: 'editUser', params: { id: props.row.id }}">
              <b-icon pack="fa"
                      icon="pencil"></b-icon>
              <span>Edit User</span>
            </router-link>
          </b-table-column>

        </template>
      </b-table>
    </div>
  </section>
</template>

<script>
import { get } from 'axios'

export default {
  data () {
    return {
      users: [],
      perPage: 10,
      selected: null
    }
  },
  async created () {
    try {
      const { status, data } = await get('/api/UserManager')
      if (status === 200) {
        this.users = data
      }
    } catch (err) {
      console.error(err)
    }
  }
}
</script>
