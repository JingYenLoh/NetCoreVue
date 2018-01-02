<template>
  <div class="section">
    <div class="columns is-centered">
      <div class="column is-narrow">
        <h1 class="title is-spaced">Create Session Synopsis</h1>

        <div class="field">
          <label for="synopsis"
                 class="label">Session Synopsis Name</label>
          <p class="control">
            <input v-validate="'required|min:1|max:100|alpha_spaces'"
                   name="synopsis"
                   class="input"
                   :class="{ 'is-danger': errors.has('synopsis') }"
                   type="text"
                   placeholder="Enter a Session Synopsis"
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
                    :class="{ 'is-loading': isLoading }"
                    :disabled="errors.any()"
                    @click="saveSynopsis">
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
      sessionSynopsisName: '',
      isVisible: 'On',
      isLoading: false,
    }
  },
  methods: {
    async saveSynopsis () {
      this.isLoading = !this.isLoading

      try {
        const { status } = await post('/api/SessionSynopsis', {
          sessionSynopsisName: this.sessionSynopsisName,
          createdById        : this.$store.state.userId,
          updatedById        : this.$store.state.userId,
          isVisible          : this.isVisible === 'On'
        })

        if (status === 201) {
          this.$toast.open({
            message: 'Session Synopsis successfully created!',
            type: 'is-success'
          })
        }
      } catch ({ response }) {
        let message

        switch (response.status) {
          case 409:
            message = 'A session synopsis with the same name already exists.'
            break
          default:
            message = 'Failed to create Session Synopsis'
            break
        }

        this.$toast.open({
          message,
          type: 'is-danger'
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
