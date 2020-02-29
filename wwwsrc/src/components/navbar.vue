<template>
  <nav class="navbar navbar-expand-lg">
    <router-link class="navbar-brand" :to="{ name: 'home' }">Keepr</router-link>
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav mr-auto">
        <!-- <li class="nav-item" :class="{ active: $route.name == 'home' }">
          <router-link :to="{ name: 'home' }" class="nav-link">Home</router-link>
        </li>-->
        <li
          class="nav-item"
          v-if="$auth.isAuthenticated"
          :class="{ active: $route.name == 'dashboard' }"
        >
          <router-link class="nav-link" :to="{ name: 'dashboard' }">My-Dashboard</router-link>
        </li>
      </ul>
      <span class="navbar-text">
        <button class="btn login" @click="login" v-if="!$auth.isAuthenticated">Login</button>
        <button class="btn logout" @click="logout" v-else>Logout</button>
      </span>
    </div>
  </nav>
</template>

<script>
import axios from "axios";

let _api = axios.create({
  baseURL: "https://localhost:5001",
  withCredentials: true
});
export default {
  name: "Navbar",
  methods: {
    async login() {
      await this.$auth.loginWithPopup();
      this.$store.dispatch("setBearer", this.$auth.bearer);
      console.log("this.$auth.user: ");
      console.log(this.$auth.user);
    },
    async logout() {
      await this.$auth.logout();
      this.$store.dispatch("resetBearer");
      this.$router.push({ name: "home" });
    }
  }
};
</script>

<style>
nav {
  background-color: rgba(0, 0, 0, 0.856);
}
nav a {
  color: orange;
}
nav a:hover {
  color: orange;
  text-shadow: 0 0 5px orange;
}
nav a {
  color: orange;
}
.logout {
  color: orange;
  background-color: grey;
  border: 1pt solid orange;
}
.logout:hover {
  color: red;
  background-color: black;
  border: 1pt solid red;
  box-shadow: 0 0 25px red;
}
.login {
  color: orange;
  background-color: black;
  border: 1pt solid rgb(255, 165, 0);
  animation: neon 1.08s ease-in-out infinite alternate;
}
.login:hover {
  color: yellow;
  background-color: black;
  border: 1pt solid yellow;
  box-shadow: 0 0 25px yellow;
}
@keyframes neon {
  from {
    text-shadow: 0 0 20px rgba(252, 238, 52, 0.92),
      0 0 30px rgba(250, 191, 65, 0.774), 0 0 12px rgba(242, 132, 30, 0.945),
      0 0 21px rgba(245, 163, 12, 0.92), 0 0 34px rgba(242, 62, 30, 0.78),
      0 0 54px rgba(243, 113, 26, 0.92);
  }
  to {
    text-shadow: 0 0 20px rgba(252, 73, 41, 0.92),
      0 0 30px rgba(238, 84, 57, 0.34), 0 0 12px rgba(242, 97, 30, 0.52),
      0 0 21px rgba(245, 47, 12, 0.92), 0 0 34px rgba(245, 66, 12, 0.78),
      0 0 54px rgba(245, 39, 12, 0.92);
  }
}
</style>
