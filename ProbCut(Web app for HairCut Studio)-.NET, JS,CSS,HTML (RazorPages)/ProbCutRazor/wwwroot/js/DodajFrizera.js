function fetchLangData(resourceName) {
    let result;
    $.ajax({
        type: "GET",
        url: "DodajFrizera?handler=LangData&resourceName=" + resourceName,
        contentType: "application/json; charset=utf-8",
        async: false,
        dataType: "json",
        success: function (response) {
            result = response;
        }
    });
    return result;
}

$('#buttonAddBarber').on('click', validateInputData);

function validateInputData() {

    // removing all previous messages
    const errors = document.getElementsByClassName('errorMessage');
    while (errors.item(0))
        errors.item(0).remove();

    let firstNameValue = document.getElementById('inputFirstName').value;
    let lastNameValue = document.getElementById('inputLastName').value;
    let usernameValue = document.getElementById('inputUsername').value;
    let passwordValue = document.getElementById('inputPassword').value;
    let dateOfBirthValue = document.getElementById('inputDateOfBirth').value;
    let phoneNumberValue = document.getElementById('inputPhoneNumber').value;

    //      1. checking if the first name is empty
    if (firstNameValue == "") {
        displayErrorMessage(document.getElementById('inputGroupFirstName'), fetchLangData('ErrorFirstNameEmpty'));
    }
    //      2. checking if the first name is at least 2 characters long
    else if (firstNameValue.length < 2) {
        displayErrorMessage(document.getElementById('inputGroupFirstName'), fetchLangData('ErrorFirstNameTooShort'));
    }

    //      3. checking if the first name uses invalid characters
    var validCharactersFirstName = 'abcčćdđefghijklmnopqrsštuvwxyzžABCČĆDĐEFGHIJKLMNOPQRSŠTUVWXYZŽ';
    for (var i = firstNameValue.length - 1; i >= 0; i--) {
        if (validCharactersFirstName.indexOf(firstNameValue.substr(i, 1)) == -1) {
            displayErrorMessage(document.getElementById('inputGroupFirstName'), fetchLangData('ErrorFirstNameInvalidCharacter'));
            break;
        }
    }

    // _____________________________________________________________________________________
    //      1. checking if the last name is empty
    if (lastNameValue == "") {
        displayErrorMessage(document.getElementById('inputGroupLastName'), fetchLangData('ErrorLastNameEmpty'));
    }
    //      2. checking if the last name is at least 2 characters long
    else if (lastNameValue.length < 2) {
        displayErrorMessage(document.getElementById('inputGroupLastName'), fetchLangData('ErrorLastNameTooShort'));
    }

    //      3. checking if the last name uses invalid characters
    for (var i = lastNameValue.length - 1; i >= 0; i--) {
        if (validCharactersFirstName.indexOf(lastNameValue.substr(i, 1)) == -1) {
            displayErrorMessage(document.getElementById('inputGroupLastName'), fetchLangData('ErrorLastNameInvalidCharacter'));
            break;
        }
    }

    // _____________________________________________________________________________________
    //      1. checking if the username is empty
    if (usernameValue == "") {
        displayErrorMessage(document.getElementById('inputGroupUsername'), fetchLangData('ErrorUsernameEmpty'));
    }

    //      2. checking if the username is at least 3 characters long
    else if (usernameValue.length < 3) {
        displayErrorMessage(document.getElementById('inputGroupUsername'), fetchLangData('ErrorUsernameTooShort'));
    }

    //      3. checking if the username has more than 30 characters
    else if (usernameValue.length > 30) {
        displayErrorMessage(document.getElementById('inputGroupUsername'), fetchLangData('ErrorUsernameTooLong'));
    }

    //      4. checking if the username uses invalid characters
    var validCharacters = '1234567890-_.abcčćdđefghijklmnopqrsštuvwxyzžABCČĆDĐEFGHIJKLMNOPQRSŠTUVWXYZŽ';
    for (var i = usernameValue.length - 1; i >= 0; i--) {
        if (validCharacters.indexOf(usernameValue.substr(i, 1)) == -1) {
            displayErrorMessage(document.getElementById('inputGroupUsername'), fetchLangData('ErrorUsernameInvalidCharacter'));
            break;
        }
    }

    //      5. checking if the username has consecutive dots or dashes
    for (var i = usernameValue.length - 2; i >= 0; i--) {
        var consError = false;
        if (usernameValue.charAt(i) == '.') {
            if (usernameValue.charAt(i + 1) == '.')
                consError = true;
        }

        if (usernameValue.charAt(i) == '-') {
            if (usernameValue.charAt(i + 1) == '-')
                consError = true;
        }

        if (consError) {
            displayErrorMessage(document.getElementById('inputGroupUsername'), fetchLangData('ErrorUsernameConsecutiveSymbols'));
            break;
        }
    }

    // _____________________________________________________________________________________
    //      1. checking if the password is empty
    if (passwordValue == "") {
        displayErrorMessage(document.getElementById('inputGroupPassword'), fetchLangData('ErrorPasswordEmpty'));
    }
    //      2. checking if the password is at least 6 characters long
    else if (6 > passwordValue.length) {
        displayErrorMessage(document.getElementById('inputGroupPassword'), fetchLangData('ErrorPasswordTooShort'));
    }
    //      3. checking if the password has more than 30 characters
    else if (passwordValue.length > 30) {
        displayErrorMessage(document.getElementById('inputGroupPassword'), fetchLangData('ErrorPasswordTooLong'));
    }


    // _____________________________________________________________________________________
    //      1. checking if the date of birth is empty
    if (dateOfBirthValue == '') {
        displayErrorMessage(document.getElementById('inputGroupDateOfBirth'), fetchLangData('ErrorDateOfBirthEmpty'));
    }

    // _____________________________________________________________________________________
    //      1. checking if the phone number uses invalid characters
    var validCharactersNumber = '0123456789 ';
    if (phoneNumberValue != '') {
        for (var i = phoneNumberValue.length - 1; i >= 0; i--) {
            if (validCharactersNumber.indexOf(phoneNumberValue.substr(i, 1)) == -1) {
                displayErrorMessage(document.getElementById('inputGroupPhoneNumber'), fetchLangData('ErrorPhoneNumberInvalidCharacter'));
                break;
            }
        }
    }


    // if there were no errors, call server function

    const data = new Array();
    data.push(firstNameValue);
    data.push(lastNameValue);
    data.push(usernameValue);
    data.push(passwordValue);
    data.push(document.getElementById('inputGender').value);
    data.push(document.getElementById('inputGenderToWorkWith').value);
    data.push(dateOfBirthValue);
    data.push(phoneNumberValue);

    if (document.getElementsByClassName('errorMessage').length == 0) {
        $.ajax({
            type: "GET",
            url: "DodajFrizera?handler=AddBarber&data=" + data,
            data: JSON.stringify(data),
            contentType: "application/json; charset=utf-8",
            async: false,
            dataType: "json"
        });

        location.href = './LogovanVlasnik?Added';
    }
}

function displayErrorMessage(parent, messageText) {
    const label = document.createElement('label');
    label.className = 'errorMessage';
    label.style.color = 'red';
    label.innerHTML = messageText;

    parent.appendChild(label);
}