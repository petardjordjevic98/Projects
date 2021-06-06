<template>
  <q-page
    class="bg-grey-4 q-px-md column items-center q-gutter-y-md col-xs-12 col-sm-10 col-md-10 col-lg-8 offset-sm-1 offset-md-1 offset-lg-2"
  >
    <q-parallax :height="670" :speed="1" src="../../public/bgYellow.jpg">
      <div class="bg-grey-4" style="border-radius: 1%; width: 80%; height: 70%">
        <div
          class="full-width text-brown-9 text-h5 text-accent q-mt-md q-pl-md q-mb-sm"
        >
          Dodavanje novog jela
        </div>
        <q-separator style="height: 2px" />
        <q-form class="full-width" ref="formRef" @submit="handleAddDish">
          <div class="full-width row justify-around wrap q-gutter-x-md">
            <div
              class="full-width column justify-center items-center"
              style="max-width: 350px"
            >
              <div class="full-width q-pa-md">
                <div class="text-brown-9 text-h6 q-pb-md">Osnovni podaci</div>
                <q-input
                  class="q-mb-sm"
                  v-model="formData.Name"
                  color="brown-9"
                  dense
                  outlined
                  label="Ime jela"
                />
                <q-input
                  class="q-mb-sm"
                  v-model="formData.description"
                  dense
                  outlined
                  label="Opis jela"
                  color="brown-9"
                />
                <q-select
                  use-input
                  @new-value="createValue"
                  transition-show="flip-up"
                  transition-hide="flip-down"
                  v-model="formData.dishType"
                  dense
                  outlined
                  color="red-5"
                  label="tip jela"
                  :options="dishTypes"
                />
              </div>
              <q-btn
                label="Potvrdi"
                color="red-5"
                text-color="white"
                type="submit"
              />
            </div>
            <q-separator cl v-if="$q.screen.gt.sm" vertical />
            <div class="full-width" style="max-width: 350px">
              <div class="text-brown-9 text-h6 q-pb-md">Slika jela</div>
              <q-uploader
                color="red-2"
                ref="uploaderRef"
                style="max-width: 300px"
                class="full-width"
                text-color="brown-9"
                :factory="factoryUpload"
                hide-upload-btn
                multiple
                batch
              />
            </div>
          </div>
        </q-form>
        <q-dialog v-model="confirm" persistent>
          <q-card>
            <q-card-section class="bg-brown-9 row items-center text-amber-6">
              <span class="q-ml-sm"
                >Da li želite da dodate i recept za ovo jelo?</span
              >
            </q-card-section>

            <q-card-actions class="bg-brown-9" align="left">
              <q-btn
                class="bg-red-5"
                text-color="white"
                flat
                label="Da"
                color="primary"
                @click="handleAddDishAndRecipe"
                v-close-popup
              />
              <q-btn
                class="bg-amber-6"
                text-color="brown-9 "
                flat
                label="Ne"
                color="primary"
                to="/dishes"
                v-close-popup
              />
            </q-card-actions>
          </q-card>
        </q-dialog>
      </div>
    </q-parallax>
  </q-page>
</template>
<script>
import { baseUrl } from "../services/apiConfig";
import { QSpinnerBall } from "quasar";

export default {
  data() {
    return {
      confirm: false,
      formData: {
        id: 0,
        name: null,
        description: "",
        dishType: ""
      },
      dishTypes: []
    };
  },

  created() {
    this.$store
      .dispatch("apiRequest/getApiRequest", { url: `/dish/dishTypes` })
      .then(res => {
        this.dishTypes = res;
      });
  },
  methods: {
    createValue(val, done) {
      if (val.length > 0) {
        if (!this.dishTypes.includes(val)) {
          this.dishTypes.push(val);
        }
        done(val, "toggle");
      }
    },
    handleAddDishAndRecipe() {
      this.$router.push(`/addRecipe/${this.id}`);
    },
    handleAddDish() {
      const data = {
        ...this.formData,
        name: this.formData.name,
        description: this.formData.description,
        dishType: this.formData.dishType
      };
      this.$store
        .dispatch("apiRequest/postApiRequest", {
          url: "dish",
          data: data,
          successMessage: "Uspešno ste dodali jelo"
        })
        .then(res => {
          this.id = res;
          this.$q.loading.show({
            spinner: QSpinnerBall,
            spinnerColor: "brown",
            spinnerSize: 140,
            backgroundColor: "grey",
            message: "Molimo Vas pričekajte...",
            messageColor: "black"
          });
          this.$refs.uploaderRef.upload();
          this.timer = setTimeout(() => {
            this.$q.loading.hide();
            this.timer = void 0;
            this.confirm = true;
          }, 3000);
        });
      //
    },
    createValue(val, done) {
      if (val.length > 0) {
        if (!this.dishTypes.includes(val)) {
          this.dishTypes.push(val);
        }
      }
    },
    factoryUpload(file) {
      return new Promise((resolve, reject) => {
        // const token = this.$store.state.auth.auth.accessToken
        resolve({
          url: `${baseUrl}dish/${this.id}/uploadDishPicture`,
          method: "POST"

          //   headers: [
          //     { name: 'Authorization', value: `Bearer ${token}` }
          //   ]
        });
      });
    }
  }
};
</script>

<style lang="stylus" scoped>
*{

 font-family: "Open Sans";

}
</style>
