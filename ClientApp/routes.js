import HomePage from 'components/home-page'
import CoursePage from 'components/course-page'
import CustomerPage from 'components/customer-page'
import SessionPage from 'components/session-page'
import Login from 'components/LoginView/LoginPage'

export const routes = [
  { path: '/', component: HomePage, display: 'Home', style: 'fa fa-lg fa-home' },
  { path: '/Courses', component: CoursePage, display: 'Courses', style: 'fa fa-lg fa-graduation-cap' },
  { path: '/Customers', component: CustomerPage, display: 'Customer', style: 'fa fa-lg fa-user' },
  { path: '/Sessions', component: SessionPage, display: 'Sessions', style: 'fa fa-lg fa-clock-o' },
  { path: '/Login', component: Login, display: 'Login', style: 'fa fa-lg fa-user' }
]
