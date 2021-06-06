<template>
  <q-page class="bg-grey-4">
    <div class="mainDiv">
      <div class="text-brown-9 fixed-top q-mt-sm">
        <h5
          v-if="this.dish"
          class="text-bold"
          style="margin-top: 50px; text-align: center"
        >
          {{ this.dish.name }}
        </h5>
        <q-form class="full-width" ref="formRef" @submit="handleAddRecipe">
          <div class="full-width row justify-around wrap">
            <div
              class="full-width column justify-center items-center"
              style="max-width: 350px"
            >
              <div class="full-width q-pa-md">
                <div class="text-brown-9 text-h6 q-pb-md">Osnovni podaci</div>
                <q-input
                  bg-color="grey-4"
                  v-model="formData.name"
                  color="brown-9"
                  dense
                  outlined
                  label="Ime recepta"
                />
                <div class="q-pt-md q-pb-md" style="max-width: 300px">
                  <q-input
                    class="bg-grey-5"
                    color="red-5"
                    style="width: 400px"
                    placeholder="Način pripreme"
                    v-model="formData.wayOfPreparing"
                    filled
                    outlined
                    type="textarea"
                  />
                </div>
                <q-input
                  bg-color="grey-4"
                  v-model="formData.preparationTime"
                  color="brown-9"
                  dense
                  outlined
                  class="q-pb-md"
                  label="Vreme pripreme"
                />
                <q-input
                  bg-color="grey-4"
                  v-model="formData.preview"
                  color="brown-9"
                  dense
                  outlined
                  label="Link za recept"
                />
              </div>
              <q-btn
                style="background-color: #6f6e57"
                label="Potvrdi"
                text-color="white"
                type="submit"
              />
            </div>
            <q-separator cl v-if="$q.screen.gt.sm" vertical />
            <div class="flex column">
              <div class="flex q-mb-md full-width" style="max-width: 350px">
                <div class="q-pb-md flex row q-mt-xl">
                  <q-select
                    style="
                      width: 130px;
                      text-overflow: ellipsis;
                      white-space: nowrap;
                      overflow: hidden;
                    "
                    ref="select"
                    bg-color="grey-4"
                    class="q-mr-sm"
                    use-input
                    @new-value="createValue"
                    transition-show="flip-up"
                    transition-hide="flip-down"
                    v-model="IngridientForAdding.ingridientName"
                    dense
                    outlined
                    color="red-5"
                    label="sastojak"
                    :options="ingridients"
                  />
                  <q-input
                    ref="amount"
                    bg-color="grey-4"
                    mask="####"
                    v-model="IngridientForAdding.ingridientAmount"
                    color="brown-9"
                    dense
                    class="q-pr-sm"
                    style="width: 75px"
                    outlined
                    label="količina"
                  />

                  <q-input
                    ref="unit"
                    bg-color="grey-4"
                    v-model="IngridientForAdding.ingridientUnit"
                    color="brown-9"
                    dense
                    style="width: 90px"
                    outlined
                    label="mera"
                  />
                  <q-btn
                    style="background-color: #6f6e57"
                    dense
                    class="q-ml-sm text-bold"
                    @click="addToArray"
                    icon="add"
                    text-color="white"
                  />
                </div>
                <q-list
                  bordered
                  class="bg-grey-5 rounded-borders"
                  style="max-width: 600px"
                >
                  <q-item-label style="width: 345px; color: black" header
                    >Sastojci:</q-item-label
                  >

                  <q-item
                    style="width: 345px"
                    v-for="ing in ingridientsForBase"
                    :key="ing.ingridientName.label"
                  >
                    <q-item-section top class="gt-sm">
                      <q-item-label class="q-mt-sm"
                        >{{ ing.ingridientName.label }} :
                        {{ ing.ingridientAmount }}
                        {{ ing.ingridientUnit }}</q-item-label
                      >
                    </q-item-section>

                    <q-item-section top side>
                      <div class="text-grey-8 q-gutter-xs">
                        <q-btn
                          @click="IncrementAmount(ing.ingridientName.label)"
                          class="gt-xs"
                          size="12px"
                          flat
                          dense
                          round
                          icon="add"
                        />
                        <q-btn
                          @click="DecrementAmount(ing.ingridientName.label)"
                          class="gt-xs"
                          size="12px"
                          flat
                          dense
                          round
                          icon="remove"
                        />
                        <q-btn
                          @click="deleteItem(ing.ingridientName.label)"
                          size="12px"
                          flat
                          dense
                          round
                          icon="delete"
                        />
                      </div>
                    </q-item-section>
                  </q-item>
                </q-list>
                <!-- dodati listu sastojaka-->
              </div>
              <div class="text-h6 q-pb-md">Slika recepta</div>
              <q-uploader
                color="teal-10"
                ref="uploaderRefForRecipe"
                style="max-width: 300px"
                class="full-width"
                :factory="factoryUpload"
                hide-upload-btn
                multiple
                batch
              />
            </div>
          </div>
        </q-form>
      </div>
    </div>
  </q-page>
</template>
<script>
import { baseUrl } from "../services/apiConfig";
import { QSpinnerBall } from "quasar";
export default {
  data() {
    return {
      formData: {
        id: 0,
        name: null,
        wayOfPreparing: "",
        preparationTime: "",
        preview: "",
        dishId: 0,
      },
      IngridientForAdding: {
        ingridientUnit: "",
        ingridientAmount: 0,
        ingridientName: "",
      },
      dish: null,
      ingridientsForBase: [],
      ingridients: [],
    };
  },

  methods: {
    showLoading() {},
    IncrementAmount(name) {
      var ar = this.ingridientsForBase
        .filter((el) => el.ingridientName.label == name)
        .map((el) => el.ingridientAmount++);
    },
    DecrementAmount(name) {
      var ar = this.ingridientsForBase
        .filter((el) => el.ingridientName.label == name)
        .map((el) => (el.ingridientAmount > 1 ? el.ingridientAmount-- : ""));
    },
    deleteItem(name) {
      this.ingridientsForBase = this.ingridientsForBase.filter(function (item) {
        return item.ingridientName.label !== name;
      });
      this.ingridients.forEach((el) => {
        if (el.label == name) el.disable = false;
      });
    },
    addToArray() {
      this.ingridientsForBase.push({ ...this.IngridientForAdding });
      var pom = this.IngridientForAdding;
      this.ingridients.forEach((el) => {
        if (el.label == pom.ingridientName.label) el.disable = true;
      });

      this.IngridientForAdding.ingridientAmount = 0;
      this.IngridientForAdding.ingridientName = "";
      this.IngridientForAdding.ingridientUnit = "";
    },
    createValue(val, done) {
      if (val.length > 0) {
        var b = 0;
        this.ingridients.forEach((el) => {
          if (val == el.label) b++;
        });
        if (b == 0) {
          var Option = {
            label: val,
            disable: false,
          };
          this.ingridients.push(Option);
          const data = {
            name: val,
          };
        }
      }
    },
    handleAddRecipe() {
      const data = {
        ...this.formData,
        name: this.formData.name,
        wayOfPreparing: this.formData.wayOfPreparing,
        preparationTime: this.formData.preparationTime,
        preview: this.formData.preview,
        dishId: this.formData.dishId,
      };
      this.$store
        .dispatch("apiRequest/postApiRequest", {
          url: "recipe",
          data: data,
          successMessage: "Uspešno ste dodali recept",
        })
        .then((res) => {
          this.formData.id = res;
          console.log(res);
          this.$q.loading.show({
            spinner: QSpinnerBall,
            spinnerColor: "brown",
            spinnerSize: 140,
            backgroundColor: "grey",
            message: "Molimo Vas pričekajte...",
            messageColor: "black",
          });
          this.$refs.uploaderRefForRecipe.upload();
          this.addIngridents();
          //
          this.timer = setTimeout(() => {
            this.$q.loading.hide();
            this.timer = void 0;
            this.$router.push(`/dish/${this.formData.dishId}`);
          }, 3000);
        });
    },
    addIngridents() {
      var i;
      for (i = 0; i < this.ingridientsForBase.length; i++) {
        const data = {
          recipeId: this.formData.id,
          quantity: parseInt(this.ingridientsForBase[i].ingridientAmount),
          ingridient: {
            name: this.ingridientsForBase[i].ingridientName.label,
          },
          unit: this.ingridientsForBase[i].ingridientUnit,
        };
        this.$store.dispatch("apiRequest/postApiRequest", {
          url: "ingridient/addIngridient",
          data: data,
        });
      }
    },

    getDish() {
      this.$store
        .dispatch("apiRequest/getApiRequest", {
          url: `Dish/${this.$route.params.id}`,
        })
        .then((res) => ((this.dish = res), (this.formData.dishId = this.dish.id)));
    },
    factoryUpload(file) {
      return new Promise((resolve, reject) => {
        resolve({
          url: `${baseUrl}recipe/${this.formData.id}/uploadRecipePicture`,
          method: "POST",

          //   headers: [
          //     { name: 'Authorization', value: `Bearer ${token}` }
          //   ]
        });
      });
      // hiding in 3s
    },
  },
  created() {
    this.getDish();
    this.$store
      .dispatch("apiRequest/getApiRequest", { url: `/ingridient` })
      .then((res) => {
        res.forEach((el) => {
          var Option = {
            label: el.name,
            disable: false,
          };
          this.ingridients.push(Option);
        });
      });
  },
};
</script>

<style scoped>
.mainDiv {
  display: flex;
  flex-direction: column;
}
* {
  font-family: "Open Sans";
}
</style>
