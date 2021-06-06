<template>
  <q-page class="bg-grey-4">
    <login-dialog :visible="showLoginDialog" />

    <q-img src="../../public/employees.jpg"></q-img>
  </q-page>
</template>
<script>
import LoginDialog from "../components/LoginDialog";

export default {
  components: {
    LoginDialog
  },
  data() {
    return {};
  },
  computed: {
    isAuthenticated() {
      return this.$store.getters["auth/isAuthenticated"];
    },
    showLoginDialog() {
      return this.$store.getters["auth/toShowLogin"];
      // return this.$store.state.auth.showLoginDialog
    }
  },
  created() {
    this.$store.commit("auth/showLoginDialog");
  }
};
</script>
