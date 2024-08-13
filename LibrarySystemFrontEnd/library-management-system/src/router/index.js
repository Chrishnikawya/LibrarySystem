import Vue from 'vue';
import Router from 'vue-router';
import HomePage from '../views/HomePage.vue'
import LoginPage from '../views/LoginPage.vue'
import SignupPage from '../views/SignupPage.vue'
import BookView from '../views/BookView.vue'
import MemberView from '../views/MemberView.vue'
import AuthorView from '../views/AuthorView.vue'
import StaffView from '../views/StaffView.vue'
import PublisherView from '../views/PublisherView.vue'
import ReservationView from '../views/ReservationView.vue'

Vue.use(Router);
export default new Router({
    mode: 'history',
    routes: [

  {path: '/', name: 'Home',component: HomePage},
  {path: '/login',name: 'Login',component: LoginPage},
  {path: '/signup', name: 'Signup',component: SignupPage },
  { path: '/book', name: 'Book',component: BookView  },
  { path: '/author', name: 'Author', component: AuthorView },
  { path: '/publisher', name: 'Publisher', component: PublisherView },
  { path: '/member', name: 'Member', component: MemberView },
  { path: '/staff', name: 'Staff', component: StaffView },
  { path: '/reservation', name: 'Reservation', component: ReservationView },
]
})





