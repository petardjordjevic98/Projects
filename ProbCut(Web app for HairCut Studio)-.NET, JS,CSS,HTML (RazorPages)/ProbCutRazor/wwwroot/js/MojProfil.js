let generated = false;
let korisnik;
let komentari;
let komentarZaBrisanje;

let fetchLangData = function(resourceName, lang = false)
{
    let result;
    if (lang)
    {
        $.ajax({
            type: "GET",
            url: "MojProfil?handler=LangData&resourceName=" + resourceName + "&lang=true",
            contentType: "application/json; charset=utf-8",
            async: false,
            dataType: "json",
            success: function (response)
            {
                result = response;
            }
        });
    }
    else
    {
        $.ajax({
            type: "GET",
            url: "MojProfil?handler=LangData&resourceName=" + resourceName,
            contentType: "application/json; charset=utf-8",
            async: false,
            dataType: "json",
            success: function (response)
            {
                result = response;
            }
        });
    }
    return result;
}

$(window).on('load', function ()
{
    // displaying error message for failed account delete
    toastr.options.positionClass = 'toast-bottom-right';
    if (window.location.href.includes('deleteFailed'))
        toastr['error'](fetchLangData('NotificationFailedDeleteAccount'));

    // loading data
    let user = getUsernameFromURL();
    getKorisnik(user, true);

    $.ajax({
        type: "GET",
        url: "MojProfil?handler=Data&username=" + user,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response)
        {
            if (korisnik == null)
                return;

            // displaying certain HTML elements based on Korisnik attributes

            // avatar gender
            let avatarContainer = document.getElementById('imageAvatarContainer');
            let avatar = document.createElement('img');
            avatar.className = 'imageAvatar';
            if (korisnik.pol == 'Z')
                avatar.src = '../lib/custom/avatar_female.png';
            else
                avatar.src = '../lib/custom/avatar_male.png';

            avatarContainer.appendChild(avatar);

            // stats
            document.getElementById('stat1').innerHTML = response.stat1;
            document.getElementById('stat2').innerHTML = response.stat2;
            document.getElementById('stat1Opis').innerHTML = response.stat1Opis;
            document.getElementById('stat2Opis').innerHTML = response.stat2Opis;
            document.getElementById('tipKorisnika').innerHTML = response.tipKorisnika;

            let ulogovanKorisnik = getKorisnik(getCookie('username'));

            if (ulogovanKorisnik.username != korisnik.username && ulogovanKorisnik.tipKorisnika == 'm' && korisnik.tipKorisnika == 'f')
            {
                let header = document.getElementById('MyProfileHeader');
                header.style.marginBottom = '0px';

                // generate rating button
                let container = document.getElementById('ratingSection');

                let btnContainer = document.createElement('div');
                btnContainer.style.display = 'flex';
                btnContainer.style.justifyContent = 'center';
                let btnRate = document.createElement('button');
                btnRate.className = 'btn btn-primary';
                btnRate.id = 'buttonRate';
                btnRate.innerHTML = fetchLangData('ButtonRate');
                btnRate.onclick = rateBarber;

                let star = document.getElementById('stars');
                star.style.display = 'block';
                star.setAttribute('data-rating', response.stat2);

                $('.my-rating-4').starRating({
                    totalStars: 5,
                    starShape: 'rounded',
                    starSize: 40,
                    emptyColor: 'lightgray',
                    hoverColor: '#aeaaff',
                    activeColor: '#6c63ff',
                    ratedColor: '#6c63ff',
                    useGradient: false,
                    disableAfterRate: false
                });

                btnContainer.appendChild(btnRate);
                container.appendChild(btnContainer);
                container.style.marginBottom = '60px';

                let starCookie = getCookie('rating');
                if (starCookie.includes(korisnik.username))
                {
                    btnRate.disabled = true;
                    let lblRow = document.createElement('div');
                    lblRow.id = 'lblAlreadyRated';
                    lblRow.style.display = 'flex';
                    lblRow.style.justifyContent = 'center';
                    let labelRatingInfo = document.createElement('label');
                    labelRatingInfo.color = 'grey';
                    labelRatingInfo.innerHTML = fetchLangData('LabelAlreadyRated');
                    labelRatingInfo.style.marginTop = '10px';

                    lblRow.appendChild(labelRatingInfo);
                    container.appendChild(lblRow);
                }
            }

            // edit button
            if (ulogovanKorisnik.username == korisnik.username)
            {
                addEditButton();
                document.getElementById('buttonEdit').onclick = generateEditSection;
                document.getElementById('buttonDeleteAccount').onclick = onButtonDelete;
            }
            else
            {
                document.getElementById('MyProfileData').style.paddingBottom = '30px';
                document.getElementById('MyProfileData').style.marginBottom = '30px';
            }
            document.getElementById('buttonDeleteComment').onclick = deleteComment;

            // data
            let parent = document.getElementById('MyProfileData');
            let separator = Object.assign(document.createElement('hr'), { className: 'hr-myProfile' });

            // first name
            let data = [
                fetchLangData('DataFirstName'),
                response.korisnik.ime
            ];
            generateDataRow(data, 'rowFirstName');
            parent.appendChild(separator);

            // last name
            data[0] = fetchLangData('DataLastName');
            data[1] = response.korisnik.prezime;
            generateDataRow(data, 'rowLastName');
            separator = Object.assign(document.createElement('hr'), { className: 'hr-myProfile' });
            parent.appendChild(separator);

            // username
            data[0] = fetchLangData('DataUsername');
            data[1] = response.korisnik.username;
            generateDataRow(data, 'rowUsername');
            separator = Object.assign(document.createElement('hr'), { className: 'hr-myProfile' });
            parent.appendChild(separator);

            if (getKorisnik(getCookie('username')).username == korisnik.username)
            {
                // password
                data[0] = fetchLangData('DataPassword');
                data[1] = fetchLangData('ChangePassword');
                generateDataRow(data, 'rowPassword');
                separator = Object.assign(document.createElement('hr'), { className: 'hr-myProfile' });
                parent.appendChild(separator);
            }

            // gender
            data[0] = fetchLangData('DataGender');
            data[1] = response.pol;
            generateDataRow(data, 'rowGender');
            separator = Object.assign(document.createElement('hr'), { className: 'hr-myProfile' });
            parent.appendChild(separator);

            if (korisnik.tipKorisnika == 'f') {
                // gender to work with
                data[0] = fetchLangData('DataGenderToWorkWith');
                data[1] = response.polKojiSisa;
                korisnik.polKojiSisa = response.polKojiSisa;
                generateDataRow(data, 'rowGenderToWorkWith');
                separator = Object.assign(document.createElement('hr'), { className: 'hr-myProfile' });
                parent.appendChild(separator);
            }

            // date of birth
            data[0] = fetchLangData('DataDateOfBirth');
            data[1] = response.datum;
            generateDataRow(data, 'rowDateOfBirth');
            separator = Object.assign(document.createElement('hr'), { className: 'hr-myProfile' });
            parent.appendChild(separator);

            // phone number
            data[0] = fetchLangData('DataPhoneNumber');
            data[1] = response.korisnik.brojTelefona;
            generateDataRow(data, 'rowPhoneNumber');
        }
    });

    if (korisnik.tipKorisnika == 'f')
    {
        getComments(user);
        sortComments();
        generateCommentsSection();
    }

});

function getUsernameFromURL()
{
    return (new URLSearchParams(window.location.search)).get('username');
}

function getKorisnik(username, initialize = false)
{
    return $.ajax({
        type: "GET",
        url: "MojProfil?handler=Data&username=" + username,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response)
        {
            if (initialize && response.korisnik != null)
                korisnik = response.korisnik;
        }
    }).responseJSON.korisnik;
}

function getComments(username)
{
    $.ajax({
        type: "GET",
        url: "MojProfil?handler=Comments&username=" + username,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response)
        {
            komentari = response;
        }
    });
}

function sortComments()
{
    komentari = komentari.sort((a, b) => new moment(b.vreme, 'MM/DD/YYYY HH:mm:ss A') - new moment(a.vreme, 'MM/DD/YYYY HH:mm:ss A'));
}

function getCookie(cname)
{
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++)
    {
        var c = ca[i];
        while (c.charAt(0) == ' ')
        {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0)
        {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function generateChangePasswordDiv(e)
{
    try {  e.preventDefault(); } catch { }

    var parent = document.getElementById('rowPasswordContainer');

    if (!generated)
    {
        parent.querySelectorAll("*").forEach(x => x.remove());

        let row1 = document.createElement('div');
        row1.className = 'myProfileItemRow';
        let row2 = document.createElement('div');
        row2.className = 'myProfileItemRow';
        let row3 = document.createElement('div');
        row3.className = 'myProfileItemRow';

        let oldPassword = document.createElement('div');
        oldPassword.className = 'myProfileItemContainer';
        oldPassword.className += ' item-left';
        let labelOldPassword = document.createElement('label');
        labelOldPassword.className = 'myProfileItem';
        labelOldPassword.innerHTML = fetchLangData('OldPassword');
        oldPassword.appendChild(labelOldPassword);
        row1.appendChild(oldPassword);

        let newPassword = document.createElement('div');
        newPassword.className = 'myProfileItemContainer';
        newPassword.className += ' item-left';
        let labelNewPassword = document.createElement('label');
        labelNewPassword.className = 'myProfileItem';
        labelNewPassword.innerHTML = fetchLangData('NewPassword');
        newPassword.appendChild(labelNewPassword);
        row2.appendChild(newPassword);

        let inputOldPassword = document.createElement('div');
        inputOldPassword.className = 'myProfileItemContainer';
        inputOldPassword.className += ' item-right';
        let textboxInputOldPassword = document.createElement('input');
        textboxInputOldPassword.id = 'inputOldPassword';
        textboxInputOldPassword.type = 'password';
        textboxInputOldPassword.className = 'form-control myProfileInput';
        inputOldPassword.appendChild(textboxInputOldPassword);
        row1.appendChild(inputOldPassword);
        parent.appendChild(row1);

        let inputNewPassword = document.createElement('div');
        inputNewPassword.className = 'myProfileItemContainer';
        inputNewPassword.className += ' item-right';
        let textboxInputNewPassword = document.createElement('input');
        textboxInputNewPassword.id = 'inputNewPassword';
        textboxInputNewPassword.type = 'password';
        textboxInputNewPassword.className = 'form-control myProfileInput';
        inputNewPassword.appendChild(textboxInputNewPassword);
        row2.appendChild(inputNewPassword);
        parent.appendChild(row2);

        let divButtonChange = document.createElement('div');
        divButtonChange.className = 'myProfileItemContainer button-change';
        let buttonChange = document.createElement('button');
        buttonChange.className = 'btn btn-info btn-blue myButton';
        buttonChange.id = 'buttonChange';
        buttonChange.onclick = savePassword;
        let iconChange = document.createElement('i');
        iconChange.className = 'fas fa-check';
        buttonChange.appendChild(iconChange);
        divButtonChange.appendChild(buttonChange);
        row3.appendChild(divButtonChange);

        let divButtonCancel = document.createElement('div');
        divButtonCancel.className = 'myProfileItemContainer button-cancel';
        let buttonCancel = document.createElement('button');
        buttonCancel.className = 'btn btn-info btn-blue myButton';
        buttonCancel.id = 'buttonCancelPass';
        buttonCancel.onclick = generateChangePasswordDiv;
        let iconCancel = document.createElement('i');
        iconCancel.className = 'fas fa-times';
        buttonCancel.appendChild(iconCancel);
        divButtonCancel.appendChild(buttonCancel);
        row3.appendChild(divButtonCancel);
        parent.appendChild(row3);

        generated = true;
    }
    else
    {
        parent.querySelectorAll("*").forEach(x => x.remove());

        let row = document.createElement('div');
        row.className = 'myProfileItemRow';

        let divPassword = document.createElement('div');
        divPassword.className = 'myProfileItemContainer item-left';
        let labelPassword = document.createElement('label');
        labelPassword.className = 'myProfileItem';
        labelPassword.innerHTML = fetchLangData('DataPassword');
        divPassword.appendChild(labelPassword);
        row.appendChild(divPassword);
        parent.appendChild(row);

        let divButtonChangePassword = document.createElement('div');
        divButtonChangePassword.className = 'myProfileItemContainer item-right';
        let buttonChangePassword = document.createElement('a');
        buttonChangePassword.innerHTML = fetchLangData('ChangePassword');
        buttonChangePassword.className = 'myProfileItem';
        buttonChangePassword.onclick = generateChangePasswordDiv;
        buttonChangePassword.href = '#';
        divButtonChangePassword.appendChild(buttonChangePassword);
        row.appendChild(divButtonChangePassword);
        parent.appendChild(row);

        generated = false;
    }
}

function generateDataRow(data, rowID)
{
    let row = document.createElement('div');
    row.className = 'myProfileItemRow';
    row.id = rowID;

    let itemName = document.createElement('div');
    itemName.className = 'myProfileItemContainer item-left';
    let itemValue = document.createElement('div');
    itemValue.className = 'myProfileItemContainer item-right';

    row.appendChild(itemName);
    row.appendChild(itemValue);

    let labelName = document.createElement('label');
    labelName.className = 'myProfileItem';
    labelName.innerHTML = data[0];
    let labelValue;
    if (rowID == 'rowPassword')
    {
        labelValue = document.createElement('a');
        labelValue.onclick = generateChangePasswordDiv;
        labelValue.href = '#';
    }
    else
    {
        labelValue = document.createElement('label');
    }
    labelValue.className = 'myProfileItem';
    labelValue.innerHTML = data[1];

    itemName.appendChild(labelName);
    itemValue.appendChild(labelValue);

    let parent = document.getElementById('MyProfileData');
    if (rowID == 'rowPassword')
    {
        let rowContainer = document.createElement('div');
        rowContainer.id = 'rowPasswordContainer';
        rowContainer.appendChild(row);
        parent.appendChild(rowContainer);
    }
    else
    {
        parent.appendChild(row);
    }
}

function generateInputRow(rowID, inputType, value)
{
    let row = document.getElementById(rowID);
    let rightColumn = row.querySelector('.item-right');

    rightColumn.querySelectorAll('*').forEach(x => x.remove());

    let input;
    if (inputType == 'select')
    {
        input = document.createElement('select');
        input.className = 'form-control myProfileInput';
        input.id = 'input' + rowID.substring(3);
        let optionN = document.createElement('option');
        if (rowID == 'rowGender')
            optionN.text = fetchLangData('GenderNone');
        else
            optionN.text = fetchLangData('GenderBoth');
        let optionM = document.createElement('option');
        optionM.text = fetchLangData('GenderMale');
        let optionF = document.createElement('option');
        optionF.text = fetchLangData('GenderFemale');

        if (value == 'M' || value == fetchLangData('GenderMale'))
            optionM.selected = true;
        else if (value == 'Z' || value == fetchLangData('GenderFemale'))
            optionF.selected = true;
        else
            optionN.selected = true;

        input.add(optionN);
        input.add(optionM);
        input.add(optionF);
    }
    else
    {
        input = document.createElement('input');
        input.type = inputType;
        input.className = 'form-control myProfileInput';
        input.value = value;
        input.id = 'input' + rowID.substring(3);
    }
    
    rightColumn.appendChild(input);
}

function reverseInputRow(rowID, value)
{
    let row = document.getElementById(rowID);
    let rightColumn = row.querySelector('.item-right');

    rightColumn.querySelectorAll('*').forEach(child => child.remove());
    let label = document.createElement('label');
    label.className = 'myProfileItem';
    if (value == 'pol')
    {
        let val;
        if (korisnik.pol == 'M')
            val = fetchLangData('GenderMale');
        else if (korisnik.pol == 'Z')
            val = fetchLangData('GenderFemale');
        else
            val = fetchLangData('GenderNone');
        label.innerHTML = val;
    }
    else
        label.innerHTML = korisnik[value];

    rightColumn.appendChild(label);

    // clearing all error messages

    let parent = document.getElementById('MyProfileData');
    parent.querySelectorAll('*').forEach(child =>
    {
        if (child.className == 'myProfileItemRow hiddenData')
            child.remove();
    })
}

function generateEditSection()
{
    generateInputRow('rowFirstName', 'text', korisnik.ime);
    generateInputRow('rowLastName', 'text', korisnik.prezime);
    generateInputRow('rowUsername', 'text', korisnik.username);
    generateInputRow('rowGender', 'select', korisnik.pol);
    if (korisnik.tipKorisnika == 'f')
        generateInputRow('rowGenderToWorkWith', 'select', korisnik.polKojiSisa);
    generateInputRow('rowDateOfBirth', 'date', korisnik.datumRodjenjaFormatiranISO);
    generateInputRow('rowPhoneNumber', 'text', korisnik.brojTelefona);

    let buttonContainer = document.getElementById('buttonEditContainer');
    let divLeft = document.getElementById('divButtonLeft');
    let divRight = document.getElementById('divButtonRight');
    buttonContainer.querySelectorAll('*').forEach(child =>
    {
        if (child.id != 'divButtonLeft' && child.id != 'divButtonRight')
            child.remove()
    });

    let btnSave = document.createElement('button');
    btnSave.className = 'btn btn-info btn-blue myButton';
    btnSave.id = 'buttonSave';
    btnSave.innerHTML = fetchLangData('ButtonSave');
    btnSave.onclick = onButtonSave;
    let iconSave = document.createElement('i');
    iconSave.className = 'fas fa-save buttonIcon';
    btnSave.appendChild(iconSave);
    divRight.appendChild(btnSave);

    let btnCancel = document.createElement('button');
    btnCancel.className = 'btn btn-light myButton';
    btnCancel.id = 'buttonCancel';
    btnCancel.innerHTML = fetchLangData('ButtonCancel');
    btnCancel.onclick = onButtonCancel;
    let iconCancel = document.createElement('i');
    iconCancel.className = 'fas fa-times buttonIcon';
    btnCancel.appendChild(iconCancel);
    divRight.appendChild(btnCancel);

    let btnDelete = document.createElement('button');
    btnDelete.className = 'btn btn-secondary';
    btnDelete.id = 'buttonDelete';
    btnDelete.innerHTML = fetchLangData('DeleteAccount');
    btnDelete.onclick = function () { $('#modalDelete').modal(); }
    divLeft.appendChild(btnDelete);

    // edit appointment link button
    if (korisnik.tipKorisnika == 'm')
    {
        let linkAp = document.createElement('a');
        linkAp.id = 'linkEditAppointment';
        linkAp.innerHTML = fetchLangData('EditAppointment');
        linkAp.href = 'LogovanMusterija';
        linkAp.style.paddingLeft = '10px';
        linkAp.style.alignItems = 'center';

        divLeft.appendChild(linkAp);
    }
}

function onButtonCancel()
{
    reverseInputRow('rowFirstName', 'ime');
    reverseInputRow('rowLastName', 'prezime');
    reverseInputRow('rowUsername', 'username');
    reverseInputRow('rowGender', 'pol');
    if (korisnik.tipKorisnika == 'f')
        reverseInputRow('rowGenderToWorkWith', 'polKojiSisa');
    reverseInputRow('rowDateOfBirth', 'datumRodjenjaFormatiranShortDate');
    reverseInputRow('rowPhoneNumber', 'brojTelefona');

    let buttonContainer = document.getElementById('buttonEditContainer');
    buttonContainer.querySelectorAll('*').forEach(child =>
    {
        if (child.id != 'divButtonLeft' && child.id != 'divButtonRight')
            child.remove();
    });

    addEditButton();
}

function onButtonDelete()
{
    // generate loading animation
    let btn = document.getElementById('buttonDeleteAccount');
    btn.innerHTML = '';
    btn.style.display = 'flex';
    btn.style.justifyContent = 'center';

    let animation = document.createElement('span');
    animation.className = 'spinner-border spinner-border-sm';
    animation.id = 'deleteAnimation';
    btn.appendChild(animation);
    btn.style.height = '38px';

    $.ajax({
        type: "GET",
        url: "MojProfil?handler=DeleteAccount",
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).then(function (response)
    {
        if (response)
        {
            // success
            window.location.href = 'Index?deleted';
        }
        else
        {
            // failure
            window.location.href = 'MojProfil?deleteFailed';
        }
    });

}

function addEditButton()
{
    let buttonContainer = document.getElementById('divButtonRight');
    let btnEdit = document.createElement('button');
    btnEdit.className = 'btn btn-info btn-blue myButton';
    btnEdit.id = 'buttonEdit';
    btnEdit.innerHTML = fetchLangData('ButtonEdit');
    let icon = document.createElement('i');
    icon.className = 'fas fa-edit buttonIcon';
    btnEdit.appendChild(icon);
    btnEdit.onclick = generateEditSection;
    buttonContainer.appendChild(btnEdit);
}

function savePassword()
{
    // clear all previous error messages
    let row = document.getElementById('rowPasswordContainer');
    row.querySelectorAll('*').forEach(child =>
    {
        if (child.className == 'myProfileErrorMessage' || child.className == 'myProfileItemRow hidden')
            child.remove();
    });

    // verify old password
    let oldPass = row.querySelector('#inputOldPassword');

    if (oldPass.value == '')
    {
        displayChangePasswordError('ErrorOldPasswordEmpty');
        return;
    }

    if (!verifyPassword(oldPass.value))
    {
        displayChangePasswordError('ErrorWrongOldPassword');
        return;
    }

    // validate new password
    let newPass = row.querySelector('#inputNewPassword');

    if (newPass.value == '')
    {
        displayChangePasswordError('ErrorNewPasswordEmpty');
        return;
    }

    let validationResult = validatePassword(newPass.value);
    if (validationResult != null && validationResult.length > 0)
    {
        validationResult.forEach(x => displayChangePasswordError(x, true));
        return;
    }

    // display 'successful password change' message
    displayNotification('success', fetchLangData('NotificationSuccessfulPasswordChange'));
    generateChangePasswordDiv();
}

function verifyPassword(pass)
{
    return $.ajax({
        type: "GET",
        url: "MojProfil?handler=VerifyOldPassword&oldPass=" + pass,
        contentType: "application/json; charset=utf-8",
        async: false,
        dataType: "json"
    }).responseJSON;
}

function validatePassword(pass)
{
    return $.ajax({
        type: "GET",
        url: "MojProfil?handler=ValidatePassword&newPass=" + pass,
        contentType: "application/json; charset=utf-8",
        async: false,
        dataType: "json"
    }).responseJSON;
}

function displayChangePasswordError(passKey, raw = false)
{
    let row = document.getElementById('rowPasswordContainer');
    let lblError = document.createElement('small');
    lblError.style.color = 'red';
    if (raw)
        lblError.innerHTML = passKey;
    else
        lblError.innerHTML = fetchLangData(passKey);
    let rowDiv = document.createElement('div');
    rowDiv.className = 'myProfileItemRow hidden';
    rowDiv.style.justifyContent = 'center';
    let container = document.createElement('div');
    container.style.marginTop = '10px';
    container.appendChild(lblError);
    rowDiv.appendChild(container);
    row.appendChild(rowDiv);
}

function displayNotification(type, message)
{
    toastr.options.positionClass = 'toast-bottom-right';
    toastr[type](message);
}

function onButtonSave()
{
    // clear all previous error messages
    let rowContainer = document.getElementById('MyProfileData');
    rowContainer.querySelectorAll('*').forEach(child =>
    {
        if (child.className == 'myProfileErrorMessage' || child.className == 'myProfileItemRow hiddenData')
            child.remove();
    });

    // validate new data
    let data = new Array();
    let dataInputs = ['FirstName', 'LastName', 'Username', 'Gender', 'GenderToWorkWith', 'DateOfBirth', 'PhoneNumber'];
    dataInputs.forEach(input =>
    {
        var inputElement = document.getElementById('input' + input);
        if (inputElement != null)
            data.push(encodeURIComponent(inputElement.value));
    });

    let errorMessages = validateNewData(data);
    if (errorMessages != null && errorMessages.length > 0)
    {
        errorMessages.forEach(message =>
        {
            displayError(message.id, message.text);
        })
        return;
    }

    // display 'successful update' message
    displayNotification('success', fetchLangData('NotificationSuccessfulDataChange'));
    getKorisnik(getCookie('username'));
    if (korisnik.tipKorisnika == 'f')
        korisnik.polKojiSisa = document.getElementById('inputGenderToWorkWith').value;

    getKorisnik(getCookie('username'), true);
    onButtonCancel();
}

function displayError(rowID, message)
{
    let parent = document.getElementById('MyProfileData');
    let row = document.getElementById(rowID);

    let lblError = document.createElement('small');
    lblError.className = 'myProfileErrorMessage';
    lblError.innerHTML = message;

    let rowDiv = document.createElement('div');
    rowDiv.className = 'myProfileItemRow hiddenData';
    let cont = document.createElement('div');
    cont.className = 'myProfileItemContainer item-left';
    let container = document.createElement('div');
    container.className = 'myProfileItemContainer item-right';
    container.appendChild(lblError);
    rowDiv.appendChild(cont);
    rowDiv.appendChild(container);
    parent.insertBefore(rowDiv, row.nextSibling);
}

function validateNewData(data)
{
    return $.ajax({
        type: "GET",
        url: "MojProfil?handler=ValidateNewData&data=" + data,
        contentType: "application/json",
        async: false,
        dataType: "json"
    }).responseJSON;
}

function generateCommentsSection()
{
    let centeredDiv = document.createElement('div');
    centeredDiv.style.display = 'flex';
    centeredDiv.style.justifyContent = 'center';
    let commentSection = document.createElement('div');
    commentSection.className = 'MyProfileContainer';
    commentSection.id = 'commentsSection';
    centeredDiv.appendChild(commentSection);
    document.body.appendChild(centeredDiv);

    let ulogovanKorisnik = getKorisnik(getCookie('username'));
    if (ulogovanKorisnik != null)
    {
        if (ulogovanKorisnik.tipKorisnika == 'm' && korisnik.tipKorisnika == 'f')
        {
            let yourCommentContainer = document.createElement('div');
            yourCommentContainer.style.display = 'flex';
            yourCommentContainer.style.flexDirection = 'column';
            yourCommentContainer.style.marginBottom = '20px';
            yourCommentContainer.style.marginTop = '20px';
            yourCommentContainer.style.marginLeft = '20px';
            yourCommentContainer.style.marginRight = '20px';

            let authorRow = document.createElement('div');
            authorRow.style.display = 'flex';

            let yourCommentAuthor = document.createElement('label');
            yourCommentAuthor.className = 'commentAuthor';
            yourCommentAuthor.innerHTML = ulogovanKorisnik.username + ':';

            authorRow.appendChild(yourCommentAuthor);

            let yourCommentRow = document.createElement('div');
            yourCommentRow.style.display = 'flex';

            let textbox = document.createElement('textarea');
            textbox.className = 'form-control';
            textbox.id = 'yourComment';
            textbox.rows = '2';
            textbox.maxLength = '100';
            textbox.placeholder = fetchLangData('YourComment');
            textbox.oninput = function ()
            {
                if (textbox.value == "")
                    document.getElementById('buttonPost').disabled = true;
                else
                    document.getElementById('buttonPost').disabled = false;

            }           
            textbox.style.width = '100%';
            yourCommentRow.appendChild(textbox);

            let btnRow = document.createElement('div');
            btnRow.style.display = 'flex';
            btnRow.style.flexDirection = 'row-reverse';
            btnRow.style.marginTop = '10px';

            let btnPost = document.createElement('button');
            btnPost.className = 'btn btn-primary';
            btnPost.style.height = '30px';
            btnPost.style.boxSizing = 'border-box';
            btnPost.style.lineHeight = '0px';
            btnPost.id = 'buttonPost';
            btnPost.innerText = fetchLangData('ButtonPost');
            btnPost.onclick = addComment;
            btnPost.disabled = true;

            btnRow.appendChild(btnPost);

            yourCommentContainer.appendChild(authorRow);
            yourCommentContainer.appendChild(yourCommentRow);
            yourCommentContainer.appendChild(btnRow);

            commentSection.appendChild(yourCommentContainer);
        }
    }

    if (komentari.length == 0)
    {
        let noCommentsDiv = document.createElement('div');
        noCommentsDiv.className = 'noCommentRow';

        let noCommentsLabel = document.createElement('label');
        noCommentsLabel.id = 'NoCommentsLabel';
        noCommentsLabel.innerHTML = fetchLangData('NoCommentsLabel');

        noCommentsDiv.appendChild(noCommentsLabel);
        commentSection.appendChild(noCommentsDiv);

        return;
    }

    loadComments(komentari);
}

function loadComments()
{
    let lastRow;
    let doubleRow = false;
    let leftSide = true;
    komentari.forEach(comment =>
    {
        let row = document.createElement('div');
        row.className = 'commentRow';
        let commentRow = document.createElement('div');
        commentRow.style.display = 'flex';

        let authorRow = document.createElement('div');
        authorRow.style.display = 'flex';
        let commentAuthor = document.createElement('label');
        commentAuthor.innerHTML = comment.autor.username + ':';
        commentAuthor.className = 'commentAuthor';
        let commentTime = document.createElement('label');
        commentTime.className = 'commentTime';
        var time = new moment(comment.vreme, 'MM/DD/YYYY HH:mm:ss A');
        moment.locale(fetchLangData('', true));
        commentTime.innerHTML = '(' + moment([time.year(), time.month(), time.date(), time.hours(), time.minutes()]).fromNow() + ')';
        authorRow.appendChild(commentAuthor);
        authorRow.appendChild(commentTime);

        let commentContainer = document.createElement('div');
        commentContainer.className = 'commentContainer';
        commentContainer.appendChild(authorRow);

        let commentElement = document.createElement('div');
        commentElement.className = 'comment';
        if (comment.sadrzaj.length > 58)
        {
            commentElement.style.height = '100px';
            doubleRow = true;
        }
        else
            doubleRow = false;
        let commentLabel = document.createElement('label');
        commentLabel.className = 'commentLabel';
        commentLabel.innerHTML = comment.sadrzaj;
        commentElement.appendChild(commentLabel);

        let ulogovanKorisnik = getKorisnik(getCookie('username'));
        let buttonContainer = null;
        if (ulogovanKorisnik.tipKorisnika == 'v')
        {
            // generate delete comment button
            buttonContainer = document.createElement('div');
            buttonContainer.style.display = 'flex';
            buttonContainer.style.flexGrow = '1';
            buttonContainer.style.marginLeft = '10px';
            buttonContainer.style.marginRight = '10px';
            let commentButtonDelete = document.createElement('button');
            commentButtonDelete.className = 'btn btn-secondary';
            commentButtonDelete.style.display = 'flex';
            commentButtonDelete.style.justifyContent = 'center';
            commentButtonDelete.style.height = '27px';
            commentButtonDelete.style.width = '25px';
            commentButtonDelete.style.lineHeight = '0';
            commentButtonDelete.onclick = function ()
            {
                $('#modalDeleteComment').modal();
                komentarZaBrisanje = comment.id;
            }
            let iconDelete = document.createElement('i');
            iconDelete.className = 'far fa-trash-alt fa-sm';
            commentButtonDelete.appendChild(iconDelete);
            buttonContainer.appendChild(commentButtonDelete);
            commentElement.appendChild(buttonContainer);
        }

        commentContainer.appendChild(commentElement);
        commentRow.appendChild(commentContainer);
        row.appendChild(commentRow);

        let parent = document.getElementById('commentsSection');
        parent.appendChild(row);

        if (leftSide)
        {
            authorRow.style.flexDirection = 'row';
            commentRow.style.flexDirection = 'row';
            commentElement.style.flexDirection = 'row';
            if (buttonContainer != null)
                buttonContainer.style.flexDirection = 'row-reverse';
        }
        else
        {
            authorRow.style.flexDirection = 'row-reverse';
            commentRow.style.flexDirection = 'row-reverse';
            commentElement.style.flexDirection = 'row-reverse';
            if (buttonContainer != null)
                buttonContainer.style.flexDirection = 'row';
        }

        leftSide = !leftSide;
        lastRow = row;
    });

    if (doubleRow)
        lastRow.style.marginBottom = '50px';
}

function addComment()
{
    let textbox = document.getElementById('yourComment');
    if (textbox.value == '')
        return;

    let result = $.ajax({
        type: "GET",
        url: "MojProfil?handler=PostComment&content=" + encodeURIComponent(textbox.value) + "&barber=" + encodeURIComponent(getUsernameFromURL()),
        contentType: "application/json",
        async: false,
        dataType: "json"
    }).responseJSON;

    if (!result)
    {
        displayNotification('error', fetchLangData('NotificationCommentFailed'))
        return;
    }
    else
    {
        // removing previous comments
        document.querySelectorAll('.commentRow,.noCommentRow').forEach(row => row.remove());

        // getting updated list of comments
        getComments(getUsernameFromURL());
        sortComments();
        loadComments();

        textbox.value = '';
        displayNotification('success', fetchLangData('NotificationCommentAdded'))
    }
}

function deleteComment()
{
    let result = $.ajax({
        type: "GET",
        url: "MojProfil?handler=DeleteComment&id=" + komentarZaBrisanje,
        contentType: "application/json",
        async: false,
        dataType: "json"
    }).responseJSON;

    if (!result)
    {
        displayNotification('error', fetchLangData('NotificationCommentDeleteFailed'))
        return;
    }
    else
    {
        // removing previous comments
        document.querySelectorAll('.commentRow,.noCommentRow').forEach(row => row.remove());

        // getting updated list of comments
        getComments(getUsernameFromURL());
        sortComments();
        loadComments();

        displayNotification('success', fetchLangData('NotificationCommentDeleted'))
    }
}

function rateBarber()
{
    let ocena = $('.my-rating-4').starRating('getRating')
    let result = $.ajax({
        type: "GET",
        url: "MojProfil?handler=RateBarber&user=" + korisnik.username + '&rating=' + ocena,
        contentType: "application/json",
        async: false,
        dataType: "json"
    }).responseJSON;

    if (result == null)
    {
        displayNotification('error', fetchLangData('NotificationRatingFailed'));
        return;
    }
    else
    {
        let container = document.getElementById('ratingSection');
        let lblRow = document.createElement('div');
        lblRow.id = 'lblAlreadyRated';
        lblRow.style.display = 'flex';
        lblRow.style.justifyContent = 'center';
        let labelRatingInfo = document.createElement('label');
        labelRatingInfo.color = 'grey';
        labelRatingInfo.innerHTML = fetchLangData('LabelAlreadyRated');
        labelRatingInfo.style.marginTop = '10px';

        lblRow.appendChild(labelRatingInfo);
        container.appendChild(lblRow);

        document.getElementById('buttonRate').disabled = true;
        document.getElementById('stat2').innerHTML = result;

        displayNotification('success', fetchLangData('NotificationRatingAdded'));
    }

}