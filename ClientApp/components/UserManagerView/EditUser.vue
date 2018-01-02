<template>
  <div class="section">
    <div class="columns is-centered">
      <div class="column is-narrow">
        <h1 class="title is-spaced">Edit User Information</h1>

        <!-- Username -->
        <div class="field">
          <label for="userName"
                 class="label">Username</label>
          <p class="control">
            <input type="text"
                   name="userName"
                   class="input"
                   :class="{ 'is-danger': errors.has('userName') }"
                   placeholder="userName"
                   v-validate="'required|min:1|max:100'"
                   v-model="userName">
            <span v-show="errors.has('accountName')"
                  class="help is-danger">
              {{ errors.first('accountName') }}
            </span>
          </p>
        </div>

        <!-- Full name -->
        <div class="field">
          <label for="fullName"
                 class="label">Full name</label>
          <p class="control">
            <input type="text"
                   name="fullName"
                   class="input"
                   :class="{ 'is-danger': errors.has('fullName') }"
                   placeholder="fullName"
                   v-validate="'required'"
                   v-model="fullName">
            <span v-show="errors.has('fullName')"
                  class="help is-danger">
              {{ errors.first('fullName') }}
            </span>
          </p>
        </div>

        <!-- Email -->
        <div class="field">
          <label for="email"
                 class="label">Email</label>
          <p class="control">
            <input type="text"
                   name="email"
                   class="input"
                   :class="{ 'is-danger': errors.has('email') }"
                   placeholder="email"
                   v-validate="'required|email'"
                   v-model="email">
            <span v-show="errors.has('email')"
                  class="help is-danger">
              {{ errors.first('email') }}
            </span>
          </p>
        </div>

        <!-- Role -->
        <b-field label="Role">
        </b-field>
        <b-field>
          <b-radio v-model="role"
                   native-value="Admin">
            Admin
          </b-radio>
          <b-radio v-model="role"
                   native-value="Instructor">
            Instructor
          </b-radio>
        </b-field>

        <b-field grouped
                 group-multiline>
          <p class="control">
            <button type="submit"
                    class="button is-primary"
                    :class="{ 'is-loading': isLoading }"
                    @click="saveSynopsis">
              Save
            </button>
          </p>
          <p class="control">
            <button class="button is-danger"
                    @click="cancel">
              Cancel
            </button>
          </p>
        </b-field>

      </div>
    </div>
  </div>
</template>

<script>
import { get, put } from 'axios'
import router from '../../router'

export default {
  data () {
    return {
      userName: null,
      fullName: null,
      email: null,
      isLoading: false,
      role: null
    }
  },
  async created () {
    try {
      const { data } = await get(`/api/UserManager/${this.id}`)

      this.userName = data.user.userName
      this.fullName = data.user.fullName
      this.email = data.user.email
      this.role = data.roles[0]
    } catch (err) {
      console.error(err)
    }
  },
  props: {
    id: {
      type: [Number, String],
      required: true
    }
  },
  methods: {
    async saveSynopsis () {
      this.isLoading = !this.isLoading

      try {
        const { status } = await put(`/api/CustomerAccounts/${this.id}`, {
        })

        if (status === 204) {
          this.$toast.open({
            message: 'User record successfully updated!',
            type: 'is-success',
          })
        }
      } catch ({ response }) {
        let message

        switch (response.status) {
          case 400:
            message = 'Unable to update User record.'
            break
          default:
            message = 'Unable to update User record.'
            break
        }

        this.$toast.open({
          message,
          type: 'is-danger',
        })
      } finally {
        this.isLoading = !this.isLoading
      }
    },
    cancel () {
      router.go(-1)
    }
  }
}
</script>

<style lang="scss" scoped>

</style>
