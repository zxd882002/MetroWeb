function getStationName() {
    var sendData = '{"stationId":"' + $("#StationId").val() + '"}';
    //alert(sendData);
    $.ajax({
        type: 'post',
        url: 'http://localhost:8732/MetroWebService.svc/GetStationByStationId',
        contentType: 'text/json',
        data: sendData,
        success: function (msg) {
            var station = eval(msg.d);
            $('#StationName').text(station.NameGraph.text);
        },
        error: function (response) {
            alert(response.statusText);
        }
    });
}

function getRoute() {
    var fromStationName = $('#FromStationName').val();
    var fromLine = $('#FromLine').val();
    var toStationName = $('#ToStationName').val();
    var toLine = $('#ToLine').val();
    var sendData = '{"fromStationName":"' + fromStationName + '","fromLine":"' + fromLine +
                   '","toStationName":"' + toStationName + '","toLine":"' + toLine + '"}';
    //alert(sendData);
    $.ajax({
        type: 'post',
        url: 'http://localhost:8732/MetroWebService.svc/GetNearestRoute',
        contentType: 'text/json',
        data: sendData,
        success: function (msg) {
            var route = msg.d;
            $('#route').html(route);
        },
        error: function (response) {
            alert(response.statusText);
        }
    });
}

function html_decode(str) {
    var s = "";
    if (str.length == 0) return "";
    s = str.replace(/>/g, "&");
    s = s.replace(/</g, "<");
    s = s.replace(/>/g, ">");
    s = s.replace(/ /g, " ");
    s = s.replace(/'/g, "\'");
    s = s.replace(/"/g, "\"");
    s = s.replace(/<br>/g, "\n"); 
    return s;
}