<template>
  <section class="section">
    <div class="columns is-centered">
      <div class="column is-narrow">
        <h1 class="title is-spaced">Update Account Details for {{ id }}</h1>

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
                            :min-date="new Date()"
                            v-model="accountDetail.effectiveStartDate"
                            :readonly="false" />
            </b-field>

            <!-- End Date -->
            <b-field label="Effective End Date">
              <b-datepicker placeholder="Type or select a date..."
                            icon="calendar"
                            :min-date="accountDetail.effectiveStartDate"
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
                        @click="editDetail">
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
import { get, put } from 'axios'
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
  // data () {
  //   return {
  //     isLoading: false,
  //     accountDetail: {
  //       dayOfWeekNumber    : 1,
  //       startTime          : null,
  //       endTime            : null,
  //       effectiveStartDate : new Date(),
  //       effectiveEndDate   : null,
  //       isVisible          : 'Off'
  //     }
  //   }
  // },
  props: {
    id: [Number, String]
  },
  async created () {
    this.DAYS_OF_WEEK = DAYS_OF_WEEK
    // try {
    //   console.log(this.id)
    //   const { status, data } = await get(`/api/AccountDetails/${this.id}`)
    //   console.log(data)
    //   if (status === 200) {
    //     this.accountDetail = {
    //       ...this.accountDetail,
    //       dayOfWeekNumber   : data.dayOfWeekNumber,
    //       effectiveStartDate: new Date(data.effectiveStartDate),
    //       effectiveEndDate  : data.effectiveEndDate ? new Date(data.effectiveEndDate) : null,
    //       isVisible         : data.isVisible === true ? 'On': 'Off'
    //     }
    //   }
    // } catch (e) {
    //   console.error(e)
    // }
  },
  methods: {
    cancel () {
      this.$router.go(-1)
    },
    async editDetail () {
      // const { status } = await put(`/api/AccountDetails/${this.id}`, {

      // })
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

