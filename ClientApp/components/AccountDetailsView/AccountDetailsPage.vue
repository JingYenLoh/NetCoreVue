<template>
  <section class="section">
    <div class="columns is-centered">
      <div class="column is-narrow">
        <h1 class="title is-spaced">Account Details for {{ id }}</h1>

        <b-table :data="accountDetails"
                 striped
                 paginated
                 per-page="10">

          <template slot-scope="props">

            <!-- Day of Week -->
            <b-table-column field="dayOfWeekNumber"
                            label="Day">
              {{ props.row.dayOfWeekNumber }}
            </b-table-column>

            <!-- Start Time -->
            <b-table-column field="startTimeInMinutes"
                            label="Start Time">
              {{ formatTime(props.row.startTimeInMinutes) }}
            </b-table-column>

            <!-- End Time -->
            <b-table-column field="endTimeInMinutes"
                            label="End Time">
              {{ formatTime(props.row.endTimeInMinutes) }}
            </b-table-column>

            <!-- Start Date -->
            <b-table-column field="effectiveStartDate"
                            label="Effective Start Date">
              {{ new Date(props.row.effectiveStartDate).toDateString() }}
            </b-table-column>

            <!-- End Date -->
            <b-table-column field="effectiveEndDate"
                            label="Effective End Date">
              {{ props.row.effectiveEndDate ? new Date(props.row.effectiveEndDate).toDateString() : '~' }}
            </b-table-column>

            <!-- Visibility -->
            <b-table-column field="isVisible"
                            label="Visible">
              <b-icon v-if="props.row.isVisible"
                      pack="fa"
                      icon="check" />
            </b-table-column>

            <!-- Actions -->
            <b-table-column label="Actions">
              <router-link class="button is-info"
                           :to="{ name: 'editDetails', params: { id: props.row.accountDetailId }}">
                <b-icon pack="fa"
                        icon="pencil" />
                <span>Is this shit null {{ props.row.accountDetailId }}</span>
              </router-link>
            </b-table-column>

          </template>

          <template slot="footer">
            <router-link class="button is-primary"
                         :to="{ name: 'createDetails', param: { id: this.id }}">
              Add Account Detail
            </router-link>
          </template>

        </b-table>

      </div>
    </div>
  </section>
</template>

<script>
import { get } from 'axios'

export default {
  data () {
    return {
      accountDetails: []
    }
  },
  props: {
    id: [Number, String]
  },
  async created () {
    try {
      const { status, data } = await get(`/api/CustomerAccounts/Details/${this.id}`)
      console.log(data)
      if (status === 200) {
        this.accountDetails = data
      }
    } catch (e) {
      console.error(e)
    }
  },
  methods: {
    formatTime (val) {
      const hours = Math.floor(val / 60)
      const mins = val % 60
      return `${hours}:${mins >= 10 ? mins : '0' + mins}`
    }
  }
}
</script>

<style lang="scss" scoped>

</style>
