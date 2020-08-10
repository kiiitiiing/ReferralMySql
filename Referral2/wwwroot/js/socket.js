
function init() {
    output = document.getElementById("MessageChatBox");
}

function Initialize(wsUri) {
    websocket = new WebSocket(wsUri);
    websocket.onopen = function (evt) { onOpen(evt) };
    websocket.onclose = function (evt) { onClose(evt) };
    websocket.onmessage = function (evt) { onMessage(evt) };
    websocket.onerror = function (evt) { onError(evt) };
}

function onOpen(evt) {
}

function onClose(evt) {
}

function onMessage(evt) {
    var parsedata = JSON.parse(evt.data);
    switch (parsedata.InformationType) {
        default:
            console.log("default");
            break;
    }
}

function SubmitUserInformation(getuser) {
    var url = "/ViewPatients/GetUserInformation/";
    $.ajax({
        type: "POST",
        url: url,
        data: {
            user: JSON.stringify(getuser),
        },
        success: function (data) {
            doSend(JSON.stringify(data));
        },
    });
}

function EnveloperPatientInformation(getpatient) {
    var url = "/ViewPatients/GetPatientInformation/";

    var data =
    {
        patient: JSON.stringify(getpatient),
    };

    $.ajax({
        type: "POST",
        url: url,
        data: data,
        success: function (data) {
            doSend(JSON.stringify(data));
        },
    });
}

function onError(evt) {
}

function doSend(message) {
    websocket.send(message);
}

window.addEventListener("load", init, false);