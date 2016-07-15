var varType;
var varUrl;
var varData;
var varContentType;
var varDataType;
var varProcessData;

function GenerateWCFparameterAndCallService(id) {
    varType = 'POST';
    varUrl = 'http://localhost:3128/MetroWebService.svc/GetSimpleStationInformation';
    varData = JSON.stringify('{"stationId":"' + id + '"}');
    varContentType = 'application/json; charset=utf-8';
    varDataType = 'json';
    varProcessData = false;
    CallService();
}

function CallService() {
    $.ajax({
        type: varType, //GET or POST or PUT or DELETE verb
        url: varUrl, // Location of the service
        data: varData, //Data sent to server
        contentType: varContentType, // content type sent to server
        dataType: varDataType, //Expected data format from server
        processdata: varProcessData, //True or False
        crossDomain: true,
        success: function (msg) {//On Successfull service call
            ServiceSucceeded(msg);
        },
        error: function (msg) {// When Service call fails
            ServiceFailed(msg);
        }
    });
}

function ServiceSucceeded(msg) {
    alert("succeed:" + msg);
}

function ServiceFailed(msg) {
    alert("fail:" + msg);
}

$(document).ready(function () {
    var metroCanvas = $("#metroCanvas");

    metroCanvas.drawRect({
        fillStyle: 'steelblue',
        strokeStyle: 'blue',
        strokeWidth: 4,
        x: 150,
        y: 100,
        fromCenter: false,
        width: 200,
        height: 100
    });

    var button = $("#station");
    button.click(function () {
        //alert("Buttn is clicked, button value = " + button.text());
        GenerateWCFparameterAndCallService(button.text());
    });
});