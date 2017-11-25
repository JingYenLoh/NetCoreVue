<template>
  <div class="section">
    <div class="columns is-centered">
      <div class="column is-narrow">

        <h1 class="title is-spaced">Add Account Rate for {{ accountName }}</h1>

        <div class="field">
          <label for="ratePerHr"
                 class="label">Rate per Hour</label>
          <p class="control">
            <input type="number"
                   name="ratePerHr"
                   class="input"
                   :class="{ 'is-danger': errors.has('ratePerHr') }"
                   :placeholder="ratePerHr"
                   v-validate="'required|min_value:0.01|decimal:2'"
                   v-model="ratePerHr">
            <p v-show="errors.has('ratePerHr')"
               class="help is-danger">
              {{ errors.first('ratePerHr') }}
            </p>
          </p>
        </div>

        <b-field label="Effective Start Date">
          <b-datepicker icon="calendar"
                        :min-date="minStartDate"
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
                    @click="createRate">
              Add
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
import axios from 'axios'
import router from '../../router'

export default {
  data () {
    return {
      accountName: '',
      ratePerHr: 0,
      isLoading: false,
      startDate: null,
      endDate: null,
      minStartDate: new Date()
    }
  },
  async created () {
    try {
      const accountResponse = await axios.get(`/api/CustomerAccounts/${this.id}`)
      const minDateResponse = await axios.get(`/api/AccountRates/LatestDate/${this.id}`)

      if (accountResponse.status === 200 && minDateResponse.status === 200) {
        this.accountName = accountResponse.data.accountName
        this.minStartDate = new Date(minDateResponse.data)
      }
      // this.startDate = Math.max(this.minStartDate, new Date())
      this.startDate = this.minStartDate > new Date() ? this.minStartDate : new Date()
      this.endDate = this.startDate
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
    async createRate () {
      this.isLoading = !this.isLoading

      let response
      try {
        // TODO:
        response = await axios.post('/api/AccountRates', {
          customerAccountId : this.id,
          ratePerHour       : this.ratePerHr,
          effectiveStartDate: this.startDate,
          effectiveEndDate  : this.endDate
        })

        if (response.status === 201) {
          this.$toast.open({
            message: 'Account rate successfully created!',
            type: 'is-success',
          })
        } else {
          // TODO: Use validation
          this.$toast.open({
            message: 'Failed to create Account rate',
            type: 'is-danger',
          })
        }
      } catch (err) {
        const inDevelopment = process.env.NODE_ENV === 'development'

        if (inDevelopment) {
          console.error(err)
        }

        const message = inDevelopment ? err.message : 'Failed to create Account rate'

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
