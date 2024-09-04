import Vue from 'vue';
import Router from 'vue-router';
import HomePage from '../views/HomePage.vue';
import LoginPage from '../views/LoginPage.vue';
import SignupPage from '../views/SignupPage.vue';
import BookView from '../views/BookView.vue';
import MemberView from '../views/MemberView.vue';
import AuthorView from '../views/AuthorView.vue';
import StaffView from '../views/StaffView.vue';
import PublisherView from '../views/PublisherView.vue';
import ReservationView from '../views/ReservationView.vue';
import CategoryView from '../views/CategoryView.vue';
Vue.use(Router);


const isAuthenticated = () => {
  return !!localStorage.getItem('authToken'); 
};

const router = new Router({
  mode: 'history',
  routes: [
    { path: '/', name: 'Home', component: HomePage },
    { path: '/login', name: 'Login', component: LoginPage },
    { path: '/signup', name: 'Signup', component: SignupPage },
    { path: '/book', name: 'Book', component: BookView, meta: { requiresAuth: true } },
    { path: '/author', name: 'Author', component: AuthorView, meta: { requiresAuth: true } },
    { path: '/publisher', name: 'Publisher', component: PublisherView, meta: { requiresAuth: true } },
    { path: '/member', name: 'Member', component: MemberView, meta: { requiresAuth: true } },
    { path: '/staff', name: 'Staff', component: StaffView, meta: { requiresAuth: true } },
    { path: '/reservation', name: 'Reservation', component: ReservationView, meta: { requiresAuth: true } },
    { path: '/category', name: 'Category', component: CategoryView, meta: { requiresAuth: true } },
  ]
});


export default router;
