import HomePage from 'components/HomePage'
import ErrorPage from 'components/ErrorView'

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

// User Manager
import UserHome from 'components/UserManagerView/index'
import UserPage from 'components/UserManagerView/UserManagerPage'
import EditUser from 'components/UserManagerView/EditUser'

// Account Rates
import RateHome from 'components/AccountRatesView/index'
import ManageRate from 'components/AccountRatesView/ManageRate'
import CreateRate from 'components/AccountRatesView/CreateAccountRate'
import EditRate from 'components/AccountRatesView/EditAccountRate'

// Account Details
import DetailsHome from 'components/AccountDetailsView/index'
import DetailsPage from 'components/AccountDetailsView/AccountDetailsPage'
import CreateDetails from 'components/AccountDetailsView/CreateAccountDetail'
import EditDetails from 'components/AccountDetailsView/EditAccountDetail'

export const routes = [
  {
    path: '/',
    component: HomePage,
    display: 'Home'
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
    path: '/Users',
    component: UserHome,
    display: 'Manage Users',
    children: [
      {
        path: 'Index',
        component: UserPage
      },
      {
        path: 'Edit/:id',
        name: 'editUser',
        component: EditUser,
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
    path: '/AccountDetails',
    name: 'accountDetails',
    component: DetailsHome,
    children: [
      {
        path: ':id',
        component: DetailsPage,
        props: true
      },
      {
        path: 'Create/:id',
        name: 'createDetails',
        component: CreateDetails,
        props: true
      },
      {
        path: 'Update/:id',
        name: 'editDetails',
        component: EditDetails,
        props: true
      }
    ]
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
