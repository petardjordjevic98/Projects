function getUserType() {
    let result;
    $.ajax({
        type: "GET",
        url: "Cenovnik?handler=UserType",
        contentType: "application/json; charset=utf-8",
        async: false,
        dataType: "json",
        success: function (response) {
            result = response;
        }
    });
    return result;
}

function fetchLangData(resourceName) {
    let result;
    $.ajax({
        type: "GET",
        url: "Cenovnik?handler=LangData&resourceName=" + resourceName,
        contentType: "application/json; charset=utf-8",
        async: false,
        dataType: "json",
        success: function (response) {
            result = response;
        }
    });
    return result;
}

$(window).on('load', function () {
    if (getUserType() == 'vlasnik') {
        // generate edit section

        const container = document.getElementById('tableContainer');
        const buttonContainer = document.createElement('div');
        buttonContainer.className = 'buttonEditPricingContainer';

        const buttonEdit = document.createElement('button');
        buttonEdit.className = 'btn btn-primary';
        buttonEdit.id = 'buttonEditPricing';
        buttonEdit.innerHTML = fetchLangData('ButtonEdit');
        buttonEdit.onclick = generateEditSection;

        buttonContainer.appendChild(buttonEdit);
        container.insertBefore(buttonContainer, document.getElementById('pricingTable'));
    }
});

function generateEditSection() {

    const container = document.getElementsByClassName('buttonEditPricingContainer')[0];
    container.removeChild(container.children[0]);

    const buttonCancel = document.createElement('button');
    buttonCancel.className = 'btn btn-secondary';
    buttonCancel.id = 'buttonCancelPricing';
    buttonCancel.style.marginLeft = '5px';
    buttonCancel.innerHTML = fetchLangData('ButtonCancel');
    buttonCancel.onclick = removeEditSection;

    const buttonSave = document.createElement('button');
    buttonSave.className = 'btn btn-primary';
    buttonSave.id = 'buttonSavePricing';
    buttonSave.style.marginRight = '5px';
    buttonSave.innerHTML = fetchLangData('ButtonSave');
    buttonSave.onclick = saveChanges;

    container.appendChild(buttonCancel);
    container.appendChild(buttonSave);

    // enable editing
    const cells = document.getElementsByClassName('cell-editable');
    for (let cell of cells) {
        cell.setAttribute('contenteditable', 'true');
    }

    document.getElementById('HaircutMen').focus();
}

function removeEditSection() {
    const container = document.getElementsByClassName('buttonEditPricingContainer')[0];
    container.removeChild(container.children[0]);
    container.removeChild(container.children[0]);

    const buttonEdit = document.createElement('button');
    buttonEdit.className = 'btn btn-primary';
    buttonEdit.id = 'buttonEditPricing';
    buttonEdit.innerHTML = fetchLangData('ButtonEdit');
    buttonEdit.onclick = generateEditSection;

    container.appendChild(buttonEdit);

    // disable editing
    const cells = document.getElementsByClassName('cell-editable');
    for (let cell of cells) {
        cell.setAttribute('contenteditable', 'false');
    }
}

function saveChanges() {
    const container = document.getElementsByClassName('buttonEditPricingContainer')[0];
    container.removeChild(container.children[0]);
    container.removeChild(container.children[0]);

    const buttonEdit = document.createElement('button');
    buttonEdit.className = 'btn btn-primary';
    buttonEdit.id = 'buttonEditPricing';
    buttonEdit.innerHTML = fetchLangData('ButtonEdit');
    buttonEdit.onclick = generateEditSection;

    container.appendChild(buttonEdit);

    // disable editing
    const cells = document.getElementsByClassName('cell-editable');
    for (let cell of cells) {
        cell.setAttribute('contenteditable', 'false');
    }

    // save changes
    let priceValues = new Array();
    for (let i = 0; i < cells.length; i++) {
        let row = new Array();
        row.push(cells[i].id);
        row.push(cells[i].innerHTML);
        priceValues.push(row);
    }

    $.ajax({
        type: "GET",
        url: "Cenovnik?handler=SaveChanges&data=" + priceValues,
        contentType: "application/json; charset=utf-8",
        async: false,
        dataType: "json"
    });

    // display notification
    toastr.options.positionClass = 'toast-bottom-right';
    toastr['success'](fetchLangData('NotificationSuccessfulChange'));
}