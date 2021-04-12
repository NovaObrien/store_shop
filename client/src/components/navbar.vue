<template>
  <nav class="navbar navbar-expand-lg navbar-dark">
    <router-link class="navbar-brand d-flex" :to="{ name: 'HomePage' }">
      <div class="d-flex flex-column align-items-center">
        Home
      </div>
    </router-link>
    <!-- <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    > -->
    <!-- <span class="navbar-toggler-icon" />
    </button> -->
    <search-bar-component class="search-bar rounded mx-auto" />
    <div id="navbarText">
      <span class="navbar-text">
        <button
          class="btn btn-outline-primary text-uppercase"
          @click="login"
          v-if="!user.isAuthenticated"
        >
          Login
        </button>

        <div class="dropdown" v-else>
          <div
            class="dropdown-toggle p-3 rounded small"
            @click="state.dropOpen = !state.dropOpen"
          >
            <img
              :src="user.picture"
              alt="user photo"
              height="40"
              class="rounded-circle"
            />

            <div
              class="dropdown-menu p-0 list-group w-100"
              :class="{ show: state.dropOpen }"
              @click="state.dropOpen = false"
            >
              <router-link :to="{ name: 'Profile' }">
                <div class="list-group-item list-group-item-action hoverable">
                  Profile
                </div>
              </router-link>
              <div
                class="list-group-item list-group-item-action hoverable"
                @click="logout"
              >
                logout
              </div>
            </div>
          </div>
          <div
            class="dropdown-toggle p-3 rounded large"
            @click="state.dropOpen = !state.dropOpen"
          >

            <img
              :src="user.picture"
              alt="user photo"
              height="40"
              class="rounded-circle"
            />
            <span class="mx-3">{{ user.name }}</span>
            <div
              class="dropdown-menu p-0 list-group w-100"
              :class="{ show: state.dropOpen }"
              @click="state.dropOpen = false"
            >
              <router-link :to="{ name: 'Profile' }">
                <div class="list-group-item list-group-item-action hoverable">
                  Profile
                </div>
              </router-link>
              <div
                class="list-group-item list-group-item-action hoverable"
                @click="logout"
              >
                logout
              </div>
            </div>
          </div>
        </div>
      </span>
    </div>
  </nav>
</template>

<script>
import { AuthService } from '../services/AuthService'
import { AppState } from '../AppState'
import { computed, reactive } from 'vue'
import router from '../router'
import HomePageVue from '../pages/HomePage.vue'
export default {
  name: 'Navbar',
  setup() {
    const state = reactive({
      dropOpen: false
    })
    return {
      state,
      user: computed(() => AppState.user),
      async login() {
        await AuthService.loginWithPopup()
        router.push(HomePageVue)
      },
      async logout() {
        await AuthService.logout({ returnTo: window.location.origin })
      }
    }
  }
}
</script>

<style scoped>

.navbar{
  background-color: #666666fb;
}

.dropdown-menu {
  user-select: none;
  display: block;
  transform: scale(0);
  transition: all 0.15s linear;
}
.dropdown-menu.show {
  transform: scale(1);
}
.dropdown-toggle{
  background: rgb(126, 126, 126);
}
.dropdown-toggle:hover {
  background: #000;
}
@media(max-width: 600px){
  .large{
    display: none;
  }
  #logo{
    font-size: 30px;
    border: 4px solid;
  }
}
@media(min-width: 600px){
  .small{
    display: none;
  }
}

.hoverable {
  cursor: pointer;
}
a:hover {
  text-decoration: none;
}
.nav-link{
  text-transform: uppercase;
}
.nav-item .nav-link.router-link-exact-active{
  color: var(--primary);
}
</style>
