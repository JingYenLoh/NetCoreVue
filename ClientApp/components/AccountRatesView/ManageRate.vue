<template>
  <div class="section">
    <div class="container">
      <h1 class="title is-spaced">Account Rates for {{ name }}</h1>
      <b-table :data="accountRates"
               striped
               paginated
               :per-page="perPage"
               default-sort-direction="asc"
               :selected.sync="selected"
               default-sort="effectiveStartDate">
        <template slot-scope="props">

          <!-- <b-table-column field="customerAccountName" label="Customer Account Name">
              {{ props.row.customerAccountName }}
            </b-table-column> -->

          <b-table-column field="effectiveStartDate"
                          label="Effective Start Date"
                          sortable>
            {{ new Date(props.row.effectiveStartDate).toLocaleString() }}
          </b-table-column>

          <b-table-column field="effectiveEndDate"
                          label="Effective End Date"
                          sortable>
            <!-- Display ~ if effectiveEndDate is null -->
            {{ props.row.effectiveEndDate === null ? '~' : new Date(props.row.effectiveEndDate).toLocaleString() }}
          </b-table-column>

          <b-table-column field="ratePerHour"
                          label="Hourly rate"
                          sortable>
            {{ props.row.ratePerHour }}
          </b-table-column>

          <b-table-column label="Actions">
            <router-link class="button is-warning"
                         :to="{ name: 'editRates', params: { id: props.row.accountRateId }}">
              <b-icon pack="fa"
                      icon="pencil"></b-icon>
              <span>Update</span>
            </router-link>
          </b-table-column>
        </template>

        <!-- Footer -->
        <template slot="footer">
          <button class="button is-primary"
                  @click="addAccountRate">
            Add Rate
          </button>
        </template>

      </b-table>
    </div>
  </div>
</template>

<script>
import Vue from 'vue'
import axios from 'axios'
import AccountError from './Error'

Vue.component('error', AccountError)

export default {
  data () {
    return {
      account: null,
      accountRates: [],
      isPaginated: true,
      defaultSortDirection: 'asc',
      perPage: 10,
      selected: null
    }
  },
  async created () {
    try {
      const response = await axios.get(`/api/AccountRates/CustomerAccountRates/${this.id}`)

      if (response.status === 200) {
        this.accountRates = response.data
      } else {
        this.$router.push({ path: '/Error' })
      }
    } catch (err) {
      console.log(typeof(err))
    }
  },
  props: {
    id: {
      type: [Number, String],
      required: true
    },
    name: {
      type: String,
      required: true
    }
  },
  methods: {
    addAccountRate () {
      this.$router.push({ name: 'createRates', params: { id: this.id } })
    }
  }
}
</script>

<style lang="scss" scoped>

</style>
