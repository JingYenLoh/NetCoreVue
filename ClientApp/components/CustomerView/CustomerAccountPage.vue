<template>
  <div class="section">
    <div class="container">
      <h1 class="title is-spaced">Customer Accounts</h1>

      <b-table :data="customers"
               striped
               paginated
               :per-page="perPage"
               default-sort-direction="asc"
               :selected.sync="selected"
               default-sort="accountName">
        <template slot-scope="props">

          <!-- Account Name -->
          <b-table-column field="accountName"
                          label="Account Name"
                          sortable>
            {{ props.row.accountName }}
          </b-table-column>

          <!-- Rates Data -->
          <b-table-column field="accountRates"
                          label="# of Rates Data"
                          numeric>
            {{ props.row.numAccountRates }}
          </b-table-column>

          <!-- Comments -->
          <b-table-column field="comments"
                          label="comments">
            {{ props.row.comments.slice(0, 20) }}
            <span v-if="props.row.comments.length > 20"
                  class="tag is-info"
                  @click="showComments(props.row.comments)">
              ...
            </span>
          </b-table-column>

          <b-modal :active.sync="showModal">
            <div class="card">
              <div class="card-content">
                <div class="content">{{ comments }}</div>
              </div>
            </div>
          </b-modal>

          <b-table-column field="instructorAccounts"
                          label="# of Instructors"
                          numeric>
            {{ props.row.numInstructors }}
          </b-table-column>

          <b-table-column field="updatedBy"
                          label="Updated By"
                          sortable>
            {{ props.row.updatedBy }}
          </b-table-column>

          <b-table-column field="updatedAt"
                          label="Updated At"
                          sortable>
            <span class="tag is-info">
              {{ new Date(props.row.updatedAt).toLocaleString() }}
            </span>
          </b-table-column>

          <b-table-column field="isVisible"
                          label="Visibility">
            <b-icon v-if="props.row.isVisible"
                    pack="fa"
                    icon="check" />
          </b-table-column>

          <b-table-column label="Modify">
            <router-link class="button is-warning"
                         :to="{ name: 'editCustomer', params: { id: props.row.customerAccountId }}">
              <b-icon pack="fa"
                      icon="pencil" />
              <span>Edit</span>
            </router-link>
            <router-link class="button is-info"
                         :to="{ name: 'manageRates', params: { id: props.row.customerAccountId, name: props.row.accountName }}">
              <b-icon pack="fa"
                      icon="pencil" />
              <span>Rates</span>
            </router-link>
            <router-link class="button is-info"
                         :to="`/AccountDetails/${props.row.customerAccountId}`">
              <b-icon pack="fa"
                      icon="pencil" />
              <span>Details</span>
            </router-link>
            <button class="button is-danger"
                    @click="confirmDelete(props.row.customerAccountId)">
              <b-icon pack="fa"
                      icon="trash-o" />
              <span>Delete</span>
            </button>
          </b-table-column>

        </template>

        <!-- Footer -->
        <template slot="footer">
          <button class="button is-primary"
                  @click="createCustomerAccount()">
            Create Account
          </button>
        </template>

      </b-table>
    </div>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  data () {
    return {
      customers: [],
      perPage: 10,
      selected: null,
      showModal: false,
      comments: ''
    }
  },
  async created () {
    try {
      const { data } = await axios.get('/api/CustomerAccounts')
      this.customers = data
    } catch (err) {
      console.error(err)
    }
  },
  methods: {
    confirmDelete (id) {
      this.$dialog.confirm({
        title: 'Deleting account',
        message: 'Are you sure you want to <b>delete</b> this customer account? This action cannot be undone.',
        confirmText: 'Delete Account',
        type: 'is-danger',
        hasIcon: true,
        onConfirm: () => {
          axios.delete(`/api/CustomerAccounts/${id}`)
            .then(({ status }) => {
              if (status === 200) {
                return true
              } else {
                throw new Error(status)
              }
            }).then(() => axios.get('/api/CustomerAccounts'))
            .then(({ data }) => this.customers = data)
            .then(() => this.$toast.open('Customer Account deleted!'))
            .catch(err => console.error(err))
        }
      })
    },
    createCustomerAccount () {
      this.$router.push('/Customers/Create')
    },
    showComments(comments) {
      this.showModal = true
      this.comments = comments
    }
  }
}
</script>

<style lang="scss" scoped>
span.tag.is-info {
  cursor: pointer;
}

.card-content .content {
  overflow-wrap: break-word;
}
</style>
