<template>
  <div class="section">
    <div class="columns is-centered">
      <div class="column is-narrow">
        <h1 class="title is-spaced">Update Session Synopsis</h1>

        <div class="field">
          <label for="synopsis"
                 class="label">Session Synopsis Name</label>
          <p class="control">
            <input name="synopsis"
                   :class="{ 'input': true, 'is-danger': errors.has('synopsis') }"
                   type="text"
                   :placeholder="sessionSynopsisName"
                   v-validate="'required|min:1|max:100'"
                   v-model="sessionSynopsisName">
            <p v-show="errors.has('synopsis')"
               class="help is-danger">
              {{ errors.first('synopsis') }}
            </p>
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
        <b-field grouped
                 group-multiline>
          <p class="control">
            <button type="submit"
                    class="button is-primary"
                    v-bind:class="{ 'is-loading': isLoading }"
                    @click="editSynopsis">
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
import axios from 'axios'
import router from '../../router'

// Custom validation
import { sessionSynopsisRule } from '../../helpers/validators'

export default {
  data () {
    return {
      sessionSynopsisName: '',
      isVisible: 'On',
      isLoading: false,
      createdById: null
    }
  },
  async created () {
    try {
      let response = await axios.get(`/api/SessionSynopsis/${this.id}`)
      this.sessionSynopsisName = response.data.sessionSynopsisName
      this.createdById = response.data.createdById
    } catch (err) {
      console.error(err)
    }
  },
  props: {
    id: {
      type: [ Number, String ],
      required: true
    }
  },
  methods: {
    async editSynopsis () {
      this.isLoading = !this.isLoading

      let response
      try {
        response = await axios.put(`/api/SessionSynopsis/${this.id}`, {
          sessionSynopsisId: this.id,
          sessionSynopsisName: this.sessionSynopsisName,
          createdById: this.createdById,
          updatedById: this.$store.state.userId,
          isVisible: this.isVisible === 'On'
        })

        if (response.status === 200) {
          this.$toast.open({
            message: 'Session Synopsis successfully updated!',
            type: 'is-success',
          })
        } else {
          this.$toast.open({
            message: 'Failed to update Session Synopsis',
            type: 'is-danger',
          })
        }
      } catch (err) {
        const inDevelopment = process.env.NODE_ENV === 'development'

        if (inDevelopment) {
          console.error(err)
        }

        const message = inDevelopment ? err.message : 'Failed to update Session Synopsis'

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
