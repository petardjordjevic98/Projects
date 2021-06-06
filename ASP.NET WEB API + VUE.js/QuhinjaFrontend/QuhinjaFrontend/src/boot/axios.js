import Vue from 'vue'
import axios from 'axios'
import { Store } from 'src/store'

Vue.prototype.$axios = axios
axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';

const initialStore = localStorage.getItem('quhinjaStore')

if (initialStore) {
  Store.commit('auth/initialize', JSON.parse(initialStore))
  if (Store.getters['auth/isAuthenticated']) {
    axios.defaults.headers.common.Authorization = `Bearer ${Store.state.auth.auth.accessToken}`
  }
}
