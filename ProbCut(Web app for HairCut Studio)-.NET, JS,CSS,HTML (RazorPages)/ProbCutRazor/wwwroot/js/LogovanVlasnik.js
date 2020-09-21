let barberIdToDelete;

function fetchLangData(resourceName) {
    let result;
    $.ajax({
        type: "GET",
        url: "LogovanVlasnik?handler=LangData&resourceName=" + resourceName,
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
    toastr.options.positionClass = 'toast-bottom-right';
    if (location.href.includes('Deleted')) {
        toastr['success'](fetchLangData('NotificationSuccessfulDelete'));
    }
    else if (location.href.includes('Added')) {
        toastr['success'](fetchLangData('NotificationSuccessfulAdd'));
    }
})

$('.buttonDeleteBarber').on('click', function () {
    $('#modalDeleteBarber').modal();
    barberIdToDelete = this.id;
    console.log(barberIdToDelete);
});

$('#modalButtonDeleteBarber').on('click', function () {
    $.ajax({
        type: "GET",
        url: "LogovanVlasnik?handler=DeleteBarber&id=" + barberIdToDelete,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false
    });

    location.href = 'LogovanVlasnik?Deleted';
});