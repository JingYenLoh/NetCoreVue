<template>
  <div>
    <h1 class="title is-spaced">Customer Accounts</h1>
    <table class="table">
      <thead>
        <tr>
          <th>Account name</th>
          <th># of Rates Data</th>
          <th># of Instructors</th>
          <th>Updated By</th>
          <th>Updated At</th>
          <th>Visibility</th>
          <th>Modify</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="customer in customers" :key="customer.customerAccountId">
          <td>{{ customer.accountName }}</td>
          <td>{{ customer.accountRates.length }}</td>
          <td>{{ customer.instructorAccounts }}</td>
          <td>{{ customer.updatedBy }}</td>
          <td>{{ customer.updatedAt }}</td>
          <td>
            <b-icon v-if="customer.isVisible" pack="fa" icon="check"></b-icon>
          </td>
          <td>
            <button class="button is-warning" @click="editCustomerAccount">
              <b-icon pack="fa" icon="pencil-square-o">
              </b-icon>
              <span>Edit</span>
            </button>
            <button class="button is-info" @click="manageRates">
              <b-icon pack="fa" icon="pencil-square-o">
              </b-icon>
              <span>Manage Rates</span>
            </button>
            <button class="button is-success" @click="manageAccountDetails">
              <b-icon pack="fa" icon="pencil-square-o">
              </b-icon>
              <span>Manage Details</span>
            </button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<<script>
import axios from 'axios'

// TODO: Pull instructor info as well (change API side)
export default {
  data () {
    return {
      customers: []
    }
  },
  async created () {
    try {
      let response = await axios.get('/api/CustomerAccounts')
      this.customers = response.data
    } catch (err) {
      console.error(err)
    }
  },
  methods: {
    editCustomerAccount () {
      window.alert('TODO: Launch edit customer account')
    },
    manageRates () {
      window.alert('TODO: Launch manage rates')
    },
    manageAccountDetails () {
      window.alert('TODO: Launch manage account details, probably a new route')
    }
  }
}
</script>

<style lang="scss" scoped>

</style>
