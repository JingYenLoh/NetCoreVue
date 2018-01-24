<template>
  <section class="section">
    <div class="columns is-centered">
      <div class="column is-narrow">
        <h1 class="title is-spaced">Add Account Details for {{ id }}</h1>

        <template>
          <section>

            <!-- Day -->
            <b-field label="Day">
              <b-select placeholder="Select a day"
                        v-model="accountDetail.dayOfWeekNumber">
                <option v-for="day in DAYS_OF_WEEK"
                        :value="day.value"
                        :key="day.key">
                  {{ day.key }}
                </option>
              </b-select>
            </b-field>

            <!-- Lesson Start Time -->
            <b-field label="Lesson Start Time">
              <b-timepicker placeholder="Type or select a date..."
                            :increment-minutes="15"
                            icon="clock-o"
                            v-model="accountDetail.startTime"
                            :readonly="false" />
            </b-field>

            <!-- Lesson End Time -->
            <b-field label="Lesson End Time">
              <b-timepicker placeholder="Type or select a date..."
                            :increment-minutes="15"
                            icon="clock-o"
                            :min-time="accountDetail.startTime"
                            v-model="accountDetail.endTime"
                            :readonly="false" />
            </b-field>

            <!-- Start Date -->
            <b-field label="Effective Start Date">
              <b-datepicker placeholder="Type or select a date..."
                            icon="calendar"
                            v-model="accountDetail.effectiveStartDate"
                            :readonly="false" />
            </b-field>

            <!-- End Date -->
            <b-field label="Effective End Date">
              <b-datepicker placeholder="Type or select a date..."
                            icon="calendar"
                            v-model="accountDetail.effectiveEndDate"
                            :readonly="false" />
            </b-field>

            <!-- Visibility -->
            <b-field label="Visibility">
              <div class="field">
                <b-switch v-model="accountDetail.isVisible">
                  {{ accountDetail.isVisible === true ? 'On' : 'Off' }}
                </b-switch>
              </div>
            </b-field>

            <b-field grouped
                     group-multiline>
              <p class="control">
                <button type="submit"
                        class="button is-primary"
                        :class="{ 'is-loading': isLoading }"
                        :disabled="errors.any()"
                        @click="createDetail">
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

          </section>
        </template>

      </div>
    </div>
  </section>
</template>

<script>
import { post } from 'axios'
import { DAYS_OF_WEEK } from '../../helpers/constants'

export default {
  data () {
    return {
      isLoading: false,
      isVisible: 'On',
      accountDetail: {
        dayOfWeekNumber    : 1,
        startTime          : null,
        endTime            : null,
        effectiveStartDate : new Date(),
        effectiveEndDate   : null,
        isVisible          : 'Off'
      }
    }
  },
  created () {
    this.DAYS_OF_WEEK = DAYS_OF_WEEK
  },
  props: {
    id: [Number, String]
  },
  methods: {
    cancel () {
      this.$router.go(-1)
    },
    async createDetail () {
      this.isLoading = true
      try {
        const accDetails = {
          customerAccountId  : parseInt(this.id),
          dayOfWeekNumber    : this.accountDetail.dayOfWeekNumber,
          startTimeInMinutes : this.startTimeInMins,
          endTimeInMinutes   : this.endTimeInMins,
          effectiveStartDate : this.accountDetail.effectiveStartDate,
          effectiveEndDate   : this.accountDetail.effectiveEndDate,
          isVisible          : this.accountDetail.isVisible === 'On' ? true : false
        }

        const { status, data } = await post(`/api/AccountDetails/${this.id}`, accDetails)
        if (status === 201) {
          this.$toast.open({
            message: 'Account Detail successfully created!',
            type: 'is-success'
          })
        }
      } catch ({ response }) {
        let message

        switch (response.status) {
          case 400:
            message = 'A Bad request was made.'
            break
          default:
            message = 'The server was unable to process the request. Try again later?'
            break
        }

        this.$toast.open({
          message,
          type: 'is-danger'
        })
      } finally {
        this.isLoading = false
      }
    }
  },
  computed: {
    startTimeInMins () {
      return this.accountDetail.startTime.getHours() * 60 +
        this.accountDetail.startTime.getMinutes()
    },
    endTimeInMins () {
      return this.accountDetail.endTime.getHours() * 60 +
        this.accountDetail.endTime.getMinutes()
    }
  }
}
</script>
