<template>
  <q-layout view="lHh Lpr lFf">
    <login-dialog :visible="showLoginDialog" />

    <q-header elevated>
      <q-toolbar style="background-color:#6f6e57; height:20px;display:flex; flex-direction:row; flex grow:1; align-content:center  "
        ><div class="buttonDetails" @click="handleClick">
          <h6 class="q-mr-sm">Quhinja</h6>
        </div>

        <q-tabs class="text-brown-9">
          <q-route-tab active name="Menu" label="Menu" to="/menu" />
          <q-route-tab name="Jela" label="Jela" to="/dishes" />
          <q-route-tab name="Zaposleni" label="Zaposleni" to="/employees" />
        </q-tabs>
        <div v-if="isAuthenticated" class="fixed-top-right on-left q-mt-sm">
          <user-avatar-and-menu />
        </div>
        <div v-else>
          <q-btn @click="handleLoginClick" class="fixed-top-right on-left q-mt-sm" dense>
            <q-icon name="login" color="white"> </q-icon>
          </q-btn>
        </div>
      </q-toolbar>
    </q-header>

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
import UserAvatarAndMenu from "../components/UserAvatarAndMenu";

import LoginDialog from "../components/LoginDialog";

export default {
  name: "MainLayout",
  components: {
    LoginDialog,
    UserAvatarAndMenu,
  },
  data() {
    return {};
  },
  methods: {
    handleClick() {
      this.$router.push(`/`);
    },
    handleLoginClick() {
      this.$store.commit("auth/showLoginDialog");
    },
  },
  computed: {
    isAuthenticated() {
      return this.$store.getters["auth/isAuthenticated"];
    },
    showLoginDialog() {
      return this.$store.getters["auth/toShowLogin"];
      // return this.$store.state.auth.showLoginDialog
    },
  },
};
</script>

<style scoped>
* {
  color: #f1eae8;
}
.buttonDetails:hover {
  cursor: pointer;
  color: blue;
}
</style>
