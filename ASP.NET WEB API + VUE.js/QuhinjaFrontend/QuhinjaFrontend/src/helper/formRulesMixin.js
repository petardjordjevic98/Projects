const emailPattern = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/
const passwordPattern = /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z0-9@$!%*#?&]{8,}$/
const phoneNumberPattern = /^[0-9 ]+$/

const userNameMaxLength = 30
const firstNameMaxLength = 25
const lastNameMaxLength = 30
const mobilePhoneMaxLength = 20

const regionNameMaxLength = 25
const townNameMaxLength = 20
const vehicleCategoryNameMaxLength = 30
const ImageUrlMaxLength = 200

const maxLengthValidation = (maxLength) => {
  return val => val.length <= maxLength || `Maksimalni broj karaktera za polje je ${maxLength}`
}

export const formRulesMixin = {
  methods: {
    requiredField: val => !!val || 'Polje je obavezno',
    emailField: val => emailPattern.test(val) || 'Unesite validnu email adresu',
    passwordField: val => passwordPattern.test(val) || 'Šifra treba sadržti minimum 8 karaktera i bar jedan specijalni karatker, slovo i broj',
    phoneField: val => phoneNumberPattern.test(val) || 'Broj telefona moze sadrzati samo brojeve',
    invalidYear: val => val < 2021 || 'Nevalidna godina',
    positiveNumber: val => val > 0 || 'Vrednost mora biti pozitivan broj',
    postalCodeField: val => (val >= 10000 && val <= 40000) || 'Nevalidan postanski broj',
    userNameMaxLengthValidation: maxLengthValidation(userNameMaxLength),
    firstNameMaxLengthValidation: maxLengthValidation(firstNameMaxLength),
    lastNameMaxLengthValidation: maxLengthValidation(lastNameMaxLength),
    mobilePhoneMaxLengthValidation: maxLengthValidation(mobilePhoneMaxLength),
    regionNameMaxLengthValidation: maxLengthValidation(regionNameMaxLength),
    townNameMaxLengthValidation: maxLengthValidation(townNameMaxLength),
    vehicleCategoryNameMaxLengthValidation: maxLengthValidation(vehicleCategoryNameMaxLength),
    ImageUrlMaxLengthValidation: maxLengthValidation(ImageUrlMaxLength)
  }
}
