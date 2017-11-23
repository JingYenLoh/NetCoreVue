import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

// TYPES
const MAIN_SET_USER_ID = 'MAIN_SET_USER_ID'

// STATE
const state = {
  userId: null
}

// MUTATIONS
const mutations = {
  [MAIN_SET_USER_ID] (state, id) {
    state.userId = id
  }
}

// ACTIONS
const actions = ({
  // Doesn't need to be async really, but I was testing code out
  setUserId ({ commit }, id) {
    commit(MAIN_SET_USER_ID, id)
  }
})

export default new Vuex.Store({
  state,
  mutations,
  actions
})
