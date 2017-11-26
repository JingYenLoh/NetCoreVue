<template>
  <div class="section">
    <div class="columns is-centered">
      <div class="column is-narrow">
        <h1 class="title is-spaced">Edit Customer Account</h1>
        <h1 class="subtitle">General Information</h1>

        <div class="field">
          <label for="accountName" class="label">Account Name</label>
          <p class="control">
            <input
              type="text"
              name="accountName"
              class="input"
              :class="{ 'is-danger': errors.has('accountName') }"
              placeholder="customerAccName"
              v-validate="'required|min:1|max:100'"
              v-model="customerAccName"
            >
            <span v-show="errors.has('accountName')" class="help is-danger">
              {{ errors.first('accountName') }}
            </span>
          </p>
        </div>

        <b-field label="Visibility">
          <div class="field">
            <b-switch v-model="isVisible" true-value="On" false-value="Off">
              {{ isVisible }}
            </b-switch>
          </div>
        </b-field>

        <b-field label="Comments"></b-field>
        <!-- This isn't inside the previous b-field because of a Bulma bug -->
        <b-field>
          <textarea
            name="comments"
            cols="30"
            rows="3"
            :class="{ 'textarea': true, 'is-danger': errors.has('comments') }"
            v-validate="'max:4000'"
            v-model="comments"
          >
          </textarea>
        </b-field>
        <span v-show="errors.has('comments')" class="help is-danger">
          {{ errors.first('comments') }}
        </span>

        <b-field grouped group-multiline>
          <p class="control">
            <button
              type="submit"
              class="button is-primary"
              :class="{ 'is-loading': isLoading }"
              @click="saveSynopsis"
            >
              Save
            </button>
          </p>
          <p class="control">
            <button class="button is-danger" @click="cancel">
              Cancel
            </button>
          </p>
        </b-field>

      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
import router from '../../router'

export default {
  data () {
    return {
      comments: '',
      createdAt: null,
      createdById: null,
      customerAccName: null,
      endDate: null,
      isLoading: false,
      isVisible: 'On',
      ratePerHr: 0,
      startDate: null,
      updatedById: null,
    }
  },
  async created () {
    try {
      let response = await axios.get(`/api/CustomerAccounts/${this.id}`)

      const data = response.data

      this.customerAccName = data.accountName
      this.isVisible       = data.isVisible === true ? 'On': 'Off'
      this.comments        = data.comments
      this.startDate       = data.startDate
      this.endDate         = data.endDate
      this.createdById     = data.createdById
      this.createdAt       = data.createdAt
      this.updatedById     = data.updatedById
    } catch (err) {
      console.error(err)
    }
  },
  props: {
    id: {
      type: [ Number, String ],
      required: true
    }
  },
  methods: {
    async saveSynopsis () {
      this.isLoading = !this.isLoading

      let response
      try {
        response = await axios.put(`/api/CustomerAccounts/${this.id}`, {
          customerAccountId: this.id,
          accountName      : this.customerAccName,
          isVisible        : this.isVisible === 'On',
          comments         : this.comments,
          createdById      : this.createdById,
          createdAt        : this.createdAt,
          updatedById      : this.$store.state.userId,
          updatedAt        : new Date()
        })

        if (response.status === 204) {
          this.$toast.open({
            message: 'Session Synopsis successfully updated!',
            type: 'is-success',
          })
        } else {
          // TODO: Use validation
          this.$toast.open({
            message: 'Failed to update Session Synopsis',
            type: 'is-danger',
          })
        }
      } catch (err) {
        const inDevelopment = process.env.NODE_ENV === 'development'

        if (inDevelopment) {
          console.error(err)
        }

        const message = inDevelopment ? err.message : 'Failed to update Session Synopsis'

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
