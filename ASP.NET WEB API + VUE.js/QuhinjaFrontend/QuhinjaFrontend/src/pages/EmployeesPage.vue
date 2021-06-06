<template>
  <q-page class="bg-grey-4">
    <div class="q-pa-md q-gutter-md">
      <q-list style="width: 100%">
        <q-item class="q-mb-sm text-brown-5">
          <q-item-section avatar>
            <q-avatar style="width: 100px"> </q-avatar>
          </q-item-section>

          <q-item-section>
            <q-item-label>
              <span class="text-bold">Ime i prezime</span>
            </q-item-label>
          </q-item-section>

          <q-item-section>
            <q-item-label class="text-bold"> Datum rođenja</q-item-label>
          </q-item-section>
          <q-item-section>
            <q-item-label class="text-bold">Datum zaposlenja</q-item-label>
          </q-item-section>

          <q-item-section>
            <q-item-label class="text-bold"> Omiljeno jelo</q-item-label>
          </q-item-section>
          <q-item-section v-if="admin">
            <q-item-label class="text-bold"> Izostanci</q-item-label>
          </q-item-section>
          <q-btn
            v-if="admin"
            @click="handleNewUserClick"
            color="red-5"
            label=" + Dodaj novog radnika"
            class="buttonForEmployee"
          />
        </q-item>
        <q-item
          style="border-radius: 15px 15px 15px 15px"
          class="bg-red-2 q-mb-md"
          v-for="employee in employees"
          :key="employee.id"
          v-ripple
        >
          <q-item-section avatar>
            <q-avatar style="height: 100px; width: 100px">
              <img :src="employee.image" />
            </q-avatar>
          </q-item-section>

          <q-item-section>
            <q-item-label>
              <span>{{ employee.name }} {{ employee.surname }}</span>
            </q-item-label>
          </q-item-section>

          <q-item-section>
            <q-item-label> {{ employee.dateOfBirth | ParseDate }}</q-item-label>
          </q-item-section>
          <q-item-section>
            <q-item-label>{{ employee.dateOfEmployment | ParseDate }}</q-item-label>
          </q-item-section>

          <q-item-section v-if="employee.favouriteDish != null">
            <q-img
              style="border-radius: 20px"
              height="100px"
              width="100px"
              :src="employee.favouriteDish.image"
            ></q-img>
            <q-item-label>{{ employee.favouriteDish.name }}</q-item-label>
          </q-item-section>
          <q-item-section v-if="admin">
            <div class="q-pa-md">
              <q-btn icon="event" round color="red-1">
                <q-popup-proxy
                  @before-show="updateProxy"
                  transition-show="rotate"
                  transition-hide="rotate"
                >
                  <q-date
                    :options="optionsFn"
                    :events="employee.missedDatesFromBase"
                    :event-color="'red'"
                    color="red-2"
                    text-color="red-1"
                    v-model="proxyDate"
                  >
                    <div class="row items-center justify-end q-gutter-sm">
                      <q-btn
                        label="Cancel"
                        @click="cancel"
                        class="bg-red-1"
                        color="white"
                        flat
                        v-close-popup
                      />
                      <q-btn
                        label="OK"
                        class="bg-red-1"
                        color="white"
                        flat
                        @click="save(employee)"
                        v-close-popup
                      />
                    </div>
                  </q-date>
                </q-popup-proxy>
              </q-btn>
            </div>
          </q-item-section>
        </q-item>
      </q-list>
      <div class="col-6"></div>
    </div>
    <q-dialog v-model="visibleRegisterForm" persistent @hide="handleHideRegisterDialog">
      <q-card class="q-py-sm full-width text-accent">
        <q-card-section class="q-ml-sm row full-width justify-between items-center">
          <div class="text-h4 q-pl-sm text-brown-5">Registracija</div>
          <q-btn
            icon="close"
            class="text-brown-5"
            flat
            round
            dense
            @click="handleHideRegisterDialog"
          />
        </q-card-section>
        <q-form
          ref="form"
          class="full-width column q-gutter-y-sm"
          @submit="handleSubmitRegisterForm"
        >
          <q-input
            color="red-2"
            dense
            outlined
            v-model="formData.email"
            label="Email"
            :rules="[requiredField, emailField]"
          >
            <template v-slot:prepend>
              <q-icon name="email" />
            </template>
          </q-input>
          <q-input
            color="red-2"
            v-model="formData.username"
            label="Korisnicko ime"
            dense
            outlined
            :rules="[requiredField, userNameMaxLengthValidation]"
          />
          <q-input
            color="red-2"
            v-model="formData.name"
            label="Ime"
            dense
            outlined
            :rules="[requiredField, firstNameMaxLengthValidation]"
          />
          <q-input
            color="red-2"
            v-model="formData.surname"
            label="Prezime"
            dense
            outlined
            :rules="[requiredField, lastNameMaxLengthValidation]"
          />
          <q-input
            color="red-2"
            v-model="formData.position"
            label="Pozicija"
            dense
            outlined
            :rules="[requiredField, lastNameMaxLengthValidation]"
          />
          <q-select
            color="red-2"
            v-model="formData.gender"
            label="Pol"
            outlined
            dense
            :options="[
              { value: 1, label: 'Muski' },
              { value: 2, label: 'Zenski' },
            ]"
            :rules="[requiredField]"
          />
          <q-checkbox
            color="brown"
            v-model="formData.admin"
            class="text-brown-5"
            label="Admin"
          />
          <q-input
            color="red-2"
            v-model="formData.birthDate"
            label="Datum rodjenja"
            outlined
            dense
          >
            <template v-slot:append>
              <q-icon name="event" class="cursor-pointer">
                <q-popup-proxy
                  ref="qDateProxy"
                  transition-show="scale"
                  transition-hide="fade"
                >
                  <q-date
                    v-model="formData.birthDate"
                    minimal
                    :mask="dateFormatString"
                    @input="() => $refs.qDateProxy.hide()"
                  />
                </q-popup-proxy>
              </q-icon>
            </template>
          </q-input>
          <q-input
            color="red-2"
            v-model="formData.firstDayAtWork"
            label="Datum zaposlenja"
            outlined
            dense
          >
            <template v-slot:append>
              <q-icon name="event" class="cursor-pointer">
                <q-popup-proxy
                  ref="qDateProxy"
                  transition-show="scale"
                  transition-hide="fade"
                >
                  <q-date
                    v-model="formData.firstDayAtWork"
                    minimal
                    :mask="dateFormatString"
                    @input="() => $refs.qDateProxy.hide()"
                  />
                </q-popup-proxy>
              </q-icon>
            </template>
          </q-input>
          <q-btn
            class="q-py-sm"
            type="submit"
            color="red-5"
            label="Dodaj novog zaposlenog"
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
import { date } from "quasar";
import { formRulesMixin } from "src/helper/formRulesMixin";
import { baseUrl } from "../services/apiConfig";
export default {
  mixins: [formRulesMixin],
  data() {
    return {
      employees: null,
      admin: false,
      proxyDate: "",
      events: [],
      eventsForBase: [],
      menuItemsFromBase: [],
      visibleRegisterForm: false,
      registerButtonLoading: false,
      formData: {
        email: "",
        username: "",
        name: "",
        surname: "",
        position: "",
        birthDate: null,
        firstDayAtWork: null,
        gender: null,
        admin: false,
      },
      dateFormatString: "DD/MM/YYYY",
    };
  },
  filters: {
    ParseDate(date) {
      return (date = moment(date).format("LL")); // put format as you want
    },
  },
  methods: {
    handleNewUserClick() {
      this.visibleRegisterForm = true;
    },
    handleHideRegisterDialog() {
      this.visibleRegisterForm = false;
    },
    handleSubmitRegisterForm() {
      console.log(this.formData);

      this.$store
        .dispatch("auth/register", {
          ...this.formData,
          dateOfBirth: moment(this.formData.birthDate, this.dateFormatString).format(),
          dateOfEmployment: moment(
            this.formData.firstDayAtWork,
            this.dateFormatString
          ).format(),
        })
        .then((response) => {
          this.$q.notify({
            position: "top",
            message: "Uspesno ste registrovali korisnika",
            color: "brown",
          });
          this.visibleRegisterForm = false;
          this.formData = {
            email: "",
            username: "",
            name: "",
            surname: "",
            position: "",
            birthDate: null,
            firstDayAtWork: null,
            gender: null,
            admin: false,
          };
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
    optionsFn(date) {
      if (this.events.includes(date)) return true;
      else {
        return false;
      }
    },
    eventsFn(date) {
      if (!this.eventsForBase.includes(this.proxyDate)) {
        this.eventsForBase.push(this.proxyDate);
      } else {
        // for (var i = 0; i < this.events.length; i++) {
        //   if (this.events[i] === this.proxyDate) {
        //     this.events.splice(i, 1);
        //     i--;
        //   }
        // }
      }
      if (this.events.includes(date)) {
        return true;
      }
      return false;
    },
    updateProxy() {},
    save(employee) {
      var menuItemId = 0;
      this.menuItemsFromBase.forEach((el) => {
        if (el.dateOfDish == this.proxyDate) menuItemId = el.id;
      });
      const data = {
        userId: parseInt(employee.id),
        menuItemId: menuItemId,
      };
      this.$store
        .dispatch("apiRequest/postApiRequest", {
          url: "MenuItem/addMissedDate",
          data: data,
        })
        .then((res) => {
          this.getData();
        });
    },
    cancel() {
      this.proxyDate = "";
    },
    getUsersData() {
      this.$store.dispatch("apiRequest/getApiRequest", { url: "user/0" }).then((res) => {
        this.userData = res;

        this.check();
      });
    },
    getData() {
      this.$store.dispatch("apiRequest/getApiRequest", { url: "User" }).then((res) => {
        this.employees = res;
        this.employees.forEach((el) => {
          el.image = "data:image/png;base64," + el.image;
          el.favouriteDish.image = "data:image/png;base64," + el.favouriteDish.image;
          el.missedDatesFromBase = [];
          el.missedDates.forEach((menu) => {
            let timeStamp = menu.menuItem.dateOfDish;
            let formattedString = date.formatDate(timeStamp, "YYYY/MM/DD");

            el.missedDatesFromBase.push(formattedString);
          });
        });
      });
    },
    check() {
      this.userData.roles.forEach((el) => {
        if (el == "admin") return (this.admin = true);
      });
    },
    getMenuItems() {
      this.$store
        .dispatch("apiRequest/getApiRequest", { url: "MenuItem" })
        .then((res) => {
          this.menuItemsFromBase = res;

          this.menuItemsFromBase.forEach((el) => {
            let timeStamp = el.dateOfDish;
            let formattedString = date.formatDate(timeStamp, "YYYY/MM/DD");
            this.events.push(formattedString);
            el.dateOfDish = formattedString;
          });
        });
    },
  },
  created() {
    this.getData();
    this.getUsersData();
    this.getMenuItems();
  },
};
</script>
