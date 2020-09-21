let korisnik;
let poruke;
let fetchLangData = function (resourceName, lang = false) {
    let result;
    if (lang) {
        $.ajax({
            type: "GET",
            url: "Inbox?handler=LangData&resourceName=" + resourceName + "&lang=true",
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
            url: "Inbox?handler=LangData&resourceName=" + resourceName,
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
    // main container
    const main = document.createElement('div');
    main.id = 'mainInbox';

    // conversations container
    const divConversations = document.createElement('div');
    divConversations.className = 'divConversations';
    main.appendChild(divConversations);

    const conversationsContainer = document.createElement('div');
    conversationsContainer.className = 'conversationsContainer';

    const labelConversations = document.createElement('label');
    labelConversations.innerHTML = fetchLangData('LabelConversations');
    labelConversations.className = 'labelConversations';
    divConversations.appendChild(labelConversations);

    const separator = document.createElement('hr');
    separator.className = 'inboxSeparator';
    divConversations.appendChild(separator);

    divConversations.appendChild(conversationsContainer);
    getKorisnik(getUsernameFromURL(), true);

    // senders
    $.ajax({
        type: "GET",
        url: "Inbox?handler=Senders",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response != null) {
                response.forEach(data => {
                    addConversation(data);
                })
            }
        }
    }).then(function () {

        // add conversation button

        const buttonAdd = document.createElement('button');
        buttonAdd.className = 'btn btn-primary';
        buttonAdd.id = 'buttonAddConversation';
        buttonAdd.innerHTML = fetchLangData('ButtonAdd');
        buttonAdd.onclick = function () {
            $.ajax({
                type: "GET",
                url: "Inbox?handler=User&username=" + textboxUsername.value,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                        addConversation(response).onclick();
                },
                error: function () {
                    // display error message

                    toastr.options.positionClass = 'toast-bottom-right';
                    toastr['error'](fetchLangData('NotificationNoSuchUsername'));
                }
            })
        }

        const textboxUsername = document.createElement('input');
        textboxUsername.className = 'textboxUsername';
        textboxUsername.type = 'text';
        textboxUsername.placeholder = fetchLangData('PlaceholderNewConversation');

        divConversations.appendChild(buttonAdd);
        divConversations.appendChild(textboxUsername);
    });

    // messages container

    const divMessageHistory = document.createElement('div');
    divMessageHistory.id = 'messageHistory';
    main.appendChild(divMessageHistory);

    // empty message history
    const messageHistory = document.createElement('div');
    messageHistory.className = 'GlavniContainer';
    main.appendChild(messageHistory);

    const labelContainer = document.createElement('div');
    labelContainer.id = 'labelSelect';
    
    const labelSelectConversation = document.createElement('label');
    labelSelectConversation.className = 'labelUsername'
    labelSelectConversation.innerHTML = fetchLangData('LabelSelectConversation');
    labelContainer.appendChild(labelSelectConversation);
    messageHistory.appendChild(labelContainer);

    document.body.appendChild(main);
});

function GetPoruke(ime) {
    $.ajax({
        type: "GET",
        url: "Inbox?handler=Poruke&odKoga=" + ime,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            poruke = response;
            sortPoruke();            
            generatePoruke(ime);
        }
    });
} 

function sortPoruke() {
    poruke = poruke.sort((a, b) => new moment(a.vreme, 'MM/DD/YYYY HH:mm:ss A') - new moment(b.vreme, 'MM/DD/YYYY HH:mm:ss A'));
}

function generatePoruke(ime) {
    let centeredDiv = document.getElementById("messageHistory");
    let MessageSection = document.getElementsByClassName('GlavniContainer')[0];
    MessageSection.id = ime;

    // clearing current message history
    while (MessageSection.children[0])
        MessageSection.children[0].remove();

    let PorukeProzori = document.createElement('div');
    PorukeProzori.className = 'PorukeContainer';
    PorukeProzori.id = ime + "poruke";
    MessageSection.appendChild(PorukeProzori);
    centeredDiv.appendChild(MessageSection);

    let PorukeContainer = document.createElement('div');
    PorukeContainer.style.display = 'flex';
    PorukeContainer.style.flexDirection = 'column';
    PorukeContainer.style.marginBottom = '20px';
    PorukeContainer.style.marginTop = '20px';
    PorukeContainer.style.marginLeft = '20px';
    PorukeContainer.style.marginRight = '20px';

    let messageRow = document.createElement('div');
    messageRow.style.display = 'flex';

    let mojaMessageRow = document.createElement('div');
    mojaMessageRow.style.display = 'flex';

    loadPoruke(ime);
}

function loadPoruke(ime) {
    let lastRow;
    let doubleRow = false;
    let leftSide = true;
    poruke.forEach(p => {

        let section = document.getElementById(ime + "poruke");

        let row = document.createElement('div');
        row.className = 'messageRow';
        let messageRow = document.createElement('div');
        messageRow.style.display = 'flex';

        let authorRow = document.createElement('div');
        authorRow.style.display = 'flex';
        let Sender = document.createElement('label');
        if (p.tip == "primljena") {
            leftSide = true;
            Sender.innerHTML = ime + ':';

        }
        else {
            leftSide = false;

            Sender.innerHTML = fetchLangData('Ko') + ":";
        }
        Sender.className = 'messageAuthor';
        let MessageTime = document.createElement('label');
        MessageTime.className = 'messageTime';
        var time = new moment(p.vreme, 'MM/DD/YYYY HH:mm:ss A');
        moment.locale(fetchLangData('', true));
        MessageTime.innerHTML = '(' + moment([time.year(), time.month(), time.date(), time.hours(), time.minutes()]).fromNow() + ')';
        authorRow.appendChild(Sender);
        authorRow.appendChild(MessageTime);

        let MessageContainer = document.createElement('div');
        MessageContainer.className = 'messageContainer';
        MessageContainer.appendChild(authorRow);
        section.appendChild(MessageContainer);
        let MessageElement = document.createElement('div');
        MessageElement.className = 'message';
        if (p.sadrzaj.length > 58) {
            MessageElement.style.height = '100px';
            doubleRow = true;
        }
        else
            doubleRow = false;
        let Messagelabel = document.createElement('label');
        Messagelabel.className = 'messageLabel';
        Messagelabel.innerHTML = p.sadrzaj;
        MessageElement.appendChild(Messagelabel);



        MessageContainer.appendChild(MessageElement);
        messageRow.appendChild(MessageContainer);
        row.appendChild(messageRow);

        let parent = document.getElementById(ime + "poruke");
        parent.appendChild(row);

        if (!leftSide) {
            authorRow.style.flexDirection = 'row';
            messageRow.style.flexDirection = 'row';
            MessageElement.style.flexDirection = 'row';

        }
        else {
            authorRow.style.flexDirection = 'row-reverse';
            messageRow.style.flexDirection = 'row-reverse';
            MessageContainer.style.flexDirection = 'column';

        }

        lastRow = row;
    });

    let divZaInput = document.createElement("div");
    divZaInput.id = "InputDiv";
    divZaInput.className = "SendingTextBox";

    const inputContainer = document.createElement('div');
    inputContainer.className = 'inputContainer';
    
    var input = document.createElement("input");
    input.className = "InputSend";
    input.type = "textbox";
    input.id = ime + "btn";
    input.placeholder = fetchLangData('placeHolder');
    
    var sek = document.getElementById(ime);
    sek.appendChild(divZaInput);
    var btn = document.createElement("button");
    btn.className = 'btn btn-info btn-blue myButton';
    btn.id = 'buttonEdit';   
    btn.innerHTML = fetchLangData("Posalji");
    var icon = document.createElement('i');
    icon.className = 'fas fa-paper-plane';
    icon.style.marginLeft = '5px';
    btn.appendChild(icon);
    input.addEventListener("keyup", function (event) {
        // Number 13 is the "Enter" key on the keyboard
        if (event.keyCode === 13) {
            btn.click();
        }
    });
    btn.onclick = function () {
       
        var input1 = document.getElementById(ime + "btn");
        var message = input1.value;
            
        $.ajax({
            type: "GET",
            url: "Inbox?handler=Posalji&message=" +encodeURIComponent(message) + "&primalac=" + encodeURIComponent(ime),
            contentType: "application/json; charset=utf-8",
            async: false,
            dataType: "json"           
        });       
        
        let section = document.getElementById(ime);

        let row = document.createElement('div');
        row.className = 'messageRow';
        let messageRow = document.createElement('div');
        messageRow.style.display = 'flex';

        let authorRow = document.createElement('div');
        authorRow.style.display = 'flex';
        let Sender = document.createElement('label');

        let commentTime = document.createElement('label');
        commentTime.className = 'commentTime';
        var time = new moment();
        moment.locale(fetchLangData('', true));
        commentTime.innerHTML = '(' + moment([time.year(), time.month(), time.date(), time.hours(), time.minutes()]).fromNow() + ')';

        leftSide = false;

        Sender.innerHTML = fetchLangData('Ko') + ":";
        Sender.className = 'messageAuthor';
        authorRow.appendChild(Sender);
        authorRow.appendChild(commentTime);

        let MessageContainer = document.createElement('div');
        MessageContainer.className = 'messageContainer';
        MessageContainer.appendChild(authorRow);
        section.appendChild(MessageContainer);
        let MessageElement = document.createElement('div');
        MessageElement.className = 'message';
        if (message.length > 58) {
            MessageElement.style.height = '100px';
            doubleRow = true;
        }
        else
            doubleRow = false;
        let Messagelabel = document.createElement('label');
        Messagelabel.className = 'messageLabel';
        Messagelabel.innerHTML = message;

        MessageElement.appendChild(Messagelabel);
        

        MessageContainer.appendChild(MessageElement);
        messageRow.appendChild(MessageContainer);
        row.appendChild(messageRow);

        let parent = document.getElementById(ime + "poruke");
        parent.appendChild(row);
        if (!leftSide) {
            authorRow.style.flexDirection = 'row';
            messageRow.style.flexDirection = 'row';
            MessageElement.style.flexDirection = 'row';
            }
        else {
            authorRow.style.flexDirection = 'row-reverse';
            messageRow.style.flexDirection = 'row-reverse';
            MessageContainer.style.flexDirection = 'row-reverse';

        }

        input1.value ="" ;
        }    
   
    inputContainer.appendChild(input);
    inputContainer.appendChild(btn);

    divZaInput.appendChild(inputContainer);

    if (doubleRow)
        lastRow.style.marginBottom = '50px';

}

function addConversation(data) {
    const divConversations = document.getElementsByClassName('conversationsContainer')[0];
    const conv = document.createElement('div');
    conv.className = 'conversation';

    const labelUsername = document.createElement('label');
    labelUsername.className = 'labelUsername';
    labelUsername.innerHTML = data.username;
    conv.appendChild(labelUsername);

    const labelType = document.createElement('label');
    labelType.className = 'labelType';
    labelType.innerHTML = data.tip;
    conv.appendChild(labelType);

    conv.onclick = function () { GetPoruke(data.username); };
    divConversations.appendChild(conv);

    return conv;
}

function getUsernameFromURL()
{
    return (new URLSearchParams(window.location.search)).get('username');
}

function getKorisnik(username, initialize = false) {
    return $.ajax({
        type: "GET",
        url: "Inbox?handler=Data&username=" + username,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            if (initialize && response.korisnik != null)
                korisnik = response.korisnik;
        }
    }).responseJSON.korisnik;
}
