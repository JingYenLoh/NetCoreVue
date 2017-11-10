import HomePage from 'components/home-page'
import ErrorPage from 'components/ErrorView'
import CoursePage from 'components/course-page'

// Customer Account
import CustomerHome from 'components/CustomerView/index'
import CustomerPage from 'components/CustomerView/CustomerAccountPage'
import EditCustomer from 'components/CustomerView/EditCustomerAccount'
import CreateCustomer from 'components/CustomerView/CreateCustomerAccount'

// Session Synopsis
import SessionHome from 'components/SessionSynopsisView/index'
import SessionPage from 'components/SessionSynopsisView/SessionSynopsisPage'
import EditSession from 'components/SessionSynopsisView/EditSessionSynopsis'
import CreateSession from 'components/SessionSynopsisView/CreateSessionSynopsis'

// Account Rates
import RateHome from 'components/AccountRatesView/index'
import ManageRate from 'components/AccountRatesView/ManageRate'
import CreateRate from 'components/AccountRatesView/CreateAccountRate'
import EditRate from 'components/AccountRatesView/EditAccountRate'

import Login from 'components/LoginView/LoginPage'

export const routes = [
  {
    path: '/',
    component: HomePage,
    display: 'Home',
    style: 'home'
  },
  {
    path: '/Courses',
    component: CoursePage,
    display: 'Courses',
    style: 'graduation-cap'
  },
  {
    path: '/Customers',
    component: CustomerHome,
    display: 'Customers',
    children: [
      {
        path: 'Index',
        component: CustomerPage,
        display: 'Customers'
      },
      {
        path: 'Create',
        component: CreateCustomer,
        display: 'Create Customer Account'
      },
      {
        path: 'Edit/:id',
        name: 'editCustomer',
        component: EditCustomer,
        props: true
      }
    ]
  },
  {
    path: '/Sessions',
    component: SessionHome,
    display: 'Sessions',
    style: 'clock-o',
    children: [
      {
        path: 'Index',
        component: SessionPage,
        display: 'Sessions'
      },
      {
        path: 'Create',
        component: CreateSession,
        display: 'Create Session Synopsis'
      },
      {
        path: 'Edit/:id',
        name: 'editSynopsis',
        component: EditSession,
        props: true
      }
    ]
  },
  {
    path: '/AccountRates',
    component: RateHome,
    children: [
      {
        path: 'ManageRates/:id/:name', // HACK: name is a hack
        name: 'manageRates',
        component: ManageRate,
        props: true
      },
      {
        path: 'Create/:id',
        name: 'createRates',
        component: CreateRate,
        props: true
      },
      {
        path: 'Edit/:id',
        name: 'editRates',
        component: EditRate,
        props: true
      }
    ]
  },
  {
    path: '/Login',
    component: Login,
    display: 'Login',
    style: 'user'
  },
  {
    path: '/Error',
    component: ErrorPage
  },
  {
    path: '*',
    redirect: '/Error'
  }
]
