<template>
  <q-page class="bg-grey-4">
    <div
      style="
        justify-content: center;
        display: flex;
        flex-direction: column;
        margin: 30px;
        margin-top: 0;
      "
    >
      <div style="margin-left: 30px; align-items: center" class="row q-gutter-x-md">
        <q-btn label="Filter" icon-right="sort" class="text-red-5" flat>
          <q-menu transition-show="rotate" transition-hide="rotate" fit auto-close>
            <q-list style="min-width: 150px">
              <q-item
                v-for="option in sortingOptions"
                :key="option.value"
                clickable
                @click="sortDishes(option)"
              >
                <q-item-section>{{ option }}</q-item-section>
              </q-item>
            </q-list>
          </q-menu>
        </q-btn>
        <q-btn
          v-if="sortBool"
          style="height: 30px"
          dense
          rounded
          color="red-2"
          label="Isključi filter"
          @click="
            sortBool = false;
            dishesForView = dishes;
          "
        />

        <q-input
          color="red-2"
          v-model="search"
          filled
          type="search"
          placeholder="Pretraži..."
        >
          <template v-slot:append>
            <q-icon name="search" />
          </template>
        </q-input>
        <q-btn
          color="red-5"
          to="/addDish"
          label=" + Dodaj novo jelo"
          class="buttonForDish"
        />
      </div>

      <div class="cards">
        <q-card
          :ratio="16 / 9"
          style="border-radius: 15px 15px 15px 15px; width: 275px"
          v-for="(dish, index) in dishesForView.slice(
            (currentPage - 1) * dishesPerPage,
            currentPage * dishesPerPage
          )"
          :key="index"
          class="my-card"
        >
          <q-img height="200px" :src="dish.image" />

          <q-card-section style="" class="bg-red-2">
            <div class="row no-wrap items-center">
              <div class="text-bold col text-h6 ellipsis">
                {{ dish.name }}
              </div>
              <div v-if="dish.averageRating > 0" class="text-brown-9 text-h6">
                {{ dish.averageRating | ParseFloat }}
              </div>
              <div v-else class="text-grey-9">nije ocenjeno</div>
            </div>
            <div class="text-bold text-subtitle1 text-brown-9">
              {{ dish.dishType }}
            </div>
          </q-card-section>

          <q-card-section
            style="border-radius: 0px 0px 15px 15px"
            class="bg-red-2 q-pt-none"
          >
            <div
              style="
                text-overflow: ellipsis;
                white-space: nowrap;
                overflow: hidden;
                width: 100px;
              "
              class="text-caption text-brown-8"
            >
              {{ dish.description }}
            </div>
            <div
              class="text-white buttonDetails"
              style="position: absolute; right: 10px; bottom: 1px"
              @click="handleClick(dish.id)"
              flat
              color="white"
            >
              Detalji >>
            </div>
          </q-card-section>
        </q-card>
      </div>
    </div>

    <div class="divForPaging q-pa-lg flex flex-center">
      <div class="q-pa-lg flex flex-center">
        <q-pagination
          color="red-5"
          v-model="currentPage"
          :max="numOfPages"
          :max-pages="6"
          :boundary-numbers="true"
        >
        </q-pagination>
      </div>
    </div>
  </q-page>
</template>
<script>
import { baseUrl } from "../services/apiConfig";
export default {
  data() {
    return {
      dishes: [],
      sortingOptions: [],
      sortingOption: "",
      dishesForView: [],
      search: "",
      dishesPerPage: 8,
      currentPage: 1,
      sortBool: false,
    };
  },
  computed: {
    numOfDishes() {
      return this.dishesForView.length;
    },
    numOfPages() {
      if (this.numOfDishes % this.dishesPerPage == 0)
        return this.numOfDishes / this.dishesPerPage;
      else {
        return this.numOfDishes / this.dishesPerPage + 1;
      }
    },
  },
  watch: {
    search: function () {
      if (this.search == "") {
        this.dishesForView = this.dishes;
      } else {
        this.dishesForView = this.dishesForView.filter((dish) => {
          return dish.name.toLowerCase().startsWith(this.search.toLowerCase());
        });
      }
    },
  },
  filters: {
    ParseFloat(number) {
      let newValue = parseFloat(number).toFixed(2);
      return newValue;
    },
  },
  methods: {
    handleClick(id) {
      this.$router.push("dish/" + id);
    },
    sortDishes(option) {
      this.sortBool = true;
      this.dishesForView = [];
      this.dishes.forEach((element) => {
        if (element.dishType == option) this.dishesForView.push(element);
      });
    },
    getData() {
      this.$store.dispatch("apiRequest/getApiRequest", { url: "Dish" }).then((res) => {
        this.dishes = res;

        this.dishes.forEach((element) => {
          element.image = "data:image/png;base64," + element.image;
        });
        this.dishesForView = this.dishes;
      });
    },
    getDishTypes() {
      this.$store
        .dispatch("apiRequest/getApiRequest", { url: `/dish/dishTypes` })
        .then((res) => {
          this.sortingOptions = res;
        });
    },
  },
  created() {
    this.getData();
    this.getDishTypes();
  },
};
</script>
<style scoped>
.divForPaging {
  display: flex;
  flex-direction: row;
}
.cards {
  justify-content: center;
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  position: relative;
}

.my-card {
  background-color: #7d7962;
  margin: 15px;

  transition: 0.2s ease-in-out 0s;
  width: 275px;
}

.buttonForDish {
  position: absolute;
  right: 100px;
  top: 20px;
  transition: 0.2s ease-in-out 0s;
}
.buttonForDish:hover {
  cursor: pointer;
  transform: scale(1.1);
  background: #fff;
  color: #000;
}
.buttonDetails {
  transition: 0.2s ease-in-out 0s;
}
.buttonDetails:hover {
  cursor: pointer;
  color: blue;
}
.cards {
  font-family: "Open Sans";
}
</style>
