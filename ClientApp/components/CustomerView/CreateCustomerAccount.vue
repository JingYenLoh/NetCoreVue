<template>
  <div class="section">
    <div class="columns is-centered">
      <div class="column is-narrow">

        <h1 class="title is-spaced">Create Customer Account</h1>

        <div class="field">
          <label for="accountName"
                 class="label">
            Account Name
          </label>
          <div class="control">
            <input type="text"
                   name="accountName"
                   :class="{ 'input': true, 'is-danger': errors.has('accountName') }"
                   placeholder="e.g. Francesca"
                   v-validate="'required|min:1|max:100'"
                   v-model="customerAccName">
            <p v-show="errors.has('accountName')"
               class="help is-danger">
              {{ errors.first('accountName') }}
            </p>
          </div>
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
                    id="comments"
                    cols="30"
                    rows="3"
                    :class="{ 'textarea': true, 'is-danger': errors.has('comments') }"
                    v-validate="'max:4000'"
                    v-model="comments">
          </textarea>
        </b-field>
        <span v-show="errors.has('comments')"
              class="help is-danger">
          {{ errors.first('comments') }}
        </span>

        <label for="rate"
               class="label">Rate per hour</label>
        <p class="control">
          <input name="rate"
                 type="number"
                 :class="{ 'input': true, 'is-danger': errors.has('rate') }"
                 placeholder="e.g. 100"
                 v-validate="'decimal:2|min_value:0.01|max_value:9999.99'"
                 v-model="ratePerHr">
          <span v-show="errors.has('rate')"
                class="help is-dangers">
            {{ errors.first('rate') }}
          </span>
        </p>

        <b-field label="Effective Start Date">
          <b-datepicker icon="calendar"
                        :min-date="today"
                        placeholder="MM/DD/YYYY"
                        :readonly="false"
                        v-model="startDate">
          </b-datepicker>
        </b-field>

        <b-field label="Effective End Date">
          <b-datepicker icon="calendar"
                        :min-date="startDate"
                        placeholder="MM/DD/YYYY"
                        :readonly="false"
                        v-model="endDate">
          </b-datepicker>
        </b-field>

        <b-field grouped
                 group-multiline>
          <p class="control">
            <button type="submit"
                    class="button is-primary"
                    :class="{ 'is-loading': isLoading }"
                    @click="createAccount">
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
import { post } from 'axios'
import router from '../../router'

export default {
  data () {
    return {
      customerAccName: null,
      isVisible: 'On',
      comments: '',
      ratePerHr: 0,
      isLoading: false,
      startDate: null,
      endDate: null,
    }
  },
  created () {
    try {
      this.startDate = new Date()
    } catch (err) {
      console.error(err)
    }
  },
  methods: {
    async createAccount () {
      this.isLoading = !this.isLoading

      try {
        const { status } = await post('/api/CustomerAccounts', {
          accountName       : this.customerAccName,
          comments          : this.comments,
          isVisible         : this.isVisible === 'On',
          createdAt         : new Date(),
          createdById       : this.$store.state.userId,
          updatedAt         : new Date(),
          updatedById       : this.$store.state.userId,
          ratePerHour       : this.ratePerHr,
          effectiveStartDate: this.startDate,
          effectiveEndDate  : this.endDate
        })

        if (status === 201) {
          this.$toast.open({
            message: 'Customer Account successfully created!',
            type: 'is-success',
          })
        }
      } catch (e) {
        this.$toast.open({
          message: e.data.message,
          type: 'is-danger',
        })
      } finally {
        this.isLoading = !this.isLoading
      }
    },
    cancel () {
      router.go(-1)
    }
  },
  computed: {
    today () {
      return new Date()
    }
  }
}
</script>

<style lang="scss" scoped>

</style>
