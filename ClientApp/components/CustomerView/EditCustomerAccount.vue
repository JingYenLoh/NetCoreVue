<template>
  <div class="section">
    <div class="columns is-centered">
      <div class="column is-narrow">
        <h1 class="title is-spaced">Edit Customer Account</h1>
        <h1 class="subtitle">General Information</h1>

        <div class="field">
          <label for="accountName"
                 class="label">Account Name</label>
          <p class="control">
            <input type="text"
                   name="accountName"
                   class="input"
                   :class="{ 'is-danger': errors.has('accountName') }"
                   placeholder="customerAccName"
                   v-validate="'required|min:1|max:100'"
                   v-model="customerAccName">
            <span v-show="errors.has('accountName')"
                  class="help is-danger">
              {{ errors.first('accountName') }}
            </span>
          </p>
        </div>

        <b-field label="Visibility">
          <div class="field">
            <b-switch v-model="isVisible"
                      true-value="On"
                      false-value="Off">
              {{ isVisible }}
            </b-switch>
          </div>
        </b-field>

        <b-field label="Comments"></b-field>
        <!-- This isn't inside the previous b-field because of a Bulma bug -->
        <b-field>
          <textarea name="comments"
                    cols="40"
                    rows="10"
                    :class="{ 'textarea': true, 'is-danger': errors.has('comments') }"
                    v-validate="'max:4000'"
                    v-model="comments">
          </textarea>
        </b-field>
        <span v-show="errors.has('comments')"
              class="help is-danger">
          {{ errors.first('comments') }}
        </span>

        <b-field grouped
                 group-multiline>
          <p class="control">
            <button type="submit"
                    class="button is-primary"
                    :class="{ 'is-loading': isLoading }"
                    :disabled="errors.any()"
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
      const { data } = await get(`/api/CustomerAccounts/${this.id}`)
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
      type: [Number, String],
      required: true
    }
  },
  methods: {
    async saveSynopsis () {
      this.isLoading = !this.isLoading

      try {
        const { status } = await put(`/api/CustomerAccounts/${this.id}`, {
          customerAccountId: this.id,
          accountName      : this.customerAccName,
          isVisible        : this.isVisible === 'On',
          comments         : this.comments,
          createdById      : this.createdById,
          createdAt        : this.createdAt,
          updatedById      : this.$store.state.userId,
          updatedAt        : new Date()
        })

        if (status === 204) {
          this.$toast.open({
            message: 'Customer Account successfully updated!',
            type: 'is-success',
          })
        }
      } catch ({ response }) {
        let message

        switch (response.status) {
          case 400:
            message = 'Please input all fields properly.'
            break
          case 404:
            message = 'Unable to find the Account you are editing for.'
            break
          default:
            message = 'Failed to update Customer Account.'
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
