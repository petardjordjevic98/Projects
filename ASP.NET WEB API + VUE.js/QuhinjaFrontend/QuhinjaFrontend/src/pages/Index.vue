<template>
  <q-page class="column items-center q-gutter-y-none bg-grey-4">
    <div class="q-mb-md text-h5 text-brown-9 q-mt-sm items-center column firstDiv">
      <u>Danas na meniju</u>
    </div>

    <div v-if="this.todaysMenu" class="bg-red-2 menu">
      <div class="q-mt-md q-mr-md leftDiv">
        <div v-if="this.todaysMenu.recipe" class="q-ml-md pictureDiv">
          <q-img
            style="border-radius: 15px 15px 15px 15px; height: 300px"
            :src="todaysMenu.recipe.image"
          ></q-img>

          <div
            style="font-size: 24px"
            class="q-mt-md text-bold text-brown-9 middleDiv q-m-sm q-ml-md"
          >
            <p>{{ this.todaysMenu.recipe.dish.name }}</p>
          </div>
        </div>
      </div>
      <q-separator vertical class="q-ml-md bg-red-2" />

      <div class="rightDiv q-mt-md q-mr-md">
        <q-list
          v-if="this.todaysMenu.recipe"
          bordered
          class="q-mr-sm itemForIng bg-red-1 rounded-borders"
          style="color: #6f6e57; border-radius: 15px 15px 15px 15px"
        >
          <q-item-label class="itemForIng text-bold" header>Sastojci:</q-item-label>
          <q-scroll-area style="height: 100px">
            <div class="flex column itemDiv">
              <q-item
                class="item"
                v-for="ing in this.todaysMenu.recipe.ingridients"
                :key="ing.ingridient.name"
              >
                <q-item-section top>
                  <q-item-label
                    style="white-space: nowrap"
                    class="text-red-2 text-bold q-mt-sm"
                    >{{ ing.ingridient.name }} : {{ ing.quantity }}
                    {{ ing.unit }}</q-item-label
                  >
                </q-item-section>
              </q-item>
            </div>
          </q-scroll-area>
        </q-list>
        <div v-if="this.todaysMenu.recipe" class="q-mt-sm">
          <q-scroll-area style="height: 500px">
            <q-input
              readonly
              class="way"
              v-model="this.todaysMenu.recipe.wayOfPreparing"
              autogrow
            />
          </q-scroll-area>
        </div>
      </div>
    </div>
    <div class="text-black" v-else>Danas nema nicega na meniju</div>
    <div class="q-mb-sm q-mt-md text-h5 text-brown-9">
      <u> Najbolje ocenjena jela</u>
    </div>
    <q-carousel
      v-if="this.dishes"
      v-model="selectedDishIndex"
      swipeable
      infinite
      animated
      padding
      arrows
      class="bg-transparent"
      control-color="red-1"
    >
      <q-carousel-slide
        class="q-pa-sm"
        v-for="(dish, index) in dishes"
        :key="index"
        :name="index"
      >
        <div class="row q-gutter-x-md justify-center items-center">
          <div
            class="column items-center"
            v-for="adjacentIndex in adjacentIndexes(index)"
            :key="adjacentIndex"
          >
            <q-card style="width: 200px; height: 290px" class="my-card">
              <q-img height="140px" :src="dishes[adjacentIndex].image" />

              <q-card-section>
                <div class="row no-wrap items-center">
                  <div class="col text-h6 ellipsis text-bold">
                    {{ dishes[adjacentIndex].name }}
                  </div>

                  <div class="text-brown-9 text-h6 text-bold">
                    {{ dishes[adjacentIndex].averageRating | ParseFloat }}
                  </div>
                </div>
                <div style="" class="text-brown-9 text-subtitle1 text-bold">
                  {{ dishes[adjacentIndex].dishType }}
                </div>
              </q-card-section>

              <q-card-section class="q-pt-none">
                <div
                  style="
                    text-overflow: ellipsis;
                    white-space: nowrap;
                    overflow: hidden;
                    width: 100px;
                  "
                  class="text-caption text-brown-8"
                >
                  {{ dishes[adjacentIndex].description }}
                </div>
              </q-card-section>

              <q-card-actions style="position: relative" class="teal-3">
                <div
                  style="   text-bold;
position:absolute; right:0;"
                  class="buttonDetails"
                  @click="handleClick(dishes[adjacentIndex].id)"
                  flat
                >
                  Detalji >>
                </div>
              </q-card-actions>
            </q-card>
          </div>
        </div>
      </q-carousel-slide>
    </q-carousel>
  </q-page>
</template>

<script>
export default {
  name: "PageIndex",
  data() {
    return {
      stars: 3,
      dishes: [],
      selectedDishIndex: 0,
      todaysMenu: {},
    };
  },
  computed: {},
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
    getData() {
      this.$store
        .dispatch("apiRequest/getApiRequest", { url: "/dish/getSortedDishes" })
        .then((res) => {
          this.dishes = res;

          this.dishes.forEach((element) => {
            element.image = "data:image/png;base64," + element.image;
          });
        });
    },
    getTodayItem() {
      this.$store
        .dispatch("apiRequest/getApiRequest", { url: "/MenuItem/todaysRecipe" })
        .then((res) => {
          this.todaysMenu = res;
          this.todaysMenu.recipe.image =
            "data:image/png;base64," + this.todaysMenu.recipe.image;
        });
    },
    adjacentIndexes(index) {
      const length = this.dishes.length;
      const array = [];
      if (this.numOfShowedItems === 5) {
        array.push((index - 2 + length) % length);
      }
      array.push((index - 1 + length) % length);
      array.push(index);
      array.push((index + 1) % length);
      if (this.numOfShowedItems === 5) {
        array.push((index + 2) % length);
      }
      return array.reverse();
    },
  },
  created() {
    this.getData();
    this.getTodayItem();
  },

  computed: {
    numOfShowedItems() {
      if (this.$q.screen.gt.sm) return 5;
      else return 3;
    },
  },
};
</script>
<style scoped>
* {
  font-family: "Open Sans";
}
@media screen and (max-width: 1920px) {
  .menu {
    display: flex;
    flex-wrap: wrap;
    flex-direction: row;

    border-radius: 15px 15px 15px 15px;
    height: 400px;
    width: 1050px;
  }
  .rightDiv {
    height: 300px;
    width: 500px;
  }
  .leftDiv {
    height: 300px;
    width: 500px;
  }
  .item {
    width: 200px;
  }
  .pictureDiv {
    height: 100%;
    width: 500px;
  }
  .itemForIng {
    width: 500px;
    font-size: 20px;
    color: white;
  }
}
@media screen and (max-width: 1000px) {
  . rightDiv {
    height: 200px;
    width: 200px;
  }
  .way {
    width: 400px;
  }
  .item {
    width: 200px;
  }
  .itemForIng {
    width: 400px;
    font-size: 18px;
    color: white;
  }
  .pictureDiv {
    height: 100%;
    width: 400px;
  }
  .leftDiv {
    height: 200px;
    width: 400px;
  }
  .menu {
    flex-direction: row;
    display: flex;
    height: 400px;
    width: 1000px;
  }
}
.my-card {
  background-color: #baa671;
  color: #f1eae8;
}
.leftDiv {
  display: flex;
  flex-direction: row;
  flex-grow: 1;
}
.buttonDetails {
  margin-left: 0;
  transition: 0.2s ease-in-out 0s;
}
.buttonDetails:hover {
  cursor: pointer;
}
</style>
