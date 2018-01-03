<template>
  <div class="section">
    <div class="columns is-centered">
      <div class="column is-narrow">

        <h1 class="title is-spaced">Edit Account Rate</h1>

        <div class="field">
          <label for="ratePerHr"
                 class="label">Rate per Hour</label>
          <div class="control">
            <input type="number"
                   name="ratePerHr"
                   class="input"
                   :class="{ 'is-danger': errors.has('ratePerHr') }"
                   placeholder=""
                   v-validate="'required|min_value:0.01|decimal:2|max_value:9999.99'"
                   v-model="ratePerHour" />
            <p v-show="errors.has('ratePerHr')"
               class="help is-danger">
              {{ errors.first('ratePerHr') }}
            </p>
          </div>
        </div>

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
                    :disabled="errors.any()"
                    @click="editRate">
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
      accountRateId    : 0,
      customerAccountId: 0,
      ratePerHour      : 0,
      isLoading        : false,
      startDate        : null,
      endDate          : null,
    }
  },
  async created () {
    try {
      const { status, data } = await get(`/api/AccountRates/${this.id}`)

      if (status === 200) {
        this.accountRateId     = data.accountRateId
        this.customerAccountId = data.customerAccountId
        this.ratePerHour       = data.ratePerHour
        this.startDate         = new Date(data.effectiveStartDate)
        this.endDate           = data.effectiveEndDate == null ? null : new Date(data.effectiveEndDate)
      }
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
    async editRate () {
      this.isLoading = !this.isLoading

      try {
        const { status } = await put(`/api/AccountRates/${this.accountRateId}`, {
          accountRateId     : this.accountRateId,
          customerAccountId : this.customerAccountId,
          ratePerHour       : this.ratePerHour,
          effectiveStartDate: this.startDate,
          effectiveEndDate  : this.endDate
        })

        if (status === 200) {
          this.$toast.open({
            message: 'Account rate successfully edited!',
            type: 'is-success',
          })
        } else {
          this.$toast.open({
            message: 'Failed to edit Account rate',
            type: 'is-danger',
          })
        }
      } catch ({ response }) {
        let message

        switch (response.status) {
          case 400:
            message = response.data.message
            break
          case 404:
            message = 'Account rate not found!'
            break
          default:
            message = 'Failed to edit Account rate'
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
  },
  computed: {
    today () {
      return new Date()
    }
  }
}
</script>
