<template>
  <div>
    <div class="text-subtitle2 text-center q-mr-md text-white"></div>
    {{ userName }}
    <q-avatar style="cursor: pointer">
      <img
        :src="profilePicture !== null ? profilePicture : 'statics/no-image-user.png'"
      />

      <q-menu
        transition-show="rotate"
        transition-hide="rotate"
        self="top right"
        :offset="[-50, 15]"
      >
        <q-list>
          <q-separator />
          <q-item v-for="option in menuOptions" :key="option.name" :to="option.link">
            <q-item-section class="text-red-1" avatar>
              <q-icon :name="option.icon" />
            </q-item-section>
            <q-item-section class="text-red-1">
              {{ option.name }}
            </q-item-section>
          </q-item>
          <q-separator />
          <q-item clickable @click="handleLogout">
            <q-item-section class="text-red-1" avatar>
              <q-icon name="exit_to_app" />
            </q-item-section>
            <q-item-section class="text-red-1"> Odjava </q-item-section>
          </q-item>
        </q-list>
      </q-menu>
    </q-avatar>
  </div>
</template>

<script>
export default {
  name: "UserAvatarAndMenu",
  data() {
    return {
      menuOptions: [
        {
          name: "Profil",
          icon: "person",
          link: "/profile",
        },
      ],
    };
  },
  methods: {
    handleLogout() {
      this.$store.dispatch("auth/logout").then(() => {
        this.$router.push("/login");
      });
    },
  },
  computed: {
    fullName() {
      return this.$store.getters["auth/fullName"];
    },
    profilePicture() {
      return this.$store.getters["auth/image"];
    },
    userName() {
      return this.$store.getters["auth/userName"];
    },
  },
};
</script>

<style scoped></style>
