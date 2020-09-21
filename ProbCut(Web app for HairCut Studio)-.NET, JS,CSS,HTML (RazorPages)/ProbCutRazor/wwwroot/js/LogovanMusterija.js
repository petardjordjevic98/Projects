let dani = 0;
let prikazan = null;
let crvenaBoja = '#FF8080';
let svetloCrvenaBoja = '#FFAEAE';

let izabraniDan;
let izabraniFrizer;
let frizeri;

let fetchLangData = function (resourceName, lang = false) {
    let result;
    if (lang) {
        $.ajax({
            type: "GET",
            url: "LogovanMusterija?handler=LangData&resourceName=" + resourceName + "&lang=true",
            contentType: "application/json; charset=utf-8",
            async: false,
            dataType: "json",
            success: function (response) {
                result = response;
            }
        });
    }
    else {
        $.ajax({
            type: "GET",
            url: "LogovanMusterija?handler=LangData&resourceName=" + resourceName,
            contentType: "application/json; charset=utf-8",
            async: false,
            dataType: "json",
            success: function (response) {
                result = response;
            }
        });
    }
    return result;
}

$(window).on('load', function () {

    // display notification
    if (location.href.includes('scheduled')) {
        toastr.options.positionClass = 'toast-bottom-right';
        toastr['success'](fetchLangData('NotificationScheduled'));
    }

    const container = document.createElement('div');
    container.className = 'rcorners';
    document.body.appendChild(container);

    const GlavniDiv = document.createElement("div");
    GlavniDiv.id = "GlavniDiv";
    document.body.appendChild(GlavniDiv);
  
    $.ajax({
        type: "GET",
        url: "LogovanMusterija?handler=Frizeri",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response != null) {
                frizeri = response;

                const containerButtons = document.createElement('div');
                containerButtons.className = 'containerButtons';

                const containerFrizeri = document.createElement('div');
                containerFrizeri.className = 'containerFrizeri';

                const labelContainer = document.createElement('div');
                labelContainer.className = 'labelBarbersContainer';
                const labelFrizeri = document.createElement('label');
                labelFrizeri.innerHTML = fetchLangData('LabelBarbers');
                labelContainer.appendChild(labelFrizeri);

                const sortBarbers = document.createElement('select');
                sortBarbers.className = 'form-control';
                sortBarbers.style.width = '100px';
                const option1 = document.createElement('option');
                option1.innerHTML = fetchLangData('SortBarbersAll');
                const option2 = document.createElement('option');
                option2.innerHTML = fetchLangData('SortBarbersMale');
                const option3 = document.createElement('option');
                option3.innerHTML = fetchLangData('SortBarbersFemale');
                const option4 = document.createElement('option');
                option4.innerHTML = fetchLangData('SortBarbersRating');
                sortBarbers.appendChild(option1);
                sortBarbers.appendChild(option2);
                sortBarbers.appendChild(option3);
                sortBarbers.appendChild(option4);
                sortBarbers.onchange = function () {

                    // clear all shown barbers
                    let cont = document.getElementsByClassName('containerFrizeri')[0];
                    while (cont.children[0])
                        cont.removeChild(cont.children[0]);

                    let tmp = new Array();
                    if (sortBarbers.value == fetchLangData('SortBarbersRating')) {
                        tmp = frizeri;
                        tmp.sort(function (a, b) { return b.prosecnaOcena - a.prosecnaOcena });
                        tmp.forEach(data => drawBarber(containerFrizeri, data));
                    }
                    else if (sortBarbers.value == fetchLangData('SortBarbersAll')) {
                        frizeri.forEach(data => drawBarber(containerFrizeri, data));
                    }
                    else if (sortBarbers.value == fetchLangData('SortBarbersMale')) {
                        frizeri.forEach(data => { if (data.polKojiSisa == 'M') tmp.push(data); })
                        tmp.forEach(data => drawBarber(containerFrizeri, data));
                    }
                    else if (sortBarbers.value == fetchLangData('SortBarbersFemale')) {
                        frizeri.forEach(data => { if (data.polKojiSisa == 'Z') tmp.push(data); })
                        tmp.forEach(data => drawBarber(containerFrizeri, data));
                    }
                }

                const labelSort = document.createElement('label');
                labelSort.className = 'labelSortBy';
                labelSort.innerHTML = fetchLangData('LabelSortBy');

                containerButtons.appendChild(sortBarbers);
                containerButtons.appendChild(labelSort);
                containerButtons.appendChild(labelContainer);

                container.appendChild(containerButtons);
                container.appendChild(containerFrizeri);

                response.forEach(data => drawBarber(containerFrizeri, data));
            }
        }
    });
});

function PrikaziTermine(termini, danasnji) {
    prikazan = 1;
   
    let DesniDiv = document.createElement("div");
    GlavniDiv.appendChild(DesniDiv);
    DesniDiv.id = "ZaPrikaz";

    let danas = document.createElement("div");
    danas.innerHTML = fetchLangData("Danas");
    danas.id = "datum";

    let dugmeZaDanas = document.createElement("button");
    dugmeZaDanas.innerHTML = fetchLangData("Raspored");
    dugmeZaDanas.className = "DanasnjiDan";
    dugmeZaDanas.onclick = function () {
        GetTermini(danasnji, new moment());
    }
    let PrikazanDan = document.createElement("div");
    PrikazanDan.className = "DivZaPrikazanog";
    PrikazanDan.id = "Prikazan";

    let PrikazanDiv = document.createElement("div");
    PrikazanDiv.className = "Prikazan";
    PrikazanDiv.id = "brisanje";

    PrikazanDiv.appendChild(danas);
    PrikazanDan.appendChild(PrikazanDiv);
    DesniDiv.appendChild(PrikazanDan);

    Danas(danas, danasnji);

    DesniDiv.appendChild(dugmeZaDanas);

    const buttonSchedule = document.createElement('button');
    buttonSchedule.className = 'btn btn-primary';
    buttonSchedule.innerHTML = fetchLangData('ButtonAdd');
    buttonSchedule.style.display = 'flex';
    buttonSchedule.style.margin = '10px auto';
    buttonSchedule.onclick = function () { if (izabraniDan != null) $('#modalSchedule').modal(); }

    DesniDiv.appendChild(buttonSchedule);

    let PrvaNedelja = document.createElement("div");
    PrvaNedelja.className = "Sedmica";


    let DrugaNedelja = document.createElement("div");
    DrugaNedelja.className = "Sedmica";

    DesniDiv.appendChild(PrvaNedelja);
    DesniDiv.appendChild(DrugaNedelja);
    termini.forEach(data => {
        dani++;
        let divZaDan = document.createElement("div");
        divZaDan.className = "dan";

        let divZaDanUNedelji = document.createElement("div");
        divZaDanUNedelji.innerHTML = fetchLangData(data.dan);
        divZaDanUNedelji.className = "DanUNedelji";

        let btn = document.createElement("button");

        btn.className = "ImeDana";
        btn.onclick = function () {

            if (data.termini != null)
                GetTermini(data.termini, data.datum);
        };
        btn.innerHTML = data.danUMesecu;
        if (data.termini != null && data.termini.length != 0) {
            btn.style.backgroundColor = svetloCrvenaBoja;
            divZaDanUNedelji.style.backgroundColor = crvenaBoja;
        }


        divZaDan.appendChild(divZaDanUNedelji);
        divZaDan.appendChild(btn);

        if (dani <= 7)
            PrvaNedelja.appendChild(divZaDan);
        else
            DrugaNedelja.appendChild(divZaDan);
    });

    if (termini.length == 0) {
        const labelContainer = document.createElement('div');
        labelContainer.className = 'labelContainer';
        const labelNoApps = document.createElement('label');
        labelNoApps.innerHTML = fetchLangData('LabelNoAppointments');
        labelContainer.appendChild(labelNoApps);

        document.getElementsByClassName('Prikazan')[0].appendChild(labelContainer);
    }
}

function GetTermini(termini, vreme) {

    izabraniDan = moment(vreme).format("yyyy-MM-DD");

    var p = document.getElementById("Prikazan");
    var p1 = document.getElementById("brisanje");

    if (prikazan != null)
        p.removeChild(p1);

    let danas = document.createElement("div");

    if (moment(vreme).format('MM/DD/YYYY') == moment().format('MM/DD/YYYY'))
        danas.innerHTML = fetchLangData('Danas');
    else
        danas.innerHTML = moment(vreme).format('MM/DD/YYYY');

    danas.id = "datum";

    let zadodavanje = document.getElementById("Prikazan");
    let IzabranDan1 = document.createElement("div");

    IzabranDan1.className = "Prikazan";
    IzabranDan1.id = "brisanje";
    IzabranDan1.appendChild(danas);
    zadodavanje.appendChild(IzabranDan1);

    termini.forEach(t => {

        let termin = document.createElement("div");
        termin.style.backgroundColor = crvenaBoja;
        termin.style.color = "White";
        termin.className = "Termin";

        let vrsta = document.createElement("div");
        vrsta.className = "vrsta";
        vrsta.innerHTML = moment(t.vreme).format("HH:mm") + " " + t.vrstaUsluge;
        let minuti;
        if (t.trajanjeUMinutima > 1) {
            minuti = fetchLangData("Minuti");
        }
        else {
            minuti = fetchLangData("Minut");
        }

        let trajanje = document.createElement("div");
        trajanje.innerHTML = t.trajanjeUMinutima + " " + minuti;
        trajanje.className = "trajanje";


        termin.appendChild(vrsta);
        termin.appendChild(trajanje);
        danas.appendChild(termin);

    });

    if (termini.length == 0) {
        const labelContainer = document.createElement('div');
        labelContainer.className = 'labelContainer';
        const labelNoApps = document.createElement('label');
        labelNoApps.innerHTML = fetchLangData('LabelNoAppointments');
        labelContainer.appendChild(labelNoApps);

        document.getElementsByClassName('Prikazan')[0].appendChild(labelContainer);
    }
}

function Danas(danas, danasnji) {
    if (danasnji != null) {
        danasnji.forEach(data => {

            let termin = document.createElement("div");
            termin.style.backgroundColor = crvenaBoja;
            termin.style.color = "White";
            termin.className = "Termin";

            let vrsta = document.createElement("div");
            vrsta.className = "vrsta";
            vrsta.innerHTML = moment(data.vreme).format("HH:mm") + " " + data.vrstaUsluge;

            let trajanje = document.createElement("div");
            let minuti;
            if (data.trajanjeUMinutima > 1) {
                minuti = fetchLangData("Minuti");
            }
            else {
                minuti = fetchLangData("Minut");
            }
            trajanje.className = "trajanje";
            trajanje.innerHTML = data.trajanjeUMinutima + " " + minuti;

            termin.appendChild(vrsta);
            termin.appendChild(trajanje);
            danas.appendChild(termin);
        });
    }
}

function drawBarber(parent, data) {
    const btn = document.createElement('div');
    btn.className = 'profileHeader';

    const image = document.createElement('img');
    image.className = 'profileImage';
    if (data.pol == 'Z')
        image.src = '../lib/custom/avatar_female.png';
    else
        image.src = '../lib/custom/avatar_male.png';
    btn.appendChild(image);

    const usernameLink = document.createElement('a');
    usernameLink.className = 'usernameLink';
    usernameLink.innerHTML = data.username;
    usernameLink.href = './MojProfil?username=' + data.username;

    btn.appendChild(usernameLink);

    btn.onclick = function () {
        if (prikazan != null) {
            const brisanje = document.getElementById("ZaPrikaz");
            GlavniDiv.removeChild(brisanje);
            dani = 0;
        }
        izabraniFrizer = data.username;
        PrikaziTermine(data.terminiZaDveNedelje, data.danasnjiTermini);
    }
    parent.appendChild(btn);
}

$('#buttonSchedule').on('click', function () {

    const vreme = document.getElementById('inputTime').value;
    const trajanje = document.getElementById('inputDuration').value;
    const vrstaUsluge = document.getElementById('inputType').value;

    let vr = izabraniDan + ' ' + vreme;

    $.ajax({
        type: "GET",
        url: "LogovanMusterija?handler=Zakazi&username=" + izabraniFrizer + "&vreme=" + vr + "&trajanje=" + +trajanje + "&vrsta=" + vrstaUsluge,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
            location.href = 'LogovanMusterija?scheduled';
        }
    });
})