<template>
  <q-page v-if="this.dish" class="bg-grey-4">
    <div class="mainDiv">
      <div
        class="q-mt-xl leftDiv"
        style="
          border-style: none;
          display: flex;
          flex-direction: column;
          align-items: center;
          justify-content: center;
          width: 50%;
        "
      >
        <div style="border-style: none; border-radius: 15px 15px 15px 15px">
          <q-card
            :ratio="16 / 9"
            style="
              background-color: #baa671;

              border-style: none;
              border-radius: 15px 15px 15px 15px;
              width: 275px;
            "
            class="my-card bg-grey-4"
          >
            <q-img
              style="
                border-style: none;

                border-radius: 15px 15px 0px 0px;
              "
              height="200px"
              :src="this.dish.image"
            />

            <q-card-section style="border-style: none; background-color: #baa671">
              <div class="row no-wrap items-center">
                <div class="col text-bold text-h6 ellipsis">
                  {{ this.dish.name }}
                </div>
                <div class="text-brown-9 text-h6">
                  {{ this.dish.averageRating | ParseFloat }}
                </div>
              </div>
            </q-card-section>

            <q-card-section
              style="
                background-color: #baa671;
                border-style: none;
                border-radius: 0px 0px 15px 15px;
              "
              class="q-pt-none"
            >
              <div
                style="border-style: none"
                class="text-bold text-subtitle1 text-brown-9"
              >
                {{ this.dish.dishType }}
              </div>
              <div style="border-style: none" class="text-caption text-brown-9">
                {{ this.dish.description }}
              </div>
            </q-card-section>
          </q-card>
        </div>
        <div v-if="!this.admin">
          <div class="q-mt-xl"></div>
          <q-form @submit="onSubmit" class="q-gutter-md">
            <div class="text-red-1 flex column q-mt-md">
              <q-rating
                class="q-mb-md"
                v-model="usersRatingFromBase"
                max="5"
                size="4em"
                color="brown"
                icon="star_border"
                icon-selected="star"
                icon-half="star_half"
                no-dimming
              />
              <q-btn label="Oceni" type="submit" color="red-1" />
              <div v-if="usersRatingFromBase != 0"></div>
              <div v-else>Niste ocenili ovo jelo</div>
            </div>
          </q-form>
        </div>
      </div>
      <q-separator cl v-if="$q.screen.gt.sm" vertical />

      <div class="q-mt-xl rightDiv" style="width: 50%">
        <div
          v-if="showRecipeList"
          style="display: flex; align-items: center; justify-content: center"
        >
          <q-list>
            <div class="flex row" v-for="recipe in this.dish.recipes" :key="recipe.id">
              <q-item
                :style="
                  recipe.id == dish.selectedRecipeId ? ' transform: scale(1.1);' : ''
                "
                clickable
                @click="handleShowRecipe(recipe)"
                class="q-mb-md itemForRecipe"
                style="
                  background-color: #7d7962;
                  width: 300px;
                  height: 100px;
                  border-radius: 15px 15px 15px 15px;
                "
                tag="label"
                v-ripple
              >
                <q-item-section>
                  <q-img
                    height="100px"
                    style="border-radius: 15px 15px 15px 15px"
                    :src="recipe.image"
                  ></q-img>
                </q-item-section>
                <q-item-section>
                  <q-item-label class="text-grey-4">{{ recipe.name }}</q-item-label>
                </q-item-section>
              </q-item>
              <div v-if="admin" class="q-ml-md" @click="checkBox(recipe.id)">
                <input
                  id="checkbox1"
                  clickable
                  type="checkbox"
                  @change="checkBox(recipe.id)"
                  :value="recipe.id"
                  v-model="model"
                />
                <label for="checkbox1"></label>
              </div>
            </div>
            <div>
              <q-item
                clickable
                @click="handleAddRecipe"
                class="q-mb-md bg-red-2 itemForRecipe"
                style="
                  width: 300px;
                  height: 100px;
                  border-radius: 15px 15px 15px 15px;
                  display: flex;
                  flex-direction: column;
                  align-items: center;
                  justify-content: center;
                "
              >
                <q-icon class="text-grey-4" size="70px" name="add"></q-icon>
              </q-item>
            </div>
          </q-list>
        </div>
        <div v-if="showDetailsForRecipe" v-model="recipeToShow">
          <div class="q-ml-md mainForRecipe">
            <div style="font-size: 20px">
              <p class="text-brown-9">{{ recipeToShow.name }}</p>
            </div>
            <div class="topDiv">
              <q-img
                class="q-mr-md"
                style="max-width: 250px; border-radius: 0px 15px 15px 0px"
                :src="recipeToShow.image"
              >
              </q-img>
              <q-list
                bordered
                class="q-mr-sm bg-grey-5 rounded-borders"
                style="
                  max-width: 600px;
                  color: #6f6e57;
                  border-radius: 15px 15px 15px 15px;
                "
              >
                <q-item-label style="width: 345px; color: black" header
                  >Sastojci:</q-item-label
                >

                <q-item
                  style="width: 345px"
                  v-for="ing in recipeToShow.ingridients"
                  :key="ing.ingridient.name"
                >
                  <q-item-section top class="gt-sm">
                    <q-item-label class="q-mt-sm"
                      >{{ ing.ingridient.name }} : {{ ing.quantity }} :
                      {{ ing.unit }}</q-item-label
                    >
                  </q-item-section>
                </q-item>
              </q-list>
            </div>
            <div style="color: #6f6e57" class="middleDiv q-mt-sm">
              <p>Vreme pripreme: {{ recipeToShow.preparationTime }}</p>
              <p>
                Link: <a :href="recipeToShow.preview">{{ recipeToShow.preview }}</a>
              </p>
            </div>
            <div class="q-mt-sm">
              <q-input
                readonly
                v-model="recipeToShow.wayOfPreparing"
                filled
                type="textarea"
              />
            </div>
          </div>
          <q-btn
            class="q-ml-sm q-mt-sm"
            style="background-color: #6f6e57"
            icon="keyboard_backspace"
            label="Vidi ostale recepte"
            @click="
              showRecipeList = true;
              showDetailsForRecipe = false;
            "
          />
        </div>
      </div>
    </div>
  </q-page>
</template>
<script>
import { baseUrl } from "../services/apiConfig";
export default {
  data() {
    return {
      val: null,
      dish: null,
      color: "",
      usersRating: null,
      usersRatingFromBase: 0,
      showDetailsForRecipe: false,
      showRecipeList: true,
      recipeToShow: null,
      userData: {},
      admin: false,
      model: [],
    };
  },
  methods: {
    handleShowRecipe(recipe) {
      this.showDetailsForRecipe = true;
      this.showRecipeList = false;
      this.recipeToShow = recipe;
    },
    handleAddRecipe() {
      this.$router.push("/addRecipe/" + this.dish.id);
    },
    getDish() {
      this.$store
        .dispatch("apiRequest/getApiRequest", {
          url: `Dish/${this.$route.params.id}`,
        })
        .then((res) => {
          this.model = [];
          res.recipes.forEach((el) => {
            el.image = "data:image/png;base64," + el.image;
            if (el.id == res.selectedRecipeId) this.model.push(el.id);
          });
          console.log(this.model);
          this.dish = res;
          this.dish.image = "data:image/png;base64," + this.dish.image;

          this.getRating();
        });
    },
    onSubmit() {
      const data = {
        dishId: this.dish.id,
        rating: this.usersRatingFromBase,
        userId: parseInt(this.userData.id),
      };
      this.$store
        .dispatch("apiRequest/postApiRequest", {
          url: "Dish/rateDish",
          data: data,
          successMessage: "Uspešno ste ocenili jelo",
        })
        .then((res) => {
          this.getDish();
        });
    },

    getRating() {
      this.$store
        .dispatch("apiRequest/getApiRequest", {
          url: `user/getRatingForUser/${this.dish.id}`,
        })
        .then((res) => {
          this.usersRatingFromBase = res;
          console.log(res);
        });
    },
    getUsersData() {
      this.$store.dispatch("apiRequest/getApiRequest", { url: "user/0" }).then((res) => {
        this.userData = res;
        this.check();
      });
    },
    checkBox(recipeId) {
      console.log(recipeId);
      const data = {
        selectedRecipeId: recipeId,
        id: this.dish.id,
      };
      this.$store
        .dispatch("apiRequest/postApiRequest", {
          url: "Dish/changeSelectedRecipe",
          data: data,
        })
        .then((res) => {
          this.getDish();
        });
    },
    check() {
      this.userData.roles.forEach((el) => {
        if (el == "admin") return (this.admin = true);
      });
    },
  },
  filters: {
    ParseFloat(number) {
      let newValue = parseFloat(number).toFixed(2);
      return newValue;
    },
  },
  created() {
    this.getDish();
    this.getUsersData();
  },
};
</script>
<style lang="stylus" scoped>
.mainDiv {
  display: flex;
  flex-direction: row;
}

.mainForRecipe {
  display: flex;
  flex-direction: column;
}

.topDiv {
  display: flex;
  flex-wrap: wrap;
  flex-direction: row;
}

.itemForRecipe {
  transition: 0.2s ease-in-out 0s;
}

.itemForRecipe:hover {
  cursor: pointer;
  color: white;
  transform: scale(1.1);
  border-style: solid;
  border-width: 4px;
  border-color: grey;
}
input[type=checkbox] {
  transform: scale(1.5);
}

input[type=checkbox] {
  width: 15px;
  height: 15px;
  margin-right: 8px;
  cursor: pointer;
  font-size:10px;
  visibility: hidden;
}

input[type=checkbox]:after {
  content: " ";
  background-color:white;
  display: inline-block;
  margin-left: 10px;
  padding-bottom: 5px;
  color: #baa671;
  width: 15px;
  height: 15px;
  visibility: visible;
  border: 1px solid #baa671;
  padding-left: 3px;
  border-radius: 5px;
}

input[type=checkbox]:checked:after {
  content: "\2714";
  padding: -5px;
  font-weight: bold;
}
cards {
  font-family: 'Open Sans';
}
</style>
