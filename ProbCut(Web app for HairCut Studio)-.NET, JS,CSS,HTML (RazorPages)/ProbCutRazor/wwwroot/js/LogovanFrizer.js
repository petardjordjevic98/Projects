let dani = 0;
let prikazan = "Prikazan";
let crvenaBoja = '#FF8080';
let svetloCrvenaBoja = '#FFAEAE';
let fetchLangData = function (resourceName, lang = false) {
    let result;
    if (lang) {
        $.ajax({
            type: "GET",
            url: "LogovanFrizer?handler=LangData&resourceName=" + resourceName + "&lang=true",
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
            url: "LogovanFrizer?handler=LangData&resourceName=" + resourceName,
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
    let dugmeZaDanas = document.createElement("button");
    dugmeZaDanas.innerHTML = fetchLangData("Raspored");
    dugmeZaDanas.className = "DanasnjiDan";
    
    let danas = document.createElement("div");
    danas.innerHTML = fetchLangData("Danas");
    danas.id = "datum";

    let PrikazanDan = this.document.createElement("div");
    PrikazanDan.className = "DivZaPrikazanog";
    PrikazanDan.id = "Prikazan";

    let PrikazanDiv = this.document.createElement("div");
    PrikazanDiv.className = "Prikazan";
    PrikazanDiv.id = "brisanje";

    PrikazanDiv.appendChild(danas);
    PrikazanDan.appendChild(PrikazanDiv);
    this.document.body.appendChild(PrikazanDan);

    Danas(danas);

    let PrvaNedelja = document.createElement("div");
    PrvaNedelja.className = "Sedmica";


    let DrugaNedelja = document.createElement("div");
    DrugaNedelja.className = "Sedmica";

    document.body.appendChild(dugmeZaDanas);

    document.body.appendChild(PrvaNedelja);
    document.body.appendChild(DrugaNedelja);

    $.ajax({
        type: "GET",
        url: "LogovanFrizer?handler=Termini",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response)
        {
            if (response != null) {
                response.forEach(data =>
                {
                    dani++;
                    let divZaDan = document.createElement("div");
                    divZaDan.className = "dan";

                    let divZaDanUNedelji = document.createElement("div");
                    divZaDanUNedelji.innerHTML = fetchLangData(data.dan);
                    divZaDanUNedelji.className = "DanUNedelji";

                    let btn = document.createElement("button");
                   
                    btn.className = "ImeDana";
                    btn.onclick = function () {

                        if (data.termini!=null)
                        GetTermini(data.termini, data.datum);
                    };
                    btn.innerHTML = data.danUMesecu;
                    if (  data.termini!=null && data.termini.length!=0 )
                    {
                        btn.style.backgroundColor = svetloCrvenaBoja;
                        divZaDanUNedelji.style.backgroundColor = crvenaBoja;
                    }
                 

                    divZaDan.appendChild(divZaDanUNedelji);
                    divZaDan.appendChild(btn);

                    if (dani <= 7)
                        PrvaNedelja.appendChild(divZaDan);
                    else
                        DrugaNedelja.appendChild(divZaDan);     
                })
            }
        }
    });
    dugmeZaDanas.onclick = function () {
        var p = document.getElementById(prikazan);
        var p1 = document.getElementById("brisanje");

        if (prikazan != null)
            p.removeChild(p1);

        let danas = document.createElement("div");
        danas.innerHTML = fetchLangData("Danas");
        danas.id = "datum";

        let zadodavanje = document.getElementById("Prikazan");

        let IzabranDan1 = document.createElement("div");

        IzabranDan1.className = "Prikazan";
        IzabranDan1.id = "brisanje";
        IzabranDan1.appendChild(danas);
        zadodavanje.appendChild(IzabranDan1);

        Danas(danas);
    }
});

function GetTermini(termini,vreme)
{
    
    var p = document.getElementById(prikazan);
    var p1 = document.getElementById("brisanje");
    
    if (prikazan != null) 
            p.removeChild(p1);

    let danas = document.createElement("div");
    danas.innerHTML = moment(vreme).format('MM/DD/YYYY');
    danas.id = "datum";

    let zadodavanje = document.getElementById("Prikazan");

    let IzabranDan1 = document.createElement("div");

    IzabranDan1.className = "Prikazan";
    IzabranDan1.id = "brisanje";
    IzabranDan1.appendChild(danas);
    zadodavanje.appendChild(IzabranDan1);

    let noApps = true;
    termini.forEach(t => {
        noApps = false;
        while (danas.children[0])
            danas.removeChild(danas.children[0]);

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

    if (noApps) {
        const labelContainer = document.createElement('div');
        labelContainer.className = 'labelContainer';
        const labelNoApps = document.createElement('label');
        labelNoApps.innerHTML = fetchLangData('LabelNoAppointments');
        labelContainer.appendChild(labelNoApps);

        document.getElementsByClassName('Prikazan')[0].appendChild(labelContainer);
    }
}

function Danas(danas) {
    $.ajax({
        type: "GET",
        url: "LogovanFrizer?handler=Danas",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response != null) {
                let noApps = true;
                response.forEach(data => {                    
                    noApps = false;
                    while (danas.children[0])
                        danas.removeChild(danas.children[0]);

                    let termin = document.createElement("div");
                    termin.style.backgroundColor = crvenaBoja;
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

                if (noApps) {
                    const labelContainer = document.createElement('div');
                    labelContainer.className = 'labelContainer';
                    const labelNoApps = document.createElement('label');
                    labelNoApps.innerHTML = fetchLangData('LabelNoAppointments');
                    labelContainer.appendChild(labelNoApps);

                    document.getElementsByClassName('Prikazan')[0].appendChild(labelContainer);
                }
            }
        }
    })
}