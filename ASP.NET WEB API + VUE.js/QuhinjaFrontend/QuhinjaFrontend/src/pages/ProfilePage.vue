<template>
  <q-page
    class="q-px-md column col-xs-12 col-sm-10 col-md-10 col-lg-8 offset-sm-1 offset-md-1 offset-lg-2"
  >
    <div class="column items-center full-width q-mt-lg">
      <q-form
        class="full-width text-center column q-gutter-y-sm"
        style="max-width: 350px"
        @submit="handleSubmit"
      >
        <div class="text-h5 text-red-2 q-mt-md q-mb-sm">Profil</div>
        <div class="full-width row justify-between">
          <q-avatar square size="100px">
            <q-img :src="userData.image" />
          </q-avatar>
          <q-uploader
            ref="uploaderRef"
            color="red-1"
            :multiple="false"
            flat
            style="max-width: 230px; max-height: 125px"
            :factory="factoryUpload"
            hide-upload-btn
            no-thumbnails
            batch
          />
        </div>
        <q-input
          color="red-2"
          v-model="userData.name"
          label="Ime"
          dense
          outlined
          :rules="[requiredField, firstNameMaxLengthValidation]"
        />
        <q-input
          color="red-2"
          v-model="userData.surname"
          label="Prezime"
          dense
          outlined
          :rules="[requiredField, lastNameMaxLengthValidation]"
        />
        <q-input
          v-model="this.EmplDate"
          label="Datum zaposlenja"
          readonly
          dense
          outlined
          :rules="[requiredField, firstNameMaxLengthValidation]"
        />
        <q-input
          v-model="this.BirthDate"
          label="Datum rodjenja"
          readonly
          dense
          outlined
          :rules="[requiredField, lastNameMaxLengthValidation]"
        />

        <q-select
          color="red-2"
          filled
          v-model="model"
          use-input
          hide-selected
          fill-input
          input-debounce="0"
          :options="options"
          @filter="filterFn"
          label="Omiljeno jelo"
        >
          <template v-slot:no-option>
            <q-item>
              <q-item-section>Nema rezultata </q-item-section>
            </q-item>
          </template>
        </q-select>

        <q-btn color="red-1" type="submit" label="Ažuriraj" />
        <q-btn
          @click="handleNewPasswordClick"
          color="red-5"
          label="Promeni lozinku"
          class="buttonForEmployee"
        />
      </q-form>
    </div>
    <q-dialog v-model="visiblePasswordForm" persistent @hide="handleHidePasswordDialog">
      <q-card class="q-py-sm full-width text-accent">
        <q-card-section class="q-ml-sm row full-width justify-between items-center">
          <div class="text-h4 q-pl-sm text-brown-5">Promena lozinke</div>
          <q-btn
            icon="close"
            class="text-brown-5"
            flat
            round
            dense
            @click="handleHidePasswordDialog"
          />
        </q-card-section>
        <q-form
          ref="form"
          class="full-width column q-gutter-y-sm"
          @submit="handleSubmitPasswordForm"
        >
          <q-input
            color="red-2"
            type="password"
            v-model="cPass"
            label="Trenutna lozinka"
            dense
            outlined
            :rules="[requiredField, passwordPattern]"
          />
          <q-input
            color="red-2"
            type="password"
            v-model="nPass"
            label="Nova lozinka"
            dense
            outlined
            :rules="[requiredField, passwordPattern]"
          />

          <q-btn
            class="q-py-sm"
            type="submit"
            color="red-5"
            label="Promeni lozinku"
            no-caps
            :loading="registerButtonLoading"
          />
        </q-form>
      </q-card>
    </q-dialog>
  </q-page>
</template>

<script>
import moment from "moment";

import { formRulesMixin } from "src/helper/formRulesMixin";
import { baseUrl } from "src/services/apiConfig";
import noUser from "../../public/no-image-user.png";
import { QSpinnerBall } from "quasar";

export default {
  name: "ProfilePage",
  mixins: [formRulesMixin],
  data() {
    return {
      userData: {},
      BirthDate: "",
      EmplDate: "",
      noPicture: noUser,
      visiblePasswordForm: false,
      email: "",
      cPass: "",
      nPass: "",
      model: "",
      registerButtonLoading: false,

      options: this.stringOptions,
      stringOptions: [],
      dishes: [],
      favoritedishId: 0,
    };
  },
  filters: {
    hexToBase64(hexStr) {
      let base64 = "";
      for (let i = 0; i < hexStr.length; i++) {
        base64 += !((i - 1) & 1)
          ? String.fromCharCode(parseInt(hexStr.substring(i - 1, i + 1), 16))
          : "";
      }
      return btoa(base64);
    },
  },
  created() {
    this.getData();
    this.getAllDishes();
  },

  methods: {
    handleNewPasswordClick() {
      this.visiblePasswordForm = true;
    },
    handleHidePasswordDialog() {
      this.visiblePasswordForm = false;
    },
    handleSubmitPasswordForm() {
      this.$store;
      this.$store
        .dispatch("apiRequest/postApiRequest", {
          url: "Identity/changePassword",
          data: {
            email: this.email,
            cPass: this.cPass,
            password: this.nPass,
          },
          successMessage: "Uspesno ste promenili lozinku",
          color: "brown",
        })
        .then((response) => {
          this.visiblePasswordForm = false;
          this.cPass = "";
          this.nPass = "";
          this.getData();
        })
        .catch((response) =>
          this.$q.notify({
            position: "top",
            message: response.data,
            type: "negative",
          })
        );
    },
    getAllDishes() {
      this.$store.dispatch("apiRequest/getApiRequest", { url: "Dish" }).then((res) => {
        this.dishes = res.filter((dish) => dish.selectedRecipe != null);

        this.dishes.forEach((el) => {
          this.stringOptions.push(el.name);
        });
      });
    },
    filterFn(val, update, abort) {
      update(() => {
        const needle = val.toLowerCase();
        this.options = this.stringOptions.filter(
          (v) => v.toLowerCase().indexOf(needle) > -1
        );
      });
    },
    ParseDate(date) {
      return (date = moment(date).format("LL")); // put format as you want
    },
    getData() {
      this.$store.dispatch("apiRequest/getApiRequest", { url: "user/0" }).then((res) => {
        this.userData = res;
        this.userData.image = "data:image/png;base64," + this.userData.image;
        console.log(this.userData);
        this.email = this.userData.email;
        this.BirthDate = this.ParseDate(this.userData.dateOfBirth);
        this.EmplDate = this.ParseDate(this.userData.dateOfEmployment);
        this.model = this.userData.favouriteDish.name;
      });
    },

    factoryUpload(file) {
      return new Promise((resolve, reject) => {
        const token = this.$store.state.auth.auth.accessToken;
        resolve({
          url: `${baseUrl}user/uploadPicture`,
          method: "POST",
          headers: [{ name: "Authorization", value: `Bearer ${token}` }],
        });
      });
    },
    findDishId(name) {
      this.dishes.forEach((el) => {
        if (el.name == name) this.favoritedishId = el.id;
      });
      return this.favoritedishId;
    },
    handleSubmit() {
      this.userData.favouriteDishId = this.findDishId(this.model);
      this.$store
        .dispatch("apiRequest/putApiRequest", {
          url: "user/update-user",
          data: {
            ...this.userData,
          },
          successMessage: "Uspesno ste azurirali podatke",
          color: "brown",
        })
        .then((res) => {
          this.$q.loading.show({
            spinner: QSpinnerBall,
            spinnerColor: "brown",
            spinnerSize: 140,
            backgroundColor: "grey",
            message: "Molimo Vas pričekajte...",
            messageColor: "black",
          });
          this.$refs.uploaderRef.upload();
          this.timer = setTimeout(() => {
            this.$q.loading.hide();
            this.timer = void 0;
            this.$router.go();
          }, 3000);
        });
    },
  },
};
</script>

<style scoped></style>
