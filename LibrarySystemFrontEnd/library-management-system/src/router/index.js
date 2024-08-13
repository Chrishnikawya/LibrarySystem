import Vue from 'vue';
import Router from 'vue-router';
import HomePage from '../views/HomePage.vue'
import LoginPage from '../views/LoginPage.vue'
import SignupPage from '../views/SignupPage.vue'
Vue.use(Router);
export default new Router({
    mode: 'history',
    routes: [

  {
    path: '/',
    name: 'Home',
    component: HomePage
  },
  {
    path: '/login',
    name: 'Login',
    component: LoginPage
  },
  {
    path: '/signup',
    name: 'Signup',
    component: SignupPage
  }
]
})





