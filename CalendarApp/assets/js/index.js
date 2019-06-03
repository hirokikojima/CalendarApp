import Vue from 'vue';
import Vuex from 'vuex';
import VueRouter from 'vue-router';
import NavbarComponent from './components/navbar.vue';
import routerSetting from './router.js'
import storeSetting from './store.js'

import 'fullcalendar/dist/fullcalendar.css'

Vue.use(Vuex)
Vue.use(VueRouter)

Vue.component('component-navbar', NavbarComponent)

const router = new VueRouter(routerSetting)
const store = new Vuex.Store(storeSetting)

new Vue({
  router,
  store,
  el: '#app'
})