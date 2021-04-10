import { createRouter, createWebHashHistory } from 'vue-router'
import { profileService } from './services/ProfileService'
import { authGuard } from '@bcwdev/auth0provider-client'
import { AppState } from './AppState'

function loadPage(page) {
  return () => import(`./pages/${page}.vue`)
}

const routes = [
  {
    path: '/realm',
    component: loadPage('AuthGuard'),
    beforeEnter(to, from, next) {
      authGuard(to, from, async() => {
        if (!AppState.profile.id) { await profileService.getProfile() }
        next()
      })
    },
    children: [{
      path: '',
      name: 'RealmHomePage',
      component: loadPage('RealmHomePage')
    },
    {
      path: 'town/:id',
      name: 'Town',
      component: loadPage('TownPage')
    },
    {
      path: '/profile',
      name: 'Profile',
      component: loadPage('ProfilePage')
    }]
  },
  {
    path: '',
    name: 'Home',
    component: loadPage('Home')
  },
  {
    path: '/about',
    name: 'About',
    component: loadPage('AboutPage')
  }

]

const router = createRouter({
  linkActiveClass: 'router-link-active',
  linkExactActiveClass: 'router-link-exact-active',
  history: createWebHashHistory(),
  routes
})

export default router
